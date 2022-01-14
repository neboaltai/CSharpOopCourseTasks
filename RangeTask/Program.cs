using System;

namespace RangeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Range range = new Range(0, 0);

            Console.WriteLine($"Задайте непрерывный числовой диапазон ({range.From}, {range.To})");
            Console.Write("начальное значение: ");
            range.From = Convert.ToDouble(Console.ReadLine());

            Console.Write("конечное значение: ");
            range.To = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Длина диапазона: " + range.GetLength());

            Console.WriteLine();
            Console.Write("Введите число на прямой: ");
            double number = Convert.ToDouble(Console.ReadLine());

            string inside = range.IsInside(number) ? "принадлежит" : "не принадлежит";
            Console.WriteLine();
            Console.WriteLine($"Число {number} {inside} заданному диапазону");
        }
    }
}
