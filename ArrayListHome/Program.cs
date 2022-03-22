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

            List<int> integerList = new List<int> { 1, 2, 3, 4, 5, 5, 6, 3, 7, 1, 8, 9, 0 };

            for (int i = 0; i < integerList.Count; i++)
            {
                if (integerList[i] % 2 == 0)
                {
                    integerList.RemoveAt(i);
                }
            }

            Console.WriteLine();
            Console.WriteLine("2. Список нечётных чисел:");
            Console.WriteLine(string.Join(", ", integerList));

            List<int> dictinctIntegerList = new List<int>();

            for (int i = 0; i < integerList.Count; i++)
            {
                if (!dictinctIntegerList.Contains(integerList[i]))
                {
                    dictinctIntegerList.Add(integerList[i]);
                }
            }

            Console.WriteLine();
            Console.WriteLine("3. Список уникальных чисел:");
            Console.WriteLine(string.Join(", ", dictinctIntegerList));
        }
    }
}
