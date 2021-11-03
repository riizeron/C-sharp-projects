using System;
using System.Collections.Generic;
using System.Text;


partial class Multiply
{
    // Метод, производящий умножение матриц.
    public static void MatrixMultiply(double[][] matrix1, double[][] matrix2, out double[][] matrixResult)
    {
        // Проверка данных.
        if (matrix1[0].Length != matrix2.Length)
        {
            Console.WriteLine("Ошибка! Кол-во столбцов перво матрицы не совпадает с кол-вом строк второй!");
            Console.WriteLine("Нажмите любую клавишу, чтобы продлжить...");
            Console.ReadKey();
            Program.SwitchMethod();
        }
        // Объявление искомой матрицы.
        matrixResult = new double[matrix1.Length][];
        // Цикл в котором производится подсчет результата произведения.
        for (int i = 0; i < matrix1.Length; i++)
        {
            List<double> listMulti = new List<double>();
            for (int j = 0; j < matrix1[0].Length; j++)
            {
                double k = 0;
                for (int r = 0; r < matrix2.Length; r++)
                {
                    k+=(matrix1[i][r] * matrix2[r][j]);
                }
                listMulti.Add(k);
            }
            matrixResult[i] = listMulti.ToArray();
        }
    }
}

