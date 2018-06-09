namespace CodeYoga2
{
  using System;
  using System.Timers;
  // using System.Threading;
  using System.Collections.Generic;

  class Program
  {

    static Timer lclTimer; // From System.Timers
    static List<DateTime> listStor; // Stores timer results

    static void Main(string[] args)
    {
      Console.WriteLine("One");

      Wait(3);

      Console.WriteLine("Two");

      Console.WriteLine("(.)");

      Console.WriteLine("Three");

      Timer myTimer = new Timer();
      myTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
      myTimer.Interval = 1000;
      myTimer.Start();
      while (Console.Read() != 'q')
      {
        ;  // do nothing...
      }

      Console.WriteLine("FOUR");

      System.Threading.Thread.Sleep(2048);

    }

    public static void DisplayTimeEvent(object source, ElapsedEventArgs e)
    {
      Console.Write("\r{0}", DateTime.Now);
    }

    /// <summary>
    /// WAIT uses a compare from current to future time. 
    /// </summary>
    /// <param name="seconds"></param>
    static public void Wait(Double seconds)
    {
      Double sleepyTime = seconds * 1000;

      DateTime start = DateTime.Now;
      while ((DateTime.Now - start).TotalMilliseconds < sleepyTime)
      {
        string nl = Environment.NewLine;
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine(DateTime.Now.ToString() + nl);
      }
    }


    public static List<DateTime> DateList // Gets the results
    {
      get
      {
        if (listStor == null) // Lazily initialize the timer
        {
          Start(); // Start the timer
        }
        return listStor; // Return the list of dates
      }
    }

    static void Start()
    {
      listStor = new List<DateTime>();
      lclTimer = new Timer(40000);
      lclTimer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
      lclTimer.Enabled = true; // Enable it
    }

    static void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
      listStor.Add(DateTime.Now); // Add date on each timer event
    }


  }


}

// Allocate the list
// Set up the timer for 3 seconds
//
// Type "_timer.Elapsed += " and press tab twice.
//


/*  DN/ yet understadd this. 
 public static class TimerExample
{
  static Timer _timer; // From System.Timers
  static List<DateTime> _l; // Stores timer results

  public static List<DateTime> DateList // Gets the results
  {
    get
    {
      if (_l == null) // Lazily initialize the timer
      {
        Start(); // Start the timer
      }
      return _l; // Return the list of dates
    }
  }

  static void Start()
  {
    _l = new List<DateTime>();
    _timer = new Timer(10000);
    _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
    _timer.Enabled = true; // Enable it
  }

  static void _timer_Elapsed(object sender, ElapsedEventArgs e)
  {
    _l.Add(DateTime.Now); // Add date on each timer event
  }
}

 */
