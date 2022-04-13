using System;
using VectorTask;

namespace MatrixTask
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] array1 =
            {
                { 2, -3 },
                { 1, 1 },
                { 0, -1 },
                { 1, 0 }
            };

            Matrix matrixA = new Matrix(array1);
            Console.WriteLine($"Matrix {matrixA.RowsCount} x {matrixA.ColumnsCount}, specified by a two-dimensional array:: A = {matrixA}");

            Matrix matrixB = new Matrix(matrixA);
            matrixB.Transpose();
            Console.WriteLine($"Transposed matrix {matrixB.RowsCount} x {matrixB.ColumnsCount}: B = A^T = {matrixB}");

            Matrix matrixC = Matrix.GetProduct(matrixA, matrixB);
            Console.WriteLine("Matrix multiplication: С = A * B = " + matrixC);

            Console.WriteLine("Matrix determinant: detС = " + matrixC.GetDeterminant());

            Matrix matrixE = new Matrix(3, 3);
            Console.WriteLine("Matrix of zeros: E = " + matrixE);

            double[,] array2 =
            {
                { 2, -3, 1 },
                { 1, 0, -1 },
                { 0, 1, 1 }
            };

            Matrix matrixD = new Matrix(array2);
            Console.WriteLine("Matrix specified by a two-dimensional array: D1 = " + matrixD);

            matrixE.SetRow(0, matrixD.GetColumn(0));

            Vector[] vectors = { new Vector(matrixE.GetRow(0)), new Vector(matrixD.GetColumn(1)), new Vector(matrixD.GetColumn(2)) };

            Matrix matrixF = new Matrix(vectors);
            Console.WriteLine("Matrix specified by an array of row vectors: F = " + matrixF);

            double determinant = matrixF.GetDeterminant();
            Console.WriteLine("\tmatrix determinant: detF = " + determinant);

            Console.WriteLine($"\tresult of multiplication by a vector: F * {vectors[0]} = {matrixF.MultiplyByVector(vectors[0])}");

            matrixD.Add(matrixF);
            Console.WriteLine("\tresult of matrix addition: D2 = D1 + F = " + matrixD);

            matrixD.Subtract(matrixF);
            Console.WriteLine("\tresult of matrix substraction: D2 - F = " + matrixD);

            matrixF.MultiplyByScalar(determinant);
            Console.WriteLine($"\tresult of multiplying a matrix by a scalar: F * {determinant} = {matrixF}");
        }
    }
}
