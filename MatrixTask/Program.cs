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
            Console.WriteLine($"Матрица {string.Join("x", matrixA.GetSizes())}, заданная двумерным массивом: A = {matrixA}");

            Matrix matrixB = new Matrix(matrixA);
            matrixB.Transpose();
            Console.WriteLine($"Транспонированная матрица {string.Join("x", matrixB.GetSizes())}: B = A^T = {matrixB}");

            Matrix matrixC = Matrix.GetProduct(matrixA, matrixB);
            Console.WriteLine("Умножение матриц: С = A * B = " + matrixC);

            Console.WriteLine("Определитель матрицы: detС = " + matrixC.GetDeterminant());

            Matrix matrixE = new Matrix(3, 4);
            Console.WriteLine("Матрица нулей: E = " + matrixE);

            double[,] array2 =
            {
                { 2, -3, 1 },
                { 1, 0, -1 },
                { 0, 1, 1 }
            };

            Matrix matrixD = new Matrix(array2);
            Console.WriteLine("Матрица, заданная двумерным массивом: D1 = " + matrixD);

            matrixE.SetRow(0, matrixD.GetColumn(0));

            Vector[] vectors = { new Vector(matrixE.GetRow(0)), new Vector(matrixD.GetColumn(1)), new Vector(matrixD.GetColumn(2)) };

            Matrix matrixF = new Matrix(vectors);
            Console.WriteLine("Матрица, заданная массивом векторов-строк: F = " + matrixF);

            double determinant = matrixF.GetDeterminant();
            Console.WriteLine("\tопределитель матрицы: detF = " + determinant);

            Console.WriteLine($"\tрезультат умноженная на вектор: F * {vectors[0]} = {matrixF.MultiplyByVector(vectors[0])}");

            matrixD.Add(matrixF);
            Console.WriteLine("\tрезультат сложения с матрицей: D2 = D1 + F = " + matrixD);

            matrixD.Subtract(matrixF);
            Console.WriteLine("\tрезультат вычитания матрицы: D2 - F = " + matrixD);

            matrixF.MultiplyByScalar(determinant);
            Console.WriteLine($"\tрезультат умножения матрицы на скаляр: F * {determinant} = {matrixF}");
        }
    }
}
