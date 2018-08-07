/*
BTK - BethelTech
CCP - CoderCamps 
NAU - NorthArizona
SCI - SouthernCareers
WOL - WashingtonOnLine
WOZ - WOZU
 */

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
    [TestClass]
    public class UnitTest1
    {
        public static string PasswordAlways = Properties.Settings.Default.Passwords;
        static string TestName = Properties.Settings.Default.TestName;
        static string logPath = Properties.Settings.Default.LogPath +
                                Properties.Settings.Default.TestName + DateTime.Now.ToString("-MM-dd-HHmm");

        Utilities utility = new Utilities(logPath);
        LogOnUtility LogIn = new LogOnUtility();

        [TestMethod]
        public void BethelTechPageLoad()
        {
            bool passed = false;
            var newLine = Environment.NewLine;
            string subTest = "Bethal_Login";
            string searchText = Properties.Settings.Default.BethelTechIconSearch;
            string targetUrl = Properties.Settings.Default.BethelTechURL;
            string userAlias = Properties.Settings.Default.BethelAdmin;

            passed = LogIn.LogInAdmin
            (utility, logPath, subTest, searchText, targetUrl, userAlias, PasswordAlways);

            if(passed)
            {
                utility.MakeLogEntry("All Login worked for = " + newLine + userAlias);
            }
            else
            {
                utility.MakeLogEntry("Something failed " + newLine + userAlias);
            }

        }//EOT BETHEL

        [TestMethod]
        public void CoderCampsPageLoad()
        {
            bool passed = false;
            var newLine = Environment.NewLine;
            string subTest = "CoderCamps_Login";
            string searchText = Properties.Settings.Default.CoderCampsIconSearch;
            string targetUrl = Properties.Settings.Default.CoderCampsURL;
            string userAlias = Properties.Settings.Default.CoderCampAdmin;

            passed = LogIn.LogInAdmin
            (utility, logPath, subTest, searchText, targetUrl, userAlias, PasswordAlways);

            if (passed)
            {
                utility.MakeLogEntry("All Login worked for = " + newLine + userAlias);
            }
            else
            {
                utility.MakeLogEntry("Something failed " + newLine + userAlias);
            }

        }//EOT CoderCamps

        [TestMethod]
        public void NorthernArizonaPageLoad()
        {
            bool passed = false;
            var newLine = Environment.NewLine;
            string subTest = "NorthernArizona_Logon";
            string searchText = Properties.Settings.Default.NorthernArizonaIconSearch;
            string targetUrl = Properties.Settings.Default.NorthernArizonaURL;
            string userAlias = Properties.Settings.Default.NorthernAdmin;

            passed = LogIn.LogInAdmin
            (utility, logPath, subTest, searchText, targetUrl, userAlias, PasswordAlways);

            if (passed)
            {
                utility.MakeLogEntry("All Login worked for = " + newLine + userAlias);
            }
            else
            {
                utility.MakeLogEntry("Something failed " + newLine + userAlias);
            }

        }//EOT Northern Arizona
        
        [TestMethod]
        public void SouthernCareersPageLoad()
        {
            bool passed = false;
            var newLine = Environment.NewLine;
            string subTest = "SouthernCareers_Login";
            string searchText = Properties.Settings.Default.SouthernCareersIconSearch;
            string targetUrl = Properties.Settings.Default.SouthernCareersURL;
            string userAlias = Properties.Settings.Default.SouthernAdmin;

            passed = LogIn.LogInAdmin
            (utility, logPath, subTest, searchText, targetUrl, userAlias, PasswordAlways);

            if (passed)
            {
                utility.MakeLogEntry("All Login worked for = " + newLine + userAlias);
            }
            else
            {
                utility.MakeLogEntry("Something failed " + newLine + userAlias);
            }

        }//EOT Southern Careers
        
        [TestMethod]
        public void WashingtonOnLinePageLoad()
        {
            bool passed = false;
            var newLine = Environment.NewLine;
            string subTest = "WashingtonOnLine_Logon";
            string searchText = Properties.Settings.Default.WashingtonOnLineIconSearch;
            string targetUrl = Properties.Settings.Default.WashingtonOnLineURL;
            string userAlias = Properties.Settings.Default.WashingtonAdmin;

            passed = LogIn.LogInAdmin
            (utility, logPath, subTest, searchText, targetUrl, userAlias, PasswordAlways);

            if (passed)
            {
                utility.MakeLogEntry("All Login worked for = " + newLine + userAlias);
            }
            else
            {
                utility.MakeLogEntry("Something failed " + newLine + userAlias);
            }

        }//EOT Washington OnLine

        [TestMethod]
        public void WOZUniversityPageLoad()
        {

            bool passed = false;
            var newLine = Environment.NewLine;
            string subTest = "WOZUniversity_Logon";
            string searchText = Properties.Settings.Default.WOZUniversityIconSearch;
            string targetUrl = Properties.Settings.Default.WOZUnversityURL;
            string userAlias = Properties.Settings.Default.WOZAdmin;

            passed = LogIn.LogInAdmin
            (utility, logPath, subTest, searchText, targetUrl, userAlias, PasswordAlways);

            if (passed)
            {
                utility.MakeLogEntry("All Login worked for = " + newLine + userAlias);
            }
            else
            {
                utility.MakeLogEntry("Something failed " + newLine + userAlias);
            }

        }//EOT WOZ Unversity

    }//EOC
}//EONS


/*
    //Intentionally replaced searchText with an expected fail
    searchText = "Fuzzy Bunny Search Text!";
*/