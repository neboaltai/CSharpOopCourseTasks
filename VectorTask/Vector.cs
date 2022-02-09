using System;

namespace VectorTask
{
    class Vector
    {
        public double[] Components { get; private set; }

        public Vector(int dimension) : this(dimension, null) { }

        public Vector(double[] components) : this(components.Length, components) { }

        public Vector(Vector vector) : this(vector.Components.Length, vector.Components) { }

        public Vector(int dimension, double[] components)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("the count of components must be > 0", nameof(dimension));
            }

            Components = new double[dimension];

            if (components != null && components.Length != 0)
            {
                for (int i = 0; i < components.Length; i++)
                {
                    Components[i] = components[i];
                }
            }
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public override string ToString()
        {
            return $"{{ {string.Join(", ", Components)} }}";
        }
    }
}
