using System;
using System.Collections.Generic;
using System.Text;

partial class NaChislo
{
    public static void Umnozit(double chislo, double[][] matrix, out double[][] matrixResult)
    {
        matrixResult = matrix;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                matrixResult[i][j] = Math.Round(chislo*matrix[i][j]);
            }
        }
        
        
    }
}

