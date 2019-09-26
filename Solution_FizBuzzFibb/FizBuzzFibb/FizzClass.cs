using System;

namespace FizBuzzFibb
{
  class FizzClass
  {
    public void Fizz(int startNum, int endingNum, int fNumber, int lNumber, string fName, string lName)
    {
      for (int i = startNum; i <= endingNum; i++)
      {
        if (i > 0)
        {
          if (i % fNumber == 0 && i % lNumber == 0)
          {
            Console.WriteLine("The iteration value is == {0}.", i);
            Console.WriteLine("The First name is == {0} \n  The Last Name is == {1}.\n", fName, lName);
          }
          else if (i % fNumber == 0)
          {
            Console.WriteLine("The iteration value is == {0}.", i);
            Console.WriteLine("The first name is == {0}.\n", fName);
          }
          else if (i % lNumber == 0)
          {
            Console.WriteLine("The iteration value is == {0}.", i);
            Console.WriteLine("The last name is == {0}.\n", lName);
          }
          else
          {
            Console.WriteLine("No Name but the iteration value is == {0}.", i);
          }
        }
      }
    }


  }//EOC
}//ENS
