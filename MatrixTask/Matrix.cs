using System;
using VectorTask;

namespace MatrixTask
{
    class Matrix
    {
        private Vector[] rowsArray;

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0)
            {
                throw new ArgumentException($"Parameter value {rowsCount} is invalid. The count of components must be > 0", nameof(rowsCount));
            }

            if (columnsCount <= 0)
            {
                throw new ArgumentException($"Parameter value {columnsCount} is invalid. The count of components must be > 0", nameof(columnsCount));
            }

            rowsArray = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rowsArray[i] = new Vector(columnsCount);
            }
        }

        public Matrix(double[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException();
            }

            int rowsCount = array.GetLength(0);
            int columnsCount = array.GetLength(1);

            rowsArray = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rowsArray[i] = new Vector(columnsCount);

                for (int j = 0; j < columnsCount; j++)
                {
                    rowsArray[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            if (vectors is null)
            {
                throw new ArgumentNullException();
            }

            int columnsCount = 0;

            rowsArray = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                rowsArray[i] = new Vector(vectors[i]);

                columnsCount = Math.Max(columnsCount, vectors[i].GetSize());
            }

            for (int i = 0; i < rowsArray.Length; i++)
            {
                if (rowsArray[i].GetSize() < columnsCount)
                {
                    rowsArray[i].Add(new Vector(columnsCount));
                }
            }
        }

        public Matrix(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException();
            }

            rowsArray = new Vector[matrix.rowsArray.Length];

            for (int i = 0; i < matrix.rowsArray.Length; i++)
            {
                rowsArray[i] = new Vector(matrix.rowsArray[i]);
            }
        }

        public int[] GetSizes()
        {
            return new int[] { rowsArray.Length, rowsArray[0].GetSize() };
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index >= rowsArray.Length)
            {
                throw new ArgumentOutOfRangeException($"Parameter value {index} is invalid. The index must be within the bound of the array", nameof(index));
            }

            return rowsArray[index];
        }
    }
}
