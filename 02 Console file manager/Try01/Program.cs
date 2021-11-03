using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Класс глобальных переменных, обеспечивающий доступ к ним в любом фрагменте кода.
public static class Globals
{
    public static string nameOfCopyFile;
    public static string pathOfCopyFile;
    public static int flag = 1;
    public static string separator;

}
class Program
{
    static void Main()
    {
        // Опознавание операционной системы в которой запускается программа.
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Globals.separator = @"\";
        }
        else
        {
            Globals.separator = @"/";
        }
        Console.WriteLine("\t\t КОНСОЛЬНЫЙ ПРОВОДНИК" + Environment.NewLine);
        Console.WriteLine("Нажмите 'Enter', чтобы начать");
        Console.WriteLine("Нажмите 'Escape, чтобы выйти");
        Console.Write(": ");

        FirstOfAllChoice();
        Console.WriteLine(String.Empty);
    }

    // Метод для получения списка дисков через цикл.
    public static string[] AllDisksOverview()
    {
        string[] Drives = Environment.GetLogicalDrives();
        return Drives;
    }

    // Метод выбора диска.
    public static void DiskChoose()
    {
        Console.Write("Выберите диск (укажите цифру):");
        string yourChoice = Console.ReadLine();
        string nameOfDisk = "";
        for (int i = 0; i < AllDisksOverview().Length; i++)
        {
            if (int.Parse(yourChoice) == (i + 1))
            {
                nameOfDisk = AllDisksOverview()[i];
            }
        }
        Console.WriteLine("Вы выбрали диск: " + nameOfDisk);
    }

    /* Метод через который обеспечивается функционал перемещения между репозиториями. 
     * А так же он возвращает все папки и файлы текущего каталога.
     * К тому же в этом методе осуществляется вызов метода выбора действия.
     * Этот метод вызывается практически в каждом другом методе,
     * чтобы выводить текущее местоположение, файлы и папки после каждого действия.
     */
    public static void Jump()
    {
        Console.WriteLine("Вы находитесь в каталоге: {0}", Directory.GetCurrentDirectory() + Environment.NewLine);
        Console.WriteLine("Вот содержимое этого каталога: " + Environment.NewLine);
        OutputFolders();
        OutputFiles();
        Console.Write("Так что вы хотите сделать: ");

        ActChoice();
    }

    // Метод выводящий папки каталога.
    public static void OutputFolders()
    {
        Console.WriteLine("папки: ");
        string[] directories = Directory.GetDirectories(Directory.GetCurrentDirectory());
        foreach (string v in directories)
        {
            Console.WriteLine(Path.GetFileName(v));
        }
        Console.WriteLine();
    }

    // Метод выводящий файлы каталога.
    public static void OutputFiles()
    {
        Console.WriteLine("файлы: ");
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
        foreach (string v in files)
        {
            Console.WriteLine(Path.GetFileName(v));
        }
        Console.WriteLine();
    }

    // Метод вывода списка дисков.
    public static void AllDiskOutput(string[] allDisks)
    {
        for (int i = 0; i < allDisks.Length; i++)
        {
            Console.WriteLine(allDisks[i]);
        }
    }

    // Метод, обеспечивающий функционал перемещения на каталог вниз.
    public static void DownChoice()
    {
        Console.Write("Введите название папки желаемой для перемещения: ");
        string desireFolder = Console.ReadLine();
        try
        {
            string desireDestination = (Directory.GetCurrentDirectory() + Globals.separator + desireFolder);
            Directory.SetCurrentDirectory(desireDestination);
            Console.Clear();
        }
        catch (Exception ex)
        {
            Console.WriteLine(String.Empty);
            Console.WriteLine(ex.Message);
            Console.WriteLine(String.Empty);
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("ОШИБКА! ПЕРЕМЕЩЕНИЕ В ЭТОТ ПОДКАТАЛОГ НЕВОЗМОЖНО ТАК КАК ЕГО НЕ СУЩЕСТВУЕТ В ЭТОМ КАТАЛОГЕ\a"
                              + Environment.NewLine);
        }
        Jump();
    }

    // Метод, обеспечивающий функционал перемещения на каталог вверх.
    public static void UpChoice()
    {
        try
        {
            Console.Clear();
            string path = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            Directory.SetCurrentDirectory(path);
        }
        catch (Exception)
        {
            Console.Clear();
            RootChoice();
        }
        Jump();
    }

    // Метод, обеспечивающий вывод корневых дисков и перемещение в один из них.
    public static void RootChoice()
    {
        Console.Clear();
        Console.WriteLine("Вы находитесь в корневом каталоге" + Environment.NewLine);
        Console.WriteLine("Вот список доступных дисков: ");
        AllDiskOutput(AllDisksOverview());
        Console.WriteLine(String.Empty);
        Console.Write("Введите имя диска: ");
        string nameOfDisk = Console.ReadLine();
        string[] someDisks = Environment.GetLogicalDrives();
        bool flag = false;
        // Проверка диска на существование.
        foreach (string v in someDisks)
        {
            if (v == nameOfDisk + @":" + Globals.separator)
            {
                flag = true;
            }
        }
        if (flag == true)
        {
            Directory.SetCurrentDirectory(nameOfDisk + @":" + Globals.separator);
            Console.Clear();
            Jump();
        }
        else
        {
            Console.WriteLine("ОШИБКА! Введенного диска не существует! Нажмите любою клавишу чтобы повторить ввод.");
            Console.ReadKey();
            RootChoice();
        }
        Directory.SetCurrentDirectory(Console.ReadLine() + @":" + Globals.separator);
        Console.Clear();
        Jump();
    }

    // Метод, выводящий список подсказок.
    public static void Help()
    {
        Console.Clear();
        Console.WriteLine("\t\tСПРАВКА!!!");
        Console.WriteLine(String.Empty);
        Console.WriteLine("'up'\t\t-\tперемещение в каталог выше");
        Console.WriteLine("'down'\t\t-\tперемещение в каталог ниже");
        Console.WriteLine("'root'\t\t-\tперемещение в корневой каталог");
        Console.WriteLine("'open'\t\t-\tоткрыть текстовый файл");
        Console.WriteLine("'help'\t\t-\tвызов справки");
        Console.WriteLine("'copy'\t\t-\tкопирование файла");
        Console.WriteLine("'move'\t\t-\tвырезание файла");
        Console.WriteLine("'paste'\t\t-\tвставка файла");
        Console.WriteLine("'create'\t-\tсоздание текстового файла");
        Console.WriteLine("'concatination'\t-\tконкатенация двух файлов");
        Console.WriteLine("'exit'\t\t-\tвыход из программы");
        Console.WriteLine(String.Empty);
        ChooseHelp();
    }

    // Метод, обеспечивающий функционал выбора функции вывода подсказок.
    public static void ChooseHelp()
    {
        Console.WriteLine("Если вы хотите узнать информацию о возможных действиях введите 'help'");
        Console.WriteLine("Если вы уже ознакомлены с возможностями приложения введите 'continue'" + Environment.NewLine);
        Console.Write("Так что вы выберите: ");
        string helpOrContinueChoice = Console.ReadLine();
        Console.Clear();
        switch (helpOrContinueChoice)
        {
            case "help":
                Help();
                ChooseHelp();
                break;

            case "continue":
                Jump();
                break;

            case "exit":
                ExitChoice();
                break;

            default:
                Console.Write("Ошибка ввода!" + Environment.NewLine);
                ChooseHelp();
                break;
        }
    }

    // Метод, обеспечивающий первоначальный выбор.
    public static void FirstOfAllChoice()
    {
        ConsoleKeyInfo t;

        /* Цикл для считывания клавиш Enter и ESC.
         * Он нужен для того чтобы программа не реагировала на нажатия остальных клавиш.
         */
        do
        {
            t = (Console.ReadKey(true));
        } while ((t.Key.ToString() != "Escape") & (t.Key.ToString() != "Enter"));

        switch (t.Key.ToString())
        {
            case "Enter":
                Console.Clear();
                ChooseHelp();
                break;
            case "Escape":
                Environment.Exit(0);
                break;
        }
    }

    // Метод, обеспечивающий выбор действия.
    public static void ActChoice()
    {
        string upOrDown = Console.ReadLine();
        Console.WriteLine(String.Empty);

        switch (upOrDown)
        {
            case "up":
                UpChoice();
                break;

            case "down":
                DownChoice();
                break;

            case "root":
                RootChoice();
                break;

            case "help":
                Help();
                break;

            case "open":
                TextFileOpen();
                break;

            case "copy":
                CopyCase();
                break;

            case "paste":
                PasteCase();
                break;

            case "move":
                MoveCase();
                break;

            case "delete":
                DeleteCase();
                break;

            case "create":
                FileCreation();
                break;

            case "concatination":
                Concatination();
                break;

            case "count":
                Splitss();
                break;

            case "exit":
                ExitChoice();
                break;

            default:
                Console.Write("Ошибка! Введите команду корректно!" + Environment.NewLine
                                + "Введите корректную команду или введите 'help', чтобы ознакомиться с ними: ");
                ActChoice();
                break;
        }
    }

    // Метод, спрашивающий имя файла, желаемого к открытию.
    // Так же тут происходит вызов метода выбора кодировки и вывода текста.
    public static void TextFileOpen()
    {
        Console.Write("Содержимое какого текстого файли вы хотите вывести в консоль: ");
        string nameOfTextFile = Console.ReadLine();

        CodeChoice(nameOfTextFile);
    }

    // Метод, обеспечивающий функционал выбора кодировки и вывода текста в консоль.
    public static void CodeChoice(string nameOfTextFile)
    {
        Console.WriteLine("Список доступных кодировок для вывода: ");
        Console.WriteLine("1) UTF-8" + Environment.NewLine +
                          "2) ASCII" + Environment.NewLine +
                          "3) Default" + Environment.NewLine +
                          "4) Unicode" + Environment.NewLine);
        Console.Write("В какой кодировке из следующих вы хотите вывести тестовый файл: ");

        string codeOfTextFile = Console.ReadLine();
        // Проверка файла на существование.
        try
        {
            switch (codeOfTextFile)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine(File.ReadAllText(nameOfTextFile, System.Text.Encoding.UTF8));
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine(File.ReadAllText(nameOfTextFile, System.Text.Encoding.ASCII));
                    break;

                case "3":
                    Console.Clear();
                    Console.WriteLine(File.ReadAllText(nameOfTextFile, System.Text.Encoding.Default));
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine(File.ReadAllText(nameOfTextFile, System.Text.Encoding.UTF32));
                    break;

                default:
                    Console.Clear();
                    Console.Write("Ошибка! Выберите кодировку корректно!" + Environment.NewLine + "Введите кодировку: ");
                    CodeChoice(nameOfTextFile);
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        AfterFileOpen();
    }

    // Метод, осуществляющий функционал после вывода текста файла в консоль.
    public static void AfterFileOpen()
    {
        Console.WriteLine(String.Empty);
        Console.WriteLine("Чтобы продолжить нажмите любую клавишу");
        Console.ReadKey();
        Console.Clear();
        Jump();
    }

    // Метод, осуществляющий функционал копирования файла.
    // Но на деле он лишь сохраняет в переменную имя файла желаемого для копирования.
    public static void CopyCase()
    {
        Console.Write("Введите имя файли который вы хотите копировать: ");
        Globals.nameOfCopyFile = Console.ReadLine();
        if (File.Exists(Globals.nameOfCopyFile))
        {
            Console.Clear();
            Console.WriteLine("ФАЙЛ СКОПИРОВАН!\a" + Environment.NewLine);
            Globals.pathOfCopyFile = Path.GetFullPath(Globals.nameOfCopyFile);
            Globals.flag = 1;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("КОПИРОВАНИЕ ФАЙЛА НЕВОЗМОЖНО ТАК КАК ОН ОТСУТСТВУЕТ В ЭТОМ КАТАЛОГЕ!\a"
                              + Environment.NewLine);
        }
        Jump();
    }

    // Метод, выполняющий функцию вставки файла.
    public static void PasteCase()
    {
        try
        {
            File.Copy(Globals.pathOfCopyFile, Directory.GetCurrentDirectory() + Globals.separator + Globals.nameOfCopyFile);
            Console.Clear();
            Console.WriteLine("ФАЙЛ ВСТАВЛЕН!\a" + Environment.NewLine);
            if (Globals.flag == 0)
            {
                File.Delete(Globals.pathOfCopyFile);
            }
        }
        catch (Exception)
        {
            Console.Clear();
            Console.WriteLine("ВСТАВКА ФАЙЛА НЕВОЗМОЖНА ТАК КАК ОН УЖЕ СУЩЕСТВУЕТ В ЭТОМ КАТАЛОГЕ!\a"
                              + Environment.NewLine);
        }
        Jump();
    }

    // Метод, выполняющий функцию удаления файла.
    public static void DeleteCase()
    {
        Console.Write("Введите имя файли, который вы хотите удалить: ");
        string nameOfDeleteFile = Console.ReadLine();
        if (File.Exists(nameOfDeleteFile))
        {
            File.Delete(nameOfDeleteFile);
            Console.Clear();
            Console.WriteLine("ФАЙЛ УДАЛЕН!\a" + Environment.NewLine);

        }
        else
        {
            Console.Clear();
            Console.WriteLine("УДАЛЕНИЕ ФАЙЛА НЕВОЗМОЖНО ТАК КАК ЕГО НЕ СУЩЕСТВУЕТ В ЭТОМ КАТАЛОГЕ!\a"
                              + Environment.NewLine);

        }
        Jump();
    }

    // Метод, осуществляющий функционал перемещения файла.
    // Но на деле он лишь сохраняет в переменную имя файла желаемого для перемещения.
    public static void MoveCase()
    {
        Console.Write("Введите имя файли который вы хотите вырезать: ");
        Globals.nameOfCopyFile = Console.ReadLine();
        if (File.Exists(Globals.nameOfCopyFile))
        {
            Console.Clear();
            Console.WriteLine("ФАЙЛ ВЫРЕЗАН!\a" + Environment.NewLine);
            Globals.pathOfCopyFile = Path.GetFullPath(Globals.nameOfCopyFile);
            // Флаг изменил свое значение, а значит последней была вызвана функция перемещения.
            Globals.flag = 0;
        }
        else
        {
            Console.Clear();
            Console.WriteLine("ВЫРЕЗАНИЕ ФАЙЛА НЕВОЗМОЖНО ТАК КАК ОН ОТСУТСТВУЕТ В ЭТОМ КАТАЛОГЕ!\a"
                              + Environment.NewLine);
        }
        Jump();
    }

    // Метод, обеспечивающий функционал создания текстового файла. 
    // В данном методе осуществляется создание списка из строк, который потом будет записан в файл.
    public static void FileCreation()
    {
        Console.Write("Введите имя нового текстового файла (расширение указывать не нужно): ");
        string nameOfNewFile = Console.ReadLine();

        Console.Clear();
        string pathOfNewFile = (Directory.GetCurrentDirectory() + Globals.separator + nameOfNewFile + ".txt");
        Console.WriteLine("Введите содержимое файла: (чтобы остановить запись введите с новой строки 'ExPo!')");

        List<string> listOfStrings = new List<string>();
        string listAppend;
        // Данный цикл предназначен для ввода угодного количества строк в список.
        // Его заполнение прекращается при ввода с новой строки 'ExPo!'.
        do
        {
            listAppend = Console.ReadLine();
            listOfStrings.Add(listAppend);
        } while (listAppend != "ExPo!");

        listOfStrings.Remove("ExPo!");
        FileAppend(pathOfNewFile, listOfStrings);
        AfterFileCreation(nameOfNewFile);
    }

    // Метод, осуществляющий функционал после создания текстового файла.
    public static void AfterFileCreation(string name)
    {
        Console.WriteLine("ФАЙЛ СОЗДАН!\a");
        Console.WriteLine(String.Empty);
        Jump();

    }

    /* Метод, обеспечивающий функционал выбора кодировки записи
     * и запись созданного списка в файл 
     * в выбранной кодировке
     */
    public static void FileAppend(string pathOfNewFile, List<string> listOfStrings)
    {
        Console.Clear();
        Console.WriteLine("В какой кодировке из предложенных вы бы хотели записать этот файл?");
        Console.WriteLine("1) UTF-8" + Environment.NewLine +
                         "2) ASCII" + Environment.NewLine +
                         "3) Default" + Environment.NewLine +
                         "4) Unicode" + Environment.NewLine);
        Console.Write("В какой кодировке из следующих вы хотите ввести тестовый файл: ");
        string codeOfNewFile = Console.ReadLine();
        switch (codeOfNewFile)
        {
            case "1":
                File.AppendAllLines(pathOfNewFile, listOfStrings, Encoding.UTF8);
                break;
            case "2":
                File.AppendAllLines(pathOfNewFile, listOfStrings, Encoding.ASCII);
                break;
            case "3":
                File.AppendAllLines(pathOfNewFile, listOfStrings, Encoding.Default);
                break;
            case "4":
                File.AppendAllLines(pathOfNewFile, listOfStrings, Encoding.Unicode);
                break;
            default:
                Console.Clear();
                Console.Write("Ошибка! Выберите кодировку корректно!" + Environment.NewLine + "Введите кодировку: ");

                FileAppend(pathOfNewFile, listOfStrings);
                break;

        }
        Console.Clear();


    }

    /* Метод, осуществляющий конкатенацию двух текстовых файлов
     * и вывод полученного результата в консоль
     */
    public static void Concatination()
    {

        Console.Write("Введите имя первого файла: ");
        string firstOfNames = Console.ReadLine();
        Console.Write("Введите имя второго файла: ");
        string secondOfNames = Console.ReadLine();
        Console.Write("Введите имя файла результата: ");
        string resultFileName = Console.ReadLine();

        try
        {
            File.WriteAllLines(resultFileName, File.ReadAllLines(firstOfNames));
            File.AppendAllLines(resultFileName, File.ReadAllLines(secondOfNames));
            Console.Clear();
            Console.WriteLine("РЕЗУЛЬТАТ КОНКАТЕНАЦИИ:" + Environment.NewLine);
            Console.WriteLine(File.ReadAllText(resultFileName));
            Console.WriteLine(String.Empty);
            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(String.Empty);
            Console.WriteLine("ОШИБКА\a!Введите корректные данные!" + Environment.NewLine);
            Concatination();

        }
        Console.Clear();
        Console.WriteLine("КОНКАТЕНАЦИЯ ПРОИЗВЕДЕНА!\a и записана в файл: " + resultFileName);
        Jump();
    }

    // Метод, осуществляющий функционал выхода из программы.
    public static void ExitChoice()
    {
        Console.Clear();
        Console.WriteLine("Вы точно хотите выйти?");
        Console.WriteLine("yes\tno");
        Console.Write(Environment.NewLine + ":");
        string exitChoice = Console.ReadLine();
        switch (exitChoice)
        {
            case "yes":
                Environment.Exit(0);
                break;
            case "no":
                Jump();
                break;
            default:
                Console.WriteLine("ОШИБКА!\aВведите корректный выбор!");
                ExitChoice();
                break;
        }
    }
    public static void Splitss()
    {
        Console.Write("Введите имя файла: ");
        string nameOfSplitFile = Console.ReadLine();
        string[] Separators = { " ", ". ", ", ", "? ", "! ", ": ", "; " };
        int charsCount = 0;
        int wordsCount = 0;
        string[] a = File.ReadAllLines(nameOfSplitFile);
        Console.Clear();
        foreach(string v in a)
        {
            Console.WriteLine(v);
        }
        int linesCount = a.Length;
        foreach (string v in a)
        {
            charsCount += v.Length;
            string[] mystring = v.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
            wordsCount += mystring.Length;
        }
        Console.WriteLine(String.Empty);
        Console.WriteLine("Число строк:\t "+linesCount);
        Console.WriteLine("Число слов:\t "+wordsCount);
        Console.WriteLine("Число симоволов:\t "+charsCount);
    }
}




