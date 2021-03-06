﻿// <copyright file="Utilities.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Utility
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Text;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;

    /// <summary>
    /// Common utilities used in testing methods
    /// </summary>
    public class Utilities
    {
        private string logFile = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Utilities"/> class. Default Constructor.
        /// </summary>
        public Utilities()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Utilities"/> class.
        /// Normally Use to create a LOG file
        /// </summary>
        /// <param name="logPath">The log path.</param>
        public Utilities(string logPath)
        {
            Directory.CreateDirectory(logPath);
            this.LogFile = logPath + "\\logged.Txt";
        }

        /// <summary>
        /// Gets or sets the log file.
        /// </summary>
        /// <value>
        /// The log file.
        /// </value>
        public string LogFile
        {
            get
            {
                return this.logFile;
            }

            set
            {
                if (!File.Exists(value))
                {
                    File.Create(value).Close();
                }

                this.logFile = value;
            }
        }

        /// <summary>
        /// Tests for int custom method for string validation.
        /// </summary>
        /// <param name="itemToTest">The item to test.</param>
        /// <returns>bool</returns>
        public bool TestForInt(string itemToTest)
        {
            int cycles = 0;
            bool retVal = false;
            retVal = int.TryParse(itemToTest, out cycles);
            return retVal;
        }

        /// <summary>
        /// Randomly stops processing for web pages to catch up, 4 to 8 seconds pause time.
        /// </summary>
        public void RandomPause()
        {
            Random rdmTime = new Random();
            int pauseTime = rdmTime.Next(4096, 8192);
            Thread.Sleep(pauseTime);
        }

        /// <summary>
        /// Overloaded version for RandomPause, takes in a double convers to seconds to pause.
        /// </summary>
        /// <param name="seconds">The seconds.</param>
        public void RandomPause(double seconds)
        {
            double sleepyTime = seconds * 1000;

            Thread.Sleep(Convert.ToInt32(sleepyTime));
        }

        /// <summary>
        /// Stops for any nightly processing when tests are run on a 24 x 7 basis.
        /// </summary>
        /// <returns>bool</returns>
        public bool StopForNightlyProcessing()
        {
                bool goNoGoAnswer = true;

                DateTime dT = DateTime.Now;

                int timeIs = dT.Hour;

                Console.WriteLine("The Hour Is {0}", timeIs);

                if ((timeIs >= 22) || (timeIs < 2))
                {
                    goNoGoAnswer = false;
                    Console.WriteLine("All testing stops because of nightly processing");
                    Thread.Sleep(1500);
                }

                return goNoGoAnswer;
        }

        /// <summary>
        /// Checks for common loading errors returns a bool true if no errors found.
        /// </summary>
        /// <param name="pageText">The page text.</param>
        /// <returns>bool</returns>
        public bool PageIsGood(string pageText)
        {
            if (pageText.Contains("<title>Not Found</title>")
                || pageText.Contains("<title>Page Not Found</title>")
                || pageText.Contains("Unable")
                || pageText.Contains("page not available")
                || pageText.Contains("The page cannot be displayed because an internal server error has occurred."))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Makes the log entry.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        public void MakeLogEntry(string logMessage)
        {
            using (TextWriter txtWriter = new StreamWriter(this.LogFile, true))
            {
                txtWriter.WriteLine(logMessage);
                txtWriter.WriteLine(DateTime.Now.ToString("MMM:dd_HH:mm:ss"));
                txtWriter.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                txtWriter.Close();
            }
        }

        /// <summary>
        /// Old, but keep, will post a time stamp into the log for debug purpose.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="message">The message.</param>
        public void TrackingLogEntry(string path, string message)
        {
            using (TextWriter txtWriter = new StreamWriter(path, true))
            {
                txtWriter.WriteLine(message);
                txtWriter.WriteLine(DateTime.Now.ToString("MMM:dd_HH:mm:ss"));
                txtWriter.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                txtWriter.Close();
            }
        }

        /// <summary>
        /// Emails me log file from tests.
        /// Target is myself if passed.
        /// Others on the team if failing.
        /// </summary>
        /// <param name="passed">The passed.</param>
        /// <param name="failed">The failed.</param>
        /// <param name="etime">The etime.</param>
        /// <param name="testName">Name of the test.</param>
        /// <param name="testNotes">The test notes.</param>
        /// <param name="emailPassed">The email passed.</param>
        /// <param name="emailFailed">The email failed.</param>
        public void EmailMeLog(int passed, int failed, string etime, string testName, string testNotes, string emailPassed, string emailFailed)
        {
            string emailFromAddress = "Name@name.com";
            string emailFromName = "Name@Name.com";
            string smtpUser = "testing@bluewaterads.com";
            string smtpHost = "smtp.GoesHere.com"; // "office.com"; //msnhst.microsoft.com
            string smtpPassword = "pwd here";
            string emailToPassed = emailPassed;
            string emailToFailed = emailFailed;

            int portNumber = 587;

            StringBuilder sbBody = new StringBuilder();

            sbBody.Append("Test cases were run at = " + DateTime.Now.ToString("yyyyMMdd_HH:mm") + "</br>" + testName + "Automation Test </br>");
            sbBody.Append("PASSED = " + passed);
            sbBody.Append("</br>");
            sbBody.Append("FAILED = " + failed);
            sbBody.Append("</br>");
            sbBody.Append("The results log file is attached, and the time to run this suite of tests = " + etime);
            sbBody.Append("</br>");
            sbBody.Append("</br>");
            sbBody.Append(testNotes);
            sbBody.Append("</br>");
            sbBody.Append("</br>");

            MailMessage message = new MailMessage();
            SmtpClient sClient = new SmtpClient();

            message.From = new MailAddress(emailFromAddress, emailFromName);

            try
            {
                string[] toAddresses;

                if (failed == 0)
                {
                    toAddresses = emailToPassed.Split('|');

                    message.Subject = "PASSED automated test " + testName;
                }
                else
                {
                    toAddresses = emailToFailed.Split('|');

                    message.Subject = "FAILED FAILED FAILED automated test  ~ " + testName;

                    sbBody.Append("</br></br>");

                    sbBody.Append("IF there were any failures Scott Stemen is already looking at them.");
                }

                foreach (var address in toAddresses)
                {
                    message.To.Add(new MailAddress(address));
                }

                message.IsBodyHtml = true;
                message.Body = Convert.ToString(sbBody);

                using (FileStream fileReadingStream = new FileStream(this.LogFile, FileMode.Open, FileAccess.Read))
                {
                    Attachment logToAttach = new Attachment(
                        fileReadingStream, "Logs.txt", MediaTypeNames.Application.Octet);

                    message.Attachments.Add(logToAttach);

                    sClient.UseDefaultCredentials = false;

                    sClient.Credentials = new NetworkCredential(smtpUser, smtpPassword);

                    sClient.Port = portNumber;

                    sClient.Host = smtpHost;

                    sClient.DeliveryMethod = SmtpDeliveryMethod.Network;

                    sClient.EnableSsl = true;

                    sClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                this.MakeLogEntry("Email failed!!");
                this.MakeLogEntry(ex.ToString());
            }

            this.RandomPause(1);
            this.RandomPause(1);
        }

        /// <summary>
        /// Passwords the validation.
        /// </summary>
        /// <param name="userdataPassword">The userdata password.</param>
        /// <param name="testPassword">The test password.</param>
        /// <returns>bool</returns>
        public bool PasswordValidation(string userdataPassword, string testPassword)
        {
            bool passed = false;
            if (userdataPassword == testPassword)
            {
                Console.WriteLine("Passwords Match");
                this.MakeLogEntry("Passwords are a good match!");
                passed = true;
                return passed;
            }
            else
            {
                Console.WriteLine("+++++++++++++++++++++++++++++++++");
                Console.WriteLine("++  Passwords  DO  NOT  MATCH  ++");
                Console.WriteLine("+++++++++++++++++++++++++++++++++");
                Console.WriteLine("+++ We are stopping the tests +++");
                this.MakeLogEntry("FAIL FAIL FAIL" + Environment.NewLine + "These Passwords don't match" +
                                  Environment.NewLine + "Stopping");
                return passed;
            }
        }

        /// <summary>
        /// Old, verifies log on was successful, adapt to CCamps.
        /// </summary>
        /// <param name="continueTesting">if set to <c>true</c> [continue testing].</param>
        /// <param name="user">The user.</param>
        /// <returns>bool</returns>
        public bool LogonValidationTest(bool continueTesting, string user)
        {
            using (WebClient wClient = new WebClient())
            {
                wClient.Headers.Add("user-agent", "Mozilla/5.0 Chrome/55.0.2883.87 (Windows NT 10.0; Win64; x64)");

                using (StreamReader sReader = new StreamReader(wClient.OpenRead(user)))
                {
                    string response = sReader.ReadToEnd();
                    if (response.Contains("success") && response.Contains("true"))
                    {
                        continueTesting = true;
                    }

                    sReader.Dispose();
                }

                wClient.Dispose();
            }

            return continueTesting;
        }

        /// <summary>
        /// A pause timer for 5 sec, allow time to stop execution if running in prod.
        /// </summary>
        /// <returns>bool</returns>
        public bool CallToTimer5Sec()
        {
            bool continueAutomation = true;
            bool stillWaiting = true;
            int countIs = 0;

            string toUser =
                "Please press ENTER or 'X' to stop auto execution and enter custom user data" +
                Environment.NewLine +
                "If you don't in 10 seconds we will go on and run in automated Mode. ";

            while (stillWaiting)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo c = Console.ReadKey(true);
                    if (c.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine("Do you want to stop the automated run? \n\n   And enter custom data?");
                        string userEntered = Console.ReadLine();
                        continueAutomation = false;
                        stillWaiting = false;
                        break;
                    }
                }

                this.RandomPause(1);
                if (countIs++ < 5)
                {
                    Console.WriteLine("Current Count is {0}", countIs);
                    Console.WriteLine("Waiting");
                    stillWaiting = true;
                }
                else
                {
                    Console.WriteLine("Time and Count Exceeded");
                    Console.WriteLine("We will go on automatically now.");
                    Console.WriteLine("POOF!!");
                    stillWaiting = false;
                }
            }

            return continueAutomation;
        }

        /// <summary>
        /// Changes emails used for testing based upon a loop count.
        /// </summary>
        /// <param name="sentinalvalue">The sentinalvalue.</param>
        /// <param name="emailName">Name of the email.</param>
        /// <param name="emailDomain">The email domain.</param>
        /// <param name="emailNumber">The email number.</param>
        /// <param name="emailSend">The email send.</param>
        /// <returns>NewEmailToUse</returns>
        public string EmailChangeCode(int sentinalvalue, string emailName, string emailDomain, out int emailNumber, out string emailSend)
        {
            emailSend = string.Empty;

            emailNumber = sentinalvalue % 5;
            if (emailNumber == 0)
            {
                emailSend = string.Empty;
                emailNumber = 5;
                emailSend = emailName + emailNumber + emailDomain;
            }
            else
            {
                emailSend = string.Empty;
                emailSend = emailName + emailNumber + emailDomain;
            }

            return emailSend;
        }

        /// <summary>
        /// Parses page returned for text expected to find.
        /// </summary>
        /// <param name="ut">The ut.</param>
        /// <param name="pageSource">The page source.</param>
        /// <param name="testName">Name of the test.</param>
        /// <param name="lookForThisString">The look for this string.</param>
        /// <param name="passCount">The pass count.</param>
        /// <param name="failCount">The fail count.</param>
        /// <returns>bool</returns>
        public bool PageWeWanted(
            Utilities ut, string pageSource, string testName, string lookForThisString, ref int passCount, ref int failCount)
        {
            bool passedCorrectPage = false;
            try
            {
                Assert.IsTrue(pageSource.Contains(lookForThisString));
                Console.WriteLine("Expected page and text ~ {0} \n ", lookForThisString);
                ut.MakeLogEntry("We navigated to the correct page");
                passedCorrectPage = true;
                passCount = passCount + 1;
            }
            catch (Exception exTextException)
            {
                Console.WriteLine(exTextException);
                ut.MakeLogEntry(
                "There was an error with Test == " + testName + Environment.NewLine + "Error Below" + Environment.NewLine + exTextException);
                failCount = failCount + 1;
            }

            return passedCorrectPage;
        }

        /// <summary>
        /// Old, to be refactored for Coder Camps, made log entry based upon testing cycle count.
        /// </summary>
        /// <param name="ut">The ut.</param>
        /// <param name="emailSend">The email send.</param>
        /// <param name="countIs">The count is.</param>
        /// <param name="stopCount">The stop count.</param>
        /// <param name="refPassCount">The reference pass count.</param>
        /// <param name="refFailCount">The reference fail count.</param>
        public void CycleCounter(Utilities ut, string emailSend, int countIs, int stopCount, int refPassCount, int refFailCount)
        {
            Console.WriteLine("\n\n Email account this run = {0}", emailSend);
            Console.WriteLine("\n  We have completed = {0} cycles of this test", countIs + 1);
            Console.WriteLine("\n       We stil have {0} cycles to go", stopCount - (countIs + 1));
            Console.WriteLine("Our passed test count = {0}  :: Any Failures == {1} \n\n", refPassCount, refFailCount);

            ut.MakeLogEntry(
                Environment.NewLine + "Email account this run = " + emailSend + Environment.NewLine +
                "We have completed == " + (countIs + 1) + " cycles of this test run" + Environment.NewLine +
                "We still have = " + (stopCount - (countIs + 1)) + Environment.NewLine +
                "Our Pass Count = " + refPassCount + " :: Any Failures so far == " + refFailCount);
        }

        /// <summary>
        /// Parses a slow loading page for expected text when the is-dom-ready element isnt available.
        /// </summary>
        /// <param name="wDriver">The w driver.</param>
        /// <param name="helperUtilities">The helper utilities.</param>
        /// <param name="pageText">The page text.</param>
        /// <param name="textSearchingFor">The text searching for.</param>
        /// <returns>bool</returns>
        public bool PageIsReady(IWebDriver wDriver, Utilities helperUtilities, string pageText, string textSearchingFor)
        {
            int counter = 0;
            int stopAt = 135;
            bool passedTest = false;

            do
            {
                try
                {
                    Assert.IsTrue(pageText.Contains(textSearchingFor));
                    passedTest = true;
                }
                catch (Exception exTextException)
                {
                    if (counter == 0)
                    {
                        Console.WriteLine("\nWe will loop up to 65 seconds because of video upload time.");
                    }
                    else if (counter % 3 == 0)
                    {
                        Console.WriteLine("\nNOT an error, just page wasn't ready yet.  We are looping;  \n   and will report every 3rd loop\n");
                        Console.WriteLine("We have tried {0} cycles of this test and have {1} to go ", counter + 1, stopAt - counter - 1);
                        Console.WriteLine(exTextException.Message);
                        helperUtilities.MakeLogEntry("Page Text wasn't not visable to code yet we looped for a while.");
                        pageText = wDriver.PageSource;
                        passedTest = false;
                    }
                    else
                    {
                        helperUtilities.MakeLogEntry("Page Text wasn't not visable to code yet we looped for a while.");
                        pageText = wDriver.PageSource;
                        passedTest = false;
                    }
                }

                counter++;
                helperUtilities.RandomPause(.5);
            }
            while ((passedTest == false) && ((counter < stopAt) == true));

            Console.WriteLine("\n\n Page Ready moving on.  \n");

            helperUtilities.RandomPause(3); // needed pause

            return passedTest;
        }
    }// EOC
}// EONS