// *************************************************************
// Coder Camps
// 8444 N. 90th Street St. 110
// Scottsdale, AZ
// -- SBS ~ 20180123
// Copyright (c) 2016-18
// Project:      CC.Student.Basic
// NOTE NOTE ~ The random pauses are required for page load timing
// *************************************************************

/* SCOTT THIS WORKS FOR SELECTING MULTIPLES 
 var buttons = webDriver.FindElements(By.CssSelector("div.cc-course-module li.list-group-item > button"));
 buttons[0].Click();
 */

namespace CC.LMS.Student.Basic
{
    using System;
    using System.Drawing;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using Utility;

    /// <summary>
    /// Class for the Login and Log out tests.
    /// </summary>
    [TestClass]
    public class StudentBasics
    {
        private static string chromePath = Directory.GetCurrentDirectory() + "\\assets\\";
        private static string passWd = Properties.Settings.Default.password;
        private static string testName = Properties.Settings.Default.TestName;
        private static string logPath = Properties.Settings.Default.LogPath +
        Properties.Settings.Default.TestName + DateTime.Now.ToString("-MM-dd-HHmm");

        private UserData usrData = new UserData();
        private Utilities utils = new Utilities(logPath);
        private UserExists login = new UserExists();
        private Enrolled enroll = new Enrolled();
        private UpdateUserData updateUser = new UpdateUserData();

        [TestMethod]
        public void Exists()
        {
            this.usrData.LogInAlias = Properties.Settings.Default.CCStudent;
            this.usrData.Password = Properties.Settings.Default.password;
            this.usrData.ClientUrl = Properties.Settings.Default.CCURL;

            bool passed = this.login.LogIn(this.utils, logPath, this.usrData);
            if (passed)
            {
                this.utils.MakeLogEntry("User / student log in test passed");
            }
            else
            {
                this.utils.MakeLogEntry("FAILED FAILED User / student log in test");
            }
        }

        [TestMethod]
        public void Enrolled()
        {
            this.usrData.LogInAlias = Properties.Settings.Default.CCStudent;
            this.usrData.Password = Properties.Settings.Default.password;
            this.usrData.ClientUrl = Properties.Settings.Default.CCURL;

            bool passed = this.enroll.SignInUser(this.utils, logPath, this.usrData);
            if (passed)
            {
                this.utils.MakeLogEntry("User / student enrollment test passed");
            }
            else
            {
                this.utils.MakeLogEntry("FAILED FAILED User / student log in test");
            }
        }

        [TestMethod]
        public void UpdateProfile()
        {
            int passCount = 0;
            int failCount = 0;
            var nl = Environment.NewLine;
            string pageText = string.Empty;
            string searchText = string.Empty;
            this.usrData.LogInAlias = Properties.Settings.Default.CCStudent;
            this.usrData.Password = Properties.Settings.Default.password;
            this.usrData.ClientUrl = Properties.Settings.Default.CCURL;

            IWebDriver webDriver = new ChromeDriver(chromePath);

            this.updateUser.SignIn(webDriver, this.utils, this.usrData, ref passCount, ref failCount);

            // this.updateUser.Picture(webDriver, this.utils, this.usrData, ref passCount, ref failCount);

            this.updateUser.OtherData(webDriver, this.utils, this.usrData, ref passCount, ref failCount); // Add Data Files

            this.updateUser.LoggingOff(webDriver, this.utils, this.usrData, ref passCount, ref failCount);

            // this.updateUser.SignIn(webDriver, this.utils, this.usrData, ref passCount, ref failCount);

            // this.updateUser.CheckUpdates(webDriver, this.utils, this.usrData, ref passCount, ref failCount);

            // this.updateUser.LoggingOff(webDriver, this.utils, this.usrData, ref passCount, ref failCount);
            this.utils.MakeLogEntry("Pass Count == " + passCount + nl + "Failure Count == " + failCount);

            webDriver.Close();

            try
            {
                Assert.AreEqual(0, failCount);
                {
                    this.utils.MakeLogEntry("There were not failures in the update tests");
                }
            }
            catch (Exception exText)
            {
                this.utils.MakeLogEntry("FAIL count was not '0' this was the update test  " + Environment.NewLine + exText);
                Assert.Fail();
            }
        }
    }
} // EONS
