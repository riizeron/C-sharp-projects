using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


partial class Input
{
    // Метод, в котором осуществляется ввод матрицы с консоли.
    public static void MatrixInput(out int numberOfStrings, out int numberOfColumns, out double[][] matrix)
    {
        string strNumberOfString;
        string strNumberOfColumns;
        Console.WriteLine(String.Empty);
        // Проверка элементов количества строк и столбцов на допустимость.
        do
        {
            Console.Write("Введите количество строк матрицы: ");
            strNumberOfString = Console.ReadLine();
        } while (!int.TryParse(strNumberOfString, out numberOfStrings));
        // Проверка элементов количества строк и столбцов на допустимость.
        do
        {
            Console.Write("Ввеедите количество столбцов: ");
            strNumberOfColumns = Console.ReadLine();
        } while (!int.TryParse(strNumberOfColumns, out numberOfColumns));

        // Объявления заданной матрицы.
        matrix = new double[numberOfStrings][];

        ElementsInput(numberOfStrings, numberOfColumns, ref matrix);


    }
    // Метод, осуществляющий непосредственную вставку элементов, ни их место в матрицу.
    public static void ElementsInput(int stringsAmount, int columnsAmount, ref double[][] matrix)
    {

        Console.WriteLine(Environment.NewLine + "Введите строки матрицы разделяя элементы одной строки пробелом");
        for (int i = 0; i < stringsAmount; i++)
        {
            double[] intString = new double[columnsAmount];
            string[] strElementsOfString;
            // Цикл проверки на правильное введение элементов строки.
            do
            {
                Console.Write($"Ввеите элементы {i + 1} строки: ");
                // В сплите применена функция удаления лишних пробелов.
                strElementsOfString = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            } while (!LenghtCheck(strElementsOfString.Length, columnsAmount)
                      || !ElementsCheck(strElementsOfString, out intString)
                      || (strElementsOfString.Length == 0));
            // Забивка матрицы ее элементами.
            for (int j = 0; j < columnsAmount; j++)
            {
                matrix[i] = intString.ToArray();
            }

        }
    }
    
    // Метод типа bool, проверяющий данный на корректность через возможность их преобразования.
    public static bool DataCheck(string strParam, out double intParam)
    {
        return (double.TryParse(strParam, out intParam));
    }
    // Метод типа bool, проверяющий длину заданной матрицы на корректность.
    public static bool LenghtCheck(int trueLenght, int inputLenght)
    {
        return (trueLenght == inputLenght);
    }
    
    // Метод типа bool, проверяющий каждый элемент матрицы на корректность данных.
    public static bool ElementsCheck(string[] oneString, out double[] intString)
    {
        List<double> intList = new List<double>();
        intString = new double[oneString.Length];
        for (int i = 0; i < oneString.Length; i++)
        {

            if (DataCheck(oneString[i], out double intParam))
            {
                intList.Add(intParam);
            }
            else
            {
                return false;
            }
        }
        intString = intList.ToArray();
        return true;
    }
    // Метод, выводящий матрицы в консоль.
    public static void MatrixOutput(double[][] matrix, int stringsAmount, int columnsAmount)
    {
        for (int i = 0; i < stringsAmount; i++)
        {
            // Проверка списка списков на то, имеет ли он вид матрицы.
            // Осуществляется через проверку длины каждой строки.
            if (!LenghtCheck(matrix[i].Length, columnsAmount))
            {
                Console.WriteLine("Данный массив нельзя вывезти, так как он не является матрицей");
                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
                return;
            }
        }
        Console.WriteLine(String.Empty);
        for (int i = 0; i < stringsAmount; i++)
        {
            for (int j = 0; j < columnsAmount; j++)
            {
                Console.Write(String.Format("{0,3}", matrix[i][j]));
            }
            Console.WriteLine(String.Empty);

        }
    }
}



