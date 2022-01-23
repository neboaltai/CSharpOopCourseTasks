namespace ShapesTask
{
    class Square : Rectangle
    {
        private double sideLength;

        public Square(double sideLength) : base(sideLength, sideLength)
        {
            this.sideLength = sideLength;
        }
    }
}
