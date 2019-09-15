// *************************************************************
// Coder Camps
// 8444 N. 90th Street St. 110
// Scottsdale, AZ
// -- SBS ~ 20180314
// Copyright (c) 2016-18
// Project: Wake Up Sefers and processes
// *************************************************************


namespace WakeUpProject
{
  using System.Diagnostics;
  using System.Threading;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;

  public class HelpClass
  {
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

    public bool PageIsReady(IWebDriver wDriver, string pageText, string searchText)
    {
      int counter = 0;
      int stopAt = 9;
      bool passedTest = false;

      do
      {
        if (pageText.Contains(searchText))
        {
          passedTest = true;
        }
        else
        {
          pageText = wDriver.PageSource;
          passedTest = false;
        }

        ++counter;

        this.RandomPause(counter * 2);
      }
      while ((passedTest == false) && ((counter < stopAt) == true));
      return passedTest;
    }

  }
}
