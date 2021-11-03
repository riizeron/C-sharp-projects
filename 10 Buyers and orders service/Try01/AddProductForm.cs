using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Try01
{
    public partial class AddProductForm : Form
    {
        SellerForm sellerForm;
        public AddProductForm()
        {
            InitializeComponent();
        }
        public AddProductForm(SellerForm sellerForm)
        {
            InitializeComponent();
            this.sellerForm = sellerForm;
        }
        /// <summary>
        /// Методы, предназначенные для записи в текстбоксы только корректных значений.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '1') && (e.KeyChar <= '9'))
            {
                return;
            }
            else if (e.KeyChar == '0')
            {
                if (textBox2.Text.Length == 0)
                {
                    e.Handled = true;
                }
                else
                {
                    return;
                }
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    textBox2.Focus();
                }
                return;
            }
            return;
        }
        /// <summary>
        /// Создание товара и добавление его в listView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0)
            {
                MessageBox.Show("Заполните все поля", "Ошибка");
            }
            else
            {
                Product newProduct = new Product(textBox1.Text, int.Parse(textBox2.Text));
                Close();
                sellerForm.AddProductToListView();
            }
        }
    }
}
