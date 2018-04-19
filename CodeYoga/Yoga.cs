
namespace CodeYoga
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    class Yoga
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Open");

            RandomPause(1);
            string one;
            string rOne;
            string two;
            string rTwo;
            string three;
            string rTree;
            string fOne = "fileone.txt";
            string fTwo = "filetwo.txt";
            string path = Directory.GetCurrentDirectory();
            string[] tickArray = new string[6];

            FileCleanUp(path, fOne);
            FileCleanUp(path, fTwo);

            FileCreater(fOne);

            one = DateTime.UtcNow.Ticks.ToString();
            tickArray[0] = one;
            Console.WriteLine(one);

            rOne = Reverse(one);
            tickArray[1] = rOne;
            Console.WriteLine(rOne);

            // DropKickQuit("x");

            two = DateTime.UtcNow.Ticks.ToString();
            tickArray[2] = two;
            Console.WriteLine(two);

            rTwo = Reverse(two);
            tickArray[3] = rTwo;
            Console.WriteLine(rTwo);

            three = DateTime.UtcNow.Ticks.ToString();
            tickArray[4] = three;
            Console.WriteLine(three);

            rTree = Reverse(three);
            tickArray[5] = rTree;
            Console.WriteLine(rTree);

            aFileWriter(fOne, tickArray);

            File.Copy(fOne, fTwo);

            RandomPause(3);
        }

        static public void aFileWriter(string nameOfDaFile, string[] allTicks)
        {
            string pathToFile = Directory.GetCurrentDirectory() + "\\" + nameOfDaFile;

            using (StreamWriter sw = new StreamWriter(pathToFile))
            {
                foreach(string element in allTicks)
                {
                    sw.WriteLine(element);
                }

                sw.Close();
            }
        }

        static public bool IsFileThere(string fileName)
        {
            bool pass = false;
            string path = Directory.GetCurrentDirectory() + "\\" + fileName;
            pass = File.Exists(path);
            return pass;
        }

        static public string FileCreater(string filetocreate)
        {
            string FilePathAndName;
            bool ItIsThere = false;
            ItIsThere = IsFileThere(filetocreate);

            if (ItIsThere)
            {
                FilePathAndName = Directory.GetCurrentDirectory() + "\\" + filetocreate;
            }
            else
            {
                FilePathAndName = Directory.GetCurrentDirectory() + "\\" + filetocreate;
                using (FileStream fs = File.Create(FilePathAndName))
                {
                    fs.Close();
                }

            }

            return FilePathAndName;
        }

        static public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static public bool CallToTimer5Sec()
        {
            bool continueAutomation = true;
            bool stillWaiting = true;
            int countIs = 0;

            string toUser =
                "Please press ENTER or 'X' to stop auto execution and enter custom user data" +
                Environment.NewLine +
                "If you don't in 10 seconds we will go on and run in automated Mode. ";

            while (stillWaiting)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo c = Console.ReadKey(true);
                    if (c.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine("Do you want to stop the automated run? \n\n   And enter custom data?");
                        string userEntered = Console.ReadLine();
                        continueAutomation = false;
                        stillWaiting = false;
                        break;
                    }
                }

                RandomPause(1);
                if (countIs++ < 5)
                {
                    Console.WriteLine("Current Count is {0}", countIs);
                    Console.WriteLine("Waiting");
                    stillWaiting = true;
                }
                else
                {
                    Console.WriteLine("Time and Count Exceeded");
                    Console.WriteLine("We will go on automatically now.");
                    Console.WriteLine("POOF!!");
                    stillWaiting = false;
                }
            }

            return continueAutomation;
        }

        static public void RandomPause()
        {
            Random rdmTime = new Random();
            int pauseTime = rdmTime.Next(4096, 8192);
            Thread.Sleep(pauseTime);
        }

        static public void RandomPause(double seconds)
        {
            double sleepyTime = seconds * 1000;

            Thread.Sleep(Convert.ToInt32(sleepyTime));
        }

        static public string TruncationTool(string inPutText, int remainingCharacters)
        {
            if (string.IsNullOrEmpty(inPutText))
            {
                return inPutText;
            }
            else
            {
                inPutText = inPutText.Length <= remainingCharacters ? inPutText : inPutText.Substring(0, remainingCharacters);
            }

            return inPutText;
        }

        static public string ImageRandomizer()
        {
            string imageName = string.Empty;
            int imgNumber = 0;
            Random rnd = new Random();
            imgNumber = rnd.Next(1, 6);

            switch (imgNumber)
            {
                case 1:
                    {
                        imageName = "Blue.jpg";
                        break;
                    }

                case 2:
                    {
                        imageName = "Green.jpg";
                        break;
                    }

                case 3:
                    {
                        imageName = "Orange.jpg";
                        break;
                    }

                case 4:
                    {
                        imageName = "Purple.jpg";
                        break;
                    }

                case 5:
                    {
                        imageName = "Red.jpg";
                        break;
                    }

                case 6:
                    {
                        imageName = "Yellow.jpg";
                        break;
                    }

                default:
                    {
                        imageName = "Puppy.jpg";
                        break;
                    }
            }

            return imageName;
        }

        static public void DropKickQuit(string x)
        {
            if (x == "x")
            {
                Environment.Exit(1);
            }
        }

        static public void FileCleanUp(string assetPath, string fileName)
        {
            string revoveThis = assetPath + "\\" + fileName;
            bool isThere = File.Exists(revoveThis);
            if (isThere)
            {
                File.Delete(revoveThis);
            }
        }
    }
}
