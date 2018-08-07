namespace ManyFiles
{
    using System;
    using System.IO;
    using OpenQA;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FileTest02
    {
        public string driverPath = Directory.GetCurrentDirectory() + "\\assets\\";
        public string timeTick = DateTime.UtcNow.Ticks.ToString();
        public string urlStart = @"https:\\www.google.com\";
        public string ccpUrl = @"https://qa.exeterlms.com/";
        public string ccpStudent = "sbs";
        Helper H = new Helper();

        [TestMethod]
        public void TestMethod21()
        {
            using (IWebDriver webDriver = new ChromeDriver(driverPath))
            {
                webDriver.Navigate().GoToUrl(urlStart);
                H.RandomPause(1);
                H.SignIn(webDriver, ccpUrl, ccpStudent);
                H.RandomPause();
                H.LoggingOff(webDriver);
                webDriver.Close();
            }
        }
    }
}