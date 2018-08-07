
namespace HW25
{
  using System;
  class Program
  {
    static void Main(string[] args)
    {
      string string1 = "hello";
      Console.Write(string1[2].ToString());

      Console.ReadLine();
    }

    /*New Method*/
    /* 
    <Access Specificer> <Return Type> <Method Name> <(Parameter LIST)> 
    <{
        METHOD BODY  
     }>

    EXAMPLE 
    public bool FuzzyBunny(int value)
    {
      bool retVal = false;
      if (value < 5)
      {
        retVal = true;
      }
      return retVal;
    }


    */
  }
}