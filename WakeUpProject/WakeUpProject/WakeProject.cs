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
  using System;
  using System.IO;
  using System.Threading;
  using System.Diagnostics;
  using OpenQA;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using OpenQA.Selenium.Support.UI;
  using SeleniumExtras;
  using SeleniumExtras.PageObjects;
  using SeleniumExtras.WaitHelpers;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class WakeProject
  {
    private static string assetPath = Directory.GetCurrentDirectory() + "\\assets\\";
    private HelpClass help = new HelpClass();

    [TestInitialize]
    public void TestSetup()
    {

    }

    [TestMethod]
    public void Awaken()
    {
      using (IWebDriver webDriver = new ChromeDriver(assetPath))
      {

      }

    }
  }
}

/*
 
  these are the URLs you need to care about to wake up qa
  
https://contentapi.qa.exeterlms.com/
https://mgmtapi.qa.exeterlms.com/
https://platformapi.qa.exeterlms.com/
https://users.qa.exeterlms.com/test
https://resourceapi.qa.exeterlms.com/
https://api.qa.exeterlms.com/
https://reportsapi.qa.exeterlms.com/
https://login.qa.exeterlms.com/
https://betheltech.qa.exeterlms.com/
   
   */
