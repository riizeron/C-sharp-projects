using System;
using System.Collections.Generic;
using System.Text;


partial class Transp
{
    // Метод транспонирования матрицы.
    public static void MatrixTransp(double[][] matrix, out double[][] matrixL2)
    {

        matrixL2 = new double[matrix[0].Length][];

        double[,] matrixA1 = new double[matrix.GetLength(0), matrix[0].Length];
        double[,] matrixA2 = new double[matrix[0].Length, matrix.GetLength(0)];
        matrixA1 = MatrixTransformInArray(matrix, matrixA1);

        for (int i = 0; i < matrix[0].Length; i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                matrixA2[i, j] = matrixA1[j, i];
            }
        }

        matrixL2 = MatrixTransformInLists(matrix, matrixA2, matrixL2);

    }
    //Метод преобразования списка списков в двумерый массив.
    public static double[,] MatrixTransformInArray(double[][] matrix, double[,] matrixA)
    {
        matrixA = new double[matrix.GetLength(0), matrix[0].Length];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            double[] arr1 = new double[matrix[0].Length];

            arr1 = matrix[i];
            for (int j = 0; j < matrix[0].Length; j++)
            {
                matrixA[i, j] = arr1[j];

            }
        }
        return matrixA;

    }

    // Метод преобразования двумерного массива в список списков.
    public static double[][] MatrixTransformInLists(double[][] matrix, double[,] matrixA, double[][] matrixL)
    {
        matrixL = new double[matrixA.GetLength(0)][];
        for (int i = 0; i < matrixA.GetLength(0); i++)
        {
            List<double> list1 = new List<double>();
            for (int j = 0; j < matrixA.GetLength(1); j++)
            {
                list1.Add(matrixA[i, j]);
            }
            matrixL[i] = list1.ToArray();

        }
        return matrixL;

    }
}


