using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    public class Containers
    {
        /// <summary>
        /// Поля класса контейнер.
        /// </summary>
        public uint _maxMass;
        public uint _numberOfBoxes;
        public string _index;
        public Boxes[] _boxes;
        public double _damage;
        public uint _cost;
        /// <summary>
        /// Конструктор объекта класса контейнер.
        /// </summary>
        /// <param name="_index"></param>
        /// <param name="_maxMass"></param>
        /// <param name="_damage"></param>
        /// <param name="_numberOfBoxes"></param>
        public Containers(string _index, uint _maxMass,double _damage, uint _numberOfBoxes)
        {
            this._index = _index;
            this._maxMass = _maxMass;
            this._damage = _damage;
            this._numberOfBoxes = _numberOfBoxes;
        }
        /// <summary>
        /// Метод вывода информации о контейнере в консоль по его порядковому номеру на складе.
        /// Вызывается только сразу после добавления контейнера на склад.
        /// </summary>
        /// <param name="index"></param>
        public void GetInfo(int index)
        {
            Console.Clear();
            Console.WriteLine($"\tПараметры контейнера под номером {index}: ");
            Console.WriteLine(String.Empty);
            Console.WriteLine($"Индекс: {_index}  Максимальвый хранимый вес: {_maxMass}  Повреждение: {_damage}  " +Environment.NewLine+
                $"Количество ящиков: {_numberOfBoxes}  Общая стоимость: {_cost}");
            Console.WriteLine(String.Empty);
            Console.WriteLine(String.Empty);
            Console.WriteLine("Ящики:\t\t  Индекс  \tМасса\t\tЦена\t");
            for (int i = 0; i < _numberOfBoxes; i++)
            {
                _boxes[i].GetInfo(1);
            }
        }
        /// <summary>
        /// Метод вывода информации о контейнере.
        /// Применяется при выводе всей информации о складе или записи информации в файл.
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {
            string str="";
            for (int i = 0; i < _numberOfBoxes; i++)
            {
                str+=(_boxes[i].GetInfo()+Environment.NewLine);
            }
            return ($"Контейнер:   * Индекс: {_index}  Максимальвый хранимый вес: {_maxMass}  Повреждение: {_damage}  " + Environment.NewLine +
                $"\t\tКоличество ящиков: {_numberOfBoxes}  Общая стоимость: {_cost}" + Environment.NewLine +Environment.NewLine+
               "Ящики:\t\t  Индекс  \tМасса\t\tЦена\t"+Environment.NewLine+str);
        }
    }
}
