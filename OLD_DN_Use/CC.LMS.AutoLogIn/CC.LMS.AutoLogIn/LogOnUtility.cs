using System;
using System.IO;
using Utility;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CC.LMS.AutoLogIn
{
    class LogOnUtility
    {

        public bool LogInAdmin
            (Utilities utility, string logPath, string subTest, string searchText, 
               string targetUrl, string userAlias, string PasswordAlways)

        {
            bool allGood = false;
            var newLine = Environment.NewLine;
            Size BrowserSize = new Size(1206, 900);
            string ChromePath = Directory.GetCurrentDirectory() + "\\assets\\";

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
                utility.MakeLogEntry("Testing Bethel Tech start ==>" + DateTime.UtcNow.Ticks.ToString() + newLine);
            }
            else
            {
                utility.MakeLogEntry("Testing Bethel Tech start ==>" + DateTime.UtcNow.Ticks.ToString() + newLine);
            }


            using (IWebDriver webDriver = new ChromeDriver(ChromePath))
            {
                webDriver.Navigate().GoToUrl(targetUrl);
                utility.RandomPause(1);
                webDriver.Manage().Window.Size = BrowserSize;
                utility.RandomPause(2);
                string pageText = webDriver.PageSource.ToString();

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

                webDriver.FindElement(By.Id("Username")).SendKeys(userAlias);
                webDriver.FindElement(By.Id("Password")).SendKeys(PasswordAlways);
                utility.RandomPause(1);
                webDriver.FindElement(By.ClassName("cc-btn-sign-in")).Click();
                utility.RandomPause(5);
                pageText = webDriver.PageSource;
                searchText = "Search for a cohort";

                try
                {
                    Assert.IsTrue(pageText.Contains(searchText));
                    {
                        utility.MakeLogEntry("Log On succeeded for ==> " + userAlias);
                        webDriver.FindElement(By.PartialLinkText("Logout")).Click();
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

                try
                {
                    utility.RandomPause(2);
                    pageText = webDriver.PageSource;
                    searchText = "You have been logged out of Exeter";

                    Assert.IsTrue(pageText.Contains(searchText));
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

                webDriver.Close();
            }

            return allGood;
        }

    }
}
