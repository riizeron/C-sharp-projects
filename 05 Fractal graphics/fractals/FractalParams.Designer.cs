namespace fractals
{
    partial class FractalParams
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelIteration = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textCoeff = new System.Windows.Forms.TextBox();
            this.labelCoeff = new System.Windows.Forms.Label();
            this.textLen = new System.Windows.Forms.TextBox();
            this.labelLen = new System.Windows.Forms.Label();
            this.textAngel1 = new System.Windows.Forms.TextBox();
            this.labelAngel1 = new System.Windows.Forms.Label();
            this.textAngel2 = new System.Windows.Forms.TextBox();
            this.labelAngel2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(297, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Параметры фрактала";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "градиент";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "начало";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "конец";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(27, 211);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 59);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(144, 211);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 59);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(12, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Location = new System.Drawing.Point(144, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Выбрать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelIteration
            // 
            this.labelIteration.AutoSize = true;
            this.labelIteration.Location = new System.Drawing.Point(565, 132);
            this.labelIteration.Name = "labelIteration";
            this.labelIteration.Size = new System.Drawing.Size(168, 30);
            this.labelIteration.TabIndex = 8;
            this.labelIteration.Text = "Колличество итераций\r\n(максимальное значение - 7)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(565, 187);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 9;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonContinue.Location = new System.Drawing.Point(308, 374);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(87, 23);
            this.buttonContinue.TabIndex = 10;
            this.buttonContinue.Text = "Продолжить";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.Location = new System.Drawing.Point(589, 373);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 11;
            this.buttonBack.Text = "назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(565, 270);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 12;
            this.textBox2.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(565, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Введите расстояние между линиями";
            this.label6.Visible = false;
            // 
            // textCoeff
            // 
            this.textCoeff.Location = new System.Drawing.Point(589, 156);
            this.textCoeff.Name = "textCoeff";
            this.textCoeff.Size = new System.Drawing.Size(100, 23);
            this.textCoeff.TabIndex = 14;
            this.textCoeff.Visible = false;
            this.textCoeff.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCoeff_KeyPress);
            // 
            // labelCoeff
            // 
            this.labelCoeff.AutoSize = true;
            this.labelCoeff.Location = new System.Drawing.Point(389, 156);
            this.labelCoeff.Name = "labelCoeff";
            this.labelCoeff.Size = new System.Drawing.Size(170, 45);
            this.labelCoeff.TabIndex = 15;
            this.labelCoeff.Text = "Введите коэффициент \r\nотношения между отрезками\r\n(от 1,3)";
            this.labelCoeff.Visible = false;
            // 
            // textLen
            // 
            this.textLen.Location = new System.Drawing.Point(589, 216);
            this.textLen.Name = "textLen";
            this.textLen.Size = new System.Drawing.Size(100, 23);
            this.textLen.TabIndex = 16;
            this.textLen.Visible = false;
            this.textLen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textLen_KeyPress);
            // 
            // labelLen
            // 
            this.labelLen.AutoSize = true;
            this.labelLen.Location = new System.Drawing.Point(389, 211);
            this.labelLen.Name = "labelLen";
            this.labelLen.Size = new System.Drawing.Size(169, 45);
            this.labelLen.TabIndex = 17;
            this.labelLen.Text = "Введите длину первого \r\nотрезка (в пикселях, \r\nжелательно до 150 пикселей)";
            this.labelLen.Visible = false;
            // 
            // textAngel1
            // 
            this.textAngel1.Location = new System.Drawing.Point(589, 262);
            this.textAngel1.Name = "textAngel1";
            this.textAngel1.Size = new System.Drawing.Size(100, 23);
            this.textAngel1.TabIndex = 18;
            this.textAngel1.Visible = false;
            this.textAngel1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAngel1_KeyPress);
            // 
            // labelAngel1
            // 
            this.labelAngel1.AutoSize = true;
            this.labelAngel1.Location = new System.Drawing.Point(389, 270);
            this.labelAngel1.Name = "labelAngel1";
            this.labelAngel1.Size = new System.Drawing.Size(87, 15);
            this.labelAngel1.TabIndex = 19;
            this.labelAngel1.Text = "Введите угол 1";
            this.labelAngel1.Visible = false;
            // 
            // textAngel2
            // 
            this.textAngel2.Location = new System.Drawing.Point(589, 306);
            this.textAngel2.Name = "textAngel2";
            this.textAngel2.Size = new System.Drawing.Size(100, 23);
            this.textAngel2.TabIndex = 20;
            this.textAngel2.Visible = false;
            this.textAngel2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textAngel2_KeyPress);
            // 
            // labelAngel2
            // 
            this.labelAngel2.AutoSize = true;
            this.labelAngel2.Location = new System.Drawing.Point(389, 314);
            this.labelAngel2.Name = "labelAngel2";
            this.labelAngel2.Size = new System.Drawing.Size(87, 15);
            this.labelAngel2.TabIndex = 21;
            this.labelAngel2.Text = "Введите угол 2";
            this.labelAngel2.Visible = false;
            // 
            // FractalParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelAngel2);
            this.Controls.Add(this.textAngel2);
            this.Controls.Add(this.labelAngel1);
            this.Controls.Add(this.textAngel1);
            this.Controls.Add(this.labelLen);
            this.Controls.Add(this.textLen);
            this.Controls.Add(this.labelCoeff);
            this.Controls.Add(this.textCoeff);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labelIteration);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FractalParams";
            this.Text = "FractalParams";
            this.Load += new System.EventHandler(this.KochParams_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelIteration;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textCoeff;
        private System.Windows.Forms.Label labelCoeff;
        private System.Windows.Forms.TextBox textLen;
        private System.Windows.Forms.Label labelLen;
        private System.Windows.Forms.TextBox textAngel1;
        private System.Windows.Forms.Label labelAngel1;
        private System.Windows.Forms.TextBox textAngel2;
        private System.Windows.Forms.Label labelAngel2;
    }
}