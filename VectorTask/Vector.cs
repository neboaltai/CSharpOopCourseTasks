using System;

namespace VectorTask
{
    public class Vector
    {
        private double[] components;

        public Vector(int size) : this(size, null) { }

        public Vector(double[] components) : this(components.Length, components) { }

        public Vector(Vector vector) : this(vector.components.Length, vector.components) { }

        public Vector(int size, double[] components)
        {
            if (size <= 0)
            {
                throw new ArgumentException($"Parameter value {size} is invalid. The count of components must be > 0", nameof(size));
            }

            this.components = new double[size];

            if (components != null && components.Length != 0)
            {
                Array.Copy(components, this.components, Math.Min(size, components.Length));
            }
        }

        public int GetSize()
        {
            return components.Length;
        }

        public override string ToString()
        {
            return $"{{{string.Join(", ", components)}}}";
        }

        public void Add(Vector vector)
        {
            if (vector.components.Length > components.Length)
            {
                Array.Resize(ref components, vector.components.Length);
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] += vector.components[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (vector.components.Length > components.Length)
            {
                Array.Resize(ref components, vector.components.Length);
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] -= vector.components[i];
            }
        }

        public void MultiplyByScalar(double number)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] *= number;
            }
        }

        public void Reverse()
        {
            MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            double componentSquaresSum = 0;

            foreach (double component in components)
            {
                componentSquaresSum += component * component;
            }

            return Math.Sqrt(componentSquaresSum);
        }

        public double GetComponent(int index)
        {
            return components[index];
        }

        public void SetComponent(int index, double component)
        {
            components[index] = component;
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

            if (components.Length != vector.components.Length)
            {
                return false;
            }

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] != vector.components[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 17;
            int hash = 1;

            foreach (double e in components)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1);

            result.Add(vector2);

            return result;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector result = new Vector(vector1);

            result.Subtract(vector2);

            return result;
        }

        public static double GetDotProduct(Vector vector1, Vector vector2)
        {
            double result = 0;
            double minVectorSize = Math.Min(vector1.components.Length, vector2.components.Length);

            for (int i = 0; i < minVectorSize; i++)
            {
                result += vector1.components[i] * vector2.components[i];
            }

            return result;
        }
    }
}
