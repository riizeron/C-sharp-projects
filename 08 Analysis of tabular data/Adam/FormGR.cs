using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Adam
{
    public partial class FormGR : Form
    {
        public FormGR()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.SaveImage(Form1.RemoveQuotesFromString(chart1.Titles[0].Text) + ".png", ChartImageFormat.Png);
            MessageBox.Show("График сохранен!");
        }


        private void chart1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            chart1.Series[0].Color = cd.Color;
            Size = new Size(Size.Width-1, Size.Height);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int k = (int)numericUpDown1.Value;
            if (k < 0)
            {
                k = 1 / k;
            }
            chart1.ChartAreas[0].AxisX.Maximum = k;
        }
    }
}
