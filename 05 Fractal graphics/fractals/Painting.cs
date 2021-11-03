using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace fractals
{
    public partial class Painting : Form
    {
        public Painting()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод, обрабатывающий нажатие на кнопу Start.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, EventArgs e)
        {
            labelWarning.Visible = true;

            buttonStart.Visible = false;
            FractalBase.g = pictureBox1.CreateGraphics();
            // Разбиение программы на ччасти в зависимости от выбора фрактала.
            switch (FractalBase.numberOfFractal)
                {
                    case 1:
                        TreeDraw();
                        break;
                    case 2:
                        CurveDraw();
                        break;
                    case 3:
                        CarpetDraw();
                        break;
                    case 4:
                        TriangelDraw();
                        break;
                    case 5:
                        KantorDraw();
                        break;
                }
            org.Image = pictureBox1.Image;
            labelWarning.Visible = false;
            buttonSave.Visible = true;
            buttonBack.Visible = true;
            trackBar1.Visible = true;

        }
        /// <summary>
        /// Метод, осуществляющий приминение метода рисование Фрактального дерева.
        /// </summary>
        private void TreeDraw()
        {
            // Первоначальные координаты.
            int x = pictureBox1.Width / 2;
            int y = 0;
            int size = 1;
            double sizeCheck = FractalBase.len;
            while (sizeCheck > 2)
            {
                sizeCheck /= FractalBase.coeff;
                size++;
            }
            // Создание градиента (списка цветов).
            int rMax = FractalBase.colorEnd.R;
            int rMin = FractalBase.colorStart.R;
            int gMax = FractalBase.colorEnd.G;
            int gMin = FractalBase.colorStart.G;
            int bMax = FractalBase.colorEnd.B;
            int bMin = FractalBase.colorStart.B;
            
            var colorList = new List<Color>();
            for (int i = 0; i < size; i++)
            {
                var rAverage = rMin + (int)((rMax - rMin) * i / size);
                var gAverage = gMin + (int)((gMax - gMin) * i / size);
                var bAverage = bMin + (int)((bMax - bMin) * i / size);
                colorList.Add(Color.FromArgb(rAverage, gAverage, bAverage));
            }
            FractalBase fractal = new Tree();
            fractal._graph = Graphics.FromImage(FractalBase.bmp);
            fractal.Draw(x, y, 0, FractalBase.len, FractalBase.coeff, colorList, pictureBox1.Height, 0);
            // Присвоение изображения фрактала из Bitmap на PictureBox.
            pictureBox1.Image = FractalBase.bmp;
        }
        /// <summary>
        /// Метод, осуществляющий вызов функционала рисования множества Кантора.
        /// </summary>
        private void KantorDraw()
        {
            // Инициализирование первоначальных координат.
            int x1 = 10;
            int x2 = pictureBox1.Width-10;
            int y = pictureBox1.Height/3;
            // Создание объекта базового класса.
            FractalBase fractal = new Kantor();
            fractal._graph = Graphics.FromImage(FractalBase.bmp);
            fractal.Draw(x1, x2, y, 0);
            pictureBox1.Image = FractalBase.bmp;
        }
        /// <summary>
        /// Метод, осуществляющий вызов функционала рисования Треугольника Серпинского.
        /// </summary>
        private void TriangelDraw()
        {
            // Первоначальные координаты.
            float x1 = pictureBox1.Width*4/5;
            float x2 = pictureBox1.Width/2;
            float x3 = pictureBox1.Width/5;
            float y1 = pictureBox1.Height-20;
            float y2 = 20;
            float y3 = pictureBox1.Height-20;
            int n = FractalBase.iteration;

            // Создание объекта класса.
            FractalBase fractal = new Triangle();

            fractal._graph = Graphics.FromImage(FractalBase.bmp);

            // Вызов метода рисования.
            fractal.Draw(x1, y1, x2, y2, x3, y3, n);
            pictureBox1.Image = FractalBase.bmp;
        }
        /// <summary>
        /// Метод, осуществляющий вызов функционала рисования ковра Серпинского.
        /// </summary>
        private void CarpetDraw()
        {
            // Проверка итераций на коррекность.
            if (FractalBase.iteration == 0) 
            { 
                FractalBase.iteration = 1; 
            }
            // Создаем прямоугольник.
            RectangleF carpet = new RectangleF(0, 0, pictureBox1.Width, pictureBox1.Height);

            // Создание объекта класса.
            FractalBase fractal = new Carpet();
            fractal._graph = Graphics.FromImage(FractalBase.bmp);

            // Вызов метода рисования.
            fractal.Draw(FractalBase.iteration, carpet);
            // Отображаем результат.
            pictureBox1.Image = FractalBase.bmp;
        }
        /// <summary>
        /// Метод, осуществляющий вызов функционала рисования кривой Коха.
        /// </summary>
        private void CurveDraw()
        {
            //Определяем объект "g" класса Graphics.
            Graphics g = FractalBase.g;
            //Определим координаты исходного треугольника.
            var point1 = new PointF(10, pictureBox1.Height*3/4);
            var point2 = new PointF(pictureBox1.Width-10, pictureBox1.Height * 3 / 4);
            var point3 = new PointF(pictureBox1.Width/2, 1000);
            Pen pen1 = new Pen(FractalBase.colorList[0], 3);

            // Создание объекта базового класса.
            FractalBase fractal = new Curve();
            fractal._graph = Graphics.FromImage(FractalBase.bmp);

            //Зарисуем треугольник
            fractal._graph.DrawLine(pen1, point1, point2);
            g.DrawLine(pen1, point1, point2);
            //g.DrawLine(pen1, point2, point3);
            //g.DrawLine(pen1, point3, point1);
            if (FractalBase.iteration != 0)
            {
                // Вызываем функцию для того, чтобы нарисовать кривую.
                fractal.Draw(point1, point2, point3, FractalBase.iteration, 1);
            }
            pictureBox1.Image = FractalBase.bmp;
            //Curve.Fractal(point2, point3, point1, 5,e);
            //Curve.Fractal(point3, point1, point2, 5,e);            
        }
        /// <summary>
        /// Метод для зума (приближения и отдаления изображения).
        /// </summary>
        /// <param name="img"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        Image ZoomPicture(Image img,Size size)
        {
            Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * size.Width), Convert.ToInt32(img.Height * size.Height));
            Graphics gpu = Graphics.FromImage(bm);
            gpu.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bm;
        }
        // Объявление объекта класса PictureBox.
        PictureBox org;
        /// <summary>
        /// Метод, обрабатывающий события при загрузке формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Painting_Load(object sender, EventArgs e)
        {
            panel1.DockPadding.All = 30;
            // Поверка на корректность коэффициента дерева.
            if (FractalBase.coeff < Tree.minCoeff)
            {
                FractalBase.coeff = Tree.minCoeff;
            }
            if (FractalBase.iteration > FractalBase.maxIteration)
            {
                FractalBase.iteration = FractalBase.maxIteration;
            }
            // Инициализорование статического поля базового класса.
            FractalBase.bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            // Задание параметов trackBar.
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 6;
            trackBar1.SmallChange = 1;
            trackBar1.LargeChange = 1;
            trackBar1.UseWaitCursor = false;
            this.DoubleBuffered = true;
            org = new PictureBox();
            // Вызов метода создания градиента.
            CreateColorList();
        }
        /// <summary>
        /// метод, сохдающий градиент, записывает цвета в список.
        /// </summary>
        private void CreateColorList()
        {
            FractalBase.colorList = new List<Color>();
            int size = FractalBase.iteration;
            int rMax = FractalBase.colorEnd.R;
            int rMin = FractalBase.colorStart.R;
            int gMax = FractalBase.colorEnd.G;
            int gMin = FractalBase.colorStart.G;
            int bMax = FractalBase.colorEnd.B;
            int bMin = FractalBase.colorStart.B;
            if (size != 0)
            {
                for (int i = 0; i <= size; i++)
                {
                    var rAverage = rMin + (int)((rMax - rMin) * i / size);
                    var gAverage = gMin + (int)((gMax - gMin) * i / size);
                    var bAverage = bMin + (int)((bMax - bMin) * i / size);
                    FractalBase.colorList.Add(Color.FromArgb(rAverage, gAverage, bAverage));
                }
            }
            else
            {
                FractalBase.colorList.Add(FractalBase.colorStart);
            }
        }
        /// <summary>
        /// Метод, обрабатывющий действия с trackBar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value != 0)
            {
                pictureBox1.Image = null;
                // Использование ранне заданного метода зума изображения.
                pictureBox1.Image = ZoomPicture(org.Image, new Size(trackBar1.Value, trackBar1.Value));
            }
        }
        // Набор переменных для функционирования метода для перемещения изображения.
        bool check;
        int offsetX = 0;
        int offsetY = 0;
        // Метод, перемещающий изображение (pictureBox) внитри панели.
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (check)
            {
                int x = Cursor.Position.X - (this.Left + (this.Size.Width - this.ClientSize.Width) / 2) - offsetX;
                int y = Cursor.Position.Y - (this.Top + (this.Size.Height - this.ClientSize.Height - 4)) - offsetY;
                if (x > 0 && x < this.ClientSize.Width - pictureBox1.Width)
                    pictureBox1.Left = x;
                else
                    pictureBox1.Left = x > 0 ? x = this.ClientSize.Width - pictureBox1.Width : 0;
                if (y > 0 && y < this.ClientSize.Height - pictureBox1.Height)
                    pictureBox1.Top = y;
                else
                    pictureBox1.Top = y > 0 ? y = this.ClientSize.Height - pictureBox1.Height : 0;
            }
        }
        /// <summary>
        /// Обработка события подЪема клавиши мыши.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            check = false;
        }
        /// <summary>
        /// Обработка события подъема кнопки мыши.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            check = true;
        }
        /// <summary>
        /// Метод, обрабатывающий события на нажатие кнопки сохранения фрактала.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Save file dialogs methods.
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить картинку как...";
                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;
                sfd.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.PNG)|*.PNG|All Files(*.*)|*.*";
                sfd.ShowHelp = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image.Save(sfd.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        /// <summary>
        /// Обработка события на нажате кнопи выход.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
