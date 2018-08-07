/*Header */

namespace NewUsers01
{
  using System;
  using System.Drawing;
  using System.IO;
  using OpenQA.Selenium;
  using OpenQA.Selenium.Chrome;
 
  class ANewUser1
  {
    static void Main(string[] args)
    {
      /* Setup */
      bool keepGoing = false;
      Size browserSize = new Size(1650, 1000);
      string pageText = string.Empty;
      string google = @"https://www.google.com/";
      string client = Properties.Settings.Default.ClientWoz;
      string assetPath = Directory.GetCurrentDirectory() + "\\assets\\";
      string runDatetime = DateTime.Now.ToString("_MM-dd-HHmm");
      string logPath = Properties.Settings.Default.LogPath + "UserCreation" + runDatetime;
      string filePath = assetPath + "ShortList1.txt";
      Help hp = new Help(logPath);
      string[] rawUserData = new string[3];
      UsrData[] usrArray = new UsrData[3];
      int usrArrSize = usrArray.Length;
      int usrArrPosition = 0;



      /**************/
      using (IWebDriver webDriver = new ChromeDriver(assetPath))
      {
        hp.BrowserReady(webDriver, hp, google, client, browserSize);
        pageText = webDriver.PageSource;
        hp.PageIsGood(pageText);
        hp.RandomPause(5);

      }

      // file exists. 
      keepGoing = File.Exists(filePath);

      // Read into console just to read. 
      if(keepGoing)
      {
        // Do this 
        string[] lines = File.ReadAllLines(filePath);
        foreach(string line in lines)
        {
          Console.WriteLine("\t" + line);
          rawUserData[usrArrPosition] = line;


          {
            usrArray[usrArrPosition].FirstNameSet = "x";
            usrArray[usrArrPosition].LastNameSet = "z";
            usrArray[usrArrPosition].SISidSet = "V";
            usrArray[usrArrPosition].CRMidSet = "W";
            usrArray[usrArrPosition].EmailSet = "A@A.A";
            usrArray[usrArrPosition].LogInAlias = "Alpo";
            usrArray[usrArrPosition].PassWordSet = "pwd";
          }

          usrArrPosition++;
        }
      }

      /**************/

      // make a linked list of user elements. 

      /* Build My list of students */

      /* Create AND Login First Time */



      Console.ReadLine();
    }//EOM


  }//EOC
}//EONS
