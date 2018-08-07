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
    public class FileTest01
    {
        public string driverPath = Directory.GetCurrentDirectory() + "\\assets\\";
        public string timeTick = DateTime.UtcNow.Ticks.ToString();
        public string urlStart = @"https:\\www.google.com\";
        public string wozUrl = @"https://wozu.qa.exeterlms.com/";
        public string wozStudent = "DotDot";
        Helper H = new Helper();

        [TestInitialize]
        public void RunBeforeTest()
        {
            /* What happens in here is setup only and is not in scope for other tests. */
        }

        [TestMethod]
        public void TestMethod11()
        {
            using (IWebDriver webDriver = new ChromeDriver(driverPath))
            {
                webDriver.Navigate().GoToUrl(urlStart);
                H.RandomPause(1);
                H.SignIn(webDriver, wozUrl, wozStudent);
                H.RandomPause();
                H.LoggingOff(webDriver);
                webDriver.Close();
            }
        }
    }
}
