namespace ShapesTask.Shapes
{
    class Rectangle : IShape
    {
        public double Width { get; private set; }

        public double Height { get; private set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetPerimeter()
        {
            return 2 * (Width + Height);
        }

        public double GetWidth()
        {
            return Width;
        }

        public override string ToString()
        {
            return $"прямоугольник шириной {Width} см, высотой {Height} см";
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + Width.GetHashCode();
            hash = prime * hash + Height.GetHashCode();

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

            return Width == rectangle.Width && Height == rectangle.Height;
        }
    }
}
