using System;


namespace FizBuzzFibb
{
  static class UtilityClass
  {
    static public bool TestForInt(string isThisInt, ref int value)
      {
      bool itIsANumber = false;
      itIsANumber = int.TryParse(isThisInt, out value);
      return itIsANumber;
      }
    static public void Menu()
    {
      Console.WriteLine("Press the letter  Z to do a FIZ BUZ test.");
      Console.WriteLine("Press the letter  F to do a Fibonacci test.");
      Console.WriteLine("To Exit the application just type an X and it will quit.");
    }
    static public void Instructions(string testType)
    {
      if (testType == "F")
      {
        _Fibonacci();
      }
      else if (testType == "Z")
      {
        _FizzBuzz();
      }
    }
    static private void _Fibonacci()
    { /* Fibonacci instructions */
      Console.WriteLine("This will print out the well known Fibonacci sequence");
      Console.WriteLine("It takes in the ending integer value smaller than 90");
      Console.WriteLine("Fibonacci sequence numbers larger than 90 iterations. \n Exceed size of a Big INT!");
    }
    static private void _FizzBuzz()
    {  /* Fiz Buz Test instructions */
      Console.Clear();
      Console.WriteLine("*********************************");
      Console.WriteLine("** This is a FIZ BUZZ tester **");
      Console.WriteLine("*****************************");
      Console.WriteLine("We need six data items to perform this test.");
      Console.WriteLine("  We are going to ask your First name, then Last name:\n");
      Console.WriteLine(" After that we need 4 integers or whole numbers.");
      Console.WriteLine("   YES! if you put in wrong numbers we start all over again.\n");
      Console.WriteLine("First Number is a start point, then and end point, default is 0 ~ 100");
      Console.WriteLine("  The next number is the divisor for your first name.");
      Console.WriteLine("    Then the divisor for your last name");
      Console.WriteLine("      or you can type a D for default.");
      Console.WriteLine("Prime numbers work best, like 2, 3, 5, 7, don't get crazy.");
      Console.WriteLine("\n\nIf you accidently put in non~numbers we start over.\n\n");
    }

  }//EOC
}//ENS
