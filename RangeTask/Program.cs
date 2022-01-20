using System;

namespace RangeTask
{
    class Program
    {
        private static void Print(params Range[] ranges)
        {
            bool isEmpty = true;

            foreach (Range range in ranges)
            {
                if (range != null)
                {
                    Console.Write($"({range.From}, {range.To}) ");

                    isEmpty = false;
                }
            }

            if (isEmpty)
            {
                Console.Write("отсутствует");
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задайте первый интервал");
            Console.Write("от ");
            double from = Convert.ToDouble(Console.ReadLine());

            Console.Write("до ");
            double to = Convert.ToDouble(Console.ReadLine());

            Range range1 = new Range(from, to);

            Console.WriteLine("Длина первого диапазона: " + range1.GetLength());

            Console.Write("Введите число на прямой: ");
            double number = Convert.ToDouble(Console.ReadLine());

            string particleNot = range1.IsInside(number) ? "" : "не ";

            Console.WriteLine($"Число {number} {particleNot}принадлежит заданному диапазону");

            Console.WriteLine("Задайте второй интервал");
            Console.Write("от ");
            from = Convert.ToDouble(Console.ReadLine());

            Console.Write("до ");
            to = Convert.ToDouble(Console.ReadLine());

            Range range2 = new Range(from, to);

            Console.Write("Интервал пересечения: ");
            Range intersectionRange = range1.GetIntersection(range2);
            Print(intersectionRange);

            Console.Write("Интервал(ы) объединения: ");
            Range[] unionRanges = range1.GetUnion(range2);
            Print(unionRanges);

            Console.Write("Интервал(ы) разности: ");
            Range[] differenceRanges = range1.GetDifference(range2);
            Print(differenceRanges);
        }
    }
}
