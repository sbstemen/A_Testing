using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpockTest
{
  class Program
  {

    static void Main(string[] args)
    {
      var xE = 1528491079393;

      Console.WriteLine(xE);

      var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(xE).DateTime.ToLocalTime();

      Console.WriteLine(dateTime.ToString());



      Console.ReadLine();
    }
  }
}
