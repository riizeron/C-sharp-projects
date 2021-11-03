using System;
using System.Collections.Generic;
using System.Text;

namespace Chakra
{
    /// <summary>
    /// Это вот мой доп функционал.
    /// Релизует образоване списка из нескольких исполнителей для задач типа Story.
    /// Для задач Bug и Task образует список из одного элемента, исполнителя.
    /// </summary>
    interface IAssignable
    {
        public void SetUsers();
        public void UnSetUsers();
        List<User> List { get; set; }
    }
}
