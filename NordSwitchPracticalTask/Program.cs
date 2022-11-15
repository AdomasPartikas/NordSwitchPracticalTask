using System;
using System.IO;

namespace NordSwitchPracticalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = null;
            string t = null;
            while (true)
            {
                if (args.Length == 0 || args[0] == t)
                {
                    Console.WriteLine("Please enter file name");
                    t = Console.ReadLine();
                }
                else
                    t = args[0];

                path = Environment.CurrentDirectory + $"\\{t}";

                if (File.Exists(path))
                    break;
                Console.WriteLine("File does not exist");
            }
            Console.WriteLine("File exists!");

            var text = File.ReadAllText(t);

            Program p = new Program();
            p.CheckText(text);


            Console.ReadKey();
        }

        void CheckText(string text)
        {
            Console.WriteLine(text);
        }
    }
}
