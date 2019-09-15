// *************************************************************
// Coder Camps
// 8444 N. 90th Street St. 110
// Scottsdale, AZ
// -- SBS ~ 20180314
// Copyright (c) 2016-18
// Project:      CC.Student.Basic
// *************************************************************

namespace Utility
{
  using System;
  using System.Diagnostics;
  using System.Drawing;
  using System.IO;
  using System.Net;
  using System.Net.Mail;
  using System.Net.Mime;
  using System.Text;
  using System.Threading;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;

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
      this.LogFile = logPath + "\\WOZ-qa-Log.Txt";
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
      Thread.Sleep(1024);
      double sleepyTime;
      sleepyTime = 5120;
      Stopwatch sw = new Stopwatch();
      sw.Start();
      for (int i = 0; ; i++)
      {
        if (i % 100000 == 0)
        {
          sw.Stop();
          if (sw.ElapsedMilliseconds > sleepyTime)
          {
            break;
          }
          else
          {
            sw.Start();
          }
        }
      }
    }

    /// <summary>
    /// Overloaded version for RandomPause, takes in a double convers to seconds to pause.
    /// </summary>
    /// <param name="seconds">The seconds.</param>
    public void RandomPause(double seconds)
    {
      Thread.Sleep(1024);
      double sleepyTime;
      sleepyTime = seconds * 1024;
      Stopwatch sw = new Stopwatch();
      sw.Start();
      for (int i = 0; ; i++)
      {
        if (i % 100000 == 0)
        {
          sw.Stop();
          if (sw.ElapsedMilliseconds > sleepyTime)
          {
            break;
          }
          else
          {
            sw.Start();
          }
        }
      }
    }

    /// <summary>
    /// Stops for any nightly processing when tests are run on a 24 x 7 basis.
    /// </summary>
    /// <returns>bool</returns>
    public bool StopForNightlyProcessing()
    {
      bool goNoGoAnswer = true;

      DateTime dateTime = DateTime.Now;

      int timeIs = dateTime.Hour;

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

      StringBuilder sbuildBody = new StringBuilder();

      sbuildBody.Append("Test cases were run at = " + DateTime.Now.ToString("yyyyMMdd_HH:mm") + "</br>" + testName + "Automation Test </br>");
      sbuildBody.Append("PASSED = " + passed);
      sbuildBody.Append("</br>");
      sbuildBody.Append("FAILED = " + failed);
      sbuildBody.Append("</br>");
      sbuildBody.Append("The results log file is attached, and the time to run this suite of tests = " + etime);
      sbuildBody.Append("</br>");
      sbuildBody.Append("</br>");
      sbuildBody.Append(testNotes);
      sbuildBody.Append("</br>");
      sbuildBody.Append("</br>");

      MailMessage message = new MailMessage();
      SmtpClient smtpClient = new SmtpClient();

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

          sbuildBody.Append("</br></br>");

          sbuildBody.Append("IF there were any failures Scott Stemen is already looking at them.");
        }

        foreach (var address in toAddresses)
        {
          message.To.Add(new MailAddress(address));
        }

        message.IsBodyHtml = true;
        message.Body = Convert.ToString(sbuildBody);

        using (FileStream fileReadingStream = new FileStream(this.LogFile, FileMode.Open, FileAccess.Read))
        {
          Attachment logToAttach = new Attachment(
              fileReadingStream, "Logs.txt", MediaTypeNames.Application.Octet);

          message.Attachments.Add(logToAttach);

          smtpClient.UseDefaultCredentials = false;

          smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPassword);

          smtpClient.Port = portNumber;

          smtpClient.Host = smtpHost;

          smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;

          smtpClient.EnableSsl = true;

          smtpClient.Send(message);
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
    /// Parses a slow loading page for expected text when the is-dom-ready element isnt available.
    /// </summary>
    /// <param name="wDriver">The w driver.</param>
    /// <param name="pageText">The page text.</param>
    /// <param name="textSearchingFor">The text searching for.</param>
    /// <returns>bool</returns>
    public bool PageIsReady(IWebDriver wDriver, string pageText, string textSearchingFor)
    {
      int counter = 0;
      int stopAt = 33;
      bool passedTest = false;

      do
      {
        try
        {
          Assert.IsTrue(pageText.Contains(textSearchingFor));
          passedTest = true;
        }
        catch (Exception exText)
        {
          if (counter == 0)
          {
            Console.WriteLine(exText);
          }
          else if (counter % 2 == 0)
          {
            this.RandomPause(3);
            pageText = wDriver.PageSource;
            passedTest = false;
          }
          else
          {
            pageText = wDriver.PageSource;
            passedTest = false;
          }
        }

        ++counter;
        this.RandomPause(2);
      }
      while ((passedTest == false) && ((counter < stopAt) == true));
      return passedTest;
    }

    /// <summary>
    /// Used to fill in user data object with typical information.
    /// </summary>
    /// <param name="uData">The local UserData object.</param>
    /// <returns>bool</returns>
    public UserData UDataFiller(UserData uData)
    {
      uData.CreatedAt = DateTime.UtcNow;
      uData.EpochTicks = this.TruncationTool(DateTime.UtcNow.Ticks.ToString(), 8);
      uData.ClientUrl = @"https://wozu.qa.exeterlms.com/";
      uData.LogInAlias = "WZS";
      uData.Password = "123456";
      uData.Company = "Flying Poodle Software ~ " + uData.EpochTicks;
      uData.Title = "Boss ~ " + uData.EpochTicks;
      uData.EducationHistoryText = "USAF ~ " + uData.EpochTicks;
      uData.EmploymentHistoryText = "My Resume: just a little sentence :: Now is the time for all good men to come to the aid of their country, because it's a good time to help each other in the country. ~ " + uData.EpochTicks;
      uData.BioText = "I do stuff ~ " + uData.EpochTicks;
      uData.LinkedIn = " WWW (.) Linked IN (.) Com / FooBar / " + uData.EpochTicks;
      uData.BlogUrl = " http S : // FooBar (.) Blog / " + uData.EpochTicks;
      uData.GitHubUrl = "HubMe ~ " + uData.EpochTicks;
      uData.TwitterName = "TwitterName ~ " + uData.EpochTicks;
      return uData;
    }

    /// <summary>
    /// Removes target objects from User Data fields for validation testing.
    /// </summary>
    /// <param name="uData">UserData object that is going to be cleaned up</param>
    public void CleanUserData(UserData uData)
    {
      string replaceText = "New~" + this.TruncationTool(DateTime.UtcNow.Ticks.ToString(), 3);
      string chromepath = Directory.GetCurrentDirectory() + "\\assets\\";

      using (IWebDriver webDriver = new ChromeDriver(chromepath))
      {
        string startPage = @"https://www.google.com/"; /* Opens a page for timing of the chrome driver */

        webDriver.Navigate().GoToUrl(startPage);

        Size browserSize = new Size(1600, 1024);

        webDriver.Manage().Window.Size = browserSize;

        this.RandomPause(1);

        webDriver.Navigate().GoToUrl(uData.ClientUrl);

        this.RandomPause(2);

        webDriver.FindElement(By.Id("Username")).SendKeys(uData.LogInAlias);

        webDriver.FindElement(By.Id("Password")).SendKeys(uData.Password);

        this.RandomPause(.5);

        webDriver.FindElement(By.ClassName("cc-btn-sign-in")).Click();

        this.RandomPause(5); // Update to wait for code needs to be 5 minimum.

        // webDriver.FindElement(By.CssSelector("li.cc-user-widget")).Click();

        webDriver.FindElement(By.CssSelector(".nav.navbar-nav.navbar-right>li:last-child>a")).Click();

        this.RandomPause(1);

        webDriver.FindElement(By.Id("qa-dropdown-profile")).Click();

        this.RandomPause(3);

        var saveButtons = webDriver.FindElements(By.ClassName("cc-profile-form-save-btn"));

        try
        {
          var imgButtons = webDriver.FindElements(By.CssSelector("button.cc-image-uploader-save-btn"));
          imgButtons[1].Click();
        }
        catch (Exception exText)
        {
          Console.WriteLine(exText.ToString());
        }

        this.RandomPause();

        webDriver.FindElement(By.Id("bio")).Clear();

        this.RandomPause();

        webDriver.FindElement(By.Id("bio")).SendKeys(replaceText);

        this.RandomPause();

        IWebElement scrollToBio = webDriver.FindElement(By.Id("bio"));

        ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", scrollToBio);

        this.RandomPause();

        webDriver.FindElement(By.Id("gitHubUrl")).Clear();

        this.RandomPause();

        webDriver.FindElement(By.Id("gitHubUrl")).SendKeys(replaceText);

        this.RandomPause();

        saveButtons[1].Click();

        this.RandomPause();
      }
    }

    /// <summary>
    /// Returns an image to be used for random uploading
    /// </summary>
    /// <returns>Image name as a string</returns>
    public string ImageRandomizer()
    {
      string imageName = string.Empty;
      int imgNumber = 0;
      Random rnd = new Random();
      imgNumber = rnd.Next(1, 6);

      switch (imgNumber)
      {
        case 1:
          {
            imageName = "Blue.jpg";
            break;
          }

        case 2:
          {
            imageName = "Green.jpg";
            break;
          }

        case 3:
          {
            imageName = "Orange.jpg";
            break;
          }

        case 4:
          {
            imageName = "Purple.jpg";
            break;
          }

        case 5:
          {
            imageName = "Red.jpg";
            break;
          }

        case 6:
          {
            imageName = "Yellow.jpg";
            break;
          }

        default:
          {
            imageName = "Puppy.jpg";
            break;
          }
      }

      return imageName;
    }

    /// <summary>
    /// Truncations the string.
    /// </summary>
    /// <param name="inPutText">The in put text.</param>
    /// <param name="remainingCharacters">The maximum length.</param>
    /// <returns>String Truncated by entered Int</returns>
    public string TruncationTool(string inPutText, int remainingCharacters)
    {
      if (string.IsNullOrEmpty(inPutText))
      {
        return inPutText;
      }
      else
      {
        inPutText = inPutText.Length <= remainingCharacters ? inPutText : inPutText.Substring(0, remainingCharacters);
      }

      return inPutText;
    }

    /// <summary>
    /// Reverses the entered string
    /// </summary>
    /// <param name="inputString">String</param>
    /// <returns>stringgnirts</returns>
    public string Reverse(string inputString)
    {
      char[] charArray = inputString.ToCharArray();
      Array.Reverse(charArray);
      return new string(charArray);
    }
  }// EOC
}// EONS