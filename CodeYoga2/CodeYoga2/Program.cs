namespace CodeYoga2
{
  using System;
  using System.Timers;
  using System.Collections.Generic;

  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("One");

      Wait(5);

      Console.WriteLine("Two");

      Console.ReadLine();
    }

    static public void Wait(Double seconds)
    {
      Double sleepyTime = seconds * 1000;

      DateTime start = DateTime.Now;
      while ((DateTime.Now - start).TotalMilliseconds < sleepyTime)
      {

      }
    }

  }

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
      _timer = new Timer(3000);
      _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
      _timer.Enabled = true; // Enable it
    }

    static void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
      _l.Add(DateTime.Now); // Add date on each timer event
    }
  }
}

// Allocate the list
// Set up the timer for 3 seconds
//
// Type "_timer.Elapsed += " and press tab twice.
//