using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace fractals
{
    class Triangle:FractalBase
    {
        /// <summary>
        /// Метод рисования треугольника Серпинского.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="n"></param>
        public override void Draw(float x1, float y1, float x2, float y2, float x3, float y3, int n)
        {
            // Обнуление счетчика цветов.
            if (colorCount >= iteration) 
            { 
                colorCount= 0; 
            }
            Pen pen = new Pen(colorList[colorCount++], 3);

            // Рисование фрактала. Прцесс виден нами.
            // Необходим для наглядности и красоты.
            g.DrawLine(pen, x1, y1, x2, y2); 
            g.DrawLine(pen, x2, y2, x3, y3);
            g.DrawLine(pen, x3, y3, x1, y1);
            // Рисование в Bitmap. Процесс нами не виден.
            // Необходим для качественного сохранения фрактала.
            _graph.DrawLine(pen, x1, y1, x2, y2);
            _graph.DrawLine(pen, x2, y2, x3, y3);
            _graph.DrawLine(pen, x3, y3, x1, y1);
            // Вызод из рекурсии.
            {
                if (n < 1)
                    return;
            }
            if (n > 1)
            { 
                //Рассчетные координаты
                float x1n, x2n;
                float y1n, y2n;
                float x3n, y3n;
                x1n = x1 + (x2 - x1) / 2F;
                y1n = y1 + (y2 - y1) / 2F;
                x2n = x2 + (x3 - x2) / 2F;
                y2n = y2 + (y3 - y2) / 2F;
                x3n = x3 + (x1 - x3) / 2F;
                y3n = y3 + (y1 - y3) / 2F;
                Draw(x1, y1, x1n, y1n, x3n, y3n, n - 1);
                Draw(x2, y2, x1n, y1n, x2n, y2n, n - 1);
                Draw(x3, y3, x2n, y2n, x3n, y3n, n - 1);
            }
        }
    }
}
