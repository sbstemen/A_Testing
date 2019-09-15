/* Quck and dirty little timer that waits for a Q to exit*/
/*** Effectively this code is a clock.  Timer waits 1000 ms then fires again ***/
/******* This is not what you want when you are doing Wait For X  *************/
namespace YogaTime00
{
  using System;
  using System.Timers;
  class CmdClock
  {
    static void Main(string[] args)
    {
      Console.Write("z will Exit! \n");
      Timer myTimer = new Timer();
      myTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
      myTimer.Interval = 1000;
      myTimer.Start();
      while (Console.Read() != 'z')
      {
        ;  // do nothing...
      }
    }//EOM
    public static void DisplayTimeEvent(object source, ElapsedEventArgs e)
    {
      Console.Write("\r{0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    }
  }//EOC
}//EONS
//EOF