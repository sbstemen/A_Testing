namespace UploadTest
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using Utility;


    [TestClass]
    public class StudentUpload
    {
        private static string chromePath = Directory.GetCurrentDirectory() + Properties.Settings.Default.ChromePath;
        private static string testName = Properties.Settings.Default.TestName;
        private static string logPath = Properties.Settings.Default.LogPath +
        Properties.Settings.Default.TestName + DateTime.Now.ToString("-MM-dd-HHmm");

        private UserData usrData = new UserData();
        private Utilities utils = new Utilities(logPath);
        private Actions sUpdates = new Actions();

        [TestInitialize]
        public void CreateUserData()
        {
            this.usrData.ClientUrl = "https://qa.exeterlms.com/";
            this.usrData.LogInAlias = "CCSS";
            this.usrData.Password = "123456";
            this.usrData.BirthDate = "10/26/1960";
            this.usrData.Phone = "(480) 123-3141";
            this.usrData.AddressOne = "1234 Many St.";
            this.usrData.AddressTwo = "Back Room Front Ally";
            this.usrData.City = "Your Town";
            this.usrData.StateCode = "CALIFORNIA";
            this.usrData.ZipCode = "31415";
            this.usrData.Company = "Any Company That shovels Bits, Bytes, and Nibbles";
            this.usrData.Title = "Chief Byte Wrangler";
            this.usrData.EducationHistoryText = "Lots and lots of words. With full sentences";
            this.usrData.EmploymentHistoryText = "More words, lots more words but has names and dates";
            this.usrData.BioText = "This is even fluffier, we put in here things like ran people over";
            this.usrData.LinkedIn = @"http://www.linkedIn.Com/";
            this.usrData.BlogUrl = @"http://www.DC.Blog.CoderCamps.Com/";
            this.usrData.TwitterName = "TicTok." + DateTime.UtcNow.Ticks.ToString();
            this.usrData.GitHubUrl = "Git_LoginName";
            this.usrData.NotifyContact = true;
            this.usrData.NotifyText = true;
            this.usrData.EpochTicks = DateTime.UtcNow.Ticks.ToString();
            this.usrData.CreatedAt = DateTime.UtcNow;
        }

        [TestMethod]
        public void PerformingActions()
        {

            int passCount = 0;
            int failCount = 0;
            var nl = Environment.NewLine;
            string pageText = string.Empty;
            string searchText = string.Empty;
            string checkForValue = this.usrData.TwitterName;
            using (IWebDriver webDriver = new ChromeDriver(chromePath))
            {
                this.sUpdates.SignIn(webDriver, this.utils, this.usrData, ref passCount, ref failCount);

                this.sUpdates.UploadAFile(webDriver, this.utils, this.usrData, ref passCount, ref failCount);

                this.sUpdates.Picture(webDriver, this.utils, this.usrData, ref passCount, ref failCount);

                this.sUpdates.UpdateData(webDriver, this.utils, this.usrData, ref passCount, ref failCount);

                this.sUpdates.LoggingOff(webDriver, this.utils, this.usrData, ref passCount, ref failCount);

                this.utils.RandomPause();

                webDriver.Close();
            }

            using (IWebDriver webDriver = new ChromeDriver(chromePath))
            {
                this.sUpdates.SignIn(webDriver, this.utils, this.usrData, ref passCount, ref failCount);

                this.sUpdates.ValidateUpdates(webDriver, this.utils, this.usrData, checkForValue, ref passCount, ref failCount);

                this.sUpdates.LoggingOff(webDriver, this.utils, this.usrData, ref passCount, ref failCount);

                this.utils.RandomPause();

                webDriver.Close();
            }
        }
    }
}
