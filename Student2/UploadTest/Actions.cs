namespace UploadTest
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Utility;
    using AutoIt;


    internal class Actions
    {
        public IWebDriver SignIn(IWebDriver webDriver, Utilities utils, UserData usrData, ref int passCount, ref int failCount)
        {
            Size browserSize = new Size(1500, 900);
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
                searchText = "Graded Assignments";
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

        /* PICTURE */
        public IWebDriver Picture(IWebDriver webDriver, Utilities utils, UserData usrData, ref int passCount, ref int failCount)
        {
            string imagePath = Directory.GetCurrentDirectory() + "\\assets\\dot.jpg";
            string imgText = "Blue.jpg";

            utils.RandomPause(1.5);

            webDriver.FindElement(By.CssSelector("li.cc-user-widget")).Click();

            utils.RandomPause(1.2);

            webDriver.FindElement(By.ClassName("cc-image-uploader-save-btn")).Click();

            utils.RandomPause(1.2);

            webDriver.FindElement(By.CssSelector(".cc-file-input-container > label:nth-child(2)")).Click();

            utils.RandomPause(1);

            AutoItX.WinWaitActive("Open");
            AutoItX.ControlGetFocus("Open", "Edit1");
            AutoItX.Send("Blue.jpg");
            AutoItX.ControlGetFocus("Open","Button1"); // Button1
            AutoItX.Send("{ENTER}");

            return webDriver;
        }

        public IWebDriver UpdateData(IWebDriver webDriver, Utilities utils, UserData usrData, ref int passCount, ref int failCount)
        {
            utils.RandomPause(1);

            webDriver.FindElement(By.CssSelector("li.cc-user-widget")).Click();
            utils.RandomPause(1);
            var saveButtons = webDriver.FindElements(By.ClassName("cc-profile-form-save-btn"));

            // BirthDate
            webDriver.FindElement(By.CssSelector("input.form-control:nth-child(1)")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.CssSelector("input.form-control:nth-child(1)")).SendKeys(usrData.BirthDate);

            // Phone
            webDriver.FindElement(By.Id("phoneNumberPrimary")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("phoneNumberPrimary")).SendKeys(usrData.Phone);

            // AddOne
            webDriver.FindElement(By.Id("address1")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("address1")).SendKeys(usrData.AddressOne);

            // AddTwo
            webDriver.FindElement(By.Id("address2")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("address2")).SendKeys(usrData.AddressTwo);

            // City
            webDriver.FindElement(By.Id("city")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("city")).SendKeys(usrData.City);

            // State
            webDriver.FindElement(By.Id("state")).SendKeys(usrData.StateCode);
            utils.RandomPause(.5);

            // zipcode
            webDriver.FindElement(By.Id("postalCode")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("postalCode")).SendKeys(usrData.ZipCode);

            // Scroll into view
            IWebElement scrollToZip = webDriver.FindElement(By.Id("postalCode"));
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", scrollToZip);
            utils.RandomPause(.5);
            saveButtons[0].Click();
            utils.RandomPause(2);

            // Company Data
            webDriver.FindElement(By.Id("company")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("company")).SendKeys(usrData.Company);

            // Title
            webDriver.FindElement(By.Id("jobTitle")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("jobTitle")).SendKeys(usrData.Title);

            // Educational Text
            webDriver.FindElement(By.Id("educationHistory")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("educationHistory")).SendKeys(usrData.EducationHistoryText);

            // Employment Text
            webDriver.FindElement(By.Id("employmentHistory")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("employmentHistory")).SendKeys(usrData.EmploymentHistoryText);

            // Bio ~ CV ~ Resume
            webDriver.FindElement(By.Id("bio")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("bio")).SendKeys(usrData.BioText);

            // scroll into view
            IWebElement scrollToBio = webDriver.FindElement(By.Id("bio"));
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", scrollToBio);
            utils.RandomPause(.5);
            saveButtons[1].Click();
            utils.RandomPause(2);

            // LinkedIN
            webDriver.FindElement(By.Id("linkedInUrl")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("linkedInUrl")).SendKeys(usrData.LinkedIn);

            // Blog URL
            webDriver.FindElement(By.Id("blogUrl")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("blogUrl")).SendKeys(usrData.BlogUrl);

            // Tweeter Name
            webDriver.FindElement(By.Id("twitterHandle")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("twitterHandle")).SendKeys(usrData.TwitterName);

            // GitHub URL
            webDriver.FindElement(By.Id("gitHubUrl")).Clear();
            utils.RandomPause(.5);
            webDriver.FindElement(By.Id("gitHubUrl")).SendKeys(usrData.GitHubUrl);

            // scroll into view
            IWebElement scrollToGitHub = webDriver.FindElement(By.Id("gitHubUrl"));
            ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", scrollToGitHub);
            utils.RandomPause(.5);
            saveButtons[2].Click();

            return webDriver;
        }

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
                        Assert.Fail();
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

        public IWebDriver ValidateUpdates(IWebDriver webDriver, Utilities utils, UserData usrData, string twitterName, ref int passCount, ref int failCount)
        {
            utils.RandomPause(1);

            webDriver.FindElement(By.CssSelector("li.cc-user-widget")).Click();

            utils.RandomPause(2);

            string twitNameFromPage = webDriver.FindElement(By.Id("twitterHandle")).GetAttribute("value");

            try
            {
                Assert.IsTrue(twitNameFromPage.Contains(twitterName));
                utils.MakeLogEntry("User update test pass:: Twitter matched = " + twitterName);
                utils.MakeLogEntry("Time of user creation == " + usrData.CreatedAt.ToString());
                utils.MakeLogEntry("Epoch UTC ticks at creation == " + usrData.EpochTicks);
            }
            catch (AssertFailedException exText)
            {
                utils.MakeLogEntry("Failed the update check time of user creation == " + usrData.CreatedAt.ToString());
                utils.MakeLogEntry("Failed the update check, Epoch UTC ticks at creation == " + usrData.EpochTicks);
                Assert.Fail("Failed the update check" + Environment.NewLine + exText);
            }

            return webDriver;
        }

        public IWebDriver UploadAFile(IWebDriver webDriver, Utilities utils, UserData usrData, ref int passCount, ref int failCount)
        {
            string fileTooBeeUpLoaded = "FuzzyBunny.zip";
            string XP = "//*[@id='app-content']/div/div/div/div[2]/div[1]/div[2]/ul/li/button";
            // Open the upload test
            webDriver.FindElement(By.XPath(XP)).Click();
            
            // Browse to file 
            utils.RandomPause();
            XP = "//*[@id='app-content']/div/div/div[2]/div/div/div/div[3]";
            webDriver.FindElement(By.XPath(XP)).Click();

            AutoItX.WinWaitActive("Open");
            AutoItX.ControlGetFocus("Open", "Edit1");
            AutoItX.Send(fileTooBeeUpLoaded);
            AutoItX.ControlGetFocus("Open", "Button1"); // Button1
            AutoItX.Send("{ENTER}");

            // Save 

            return webDriver;
        }

        private string LogOffXpath(string userAlias)
        {
            switch (userAlias)
            {
                case "BTS":
                    return ".//*[@id='app']/div[3]/footer/div[1]/div/div[2]/ul/li[4]/a";

                case "CCSS":
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

