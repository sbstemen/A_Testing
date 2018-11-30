/* Gotta have a name */
namespace NuUserZ
{
  using System;
  using System.Drawing;
  using System.IO;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using UxTestTwo;
  


  [TestClass]
  public class NewUsersOne
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
    private NewUsersOneProcess Proc = new NewUsersOneProcess();
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
    public void Test001()
    {
      using (IWebDriver webDriver = new ChromeDriver(chromePath))
      {
        string useMe = string.Empty;
        bool G2G = false;

        this.Proc.BrowserReady(webDriver, util, results);
        G2G = this.Proc.KeepGoing(results);

        if (G2G)
        {
          this.util.MakeLogEntry("WOW, we be workin.");
          useMe = this.Proc.MNUSR(webDriver, this.util, this.Admin, this.NewGuy, this.results);
          this.util.MakeLogEntry("User Name " + useMe);
        }
        else
        {
          webDriver.Close();
          this.util.MakeLogEntry("Test of fail worked, this means we had a failure at line 52. ");
          Environment.Exit(101);
        }



        this.util.RandomPause(3);
      }
    }
  }
}
