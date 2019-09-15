using System;
using System.IO;
using System.Diagnostics;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLTester
{
  class SingleURLtest
  {
    static void Main(string[] args)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();

      HelpClass help = new HelpClass("C:\\Ztst");
      SingleUrlTestProcessCode testCode = new SingleUrlTestProcessCode();
      
      string urlTest01 = "https://contentapi.qa.exeterlms.com/";
      string endTime = string.Empty;

      bool good = false;

      help.MakeLogEntry("Starting");

      good = testCode.WakeUpUrl(urlTest01);


      help.RandomPause();

      stopwatch.Stop();
      endTime = stopwatch.Elapsed.ToString();
      endTime = help.TruncationTool(endTime, 12);
      help.MakeLogEntry("End Of Log " + endTime);
    }//EOM

  }//EOC
}//EONS
