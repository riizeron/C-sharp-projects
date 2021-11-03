using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Try01
{
    /// <summary>
    /// Форма клиента.
    /// </summary>
    public partial class ClientForm : Form
    {
        Client client;
        StartForm sf;
        public ClientForm()
        {
            InitializeComponent();
        }
        public ClientForm(Client client, StartForm sf)
        {
            InitializeComponent();
            this.client = client;
            this.sf = sf;
            AddProductToListView();
        }
        /// <summary>
        /// Метод, добавляющий товары в listView со всеми товарами.
        /// </summary>
        public void AddProductToListView()
        {
            listView1.Items.Clear();
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item;

            foreach (Product pr in Product.products)
            {
                item = new ListViewItem(pr.Name, 1);
                item.Tag = pr;
                subItems = new ListViewItem.ListViewSubItem[]
                    {   new ListViewItem.ListViewSubItem(item,pr.Price.ToString())};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        /// <summary>
        /// Метод, добавляющий товар в корзину.
        /// В listView слева.
        /// </summary>
        public void AddProductToOrder()
        {
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem newItem;

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                Product pr = (Product)item.Tag;
                newItem = new ListViewItem(pr.Name, 1);
                newItem.Tag = pr;
                subItems = new ListViewItem.ListViewSubItem[]
                    {   new ListViewItem.ListViewSubItem(newItem,pr.Price.ToString())};
                newItem.SubItems.AddRange(subItems);
                listView2.Items.Add(newItem);
            }
            listView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        /// <summary>
        /// Обработчик кнопки, с помощью которой происходит вызов метода добавления товара в корзину.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void добавитьВЗаказToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems == null || listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите товар", "Ошибка");
            }
            else
            {
                List<Product> products = new List<Product>();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    products.Add((Product)item.Tag);
                }
                //Order newOrder = new Order(client, products);
                //client.orders.Add(newOrder);
                AddProductToOrder();
            }
        }
        /// <summary>
        /// Удаление товара из корзины.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void удалитьИзЗаказаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems == null || listView2.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите товар", "Ошибка");
            }
            else
            {
                foreach (ListViewItem item in listView2.SelectedItems)
                {
                    listView2.Items.Remove(item);
                }
            }
        }
        /// <summary>
        /// Кнопка выхода из функционала клиента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            sf.Show();
        }
        /// <summary>
        /// При закрытии формы, главная форма с авторизацией появляется.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sf.Show();
        }
        /// <summary>
        /// Оформление заказа из товаров в корзине.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сформироватьЗаказToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView2.Items == null || listView2.Items.Count == 0)
            {
                MessageBox.Show("Корзина пуста", "Ошибка");
            }
            else
            {
                List<Product> products = new List<Product>();
                foreach (ListViewItem item in listView2.Items)
                {
                    products.Add((Product)item.Tag);
                }
                Order newOrder = new Order(client, products);
                MessageBox.Show($"Заказ {newOrder.Number} сформирован", "Готово");
                listView2.Items.Clear();
            }
        }
        /// <summary>
        /// Просмотр всех заказов клиента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void показатьЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrdersForm ordersForm = new ShowOrdersForm(client);
            ordersForm.Text = "Заказы";
            MenuStrip menuStrip = ordersForm.Controls[1] as MenuStrip;
            menuStrip.Items.RemoveAt(2);
            ordersForm.Activate();
            ordersForm.Visible = true;
        }
    }
}
