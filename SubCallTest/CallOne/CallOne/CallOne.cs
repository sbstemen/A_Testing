/* Gotta have a name */
namespace CallOne
{
  using System;
  using System.Drawing;
  using System.IO;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using UxTestTwo;
  


  [TestClass]
  public class CallOne
  {
    /**/
    private static string passWord = "123456";
    private static string testName = "X";
    private static string runDateTime = DateTime.Now.ToString("-MM-dd-HHmm");
    private static string logthis = @"C:\TstLog\" + runDateTime + "\\";
    private static string chromePath = Directory.GetCurrentDirectory() + "\\assets\\";
    private UxTwo util = new UxTwo(logthis);
    private PassFailCount results = new PassFailCount();
    private Usr Admin = new Usr();
    private Usr NewGuy = new Usr();
    private CallOneProcess Proc = new CallOneProcess();
    /**/
    [TestInitialize]
    public void TestCount()
    {

    }

    [TestMethod]
    public void Test001()
    {
      using (IWebDriver DrVr = new ChromeDriver(chromePath))
      {
        this.Proc.BrowserReady(DrVr, util, results);

        this.util.RandomPause(3);
      }
    }
  }
}
