using System;
using System.IO;
using System.Threading;
using System.Diagnostics;


namespace URLTester
{
  public class HelpClass
  {
    private string logFile = string.Empty;

    /*replace the default constructor*/
    public HelpClass()  
    {
    }

    public HelpClass(string logPath)
    {
      string startTime = DateTime.Now.ToString("MM_dd_HH_mm_ss");
      Directory.CreateDirectory(logPath);
      this.LogFile = logPath + "\\Log_" + startTime + ".log";
    }

    public string LogFile
    {
      get
      {
        return this.logFile;
      }

      set
      {
        if(!File.Exists(value))
        {
          File.Create(value).Close();
        }

        this.logFile = value;
      }
    }

    public void MakeLogEntry(string logMessage)
    {
      using (TextWriter txtWrite = new StreamWriter(this.LogFile, true))
      {
        txtWrite.WriteLine(DateTime.Now.ToString("MMM:dd HH:mm:ss"));
        txtWrite.WriteLine(logMessage);
        txtWrite.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
        txtWrite.Close();
      }
    }

    public void RandomPause()
    {
      Thread.Sleep(1024);
      double sleepyTime;
      sleepyTime = 5120;
      Stopwatch sw = new Stopwatch();
      sw.Start();
      for (int i = 0; ; i++)
      {
        if (i % 100000 == 0)
        {
          sw.Stop();
          if (sw.ElapsedMilliseconds > sleepyTime)
          {
            break;
          }
          else
          {
            sw.Start();
          }
        }
      }
    }

    public void RandomPause(double seconds)
    {
      Thread.Sleep(1024);
      double sleepyTime;
      sleepyTime = seconds * 1024;
      Stopwatch sw = new Stopwatch();
      sw.Start();
      for (int i = 0; ; i++)
      {
        if (i % 100000 == 0)
        {
          sw.Stop();
          if (sw.ElapsedMilliseconds > sleepyTime)
          {
            break;
          }
          else
          {
            sw.Start();
          }
        }
      }
    }

    public string TruncationTool(string inPutText, int remainingCharacters)
    {
      if (string.IsNullOrEmpty(inPutText))
      {
        return inPutText;
      }
      else
      {
        inPutText = inPutText.Length <= remainingCharacters ? inPutText : inPutText.Substring(0, remainingCharacters);
      }

      return inPutText;
    }

  }//EOC
}//EONS
