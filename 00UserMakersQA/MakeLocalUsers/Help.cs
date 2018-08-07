namespace MakeLocalUsers
{
  using System;
  using System.IO;
  using System.Linq;
  using System.Text;
  using System.Drawing;
  using OpenQA.Selenium;
  using System.Threading;
  using System.Diagnostics;
  using OpenQA.Selenium.Chrome;
  using System.Threading.Tasks;
  using System.Collections.Generic;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  public class Help
  {
    private string logFile = string.Empty;
    public Help()
    {
    }

    public Help(string logPath)
    {
      Directory.CreateDirectory(logPath);
      this.LogFile = logPath + "\\UsersIn-QA-Log.Txt";
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
          if (counter == 32)
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

  }// EOC
}// EONS
