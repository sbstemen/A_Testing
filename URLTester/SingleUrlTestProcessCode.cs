using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Diagnostics;
using System.Threading.Tasks;

namespace URLTester
{
  public class SingleUrlTestProcessCode
  {


    public bool WakeUpUrl(string urlToAlert)
    {
      bool good = false;
      string htmlText = string.Empty;
      string returnedCodeAsString = string.Empty;
      int returnedCodeValueAsInteger = -1;

      try
      {
        HttpWebRequest webRequested = (HttpWebRequest)WebRequest.Create(urlToAlert);
        webRequested.AutomaticDecompression = DecompressionMethods.GZip;
        using (HttpWebResponse webResponseIs = (HttpWebResponse)webRequested.GetResponse())
        using (Stream bitStream = webResponseIs.GetResponseStream())
        using (StreamReader sReader = new StreamReader(bitStream))
        {
          htmlText = sReader.ReadToEnd(); // just the text incase it goes to shit!
          returnedCodeAsString = Convert.ToString(webResponseIs.StatusCode); // description as well 
          returnedCodeValueAsInteger = (int)webResponseIs.StatusCode;
          if (returnedCodeValueAsInteger > 0)
          {
            good = true;
          }
        }
      }
      catch (System.Net.WebException exceptionTextIs)
      {
        string exText = exceptionTextIs.ToString();
        string expectedFlawedUrl = "https://users.qa.exeterlms.com/test";

        if ((exText.Contains("(404) Not Found.")) && (expectedFlawedUrl == urlToAlert))
        {
          Console.WriteLine("It's all Okay, expected failure input was an invalid URL");
          good = true;
        }
        else
        {
          Console.WriteLine("Exception Code ==> {0}", exceptionTextIs);
        }

      }
      return good;
    }


  }
}
