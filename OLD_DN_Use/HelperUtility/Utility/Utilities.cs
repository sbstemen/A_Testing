/*Date 20180101
 *   Scott B. Stemen
 *         Common Utilities that are used with projects.
 *            Designed to be run from a command line 
 *                20170206 ~ Updated to run Email send with test user. 
 *                    20170210 ~ Adding Timer of 10 Seconds while waiting for user inputs. 
 *                        20170323 ~ Added Utility to test for visable string and time out after 15 seconds. 
 *                
 * */

//READ ME IF LOST
/**
This is a brief list of the methods in my Utilities Class as well as location. 

LogFile ~ Locally scoped variable called in the second Utilities Constructor. 

Utilities ~ First of two constructors. Replaces the default blank constructor of the whole class. 

Utilities ~ Second of Two constructors.  When given the path it starts the log file. 

TestForInt ~ Tests that the string input was an Interger for user inputs to stop crashing code. 

RandomPause ~ First of two methods, just pauses a random 3 ~ 8 second time while web pages load. 

RandomPause ~ Second of two methods, this is overloaded with a double representing seconds to dicitate the time to stop. 

StopForNightlyProcessing  ~ Returns a bool tests for specific time to keep automation from running while maintenance is happening. 

PageIsGood ~ Method used to quickly test for common web based errors, before going on with more tests. 

MakeLogEntry ~ Method to log errors and anything sent to it, including caught exceptions. 

GetCookie  ~ A method used to convert and get cookie to a Selenium Style cookie

EmailMeLog  ~  Emails me on successful completion and Omar, Jeff and me if failed. 

PasswordValidation  ~ Quick test that Password entered meets requirements. 

LogonValidationTest ~ Verification that Logging on was successfully done. 

CallToTimer5Sec ~ Times 5 seconds before going on with test, give user chance to interup the test. 

EmailChangeCode ~ Cycles through sbs1 to sbs5 emails

CycleCounter ~ Code that takes in Counter & Stop Count of a test, along with pass, fail counts and prints to Screen and log file

PageIsReady ~ Inputs are the page source, and text to look for time out is 15 seconds total. 
 */

using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Collections.Generic;
using System.Configuration;
using Cookie = System.Net.Cookie;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using  OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Utility

{
    public class Utilities
    {
        private string logFile = String.Empty;

        public Utilities()
        {
        }  //Default Constructor 

        public Utilities(string logPath)
        {
            Directory.CreateDirectory(logPath);
            this.LogFile = logPath + "\\logged.Txt";
        }  //Usually Use, Creates a LOG file

        public string LogFile
        {
            get { return logFile; }
            set
            {
                if (!File.Exists(value))
                {
                    File.Create(value).Close();
                }

                logFile = value;
            }
        }

        public bool TestForInt(string itemToTest)
        {
            int cycles = 0;
            bool retVal = false;
            retVal = Int32.TryParse(itemToTest, out cycles);
            return retVal;
        }

        public void RandomPause()
        {
            Random rdmTime = new Random();
            int pauseTime = rdmTime.Next(4096, 8192);
            Thread.Sleep(pauseTime);
        }

        public void RandomPause(double seconds)
        {
            double sleepyTime = (seconds * 1000);

            Thread.Sleep( Convert.ToInt32(sleepyTime) );
        }

        public static bool StopForNightlyProcessing
        {
            get
            {
                bool goNoGoAnswer = true;

                DateTime DT = DateTime.Now;

                int timeIs = DT.Hour;

                Console.WriteLine("The Hour Is {0}", timeIs);

                if ((timeIs >= 22) || (timeIs < 2))
                {
                    goNoGoAnswer = false;
                    Console.WriteLine("All testing stops because of nightly processing");
                    Thread.Sleep(1500);
                }

                return goNoGoAnswer;
            }
        }

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


        public  void TrackingLogEntry(string path, string message)
        {
            using (TextWriter txtWriter = new StreamWriter(path, true))
            {
                txtWriter.WriteLine(message);
                txtWriter.WriteLine(DateTime.Now.ToString("MMM:dd_HH:mm:ss"));
                txtWriter.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                txtWriter.Close();
            }
        }


        public IEnumerable<Cookie> GetCookie(string bwaTestUser)
        {
            CookieContainer cookieJar = new CookieContainer();

            HttpClientHandler handler = new HttpClientHandler();

            handler.CookieContainer = cookieJar;

            HttpClient client = new HttpClient(handler);

            HttpResponseMessage response = client.GetAsync(bwaTestUser).Result;

            Uri uri = new Uri(bwaTestUser);

            return cookieJar.GetCookies(uri).Cast<Cookie>();
        }

        public void EmailMeLog(int passed, int failed, string etime, string testName, string testNotes, string emailPassed, string emailFailed)
        {
            string emailFromAddress = "Name@name.com";
            string emailFromName = "Name@Name.com";
            string smtpUser = "testing@bluewaterads.com";
            string smtpHost = "smtp.GoesHere.com"; //  "office.com"; //msnhst.microsoft.com
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
                    //message.Subject = "FAILED: The Automated WebSite Test is under investigation";
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

                using (FileStream fileReadingStream = new FileStream(LogFile, FileMode.Open, FileAccess.Read))
                {
                    Attachment logToAttach = new Attachment(fileReadingStream, "Logs.txt",
                        MediaTypeNames.Application.Octet);

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
                RandomPause(1);
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

        public string EmailChangeCode(int sentinalvalue, string emailName, string emailDomain, out int emailNumber, out string emailSend)
        {
            emailSend = "";

            emailNumber = sentinalvalue%5;
            if (emailNumber == 0)
            {
                emailSend = "";
                emailNumber = 5;
                emailSend = emailName + emailNumber + emailDomain;
            }
            else
            {
                emailSend = String.Empty;
                emailSend = emailName + emailNumber + emailDomain;
            }
            return emailSend;
        }

        public void CycleCounter(Utilities ut, string emailSend, int countIs, int stopCount, int refPassCount, int refFailCount)
        {
            Console.WriteLine("\n\n Email account this run = {0}", emailSend);
            Console.WriteLine("\n  We have completed = {0} cycles of this test", (countIs+1));
            Console.WriteLine("\n       We stil have {0} cycles to go", (stopCount-(countIs + 1)));
            Console.WriteLine("Our passed test count = {0}  :: Any Failures == {1} \n\n", refPassCount, refFailCount);

            ut.MakeLogEntry
                (Environment.NewLine + "Email account this run = " + emailSend + Environment.NewLine +  
                "We have completed == " + (countIs+1) + " cycles of this test run" + Environment.NewLine + 
                "We still have = " +(stopCount - (countIs + 1)) +  Environment.NewLine +
                "Our Pass Count = " + refPassCount + " :: Any Failures so far == " + refFailCount);
        }

        public bool PageIsReady(IWebDriver wDriver, Utilities helperUtilities, string pageText, string textSearchingFor)
        {
            int counter = 0;
            int stopAt =135;
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
                    else if (counter%3 == 0)
                    { 
                        Console.WriteLine("\nNOT an error, just page wasn't ready yet.  We are looping;  \n   and will report every 3rd loop\n");
                        Console.WriteLine("We have tried {0} cycles of this test and have {1} to go ", counter +1, stopAt -counter-1);
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
            } while ((passedTest == false)  && ((counter < stopAt) == true));

            Console.WriteLine("\n\n Page Ready moving on.  \n");

            helperUtilities.RandomPause(3); //Just Because 

            return passedTest;
        }



    }//EOC
}//EONS


/**************  utilities I have depricated *********************/
/* 20180122
     
          public bool PageWeWanted
            (string pageSource, string testName, string lookForThisString, ref int passCount, ref int failCount)
        {
            bool passedCorrectPage = false;
            
            try
            {
                Assert.IsTrue(pageSource.Contains(lookForThisString));
                Console.WriteLine("Expected page and text ~ {0} \n ", lookForThisString);
                passedCorrectPage = true;
                passCount = passCount + 1;
            }
            catch (Exception exTextException)
            {
                Console.WriteLine(exTextException);
                failCount = failCount + 1;
            }
            return passedCorrectPage;
        }
   
     
     
*/
