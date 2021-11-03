using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Try01
{
    public partial class RegisterationForm : Form
    {
        string clientOrSeller;
        public RegisterationForm()
        {
            InitializeComponent();
        }
        public RegisterationForm(string clientorSeller)
        {
            InitializeComponent();
            this.clientOrSeller = clientorSeller;
        }
        /// <summary>
        /// Далее методы для ввода только корректных данных в текстбоксы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A') && (e.KeyChar <= 'Z') || (e.KeyChar >= 'a') && (e.KeyChar <= 'z'))
            {
                return;
            }
            else if (e.KeyChar == ' ')
            {
                if (textBox1.Text.Length == 0)
                {
                    e.Handled = true;
                }
                else if (textBox1.Text.Last() == ' ')
                {
                    e.Handled = true;
                }
                return;
            }
            else if (Char.IsControl(e.KeyChar))
            {

                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (textBox1.Text.Length != 0 && textBox1.Text.Last() == ' ')
                    {
                        textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                    }
                    textBox2.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9') || e.KeyChar == '+')
            {
                return;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    textBox3.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A') && (e.KeyChar <= 'Z') || (e.KeyChar >= 'a') && (e.KeyChar <= 'z')
                || (e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            else if ((e.KeyChar == ' ') || (e.KeyChar == ',') || (e.KeyChar == '.'))
            {
                if (textBox3.Text.Length == 0)
                {
                    e.Handled = true;
                }
                else if (textBox3.Text.Last() == ' '
                    || textBox3.Text.Last() == ','
                    || textBox3.Text.Last() == '.')
                {
                    e.Handled = true;
                }
                return;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (textBox3.Text.Length != 0 && (textBox3.Text.Last() == ' '
                        || textBox3.Text.Last() == ','))
                    {
                        textBox3.Text = textBox3.Text.Remove(textBox3.Text.Length - 1);
                    }
                    textBox4.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A') && (e.KeyChar <= 'Z') || (e.KeyChar >= 'a') && (e.KeyChar <= 'z')
                || e.KeyChar == '_' || (e.KeyChar >= '0' && e.KeyChar <= '9'))
            {
                return;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    textBox5.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A') && (e.KeyChar <= 'Z') || (e.KeyChar >= 'a') && (e.KeyChar <= 'z')
                || e.KeyChar == '_' || (e.KeyChar >= '0' && e.KeyChar <= '9'))
            {
                return;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    textBox6.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A') && (e.KeyChar <= 'Z') || (e.KeyChar >= 'a') && (e.KeyChar <= 'z')
                || e.KeyChar == '_' || (e.KeyChar >= '0' && e.KeyChar <= '9'))
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
        /// Кнопка, осуществляющая функционал регистрации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != textBox6.Text)
            {
                MessageBox.Show("Пароли не совпадают", "Ошибка");
            }
            else if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0
                || textBox3.Text.Length == 0 || textBox4.Text.Length == 0
                || textBox5.Text.Length == 0 || textBox6.Text.Length == 0)
            {
                MessageBox.Show("Заполните все поля", "Ошибка");
            }
            else if (Client.emails.Contains(textBox3.Text))
            {
                MessageBox.Show("Пользователь с таким логином уже зарегистрирован", "Ошибка");
            }
            else
            {
                if (clientOrSeller == "Пользователя")
                {
                    Client newClient = new Client(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                        textBox5.Text);
                    MessageBox.Show("Пользователь успешно зарегистрирован", "Регистрация");
                }
                else
                {
                    Seller newSeller = new Seller(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                        textBox5.Text);
                    MessageBox.Show("Продавец успешно зарегистрирован", "Регистрация");
                }
                Close();
            }
        }
    }
}

