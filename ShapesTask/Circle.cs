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

        public override string ToString()
        {
            return $"окружность диаметром {diameter} см";
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + diameter.GetHashCode();

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

            Circle circle = (Circle)obj;

            return diameter == circle.diameter;
        }
    }
}
