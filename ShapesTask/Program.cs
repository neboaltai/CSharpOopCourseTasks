using System;
using ShapesTask.Comparers;
using ShapesTask.Shapes;

namespace ShapesTask
{
    class Program
    {
        private static IShape GetMaxAreaShape(IShape[] shapes)
        {
            if (shapes is null || shapes.Length < 1)
            {
                return null;
            }

            Array.Sort(shapes, new AreaComparer());

            return shapes[shapes.Length - 1];
        }

        private static IShape GetSecondPerimeterShape(IShape[] shapes)
        {
            if (shapes is null || shapes.Length <= 1)
            {
                return null;
            }

            Array.Sort(shapes, new PerimeterComparer());

            return shapes[shapes.Length - 2];
        }

        static void Main(string[] args)
        {
            IShape[] shapes =
            {
                new Rectangle(8, 14),
                new Circle(5),
                new Triangle(0, 0, 0, 20, 10, 10),
                new Triangle(10, 5, 2, 2, 0, 17),
                new Square(10.5),
                new Circle(6),
                new Rectangle(19, 5),
                new Triangle(2, 3, 3, -10, 3, 50)
            };

            Console.Write("Заданы геометрические фигуры:");

            if (shapes is null || shapes.Length == 0)
            {
                Console.WriteLine(" массив не задан");

                return;
            }

            Console.WriteLine();

            foreach (IShape shape in shapes)
            {
                Console.WriteLine("\t - " + shape);
            }

            Triangle triangle = new Triangle(0, 0, 0, 20, 10, 10);

            foreach (IShape shape in shapes)
            {
                if (triangle.Equals(shape))
                {
                    Console.WriteLine($"фигура: {triangle} эквивалентна одной из них");

                    break;
                }
            }

            Console.WriteLine();
            Console.Write("Фигура с максимальной площадью ");
            IShape maxAreaShape = GetMaxAreaShape(shapes);

            if (maxAreaShape is null)
            {
                Console.WriteLine("не найдена. Недостаточно элементов");
            }
            else
            {
                Console.WriteLine(":" + maxAreaShape.GetType().Name);
                Console.WriteLine($"\t площадь: {maxAreaShape.GetArea():f2} кв.см");
                Console.WriteLine($"\t периметр: {maxAreaShape.GetPerimeter():f2} см");
                Console.WriteLine($"\t ширина: {maxAreaShape.GetWidth()} см");
                Console.WriteLine($"\t высота: {maxAreaShape.GetHeight()} см");
            }

            Console.WriteLine();
            Console.Write("Фигура со вторым по величине периметром ");
            IShape secondPerimeterShape = GetSecondPerimeterShape(shapes);

            if (secondPerimeterShape is null)
            {
                Console.WriteLine("не найдена. Недостаточно элементов");
            }
            else
            {
                Console.WriteLine(":" + secondPerimeterShape.GetType().Name);
                Console.WriteLine($"\t периметр: {secondPerimeterShape.GetPerimeter():f2} см");
                Console.WriteLine($"\t площадь: {secondPerimeterShape.GetArea():f2} кв.см");
                Console.WriteLine($"\t ширина: {secondPerimeterShape.GetWidth()} см");
                Console.WriteLine($"\t высота: {secondPerimeterShape.GetHeight()} см");
            }
        }
    }
}
