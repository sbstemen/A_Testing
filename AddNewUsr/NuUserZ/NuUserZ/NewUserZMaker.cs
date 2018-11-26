/* Make a user Return only the log in string */

namespace NuUserZ
{
  using System;
  using System.Drawing;
  using System.IO;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  using UxTestTwo;

  internal class NewUserZMaker
  {
    public string UseThisUser(IWebDriver webDriver, UxTwo util, Usr admin, Usr newGuy, PassFailCount result)
    {
      string superFly = "x";

      FillInDetails(util, newGuy, result);
      util.RandomPause(2);
      LogAnybodyIn(webDriver, util, admin, result);
      OpenUserWindow(webDriver, util, result);
      FillForm(webDriver, util, newGuy, result);
      WaitSearch(webDriver, util, newGuy, result);
      GetInviteLink(webDriver, util, newGuy, result);
      LogOffNow(webDriver, util, result);
      FirstContact(webDriver, util, newGuy, result);
      SecondContact(webDriver, util, newGuy, result);
      util.RandomPause(3);
      LogOffNow(webDriver, util, result);
      if (result.Failed <= 0)
      {
        superFly = newGuy.LogInAlias;
      }
      return superFly;
    }

    static private void FillInDetails(UxTwo util, Usr newGuyBecomes, PassFailCount result)
    {
      util.RandomPause(3);
      string theUniqueValue = string.Empty;
      newGuyBecomes.EpochTicks = DateTime.Now.Ticks.ToString();
      theUniqueValue = util.Reverse(newGuyBecomes.EpochTicks);
      theUniqueValue = util.TruncationTool(theUniqueValue, 5);
      newGuyBecomes.Email = "EM" + theUniqueValue + "@SkyK9.Com";
      newGuyBecomes.FirstName = "AutoFirst";
      newGuyBecomes.LastName = "AutoLast" + theUniqueValue;
      newGuyBecomes.LogInAlias = "LIn" + theUniqueValue;
      newGuyBecomes.FirstLogLink = "ReplaceMe";
      newGuyBecomes.Password = "123456";
      if (newGuyBecomes.FirstLogLink == "ReplaceMe")
      {
        result.Passed++;
      }
      else
      {
        result.Failed++;
      }
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

    static private IWebDriver OpenUserWindow(IWebDriver webDriver, UxTwo util, PassFailCount result)
    {
      util.RandomPause(3);
      string justRandomstring = DateTime.Now.Ticks.ToString();
      IWebElement search4Users = webDriver.FindElement(By.Id("qa-user-search-input"));
      search4Users.SendKeys(justRandomstring);
      util.RandomPause(3);
      IWebElement registrationClick = webDriver.FindElement(By.Id("qa-register-new-user-link"));
      registrationClick.Click();
      util.RandomPause(2);
      return webDriver;
    }

    static private IWebDriver FillForm(IWebDriver webDriver, UxTwo util, Usr newDude, PassFailCount result)
    {
      util.RandomPause(3);

      webDriver.FindElement(By.Id("firstName")).SendKeys(newDude.FirstName);
      util.RandomPause(1);

      webDriver.FindElement(By.Id("lastName")).SendKeys(newDude.LastName);
      util.RandomPause(1);

      webDriver.FindElement(By.Id("email")).SendKeys(newDude.Email);

      util.RandomPause(5);

      webDriver.FindElement(By.Id("qa-register-user-modal-save")).Click();
      return webDriver;
    }

    static private IWebDriver WaitSearch(IWebDriver webDriver, UxTwo util, Usr newDude, PassFailCount result)
    {
      util.RandomPause(3);

      bool passed = false;
      string searchFor = newDude.LastName;
      string webResult = webDriver.PageSource;
      passed = util.PageIsReady(webDriver, webResult, searchFor);

      if (passed)
      {
        result.Passed++;
      }
      else if (!passed)
      {
        result.Failed++;
      }
      return webDriver;
    }

    static private IWebDriver GetInviteLink(IWebDriver webDriver, UxTwo util, Usr newDude, PassFailCount result)
    {
      util.RandomPause(3);
      string newestUser = newDude.LastName;
      newDude.FirstLogLink = "ReplaceMe";
      IWebElement search4Users = webDriver.FindElement(By.Id("qa-user-search-input"));
      search4Users.Clear();
      util.RandomPause(1);
      search4Users.SendKeys(newestUser);
      util.RandomPause(1);
      webDriver.FindElement(By.ClassName("cc-admin-users")).Click();
      util.RandomPause(5);
      IJavaScriptExecutor pageScroll = webDriver as IJavaScriptExecutor;
      pageScroll.ExecuteScript("window.scrollBy(0,350);");
      util.RandomPause(8);
      webDriver.FindElement(By.Id("qa-registration-status-copy-link")).Click();
      util.RandomPause(2);
      newDude.FirstLogLink = webDriver.FindElement(By.Id("registration-link")).GetAttribute("value");
      util.RandomPause(2);
      util.MakeLogEntry("Login First Time link Data");
      util.MakeLogEntry("**" + newDude.FirstLogLink.ToString() + "**");
      util.MakeLogEntry("User was / is == " + newDude.LastName);

      if (newDude.FirstLogLink != "ReplaceMe")
      {
        result.Passed++;
      }
      else
      {
        result.Failed++;
      }
      return webDriver;
    }

    static private IWebDriver FirstContact(IWebDriver webDriver, UxTwo util, Usr newDude, PassFailCount result)
    {
      util.RandomPause(3);

      webDriver.Navigate().GoToUrl(newDude.FirstLogLink.ToString());

      util.RandomPause(3);

      webDriver.FindElement(By.Id("Username")).SendKeys(newDude.LogInAlias);

      util.RandomPause(1);

      webDriver.FindElement(By.Id("Security_Password")).SendKeys(newDude.Password);

      webDriver.FindElement(By.Id("Security_ConfirmPassword")).SendKeys(newDude.Password);

      util.RandomPause(1);

      webDriver.FindElement(By.CssSelector(".btn.btn-primary")).Click();

      util.RandomPause(5);

      string pageText = webDriver.PageSource;
      string searchText = "314159265358979";
      bool GoAhead = false;

      GoAhead = util.PageWeWanted(util, pageText, searchText, result);
      if (GoAhead)
      {
        result.Passed++;
      }
      else
      {
        result.Failed++;
      }

      webDriver.FindElement(By.Id("labelToSAcceptanceCheckbox@i")).Click();

      util.RandomPause(1);

      IJavaScriptExecutor pageScroll = webDriver as IJavaScriptExecutor;

      pageScroll.ExecuteScript("window.scrollBy(0,150);");

      webDriver.FindElement(By.Id("acceptButton")).Click();

      util.RandomPause(5);  // We have a very long pause for the second authentication

      return webDriver;
    }

    static private IWebDriver SecondContact(IWebDriver webDriver, UxTwo util, Usr newDude, PassFailCount result)
    {
      util.RandomPause(5);  // We have a very long pause for the second authentication

      webDriver.FindElement(By.Id("Username")).SendKeys(newDude.LogInAlias);

      webDriver.FindElement(By.Id("Password")).SendKeys(newDude.Password);

      util.RandomPause(1);

      webDriver.FindElement(By.ClassName("cc-btn-sign-in")).Click();

      util.RandomPause(5);

      string pageText = webDriver.PageSource;
      string searchText = "You have not been enrolled in any courses";
      bool GoAhead = false;

      GoAhead = util.PageWeWanted(util, pageText, searchText, result);
      if (GoAhead)
      {
        result.Passed++;
      }
      else
      {
        result.Failed++;
      }
      return webDriver;
    }

    static private IWebDriver LogOffNow(IWebDriver webDriver, UxTwo util, PassFailCount result)
    {
      util.RandomPause(3);
      webDriver.FindElement(By.CssSelector(".nav.navbar-nav.navbar-right>li:last-child>a")).Click();
      util.RandomPause(1);
      webDriver.FindElement(By.Id("qa-dropdown-logout")).Click();
      util.RandomPause(1);
      return webDriver;
    }

  }
}
