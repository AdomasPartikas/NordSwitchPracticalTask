using System;
using System.IO;
using System.Text;

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
            Console.WriteLine(p.CheckText(text));


            Console.ReadKey();
        }

        string CheckText(string text)
        {
            StringBuilder sb = new StringBuilder();
            bool bracketsOpen = false;
            int countOfLetter = 1;
            for (int i = 0; i < text.Length; i++)
            {
                if(i == text.Length - 1)
                {
                    if (bracketsOpen)
                    {
                        sb.Append($"{countOfLetter}{text[i]}");
                        sb.Append("}");
                    }
                    else
                    {
                        sb.Append($"{text[i]}");
                    }
                }
                else if(text[i] == text[i+1])
                {
                    if(bracketsOpen)
                    {
                        countOfLetter++;
                    }
                    else
                    {
                        bracketsOpen = true;
                        sb.Append("{");
                        countOfLetter++;
                    }
                }
                else if(bracketsOpen)
                {
                    sb.Append($"{countOfLetter}{text[i]}");
                    sb.Append("}");
                    countOfLetter = 1;
                    bracketsOpen = false;
                }
                else
                {
                    sb.Append($"{text[i]}");
                }
            }
            return sb.ToString();
        }
    }
}
