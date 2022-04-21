using System;
using VectorTask;

namespace MatrixTask
{
    class Matrix
    {
        private Vector[] rows;

        public int RowsCount => rows.Length;

        public int ColumnsCount => rows[0].GetSize();

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0)
            {
                throw new ArgumentException($"Parameter value {rowsCount} is invalid. The count of rows must be > 0", nameof(rowsCount));
            }

            if (columnsCount <= 0)
            {
                throw new ArgumentException($"Parameter value {columnsCount} is invalid. The count of columns must be > 0", nameof(columnsCount));
            }

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(columnsCount);
            }
        }

        public Matrix(double[,] array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array), "Array cannot be null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"Parameter value {array.Length} is invalid. The count of elements must be > 0", nameof(array));
            }

            int rowsCount = array.GetLength(0);
            int columnsCount = array.GetLength(1);

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(columnsCount);

                for (int j = 0; j < columnsCount; j++)
                {
                    rows[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            if (vectors is null)
            {
                throw new ArgumentNullException(nameof(vectors), "Array cannot be null");
            }

            if (vectors.Length == 0)
            {
                throw new ArgumentException($"Parameter value {vectors.Length} is invalid. The count of rows must be > 0", nameof(vectors));
            }

            int columnsCount = 0;

            rows = new Vector[vectors.Length];

            foreach (Vector vector in vectors)
            {
                columnsCount = Math.Max(columnsCount, vector.GetSize());
            }

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i] = new Vector(columnsCount);

                rows[i].Add(vectors[i]);
            }
        }

        public Matrix(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null");
            }

            rows = new Vector[matrix.RowsCount];

            for (int i = 0; i < matrix.RowsCount; i++)
            {
                rows[i] = new Vector(matrix.rows[i]);
            }
        }

        private static void CheckIndex(int index, int maxIndex)
        {
            if (index < 0 || index > maxIndex)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Parameter value {index} is invalid. The index must be between 0 and {maxIndex} inclusive");
            }
        }

        private static void CheckDimensions(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.RowsCount != matrix2.RowsCount || matrix1.ColumnsCount != matrix2.ColumnsCount)
            {
                throw new ArgumentException($"The dimensions of the first matrix ({matrix1.RowsCount} * {matrix1.ColumnsCount}) must match the dimensions of the second matrix ({matrix2.RowsCount} * {matrix2.ColumnsCount})");
            }
        }

        public Vector GetRow(int index)
        {
            CheckIndex(index, RowsCount - 1);

            return new Vector(rows[index]);
        }

        public void SetRow(int index, Vector vector)
        {
            CheckIndex(index, RowsCount - 1);

            if (vector.GetSize() != ColumnsCount)
            {
                throw new ArgumentException($"Parameter value {vector.GetSize()} is invalid. The size of the vector must be equal to the size of the row ({rows[index].GetSize()})", nameof(vector));
            }

            rows[index] = new Vector(vector);
        }

        public Vector GetColumn(int index)
        {
            CheckIndex(index, ColumnsCount - 1);

            Vector result = new Vector(RowsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                result.SetComponent(i, rows[i].GetComponent(index));
            }

            return result;
        }

        public void Transpose()
        {
            Vector[] columns = new Vector[ColumnsCount];

            for (int i = 0; i < ColumnsCount; i++)
            {
                columns[i] = GetColumn(i);
            }

            rows = columns;
        }

        public void MultiplyByScalar(double number)
        {
            foreach (Vector row in rows)
            {
                row.MultiplyByScalar(number);
            }
        }

        public double GetDeterminant()
        {
            if (RowsCount != ColumnsCount)
            {
                throw new InvalidOperationException($"Matrix is not square. The count of rows ({RowsCount}) must be equal to the count of columns ({ColumnsCount})");
            }

            double[,] matrixA = new double[RowsCount, RowsCount];
            double[,] matrixB = new double[RowsCount, RowsCount];

            double determinant = 1;
            double epsilon = 1.0e-10;

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < RowsCount; j++)
                {
                    if (i >= j)
                    {
                        matrixA[i, j] = rows[i].GetComponent(j);

                        for (int k = 0; k < j; k++)
                        {
                            matrixA[i, j] -= matrixA[i, k] * matrixB[k, j];
                        }
                    }

                    if (i <= j && Math.Abs(matrixA[i, i]) > epsilon)
                    {
                        matrixB[i, j] = rows[i].GetComponent(j) / matrixA[i, i];

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
            return $"{{{string.Join<Vector>(", ", rows)}}}";
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (vector is null)
            {
                throw new ArgumentNullException(nameof(vector), "Vector cannot be null");
            }

            if (vector.GetSize() != ColumnsCount)
            {
                throw new ArgumentException($"Parameter value {vector.GetSize()} is invalid. Vector size must be equal to the count of columns ({ColumnsCount})", nameof(vector));
            }

            Vector result = new Vector(RowsCount);

            for (int i = 0; i < RowsCount; i++)
            {
                result.SetComponent(i, Vector.GetDotProduct(rows[i], vector));
            }

            return result;
        }

        public void Add(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null");
            }

            CheckDimensions(this, matrix);

            for (int i = 0; i < RowsCount; i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (matrix is null)
            {
                throw new ArgumentNullException(nameof(matrix), "Matrix cannot be null");
            }

            CheckDimensions(this, matrix);

            for (int i = 0; i < rows.Length; i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            CheckDimensions(matrix1, matrix2);

            Matrix result = new Matrix(matrix1);

            result.Add(matrix2);

            return result;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            CheckDimensions(matrix1, matrix2);

            Matrix result = new Matrix(matrix1);

            result.Subtract(matrix2);

            return result;
        }

        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 is null)
            {
                throw new ArgumentNullException(nameof(matrix1), "Matrix cannot be null");
            }

            if (matrix2 is null)
            {
                throw new ArgumentNullException(nameof(matrix2), "Matrix cannot be null");
            }

            if (matrix1.ColumnsCount != matrix2.RowsCount)
            {
                throw new ArgumentException($"The count of columns ({matrix1.ColumnsCount}) of the first matrix must be equal to the count of rows ({matrix2.RowsCount}) of the second matrix");
            }

            double[,] result = new double[matrix1.RowsCount, matrix2.ColumnsCount];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = Vector.GetDotProduct(matrix1.rows[i], matrix2.GetColumn(j));
                }
            }

            return new Matrix(result);
        }
    }
}
