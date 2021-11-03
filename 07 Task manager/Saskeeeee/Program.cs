using System;
using Chakra;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Saskeeeee
{
    class Program
    {

        static void Main()
        {
            try
            {
                Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Извините, что-тто пошло не так");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                Main();
            }
        }
        /// <summary>
        /// Я уверен, что вам понятно, что здесь происходит))).
        /// </summary>
        public static void Start()
        {
            // Просто текст.
            Console.Clear();
            Console.WriteLine("Проектный менеджер");
            Console.WriteLine(String.Empty);
            Console.WriteLine("create user - создать пользователя");
            Console.WriteLine("show users - вывести список пользователей");
            Console.WriteLine("delete user - удалить пользователя");
            Console.WriteLine("create project - создать новый проект");
            Console.WriteLine("show projects - показать все проекты");
            Console.WriteLine("change name - изменение имени проекта");
            Console.WriteLine("delete project - удалить проект");
            Console.WriteLine("add task - добавить в проект задачу");
            Console.WriteLine("change status - изменить статус задачи");
            Console.WriteLine("delete task - удалить задачу из проекта");
            Console.WriteLine("appoint user - назначить пользователя на задачу");
            Console.WriteLine("disappoint user - убрать исполнителя");
            Console.WriteLine("add task to Epic - добавить задачу в задачу типа 'Epic' ");
            Console.WriteLine("save - сериализация проекта");
            Console.WriteLine("open - десереализация проекта");
            Console.WriteLine("exit - выход и сериализация проекта");
            Console.WriteLine(String.Empty);
            Console.Write(':');
            // Вызов метода выбора действия.
            SwitchCase(Console.ReadLine());
            Start();
        }
        /// <summary>
        /// Метод выбора действия.
        /// Да, великоват, а куда деваться?
        /// </summary>
        /// <param name="choice"></param>
        public static void SwitchCase(string choice)
        {
            switch (choice)
            {
                case "create user":
                    UserCreation();
                    break;
                case "show users":
                    ShowUsers();
                    Console.ReadKey();
                    break;
                case "delete user":
                    Deleting();
                    break;
                case "create project":
                    ProjectCreation();
                    break;
                case "show projects":
                    ShowProjects();
                    Console.ReadKey();
                    break;
                case "delete project":
                    Deleting("project");
                    break;
                case "change name":
                    ChangingNameOfProject();
                    break;
                case "add task":
                    AddTask();
                    break;
                case "change status":
                    ChangeStatus();
                    break;
                case "delete task":
                    DeleteTask();
                    break;
                case "appoint user":
                    AppointUser();
                    break;
                case "disappoint user":
                    DisappointUser();
                    break;
                case "add task to Epic":
                    AddTask("epic");
                    break;
                case "save":
                    Saving();
                    break;
                case "exit":
                    File.WriteAllText($@"{DateTime.Now.Ticks}.txt", Project.ShowProject());
                    Saving();
                    Environment.Exit(0);
                    break;
                case "open":
                    Opening();
                    break;
                default:
                    Console.WriteLine("No");
                    break;
            }
        }
        /// <summary>
        /// Метод создания пользователя.
        /// </summary>
        public static void UserCreation()
        {
            Console.Clear();
            Console.WriteLine("Добавление польщователя" + Environment.NewLine);
            Console.Write("Введите имя пользователя (для отмены введите 'cancel'): ");
            string name = Console.ReadLine();
            CancelOperation(name);
            User chel = new User(name);
            Console.WriteLine("Пользователь успешно добавлен!");
            Console.ReadKey();
        }
        /// <summary>
        /// Метод создания проекта.
        /// </summary>
        public static void ProjectCreation()
        {
            Console.Clear();
            Console.WriteLine("Создание проекта" + Environment.NewLine);
            Console.Write("Введите имя проекта (или введите 'cancel' для отмены): ");
            string nameOfNewProject = Console.ReadLine();
            CancelOperation(nameOfNewProject);
            Project newProject = new Project(nameOfNewProject);
        }
        /// <summary>
        /// Показ всех существующих на данный момент поьзователей.
        /// </summary>
        public static void ShowUsers()
        {
            Console.Clear();
            Console.WriteLine("Список пользователей:");
            Console.WriteLine(String.Empty);
            User.ShowUsers();
        }
        /// <summary>
        ///  Показ всех существующих на жанный момент проектов со всеми их заадачами.
        /// </summary>
        public static void ShowProjects()
        {
            Console.Clear();
            Console.WriteLine("Проекты:" + Environment.NewLine);
            Console.WriteLine(Project.ShowProject());
        }
        /// <summary>
        /// Метод добавления задачи в проект.
        /// Реализован хитро, так как помимо добавления задачи в проект
        /// способен добавлять подзадачу в задачу типа Epic за счет изменения параметра flag.
        /// То есть этим методом мы убиваем сразу двух зайцев.
        /// </summary>
        /// <param name="flag"> Тот самый параметр, определяющий какое добавление задач будет происходить. </param> 
        public static void AddTask(string flag = "task")
        {
            if (Project.projects.Count == 0)
            {
                Console.WriteLine("Для начала пожалуйста создайте проект!)))");
                Console.ReadKey();
                return;
            }
            Console.Clear();
            ShowProjects();

            try
            {
                if (flag == "task")
                {
                    ForTask();
                }
                else if (flag == "epic")
                {
                    ForEpic();
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                AddTask(flag);
            }
        }
        /// <summary>
        /// Метод, в совокупности с предыдущим, осуществляет функционал добавления подзадачи в Epic.
        /// </summary>
        public static void ForEpic()
        {
            Console.Write("введите имя проекта (или введите 'cancel' для отмены): ");
            string nameOfChoosenProject = Console.ReadLine();
            CancelOperation(nameOfChoosenProject);
            Project pr = Project.ChooseProject(nameOfChoosenProject);
            pr.ToString();
            Console.Write("Введите имя задачи типа 'Epic': ");
            string epicTaskName = Console.ReadLine();
            // Проверка на корректность.
            try
            {
                Epic ep = pr.SeeTaskOfEpic(epicTaskName);
                ep.ToString();
                Console.Write("введите тип задачи (Story,Task): ");
                string typeOfTask = Console.ReadLine();
                Console.Write("введите имя новой задачи: ");
                string nameOfTask = Console.ReadLine();
                SwitchToEpic(ep, typeOfTask, nameOfTask);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                ForEpic();
            }
        }
        /// <summary>
        /// Абсолютно аналогичен предыдущему методу за исключение того, что добавляет 
        /// задачу напрямую в проект, не в Epic.
        /// </summary>
        public static void ForTask()
        {
            Console.Write("введите имя проекта (или введите 'cancel для отмены'): ");
            string nameOfChoosenProject = Console.ReadLine();
            CancelOperation(nameOfChoosenProject);
            Project pr = Project.ChooseProject(nameOfChoosenProject);
            pr.ToString();
            Console.Write("введите тип задачи (Epic, Story, Task, Bug): ");
            string typeOfTask = Console.ReadLine();
            Console.Write("введите имя задачи: ");
            string nameOfTask = Console.ReadLine();
            Console.Write("введите статус задачи (при неверном введении он будет расцениваться как 'Open Task'): ");
            string status = Console.ReadLine();
            SwitchToProject(pr, typeOfTask, nameOfTask, status);
        }
        /// <summary>
        /// Этот метод также дополняет пару предыдущих в плане добавления задачи именно в проект, не в Epic.
        /// Тут осуществляется создание объекстов и добавление их в список задач проекта.
        /// </summary>
        /// <param name="pr"> Выбранный проект. </param>
        /// <param name="typeOfTask">. Передается тип новой задачи. </param>
        /// <param name="nameOfTask"> Имя новой задачи. </param>
        /// <param name="status"> Статус новой задачи. </param>
        public static void SwitchToProject(Project pr, string typeOfTask, string nameOfTask, string status)
        {
            switch (typeOfTask)
            {
                case "Epic":
                    pr.TaskList = new Epic(nameOfTask, status);
                    break;
                case "Story":
                    pr.TaskList = new Story(nameOfTask, status);
                    break;
                case "Task":
                    pr.TaskList = new Task(nameOfTask, status);
                    break;
                case "Bug":
                    pr.bug = new Bug(nameOfTask, status);
                    break;
                default:
                    throw new ArgumentException("Такого типа задачи нет!!");
            }
        }
        /// <summary>
        /// Аналогичный предыдущему метод, добавляющий подзадачу в Epic.
        /// </summary>
        /// <param name="ep"> Объект типа Epic. </param>
        /// <param name="typeOfTask"> Тип новой подзадачи. </param>
        /// <param name="nameOfTask"> Имя новой подзадачи. </param>
        public static void SwitchToEpic(Epic ep, string typeOfTask, string nameOfTask)
        {
            switch (typeOfTask)
            {
                case "Story":
                    ep.UnderList = new Story(nameOfTask);
                    break;
                case "Task":
                    ep.UnderList = new Task(nameOfTask);
                    break;
                default:
                    throw new ArgumentException("Такого типа задачи нет!!");
            }
        }
        /// <summary>
        /// Ну а это простенький метод для реализации операции отмены какого-либо действия.
        /// </summary>
        /// <param name="choice"> Быть или не быть... </param>
        public static void CancelOperation(string choice)
        {
            if (choice == "cancel")
            {
                Start();
            }
        }
        /// <summary>
        /// Метод, который удаляет и людей и проекты.
        /// Примитивно убивает сразу двух зайцев за счет изменения параметра flag.
        /// Вообще конечно можно было и два разных метода написать,
        /// но мне захотелось поиграться со значением параметра по умолчанию)).
        /// </summary>
        /// <param name="flag"> Флажочек помогает понять что именнно нужно удалять, человека или проект. </param>
        public static void Deleting(string flag = "user")
        {
            Console.Clear();
            if (flag == "user")
            {
                Console.WriteLine("Удаление пользователя" + Environment.NewLine);
                if (User.userList.Count == 0)
                {
                    Console.WriteLine("Пользователей нету вообще");
                    Console.ReadKey();
                    return;
                }
                ShowUsers();
                Console.Write("введите имя пользователя: ");
                string name = Console.ReadLine();
                Console.WriteLine(String.Empty);
                foreach (User u in User.userList)
                {
                    if (u.Name == name)
                    {
                        User.userList.Remove(u);
                        Console.WriteLine($"Пользователь {name} успешно удален!");
                        Console.ReadKey();
                        return;
                    }
                }
                Console.WriteLine($"Пользователь {name} не существует");
            }
            else
            {
                Console.WriteLine("Удаление проекта" + Environment.NewLine);
                if (Project.projects.Count == 0)
                {
                    Console.WriteLine("Проектов нету вообще");
                    Console.ReadKey();
                    return;
                }
                ShowProjects();
                Console.WriteLine(String.Empty);
                Console.Write("введите имя проекта: ");
                string name = Console.ReadLine();
                Console.WriteLine(String.Empty);
                foreach (Project p in Project.projects)
                {
                    if (p.Name == name)
                    {
                        Project.projects.Remove(p);
                        Console.WriteLine($"Проект {name} успешно удален!");
                        Console.ReadKey();
                        return;
                    }
                }
                Console.WriteLine($"Проект {name} не существует");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Метод изменения имени любого существующего проекта.
        /// </summary>
        public static void ChangingNameOfProject()
        {
            Console.Clear();
            Console.WriteLine("Изменение имени проекта");
            Console.WriteLine(String.Empty);
            if (Project.projects.Count == 0)
            {
                Console.WriteLine("ни одного проекта вообще не существует");
                Console.ReadKey();
                return;
            }
            ShowProjects();
            Console.WriteLine(String.Empty);
            Console.Write("введите имя проекта (или введите 'cancel' для отмены): ");
            string last = Console.ReadLine();
            CancelOperation(last);
            foreach (Project p in Project.projects)
            {
                if (p.Name == last)
                {
                    Console.Write("введите новое имя: ");
                    p.Name = Console.ReadLine();
                    Console.WriteLine("имя успешно изменено!");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("проекта с таким имененм нет");
            Console.ReadKey();
            return;
        }
        /// <summary>
        /// Метод назначения пользователей, то бишь исполнителей, на выполнение задач.
        /// Как по мне это, наверное, самый лаконичный!!! в моем коде,
        /// так как очень просто реализуется за счет интерфейса и классов.
        /// </summary>
        public static void AppointUser()
        {
            Console.Clear();
            Console.WriteLine("Назначение пользователей");
            Console.WriteLine(String.Empty);
            if (User.userList.Count == 0)
            {
                Console.WriteLine("Для начала добавте пожалуйста пользователя!!");
                Console.ReadKey();
                return;
            }
            if (Project.projects.Count == 0)
            {
                Console.WriteLine("Для начала добавте пожалуйста проект!!");
                Console.ReadKey();
                return;
            }
            ShowProjects();
            Console.WriteLine(String.Empty);
            Console.Write("введите имя проекта: ");
            string name = Console.ReadLine();
            try
            {
                TaskBase task = TaskBase.ChooseTask(Project.ChooseProject(name));
                task.SetUsers();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Метод абсолютно противоположный предыдущему.
        /// Снимает исполнителя с задачи.
        /// Тоже простой и понятный, использует интерфейс IAssignible.
        /// </summary>
        public static void DisappointUser()
        {
            Console.Clear();
            Console.WriteLine("Убрать исполнителя");
            Console.WriteLine(String.Empty);
            if (User.userList.Count == 0)
            {
                Console.WriteLine("Для начала добавте пожалуйста пользователя!!");
                Console.ReadKey();
                return;
            }
            if (Project.projects.Count == 0)
            {
                Console.WriteLine("Для начала добавте пожалуйста проект!!");
                Console.ReadKey();
                return;
            }
            ShowProjects();
            Console.WriteLine(String.Empty);
            Console.Write("введите имя проекта: ");
            string name = Console.ReadLine();
            try
            {
                TaskBase task = TaskBase.ChooseTask(Project.ChooseProject(name));
                task.UnSetUsers();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Простой метод изменения статуса у произвольно существующей задачи.
        /// </summary>
        public static void ChangeStatus()
        {
            Console.Clear();
            Console.WriteLine("Изменение статуса задачи");
            Console.WriteLine(String.Empty);
            if (Project.projects.Count == 0)
            {
                Console.WriteLine("Для начала добавте пожалуйста проект!!");
                Console.ReadKey();
                return;
            }
            ShowProjects();
            Console.WriteLine(String.Empty);
            Console.Write("введите имя проекта: ");
            string name = Console.ReadLine();
            try
            {
                TaskBase task = TaskBase.ChooseTask(Project.ChooseProject(name));
                Console.Write("введите новый статус (Work Task, Open Task, End Task)" + Environment.NewLine +
                    "(при неверном введении он будет расцениваться как 'Open Task'): ");
                task.Status = Console.ReadLine();
                Console.WriteLine("Статус успешно изменен!!");
                Console.ReadKey();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Великоват немного метод? Да, знаю.
        /// Все дело в бессмысленности разбиения его на части 
        /// по причине уникальности происходящего в нем действия.
        /// Иными словами, разбивать этод метод означает 
        /// загрязнять код абсолютно ненужными одноразовыми методами.
        /// Этот метод удаляет задачу из проекта.
        /// Причем реализован он довольно хитро, ведь сразу же не поятно что делать с задачей типа Epic.
        /// Поэтому я реализовал штуку, которая спрашивает пользователя о том, удалять ли весь Epic 
        /// или зайти внутрь него и удалить подзадачу.
        /// </summary>
        public static void DeleteTask()
        {
            Console.Clear();
            Console.WriteLine("Удаление задачи");
            Console.WriteLine(String.Empty);
            if (Project.projects.Count == 0)
            {
                Console.WriteLine("Для начала добавте пожалуйста проект!!");
                Console.ReadKey();
                return;
            }
            ShowProjects();
            Console.WriteLine(String.Empty);
            Console.Write("введите имя проекта: ");
            string name = Console.ReadLine();
            try
            {
                Project pr = Project.ChooseProject(name);
                Console.Write("введите имя задачи: ");
                string taskName = Console.ReadLine();
                if (pr.bug != null && pr.bug.Name == taskName)
                {
                    pr.bug = null;
                }
                foreach (TaskBase t in pr.taskList)
                {
                    if (t.Name == taskName)
                    {
                        if (t.GetType().Name == "Epic")
                        {
                            Console.WriteLine("Удалить весь Epic или подзадачи в нем?");
                            Console.WriteLine("Нажмите 'Backspace' чтобы удалить весь Epic, 'Space' чтобы зайти внутрь");
                            ConsoleKeyInfo key;
                            do
                            {
                                key = Console.ReadKey(true);
                            } while (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Spacebar);
                            if (key.Key == ConsoleKey.Spacebar)
                            {
                                TaskBase tb = ((Epic)t).SearchInEpic();
                                ((Epic)t).underList.Remove(tb);
                                return;
                            }
                            else if (key.Key == ConsoleKey.Backspace)
                            {
                                pr.taskList.Remove(t);
                                return;
                            }
                        }
                        else
                        {
                            pr.taskList.Remove(t);
                            return;
                        }
                    }
                }
                throw new ArgumentException("Отсутствует задача с таким именем");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        public static void Saving()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("project.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Project.projects);
            }
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User.userList);
            }
            Console.WriteLine("Объект сериализован");

        }
        public static void Opening()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("project.dat", FileMode.OpenOrCreate))
            {
                Project.projects = (List<Project>)formatter.Deserialize(fs);
            }
            using (FileStream fs = new FileStream("people.dat", FileMode.OpenOrCreate))
            {
                User.userList = (List<User>)formatter.Deserialize(fs);
            }
            Console.WriteLine("Объект десериализован");

            Console.ReadKey();

        }
    }
}
