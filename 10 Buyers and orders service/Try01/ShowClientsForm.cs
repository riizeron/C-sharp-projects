using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Try01
{
    /// <summary>
    /// Форма показа всех клиентов.
    /// </summary>
    public partial class ShowClientsForm : Form
    {
        public ShowClientsForm()
        {
            InitializeComponent();
            AddClientsToListView();
        }
        /// <summary>
        /// Добавление клиентов в listView.
        /// </summary>
        private void AddClientsToListView()
        {
            listView1.Items.Clear();
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item;

            foreach (Client client in Client.clients)
            {
                item = new ListViewItem(client.FIO, 1);
                item.Tag = client;
                subItems = new ListViewItem.ListViewSubItem[]
                    {   new ListViewItem.ListViewSubItem(item,client.Email),
                        new ListViewItem.ListViewSubItem(item,client.Phone)};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        /// <summary>
        /// Просмотр заказов выбранного клиента.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void просмотретьЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems == null || listView1.SelectedItems.Count > 1
                || listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите одного клиента", "Ошибка");
            }
            else
            {
                Client client = (Client)listView1.SelectedItems[0].Tag;
                ShowOrdersForm ordersForm = new ShowOrdersForm(client);
                ordersForm.Text = $"Заказы клиента {client.FIO}";
                MenuStrip menuStrip = (MenuStrip)ordersForm.Controls[1];
                menuStrip.Items.RemoveAt(0);
                menuStrip.Items.RemoveAt(0);
                ordersForm.Activate();
                ordersForm.Visible = true;
            }
        }
    }
}
