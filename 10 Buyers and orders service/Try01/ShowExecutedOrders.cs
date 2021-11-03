using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Try01
{
    /// <summary>
    /// AФорма, отображающая только исполненные заказы.
    /// </summary>
    public partial class ShowExecutedOrders : Form
    {
        public ShowExecutedOrders()
        {
            InitializeComponent();
            AddExecutedOrders();
        }
        /// <summary>
        /// Метод, добавляющий заказы в listView.
        /// </summary>
        public void AddExecutedOrders()
        {
            listView1.Items.Clear();
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item;

            foreach (Order ord in Order.orders)
            {
                if ((ord.Status & Status.Paid) == Status.Paid)
                {
                    item = new ListViewItem(ord.Number.ToString(), 1);
                    item.Tag = ord;
                    subItems = new ListViewItem.ListViewSubItem[]
                        {   new ListViewItem.ListViewSubItem(item,ord.Price.ToString()),
                        new ListViewItem.ListViewSubItem(item,ord.Status.ToString()),
                        new ListViewItem.ListViewSubItem(item,ord.Client.Email)};
                    item.SubItems.AddRange(subItems);
                    listView1.Items.Add(item);
                }
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
