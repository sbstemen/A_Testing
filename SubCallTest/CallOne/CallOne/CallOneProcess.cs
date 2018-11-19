/* since 1952 */

namespace CallOne
{
  using System;
  using System.Drawing;
  using System.IO;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using UxTestTwo;

  internal class CallOneProcess
  {
    public IWebDriver BrowserReady(IWebDriver drvr, UxTwo util, PassFailCount results)
    {
      bool testGood = false;
      string findThis = "Microsoft";
      string pageText = string.Empty;
      string startPage = @"https://www.google.com/";
      Size viewPort = new Size(1650, 1000);
      drvr.Navigate().GoToUrl(startPage);
      util.RandomPause(2);
      drvr.Manage().Window.Size = viewPort;
      testGood = util.PageWeWanted(util, pageText, findThis, results);
      return drvr;
    }

  }
}
