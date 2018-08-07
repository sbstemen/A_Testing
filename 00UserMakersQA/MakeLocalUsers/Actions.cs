

namespace MakeLocalUsers
{
  using System;
  using System.IO;
  using System.Linq;
  using System.Text;
  using System.Drawing;
  using OpenQA.Selenium;
  using System.Threading;
  using System.Diagnostics;
  using OpenQA.Selenium.Chrome;
  using System.Threading.Tasks;
  using System.Collections.Generic;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  public class Actions
  {


    public IWebDriver BrowserReady(IWebDriver webDriver, Help hpCode, string client)
    {
      Size browserSize = new Size(1650, 1000);
      string startPage = @"https://www.google.com/";
      webDriver.Navigate().GoToUrl(startPage);
      webDriver.Manage().Window.Size = browserSize;
      hpCode.RandomPause(2);
      webDriver.Navigate().GoToUrl(client);
      hpCode.RandomPause(3);
      return webDriver;
    }

    public IWebDriver SignIn(IWebDriver webDriver, Help hpCode, string usrName, string usrPwd)
    {
      string pageText = string.Empty;
      string searchText = "Courses";
      webDriver.FindElement(By.Id("Username")).SendKeys(usrName);
      webDriver.FindElement(By.Id("Password")).SendKeys(usrPwd);
      hpCode.RandomPause(2);
      webDriver.FindElement(By.ClassName("cc-btn-sign-in")).Click();
      hpCode.RandomPause(5);

      pageText = webDriver.PageSource.ToString();

      searchText = "Organizations";

      try
      {
        Assert.IsTrue(pageText.Contains(searchText));
        {
          hpCode.MakeLogEntry("Admin Account");
          hpCode.RandomPause(2);
          searchText = string.Empty;
        }
      }
      catch (Exception expText)
      {
        searchText = "Graded Assignments";
        pageText = webDriver.PageSource.ToString();
        if (pageText.Contains(searchText))
        {
          hpCode.MakeLogEntry("Student Login was completed.");
        }
        else
        {
          hpCode.MakeLogEntry("FAILED FAILED Tried to authenticate as a student something went really wrong");
          hpCode.MakeLogEntry("Log On Failed for client " + usrName);
          hpCode.MakeLogEntry("Exception Code" + expText);
          Assert.Fail();
        }
      }

      hpCode.RandomPause(1);
      return webDriver;
    }

    public IWebDriver CreateUser(IWebDriver webDriver, Help hpCode, UsrDataObject studentNew, ref string[] createdAccount)
    {
      string usrSrchCss = "div.media.cc-panel-header div.media-body div.pull-right input.form-control";

      string usrRegLink = "li.list-group-item.cc-panel-item.cc-panel-item-clickable.cc-panel-item-placeholder div.row div.col-md-12";

      IWebElement usrSrchBox = webDriver.FindElement(By.CssSelector(usrSrchCss));

      usrSrchBox.SendKeys(DateTime.UtcNow.Ticks.ToString());

      hpCode.RandomPause(3);

      IWebElement registrationClick = webDriver.FindElement(By.CssSelector(usrRegLink));

      registrationClick.Click();
      hpCode.RandomPause(2);

      IWebElement firstBox = webDriver.FindElement(By.Id("firstName"));
      firstBox.SendKeys(studentNew.FirstName);

      IWebElement lastBox = webDriver.FindElement(By.Id("lastName"));
      lastBox.SendKeys(studentNew.LastName);

      IWebElement sisBox = webDriver.FindElement(By.Id("sisId"));
      sisBox.SendKeys(studentNew.SiSiD);

      IWebElement crsBox = webDriver.FindElement(By.Id("crmId"));
      crsBox.SendKeys(studentNew.CRMid);

      IWebElement emailBox = webDriver.FindElement(By.Id("email"));
      emailBox.SendKeys(studentNew.Email);

      hpCode.RandomPause(3);

      var buttons = webDriver.FindElements(By.CssSelector("body.modal-open div div.fade.in.modal div.modal-dialog div.modal-content button"));

      hpCode.RandomPause(1.5);

      buttons[1].Click();

      hpCode.RandomPause(2);

      usrSrchBox.Clear();

      hpCode.RandomPause(2);

      usrSrchBox.SendKeys(studentNew.LastName);

      hpCode.RandomPause(2);

      createdAccount[0] = studentNew.LogInAlias;
      createdAccount[1] = studentNew.PassWord;
      createdAccount[2] = studentNew.Email;

      return webDriver;
    }

    public IWebDriver GetUsrUrl(IWebDriver webDriver, Help hpCode, ref string[] createdUser)
    {
      string usrSrchCss = "div.media.cc-panel-header div.media-body div.pull-right input.form-control";
      string userSelection = "li.cc-focus.list-group-item.cc-user-panel-item div div h6";
      string copyLinkBtn = "div.c011.panel.panel-default div form div span.dropdown span > button"; //.c0149.c0129
      string[] checkSum = new string[3];

      IWebElement usrSrchBox = webDriver.FindElement(By.CssSelector(usrSrchCss));

      hpCode.RandomPause(2);

      IWebElement newUserSelectCss = webDriver.FindElement(By.CssSelector(userSelection));

      newUserSelectCss.Click();

      hpCode.RandomPause(6);  /* YES keep as six whole seconds */

      var copyBtn = webDriver.FindElements(By.CssSelector(copyLinkBtn));

      copyBtn[0].Click();

      IWebElement linkBox = webDriver.FindElement(By.Id("registration-link"));

      string usrInviteUrl = linkBox.GetAttribute("value");

      createdUser[2] = usrInviteUrl;

      return webDriver;
    }

    public IWebDriver RegNewUsrViaUrl(IWebDriver webDriver, Help hpCode, ref string[] newStudentData)
    {
      string regButtonCss = "div.login-page div.row div.col-md-5.col-sm-12.col-xs-12 div.panel.panel-default li.list-group-item.cc-panel-item form div.form-group button.btn.btn-primary.cc-btn-sign-in.btn-confirm ";
      string createThisLoginId = newStudentData[0];
      string useThisPasswordVal = newStudentData[1];
      string invitationUrlToUse = newStudentData[2];

      hpCode.RandomPause(1);

      webDriver.Navigate().GoToUrl(invitationUrlToUse);

      hpCode.RandomPause(1);

      webDriver.FindElement(By.Id("Username")).SendKeys(createThisLoginId);

      webDriver.FindElement(By.Id("Security_Password")).SendKeys(useThisPasswordVal);

      webDriver.FindElement(By.Id("Security_ConfirmPassword")).SendKeys(useThisPasswordVal);

      hpCode.RandomPause(1);

      webDriver.FindElement(By.CssSelector(regButtonCss)).Click();

      hpCode.RandomPause(1);

      return webDriver;
    }

    public IWebDriver FirstUsrLogIn(IWebDriver webDriver, Help hpCode, ref string[] regStudentNew)
    {
      hpCode.RandomPause(1);
      string pageText = string.Empty;
      string searchText = "You have not been enrolled in any courses";
      webDriver.FindElement(By.Id("Username")).SendKeys(regStudentNew[0]);
      webDriver.FindElement(By.Id("Password")).SendKeys(regStudentNew[1]);
      hpCode.RandomPause(2);
      webDriver.FindElement(By.ClassName("cc-btn-sign-in")).Click();
      hpCode.RandomPause(6);

      pageText = webDriver.PageSource.ToString();

      try
      {
        Assert.IsTrue(pageText.Contains(searchText));
        {
          hpCode.MakeLogEntry("Student Account logged in");
          hpCode.RandomPause(2);
          hpCode.MakeLogEntry("WE have successfully created account {0}" + regStudentNew[0]);
          searchText = string.Empty;
        }
      }
      catch (Exception expText)
      {
        searchText = "Dashboard";
        if (pageText.Contains(searchText))
        {
          hpCode.MakeLogEntry("Student Login was completed.");
        }
        else
        {
          hpCode.MakeLogEntry("FAILED FAILED Tried to authenticate as a student something went really wrong");
          hpCode.MakeLogEntry("Exception Code" + expText);
          Assert.Fail();
        }
      }

      hpCode.RandomPause(1);

      return webDriver;
    }

    public IWebDriver SignOff(IWebDriver webDriver, Help hpCode)
    {
      try
      {
        {
          var closeButton = webDriver.FindElement(By.CssSelector("div.modal-content button.close"));
          closeButton.Click();
        }
      }
      catch (Exception exText)
      {
        hpCode.MakeLogEntry(exText.ToString());
      }

      var dashboardButton = webDriver.FindElements(By.CssSelector("div.navbar-collapse.collapse ul.nav.navbar-nav.navbar-right > li"));

      dashboardButton[0].Click();

      hpCode.RandomPause(1);

      var logOffButton = webDriver.FindElement(By.ClassName("qa-logout-button"));

      ((IJavaScriptExecutor)webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", logOffButton);

      hpCode.RandomPause(1);

      logOffButton.Click();

      return webDriver;
    }


  }// EOC
}// EONS
