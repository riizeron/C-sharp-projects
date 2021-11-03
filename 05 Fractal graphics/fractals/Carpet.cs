using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
namespace fractals
{
    public class Carpet:FractalBase
    {
        /// <summary>
        ///  Метод, который рисует ковер Серпинского.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="carpet"></param>
        public override void Draw(int level, RectangleF carpet)
        {
            if (colorCount == iteration) { colorCount = 0; }
            // Проверяем, закончили ли мы построение.
            if (level == 0)
            {
                // Рисуем прямоугольник. 
                Brush brush = new SolidBrush(colorList[colorCount++]);
                // Рисование в Bitmap. Процесс нами не виден.
                // Необходим для качественного сохранения фрактала.
                _graph.FillRectangle(brush, carpet);
                // Рисование фрактала. Прцесс виден нам.
                // Необходим для наглядности и красоты.
                g.FillRectangle(brush, carpet);
            }
            else
            {
                // Делим прямоугольник на 9 частей.
                var width = carpet.Width / 3f;
                var height = carpet.Height / 3f;
                // x1 и y1 - координаты левой верхней вершины прямоугольника.
                // От нее будем отсчитывать остальные вершины маленьких прямоугольников.
                var x1 = carpet.Left;
                var x2 = x1 + width;
                var x3 = x1 + 2f * width;
                var y1 = carpet.Top;
                var y2 = y1 + height;
                var y3 = y1 + 2f * height;

                // Рекурсия, за счет которой осуществляется рисование фрактала.
                Draw(level - 1, new RectangleF(x1, y1, width, height)); 
                Draw(level - 1, new RectangleF(x2, y1, width, height)); 
                Draw(level - 1, new RectangleF(x3, y1, width, height)); 
                Draw(level - 1, new RectangleF(x1, y2, width, height));
                Draw(level - 1, new RectangleF(x3, y2, width, height));
                Draw(level - 1, new RectangleF(x1, y3, width, height));
                Draw(level - 1, new RectangleF(x2, y3, width, height)); 
                Draw(level - 1, new RectangleF(x3, y3, width, height)); 
                
            }
        }


    }
}
