using System;


namespace FizBuzzFibb
{
  class FibbClass
  {
    public void FibonacciSeq(int stop)
    {
      Int64 firstDigit = 0;
      Int64 secondDigit = 1;
      Int64 resultSetDigit = firstDigit + secondDigit;
      Console.WriteLine("You want me to stop after {0} iterations of the Fibonacci sequence.", stop);
      Console.WriteLine("The value of the firstDigit in the sequence is now = {0}", firstDigit);
      Console.WriteLine("The value of the secondDigit in the sequence is now = {0}", secondDigit);
      Console.WriteLine("The value of the added together is of course now = {0}", resultSetDigit);
      for (int i = 0; i <= stop; i++)
      {
        if (i == 0)
        {
          Console.WriteLine("First is always 0 + 1 or == {0}", resultSetDigit);
        }
        else
        {
          Console.WriteLine("Results iteration #{0} == {1} ", i, resultSetDigit);
          firstDigit = secondDigit;
          secondDigit = resultSetDigit;
          resultSetDigit = firstDigit + secondDigit;
        }
      }

    }
  }
}
