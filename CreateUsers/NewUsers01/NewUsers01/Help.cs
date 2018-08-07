/*Header Notes*/
namespace NewUsers01
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
  using OpenQA;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  class Help
  {
    private string logFile = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="Utilities"/> class. Default Constructor.
    /// </summary>
    public Help()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Utilities"/> class.
    /// Normally Use to create a LOG file
    /// </summary>
    /// <param name="logPath">The log path.</param>
    public Help(string logPath)
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

    public IWebDriver BrowserReady(IWebDriver webDriver, Help hp, string startPage, string client, Size browserSize)
    {
      webDriver.Navigate().GoToUrl(startPage);
      webDriver.Manage().Window.Size = browserSize;
      hp.RandomPause(2);
      webDriver.Navigate().GoToUrl(client);
      string pageText = webDriver.PageSource;
      hp.RandomPause(2);
      // Removed until it works. hp.PageIsReady(webDriver, pageText, "Sign in with Microsoft");
      return webDriver;
    }
  }
}
