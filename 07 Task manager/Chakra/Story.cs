using System;
using System.Collections.Generic;
using System.Text;

namespace Chakra
{
    [Serializable]
    public class Story : TaskBase
    {
        public Story(string name, string status = "Open Task") : base(name, status)
        {
            Date = DateTime.Now;
        }
        /// <summary>
        /// Переопределенный метод из интерфейса IAssignible.
        /// Переопределение необходимо для добавления в задачи типа Story 
        /// произвольного количествна пользователей, а не одного.
        /// Хитро работает за счет нажатия определенных клавиш.
        /// </summary>
        public override void SetUsers()
        {
            Console.WriteLine("Распределение пользователей для задачи 'Story'");
            Console.WriteLine(String.Empty);
            if (User.userList.Count == 0)
            {
                Console.WriteLine("Для начала добавте пожалуйста пользователя!!");
                Console.ReadKey();
                return;
            }
            User.ShowUsers();
            Console.WriteLine(String.Empty);
            Console.Write("введите имя пользователя: ");
            string name = Console.ReadLine();
            foreach (User u in User.userList)
            {
                if (u.Name == name)
                {
                    if (appointUsers.Contains(u))
                    {
                        throw new ArgumentException("Этот пользователь уже назначен на это работу!!");
                    }
                    appointUsers.Add(u);
                    List = appointUsers;
                    Console.WriteLine("пользователь успешно распределен!");
                    Console.Write("нажмите 'Enter' чтобы добавить еще одного или 'ESC' чтобы завершить процедуру: ");
                    ConsoleKeyInfo choice;
                    do
                    {
                        choice = Console.ReadKey(true);
                    } while (choice.Key != ConsoleKey.Escape && choice.Key != ConsoleKey.Enter);

                    if (choice.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine(String.Empty);
                        Console.WriteLine(String.Empty);
                        SetUsers();
                        return;
                    }
                    else if (choice.Key == ConsoleKey.Escape)
                    {
                        return;
                    }
                }
            }
            throw new ArgumentException("Такого пользователя не существует");
        }
    }
}
