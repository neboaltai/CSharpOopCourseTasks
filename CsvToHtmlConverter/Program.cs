using System;

namespace CsvToHtmlConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 2)
            {
                CsvToHtmlConverter.ConvertCsvToHtml(args[0], args[1]);
                return;
            }

            if (args.Length != 0 && args[0].StartsWith("/?"))
            {
                Console.WriteLine("Конвертировать данные из файла формата .csv в таблицу формата .html");
            }
            else
            {
                Console.WriteLine("Ошибка: неопознанная или неполная командная строка");
            }

            Console.WriteLine();
            Console.WriteLine("ИСПОЛЬЗОВАНИЕ:");
            Console.WriteLine("\tCsvToHtmlConverter [источник] [результат]");
            Console.WriteLine();
            Console.WriteLine("  источник\tКаталог и/или имя конвертируемого файла.");
            Console.WriteLine("  результат\tКаталог и/или имя для конечного файла.");
        }
    }
}
