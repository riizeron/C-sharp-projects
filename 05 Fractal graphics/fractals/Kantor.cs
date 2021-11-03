using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace fractals
{
    public class Kantor:FractalBase
    {
        /// <summary>
        /// Метод, осуществляющий рисование Множесства Кантора.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y"></param>
        /// <param name="count"></param>
        public override void Draw(int x1, int x2, int y,int count)
        {
            // Обнуления счетчика цветов.
            if (colorCount >= iteration) 
            { 
                colorCount = 0; 
            }
            Pen pen = new Pen(colorList[count++], 13);
            // Рисование в Bitmap. Процесс нами не виден.
            // Необходим для качественного сохранения фрактала.
            _graph.DrawLine(pen, x1, y, x2, y);
            // Рисование фрактала. Прцесс виден нами.
            // Необходим для наглядности и красоты.
            g.DrawLine(pen, x1, y, x2, y);
            // Объявляем рекурсию нужное количество раз.
            if (count < iteration)
            {
                Draw(x1, x1+(x2-x1)/3, y + distance,  count);
                Draw(x2 - (x2 - x1) / 3, x2, y + distance,  count);
                count=0;
            }
        }
    }
}
