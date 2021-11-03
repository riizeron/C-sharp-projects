using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace Warehouse
{
    class Program
    {
        /// <summary>
        /// Объекты классов и рандомайзер.
        /// </summary>
        public static Storage depot;
        public static Boxes[][] boxes;
        public static List<Containers> containersList;
        static Random rnd = new Random();
        /// <summary>
        /// Основной метод программы. 
        /// </summary>
        static void Main()
        {
            // Это не должно пригодиться, но это на всякий случай.
            try
            {
            // Вызов стартового метода выбора запуска или выхода из программы.
            StartChoice();
            Console.Clear();
            // Предоставление пользоватеелю выбора ввода информации.
            // Через файл либо через ввод с консоли.
            ConsoleOrTextFileChoice();
            }
            catch (Exception ex)
            {
            Console.WriteLine(String.Empty + Environment.NewLine);
            Console.WriteLine(ex.Message);
            Console.WriteLine(String.Empty + Environment.NewLine);
            Console.WriteLine("Что-то в ходе программы пошло не так...");
            Console.WriteLine("Пожалуйста не расстраивайтесь и не расстраивайте меня(((");
            Console.Write("Нажмите любую клавишу, чтобы попробовать снова...");
            Console.ReadKey();
            Console.Clear();
            Main();
            }
        }
        /// <summary>
        /// Метод выбора между наалом работы или завершение программы.
        /// </summary>
        public static void StartChoice()
        {
            Console.WriteLine(String.Empty + Environment.NewLine);
            Console.WriteLine(String.Empty + Environment.NewLine);
            Console.WriteLine(String.Empty + Environment.NewLine);
            Console.WriteLine(String.Empty);
            Console.WriteLine("\t\t\t\tПРИВЕТСТВУЮ ВАС НА СКЛАДЕ ОВОЩЕЙ !!! ");
            Console.WriteLine(String.Empty + Environment.NewLine);
            Console.WriteLine(String.Empty);
            Console.WriteLine("\t\t\t\t\tЖелаете начать рабоу?");
            Console.WriteLine(Environment.NewLine + "\t\t\tНажмие 'Enter', чтобы начать или 'ESC', чтобы выйти");
            Console.Write("\t\t\t\t\t\t...");

            ConsoleKeyInfo keyPressed;

            do
            // Цикл для считывания клавиш Enter и ESC.
            // Он нужен для того чтобы программа не реагировала на нажатия остальных клавиш.
            {
                keyPressed = (Console.ReadKey(true));
            } while ((keyPressed.Key.ToString() != "Escape") & (keyPressed.Key.ToString() != "Enter"));

            if (keyPressed.Key.ToString() == "Escape")
            {
                CloseProgramm();
            }
            else
            {
                Console.Clear();
                Console.WriteLine(String.Empty + Environment.NewLine);
                Console.WriteLine(String.Empty + Environment.NewLine);
                Console.WriteLine(String.Empty + Environment.NewLine);
                Console.WriteLine("\t\t\t\t\tСоздается склад...Подождите..." + Environment.NewLine);
                // Красивая анимация.
                for (int i = 120; i > -1; i--)
                {
                    Thread.Sleep(8);
                    Console.Write("x");
                }
            }
        }
        /// <summary>
        /// Метод, осуществляющих красивый выход из программы.
        /// </summary>
        public static void CloseProgramm()
        {
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine("\t\t\t\t\tЗАВЕРШЕНИЕ РАБОТЫ...");
            Console.WriteLine(String.Empty);
            for (int i = 120; i > -1; i--)
            {
                Thread.Sleep(10);
                Console.Write('x');

            }
            Console.WriteLine(String.Empty);
            Environment.Exit(0);
        }
        /// <summary>
        /// Метод, за счет которого осуществляется ввод вместимости склада.
        /// Через функцию проверки данных на корректность, которая в данном случае возвращает вместимость.
        /// </summary>
        /// <returns></returns>
        public static uint StorageCapacityInput()
        {
            Console.Write("Введите вместимость склада (целое число, максимально допустимое количество контейнеров в нем):");
            return DataCheck();
        }
        /// <summary>
        /// /// Метод, за счет которого осуществляется ввод стоимости хранения контейнера на складе.
        /// Через функцию проверки данных на корректность, которая в данном случае возвращает тариф.
        /// </summary>
        /// <returns></returns>
        public static uint StoragePriceInput()
        {
            Console.WriteLine(String.Empty);
            Console.Write("Введите тариаф склада (целое число, фиксированная плата за хранение контейнера):");
            return DataCheck();
        }
        /// <summary>
        /// Функция, проверяющая данные на корректность.
        /// Нельзя выйти из нее не вбив корректные данные.
        /// Возвращает корректное значение данных.
        /// </summary>
        /// <returns></returns>
        public static uint DataCheck()
        {
            uint intParameter;
            string strParameter;
            do
            {
                Console.Write(" ");
                strParameter = Console.ReadLine();
                if (!uint.TryParse(strParameter, out intParameter))
                {
                    Console.WriteLine("ОШИБКА! Введите корректные данные!");
                    Console.WriteLine(String.Empty);
                }
            } while (!uint.TryParse(strParameter, out intParameter));
            return intParameter;
        }
        /// <summary>
        /// Метод, возвращающий индекс контейнера (его идентификатор) - рандомное значение.
        /// </summary>
        /// <returns></returns>
        public static string ContainerIndex()
        {
            string index = "#" + rnd.Next(1000, 10000);
            Console.WriteLine($"Индекс контейнера: {index}");
            return index;
        }
        /// <summary>
        /// Метод, возвращающий максимальную вместимую массу контейнера - рандомное значение.
        /// </summary>
        /// <returns></returns>
        public static uint ContainerMaxMassInput()
        {
            uint maxMass = (uint)(rnd.Next(50, 1000));
            Console.WriteLine($"Максимальная хранимая масса в данном контейнере: {maxMass} ");
            return maxMass;
        }
        /// <summary>
        /// Метод, осуществляющий ввод данных о количестве ящиков в контейнере.
        /// Возвращает значение количества ящиков контенера.
        /// </summary>
        /// <returns></returns>
        public static uint NumbersOfBoxes()
        {
            Console.WriteLine(String.Empty);
            Console.Write("Введите количество помещаемых ящиков:");
            return DataCheck();
        }
        /// <summary>
        /// Метод, за счет которого осуществляется функционал добавления контейнера на склад.
        /// </summary>
        public static void ContainerAdd()
        {
            // Проверка на загруженность склада.
            // При его полной загрузке контейнер не добавиться, о чем будет сообщено польщователю.
            if (containersList.ToArray().Length == depot._capacity)
            {
                Console.WriteLine("Все места на складе заняты");
            }
            else
            {
                Console.WriteLine("ДОБАВЛЕНИЕ КОНТЕЙНЕРА." + Environment.NewLine);
                // Определение порядка контейнера, его номера начиная с единицы.
                // Для избежания постоянного вычичлсения длины списка.
                int numberOfNextContainer = containersList.ToArray().Length + 1;
                Console.WriteLine($"КОНТЕЙНЕР {numberOfNextContainer}");
                Console.WriteLine(String.Empty);
                Console.WriteLine($"Задайте параметры контейнера под номером {numberOfNextContainer}" + Environment.NewLine);
                containersList.Add(new Containers(ContainerIndex(), ContainerMaxMassInput(), ContainerDamage(), NumbersOfBoxes()));
                AddBoxesInContainers();
                containersList[numberOfNextContainer - 1].GetInfo(numberOfNextContainer);
                // Проверка на рентабельность.
                // Если проверка будет провалена, контейнер не добавиться на склад, о чем будет сообщено пользователю.
                double damagedCost = Math.Round(containersList[numberOfNextContainer - 1]._cost *
                    (1 - containersList[numberOfNextContainer - 1]._damage), 3);
                if (damagedCost > depot._rate)
                {
                    depot._containers = containersList;
                    Console.WriteLine(String.Empty);
                    Console.WriteLine($"Осталось свободного места на складе: {depot._capacity - numberOfNextContainer}");
                }
                else
                {
                    containersList.RemoveAt(numberOfNextContainer - 1);
                    Console.WriteLine(String.Empty);
                    Console.WriteLine("\t!!!ВЫ НЕ МОЖЕТЕ ДОБАВИТЬ ЭТОТ КОНТЕЙНЕР НА СКЛАД," +
                        " ПОТОМУ ЧТО ЕГО ХРАНЕНИЕ НЕРЕНТАБЕЛЬНО !!!.");
                    Console.WriteLine(String.Empty);
                    Console.WriteLine($"Тариф склада: {depot._rate}   Стоимость контейнера с учетом повреждений: {damagedCost}");
                    Console.WriteLine(String.Empty);
                    Console.WriteLine($"Осталось свободного места на складе: {depot._capacity - numberOfNextContainer + 1}");
                }
            }
        }
        /// <summary>
        /// Метод, осуществляющий функционал выбора действия пользователем.
        /// Добавить контейнер, удалить, вывести информациюю о складе, записать ее в файл или выйти из программы.
        /// Метод цикличен (повтор решения).
        /// </summary>
        public static void MoveChoice()
        {
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine("Что вы хотите сделать дальше?");
            Console.WriteLine("1. Добавить контейнер на склад.");
            Console.WriteLine("2. Удалить контейнер со склада.");
            Console.WriteLine("3. Вывести содержимое склада.");
            Console.WriteLine("4. Запись содержимого склада в файл." + Environment.NewLine);
            Console.WriteLine("///\tПри желании выхода из программы введите 'exit'.");
            Console.WriteLine(String.Empty);
            Console.Write("Введите номер выбранного пункта: ");
            string yourChoice = Console.ReadLine();
            switch (yourChoice)
            {
                case "1":
                    Console.Clear();
                    ContainerAdd();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("\tУДАЛЕНИЕ КОНТЕЙНЕРА." + Environment.NewLine);
                    ShowAllContainers();
                    ContainerDelete();
                    break;
                case "3":
                    Console.Clear();
                    ShowStorage();
                    Console.WriteLine(Environment.NewLine + "Нажмите любую клавишу для продолжения действия...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case "4":
                    Console.Clear();
                    WriteStorage();
                    break;
                case "exit":
                    CloseProgramm();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("ОШИБКА! Введенные данные некорректны.");
                    Console.WriteLine("Попробуйте снова." + Environment.NewLine);
                    break;
            }
            MoveChoice();
        }
        /// <summary>
        /// Метод, выводящий в консоль информацию о контейнерах склада при желании удалить какой-либо из них.
        /// </summary>
        public static void ShowAllContainers()
        {
            if (containersList.ToArray().Length == 0)
            {
                Console.WriteLine("ОШИБКА! На данном складе отсутствуют контейнеры.");
                MoveChoice();
            }
            else
            {
                Console.WriteLine("Список контейнеров." + Environment.NewLine);
                for (int i = 0; i < containersList.ToArray().Length; i++)
                {
                    Console.Write($"** Контейнер {containersList[i]._index}.");
                    Console.WriteLine($"\tМаксимальвый хранимый вес: {containersList[i]._maxMass}  " +
                        $"Количество ящиков: {containersList[i]._numberOfBoxes}");
                    Console.WriteLine(String.Empty);
                }
            }
        }
        /// <summary>
        /// Метод, осуществляющий функционал удаления контейнера.
        /// </summary>
        public static void ContainerDelete()
        {
            Console.WriteLine(Environment.NewLine + "Введите индекс (с решёточкой!) контейнера, " +
                "который вы хотите удалить (для отмены операции введите 'cancel'): ");
            // Запрос индекса контейнера, желаемого к удалению.
            string indexChoice = Console.ReadLine();
            // При желании пользователь может отменить эту опреацию и увидеть красивую анимацию отмены.
            if (indexChoice == "cancel")
            {
                Console.WriteLine("Отмена операции.....");
                Thread.Sleep(2000);
                MoveChoice();
            }
            else
            {
                // Поиск контейнера с введенным индексом.
                bool flag = false;
                for (int i = 0; i < containersList.ToArray().Length; i++)
                {
                    if (containersList[i]._index == indexChoice)
                    {
                        containersList.RemoveAt(i);

                        Console.WriteLine(Environment.NewLine + "грузчики выносят контейнер со склада....подождите....");
                        Thread.Sleep(3000);
                        Console.WriteLine(Environment.NewLine + "УДАЛЕНИЕ ПРОИЗВЕДЕНО!");
                        flag = true;
                    }
                }
                if (!flag)
                {
                    Console.WriteLine("Контейнера с данным индексом нет на складе.");
                    Console.WriteLine("Попробуйте снова.");
                    Console.WriteLine(String.Empty);
                    ContainerDelete();
                }
            }
        }
        /// <summary>
        /// Метод, осуществляющий добавление в контейнер ящиков.
        /// </summary>
        public static void AddBoxesInContainers()
        {
            // Переменная - индекс последнего добавленного контейнера.
            int lastIndex = containersList.ToArray().Length - 1;
            Console.WriteLine("________________________________________________________________________");
            Console.WriteLine($"ВВОД ИНФОРМАЦИИ О ЯЩИКАХ КОНТЕЙНЕРА { containersList[lastIndex]._index}"
                + Environment.NewLine);

            boxes[lastIndex] = new Boxes[containersList[lastIndex]._numberOfBoxes];
            // Запись массы контейнера.
            uint weight = 0;
            // Запись стоимости содержимого контейнера.
            uint cost = 0;
            for (int i = 0; i < containersList[lastIndex]._numberOfBoxes; i++)
            {

                AddBox(i, ref weight, ref cost, lastIndex);
                Console.WriteLine(String.Empty);
            }
            containersList[lastIndex]._cost = cost;
            containersList[lastIndex]._boxes = boxes[lastIndex];

        }
        /// <summary>
        /// Метод, осуществляющий ввод данных о массе ящиков.
        /// Возвращает значение массы ящика.
        /// </summary>
        /// <returns></returns>
        public static uint BoxMassInput()
        {
            Console.Write("Введите массу:");
            return DataCheck();
        }
        /// <summary>
        /// Метод, возвращающий индекс ящика (идентификатор) - рандомное значение.
        /// </summary>
        /// <returns></returns>
        public static string BoxIndex()
        {
            string index = "#" + rnd.Next(100000, 1000000);
            Console.WriteLine($"Индекс ящика: {index}");
            return index;
        }
        /// <summary>
        /// Метод, осуществляющий ввод данных о цене содержимого ящиков.
        /// Возвращает значение цены содержимого ящика.
        /// </summary>
        /// <returns></returns>
        public static uint BoxPriceInput()
        {
            Console.Write("Введите цену:");
            return DataCheck();
        }
        /// <summary>
        /// Метод, осуществляющий функционал ддобавления ящиков в контейнер.
        /// Включает в себя проверку на массу содержимого.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="weight"></param>
        /// <param name="cost"></param>
        /// <param name="lastIndex"></param>
        public static void AddBox(int i, ref uint weight, ref uint cost, int lastIndex)
        {

            Console.WriteLine($"Введите информацию о {i + 1} ящике:");
            boxes[lastIndex][i] = new Boxes(BoxIndex(), BoxMassInput(), BoxPriceInput());
            cost += boxes[lastIndex][i]._price;
            weight += boxes[lastIndex][i]._mass;
            if (weight > containersList[lastIndex]._maxMass)
            {
                Console.WriteLine(String.Empty);
                Console.WriteLine("\tОШИБКА! Вы не можете добавить данный ящик в контейнер");
                Console.WriteLine("\tПричина - ПЕРЕГРУЗ");
                Console.WriteLine("\tДобавте ящик полегче");
                Console.WriteLine(String.Empty);
                weight -= boxes[lastIndex][i]._mass;
                AddBox(i, ref weight, ref cost, lastIndex);
            }
        }
        /// <summary>
        /// Медод, осуществляющий функционал вывода текущей информации о складе на консоль.
        /// </summary>
        public static void ShowStorage()
        {
            Console.Clear();
            Console.WriteLine("\tСОДЕРЖИМОЕ СКЛАДА" + Environment.NewLine);
            Console.WriteLine(depot.GetInfo(1));
            Console.WriteLine(String.Empty);
            Console.WriteLine("КОНТЕЙНЕРЫ.");

            if (containersList.ToArray().Length == 0)
            {
                Console.WriteLine("Склад пуст...");
            }
            else
            {
                foreach (Containers v in depot._containers)
                {
                    Console.WriteLine("____________________________________________" +
                        "_______________________________________________");
                    Console.WriteLine(v.GetInfo());
                }
            }
        }
        /// <summary>
        /// Метод возвращяющий степень повреждения контейнера в ходе хранения на складе.
        /// Рандомное значение.
        /// </summary>
        /// <returns></returns>
        public static double ContainerDamage()
        {
            double damage = Math.Round(rnd.NextDouble() * 0.5, 3);
            Console.WriteLine($"Повреждение: {damage} ");
            return damage;
        }
        /// <summary>
        /// Метод, осуществляющий запись информации о складе в выбранный текстовый файл.
        /// </summary>
        public static void WriteStorage()
        {
            string ourDestination = Directory.GetCurrentDirectory();
            Console.Clear();
            string anotherTextVariation = ("\tЗАПИСЬ ТЕКУЩИХ ДАННЫХ О СКЛАДЕ В ФАЙЛ"
                + Environment.NewLine + Environment.NewLine
                + Environment.NewLine + Environment.NewLine);
            string textVariation = ("Хотите ли вы поместить файл в текущий каталог:" + Environment.NewLine
                + Directory.GetCurrentDirectory() + Environment.NewLine);
            string name;
            // Выбор каталога и имени файла для записи.
            if (MiniGame(anotherTextVariation + textVariation) == 1)
            {
                Console.WriteLine("Введите имя файла(скажу сразу, WordPad будет читать этой файл криво, " +
                    "не знаю отчего, так что пожалуйста, используйте блокнот): ");
                name = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Нет? Ну тогда вводите полный путь до файла" +
                    "(скажу сразу, WordPad будет читать этой файл криво, " +
                    "не знаю отчего, так что пожалуйста, используйте блокнот):");
                Directory.SetCurrentDirectory(@"C:\");
                name = Console.ReadLine();
            }
            try
            {
                // Запись файла в выбранный файл.
                File.WriteAllText(name, "\tСОДЕРЖИМОЕ СКЛАДА" + Environment.NewLine + Environment.NewLine);
                File.AppendAllText(name, depot.GetInfo(1) + Environment.NewLine + Environment.NewLine);
                File.AppendAllText(name, "КОНТЕЙНЕРЫ." + Environment.NewLine);
                if (containersList.ToArray().Length == 0)
                {
                    File.AppendAllText(name, "Склад пуст...");
                }
                else
                {
                    foreach (Containers v in depot._containers)
                    {
                        File.AppendAllText(name, "_______________________________________" +
                            "____________________________________________________" + Environment.NewLine);
                        File.AppendAllText(name, v.GetInfo());
                        Console.WriteLine(String.Empty);
                    }
                }
                Console.WriteLine("Файл записан");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Такой директории не существует или у вас не к ней доступа!");
                Console.WriteLine("Нажмите любую клавишу, чтобы попробовать снова....");
                Console.ReadKey();
                Directory.SetCurrentDirectory(ourDestination);
                WriteStorage();
            }
        }
        /// <summary>
        /// Интересное осуществление метода выбора за счет нажатых клавиш.
        /// МОЖЕТ ОЦЕНИВАТЬСЯ В ПОЛЬЗУ К ДОПОЛНИТЕЛЬНОМУ ФУНКЦИОНАЛУ.
        /// Как и многие другие функции, которые я подобным образом не отметил.
        /// </summary>
        /// <param name="textVariation"></param>
        /// <returns></returns>
        public static int MiniGame(string textVariation)
        {
            // Прикольный консольный выбор действия, осуществленный за счет стрелочек вправо и влево.
            int t = 0;
            ConsoleKeyInfo arrowPressed;
            do
            {
                do
                {
                    Console.WriteLine(String.Empty + Environment.NewLine);
                    Console.WriteLine(String.Empty + Environment.NewLine);
                    Console.WriteLine(String.Empty);
                    Console.WriteLine("\t\t\t\t" + textVariation);
                    Console.WriteLine(String.Empty + Environment.NewLine);
                    Console.WriteLine(String.Empty);
                    Console.WriteLine("\t\t\t\t\t\t___\t   ");
                    Console.WriteLine("\t\t\t\t\t\tyes\tno");
                    arrowPressed = (Console.ReadKey(true));
                    Console.Clear();
                    t = 1;
                } while ((arrowPressed.Key.ToString() != "RightArrow") & (arrowPressed.Key.ToString() != "Enter"));
                if (arrowPressed.Key.ToString() == "RightArrow")
                {
                    do
                    {
                        Console.WriteLine(String.Empty + Environment.NewLine);
                        Console.WriteLine(String.Empty);
                        Console.WriteLine(String.Empty + Environment.NewLine);
                        Console.WriteLine("\t\t\t\t" + textVariation);
                        Console.WriteLine(String.Empty + Environment.NewLine);
                        Console.WriteLine(String.Empty);
                        Console.WriteLine("\t\t\t\t\t\t   \t__");
                        Console.WriteLine("\t\t\t\t\t\tyes\tno");
                        arrowPressed = (Console.ReadKey(true));
                        Console.Clear();
                        t = 0;
                    } while ((arrowPressed.Key.ToString() != "LeftArrow") & (arrowPressed.Key.ToString() != "Enter"));
                }
            } while (arrowPressed.Key.ToString() != "Enter");
            return (t);
        }
        /// <summary>
        /// В этом методе осуществляется проверка введенного пути на его корректность.
        /// А также, если путь оказался корректен, осуществляется проверка файла на корректность данных.
        /// На возможность преобразовать их в uint или double.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="strParameter"></param>
        public static void DirectoryFileCheck(string path, out string[] strParameter)
        {
            strParameter = new string[0];
            bool flag = true;
            do
            {
                flag = true;
                if (path.Length == 0)
                {
                    path = Console.ReadLine();
                    // При желании пользователь имеет возможность вернуться в самое начало.
                    if (path == "tostart")
                    {
                        Console.Clear();
                        Main();
                    }
                }
                try
                {
                    strParameter = File.ReadAllLines(path);
                    FileDataCheck(strParameter, ref path, out flag);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + Environment.NewLine);
                    Console.WriteLine("Нет такой директрии" + Environment.NewLine);
                    Console.WriteLine("Введите путь снова(если хотите вернуться в начало введите 'tostart').");
                    Console.Write("введите путь: ");
                    path = "";
                    flag = false;
                }
            } while (!flag);
        }
        /// <summary>
        /// Метод, осуществляющий создание объекта склад за счет информации из текстовх файлов.
        /// </summary>
        /// <param name="path"></param>
        public static void StorageParametersInput(string path)
        {
            DirectoryFileCheck(path, out string[] strParameter);
            depot = new Storage(uint.Parse(strParameter[0].Split()[0]), uint.Parse(strParameter[0].Split()[1]));
        }
        /// <summary>
        /// Метод, вызывающий функции считывания и проверке информации из файла.
        /// Также на основе данных из файла, в которм описываются действия, координирует весь ход программы.
        /// </summary>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        public static void MoveParametersInput(string path1, string path2)
        {
            Console.Clear();
            Console.WriteLine("Введите полный путь файлу, содержащему информацию о ДЕЙСТВИЯХ" +
                "(можете ввести готовый путь 'AddAndDelete.txt': ");
            DirectoryFileCheck(path1, out string[] strMovingParams);
            Console.Clear();
            Console.WriteLine("Введите полный путь файлу, содержащему информацию о КОНТЕЙНЕРАХ" +
                "(можете ввести готовый путь 'ContainersInfo.txt': ");
            DirectoryFileCheck(path2, out string[] strConteinerParams);
            // Счетчик, определяющий количество вызова функции добавления контейнера.
            // Необходим для определения строки файла, в которой содержится информация о нужно контейнере.
            int count = 0;
            // Счетчик количества успешно добавленных контейнеров.
            // Необходим для выведении информации о каждом контейнера после его добавления.
            int amountOfContainersCount = 0;
            // Цикл длины, в зависимости от количества команд, введенных в выбранный файл.
            for (int i = 0; i < strMovingParams.Length; i++)
            {
                switch (strMovingParams[i].Split()[0])
                {
                    case "1":
                        ContainerFromFileAddInterface(count, ref amountOfContainersCount, strConteinerParams);
                        count++;
                        break;
                    case "2":
                        ContainerFromFileDeleteInterface(strMovingParams, i, ref amountOfContainersCount);
                        break;
                    case "3":
                        ShowStorage();
                        Console.WriteLine(Environment.NewLine + "Нажмите любую клавишу для продолжения действия...");
                        Console.ReadKey();
                        break;
                    case "4":
                        WriteStorage();
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(Environment.NewLine + Environment.NewLine
                    + "Данные из файла указателя исчерпаны...");
            Console.WriteLine(Environment.NewLine + "Нажмите любую клавишу, чтобы вернуться в самое начало...");
            Console.Write("...");
            Console.ReadKey();
            Console.Clear();
            Main();
        }
        /// <summary>
        /// Метод, создающий и добавляющий на склад контейнеры на основе инормации из файла.
        /// Сразу осуществляет добавление ящиков в контейнеры на основе информации из файла.
        /// Прощу меня простить за длину этого метода.
        /// Все дело в том, что он содержит ифы для разных меких проверок, 
        /// которые выделять в отдельный метод ну уж слишком.
        /// Да и вообще, что либо тут декомпозировать по сути не за чем.
        /// Просто будут лишние методы по каким-то мелочам.
        /// </summary>
        /// <param name="theContainerInfo"></param>
        /// <param name="indexOfAddContainer"></param>
        /// <param name="reason"></param>
        public static void FileContainerAdd(string[] theContainerInfo, out string indexOfAddContainer, out string reason)
        {
            // Переменная, обозначающая причину недобавления файла, в случае его недобавления.
            reason = "";
            indexOfAddContainer = "#" + theContainerInfo[0];
            containersList.Add(new Containers("#" + theContainerInfo[0], uint.Parse(theContainerInfo[1]),
                double.Parse(theContainerInfo[2]), uint.Parse(theContainerInfo[3])));
            // Данная переменная обозначает индекс последнего добавленного на склад контейнера.
            // Она указывает на тот контейнер, к которому сейчас будут добавляться ящики.
            int lastIndex = containersList.ToArray().Length - 1;
            // Массив, содержащий информацию из файла о всех ящиках контейнера, подлежащего к добавлению.
            string[][] boxesParams = new string[containersList[lastIndex]._numberOfBoxes][];
            for (int j = 0; j < containersList[lastIndex]._numberOfBoxes; j++)
            {
                boxesParams[j] = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    boxesParams[j][i] = theContainerInfo[i + 4 + 3 * j];
                }
            }
            // Проверка к переполненности массива массивов объектов ящик.
            // Необходима, так как у него определенная длина и если мы превысим ее показатель вылетит исключение.
            if (lastIndex + 1 <= depot._capacity)
            {
                // Создание объекта массива ящиков.
                boxes[lastIndex] = new Boxes[containersList[lastIndex]._numberOfBoxes];
            }
            else
            {
                reason = "СКЛАД ЗАПОЛНЕН";
                containersList.RemoveAt(lastIndex);
                return;
            }
            // Запись информации о массе контейнера и суммы цены всех въодящих в него ящиков.
            uint weight = 0;
            uint cost = 0;
            // Создание конткретного ящика, записанного в массив, на основе информации из фала.
            for (int i = 0; i < containersList[lastIndex]._numberOfBoxes; i++)
            {
                boxes[lastIndex][i] = new Boxes("#" + boxesParams[i][0],
                    uint.Parse(boxesParams[i][1]), uint.Parse(boxesParams[i][2]));
                cost += boxes[lastIndex][i]._price;
                weight += boxes[lastIndex][i]._mass;
                Console.WriteLine(String.Empty);
            }
            // Проверка контейнера на массу и цену.
            // Если данные не будут соответствовать необходимым, конотейнер на склад не добавится.
            if (cost * (1 - containersList[lastIndex]._damage) > depot._rate && weight <= containersList[lastIndex]._maxMass)
            {
                containersList[lastIndex]._cost = cost;
                containersList[lastIndex]._boxes = boxes[lastIndex];
                depot._containers = containersList;
            }
            else
            {
                if (cost * (1 - containersList[lastIndex]._damage) <= depot._rate)
                {
                    reason = "СТОИМОСТЬ";
                }
                if (weight > containersList[lastIndex]._maxMass)
                {
                    reason += " МАССА";
                }
                // Удаление неподошедшего контейнера из списка объектов класса контейнеров.
                containersList.RemoveAt(lastIndex);              
            }
        }
        /// <summary>
        /// Метод, осуществляющий первичную проверку файла на корректность данных.
        /// Далее проверка будет осуществляться на более конткретном уровне.
        /// В зависимости от требований того или иного действия.
        /// </summary>
        /// <param name="strParameter"></param>
        /// <param name="path"></param>
        /// <param name="flag"></param>
        public static void FileDataCheck(string[] strParameter, ref string path, out bool flag)
        {
            flag = true;
            // Проверка каждого параметра файла на корректность данных.
            for (int i = 0; i < strParameter.Length; i++)
            {
                // StringSplitOptions.RemoveEmptyEntries - метод, удбирающий из строки лишние пробелы.
                for (int j = 0; j < strParameter[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length; j++)
                {
                    if (!uint.TryParse(strParameter[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)[j], out uint v)
                        & !double.TryParse(strParameter[i].Split(' ', StringSplitOptions.RemoveEmptyEntries)[j], out double check)
                        & strParameter[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length != 0)
                    {
                        Console.WriteLine(String.Empty);
                        Console.WriteLine("Данные файла некорректны" + Environment.NewLine);
                        Console.WriteLine("Попробуйте другой файл (если хотите вернуться в начало введите 'tostart').");
                        Console.Write("введите путь: ");

                        path = "";
                        flag = false;
                    }
                }
            }
        }
        /// <summary>
        /// Метод, осуществляющий функционал удаления контейнера.
        /// На основе индекса указанного в файле с информацией о действиях.
        /// </summary>
        /// <param name="index"></param>
        public static void FileContainerDelete(string index)
        {
            for (int i = 0; i < containersList.ToArray().Length; i++)
            {
                if (containersList[i]._index == index)
                {
                    containersList.RemoveAt(i);
                    Console.WriteLine($"Успешно произведено удаление со склада контейнера с индексом {index}!");
                    Console.Write("Нажмите любую клавишу, чтобы продолжить...");
                    Console.ReadKey();
                }
            }
        }/// <summary>
         /// Метод, осуществляющий интерфейс добавления контейнера из файла.
         /// Выделен в отдельный метод по причине "Объем метода не более 40 строк".
         /// </summary>
         /// <param name="count"></param>
         /// <param name="amountOfContainersCount"></param>
         /// <param name="strConteinerParams"></param>
        public static void ContainerFromFileAddInterface(int count, ref int amountOfContainersCount, string[] strConteinerParams)
        {
            if ((strConteinerParams.Length >= count + 1) &&
                            strConteinerParams[count].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length != 0)
            {
                FileContainerAdd(strConteinerParams[count].Split(' ', StringSplitOptions.RemoveEmptyEntries),
                    out string indexOfAddContainer, out string reason);
                Console.Clear();
                Console.WriteLine($"\t\t\t\t\tДОБАВЛЕНИЕ КОНТЕЙНЕРА {indexOfAddContainer} ИЗ ФАЙЛА.");
                Console.WriteLine(Environment.NewLine + Environment.NewLine + "Нажмите любую клавишу, чтобы приступить...");
                Console.WriteLine(String.Empty + Environment.NewLine);
                Console.ReadKey();

                if (containersList.ToArray().Length == amountOfContainersCount)
                {
                    Console.WriteLine($"ОШИБКА! Контейнер с индексом {indexOfAddContainer}" +
                        $" из текстового файла не может быть добавлен на склад" +
                        $" по причине: {reason}");
                    Console.Write("Нажмите любую клавишу, чтобы продолжить...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine(containersList[amountOfContainersCount].GetInfo());
                    Console.WriteLine(String.Empty + Environment.NewLine);
                    Console.WriteLine($"Успешно произведено добавление на склад контейнера из " +
                        $"файла с индексом {indexOfAddContainer} !");
                    Console.Write("Нажмите любую клавишу, чтобы продолжить...");
                    Console.ReadKey();
                    amountOfContainersCount++;
                }
            }
        }
        public static void ContainerFromFileDeleteInterface(string[] strMovingParams, int i, ref int amountOfContainersCount)
        {
            // Проверка файла с действиями на корректность данных в текущей ситуации.
            if (strMovingParams[i].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length != 1)
            {
                string indexOfDeleteContainer = "#" + strMovingParams[i].Split()[1];
                Console.Clear();
                Console.WriteLine($"\t\t\t\t\tУДАЛЕНИЕ КОНТЕЙНЕРА {indexOfDeleteContainer} СО СКЛАДА.");
                Console.WriteLine(Environment.NewLine + Environment.NewLine + "Нажмите любую клавишу, чтобы приступить...");
                Console.ReadKey();
                Console.WriteLine(String.Empty + Environment.NewLine);
                FileContainerDelete(indexOfDeleteContainer);
                amountOfContainersCount--;
            }
        }
        /// <summary>
        /// В этом методе происходит выбор задания информации о складе.
        /// Пользователь в интересно проработанном интерфейсе выбирает между консолью и текстовым файлом.
        /// </summary>
        public static void ConsoleOrTextFileChoice()
        {
            string textVariable = ("Желаете ли вы задать информацию из текстовых фалов?");
            // Предоставление ппользоватеелю выбора ввода информации.
            // Через файл либо через ввод с консоли.
            if (MiniGame(textVariable) == 1)
            {
                string anotherTextVariable = ("Желаете ли вы воспользоваться уже ГОТОВЫМИ файлими?");
                // Выюор между уже готовыми файлами или иными, по выбору пользователя.
                if (MiniGame(anotherTextVariable) == 1)
                {
                    StorageParametersInput("StorageParameters.txt");
                    containersList = new List<Containers>();
                    boxes = new Boxes[depot._capacity][];
                    MoveParametersInput("AddAndDelete.txt", "ContainersInfo.txt");
                }
                else
                {
                    Console.WriteLine("Ну тогда вводите пути самостоятельно" + Environment.NewLine);

                    Console.WriteLine("Введите полный путь файлу, содержащему информацию о СКЛАДЕ" +
               "(можете ввести готовый путь 'StorageParameters.txt': ");
                    StorageParametersInput("");
                    containersList = new List<Containers>();
                    boxes = new Boxes[depot._capacity][];
                    MoveParametersInput("", "");
                }
            }
            else
            {
                Console.WriteLine("СКЛАД." + Environment.NewLine);
                depot = new Storage(StorageCapacityInput(), StoragePriceInput());
                containersList = new List<Containers>();
                boxes = new Boxes[depot._capacity][];
                Console.Clear();
                depot.GetInfo();
                MoveChoice();
            }
        }
    }
}


