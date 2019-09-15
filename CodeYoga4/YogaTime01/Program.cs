/* Trying to get code to WAIT  X seconds */

namespace YogaTime01
{
  using System;
  using System.Timers;
  using System.Diagnostics;
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("One");

      Stopwatch sw = new Stopwatch();
      sw.Start();
      for (int i = 0; ; i++)  // THIS is NOT an infinate lop
      {
        if (i % 100000 == 0)
        {
          sw.Stop();
          if (sw.ElapsedMilliseconds > 3000) // check 
          {
            break; // to the existing code
          }
          else
          {
            sw.Start(); // continue looping and resume time measurement
          }
        }
      }
      Console.WriteLine("Two");
      sw.Reset();

      sw.Start();
      for (int i = 0; ; i++)  // THIS is an infinate lop
      {
        if (i % 2 == 0)
        {
          sw.Stop();
          if (sw.ElapsedMilliseconds > 5000) // check 
          {
            break; // to the existing code
          }
          else
          {
            sw.Start(); // continue looping and resume time measurement
          }
        }
      }

      Console.WriteLine("Two and an eight");


      DateTime startUpTime = DateTime.Now;
      do
      {
        ;// does zipp-o-la
      } while (startUpTime.AddSeconds(5) > DateTime.Now);

      Console.WriteLine("Tre");

      Console.ReadLine();
    }
  }
}
