using System;

namespace ShapesTask
{
    class Program
    {
        private static IShape GetMaxAreaShape(IShape[] shapes)
        {
            Array.Sort(shapes, new AreaComparer());

            return shapes[0];
        }

        private static IShape GetSecondPerimeterValueShape(IShape[] shapes)
        {
            Array.Sort(shapes, new PerimeterComparer());

            return shapes[1];
        }

        static void Main(string[] args)
        {
            IShape[] shapes = { new Rectangle(8, 14),
                                new Circle(5),
                                new Triangle(0, 0, 0, 20, 10, 10),
                                new Triangle(10, 5, 2, 2, 0, 17),
                                new Square(10.5),
                                new Circle(6),
                                new Rectangle(19, 5),
                                new Triangle(2, 3, 3, -10, 3, 50) };

            IShape maxAreaShape = GetMaxAreaShape(shapes);

            Console.WriteLine("Фигура с максимальной площадью: " + maxAreaShape.GetType().Name);
            Console.WriteLine($"\t площадь: {maxAreaShape.GetArea():f2} кв.см");
            Console.WriteLine($"\t периметр: {maxAreaShape.GetPerimeter():f2} см");
            Console.WriteLine($"\t ширина: {maxAreaShape.GetWidth()} см");
            Console.WriteLine($"\t высота: {maxAreaShape.GetHeight()} см");
            Console.WriteLine();

            IShape secondPerimeterValueShape = GetSecondPerimeterValueShape(shapes);

            Console.WriteLine("Фигура со вторым по величине периметром: " + secondPerimeterValueShape.GetType().Name);
            Console.WriteLine($"\t периметр: {secondPerimeterValueShape.GetPerimeter():f2} см");
            Console.WriteLine($"\t площадь: {secondPerimeterValueShape.GetArea():f2} кв.см");
            Console.WriteLine($"\t ширина: {secondPerimeterValueShape.GetWidth()} см");
            Console.WriteLine($"\t высота: {secondPerimeterValueShape.GetHeight()} см");
        }
    }
}
