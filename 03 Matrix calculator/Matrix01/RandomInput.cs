using System;
using System.Collections.Generic;
using System.Text;



partial class RandomInput
{
    static Random rnd = new Random();
    // Метод рандомного задания матрицы, на основе объявленных данных(кол-вы строк и столбцов).
    public static void RandomMatrix(out int numberOfStrings, out int numberOfColumns, out double[][] matrix)
    {
        string strNumberOfString;
        string strNumberOfColumns;
        Console.WriteLine(String.Empty);
        // Проверка на корректность.
        do
        {
            Console.Write("Введите количество строк матрицы: ");
            strNumberOfString = Console.ReadLine();
        } while (!int.TryParse(strNumberOfString, out numberOfStrings));

        do
        {
            Console.Write("Ввеедите количество столбцов: ");
            strNumberOfColumns = Console.ReadLine();
        } while (!int.TryParse(strNumberOfColumns, out numberOfColumns));
        int n;
        string m;
        do
        {
            Console.Write("Введите верхнюю границу рандомайза: ");
            m = Console.ReadLine();
        } while (!int.TryParse(m, out n));


        // Вюиение рандомных элементов в матрицу.
        matrix = new double[numberOfStrings][];
        for (int i = 0; i < numberOfStrings; i++)
        {
            double[] elements = new double[numberOfColumns];
            for (int j = 0; j < numberOfColumns; j++)
            {
                elements[j] = rnd.Next(0, n);
            }
            matrix[i] = elements;
        }


    }
}

