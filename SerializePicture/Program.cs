using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializePicture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Pic");
            string image = Console.ReadLine();
            image = Directory.GetCurrentDirectory() + "\\" + image;

            Console.WriteLine(image);
            Console.ReadLine();
        }
    }
}
