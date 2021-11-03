using System;
using System.Collections.Generic;
using System.Text;

namespace Chakra
{
    /// <summary>
    /// И наконец представляю единственный класс людей в этом коде одних задач!
    /// </summary>
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public static List<User> userList = new List<User>();
        public User(string name)
        {
            Name = name;
            userList.Add(this);
        }
        /// <summary>
        /// Выводет список всех существующих пользователей.
        /// </summary>
        public static void ShowUsers()
        {
            foreach(User kianu in userList)
            {
                Console.WriteLine(kianu.ToString());
            }
        }
        public override string ToString() => this.Name; 
    }
}
