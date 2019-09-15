using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParseTest
{
  class Program
  {
    static void Main(string[] args)
    {
      string filePathIs = Directory.GetCurrentDirectory() + "\\websiteslist.txt";
      string line = string.Empty;
      bool eof = false;
      using (StreamReader reader = new StreamReader(filePathIs))
      {

        do
        {
          line = reader.ReadLine();
          if (line == null)
          {
            eof = true;
            break;
          }
          string[] outPut = line.Split('|');

          using (WebClient client = new WebClient())
          {


          }


            Console.WriteLine(outPut[0]);
        } while (eof != true);

      }

      Console.ReadLine();
    }
  }




}
