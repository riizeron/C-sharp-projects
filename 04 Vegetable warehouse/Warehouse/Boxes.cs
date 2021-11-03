using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    public class Boxes
    {
        /// <summary>
        /// Поля класса ящик.
        /// </summary>
        public uint _mass;
        public uint _price;
        public string _index;
        /// <summary>
        /// Констуктор объекта класса ящиков.
        /// </summary>
        /// <param name="_index"></param>
        /// <param name="_mass"></param>
        /// <param name="_price"></param>
        public Boxes(string _index, uint _mass,uint _price)
        {
            this._mass = _mass;
            this._price = _price;
            this._index = _index;
        }
        /// <summary>
        /// Метод вывода информции о ящиках в консоль.
        /// Применяется только при выводе информции после добавления контейнера.
        /// </summary>
        /// <param name="point"></param>
        public void GetInfo(int point)
        {
            Console.WriteLine ($"\t\t  {_index} \t{_mass}\t\t{_price}\t");
        }
        /// <summary>
        /// Метод ввода информации о ящиках контейнера в консоль.
        /// Применяется только при выводе информации о всем складе или записи ее в файл.
        /// </summary>
        /// <returns></returns>
        public string GetInfo()
        {    
            return ($"\t\t  {_index} \t{_mass}\t\t{_price}\t");
        }
    }
}
