// *************************************************************
// Coder Camps
// 8444 N. 90th Street St. 110
// Scottsdale, AZ
// -- SBS ~ 20180123
// Copyright (c) 2016-18
// Project:      CC.LMS.LogIn
// NOTE NOTE ~ The random pauses are required for page load timing
// *************************************************************

namespace CC.LMS.Authentication
{
    using System;
    using System.IO;
    using System.Drawing;
    using Utility;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class for the Login and Log out tests.
    /// </summary>
    internal class AuthenticationsProcess
    {
        /// <summary>
        /// Provides Log IN tools, Opens Browser, validates, loggs off, returns a bool.
        /// </summary>
        /// <param name="utility">The utility.</param>
        /// <param name="logPath">The log path.</param>
        /// <param name="subTest">The sub test.</param>
        /// <param name="searchText">The search text.</param>
        /// <param name="targetUrl">The target URL.</param>
        /// <param name="userAlias">The user alias.</param>
        /// <param name="passwordAlways">The password always.</param>
        /// <returns>bool</returns>
        public bool LogOnOff(
            Utilities utility,
            string logPath,
            string subTest,
            string searchText,
            string targetUrl,
            string userAlias,
            string passwordAlways)
        {
            bool allGood = false;
            var newLine = Environment.NewLine;
            Size BrowserSize = new Size(1600, 1000);
            string ChromePath = Directory.GetCurrentDirectory() + "\\assets\\";
            string openingPage = @"https://www.google.com/";  /* KEEP, opens for timing purposes. */

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
                utility.MakeLogEntry("LogON start > " + DateTime.UtcNow.Ticks.ToString() + newLine);
            }
            else
            {
                utility.MakeLogEntry("LogON start > " + DateTime.UtcNow.Ticks.ToString() + newLine);
            }

            using (IWebDriver webDriver = new ChromeDriver(ChromePath))
            {
                webDriver.Navigate().GoToUrl(openingPage);

                utility.RandomPause(1);

                webDriver.Manage().Window.Size = BrowserSize;

                webDriver.Navigate().GoToUrl(targetUrl);

                utility.RandomPause(2);

                string pageText = webDriver.PageSource.ToString();

                /* Search for the client Icon */
                try
                {
                    Assert.IsTrue(pageText.Contains(searchText));
                    {
                        utility.MakeLogEntry("Pass, text found" + newLine + searchText);
                        searchText = string.Empty;
                    }
                }
                catch (Exception expText)
                {
                    utility.MakeLogEntry("FAILED" + newLine + expText);
                    utility.MakeLogEntry("Searched text failed" + newLine + searchText);
                    searchText = string.Empty;
                    Assert.Fail();
                }

                utility.RandomPause(1);
                webDriver.FindElement(By.Id("Username")).SendKeys(userAlias);
                webDriver.FindElement(By.Id("Password")).SendKeys(passwordAlways);
                utility.RandomPause(2);
                webDriver.FindElement(By.ClassName("cc-btn-sign-in")).Click();
                utility.RandomPause(5);
                pageText = webDriver.PageSource;
                searchText = "Copyright © 2018 Exeter Education, LLC.";

                /* Search for the logged in user alias */
                try
                {
                    Assert.IsTrue(pageText.Contains(searchText));
                    {
                        utility.MakeLogEntry("Log On succeeded for ==> " + userAlias);
                        utility.RandomPause(2);
                        searchText = string.Empty;
                    }
                }
                catch (Exception expText)
                {
                    utility.MakeLogEntry("Log On Failed for client " + newLine + userAlias);
                    utility.MakeLogEntry("Exception Code" + newLine + expText);
                    Assert.Fail();
                }

                /* For Log OFF code required, It scrolls down and then clan click click */


                IJavaScriptExecutor jsexe = (IJavaScriptExecutor)webDriver;

                jsexe.ExecuteScript("window.scrollTo(0, Math.max(document.documentElement.scrollHeight, document.body.scrollHeight, document.documentElement.clientHeight));");

                utility.RandomPause(1);

                webDriver.FindElement(By.ClassName("qa-logout-button")).Click();

                /* Check logoff successfully, is ph number gone*/
                try
                {
                    utility.RandomPause(2);
                    pageText = webDriver.PageSource;
                    searchText = "tel:+1-855-755-2267";

                    Assert.IsTrue(!pageText.Contains(searchText));
                    {
                        utility.MakeLogEntry("PASSED" + newLine +
                            "Log In, Authentication, Log Off all passed for = " + subTest);
                        allGood = true;
                    }
                }
                catch (Exception expText)
                {
                    utility.MakeLogEntry("LOG OFF Failed error Was " + newLine + expText);
                    Assert.Fail();
                }
            }

            return allGood;
        }
    }
}
