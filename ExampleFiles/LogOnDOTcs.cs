namespace CC.LMS.Student.Basic
{
    using System;
    using System.Drawing;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using Utility;

    internal class LogOn
    {
        public bool SignInUser(Utilities utility, string logPath, string client, string student, string pass)
        {
            bool allGood = false;
            var newLine = Environment.NewLine;
            Size browserSize = new Size(1526, 896);
            string chromePath = Directory.GetCurrentDirectory() + "\\assets\\";
            string searchText = "My Dashboard"; // Temporary
            string startPage = @"https://www.google.com/"; // KEEP Just for browser Timing.

            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
                utility.MakeLogEntry("Log on student > " + DateTime.UtcNow.Ticks.ToString() + newLine);
            }
            else
            {
                utility.MakeLogEntry("Log on student > " + DateTime.UtcNow.Ticks.ToString() + newLine);
            }

            return allGood;
        }
    }
}
