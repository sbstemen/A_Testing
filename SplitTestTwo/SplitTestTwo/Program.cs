namespace SplitTestTwo
{
  using System;
  using System.IO;
  using System.Collections.Generic;
  class Program
  {
    static void Main(string[] args)
    {
      string baseFilePath = Directory.GetCurrentDirectory() + "\\assets\\" + "RawList.txt";
      List<UserDataObject> udoList = new List<UserDataObject>();
      var rawFileAll = File.ReadAllLines(baseFilePath);

      foreach (string aSingleUser in rawFileAll)
      {
        Console.Write(aSingleUser);

        var splitUserList = aSingleUser.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);

        udoList.Add(new UserDataObject()
        {
          FirstName = splitUserList[0],
          LastName = splitUserList[1],
          SiSiD = splitUserList[2],
          CRMid = splitUserList[3],
          Email = splitUserList[4],
          LogInAlias = splitUserList[5], 
          PassWord = splitUserList[6]
        });


        Console.Write("+++\n+++");
      }

      Console.Write("...end...");

    }
  }
}


/*
 OLD STUFF


        ////foreach(UserDataObject element in udoList)
        ////{
        ////  Console.WriteLine("First {0}", element.FirstName);
        ////  Console.WriteLine("Last  {0}", element.LastName);
        ////  Console.WriteLine("SiSiD {0}", element.SiSiD);
        ////  Console.WriteLine("CRMid {0}", element.CRMid);
        ////  Console.WriteLine("Eazy Mail  {0}", element.Email);
        ////  Console.WriteLine("Log On {0}", element.LogInAlias);
        ////  Console.WriteLine("Pass  {0}", element.PassWord);
        ////}

      ///////*
      //////foreach (string x in rawFileAll)
      //////{
      //////  string[] newText = x.Split('|');
      //////  foreach (string xx in newText)
      //////  {
      //////    Console.Write(xx + " ");
      //////  }
      //////  Console.WriteLine("");
      //////}
      //////
 */
