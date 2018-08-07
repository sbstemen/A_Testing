using System;

namespace VSAppCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var myNumb = 4;
            var myText = "Gecko Run";
            
            Console.WriteLine(myText);

            for(int i = 0; i < myNumb; i++)
            {
                Console.Write(myText + " " + i + "\n");
            }

        }
    }
}
