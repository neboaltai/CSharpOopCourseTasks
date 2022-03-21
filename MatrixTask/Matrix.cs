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

        public void SetRow(int index, Vector vector)
        {
            if (index < 0 || index >= rowsArray.Length)
            {
                throw new ArgumentOutOfRangeException($"Parameter value {index} is invalid. The index must be within the bound of the array", nameof(index));
            }

            if (vector.GetSize() > rowsArray[index].GetSize())
            {
                throw new ArgumentException($"Parameter value {vector} is invalid. Vector size must be less than or equal to the size of the row", nameof(vector));
            }

            rowsArray[index] = new Vector(rowsArray.Length);

            rowsArray[index].Add(vector);
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index >= rowsArray[0].GetSize())
            {
                throw new ArgumentOutOfRangeException($"Parameter value {index} is invalid. The index must be within the bound of the array", nameof(index));
            }

            Vector result = new Vector(rowsArray.Length);

            for (int i = 0; i < rowsArray.Length; i++)
            {
                result.SetComponent(i, rowsArray[i].GetComponent(index));
            }

            return result;
        }

        public void Transpose()
        {
            Matrix transposedMatrix = new Matrix(rowsArray[0].GetSize(), rowsArray.Length);

            int[] transposedMatrixSize = transposedMatrix.GetSizes();

            for (int i = 0; i < transposedMatrixSize[0]; i++)
            {
                transposedMatrix.SetRow(i, GetColumn(i));
            }

            rowsArray = transposedMatrix.rowsArray;
        }

        public void MultiplyByScalar(double number)
        {
            for (int i = 0; i < rowsArray.Length; i++)
            {
                rowsArray[i].MultiplyByScalar(number);
            }
        }

        public double GetDeterminant()
        {
            if (rowsArray.Length != rowsArray[0].GetSize())
            {
                throw new RankException($"Matrix is not sqaure. The number of rows ({rowsArray.Length}) must be equal to the number of columns ({rowsArray[0].GetSize()})");
            }

            double determinant = 1;

            double[,] matrixA = new double[rowsArray.Length, rowsArray.Length];
            double[,] matrixB = new double[rowsArray.Length, rowsArray.Length];

            for (int i = 0; i < rowsArray.Length; i++)
            {
                for (int j = 0; j < rowsArray.Length; j++)
                {
                    if (i >= j)
                    {
                        matrixA[i, j] = rowsArray[i].GetComponent(j);

                        for (int k = 0; k < j; k++)
                        {
                            matrixA[i, j] -= matrixA[i, k] * matrixB[k, j];
                        }
                    }

                    if (i <= j && matrixA[i, i] != 0)
                    {
                        matrixB[i, j] = rowsArray[i].GetComponent(j) / matrixA[i, i];

                        for (int k = 0; k < i; k++)
                        {
                            matrixB[i, j] -= matrixA[i, k] * matrixB[k, j] / matrixA[i, i];
                        }
                    }
                }

                determinant *= matrixA[i, i];
            }

            return determinant;
        }

        public override string ToString()
        {
            return $"{{{string.Join<Vector>(", ", rowsArray)}}}";
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException();
            }

            Vector result = new Vector(rowsArray.Length);

            for (int i = 0; i < rowsArray.Length; i++)
            {
                result.SetComponent(i, Vector.GetDotProduct(rowsArray[i], vector));
            }

            return result;
        }

        public void Add(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException();
            }

            if (rowsArray.Length != matrix.rowsArray.Length)
            {
                throw new ArgumentException($"Parameter value {matrix.rowsArray.Length} is invalid. The count of rows should be the same as the original");
            }

            if (rowsArray[0].GetSize() != matrix.rowsArray[0].GetSize())
            {
                throw new ArgumentException($"Parameter value {matrix.rowsArray[0].GetSize()} is invalid. The count of columns should be the same as the original");
            }

            for (int i = 0; i < rowsArray.Length; i++)
            {
                rowsArray[i].Add(matrix.rowsArray[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException();
            }

            if (rowsArray.Length != matrix.rowsArray.Length)
            {
                throw new ArgumentException($"Parameter value {matrix.rowsArray.Length} is invalid. The count of rows should be the same as the original");
            }

            if (rowsArray[0].GetSize() != matrix.rowsArray[0].GetSize())
            {
                throw new ArgumentException($"Parameter value {matrix.rowsArray[0].GetSize()} is invalid. The count of columns should be the same as the original");
            }

            for (int i = 0; i < rowsArray.Length; i++)
            {
                rowsArray[i].Subtract(matrix.rowsArray[i]);
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1);

            result.Add(matrix2);

            return result;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1);

            result.Subtract(matrix2);

            return result;
        }
    }
}
