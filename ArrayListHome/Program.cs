using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using StreamReader reader = new StreamReader("..\\..\\..\\input.txt");

                List<string> stringList = new List<string>();

                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    stringList.Add(currentLine);
                }

                Console.WriteLine("1. Список строк из файла:");
                Console.WriteLine(string.Join(Environment.NewLine, stringList));
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e);
            }
        }
    }
}
