namespace Hal
{
    using System;
    using System.Threading;

    class FuzzyBunny
    {
        static void Main(string[] args)
        {
            Console.WriteLine("My name is HAL");
            Console.WriteLine("  What is your name?");
            string foo = Console.ReadLine();
            Console.WriteLine("Did you say {0} that's a cool name!", foo);
            StandBy();
            Environment.Exit(0);

        }

        private static void StandBy()
        {
            Random rdmTime = new Random();
            int pauseTime = rdmTime.Next(2048, 3072);
            Thread.Sleep(pauseTime);
        }
    }
}
