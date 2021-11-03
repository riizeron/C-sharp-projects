using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace fractals
{
    public class Curve:FractalBase
    {
        /// <summary>
        /// Метод за счет которого осуществляется рисование Кривой Коха.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="iter"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public override int Draw(PointF p1, PointF p2, PointF p3, int iter, int k)
        {
            if (k >iteration)
            {
                k = 1;
            }
            // Условие выхода из рекурсии.
            if (iter > 0)  
            {
                // Средняя треть отрезка.
                var p4 = new PointF((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
                var p5 = new PointF((2 * p2.X + p1.X) / 3, (p1.Y + 2 * p2.Y) / 3);
                // Координаты вершины угла.
                var ps = new PointF((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
                var pn = new PointF((4 * ps.X - p3.X) / 3, (4 * ps.Y - p3.Y) / 3);

                Pen pen1 = new Pen(colorList[k++],3);
                // Рисование фрактала. Прцесс виден нами.
                // Необходим для наглядности и красоты.
                _graph.DrawLine(pen1, p4, pn);
                _graph.DrawLine(pen1, p5, pn);
                _graph.DrawLine(pen1, p4, p5);
                _graph.DrawLine(new Pen(Color.White,3), p4, p5);
                // Рисование фрактала. Прцесс виден нам.
                // Необходим для наглядности и красоты.
                g.DrawLine(pen1, p4, pn);
                g.DrawLine(pen1, p5, pn);
                g.DrawLine(pen1, p4, p5);
                g.DrawLine(new Pen(Color.White, 3), p4, p5);

                // Рекурсивно вызываем функцию.
                Draw(p4, pn, p5, iter - 1,k);
                Draw(pn, p5, p4, iter - 1,k);
           
                Draw(p1, p4, new PointF((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3), iter - 1,k);
                Draw(p5, p2, new PointF((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3), iter - 1,k);

            }
            return iter;
        }
    }
}
