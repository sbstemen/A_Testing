
namespace WebYoga
{
  using System;
  using System.IO;
  using System.Threading;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using OpenQA;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;

  [TestClass]
  public class UnitTest1
  {
    private static string assetPath = Directory.GetCurrentDirectory() + "\\assets\\";
    private bool ready = true;


    [TestInitialize]
    public void TestSetup()
    {

    }

    [TestMethod]
    public void JavaScriptBox()
    {
      using (IWebDriver webDriver = new ChromeDriver(assetPath))
      {
        string goo = @"HTTPS://www.Google.Com/";

        webDriver.Navigate().GoToUrl(goo);

        Thread.Sleep(2000);

        IJavaScriptExecutor js = webDriver as IJavaScriptExecutor;

        js.ExecuteScript("alert('WAKE UP Bob is NOT your uncle!!');");

        Thread.Sleep(3000);

        IAlert lert = webDriver.SwitchTo().Alert();

        lert.Accept();

      }
    }
  }
}
