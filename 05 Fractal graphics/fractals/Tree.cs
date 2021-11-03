using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace fractals
{
    class Tree:FractalBase
    {
        // Объявление минимального коэффициента.
        public static double minCoeff = 1.3;
        /// <summary>
        /// Метод рисование Фракталльного дерева.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="angle"></param>
        /// <param name="len"></param>
        /// <param name="coeff"></param>
        /// <param name="colorList"></param>
        /// <param name="panelHeight"></param>
        /// <param name="k"></param>
        public override void Draw(int x,int y,double angle, double len,
            double coeff,List<Color> colorList,double panelHeight,int k)
        {
            // Объявление координат.
            double x1, y1;
            x1 = x + len * Math.Sin( angle* Math.PI * 2 / 360.0);
            y1 = y + len * Math.Cos(angle * Math.PI * 2 / 360.0);
            // Рисование фрактала. Прцесс виден нам.
            // Необходим для наглядности и красоты.
            g.DrawLine(new Pen(colorList[k],(float)(len/10)), x, (int)panelHeight-y, (int)x1, (int)panelHeight-(int)y1);
            // Рисование в Bitmap. Процесс нами не виден.
            // Необходим для качественного сохранения фрактала.
            _graph.DrawLine(new Pen(colorList[k], (float)(len / 10)), x, (int)panelHeight - y, (int)x1, (int)panelHeight - (int)y1);
            k++;
            // Условие прекращения вызова рекурсий.
            if (len > 2)
            {
                Draw((int)x1, (int)y1,angle+angel1, len / coeff, coeff, colorList, panelHeight ,k);
                Draw((int)x1, (int)y1,angle-angel2, len / coeff, coeff, colorList, panelHeight, k);
                k= 0;
            }

        }
        
    }
}
