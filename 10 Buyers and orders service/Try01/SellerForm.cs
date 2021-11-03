using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Try01
{
    /// <summary>
    /// Форма с функционалом продавца.
    /// </summary>
    public partial class SellerForm : Form
    {
        /// <summary>
        /// Главная форма.
        /// </summary>
        StartForm sf;

        public SellerForm()
        {
            InitializeComponent();
        }
        public SellerForm(StartForm sf)
        {
            InitializeComponent();
            this.sf = sf;
            AddProductToListView();
        }
        /// <summary>
        /// Кнопа добавления товара.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void добавитьТоварToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProductForm productForm = new AddProductForm(this);
            productForm.Activate();
            productForm.Visible = true;
        }
        /// <summary>
        /// Метод, добавляющий продукты в listView.
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
        /// Метод, удаляющий товары из списка товаров и из listView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void удалитьТоварToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems == null || listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите товар", "Ошибка");
            }
            else
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    Product.products.Remove((Product)item.Tag);
                }
                AddProductToListView();
            }
        }

        /// <summary>
        /// Кнопка возварата к авторизации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
            sf.Show();
        }

        private void SellerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            sf.Show();
        }
        /// <summary>
        /// Вызов формы с отображением всех клиентов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowClientsForm clientsForm = new ShowClientsForm();
            clientsForm.Activate();
            clientsForm.Visible = true;
        }

        /// <summary>
        /// Вызов формы с отображением всех исполненных заказов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void исполненныеЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowExecutedOrders executedOrders = new ShowExecutedOrders();
            executedOrders.Activate();
            executedOrders.Visible = true;
        }
        /// <summary>
        /// Вызов формы с отображанием абсолютно всех заказов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void заказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOrdersForm ordersForm = new ShowOrdersForm();
            ordersForm.Text = $"Все заказы";
            MenuStrip menuStrip = (MenuStrip)ordersForm.Controls[1];
            menuStrip.Items.RemoveAt(0);
            menuStrip.Items.RemoveAt(0);
            ordersForm.Activate();
            ordersForm.Visible = true;
        }
    }
}
