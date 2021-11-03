using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fractals
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1Label1.Visible = true;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1Label1.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FractalParams fractalParams = new FractalParams();
            FractalBase.numberOfFractal = 1;

            fractalParams.ShowDialog();
        }

        private void buttonKoch_MouseHover(object sender, EventArgs e)
        {
            label3.Visible = true;
        }

        private void buttonKoch_MouseLeave(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void buttonCarpet_MouseHover(object sender, EventArgs e)
        {
            label4.Visible = true;
        }

        private void buttonCarpet_MouseLeave(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void buttonTriangle_MouseHover(object sender, EventArgs e)
        {
            label5.Visible = true;
        }

        private void buttonTriangle_MouseLeave(object sender, EventArgs e)
        {
            label5.Visible = false;
        }

        private void buttonKantor_MouseHover(object sender, EventArgs e)
        {
            label6.Visible = true;
        }

        private void buttonKantor_MouseLeave(object sender, EventArgs e)
        {
            label6.Visible = false;
        }

        private void buttonKoch_Click(object sender, EventArgs e)
        {
            FractalParams koch = new FractalParams();
            FractalBase.numberOfFractal = 2;
            koch.ShowDialog();
        }

        private void buttonCarpet_Click(object sender, EventArgs e)
        {
            FractalParams koch = new FractalParams();
            FractalBase.numberOfFractal = 3;
            koch.ShowDialog();
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            FractalParams koch = new FractalParams();
            FractalBase.numberOfFractal = 4;
            koch.ShowDialog();
        }

        private void buttonKantor_Click(object sender, EventArgs e)
        {
            FractalParams koch = new FractalParams();
            FractalBase.numberOfFractal = 5;
            koch.ShowDialog();
        }
    }
}
