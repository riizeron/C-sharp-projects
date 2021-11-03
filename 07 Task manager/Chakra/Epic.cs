using System;
using System.Collections.Generic;
using System.Text;

namespace Chakra
{
    [Serializable]
    public class Epic : TaskBase
    {
        // Подзадачи.
        public List<TaskBase> underList;
        public TaskBase UnderList
        {
            set
            {
                underList.Add(value);
            }
        }
        /// <summary>
        /// Я так понял у Epic статуса нет, да?
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        public Epic(string name, string status = "") : base(name, status)
        {
            underList = new List<TaskBase>();
            Date = DateTime.Now;
        }
        /// <summary>
        /// Метод, возвращающий подзадачу с указанным именем.
        /// </summary>
        /// <returns></returns>
        public TaskBase SearchInEpic()
        {
            if (this.underList.Count == 0)
            {
                throw new ArgumentException("В этом Epic задаче нет подзадач");
            }
            Console.Write("введите имя подзадачи: ");
            string name = Console.ReadLine();
            foreach (TaskBase tb in this.underList)
            {
                if (tb.Name == name)
                {
                    if (tb.GetType().Name == "Epic")
                    {
                        return ((Epic)tb).SearchInEpic();
                    }
                    else
                    {
                        return tb;
                    }
                }
            }
            throw new ArgumentException("В этом Epic нет подзадачи с таким имененем!!");
        }
        public override string ToString()
        {
            string str = String.Format("{0,10}    |{1,10}    |{2,10}    |{3,10}"+Environment.NewLine,this.GetType().Name, this.Name, this.Date.ToString(),this.Status);
            foreach (TaskBase task in underList)
            {
                str += ""+"\t" + task.ToString();
            }
            return str;
        }
    }
}
