using System;


namespace FizBuzzFibb
{

  class FizFib
  {
    static void Main(string[] args)
    {
      FibbClass Fibb = new FibbClass();
      FizzClass Fizz = new FizzClass();
      string toDo = string.Empty;
      Console.WriteLine("Hello");

      do
      {
        UtilityClass.Menu();
        toDo = Console.ReadLine();
        UtilityClass.Instructions(toDo.ToUpper());

        if (toDo.ToUpper() == "F")
        {
          bool keepGoing = false;
          int returnedIntValue = 0;
          string inputValue = Console.ReadLine();
          keepGoing = UtilityClass.TestForInt(inputValue, ref returnedIntValue);
          if (keepGoing && returnedIntValue < 91)
          {
            Fibb.FibonacciSeq(returnedIntValue);
            toDo = Console.ReadLine();
          }
          else
          {
            Console.WriteLine("\n\nThat was either not an integer value or larger than 90\n\n");
            Console.WriteLine("At 91 iterations the Fibonacci sequnce is larger than an INT64");
          }
        }
        else if (toDo.ToUpper() == "Z")
        {
          bool keepGoing = false;

          do
          {
            int startPoint = 0;
            int endPoint = 100;
            int fNameNumber = 3;
            int lNameNumber = 7;
            string firstName = string.Empty;
            string lastName = string.Empty;
            string useDefaults = "D";

            Console.WriteLine("Ready to go on?  Type 'D' for default number and the we ask for your name");
            useDefaults = Console.ReadLine();
            if(useDefaults.ToUpper() == "D")
            {
              Console.WriteLine("What is your first name to be?");
              firstName = Console.ReadLine();
              Console.WriteLine("What should I put for your last Name?");
              lastName = Console.ReadLine();
              Console.Clear();
              Fizz.Fizz(startPoint, endPoint, fNameNumber, lNameNumber, firstName, lastName);
              Console.ReadLine();
            }
            else
            {
              bool goodToGo = false;
              Console.WriteLine("OK then let's collect data");
              Console.WriteLine("Let's get that starting value from you, remember Integers?\n and this is the smallest value you are going to give me.");
              string tempValue;
              tempValue = Console.ReadLine();
              goodToGo = UtilityClass.TestForInt(tempValue, ref startPoint);
              if(!goodToGo)
              {
                Environment.Exit(0);
              }
              Console.WriteLine("Good, now the ending number, \n This is the biggest number.");
              tempValue = Console.ReadLine();
              goodToGo = UtilityClass.TestForInt(tempValue, ref endPoint);
              if (!goodToGo)
              {
                Environment.Exit(0);
              }
              Console.WriteLine("OK now a prime number for your first name, \n Usually 2, 3, 5, 7, or 11 if your crazy.");
              tempValue = Console.ReadLine();
              goodToGo = UtilityClass.TestForInt(tempValue, ref fNameNumber);
              if (!goodToGo)
              {
                Environment.Exit(0);
              }
              Console.WriteLine("Last number; for your first name, \n a Larger Prime than before.");
              tempValue = Console.ReadLine();
              goodToGo = UtilityClass.TestForInt(tempValue, ref lNameNumber);
              if (!goodToGo)
              {
                Environment.Exit(0);
              }
              Console.WriteLine("Now your first name, this time I'll take anything.");
              firstName = Console.ReadLine();
              Console.WriteLine("Now your Last name, Again... I'll take anything.");
              lastName = Console.ReadLine();
              if (goodToGo)
              {
                Console.Clear();
                Fizz.Fizz(startPoint, endPoint, fNameNumber, lNameNumber, firstName, lastName);
                Console.ReadLine();
              }
            }
          } while (keepGoing);
        }

        Console.Clear();
      } while (toDo.ToUpper() != "X");
      // Last Stop Console.ReadLine();
    }//EOM
  }//EOC
}//ENS
