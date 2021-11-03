using System;
using System.Collections.Generic;
using System.Text;

namespace Chakra
{
    /// <summary>
    /// Базовый класс для всех задач.
    /// Все классы задач наследуются от него и используют его конструктор, поля и свойства.
    /// Наследуется от интерфейса IAssignible.
    /// </summary>
    [Serializable]
    public class TaskBase : IAssignable
    {
        private string name;
        private string status;
        public List<User> appointUsers = new List<User>();

        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }
        /// <summary>
        /// Релизация значения статуа по умолчанию.
        /// </summary>
        public string Status
        {
            set
            {
                if (value == "Open Task" || value == "Work Task" || value == "End Task")
                {
                    status = value;
                }
                else
                {
                    status = "Open Task";
                }
            }
            get
            {
                return status;
            }
        }

        protected DateTime Date { set; get; }

        public TaskBase(string name, string status = "Open Task")
        {
            Name = name;
            Status = status;
        }
        /// <summary>
        /// Очень полезный метод для выбора определенной задачи проекта.
        /// Возвращает нужную задачу.
        /// Хитро поступает, если наткнется на задачу типа Epic.
        /// Может вызвать тот самый метод из класса Epic.
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        public static TaskBase ChooseTask(Project pr)
        {
            if (pr.taskList.Count == 0 && pr.bug == null)
            {
                throw new ArgumentException("В данном проекте нет ни одной задачи!!");
            }
            Console.Write("введите имя задачи: ");
            string name = Console.ReadLine();
            if (pr.bug != null && pr.bug.Name == name)
            {
                return pr.bug;
            }
            foreach (TaskBase t in pr.taskList)
            {
                if (t.Name == name)
                {
                    if (t.GetType().Name == "Epic")
                    {
                        return ((Epic)t).SearchInEpic();
                    }
                    else { return t; }
                }
            }
            throw new ArgumentException("Такой задачи нет!!");

        }
        public List<User> List { get; set; }
        /// <summary>
        /// Реализация интерфейсного метода для установки исполнителей.
        /// </summary>
        public virtual void SetUsers()
        {
            //Console.WriteLine("Распределение пользователей");
            Console.WriteLine(String.Empty);
            User.ShowUsers();
            Console.WriteLine(String.Empty);
            Console.Write("введите имя пользователя: ");
            string name = Console.ReadLine();
            foreach (User u in User.userList)
            {
                if (u.Name == name)
                {

                    appointUsers = new List<User> { u };
                    List = appointUsers;
                    Console.WriteLine("пользователь успешно распределен!");
                    Console.ReadKey();
                    return;

                }
            }
            Console.WriteLine("такого пользователя нет вообще");
            Console.ReadKey();
        }
        /// <summary>
        /// Реализация интерфейсного метода по удалению исполнителей.
        /// </summary>
        public void UnSetUsers()
        {
            if (this.appointUsers == null || this.appointUsers.Count == 0)
            {
                throw new ArgumentException("У данной задачи и так нет ни одного исполнителя!!");
            }
            Console.WriteLine(String.Empty);
            Console.Write("введите имя пользователя: ");
            string name = Console.ReadLine();
            foreach (User u in this.appointUsers)
            {
                if (u.Name == name)
                {
                    appointUsers.Remove(u);
                    List = appointUsers;
                    Console.WriteLine("пользователь успешно исключен!");
                    Console.ReadKey();
                    return;
                }
            }
            throw new ArgumentException("Пользователь с таким именем не был назначен на эту задачу");
        }
        /// <summary>
        /// Преобразование списка из всех исполнителей задачи вс строку.
        /// </summary>
        /// <returns></returns>
        public string AppointUsersToString()
        {
            string str = "(";
            foreach (User u in this.appointUsers)
            {
                str += u.Name + " | ";
            }
            str += ")";
            return str;
        }
        public override string ToString() => String.Format("{0,10}    |{1,10}    |{2,10}    |{3,10}    |{4,10}"+Environment.NewLine,
            this.GetType().Name, this.Name, this.Date.ToString(), this.status, this.AppointUsersToString());

    }
}
