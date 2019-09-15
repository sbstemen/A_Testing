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
  using OpenQA.Selenium;
  using OpenQA.Selenium.Support.UI;
  using System;
  using System.Drawing;

  internal class WakeUpProcess
  {

    public IWebDriver BrowserReady(IWebDriver webDriver, HelperUtilities utils, UserData usrData)
    {
      bool testPassed = false;

      string findThis = "Sign in with Microsoft";

      string pageText = string.Empty;

      Size viewPortSize = new Size(1650, 1000);

      string startPage = @"https://www.google.com/";

      utils.RandomPause(1);

      webDriver.Navigate().GoToUrl(startPage);

      utils.RandomPause(1);

      webDriver.Manage().Window.Size = viewPortSize;

      utils.RandomPause(1);

      webDriver.Navigate().GoToUrl(usrData.ClientUrl);

      var wait = new WebDriverWait(webDriver, new TimeSpan(0, 0, 30));

      var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("RememberLogin")));

      utils.RandomPause(1);

      pageText = webDriver.PageSource;

      testPassed = utils.PageIsReady(webDriver, pageText, findThis);

      if (testPassed)
      {
        // resultWas.PassCount++;
      }
      else
      {
        // resultWas.FailCount++;
      }

      return webDriver;
    }

  }
}
