using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace fractals
{
    public class FractalBase
    {
        public static int numberOfFractal; // поле для определения вида выбранного фрактала.
        public static double angel1;
        public static double angel2;
        public static double len; // Длина первого отрезка фрактального дерева.
        public static double coeff; // Коэффициент отношения отрезков фрактального дерева.
        public static Color colorStart; // Первый цвет градиента.
        public static Color colorEnd; // Последний цвет градиента.
        public static int distance; // Расстояние между отрезками множества Кантора.
        public static int iteration; // Количество итераций.
        public static int colorCount; // Счетчик сметы цвета.
        public static List<Color> colorList; // Лист с цветами градиента.
        public static int maxIteration=7; // Максимально возможное количество операций.
        public static Bitmap bmp; 
        public Graphics _graph; // Объект для рисования в Bitmap.
        public static Graphics g; // Объект для наглядного рисования.
        public static PaintEventArgs e; 
        /// <summary>
        /// Множество кантора.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <param name="y"></param>
        /// <param name="e"></param>
        /// <param name="count"></param>
        public virtual void Draw(int x1, int x2, int y, int count) { }

        /// <summary>
        /// Треугольник Серпинского.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="n"></param>
        /// <param name="e"></param>
        public virtual void Draw(float x1, float y1, float x2, float y2, float x3, float y3, int n) { }

        /// <summary>
        /// Фрактальное дерево.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="angle"></param>
        /// <param name="len"></param>
        /// <param name="coeff"></param>
        /// <param name="colorList"></param>
        /// <param name="panelHeight"></param>
        /// <param name="e"></param>
        /// <param name="k"></param>
        public virtual void Draw(int x, int y, double angle, double len,
            double coeff, List<Color> colorList, double panelHeight,int k) { }
        /// <summary>
        /// Ковер Серпинского.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="carpet"></param>
        public virtual void Draw(int level, RectangleF carpet) { }

        /// <summary>
        /// Кривая Коха.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="p3"></param>
        /// <param name="iter"></param>
        /// <param name="e"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public virtual int Draw(PointF p1, PointF p2, PointF p3, int iter, int k)
        {
            return 0;
        }


    }
}
