
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
  // string pageText = string.Empty;
  class StartHere
  {
    static void Main(string[] args)
    {
      string argsPassedIn = null;
      string usrListIs = string.Empty;

      if(argsPassedIn == null)
      {
        usrListIs = "RawList.txt";
      }
      else if (argsPassedIn != null)
      {
        usrListIs = argsPassedIn;
      }

      /* *** Setup Steps *** */
      bool keepGoing = false;
      Size browserSize = new Size(1650, 1000); 
      string client = @"https://wozu.qa.exeterlms.com/";
      string adminUser = "admin2";
      string adminPwd = "coder#1";
      string assetPath = Directory.GetCurrentDirectory() + "\\assets\\";
      string runDatetime = DateTime.Now.ToString("_MM-dd-HHmm");

      UsrDataObject useThis2MakeUser = new UsrDataObject();
      string[] createdAccount = new string[3];

      string logPath = @"C:\ZlogZ\ANewUserSet";
      string localPath = Directory.GetCurrentDirectory();
      string filePath = localPath + "\\assets\\" + usrListIs;
      Help hpCode = new Help(logPath);
      Actions actionCode = new Actions();

      keepGoing = File.Exists(filePath);

      if(keepGoing)
      {
        var rawData = File.ReadAllLines(filePath);

        foreach(string UsrData in rawData)
        { Console.WriteLine("\n~This User Data is == {0}", UsrData); }

        Console.Write("\n Space \n Space ");

        var usersNameList = rawData
          .Select(line => line.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries)).Select(split => new UsrDataObject
          {
            FirstName = split[0],
            LastName = split[1],
            SiSiD = split[2],
            CRMid = split[3],
            Email = split[4],
            LogInAlias = split[5],
            PassWord = split[6]
          });

        foreach (UsrDataObject makeNewUser in usersNameList)
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
      else
      {
        Console.WriteLine("End HERE... did nothing there is no file. ");
      }
      Console.Write("...END...");
    }// EOM
  }// EOC
}// EONS
