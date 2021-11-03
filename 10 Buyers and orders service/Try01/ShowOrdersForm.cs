using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Try01
{
    /// <summary>
    /// Форма отображения всех заказов.
    /// </summary>
    public partial class ShowOrdersForm : Form
    {
        Client client;
        public ShowOrdersForm()
        {
            InitializeComponent();
            AddOrderToListView();
        }
        public ShowOrdersForm(Client client)
        {
            InitializeComponent();
            this.client = client;
            AddOrderToListView();
        }
        /// <summary>
        /// Функционал клиента - удалять заказы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void удалитьЗаказToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems == null || listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите заказ");
            }
            else
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    client.orders.Remove((Order)item.Tag);
                    Order.orders.Remove((Order)item.Tag);
                }
                AddOrderToListView();
            }
        }
        /// <summary>
        /// Метод. добавляющий заказы в listView.
        /// </summary>
        public void AddOrderToListView()
        {
            listView1.Items.Clear();
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item;
            List<Order> orders;
            orders = client == null ? Order.orders : client.orders;
            foreach (Order ord in orders)
            {
                item = new ListViewItem(ord.Number.ToString(), 1);
                item.Tag = ord;
                subItems = new ListViewItem.ListViewSubItem[]
                    {   new ListViewItem.ListViewSubItem(item,ord.Price.ToString()),
                        new ListViewItem.ListViewSubItem(item,ord.Status.ToString()),
                        new ListViewItem.ListViewSubItem(item,ord.Client.FIO)};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        /// <summary>
        /// Работа со статусом заказа и перечислениями.
        /// Проверка на правильный выюор заказа.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void изменитьСтатусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (listView1.SelectedItems.Count == 0 || listView1.SelectedItems.Count > 1
                || listView1.SelectedItems == null)
            {
                foreach (ToolStripMenuItem dropItem in item.DropDownItems)
                {
                    dropItem.Enabled = false;
                }
            }
            else
            {
                foreach (ToolStripMenuItem dropItem in item.DropDownItems)
                {
                    dropItem.Enabled = true;
                }
                Order order = (Order)listView1.SelectedItems[0].Tag;
                if ((order.Status & Status.Proceed) == Status.Proceed)
                {
                    ((ToolStripMenuItem)item.DropDownItems[0]).Checked = true;
                }
                if ((order.Status & Status.Shipped) == Status.Shipped)
                {
                    ((ToolStripMenuItem)item.DropDownItems[1]).Checked = true;
                }
                if ((order.Status & Status.Executed) == Status.Executed)
                {
                    ((ToolStripMenuItem)item.DropDownItems[2]).Checked = true;
                }
            }
        }
        /// <summary>
        /// Далее, события устанавливающие статус заказа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void обработанToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            if (menuItem.Checked == true)
            {
                ((Order)listView1.SelectedItems[0].Tag).Status -= 1;
                menuItem.Checked = false;
            }
            else
            {
                ((Order)listView1.SelectedItems[0].Tag).Status += 1;
                menuItem.Checked = true;
            }
            AddOrderToListView();
        }

        private void исполненToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            Order ord = (Order)listView1.SelectedItems[0].Tag;
            if ((ord.Status & Status.Paid) != Status.Paid)
            {
                MessageBox.Show("Заказ еще не оплачен", "Ошибка");
                return;
            }
            if (menuItem.Checked == true)
            {
                ord.Status -= 8;
                menuItem.Checked = false;
            }
            else
            {
                ord.Status += 8;
                menuItem.Checked = true;
            }
            AddOrderToListView();
        }

        private void отгруженToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            Order ord = (Order)listView1.SelectedItems[0].Tag;
            if ((ord.Status & Status.Paid) != Status.Paid)
            {
                MessageBox.Show("Заказ еще не оплачен", "Ошибка");
                return;
            }
            if (menuItem.Checked == true)
            {
                ord.Status -= 4;
                menuItem.Checked = false;
            }
            else
            {
                ord.Status += 4;
                menuItem.Checked = true;
            }
            AddOrderToListView();
        }
        /// <summary>
        /// Событие оплаты заказа.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void оплатитьЗаказToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems == null || listView1.SelectedItems.Count == 0
                || listView1.SelectedItems.Count > 1)
            {
                MessageBox.Show("Выберите один заказ");
            }
            else
            {
                Order ord = (Order)listView1.SelectedItems[0].Tag;
                if ((ord.Status & Status.Paid) == Status.Paid)
                {
                    MessageBox.Show("Вы уже оплатили этот заказ", "Ошибка");
                }
                else if ((ord.Status & Status.Proceed) == Status.Proceed)
                {
                    ord.Status += 2;
                    MessageBox.Show("Заказ успешно оплачен", "Готово");
                }
                else
                {
                    MessageBox.Show("Заказ еще не обработан", "Ошибка");
                }
                AddOrderToListView();
            }
        }
    }
}

