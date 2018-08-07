

namespace SplitRead
{
  using System;
  using System.Drawing;
  using System.IO;
  using System.Linq;
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
  
  class Program
  {
    static void Main(string[] args)
    {
      /* Setup */
      bool keepGoing = false;
      Size browserSize = new Size(1650, 1000);
      string pageText = string.Empty;
      string client = @"https://wozu.qa.exeterlms.com/";
      string adminUser = "admin2";
      string adminPwd = "coder#1";
      string assetPath = Directory.GetCurrentDirectory() + "\\assets\\";
      string runDatetime = DateTime.Now.ToString("_MM-dd-HHmm");

      string[] createdAccount = new string[3];

      string logPath = @"C:\ZlogZ\ANewUserSet";
      string localPath = Directory.GetCurrentDirectory();
      string filePath = localPath + "\\assets\\" + "RawList.Txt";
      Help hpCode = new Help(logPath);
      Actions actionCode = new Actions();

      keepGoing = File.Exists(filePath);

      if (keepGoing)
      {
        var rawData = File.ReadAllLines(filePath);

        var usersNameList = rawData
          .Select(line => line.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries)).Select(split => new UsrData
          {
            FirstNameSet = split[0],
            LastNameSet = split[1],
            CRMidSet = split[2],
            SISidSet = split[3],
            EmailSet = split[4],
            LogInAlias = split[5],
            PassWordSet = split[6]
          });
          
        foreach (UsrData makeNewUser in usersNameList)
        {
          Console.WriteLine("");
          {
            Console.WriteLine("A New User LoginAlias == {0}", makeNewUser.LogInAlias.ToString());
          }

          using (IWebDriver webDriver = new ChromeDriver(assetPath))
          {
            actionCode.BrowserReady(webDriver, hpCode, client);

            hpCode.RandomPause(1);

            actionCode.SignIn(webDriver, hpCode, adminUser, adminPwd);

            hpCode.RandomPause(1);

            actionCode.CreateUser(webDriver, hpCode, makeNewUser, ref createdAccount);

            hpCode.RandomPause(1);

            actionCode.GetUsrUrl(webDriver, hpCode, ref createdAccount);

            hpCode.RandomPause(1);

            actionCode.SignOff(webDriver, hpCode);

            actionCode.RegNewUsrViaUrl(webDriver, hpCode, ref createdAccount);

            hpCode.RandomPause(1);

            actionCode.FirstUsrLogIn(webDriver, hpCode, ref createdAccount);

            hpCode.RandomPause(1);

            actionCode.SignOff(webDriver, hpCode);

            hpCode.RandomPause(3);
          }

          Console.WriteLine("... END ...");
        }

        Console.WriteLine("...");
      }
    }
  }
}