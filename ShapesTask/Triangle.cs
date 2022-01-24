using System;

namespace ShapesTask
{
    class Triangle : IShape
    {
        private double x1, y1, x2, y2, x3, y3;
        private double sideA, sideB, sideC;
        private double halfPerimeter;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;

            sideA = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            sideB = Math.Sqrt(Math.Pow((x2 - x3), 2) + Math.Pow((y2 - y3), 2));
            sideC = Math.Sqrt(Math.Pow((x3 - x1), 2) + Math.Pow((y3 - y1), 2));

            halfPerimeter = (sideA + sideB + sideC) / 2;
        }

        public double GetArea()
        {
            return Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
        }

        public double GetHeight()
        {
            return Math.Max(y1, Math.Max(y2, y3)) - Math.Min(y1, Math.Min(y2, y3));
        }

        public double GetPerimeter()
        {
            return 2 * halfPerimeter;
        }

        public double GetWidth()
        {
            return Math.Max(x1, Math.Max(x2, x3)) - Math.Min(x1, Math.Min(x2, x3));
        }

        public override string ToString()
        {
            return $"треугольник со сторонами A = {sideA:f2} см, B = {sideB:f2} см, C = {sideC:f2} см";
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + x1.GetHashCode();
            hash = prime * hash + y1.GetHashCode();
            hash = prime * hash + x2.GetHashCode();
            hash = prime * hash + y2.GetHashCode();
            hash = prime * hash + x3.GetHashCode();
            hash = prime * hash + y3.GetHashCode();

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

            return x1 == triangle.x1 && y1 == triangle.y1 && 
                   x2 == triangle.x2 && y2 == triangle.y2 &&
                   x3 == triangle.x3 && y3 == triangle.y3;
        }
    }
}
