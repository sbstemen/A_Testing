namespace CC.LMS.Student.Basic
{
    using System;
    using System.Drawing;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Utility;

    internal class Enrolled
    {
        public bool SignInUser(Utilities utility, string logPath, UserData usrData)
        {
            int countpasses = 0;
            bool passed = false;
            var newLine = Environment.NewLine;
            Size browserSize = new Size(1526, 896);
            string chromePath = Directory.GetCurrentDirectory() + "\\assets\\";
            string logOffXpath = this.LogOffXpath(usrData.LogInAlias);
            string startPage = @"https://www.google.com/"; // Just for browser Timing.
            string pageText = string.Empty;
            string searchText = string.Empty;

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
                utility.MakeLogEntry("Verify Student Enrollment ==> " + DateTime.UtcNow.Ticks.ToString() + newLine);
            }
            else
            {
                utility.MakeLogEntry("Verify Student Enrollment ==> " + DateTime.UtcNow.Ticks.ToString() + newLine);
            }

            // MUST do a log off, or else cookie will remain for last user ID
            try
            {
                Assert.IsTrue(logOffXpath != "nopath");
                {
                    utility.MakeLogEntry("Logout XPath is set for = " + usrData.LogInAlias);
                }
            }
            catch (Exception expText)
            {
                utility.MakeLogEntry("FAILED" + newLine + expText);
                utility.MakeLogEntry("Abandoned the whole test, no logoff path, bad login");
            }

            using (IWebDriver webDriver = new ChromeDriver(chromePath))
            {
                webDriver.Navigate().GoToUrl(startPage);

                utility.RandomPause(1);

                webDriver.Manage().Window.Size = browserSize;

                webDriver.Navigate().GoToUrl(usrData.ClientUrl);

                utility.RandomPause(2);

                webDriver.FindElement(By.Id("Username")).SendKeys(usrData.LogInAlias);
                webDriver.FindElement(By.Id("Password")).SendKeys(usrData.Password);
                utility.RandomPause(1.5);
                webDriver.FindElement(By.ClassName("cc-btn-sign-in")).Click();
                utility.RandomPause(3);
                pageText = webDriver.PageSource.ToString();
                searchText = "My Dashboard";

                try
                {
                    Assert.IsTrue(pageText.Contains(searchText));
                    {
                        utility.MakeLogEntry("Student shows a dashboard");
                        utility.RandomPause(2);
                        countpasses = ++countpasses;
                        searchText = string.Empty;
                    }
                }
                catch (Exception expText)
                {
                    searchText = "You are not";
                    if (pageText.Contains(searchText))
                    {
                        utility.MakeLogEntry("FAILED FAILED" + newLine + "Either last user wasn't logged out, or wrong client details.");
                    }
                    else
                    {
                        utility.MakeLogEntry("FAILED FAILED" + newLine + "Tried to authenticate as a student something went really wrong");
                    }

                    utility.MakeLogEntry("Log On Failed for client " + newLine + usrData.LogInAlias);
                    utility.MakeLogEntry("Exception Code" + newLine + expText);
                    Assert.Fail();
                }

                try
                {
                    pageText = webDriver.PageSource;
                    searchText = "Notifications";
                    Assert.IsTrue(pageText.Contains(searchText));
                    {
                        countpasses = ++countpasses;
                    }
                }
                catch (Exception expText)
                { // Log the failure
                    utility.MakeLogEntry("Log On Failed for client " + newLine + usrData.LogInAlias);
                    utility.MakeLogEntry("Exception Code" + newLine + expText);
                    Assert.Fail();
                }

                try
                {
                    pageText = webDriver.PageSource;
                    searchText = "Announcements";
                    Assert.IsTrue(pageText.Contains(searchText));
                    {
                        countpasses = ++countpasses;
                    }
                }
                catch (Exception expText)
                { // Log the failure
                    utility.MakeLogEntry("Log On Failed for client " + newLine + usrData.LogInAlias);
                    utility.MakeLogEntry("Exception Code" + newLine + expText);
                    Assert.Fail();
                }

                if (countpasses == 3)
                {
                    utility.MakeLogEntry("Student ~ " + usrData.LogInAlias + " ~ shows enrollment in courses");
                }
                else
                {
                    utility.MakeLogEntry("FAILED Review the logs we didn't get 3 successes student may not be enrolled");
                }

                // Log Out
                /* For Log OFF code required, It scrolls down and then clan click click */
                try
                {
                    IJavaScriptExecutor jsexe = (IJavaScriptExecutor)webDriver;

                    jsexe.ExecuteScript("window.scrollTo(0, Math.max(document.documentElement.scrollHeight, document.body.scrollHeight, document.documentElement.clientHeight));");

                    utility.RandomPause(2);

                    webDriver.FindElement(By.XPath(logOffXpath)).Click();
                }
                catch (Exception expText)
                {
                    utility.MakeLogEntry(expText.ToString());
                }

                /* Validation the log out was completed successfully, check is the ph num is gone */
                try
                {
                    utility.RandomPause(2);
                    pageText = webDriver.PageSource;
                    searchText = "tel:+1-855-755-2267";

                    Assert.IsTrue(!pageText.Contains(searchText));
                    {
                        utility.MakeLogEntry("PASSED Log Off");
                        passed = true;
                    }
                }
                catch (Exception expText)
                {
                    utility.MakeLogEntry("LOG OFF Failed error Was " + newLine + expText);
                    Assert.Fail();
                }

                webDriver.Close();
            }

           return passed;
        }

        /// <summary>
        /// Returns a single Xpath hard coded for each logged in Client Type
        /// </summary>
        /// <param name="userAlias">The user alias.</param>
        /// <returns>string Xpath</returns>
        public string LogOffXpath(string userAlias)
        {
            switch (userAlias)
            {
                case "BTS":
                    return ".//*[@id='app']/div[3]/footer/div[1]/div/div[2]/ul/li[4]/a";

                case "CCS":
                    return ".//*[@id='app']/div[3]/footer/div[1]/div/div[1]/ul/li[6]/a";

                case "NAS":
                    return ".//*[@id='app']/div[3]/footer/div[1]/div/div[1]/ul/li[3]/a";

                case "SCS":
                    return ".//*[@id='app']/div[3]/footer/div[1]/div/div[1]/ul/li[6]/a";

                case "WAS":
                    return ".//*[@id='app']/div[3]/footer/div[1]/div/div/ul/li[4]/a";

                case "WZS":
                    return ".//*[@id='app']/div[3]/footer/div[1]/div/div[1]/ul/li[4]/a";

                default:
                    return "nopath";
            }
        }
    }
}
