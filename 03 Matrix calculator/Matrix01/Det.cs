using System;
using System.Collections.Generic;
using System.Text;


partial class Det
{
    // Метод нахождения детерминанта квадратно матрицы.
    public static void DetFinding(double[][] matrix, int numberOfStrings)
    {
        double det = 1;
        const double EPS = 1E-9;
        double[][] b = new double[1][];
        b[0] = new double[numberOfStrings];
        for (int i = 0; i < numberOfStrings; ++i)
        {

            int k = i;

            for (int j = i + 1; j < numberOfStrings; ++j)

                if (Math.Abs(matrix[j][i]) > Math.Abs(matrix[k][i]))

                    k = j;
            // Если равенство выполняется , то выходим из программы а det=0.
            if (Math.Abs(matrix[k][i]) < EPS)
            {
                det = 0;
                break;
            }
            b[0] = matrix[i];
            matrix[i] = matrix[k];
            matrix[k] = b[0];
            if (i != k)
                det = -det;
            det *= matrix[i][i];
            for (int j = i + 1; j < numberOfStrings; ++j)
                matrix[i][j] /= matrix[i][i];
            for (int j = 0; j < numberOfStrings; ++j)
                // Проверка.
                if ((j != i) && (Math.Abs(matrix[j][i]) > EPS))
                    for (k = i + 1; k < numberOfStrings; ++k)
                        matrix[j][k] -= matrix[i][k] * matrix[j][i];
        }
        //Результат.
        Console.WriteLine(Math.Round(det, 10));
    }
}

