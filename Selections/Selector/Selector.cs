namespace Selections
{

    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using SupportCode;
    class Selector
    {

        static void Main(string[] args)
        {
            string lclLog = Directory.GetCurrentDirectory() + "\\LogFiles\\";
            string chPath = Directory.GetCurrentDirectory() + "\\assets\\";
            SupportCode support = new SupportCode(lclLog);
            UserData uData = new UserData();
            Acts actOn = new Acts();

            string mText = "Tick Is == " + DateTime.UtcNow.Ticks.ToString();
            support.UDataFiller(uData);

            Console.WriteLine(mText);
            support.MakeLogEntry(mText);
            System.Threading.Thread.Sleep(1024);
            support.MakeLogEntry(DateTime.UtcNow.Ticks.ToString());
            Console.WriteLine(uData.CreatedAt.ToString("yyyy~MM~dd::HH:mm:ss"));
            Console.WriteLine(uData.TwitterName);
            Console.WriteLine("Ticks == {0}",uData.EpochTicks);

            Size browserSize = new Size(1300, 1024);
            string pageText = string.Empty;
            string searchText = string.Empty;
            string startPage = @"https://www.google.com/";

            support.RandomPause(3);

            using (IWebDriver webDriver = new ChromeDriver(chPath))
            {
                webDriver.Navigate().GoToUrl(startPage);

                webDriver.Manage().Window.Size = browserSize;

                support.RandomPause(2);

                actOn.LogIn(webDriver, support, uData);

                Console.WriteLine("Back At ya.. Logged in!");

                actOn.ProfileCleanUp(webDriver, support, uData);

                actOn.OpenProfile(webDriver, support, uData);

                Console.WriteLine("Back At ya.. Profile Opened");


                webDriver.Close();
            }

        }
    }
}


/*
string xPath = "./html/body/div[5]/div[2]/div/div/div[2]/div/div[3]/div[2]/div/small";
 IWebElement findPoint = webDriver.FindElement(By.XPath(xPath));
  ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", findPoint);
     xPath = ".//*[@id='body']/div[5]/div[2]/div/div/div[2]/div/div[3]/div[3]/div[1]/button";
       webDriver.FindElement(By.XPath(xPath)).Click();
*/