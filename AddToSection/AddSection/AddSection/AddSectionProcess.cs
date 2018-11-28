/* since 1952 */

namespace SECNamespace
{
  using System;
  using System.Drawing;
  using System.IO;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using UxTestTwo;

  internal class AddSectionProcess
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

    public string MakeNewUser(IWebDriver webDriver, UxTwo util, Usr admin, Usr newGuy, PassFailCount results)
    {
      string NewGuyIs = "y";
      NewUserMaker newUserMaker = new NewUserMaker();
      NewGuyIs =  newUserMaker.UseThisUser(webDriver, util, admin, newGuy, results);

      util.RandomPause(1);

      if(NewGuyIs == "x" || NewGuyIs == "y")
      {
        util.MakeLogEntry("FUCKIT IT ALL FAILED!! ");
      }
      else
      {
        util.MakeLogEntry("PASSED PASSED PASSED " + Environment.NewLine + NewGuyIs + Environment.NewLine + "PAAAASSEEDD!!");
      }

      return NewGuyIs;
    }

    public string MakeNewSection(IWebDriver webDriver, UxTwo util, Usr admin, PassFailCount results)
    {
      string sectionNumber = string.Empty;

      NewSectionMaker newSectionMaker = new NewSectionMaker();

      sectionNumber = newSectionMaker.NewSectionNumber(webDriver, util, admin, results);

      return sectionNumber;
    }

  }
}