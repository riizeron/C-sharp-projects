using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Try01.Properties;

namespace Try01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Это для сохранения настроек.
            timer1.Interval = (int)Settings.Default["TimerInterval"];
            foreach(TabPage tp in tabControl1.TabPages)
            {
                ((RichTextBox)tp.Controls[0]).BackColor= (Color)Settings.Default["ColorDesign"];
            }
            this.BackColor = (Color)Settings.Default["ColorDesign"];
        }

        /// <summary>
        ///  Кнопка сохранения файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            // Save file dialogs methods.
            SaveAllMethod(tabControl1.SelectedTab, rtb);
        }

        /// <summary>
        /// Кнопка открытия файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // СОздание объекта через явное преобразование.
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            openFileDialog1.Title = "Открыть текстовый файл как...";
            openFileDialog1.Filter = "Text Files(*.TXT)|*.TXT|Text Files(*.RTF)|*.RTF|All Files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    rtb.LoadFile(openFileDialog1.FileName);
                    // Запись пути к файлу.
                    tabControl1.SelectedTab.Tag = openFileDialog1.FileName;
                    tabControl1.SelectedTab.Text = openFileDialog1.SafeFileName;
                    // Для идентификации изменений.
                    tabControl1.SelectedTab.ToolTipText = "все намально";
                    timer1.Start();
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }
        // Для нумерации вкладок.
        int tabNumber = 2;
        /// <summary>
        /// Кнопа добавления вкладки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void добавитьВкладкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage tb = new TabPage();
            // Первичная задача параметров.
            tb.Text = $"Вкладка {tabNumber}";
            tb.BackColor = tabPage1.BackColor;
            tb.ForeColor = tabPage1.ForeColor;
            tb.Name = $"tabPage{tabNumber++}";
            tb.BackgroundImageLayout = tabPage1.BackgroundImageLayout;
            tb.Margin = tabPage1.Margin;
            tb.Padding = tabPage1.Padding;
            tabControl1.TabPages.Add(tb);
            tabControl1.SelectedTab = tb;
            tb.BringToFront();
            tb.Tag = "не сохранен";
            // Добавление на вкладку РичТекстБокса.
            RichTextBox rtb = new RichTextBox()
            {
                BackColor = Color.White,
                Dock = richTextBox1.Dock,
                BorderStyle = BorderStyle.Fixed3D
            };
            rtb.MouseUp += richTextBox1_MouseUp;
            rtb.TextChanged += richTextBox1_TextChanged;
            rtb.BackColor = richTextBox1.BackColor;
            tb.Controls.Add(rtb);
        }

        /// <summary>
        /// Обработка события закрытия риложения.
        /// C возможностью сохранить измененные файлы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool flag = false;
            bool check = false;
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (!flag)
                {
                    ChangeCheck(tab, ref flag);
                }
                else break;
            }
            // Важное обращения к пользователю.
            AskToSave(ref flag, ref check, e);
            if (check)
            {
                foreach (TabPage tp in tabControl1.TabPages)
                {
                    RichTextBox rtb = (RichTextBox)tp.Controls[0];
                    SaveAllMethod(tp, rtb);
                }
            }
        }
        /// <summary>
        /// Метод, объединяющий и группирующий два других, напрвленных на сохранение файла.
        /// Необходим, тк к существует два типа сохранения файла - с окошком и без.
        /// Этот метод связывает их.
        /// </summary>
        /// <param name="tp"></param>
        /// <param name="rtb"></param>
        private void SaveAllMethod(TabPage tp, RichTextBox rtb)
        {
            timer1.Start();
            // Идентификация на сохранения.
            if ((string)tp.Tag != "не сохранен")
            {
                // Идентификация на изменения.
                if (tp.ToolTipText == "изменен")
                {
                    SaveWithoutSFD(tp, rtb);
                }
            }
            else if (rtb.TextLength > 0)
            {
                SaveWithSFD(tp, rtb);
            }
        }

        /// <summary>
        /// Кнопка копирования текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            if (rtb.TextLength > 0)
            {
                rtb.Copy();
            }
        }

        /// <summary>
        /// Кнопка вставки текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void вставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            rtb.Paste();
        }

        /// <summary>
        /// Кнопка выреза текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            if (rtb.TextLength > 0)
            {
                rtb.Cut();
            }
        }
        
        /// <summary>
        /// Кнопка настроек шрифта.
        /// Метод использует объект класса Font Dialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void настройкиШрифтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
                rtb.SelectionFont = fontDialog1.Font;
            }
        }

        /// <summary>
        /// Кнопка настройки цветовой схемы приложения.
        /// Осуществляется с помощью ColorDialog.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void цветоваяГаммаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (TabPage tp in tabControl1.TabPages)
                {
                    ((RichTextBox)tp.Controls[0]).BackColor = colorDialog1.Color; 
                }
                this.BackColor = colorDialog1.Color;
                Settings.Default["ColorDesign"]= colorDialog1.Color;
                Settings.Default.Save();
            }
        }

        /// <summary>
        /// Обработка события выделения всего текста.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            if (rtb.TextLength > 0)
            {
                rtb.SelectAll();
            }
        }

        /// <summary>
        /// Обработка события нажания правой кнопки мыши в области RichTextBox-а.
        /// Вызывает контекстное меню.
        /// Данный метод присваивается каждому созданному RichTextBox-у.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_MouseUp(object sender, MouseEventArgs e)
        {
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            if (e.Button == MouseButtons.Right)
            {
                rtb.ContextMenuStrip = contextMenuStrip1;
            }
        }

        /// <summary>
        /// Копирование вызванное из контекстного меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void копироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            if (rtb.TextLength > 0)
            {
                rtb.Copy();
            }
        }

        /// <summary>
        /// Вставка, вызванная из контекстного меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            rtb.Paste();
        }

        /// <summary>
        /// Вырезание, вызванное из контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void вырезатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            if (rtb.TextLength > 0)
            {
                rtb.Cut();
            }
        }
        
        /// <summary>
        /// Выделение, вызванное из контекстного меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void выделитьВсеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            if (rtb.TextLength > 0)
            {
                rtb.SelectAll();
            }
        }

        /// <summary>
        /// Кнопка настройки шрифта текста данного файла.
        /// Вызывается из контекстного меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void форматToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RichTextBox rtb = (RichTextBox)tabControl1.SelectedTab.Controls[0];
            fontDialog1.ShowDialog();
            rtb.SelectionFont = fontDialog1.Font;
        }

        /// <summary>
        /// Кнопа, создающая новое окно.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void добавитьОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Show();
        }

        /// <summary>
        /// Первоначальное задание параметра Tag, сразу при запуске формы.
        /// Tag необходим для идентификации файла.
        /// Сохранен он или нет.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            tabPage1.Tag = "не сохранен";
        }

        /// <summary>
        /// Задание параметра ToolTipText.
        /// Необходимо для иднетификации изменений на на вкладке.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            tabControl1.SelectedTab.ToolTipText = "изменен";
        }

        /// <summary>
        /// Запрос у пользователя с предложением выйти из приложения без сохранений.
        /// С сохранениями.
        /// Или отменить выход.
        /// Вызывается один раз - именно для этого и нужно булевое значение flag.
        /// Осуществляется с помощью MessageBox-а.
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="check"></param>
        /// <param name="e"></param>
        private void AskToSave(ref bool flag, ref bool check, FormClosingEventArgs e)
        {
            if (flag)
            {
                check = false;
                flag = false;
                DialogResult res = MessageBox.Show("Вы хотите сохранить изменение в файлах?", "Выход", MessageBoxButtons.YesNoCancel);

                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (res == DialogResult.No)
                {
                    Environment.Exit(0);
                }
                else if (res == DialogResult.Yes)
                {
                    check = true;
                }
            }
        }

        /// <summary>
        /// Сохранение всех файлов в данный момент запущенных в программе.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (TabPage tp in tabControl1.TabPages)
            {
                RichTextBox rtb = (RichTextBox)tp.Controls[0];
                SaveAllMethod(tp, rtb);
            }
        }

        /// <summary>
        /// Обработка собития, выполняющегося по тику таймера.
        /// В данном случая происходит автосохранения всех уже сохраненных когда-то раннее файлов.
        /// Для привлеччения внимания к этому событию я сделал изменения рисунка курсора.
        /// Чтобы было заметнее.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Application.UseWaitCursor = true;
            Thread.Sleep(10000);
            foreach (TabPage tp in tabControl1.TabPages)
            {
                RichTextBox rtb = (RichTextBox)tp.Controls[0];
                // Идентификация на сохранения.
                if ((string)tp.Tag != "не сохранен")
                {
                    // Идентификация на изменения.
                    if (tp.ToolTipText == "изменен")
                    {
                        SaveWithoutSFD(tp, rtb);
                        
                    }
                }
            }
            Application.UseWaitCursor = false;
        }

        /// <summary>
        /// Метод настроки интервала таймера, то есть интервала автосохранения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void автосохранениеToolStripMenuItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Interval = int.Parse((string)автосохранениеToolStripMenuItem.SelectedItem) * 60000;
            // Запись информации для дальнейшего сохранения.
            Settings.Default["TimerInterval"] = timer1.Interval;
            Settings.Default.Save();
        }

        /// <summary>
        /// Метод, сохраняющий файл с уже известным путем.
        /// Осуществлется бесшумно.
        /// Без всплывающего окна SaveFileDialog.
        /// Отсюда и название.
        /// </summary>
        /// <param name="tp"></param>
        /// <param name="rtb"></param>
        private void SaveWithoutSFD(TabPage tp, RichTextBox rtb)
        {
            try
            {
                rtb.SaveFile((string)tp.Tag);
                tp.ToolTipText = "все намально";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Противоположный по смылу к предыдущему метод.
        /// Происходит для сохранения файла с неизвестным путем.
        /// Поэтому сохранения осуществляется с всплывающим окном SaveFileDialog.
        /// Отсуюда и название.
        /// </summary>
        /// <param name="tp"></param>
        /// <param name="rtb"></param>
        private void SaveWithSFD(TabPage tp, RichTextBox rtb)
        {
            saveFileDialog1.Title = $"Сохранить текстовый файл {tp.Text} как...";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|Text Files(*.rtf)|*.rtf|All Files(*.*)|*.*";
            saveFileDialog1.ShowHelp = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    rtb.SaveFile(saveFileDialog1.FileName);
                    // Сюда записывается путь.
                    tp.Tag = saveFileDialog1.FileName;
                    // Идентивикатор изменений.
                    tp.ToolTipText = "все намально";
                    tp.Text = saveFileDialog1.FileName.Split('\\')[saveFileDialog1.FileName.Split('\\').Length - 1];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Просто осуществление метода с сохранением файла с обязательным выбором расширения.
        /// Используется ля кнопки сохранить как.
        /// Окно SFD будет всплывать всегда.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveWithSFD(tabControl1.SelectedTab, (RichTextBox)tabControl1.SelectedTab.Controls[0]);
        }

        /// <summary>
        /// Метод, осуществляемый функционал закрытия вкладки с выбором о сохранении данных.
        /// Возможна отмена закрытия.
        /// Закрытие без сохранения изменений.
        /// Закрытия с сохранением изменений.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void закрытьВкладкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (tabControl1.SelectedTab != tabPage1)
            {
                // Происходит проверка на изменения.
                ChangeCheck(tabControl1.SelectedTab, ref flag);
                switch (AskSavingTab(ref flag))
                {
                    case 0:
                        break;
                    case 1:
                        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                        break;
                    case 2:
                        SaveAllMethod(tabControl1.SelectedTab, (RichTextBox)tabControl1.SelectedTab.Controls[0]);
                        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                        break;
                }
            }
        }

        /// <summary>
        /// Метод, осуществляющий провекку на изменения в файлах.
        /// За счет передачи булевого значения по ссылке.
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="flag"></param>
        private void ChangeCheck(TabPage tab, ref bool flag)
        {
            RichTextBox rtb = (RichTextBox)tab.Controls[0];
            // Проверка идентификатора на сохранение.
            if ((string)tab.Tag != "не сохранен")
            {
                // Проверка идентификатора на изменения.
                if (tab.ToolTipText == "изменен")
                {
                    flag = true;
                }
            }
            // Для несохраненных ранее файлов.
            else if (rtb.TextLength > 0)
            {
                flag = true;
            }
        }

        /// <summary>
        /// Запрос пользователю для выяснения каким образом соуществить закрытие вкладки.
        /// С сохранением.
        /// Без него.
        /// Или не закрывать вовсе.
        /// Немного схож с практически одноименным методом но выполняет иную функцию.
        /// И совместить их было бы недопустимо!
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        private int AskSavingTab(ref bool flag)
        {
            if (flag)
            {
                flag = false;
                DialogResult res = MessageBox.Show("Вы хотите сохранить изменение в файле?", "Выход", MessageBoxButtons.YesNoCancel);
                
                if (res == DialogResult.Cancel)
                {
                    return 0;
                }
                else if (res == DialogResult.No)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Обработка принудительно выхода из программы Кибервитчер 1077.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

