/* since 1952 */

namespace NuUserZ
{
  using System;
  using System.Drawing;
  using System.IO;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using UxTestTwo;

  internal class NewUsersOneProcess
  {
    public bool KeepGoing(PassFailCount resultsAre)
    {
      bool GoodToGo = false;
      if (resultsAre.Failed == 0)
      {
        GoodToGo = true;
      }
      return GoodToGo;
    }

    public IWebDriver BrowserReady(IWebDriver webDriver, UxTwo util, PassFailCount results)
    {
      bool testGood = false;
      string findThis = "Lucky";
      string pageText = string.Empty;
      string startPage = @"https://www.google.com/";
      Size viewPort = new Size(1650, 1000);
      webDriver.Navigate().GoToUrl(startPage);
      util.RandomPause(2);
      webDriver.Manage().Window.Size = viewPort;
      util.RandomPause(3);
      pageText = webDriver.PageSource;
      testGood = util.PageWeWanted(util, pageText, findThis, results);
      util.RandomPause(4);
      return webDriver;
    }

    public string MNUSR(IWebDriver webDriver, UxTwo util, Usr admin, Usr newGuy, PassFailCount results)
    {
      string who = "y";
      NewUserZMaker NUM = new NewUserZMaker();
      who =  NUM.UseThisUser(webDriver, util, admin, newGuy, results);

      util.RandomPause(1);

      if(who == "x" || who == "y")
      {
        util.MakeLogEntry("FUCKIT IT ALL FAILED!! ");
      }
      else
      {
        util.MakeLogEntry("PASSED PASSED PASSED " + Environment.NewLine + who + Environment.NewLine + "PAAAASSEEDD!!");
      }

      return who;
    }

  }
}
