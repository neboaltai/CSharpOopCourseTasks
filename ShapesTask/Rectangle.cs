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
    }
}
