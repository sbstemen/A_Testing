using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArgsTEST
{
  class Program
  {
    static void Main(string[] args)
    {
      string foo = args[0];

      Console.WriteLine("Argument 1 {0}", foo);

      Console.Write("...end...");
    }
  }
}
