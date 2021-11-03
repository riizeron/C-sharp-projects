using System;
using System.Collections.Generic;
using System.Text;

namespace Chakra
{
    [Serializable]
    public class Bug : TaskBase
    {
        /// <summary>
        /// Простой конструктор объекта класс Bug.
        /// Полностью обращается к конструктору базового класса.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="status"></param>
        public Bug(string name, string status) : base(name, status)
        {

        }
    }
}
