
namespace Try01
{
    partial class ClientForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.добавитьВЗаказToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьИзЗаказаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьЗаказToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьЗаказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьВЗаказToolStripMenuItem,
            this.удалитьИзЗаказаToolStripMenuItem,
            this.сформироватьЗаказToolStripMenuItem,
            this.показатьЗаказыToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // добавитьВЗаказToolStripMenuItem
            // 
            this.добавитьВЗаказToolStripMenuItem.Name = "добавитьВЗаказToolStripMenuItem";
            this.добавитьВЗаказToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.добавитьВЗаказToolStripMenuItem.Text = "Добавить в заказ";
            this.добавитьВЗаказToolStripMenuItem.Click += new System.EventHandler(this.добавитьВЗаказToolStripMenuItem_Click);
            // 
            // удалитьИзЗаказаToolStripMenuItem
            // 
            this.удалитьИзЗаказаToolStripMenuItem.Name = "удалитьИзЗаказаToolStripMenuItem";
            this.удалитьИзЗаказаToolStripMenuItem.Size = new System.Drawing.Size(115, 20);
            this.удалитьИзЗаказаToolStripMenuItem.Text = "Удалить из заказа";
            this.удалитьИзЗаказаToolStripMenuItem.Click += new System.EventHandler(this.удалитьИзЗаказаToolStripMenuItem_Click);
            // 
            // сформироватьЗаказToolStripMenuItem
            // 
            this.сформироватьЗаказToolStripMenuItem.Name = "сформироватьЗаказToolStripMenuItem";
            this.сформироватьЗаказToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.сформироватьЗаказToolStripMenuItem.Text = "Сформировать заказ";
            this.сформироватьЗаказToolStripMenuItem.Click += new System.EventHandler(this.сформироватьЗаказToolStripMenuItem_Click);
            // 
            // показатьЗаказыToolStripMenuItem
            // 
            this.показатьЗаказыToolStripMenuItem.Name = "показатьЗаказыToolStripMenuItem";
            this.показатьЗаказыToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.показатьЗаказыToolStripMenuItem.Text = "Заказы";
            this.показатьЗаказыToolStripMenuItem.Click += new System.EventHandler(this.показатьЗаказыToolStripMenuItem_Click);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 426);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 1;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader8});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(266, 426);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Наименование";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Цена";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(530, 426);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Наименование";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Цена";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьВЗаказToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьИзЗаказаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сформироватьЗаказToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ToolStripMenuItem показатьЗаказыToolStripMenuItem;
    }
}

