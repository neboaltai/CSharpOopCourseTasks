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

                List<string> stringsList = new List<string>();

                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {
                    stringsList.Add(currentLine);
                }

                Console.WriteLine("1. Список строк из файла:");
                Console.WriteLine(string.Join(Environment.NewLine, stringsList));
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            List<int> integersList = new List<int> { 1, 2, 3, 4, 5, 5, 6, 3, 7, 1, 8, 9, 0 };

            for (int i = 0; i < integersList.Count; i++)
            {
                if (integersList[i] % 2 == 0)
                {
                    integersList.RemoveAt(i);

                    i--;
                }
            }

            Console.WriteLine();
            Console.WriteLine("2. Список нечётных чисел:");
            Console.WriteLine(string.Join(", ", integersList));

            List<int> distinctIntegersList = new List<int>(integersList.Count);

            foreach (int e in integersList)
            {
                if (!distinctIntegersList.Contains(e))
                {
                    distinctIntegersList.Add(e);
                }
            }

            Console.WriteLine();
            Console.WriteLine("3. Список уникальных чисел:");
            Console.WriteLine(string.Join(", ", distinctIntegersList));
        }
    }
}
