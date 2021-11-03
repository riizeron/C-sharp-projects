using System;
using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

partial class Program
{
    static void Main()
    {
        Console.WriteLine("\tПриветствую вас в калькуляторе матриц!!!");
        Console.WriteLine("Нажмите  ENTER чтобы начать или ESC для выхода");
        CalcStarting();
        Help();
        SwitchMethod();
    }

    public static void CalcStarting()
    {


        ConsoleKeyInfo t;

        /* Цикл для считывания клавиш Enter и ESC.
         * Он нужен для того чтобы программа не реагировала на нажатия остальных клавиш.
         */
        do
        {
            t = (Console.ReadKey(true));
        } while ((t.Key.ToString() != "Escape") & (t.Key.ToString() != "Enter"));
        // Если нажат Enter то программа продолжится.
        // Если нажат Esc то программа завершится.
        switch (t.Key.ToString())
        {
            case "Enter":
                Console.Clear();

                break;
            case "Escape":
                Console.WriteLine(Environment.NewLine + "Выходддюю........");
                Environment.Exit(0);
                break;
        }

    }
    // Метод, через который пользователь выбирает тип задания матрицы.
    public static void SwitchCase(out int numberOfStrings, out int numberOfColumns, out double[][] matrix)
    {
        numberOfStrings = 0;
        numberOfColumns = 0;
        Console.WriteLine(String.Empty);
        // Текстовая справка.
        Console.WriteLine("Варианты задания матриц:");
        Console.WriteLine("\t1. Ввод с консоли" + Environment.NewLine +
            "\t2. Вывод из файла" + Environment.NewLine +
            "\t3. Случайная матрица"+Environment.NewLine);
        Console.Write("Введите номер варианта задания матрицы из предложенных: ");
        
        string x = Console.ReadLine();
        // Разбор различных случаев.
        switch (x)
        {
            case "1":
                Input.MatrixInput(out numberOfStrings, out numberOfColumns, out matrix);
                break;
            case "2":
                FileInput.ElementsFileInput(out numberOfStrings, out numberOfColumns, out matrix);
                break;
            case "3":
                RandomInput.RandomMatrix(out numberOfStrings, out numberOfColumns, out matrix);
                break;
            case "exit":
                matrix = new double[1][];
                Console.WriteLine(String.Empty);
                Console.WriteLine("Завершение программы...");
                Environment.Exit(0);
                break;
            default:
                matrix = new double[1][];
                Console.WriteLine("ОШИБКА! Введите корректные данные" + Environment.NewLine);
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.Write("...");
                SwitchCase(out numberOfStrings, out numberOfColumns, out matrix);
                break;
        }
    }
    // Метод, позволяющий выбрать в какой момент закончить программу.
    public static void Continue()
    {
        Console.WriteLine(Environment.NewLine + "Желаете продолжить?");
        Console.WriteLine("Нажмите ENTER для продолжения или ESC для выхода");
        CalcStarting();
        SwitchMethod();

    }
    // Метод, обеспечивающий функционал выбора желаемого действия с матрицей.
    public static void SwitchMethod()
    {
        Console.Write("Введите номер пункта: ");
        
        string x = Console.ReadLine();
        switch (x)
        {
            case "1":
                CaseSled();
                break;
            case "2":
                CaseTrans();
                break;
            case "3":
                CaseSum();
                break;
            case "4":
                CaseRaznost();
                break;
            case "5":
                CaseMultiply();
                break;
            case "6":
                CaseUmnozenieNaChislo();
                break;
            case "7":
                CaseDet();
                break;
            case "help":
                Help();
                break;
            case "exit":
                Console.WriteLine(String.Empty);
                Console.WriteLine("Завершение программы...");
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("ОШИБКА! Введите корректные данные" + Environment.NewLine);
                Console.WriteLine("Нажмите любую клавишу для продолжения");
                Console.Write("...");
                SwitchMethod();
                break;
        }
        Continue();
    }

    /* Давлее идут методы, вызывающиеся из метода CaseMethod
     * в зависимости от выбора пользователя.
     * Каждый из них предельно прост.
     * Декомпозиция применялась здесь для уменьшения количества строк в одном методе
     * и для более изящного вида программы.
     */
    public static void CaseSled()
    {
        
        Console.WriteLine("Для данного пункта необходима квадратная матрица!");
        SwitchCase(out int numberOfStrings, out int numberOfColumns, out double[][] matrix);
        if (numberOfColumns != numberOfStrings)
        {
            Console.WriteLine(Environment.NewLine + "ОШИБКА! Матрица не квадратная.");
            Console.WriteLine("Чтобы попробовать снова нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
            SwitchMethod();
        }
        else
        {
            Console.WriteLine("Исходная матрица: ");
            Input.MatrixOutput(matrix, numberOfStrings, numberOfColumns);
            Console.Write(Environment.NewLine + "Ее след равен: ");
            Sled.SledFinding(matrix, numberOfStrings);
        }
    }

    public static void CaseTrans()
    {
        SwitchCase(out int numberOfStrings, out int numberOfColumns, out double[][] matrix);
        Console.WriteLine("Исходная матрица: ");
        Input.MatrixOutput(matrix, numberOfStrings, numberOfColumns);
        Console.WriteLine(String.Empty);

        double[][] matrixT = new double[matrix[0].Length][];
        Console.WriteLine("Транспонированная матрица");
        Transp.MatrixTransp(matrix, out matrixT);
        Input.MatrixOutput(matrixT, matrix[0].Length, matrix.GetLength(0));
    }

    public static void CaseSum()
    {
        Console.WriteLine("Для данного пункта необходимы две одинноаковые по размеру матрицы");
        double[][] matrix1;
        double[][] matrix2;

        Console.WriteLine(Environment.NewLine + "Задайте первую матрицу" + Environment.NewLine);
        SwitchCase(out int numberOfStrings, out int numberOfColumns, out matrix1);
        Console.WriteLine(Environment.NewLine + "Задайте вторую матрицу" + Environment.NewLine);
        SwitchCase(out numberOfStrings, out numberOfColumns, out matrix2);
        double[][] matrixS = new double[numberOfStrings][];
        Sum.MatrixSum(matrix1, matrix2, ref matrixS, numberOfStrings, numberOfStrings);
        Console.WriteLine(Environment.NewLine + "Их сумма равна: ");
        Input.MatrixOutput(matrixS, numberOfStrings, numberOfColumns);
    }
    public static void CaseRaznost()
    {
        Console.WriteLine("Для данного пункта необходимы две одинноаковые по размеру матрицы");
        Console.WriteLine(Environment.NewLine + "Задайте первую матрицу" + Environment.NewLine);
        SwitchCase(out int numberOfStrings, out int numberOfColumns, out double[][] matrix1);
        Console.WriteLine(Environment.NewLine + "Задайте вторую матрицу" + Environment.NewLine);
        SwitchCase(out numberOfStrings, out numberOfColumns, out double[][] matrix2);
        double[][] matrixR = new double[numberOfStrings][];
        Raznost.MatrixRaznost(matrix1, matrix2, ref matrixR, numberOfStrings, numberOfStrings);
        Console.WriteLine(Environment.NewLine + "Их разность равна: ");
        Input.MatrixOutput(matrixR, numberOfStrings, numberOfColumns);
    }

    public static void CaseMultiply()
    {
        Console.WriteLine("Для данного пункта необходимы две матрицы");
        Console.WriteLine("Причем количество стобцов первой равно количеству строк второй");


        Console.WriteLine(Environment.NewLine + "Задайте первую матрицу" + Environment.NewLine);
        SwitchCase(out int numberOfStrings, out int numberOfColumns, out double[][] matrix1);
        Console.WriteLine(Environment.NewLine + "Задайте вторую матрицу" + Environment.NewLine);
        SwitchCase(out numberOfStrings, out numberOfColumns, out double[][] matrix2);
        double[][] matrixMultiplyResult;
        Multiply.MatrixMultiply(matrix1, matrix2, out matrixMultiplyResult);
        Console.WriteLine(Environment.NewLine + "Их произведение равно: ");
        Input.MatrixOutput(matrixMultiplyResult, matrixMultiplyResult.Length, matrixMultiplyResult[0].Length);

    }

    public static void CaseUmnozenieNaChislo()
    {
        double[][] matrixResult;
        double chislo;
        string strChislo;
        Console.WriteLine(String.Empty);
        SwitchCase(out int numberOfStrings, out int numberOfColumns, out double[][] matrix);
        do
        {
            Console.Write(Environment.NewLine + "Введите корректное число на которое вы хотите умножить матрицу: ");
            strChislo = Console.ReadLine();

        } while (!Input.DataCheck(strChislo, out chislo));
        Console.WriteLine(Environment.NewLine + "Исходная матрица: ");
        Input.MatrixOutput(matrix, matrix.Length, matrix[0].Length);
        NaChislo.Umnozit(chislo, matrix, out matrixResult);
        Console.WriteLine(Environment.NewLine + "Полученная в результате матрица: ");
        Input.MatrixOutput(matrixResult, matrixResult.Length, matrixResult[0].Length);
    }
    public static void CaseDet()
    {
        Console.WriteLine("Для данного пункта необходима квадратная матрица!"+Environment.NewLine);
        SwitchCase(out int numberOfStrings, out int numberOfColumns, out double[][] matrix);
        if (numberOfColumns != numberOfStrings)
        {
            Console.WriteLine(Environment.NewLine + "ОШИБКА! Матрица не квадратная.");
            Console.WriteLine("Чтобы попробовать снова нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
            SwitchMethod();
        }
        else
        {
            Console.WriteLine("Исходная матрица: ");
            Input.MatrixOutput(matrix, numberOfStrings, numberOfColumns);
            Console.Write(Environment.NewLine+"Ее определитель равен: ");
            Det.DetFinding(matrix, numberOfStrings);
        }

    }

    // Метод вызова справки.
    public static void Help()
    {
        Console.WriteLine("Алгоритм работы приложения:" +Environment.NewLine+Environment.NewLine+
            "В начале работы программы пользователь выбирает операцию, которую" +Environment.NewLine+
            "хочет выполнить. Среди доступных операций присутстуют:" +Environment.NewLine+
            "\t1. нахождение следа матрицы;" +Environment.NewLine+
            "\t2. транспонирование матрицы;" +Environment.NewLine+
            "\t3. сумма двух матриц;" +Environment.NewLine+
            "\t4. разность двух матриц;" +Environment.NewLine+
            "\t5. произведение двух матриц;" +Environment.NewLine+
            "\t6. умножение матрицы на число;" +Environment.NewLine+
            "\t7. нахождение определителя матрицы." +Environment.NewLine+Environment.NewLine+
            "\t exit - выход из программы" +Environment.NewLine+
            "\t help - вызов этой справки");
        Console.WriteLine(Environment.NewLine + "Данную подсказку всегда можно будет вывести во время выбора методов, о которых она информирует");
        Console.WriteLine(Environment.NewLine + "Нажмите любую клавишу, если вы хотите продолжить...");
        Console.ReadKey();
        Console.Clear();

    }
   
}

