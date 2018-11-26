/*Test UX Class*/

namespace UxTestTwo  /*NAME SPACE*/
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
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using System.Collections.Generic;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  public class UxTwo  /*NAME of the class*/
  {

    private string logFile = string.Empty;

    public UxTwo()  /*Replaces the default constructor*/
    {
    }

    public UxTwo(string logPath)
    {
      Directory.CreateDirectory(logPath);
      this.LogFile = logPath + "\\QA_TestLog.Txt";
    }

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

    public bool TestForInt(string itemToTest)
    {
      int cycles = 0;
      bool retVal = false;
      retVal = int.TryParse(itemToTest, out cycles);
      return retVal;
    }

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

    public bool PageWeWanted(
    UxTwo util, string pageSource, string lookForThisString, PassFailCount resultWas)
    {
      bool passedCorrectPage = false;
      try
      {
        Assert.IsTrue(pageSource.Contains(lookForThisString));
        Console.WriteLine("Expected page and text ~ {0} \n ", lookForThisString);
        util.MakeLogEntry("We navigated to the correct page");
        resultWas.Passed++;
      }
      catch (Exception exTextException)
      {
        Console.WriteLine(exTextException);
        util.MakeLogEntry(
        "There was an error with Test == " +  Environment.NewLine + "Error Below" + Environment.NewLine + exTextException);
        resultWas.Failed++;
      }

      if(resultWas.Failed < 1)
      { passedCorrectPage = true; }
      return passedCorrectPage;
    }

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

    public string Reverse(string inputString)
    {
      char[] charArray = inputString.ToCharArray();
      Array.Reverse(charArray);
      return new string(charArray);
    }

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


  }// EOC
}// OENS


/*
 Save usings incase they vanquish
   
  using System;
  using System.Diagnostics;
  using System.Drawing;
  using System.IO;
  using System.Net;
  using System.Net.Mail;
  using System.Net.Mime;
  using System.Text;
  using System.Threading;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using System.Collections.Generic;
  using System.Linq;
   
   */
