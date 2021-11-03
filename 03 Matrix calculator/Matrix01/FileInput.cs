using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

partial class FileInput
{
    // Метод, считывающий матрицу из фала, путь к которому прямиком укажет пользователь.
    public static void ElementsFileInput(out int stringsAmount, out int columnsAmount, out double[][] matrix)
    {
        // Поимка эксешенов.
        try
        {
            Console.WriteLine("Введите полный путь до нужного файла:");
            string path = Console.ReadLine();
            // Считывание всех строк текстового файла.
            string[] stringMatrix = File.ReadAllLines(path);
            columnsAmount = stringMatrix[0].Split().Length;
            stringsAmount = stringMatrix.Length;
            matrix = new double[stringsAmount][];
            int i = 0;
            foreach (string v in stringMatrix)
            {
                // В сплите объявлены функция пропускания пробелов.
                string[] strElementsOfString = v.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                double[] intString;
                // Проверка на коррекность.
                if ((Input.ElementsCheck(strElementsOfString, out intString)) && (Input.LenghtCheck(strElementsOfString.Length, columnsAmount)))
                {
                    for (int j = 0; j < columnsAmount; j++)
                    {
                        matrix[i] = intString;
                    }
                }
                else
                {
                    Console.WriteLine(Environment.NewLine + "ОШИБКА! Данные файла некорректны!");
                    Console.WriteLine("Нажмите любую клавишу для возвращения к выбору");
                    Console.ReadKey();
                    Console.Clear();
                    Program.SwitchMethod();
                }
                i++;
            }

        }catch(Exception ex)
        {
            matrix = new double[1][];
            stringsAmount = 0;
            columnsAmount = 0;

            Console.WriteLine(ex.Message);
            Program.Continue();
        }
    }
}



