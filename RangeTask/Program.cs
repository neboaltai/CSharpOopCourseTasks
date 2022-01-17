using System;

namespace RangeTask
{
    class Program
    {
        static void Print(params Range[] ranges)
        {
            bool isEmpty = true;

            foreach (Range range in ranges)
            {
                if (range != null)
                {
                    Console.Write($" ({range.From}, {range.To})");

                    isEmpty = false;
                }
            }

            if (isEmpty)
            {
                Console.Write(" отсутствует");
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Range range1 = new Range(0, 0);

            Console.WriteLine($"Задайте первый интервал ({range1.From}, {range1.To})");
            Console.Write("начальное значение: ");
            range1.From = Convert.ToDouble(Console.ReadLine());

            Console.Write("конечное значение: ");
            range1.To = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Длина первого диапазона: " + range1.GetLength());

            Console.WriteLine();
            Console.Write("Введите число на прямой: ");
            double number = Convert.ToDouble(Console.ReadLine());

            string inside = range1.IsInside(number) ? "принадлежит" : "не принадлежит";

            Console.WriteLine();
            Console.WriteLine($"Число {number} {inside} заданному диапазону");

            Range range2 = new Range(0, 0);

            Console.WriteLine();
            Console.WriteLine($"Задайте второй интервал ({range2.From}, {range2.To})");
            Console.Write("начальное значение: ");
            range2.From = Convert.ToDouble(Console.ReadLine());

            Console.Write("конечное значение: ");
            range2.To = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();
            Console.Write("Интервал пересечения:");

            Range intersectionRange = range1.GetIntersection(range2);

            Print(intersectionRange);

            Console.Write("Интервал(ы) объединения:");

            Range[] unionRanges = range1.GetUnion(range2);

            Print(unionRanges);

            Console.Write("Интервал(ы) разности:");

            Range[] differenceRanges = range1.GetDifference(range2);

            Print(differenceRanges);
        }
    }
}
