using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace fractals
{
    public partial class FractalParams : Form
    {
        public FractalParams()
        {
            InitializeComponent();

           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextBox(e);
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                pictureBox2.BackColor = colorDialog1.Color;
            }
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (FractalBase.numberOfFractal == 1) { }
            if ((pictureBox1.BackColor != Control.DefaultBackColor) && (pictureBox2.BackColor != Control.DefaultBackColor))
            {
                FractalBase.colorStart = pictureBox1.BackColor;
                FractalBase.colorEnd = pictureBox2.BackColor;
                if (FractalBase.numberOfFractal == 1) 
                {
                    if (textAngel1.Text.Length!=0&&textAngel2.Text.Length!=0
                        &&textCoeff.Text.Length!=0&&textLen.Text.Length!=0)
                    {
                        FractalBase.len = int.Parse(textLen.Text);
                        FractalBase.coeff = double.Parse(textCoeff.Text);
                        FractalBase.angel1 = double.Parse(textAngel1.Text);
                        FractalBase.angel2 = double.Parse(textAngel2.Text);
                    }
                    else
                    {
                        check = false;
                    }
                }
                else if (FractalBase.numberOfFractal == 5)
                {
                    if(textBox2.Text.Length != 0&& textBox1.Text.Length != 0)
                    {
                        FractalBase.distance = int.Parse(textBox2.Text);
                        FractalBase.iteration = int.Parse(textBox1.Text);
                    }
                    else
                    {
                        check = false;
                    }
                }
                else
                {
                    if (textBox1.Text.Length != 0)
                    {
                        FractalBase.iteration = int.Parse(textBox1.Text);
                    }
                    else
                    {
                        check = false;
                    }
                }

                if (check==true)
                {
                    Painting coch = new Painting();
                    coch.ShowDialog();
                }
                else { ErorrMessage(); }

            }
            else
            {
                ErorrMessage();
            }
            
        }

        private static void ErorrMessage()
        {
            MessageBox.Show("Задайте все параметры", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void KochParams_Load(object sender, EventArgs e)
        {
            if (FractalBase.numberOfFractal == 5)
            {
                FractalBase f = new Kantor();
                label6.Visible = true;
                textBox2.Visible = true;
            }
            if (FractalBase.numberOfFractal == 1)
            {

                labelAngel1.Visible = true;
                labelAngel2.Visible = true;
                textAngel1.Visible = true;
                textAngel2.Visible = true;
                labelCoeff.Visible = true;
                labelLen.Visible = true;
                textLen.Visible = true;
                textCoeff.Visible = true;
                labelIteration.Visible = false;
                textBox1.Visible = false;
            }
        }

        private void CheckTextBox(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    buttonContinue.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textCoeff_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            if (e.KeyChar == ',')
            {
                if (textCoeff.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                }
                return;
            }
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    buttonContinue.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textLen_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextBox(e);

        }

        private void textAngel1_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextBox(e);
        }

        private void textAngel2_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextBox(e);
        }
    }
}
