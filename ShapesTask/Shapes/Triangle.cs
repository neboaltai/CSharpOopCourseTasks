using System;

namespace ShapesTask.Shapes
{
    class Triangle : IShape
    {
        private readonly double sideA;
        private readonly double sideB;
        private readonly double sideC;
        private readonly double halfPerimeter;

        public double X1 { get; }

        public double Y1 { get; }

        public double X2 { get; }

        public double Y2 { get; }

        public double X3 { get; }

        public double Y3 { get; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;

            sideA = GetSideLength(x1, y1, x2, y2);
            sideB = GetSideLength(x2, y2, x3, y3);
            sideC = GetSideLength(x1, y1, x3, y3);

            halfPerimeter = (sideA + sideB + sideC) / 2;
        }
        
        private static double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
        }

        public double GetArea()
        {
            return Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
        }

        public double GetHeight()
        {
            return Math.Max(Y1, Math.Max(Y2, Y3)) - Math.Min(Y1, Math.Min(Y2, Y3));
        }

        public double GetPerimeter()
        {
            return 2 * halfPerimeter;
        }

        public double GetWidth()
        {
            return Math.Max(X1, Math.Max(X2, X3)) - Math.Min(X1, Math.Min(X2, X3));
        }

        public override string ToString()
        {
            return $"треугольник со сторонами A = {sideA:f2} см, B = {sideB:f2} см, C = {sideC:f2} см";
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj is null || obj.GetType() != GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            return X1 == triangle.X1 && Y1 == triangle.Y1 &&
                   X2 == triangle.X2 && Y2 == triangle.Y2 &&
                   X3 == triangle.X3 && Y3 == triangle.Y3;
        }
    }
}
