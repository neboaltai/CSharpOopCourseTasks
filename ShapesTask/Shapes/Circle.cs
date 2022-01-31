using System;

namespace ShapesTask.Shapes
{
    class Circle : IShape
    {
        public double Diameter { get; }

        public Circle(double radius)
        {
            Diameter = 2 * radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(Diameter / 2, 2);
        }

        public double GetHeight()
        {
            return Diameter;
        }

        public double GetPerimeter()
        {
            return Math.PI * Diameter;
        }

        public double GetWidth()
        {
            return Diameter;
        }

        public override string ToString()
        {
            return $"окружность диаметром {Diameter} см";
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + Diameter.GetHashCode();

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

            return Diameter == circle.Diameter;
        }
    }
}
