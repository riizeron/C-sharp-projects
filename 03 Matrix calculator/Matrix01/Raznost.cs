using System;
using System.Collections.Generic;
using System.Text;


partial class Raznost
{
    public static void MatrixRaznost(double[][] matrix1, double[][] matrix2, ref double[][] matrixS, int numberOfStrings, int numberOfColumns)
    {


        if ((matrix1.GetLength(0) != matrix2.GetLength(0)) || (matrix1[0].Length != matrix2[0].Length))
        {
            Console.WriteLine(Environment.NewLine + "Данные матрицы не подходят");
            Console.WriteLine("Кол-во их строк и столбцов не идентично");
            Console.WriteLine("Чтобы продолжить нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
            Program.SwitchMethod();
        }
        else
        {

            for (int i = 0; i < numberOfStrings; i++)
            {
                double[] elements1 = matrix1[i];
                double[] elements2 = matrix2[i];
                double[] elementsS = new double[numberOfColumns];
                for (int j = 0; j < numberOfColumns; j++)
                {

                    elementsS[j] = elements1[j] - elements2[j];
                }
                matrixS[i] = elementsS;
            }
        }

    }
}
