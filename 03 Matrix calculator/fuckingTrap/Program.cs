using System;
using System.Collections.Generic;

namespace fuckingTrap
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());


            double[][] matrixX1 = new double[n][];


            double[][] matrixX2 = new double[m][];

            double[,] matrix = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rnd.Next(0, 10);
                }
            }
            for (int i = 0; i < n; i++)
            {
                List<double> list1 = new List<double>();
                for (int j = 0; j < m; j++)
                {
                    list1.Add(matrix[i, j]);
                }
                matrixX1[i] = list1.ToArray();

            }
            double[,] matrixT = new double[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrixT[i, j] = matrix[j, i];
                }
            }
            Console.WriteLine(String.Empty);
            for (int i = 0; i < m; i++)
            {
                List<double> list2 = new List<double>();
                for (int j = 0; j < n; j++)
                {
                    list2.Add(matrixT[i, j]);
                }
                matrixX2[i] = list2.ToArray();

            }
            for (int i = 0; i < n; i++)
            {


                for (int j = 0; j < m; j++)
                {
                    Console.Write(String.Format("{0,3}", matrixX1[i][j]));
                }
                Console.WriteLine(String.Empty);

            }
            Console.WriteLine(String.Empty);
            for (int i = 0; i < m; i++)
            {


                for (int j = 0; j < n; j++)
                {
                    Console.Write(String.Format("{0,3}", matrixX2[i][j]));
                }
                Console.WriteLine(String.Empty);
            }
        }
    }
}
