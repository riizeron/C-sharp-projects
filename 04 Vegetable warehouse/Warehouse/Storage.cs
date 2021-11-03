using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    public class Storage
    {
        /// <summary>
        /// Поля класса склад.
        /// </summary>
        public uint _capacity;
        public uint _rate;
        public List<Containers> _containers; 
        /// <summary>
        /// Конструктор объекта класса склад.
        /// </summary>
        /// <param name="_capacity"></param>
        /// <param name="_rate"></param>
        public Storage(uint _capacity, uint _rate) 
        {
            this._capacity = _capacity;
            this._rate = _rate;
        }
        /// <summary>
        /// Метод, осуществляющий вывод информации о складе в консоль.
        /// Применяется только сразу после создания склада.
        /// </summary>
        public void GetInfo ()
        {
            Console.WriteLine("\tПараметры склада: ");
            Console.WriteLine(String.Empty);
            Console.WriteLine($"Вместимость: {_capacity}  Тариф: {_rate}");
        }
        /// <summary>
        /// Метод записи информации о складе в файл.
        /// </summary>
        /// <param name="forFileOutput"></param>
        /// <returns></returns>
        public string GetInfo(int forFileOutput)
        {
            return("Параметры склада: "+ $"Вместимость: {_capacity}  Тариф: {_rate}");
        }
    }
}
