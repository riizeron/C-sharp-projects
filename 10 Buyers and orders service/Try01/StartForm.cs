using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;

namespace Try01
{
    /// <summary>
    /// Стартовая форма.
    /// Главная форма.
    /// Осуществляется регистрация и авторизация пользователей.
    /// </summary>
    public partial class StartForm : Form
    {
        string clientOrSeller;
        public StartForm()
        {
            InitializeComponent();
            Loading();
        }
        /// <summary>
        /// Вызов формы регистрации для пользователя.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            RegisterationForm regForm = new RegisterationForm(button3.Text);
            regForm.Activate();
            regForm.Visible = true;
        }
        /// <summary>
        /// Вызов формы регистрации для продавца.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            RegisterationForm regForm = new RegisterationForm(button4.Text);
            regForm.Activate();
            regForm.Visible = true;
        }
        /// <summary>
        /// Далее события, скрывающие элементы, в которых нет необходимости.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            clientOrSeller = "client";
            label3.Visible = true;
            label4.Visible = true;
            button5.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button6.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            label2.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            label1.Text = "Авторизация как пользователь";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clientOrSeller = "seller";
            label3.Visible = true;
            label4.Visible = true;
            button5.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button6.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            label2.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
            label1.Text = "Авторизация как продавец";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HideElements();
        }
        /// <summary>
        /// События, осуществляющее авторизацию.
        /// Да, большой, а куда деваться.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            switch (clientOrSeller)
            {
                case "client":
                    foreach (Client cl in Client.clients)
                    {
                        if (textBox1.Text == cl.Email)
                        {
                            if (textBox2.Text == cl.Password)
                            {
                                HideElements();
                                ClientForm newClientForm = new ClientForm(cl, this);
                                newClientForm.Activate();
                                newClientForm.Visible = true;
                                Hide();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Пароль неверен", "Ошибка");
                                return;
                            }
                        }
                    }
                    MessageBox.Show("Пользователя с таким логином не существует", "Ошибка");
                    break;
                case "seller":
                    foreach (Seller sel in Seller.sellers)
                    {
                        if (textBox1.Text == sel.Email)
                        {
                            if (textBox2.Text == sel.Password)
                            {
                                HideElements();
                                SellerForm newSellerForm = new SellerForm(this);
                                newSellerForm.Activate();
                                newSellerForm.Visible = true;
                                Hide();
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Пароль неверен", "Ошибка");
                                return;
                            }
                        }
                    }
                    MessageBox.Show("Продавца с таким логином не существует", "Ошибка");
                    break;
            }
        }
        /// <summary>
        /// Сериализация.
        /// Xml.
        /// Надеюсь ссылка на расширение с Xml сериализацией сработает как надо.
        /// Просто я проверял, к меня все работает.
        /// </summary>
        public static void Saving()
        {
            var dcss = new DataContractSerializerSettings { PreserveObjectReferences = true };
            try
            {
                var dcs = new DataContractSerializer(typeof(List<Order>), dcss);
                using (Stream fStream = new FileStream("Orders", FileMode.Create))
                {
                    dcs.WriteObject(fStream, Order.orders);
                }
                dcs = new DataContractSerializer(typeof(List<Product>), dcss);
                using (Stream fStream = new FileStream("Products", FileMode.Create))
                {
                    dcs.WriteObject(fStream, Product.products);
                }
                dcs = new DataContractSerializer(typeof(List<Seller>), dcss);
                using (Stream fStream = new FileStream("Sellers", FileMode.Create))
                {
                    dcs.WriteObject(fStream, Seller.sellers);
                }
                dcs = new DataContractSerializer(typeof(List<Client>), dcss);
                using (Stream fStream = new FileStream("Clients", FileMode.Create))
                {
                    dcs.WriteObject(fStream, Client.clients);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Соответственно, десериализация.
        /// </summary>
        public static void Loading()
        {
            try
            {
                using (XmlReader fStream = XmlReader.Create("Orders"))
                {
                    DataContractSerializer dsg = new DataContractSerializer(typeof(List<Order>));
                    Order.orders = (List<Order>)dsg.ReadObject(fStream);
                }
                using (XmlReader fStream = XmlReader.Create("Products"))
                {
                    DataContractSerializer dsg = new DataContractSerializer(typeof(List<Product>));
                    Product.products = (List<Product>)dsg.ReadObject(fStream);
                }
                using (XmlReader fStream = XmlReader.Create("Sellers"))
                {
                    DataContractSerializer dsg = new DataContractSerializer(typeof(List<Seller>));
                    Seller.sellers = (List<Seller>)dsg.ReadObject(fStream);
                }
                using (XmlReader fStream = XmlReader.Create("Clients"))
                {
                    DataContractSerializer dsg = new DataContractSerializer(typeof(List<Client>));
                    Client.clients = (List<Client>)dsg.ReadObject(fStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        /// <summary>
        /// Автосохранение при выхода из программы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Saving();
        }
        /// <summary>
        /// Метод, прячущий ненужные элементы.
        /// </summary>
        private void HideElements()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            label3.Visible = false;
            label4.Visible = false;
            button5.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            button6.Visible = false;
            button3.Visible = true;
            button4.Visible = true;
            label2.Visible = true;
            button2.Visible = true;
            button1.Visible = true;
            label1.Text = "Авторизация как";
        }
    }
}
