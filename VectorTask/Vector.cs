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

        public void Add(Vector vector)
        {
            double[] additionComponents = new double[Math.Max(Components.Length, vector.Components.Length)];

            for (int i = 0; i < vector.Components.Length; i++)
            {
                additionComponents[i] = vector.Components[i];
            }

            for (int i = 0; i < Components.Length; i++)
            {
                additionComponents[i] += Components[i];
            }

            Components = additionComponents;
        }

        public void Subtract(Vector vector)
        {
            Vector vectorCopy = new Vector(vector);

            vectorCopy.Reverse();

            Add(vectorCopy);
        }

        public void MultiplyScalar(double number)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i] *= number;
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i] *= -1;
            }
        }

        public double GetLength()
        {
            double componentSquaresSum = 0;

            for (int i = 0; i < Components.Length; i++)
            {
                componentSquaresSum += Math.Pow(Components[i], 2);
            }

            return Math.Sqrt(componentSquaresSum);
        }

        public double GetComponent(int index)
        {
            return Components[index];
        }

        public void SetComponent(int index, double component)
        {
            Components[index] = component;
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

            Vector vector = (Vector)obj;

            if (Components.Length == vector.Components.Length)
            {
                for (int i = 0; i < Components.Length; i++)
                {
                    if (Components[i] != vector.Components[i])
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int prime = 38;
            int hash = 1;

            foreach (double e in Components)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }

        public static Vector GetAdditionVector(Vector vector1, Vector vector2)
        {
            Vector additionVector = new Vector(vector1);

            additionVector.Add(vector2);

            return additionVector;
        }

        public static Vector GetSubtrationVector(Vector vector1, Vector vector2)
        {
            Vector subtractionVector = new Vector(vector1);

            subtractionVector.Subtract(vector2);

            return subtractionVector;
        }

        public static double GetDotProduct(Vector vector1, Vector vector2)
        {
            double result = 0;

            for (int i = 0; i < Math.Min(vector1.Components.Length, vector2.Components.Length); i++)
            {
                result += vector1.Components[i] * vector2.Components[i];
            }

            return result;
        }
    }
}
