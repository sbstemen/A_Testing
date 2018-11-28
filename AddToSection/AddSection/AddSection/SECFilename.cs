/* Gotta have a name */
namespace SECNamespace
{
  using System;
  using System.Drawing;
  using System.IO;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using UxTestTwo;
  


  [TestClass]
  public class SECClassname
  {
    /**/
    private static string passWord = "123456";
    private static string testName = "Practicals";
    private static string runDateTime = DateTime.Now.ToString("-MM-dd-HHmm");
    private static string logthis = @"C:\A10\" + testName + runDateTime + "\\";
    private static string chromePath = Directory.GetCurrentDirectory() + "\\assets\\";
    private UxTwo util = new UxTwo(logthis);
    private PassFailCount results = new PassFailCount();
    private Usr Admin = new Usr();
    private Usr NewGuy = new Usr();
    private AddSectionProcess AddProcess = new AddSectionProcess();
    /**/
    [TestInitialize]
    public void TestCount()
    {
      results.Passed++;
      results.Failed = 0;
      Admin.Password = passWord;
      Admin.LogInAlias = "ScottBS";
      Admin.ClientUrl = @"https://wozu.qa.ExeterLMS.Com/";
      var NL = Environment.NewLine;

      if (!Directory.Exists(logthis))
      {
        Directory.CreateDirectory(logthis);
        this.util.MakeLogEntry("LogON start > " + DateTime.UtcNow.Ticks.ToString() + NL);
      }
      else
      {
        this.util.MakeLogEntry("LogON start > " + DateTime.UtcNow.Ticks.ToString() + NL);
      }

    }

    [TestMethod]
    public void SECNewUsrSection()
    { // .form-control.cc-panel-header-lg
      using (IWebDriver webDriver = new ChromeDriver(chromePath))
      {
        string useMe = string.Empty;
        bool Good2Go = false;
        /* Start of making a new user */
        this.AddProcess.BrowserReady(webDriver, util, results);
        Good2Go = this.AddProcess.KeepGoing(results);

        if (Good2Go)
        {
          this.util.MakeLogEntry("WOW, we did good");
          // useMe = this.AddProcess.MakeNewUser(webDriver, this.util, this.Admin, this.NewGuy, this.results);
          useMe = "Lin29003";
          this.util.MakeLogEntry("NewUser is == " + useMe);
          Good2Go = false; // resetting bool LIn29003
        }
        else
        {
          webDriver.Close();
          this.util.MakeLogEntry("Test of fail worked, this means we had a failure at line 52. ");
          Environment.Exit(101);
        }

        this.AddProcess.MakeNewSection(webDriver, util, Admin, results);

        /* Start of making a new section */




        /* Start of assigning new user to new section */

        this.util.RandomPause(3);
      }
    }
  }
}
