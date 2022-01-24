namespace ShapesTask
{
    class Square : Rectangle
    {
        private double sideLength;

        public Square(double sideLength) : base(sideLength, sideLength)
        {
            this.sideLength = sideLength;
        }

        public override string ToString()
        {
            return $"квадрат со стороной {sideLength} см";
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + sideLength.GetHashCode();

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

            Square square = (Square)obj;

            return sideLength == square.sideLength;
        }
    }
}
