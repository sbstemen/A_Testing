using System;
using System.IO;
using System.Drawing;
using Utility;
using OpenQA;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NewUnitTestOne
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string targetURL = @"https://www.google.com/";
            string logPath = Properties.Settings.Default.LogPath;
            string testIs = Properties.Settings.Default.TestName;
            string driverPath = Directory.GetCurrentDirectory() + "\\assets";
            string fullPath = logPath + testIs + DateTime.Now.ToString("-MM-dd-HHmm");
            Size nuSize = new Size(1368, 1024);

            if(!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            Utilities utility = new Utilities(fullPath);
            utility.MakeLogEntry("Opening Test " + testIs + " " + DateTime.UtcNow.Ticks.ToString());

            using (IWebDriver webDriver = new ChromeDriver(driverPath))
            {

                string targetText = "doodle";

                webDriver.Navigate().GoToUrl(targetURL);

                utility.RandomPause(2);

                webDriver.Manage().Window.Size = nuSize;

                utility.RandomPause(2);

                string pgText = webDriver.PageSource.ToString();

                try
                {
                    Assert.IsTrue(pgText.Contains(targetText));
                    {
                        utility.MakeLogEntry("PASSED target text ==> " + targetText);
                    }
                }
                catch(Exception expTextCatch)
                {
                    utility.MakeLogEntry("ERROR ERROR" + Environment.NewLine + expTextCatch);
                    utility.MakeLogEntry("Failed to find text ==> " + targetText);
                }

            }

        }//EOTM1

    }//EOC
}//EONS
