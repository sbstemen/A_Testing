/* Code to Add a section */

namespace SECNamespace
{
  using System;
  using System.Drawing;
  using System.IO;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using UxTestTwo;

  internal class NewSectionMaker
  {
    public string NewSectionNumber(IWebDriver webDriver, UxTwo util, Usr admin, PassFailCount result)
    {
      string sectionSearchNumber = string.Empty;

      LogAnybodyIn(webDriver, util, admin, result);

      OpenSectionSearch(webDriver, util, result);

      // Click Save 

      // WAIT 

      // Parse the result in id=sectionName

      // Return it as the section number 

      return sectionSearchNumber;
    }

    static private IWebDriver LogAnybodyIn(IWebDriver webDriver, UxTwo util, Usr logMeIn, PassFailCount result)
    {
      webDriver.Navigate().GoToUrl(logMeIn.ClientUrl);
      util.RandomPause(2);
      bool testPassed = false;
      string findThis = "tel:+1-855-755-2267";
      string pageText = string.Empty;
      util.RandomPause(1);
      webDriver.FindElement(By.Id("Username")).SendKeys(logMeIn.LogInAlias);
      util.RandomPause(1);
      webDriver.FindElement(By.Id("Password")).SendKeys(logMeIn.Password);
      util.RandomPause(1);
      webDriver.FindElement(By.ClassName("cc-btn-sign-in")).Click();
      util.RandomPause(5);
      pageText = webDriver.PageSource;
      util.RandomPause(2);
      testPassed = util.PageIsReady(webDriver, pageText, findThis);
      if (testPassed)
      {
        result.Passed++;
      }
      else
      {
        result.Failed++;
      }
      return webDriver;
    }

    static private IWebDriver OpenSectionSearch(IWebDriver webDriver, UxTwo util, PassFailCount result)
    {
      string courseCodeIs = "ZQATest15";
      string sectionNumberIs = string.Empty;
      DateTime startingDate = new DateTime();
      startingDate = DateTime.Now.AddDays(2);
      DateTime endingDateIs = new DateTime();
      endingDateIs = DateTime.Now.AddDays(17);

      util.RandomPause(1);


      // get to search box  .form-control.cc-panel-header-lg

      var sectionSearchBox =  webDriver.FindElement(By.CssSelector("div.pull-right input.form-control.cc-panel-header-lg"));

      sectionSearchBox.SendKeys("x");

      IWebElement openSectionCreationButton = webDriver.FindElement(By.LinkText("Click here to create a new section"));

      openSectionCreationButton.Click();

      util.RandomPause(3);

      IWebElement courseCodeInput = webDriver.FindElement(By.CssSelector("div.Select-placeholder"));

      courseCodeInput.Click();

      // courseCodeInput.SendKeys(courseCodeIs);

      courseCodeInput.SendKeys(Keys.Tab);

      // input Date id=startDate 
      webDriver.FindElement(By.Id("startDate")).SendKeys(startingDate.ToString());

      util.RandomPause(1);

      webDriver.FindElement(By.Id("endDate")).SendKeys(endingDateIs.ToString());

      // input close is id=endDate

      util.RandomPause(2);

      webDriver.FindElement(By.ClassName("")).Click();

      util.RandomPause(2);


      // SAVE  .cc-admin-section-detail-wrapper button  ??  Maybe

      return webDriver;
    }

  }
}


/*Stuff I may want to implement later*/
// Change Time Zone every ??

// Unlimited Students 

// Section is open  ??