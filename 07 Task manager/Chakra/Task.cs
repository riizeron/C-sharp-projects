using System;
using System.Collections.Generic;
using System.Text;

namespace Chakra
{
    [Serializable]
    public class Task : TaskBase
    {
        /// <summary>
        /// Простейшая задача типа Task.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        public Task(string name, string status = "Open Task") : base(name, status)
        {
            Date = DateTime.Now;
        }
    }
}
