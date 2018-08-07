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

    using SupportCode;
    using AutoIt;

    using OpenQA;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Interactions;

    class Acts
    {
        public IWebDriver LogIn(IWebDriver webDrVr, SupportCode suprt, UserData uDtt)
        {
            string pageText = string.Empty;
            string searchText = string.Empty;      
            suprt.RandomPause(1);
            webDrVr.Navigate().GoToUrl(uDtt.ClientUrl);
            suprt.RandomPause(2);
            webDrVr.FindElement(By.Id("Username")).SendKeys(uDtt.LogInAlias);
            webDrVr.FindElement(By.Id("Password")).SendKeys(uDtt.Password);
            suprt.RandomPause(.5);
            webDrVr.FindElement(By.ClassName("cc-btn-sign-in")).Click();
            suprt.RandomPause(5); // Update to wait for code needs to be 5 minimum.
            pageText = webDrVr.PageSource.ToString();

            searchText = "My Dashboard";

            try
            {
                Assert.IsTrue(pageText.Contains(searchText));
                {
                    suprt.MakeLogEntry("Student shows a dashboard");
                    suprt.RandomPause(2);
                    searchText = string.Empty;
                }
            }
            catch (Exception expText)
            {
                searchText = "Graded Assignments";
                if (pageText.Contains(searchText))
                {
                    suprt.MakeLogEntry("FAILED FAILED Either last user wasn't logged out, or wrong client details.");
                }
                else
                {
                    suprt.MakeLogEntry("FAILED FAILED Tried to authenticate as a student something went really wrong");
                }

                suprt.MakeLogEntry("Log On Failed for client " + uDtt.LogInAlias);
                suprt.MakeLogEntry("Exception Code" + expText);
                Assert.Fail();
            }

  
            return webDrVr;
        }

        public IWebDriver OpenProfile(IWebDriver webDrVr, SupportCode suprt, UserData Udtt)
        {
            suprt.RandomPause(.5);

            webDrVr.FindElement(By.CssSelector("li.cc-user-widget")).Click();

            suprt.RandomPause(2);  // Faster and you will get errors.

            webDrVr.FindElement(By.ClassName("cc-image-uploader-save-btn")).Click();

            suprt.RandomPause(2);

            webDrVr.FindElement(By.CssSelector(".cc-file-input-container > label:nth-child(2)")).Click();

            suprt.RandomPause(1);

            AutoItX.WinWaitActive("Open");
            AutoItX.ControlGetFocus("ComboBox1");
            AutoItX.Send("Yellow.jpg");
            AutoItX.ControlGetFocus("Button1");
            AutoItX.Send("{ENTER}");

            //  var findPoint = webDrVr.FindElement(By.CssSelector("div.col-md-2.col-md-offset-7 button.cc-image-uploader-save-btn"));
            /* most specific*/

            //  var findPoint = webDrVr.FindElements(By.CssSelector("button.cc-image-uploader-save-btn"));
            /* Returns really 4 elements because 2 are hidden behind the active modal*/

            /*THIS will return the two elemenst on the active modal*/
            var findPoint = webDrVr.FindElements(By.CssSelector("div[style=\"display: block;\"].modal button.cc-image-uploader-save-btn"));

            ((IJavaScriptExecutor)webDrVr).ExecuteScript("arguments[0].scrollIntoView(true);", findPoint[0]);

            suprt.RandomPause(1);

            findPoint[0].Click();

            suprt.RandomPause();

            return webDrVr;
        }

        /*Erase all user data from profile pages*/
        ////////public IWebDriver EraseAll(IWebDriver webDrVr, SupportCode suprt, UserData uDtt)
        ////////{
        ////////    webDrVr.FindElement(By.CssSelector("li.cc-user-widget")).Click();
        ////////    suprt.RandomPause(5);
        ////////    var saveButtons = webDrVr.FindElements(By.ClassName("cc-profile-form-save-btn"));

        ////////    // Remove the image 
        ////////    try
        ////////    {
        ////////        var imgButtons = webDrVr.FindElements(By.CssSelector("button.cc-image-uploader-save-btn"));

        ////////        // var removeImageButton = webDrVr.FindElement(By.CssSelector("div.col-sm-offset-3 > button.cc-image-uploader-save-btn"));

        ////////        imgButtons[1].Click();

        ////////    }
        ////////    catch(Exception exText)
        ////////    {
        ////////        suprt.MakeLogEntry("Delete of image failed, maybe never was an image");
        ////////        suprt.MakeLogEntry("Exception Text " + Environment.NewLine + exText);
        ////////    }

        ////////    //             // suprt.RandomPause(7);

        ////////    webDrVr.FindElement(By.Id("company")).Clear();
        ////////    // suprt.RandomPause(7);
        ////////    webDrVr.FindElement(By.Id("company")).SendKeys(".");

        ////////    suprt.RandomPause(7);

        ////////    webDrVr.FindElement(By.Id("jobTitle")).Clear();
        ////////    // suprt.RandomPause(7);
        ////////    webDrVr.FindElement(By.Id("jobTitle")).SendKeys(".");

        ////////    suprt.RandomPause(7);

        ////////    webDrVr.FindElement(By.Id("educationHistory")).Clear();
        ////////    // suprt.RandomPause(7);
        ////////    webDrVr.FindElement(By.Id("educationHistory")).SendKeys(".");

        ////////    suprt.RandomPause(7);

        ////////    webDrVr.FindElement(By.Id("employmentHistory")).Clear();
        ////////    // suprt.RandomPause(7);
        ////////    webDrVr.FindElement(By.Id("employmentHistory")).SendKeys(".");

        ////////    suprt.RandomPause(7);

        ////////    webDrVr.FindElement(By.Id("bio")).Clear();
        ////////    // suprt.RandomPause(7);
        ////////    webDrVr.FindElement(By.Id("bio")).SendKeys(".");

        ////////    suprt.RandomPause(7);


        ////////    IWebElement scrollToBio = webDrVr.FindElement(By.Id("bio"));
        ////////    ((IJavaScriptExecutor)webDrVr).ExecuteScript("arguments[0].scrollIntoView(true);", scrollToBio);
        ////////    suprt.RandomPause(7);
        ////////    // saveButtons[0].Click();

        ////////    webDrVr.FindElement(By.Id("linkedInUrl")).Clear();
        ////////    // suprt.RandomPause(7);
        ////////    webDrVr.FindElement(By.Id("linkedInUrl")).SendKeys("");

        ////////    suprt.RandomPause(7);

        ////////    webDrVr.FindElement(By.Id("blogUrl")).Clear();
        ////////    // suprt.RandomPause(7);
        ////////    webDrVr.FindElement(By.Id("blogUrl")).SendKeys("");

        ////////    suprt.RandomPause(7);

        ////////    webDrVr.FindElement(By.Id("twitterHandle")).Clear();
        ////////    // suprt.RandomPause(7);
        ////////    webDrVr.FindElement(By.Id("twitterHandle")).SendKeys("");

        ////////    suprt.RandomPause(7);

        ////////    webDrVr.FindElement(By.Id("gitHubUrl")).Clear();
        ////////    // suprt.RandomPause(7);
        ////////    webDrVr.FindElement(By.Id("gitHubUrl")).SendKeys("");

        ////////    suprt.RandomPause(7);

        ////////    saveButtons[1].Click();

        ////////    return webDrVr;
        ////////}


        //Erase Pic && Git && Bio
        public IWebDriver ProfileCleanUp(IWebDriver webDrVr, SupportCode suprt, UserData uDtt)
        {
            webDrVr.FindElement(By.CssSelector("li.cc-user-widget")).Click();
            suprt.RandomPause(5);
            var saveButtons = webDrVr.FindElements(By.ClassName("cc-profile-form-save-btn"));
 
                try
                    {
                        var imgButtons = webDrVr.FindElements(By.CssSelector("button.cc-image-uploader-save-btn"));
                        imgButtons[1].Click();
                    }
                catch (Exception exText)
                    {
                        suprt.MakeLogEntry("Delete of image failed because there was no image");
                        suprt.MakeLogEntry("Exception Text " + Environment.NewLine + exText);
                    }

            suprt.RandomPause(7);

            webDrVr.FindElement(By.Id("bio")).Clear();

            suprt.RandomPause(7);

            webDrVr.FindElement(By.Id("bio")).SendKeys("Replacement");

            suprt.RandomPause(7);

            IWebElement scrollToBio = webDrVr.FindElement(By.Id("bio"));

            ((IJavaScriptExecutor)webDrVr).ExecuteScript("arguments[0].scrollIntoView(true);", scrollToBio);

            suprt.RandomPause(7);

            webDrVr.FindElement(By.Id("gitHubUrl")).Clear();

            suprt.RandomPause(7);

            webDrVr.FindElement(By.Id("gitHubUrl")).SendKeys("Replacement");

            suprt.RandomPause(7);

            saveButtons[1].Click();

            return webDrVr;
        }
        // Load all 

        // Save 

        // Check 

    }
}
/*
string startPage = @"https://www.google.com/";
Size browserSize = new Size(1500, 900);
webDrVr.Navigate().GoToUrl(startPage);
webDrVr.Manage().Window.Size = browserSize;

*/
