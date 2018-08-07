namespace CC.LMS.Student.Basic
{
    using System;
    using System.Drawing;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Utility;

    internal class UpdateUserData
    {
        public IWebDriver SignIn(IWebDriver webDriver, Utilities utils, UserData usrData, ref int passCount, ref int failCount)
        {
            Size browserSize = new Size(1536, 896);
            string pageText = string.Empty;
            string searchText = string.Empty;
            string startPage = @"https://www.google.com/";
            webDriver.Navigate().GoToUrl(startPage);
            utils.RandomPause(1);
            webDriver.Manage().Window.Size = browserSize;
            webDriver.Navigate().GoToUrl(usrData.ClientUrl);
            utils.RandomPause(2);
            webDriver.FindElement(By.Id("Username")).SendKeys(usrData.LogInAlias);
            webDriver.FindElement(By.Id("Password")).SendKeys(usrData.Password);
            utils.RandomPause(1.5);
            webDriver.FindElement(By.ClassName("cc-btn-sign-in")).Click();
            utils.RandomPause(5); // Update to wait for code needs to be 5 minimum.
            pageText = webDriver.PageSource.ToString();

            searchText = "My Dashboard";

            try
            {
                Assert.IsTrue(pageText.Contains(searchText));
                {
                    utils.MakeLogEntry("Student shows a dashboard");
                    utils.RandomPause(2);
                    passCount = ++passCount;
                    searchText = string.Empty;
                }
            }
            catch (Exception expText)
            {
                searchText = "You are not";
                if (pageText.Contains(searchText))
                {
                    utils.MakeLogEntry("FAILED FAILED Either last user wasn't logged out, or wrong client details.");
                }
                else
                {
                    utils.MakeLogEntry("FAILED FAILED Tried to authenticate as a student something went really wrong");
                }

                utils.MakeLogEntry("Log On Failed for client " + usrData.LogInAlias);
                utils.MakeLogEntry("Exception Code" + expText);
                failCount = failCount++;
                Assert.Fail();
            }

            return webDriver;
        }

        // Update picture
        public IWebDriver Picture(IWebDriver webDriver, Utilities utils, UserData usrData, ref int passCount, ref int failCount)
        {
            string imagePath = Directory.GetCurrentDirectory() + "\\assets\\dot.jpg";

            utils.RandomPause(1);

            webDriver.FindElement(By.CssSelector("li.cc-user-widget")).Click();

            utils.RandomPause(1);
            /* Leave commented out for now, this is for picture updates. */
            ////webDriver.FindElement(By.ClassName("dreEkd")).Click();
            ////utils.RandomPause(1);
            ////// choose an image
            ////webDriver.FindElement(By.ClassName("cc-file-input.container")).Click();
            // save

            utils.RandomPause(1);

            return webDriver;
        }

        public IWebDriver OtherData(IWebDriver webDriver, Utilities utils, UserData usrData, ref int passCount, ref int failCount)
        {// SBS Add timing to wait for a page to load.
            usrData.LogInAlias = "x";
            usrData.Password = "password";
            usrData.BirthDate = "10/26/1960";
            usrData.Phone = "(480) 123-3141";
            usrData.AddressOne = "3141 Many St.";
            usrData.AddressTwo = "Back Room Front Ally";
            usrData.City = "Your Town";
            usrData.StateCode = "CALIFORNIA";
            usrData.ZipCode = "31415";
            usrData.Company = "Any Company That shovels Bits, Bytes, and Nibbles";
            usrData.Title = "Chief Byte Wrangler";
            usrData.EducationHistoryText = "Lots and lots of words. With full sentences";
            usrData.EmploymentHistoryText = "More words, lots more words but has names and dates";
            usrData.BioText = "This is even fluffier, we put in here things like ran people over";
            usrData.LinkedIn = "http://www.linkedIn.Com/";
            usrData.BlogUrl = "http://www.DC.Blog.CoderCamps.Com/";
            usrData.TwitterName = "tweeterMe";
            usrData.GitHubUrl = "AnotherLoginName";
            usrData.NotifyContact = true;
            usrData.NotifyText = true;

            utils.RandomPause(1);

            webDriver.FindElement(By.CssSelector("li.cc-user-widget")).Click();

            utils.RandomPause(3);
            var saveButtons = webDriver.FindElements(By.ClassName("cc-profile-form-save-btn"));
            // var itemsListed = webDriver.FindElements(By.CssSelector("div.cc-profile-form-navigation-container cc-profile-form-navigation li >a"));

            // itemsListed[1].Click();

            // BirthDate
            webDriver.FindElement(By.CssSelector("input.form-control:nth-child(1)")).Clear();
            webDriver.FindElement(By.CssSelector("input.form-control:nth-child(1)")).SendKeys(usrData.BirthDate);
            utils.RandomPause(1);

            // Phone
            webDriver.FindElement(By.Id("phoneNumberPrimary")).Clear();
            webDriver.FindElement(By.Id("phoneNumberPrimary")).SendKeys(usrData.Phone);
            utils.RandomPause(1);

            // AddOne
            webDriver.FindElement(By.Id("address1")).Clear();
            webDriver.FindElement(By.Id("address1")).SendKeys(usrData.AddressOne);
            utils.RandomPause(1);

            // AddTwo
            webDriver.FindElement(By.Id("address2")).Clear();
            webDriver.FindElement(By.Id("address2")).SendKeys(usrData.AddressTwo);
            utils.RandomPause(1);

            // City
            webDriver.FindElement(By.Id("city")).Clear();
            webDriver.FindElement(By.Id("city")).SendKeys(usrData.City);
            utils.RandomPause(1);

            // State
            webDriver.FindElement(By.Id("state")).SendKeys(usrData.StateCode);
            utils.RandomPause(1);

            // zipcode
            webDriver.FindElement(By.Id("postalCode")).Clear();
            webDriver.FindElement(By.Id("postalCode")).SendKeys(usrData.ZipCode);
            utils.RandomPause(1);

            // save
            saveButtons[0].Click();

            utils.RandomPause(1);

            // itemsListed[2].Click();

            utils.RandomPause(1);

            // Company Data
            webDriver.FindElement(By.Id("company")).Clear();
            webDriver.FindElement(By.Id("company")).SendKeys(usrData.Company);
            utils.RandomPause(1);

            // Title
            webDriver.FindElement(By.Id("jobTitle")).Clear();
            webDriver.FindElement(By.Id("jobTitle")).SendKeys(usrData.Title);
            utils.RandomPause(1);

            // Educational Text
            webDriver.FindElement(By.Id("educationHistory")).Clear();
            webDriver.FindElement(By.Id("educationHistory")).SendKeys(usrData.EducationHistoryText);
            utils.RandomPause(1);

            // Employment Text
            webDriver.FindElement(By.Id("employmentHistory")).Clear();
            webDriver.FindElement(By.Id("employmentHistory")).SendKeys(usrData.EmploymentHistoryText);
            utils.RandomPause(1);

            // Bio ~ CV ~ Resume
            webDriver.FindElement(By.Id("bio")).Clear();
            webDriver.FindElement(By.Id("bio")).SendKeys(usrData.BioText);
            utils.RandomPause(1);

            saveButtons[1].Click();

            // itemsListed[3].Click();

            // LinkedIN
            webDriver.FindElement(By.Id("linkedInUrl")).Clear();
            webDriver.FindElement(By.Id("linkedInUrl")).SendKeys(usrData.LinkedIn);
            utils.RandomPause(1);

            // Blog URL
            webDriver.FindElement(By.Id("blogUrl")).Clear();
            webDriver.FindElement(By.Id("blogUrl")).SendKeys(usrData.BlogUrl);
            utils.RandomPause(1);

            // Tweeter Name
            webDriver.FindElement(By.Id("twitterHandle")).Clear();
            webDriver.FindElement(By.Id("twitterHandle")).SendKeys(usrData.TwitterName);
            utils.RandomPause(1);

            // GitHub URL
            webDriver.FindElement(By.Id("gitHubUrl")).Clear();
            webDriver.FindElement(By.Id("gitHubUrl")).SendKeys(usrData.GitHubUrl);
            utils.RandomPause(1);

            saveButtons[2].Click();

            return webDriver;
        }

        // Log off
        public IWebDriver LoggingOff(IWebDriver webDriver, Utilities utils, UserData usrData, ref int passCount, ref int failCount)
        {
            string logOutPath = this.LogOffXpath(usrData.LogInAlias);

            try
            {
                Assert.IsFalse(logOutPath == "nopath");
                {
                    /* Moves down to the bottom of the page */
                    try
                    {
                        IJavaScriptExecutor jsexe = (IJavaScriptExecutor)webDriver;

                        jsexe.ExecuteScript
                            ("window.scrollTo(0, Math.max(document.documentElement.scrollHeight, document.body.scrollHeight, document.documentElement.clientHeight));");

                        utils.RandomPause();

                        webDriver.FindElement(By.XPath(logOutPath)).Click();
                    }
                    catch (Exception expText)
                    {
                        utils.MakeLogEntry(expText.ToString());
                        failCount = ++failCount;
                    }
                }
            }
            catch (Exception exText)
            {
                utils.MakeLogEntry("FAILED FAILED ~ " + exText);
                failCount = ++failCount;
            }

            return webDriver;
        }

        // Re-Auth to revalidate

        public IWebDriver CheckUpdates(IWebDriver webDriver, Utilities utils, UserData usrData, ref int passCount, ref int failCount)
        {

            return webDriver;
        }

        private string LogOffXpath(string userAlias)
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
