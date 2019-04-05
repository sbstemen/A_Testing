//***************************************************/
//***************************************************/
//*** Author Scott B. Stemen ***/
//*** Date 20180101  */
//*** Purpose : Practice  */
//***************************************************/

using System;
using Utility;
using System.IO;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OpenGoogleOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            string startPath = Properties.Settings.Default.LogPathD;
            string testName = Properties.Settings.Default.TestName;
            string openingLine = "A" + DateTime.UtcNow.Ticks.ToString();
            string fullPath = startPath + testName + DateTime.UtcNow.ToString("-MM-dd~HHmm");
            string driverPath = Directory.GetCurrentDirectory() + "\\assets";
            Size nuSize = new Size(1684, 1024);

            if(!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            Utilities utility = new Utilities(fullPath);
            utility.MakeLogEntry("Opening Test Log ==> " + openingLine);

            using (IWebDriver webDriver = new ChromeDriver(driverPath))
            {
                string targetText = "doodle";

                string targetURL = @"https://www.google.com/";

                webDriver.Navigate().GoToUrl(targetURL);

                utility.RandomPause(1);

                webDriver.Manage().Window.Size = nuSize;

                utility.RandomPause(1);

                string pgText = webDriver.PageSource.ToString();

                try
                {
                    Assert.IsTrue(pgText.Contains(targetText));
                    {
                        Console.WriteLine("PASSED TEST");

                        utility.MakeLogEntry("Passed test for ==> " + targetText);
                    }
                }
                catch(Exception expTextCaught)
                {
                    Console.WriteLine(expTextCaught);
                    utility.MakeLogEntry("ERROR ERROR ERROR" + Environment.NewLine + expTextCaught);
                }
                
            }

            string elapsedTime = timer.Elapsed.Seconds.ToString();

            timer.Stop();

            Console.WriteLine("Test ET was ==>> {0}", elapsedTime);

            utility.RandomPause(2.75);

            utility.MakeLogEntry("Total elapsed time ==> " + elapsedTime);
        }//EOM

    }//EOC
}//EON
