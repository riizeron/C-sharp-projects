using System;
using System.Linq;
using System.Windows.Forms;

namespace First
{

    public partial class Form2 : Form
    {
        // Поля необходимые для корректной записи изменеий в продукции.
        public string name;
        public string code;
        public string amount;
        public string price;
        Section choosenSection;
        ListViewItem selectedItem;
        ListView listView;
        Product choosenProduct;
        /// <summary>
        /// Данный конструктор вызывается при добавлениии продукта.
        /// </summary>
        /// <param name="choosenSection"> Выбранный раздел для размещения </param>
        public Form2(Section choosenSection)
        {
            InitializeComponent();
            this.choosenSection = choosenSection;
        }
        /// <summary>
        /// А этот, при изменении уже существующего.
        /// </summary>
        /// <param name="listView"> listView с продукцией </param>
        public Form2(ListView listView)
        {
            InitializeComponent();
            this.selectedItem = listView.SelectedItems[0];
            this.choosenProduct = (Product)selectedItem.Tag;
            this.listView = listView;
            name = choosenProduct.Name;
            code = choosenProduct.Code;
            textBox1.Text = choosenProduct.Name;
            textBox2.Text = choosenProduct.Code;
            textBox3.Text = choosenProduct.Amount.ToString();
            textBox4.Text = choosenProduct.Price.ToString();
            button1.Text = "Изменить";
        }
        /// <summary>
        /// Надатие кнопки Изменить или Добавить.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // При изменении
            if (name != null)
            {
                ChangeProduct();
            }
            // При добавление.
            else
            {
                try
                {
                    Product newProduct = new Product(textBox1.Text, textBox2.Text,
                        int.Parse(textBox3.Text.Length == 0 ? "0" : textBox3.Text),
                        double.Parse(textBox4.Text.Length == 0 ? "0" : textBox4.Text), choosenSection);
                    this.Close();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
        }
        /// <summary>
        /// Далее буду обработки событий KeyPress всех текст боксов.
        /// Необходимо, для недопущения ввода некорректной информации в текстбоксы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            else if (e.KeyChar == '-')
            {
                if (textBox2.Text.Length == 0)
                {
                    e.Handled = true;
                }
                else if (textBox2.Text[textBox2.Text.Length - 1] == '-')
                {
                    e.Handled = true;
                }
                return;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (textBox2.Text.Length != 0 && textBox2.Text.Last() == '-')
                {
                    textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                }
                if (e.KeyChar == (char)Keys.Enter)
                {
                    textBox3.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                if (textBox2.Text.Length == 0)
                {
                    e.Handled = true;
                }
                return;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    textBox2.Focus();
                }
                return;
            }
            else { return; }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    textBox4.Focus();
                }
                return;
            }
            e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
            {
                return;
            }
            else if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }
            else if (e.KeyChar == ',')
            {
                if (textBox4.Text.Length == 0)
                {
                    e.Handled = true;
                }
                else if (textBox4.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                }
                else if (textBox4.Text[textBox4.Text.Length - 1] == ',')
                {
                    e.Handled = true;
                }
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
        /// Метод, изменяющий параметры продукта, его поля, свойства.
        /// Трай кэтч можно было бы заменить ифами, но я это так, для разнообразия.
        /// Все зависит от того какой именно параметр изменил пользователь.
        /// </summary>
        private void ChangeProduct()
        {
            try
            {
                choosenProduct.Name = textBox1.Text;
                choosenProduct.Code = textBox2.Text;
                choosenProduct.Amount = int.Parse(textBox3.Text);
                choosenProduct.Price = double.Parse(textBox4.Text);
                Form1.ChangeListView(listView);
                Close();
            }
            catch (ArgumentException ex)
            {
                if (name == textBox1.Text)
                {
                    if (code == textBox2.Text)
                    {
                        choosenProduct.Amount = int.Parse(textBox3.Text);
                        choosenProduct.Price = double.Parse(textBox4.Text);
                        Form1.ChangeListView(listView);
                        Close();
                    }
                    else
                    {
                        choosenProduct.Code = textBox2.Text;
                        choosenProduct.Amount = int.Parse(textBox3.Text);
                        choosenProduct.Price = double.Parse(textBox4.Text);
                        Form1.ChangeListView(listView);
                        Close();
                    }
                }
                else if (code == textBox2.Text)
                {
                    choosenProduct.Amount = int.Parse(textBox3.Text);
                    choosenProduct.Price = double.Parse(textBox4.Text);
                    Form1.ChangeListView(listView);
                    Close();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
        }
    }
}
