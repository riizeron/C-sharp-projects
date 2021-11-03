using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
namespace Chakra
{
    [Serializable]
    public class Project
    {
        private string name;
        public List<TaskBase> taskList;
        // Статический список всех проектов.
        public static List<Project> projects = new List<Project>();
        private int maxCount = 10;
        public Bug bug;

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
        public TaskBase TaskList
        {
            set
            {
                taskList.Add(value);
            }
        }
        /// <summary>
        /// Я так и не понял, нужна тут эта шутка или нет.
        /// </summary>
        public string MaxCount
        {
            set
            {
                if (int.TryParse(value, out int intCount) && intCount > 0 && intCount < 11)
                {
                    maxCount = intCount;
                }
                else
                {
                    throw new Exception("Ohh, it's too big, sempaii");
                }
            }
        }

        public Project(string name)
        {
            Name = name;
            projects.Add(this);
            taskList = new List<TaskBase>();
        }

        public override string ToString()
        {
            string str = String.Format("{0,10}    |{1,10} {2}", this.GetType().Name, this.Name,Environment.NewLine);
            str += (bug == null) ? "" :String.Format( "  {0,10}    |{1,10}",bug.ToString(),Environment.NewLine);
            foreach (TaskBase task in taskList)
            {
                str += String.Format("  {0,10}    |{1,10}", task.ToString(), Environment.NewLine);
            }
            return str;
        }
        /// <summary>
        /// Показ всех проектов.
        /// </summary>
        public static string ShowProject()
        {
            string str = "";
            foreach (Project pr in projects)
            {
                str += pr.ToString() + Environment.NewLine;
            }
            return str;
        }
        /// <summary>
        /// Перебор всех доступных проектов с выбором одного конкретного.
        /// Возвращает выбранный объект класса Project.
        /// </summary>
        /// <param name="name"> Имя проекта </param>
        /// <returns></returns>
        public static Project ChooseProject(string name)
        {
            foreach (Project pr in projects)
            {
                if (name == pr.Name)
                {
                    return pr;
                }
            }
            throw new ArgumentException("Такого проекта нет!!");
        }
        /// <summary>
        /// Перебор всех задач типа Epic с выбором нужной по имени.
        /// </summary>
        /// <param name="name"> Имя задачи. </param>
        /// <returns></returns>
        public Epic SeeTaskOfEpic(string name)
        {
            foreach (TaskBase t in taskList)
            {
                if (t.Name == name && t.GetType().Name == "Epic")
                {
                    return (Epic)t;
                }
            }
            throw new ArgumentException("Такой задачи типа 'Epic' в данном проекте нет");
        }
    }
}
