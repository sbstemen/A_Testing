using System;
using Utility;
using System.IO;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenLogOnCC
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string targetURL = @"https://www.google.com/";
            string testName = Properties.Settings.Default.TestName;
            string driverPath = Directory.GetCurrentDirectory() + "\\assets";
            string logPath = Properties.Settings.Default.LogPath +
                testName + DateTime.Now.ToString("-MM-dd-HHmm");
            Size nuSize = new Size(1368, 1024);

            var nuLine = Environment.NewLine;

            if(!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            Utilities utility = new Utilities(logPath);

            utility.MakeLogEntry("Opening Log ==> " + DateTime.UtcNow.Ticks.ToString());

            using (IWebDriver webDriver = new ChromeDriver(driverPath))
            {
                string targetText = "dododle";

                webDriver.Navigate().GoToUrl(targetURL);

                utility.RandomPause(2);

                webDriver.Manage().Window.Size = nuSize;

                utility.RandomPause(1.7538);

                string pageText = webDriver.PageSource.ToString();

                try
                {
                    Assert.IsTrue(pageText.Contains(targetText));
                    {
                        utility.MakeLogEntry("Passed page load of ==> " + nuLine + targetText);
                    }
                }
                catch(Exception exTextCatch)
                {
                    utility.MakeLogEntry("FAILED FAILED" + nuLine + exTextCatch);
                    utility.MakeLogEntry("Didn't find text ==> " + targetText);
                }
            }


        }
    }
}
