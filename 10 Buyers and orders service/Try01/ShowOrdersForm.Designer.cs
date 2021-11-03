
namespace Try01
{
    partial class ShowOrdersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.оплатитьЗаказToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьЗаказToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьСтатусToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.обработанToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отгруженToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполненToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оплатитьЗаказToolStripMenuItem,
            this.удалитьЗаказToolStripMenuItem,
            this.изменитьСтатусToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(611, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // оплатитьЗаказToolStripMenuItem
            // 
            this.оплатитьЗаказToolStripMenuItem.Name = "оплатитьЗаказToolStripMenuItem";
            this.оплатитьЗаказToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.оплатитьЗаказToolStripMenuItem.Text = "Оплатить  заказ";
            this.оплатитьЗаказToolStripMenuItem.Click += new System.EventHandler(this.оплатитьЗаказToolStripMenuItem_Click);
            // 
            // удалитьЗаказToolStripMenuItem
            // 
            this.удалитьЗаказToolStripMenuItem.Name = "удалитьЗаказToolStripMenuItem";
            this.удалитьЗаказToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.удалитьЗаказToolStripMenuItem.Text = "Удалить заказ";
            this.удалитьЗаказToolStripMenuItem.Click += new System.EventHandler(this.удалитьЗаказToolStripMenuItem_Click);
            // 
            // изменитьСтатусToolStripMenuItem
            // 
            this.изменитьСтатусToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обработанToolStripMenuItem,
            this.отгруженToolStripMenuItem,
            this.исполненToolStripMenuItem});
            this.изменитьСтатусToolStripMenuItem.Name = "изменитьСтатусToolStripMenuItem";
            this.изменитьСтатусToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.изменитьСтатусToolStripMenuItem.Text = "Статус";
            this.изменитьСтатусToolStripMenuItem.Click += new System.EventHandler(this.изменитьСтатусToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(611, 355);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Номер";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Цена";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Статус";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Клиент";
            // 
            // обработанToolStripMenuItem
            // 
            this.обработанToolStripMenuItem.Name = "обработанToolStripMenuItem";
            this.обработанToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.обработанToolStripMenuItem.Text = "Обработан";
            this.обработанToolStripMenuItem.Click += new System.EventHandler(this.обработанToolStripMenuItem_Click);
            // 
            // отгруженToolStripMenuItem
            // 
            this.отгруженToolStripMenuItem.Name = "отгруженToolStripMenuItem";
            this.отгруженToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.отгруженToolStripMenuItem.Text = "Отгружен";
            this.отгруженToolStripMenuItem.Click += new System.EventHandler(this.отгруженToolStripMenuItem_Click);
            // 
            // исполненToolStripMenuItem
            // 
            this.исполненToolStripMenuItem.Name = "исполненToolStripMenuItem";
            this.исполненToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.исполненToolStripMenuItem.Text = "Исполнен";
            this.исполненToolStripMenuItem.Click += new System.EventHandler(this.исполненToolStripMenuItem_Click);
            // 
            // ShowOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 379);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ShowOrdersForm";
            this.Text = "ShowOrders";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ToolStripMenuItem удалитьЗаказToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripMenuItem оплатитьЗаказToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem изменитьСтатусToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обработанToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отгруженToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исполненToolStripMenuItem;
    }
}