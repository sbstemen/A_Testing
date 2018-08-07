namespace ManyFiles
{
    using System;
    using System.Drawing;
    using System.Threading;
    using OpenQA;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    class Helper
    {

        public IWebDriver SignIn(IWebDriver webDriver, string client, string student)
        {
            string pwd = "123456";
            if(student == "sbs")
            { pwd = "314159"; }


            Size browserSize = new Size(1500, 900);
            string pageText = string.Empty;
            string searchText = string.Empty;
            string startPage = @"https://www.google.com/";
            webDriver.Navigate().GoToUrl(startPage);
            this.RandomPause(1);
            webDriver.Manage().Window.Size = browserSize;
            webDriver.Navigate().GoToUrl(client);
            this.RandomPause(2);
            webDriver.FindElement(By.Id("Username")).SendKeys(student);
            webDriver.FindElement(By.Id("Password")).SendKeys(pwd);
            this.RandomPause(2);
            webDriver.FindElement(By.ClassName("cc-btn-sign-in")).Click();
            this.RandomPause(5); // Update to wait for code needs to be 5 minimum.
            pageText = webDriver.PageSource.ToString();

            searchText = "My Dashboard";

            try
            {
                Assert.IsTrue(pageText.Contains(searchText));
                {
                    this.RandomPause(2);
                    searchText = string.Empty;
                }
            }
            catch (Exception expText)
            {
                searchText = "Graded Assignments";
                if (pageText.Contains(searchText))
                {
                }
                else
                {
                }
                Assert.Fail();
            }

            return webDriver;
        }

        public IWebDriver LoggingOff(IWebDriver webDriver)
        {
            this.RandomPause(1);

            IJavaScriptExecutor jsExecutorCode = (IJavaScriptExecutor)webDriver;

            jsExecutorCode.ExecuteScript(
                "window.scrollTo(0, Math.max(document.documentElement.scrollHeight, document.body.scrollHeight, document.documentElement.clientHeight));");

            webDriver.FindElement(By.ClassName("qa-logout-button")).Click();

            this.RandomPause(1);

            return webDriver;
        }

        public void RandomPause()
        {
            Random rdmTime = new Random();
            int pauseTime = rdmTime.Next(4096, 8192);
            Thread.Sleep(pauseTime);
        }

        public void RandomPause(double seconds)
        {
            double sleepyTime = seconds * 1000;

            Thread.Sleep(Convert.ToInt32(sleepyTime));
        }
    }
}
