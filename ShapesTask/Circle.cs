using System;

namespace ShapesTask
{
    class Circle : IShape
    {
        private double diameter;

        public Circle(double radius)
        {
            diameter = 2 * radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(diameter / 2, 2);
        }

        public double GetHeight()
        {
            return diameter;
        }

        public double GetPerimeter()
        {
            return Math.PI * diameter;
        }

        public double GetWidth()
        {
            return diameter;
        }
    }
}
