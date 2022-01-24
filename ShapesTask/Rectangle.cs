namespace ShapesTask
{
    class Rectangle : IShape
    {
        private double width;
        private double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double GetArea()
        {
            return width * height;
        }

        public double GetHeight()
        {
            return height;
        }

        public double GetPerimeter()
        {
            return 2 * (width + height);
        }

        public double GetWidth()
        {
            return width;
        }

        public override string ToString()
        {
            return $"прямоугольник шириной {width} см, высотой {height} см";
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + width.GetHashCode();
            hash = prime * hash + height.GetHashCode();

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

            Rectangle rectangle = (Rectangle)obj;

            return width == rectangle.width && height == rectangle.height;
        }
    }
}
