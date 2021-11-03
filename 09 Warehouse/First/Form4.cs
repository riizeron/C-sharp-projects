using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace First
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Кнопка, вносящая изменения в настройки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form1.minAmount = int.Parse(textBox1.Text.Length == 0 ? "0" : textBox1.Text);
            Form1.csvPath = textBox2.Text;
            this.Close();
        }
        /// <summary>
        /// KeyPress для запрета ввода некорректной информации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button1.Focus();
                }
                return;
            }
            e.Handled = true;
        }
        /// <summary>
        /// Вызов SaveFileDialog для задания пути для csv файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = $"Сохранить отчет как...";
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            sfd.Filter = "Csv Files(*.csv)|*.csv";
            sfd.ShowHelp = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = sfd.FileName;
            }
        }
    }
}
