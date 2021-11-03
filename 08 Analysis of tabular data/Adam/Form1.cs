using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Text.RegularExpressions;

using System.IO;

namespace Adam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        /// <summary>
        /// Вызов openFileDialog с фильтором.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "CSV Files(*.csv)|*.CSV";
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
            BindDataCSV(textBox1.Text);
        }
        /// <summary>
        /// Открытие csv фала и заполнение dataGridView.
        /// Заключается в последовательном выполнение простейших циклов.
        /// Функционал заключается в заполнении DataTable с последующем заполнением dataGridView.
        /// DataTable необходим, тк он куда лучше и удобнеее в анализе данных чем сама таблица DataGridView.
        /// </summary>
        /// <param name="filePath"></param>
        private void BindDataCSV(string filePath)
        {
            // Зануление таблицы и DataTable.
            evaGridView1.Rows.Clear();
            dt.Rows.Clear();
            dt.Columns.Clear();
            this.evaGridView1.SelectionMode =
    DataGridViewSelectionMode.RowHeaderSelect;
            string[] lines;
            try
            {
                lines = File.ReadAllLines(filePath);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            if (lines.Length > 0)
            {
                string firstLine = lines[0];
                if (firstLine[0] == ',')
                {
                    firstLine = firstLine.Insert(0, " ");
                }
                string[] headerLabels = firstLine.Split(',');
                int headerCount = headerLabels.Length;
                evaGridView1.ColumnCount = headerCount;
                int i = 0;
                foreach (string headerWord in headerLabels)
                {
                    evaGridView1.Columns[i++].HeaderText = headerWord;
                    dt.Columns.Add(new DataColumn(headerWord));
                }
                SetSortMode();
                for (int r = 1; r < lines.Length; r++)
                {
                    string[] dataWords = (SaveComma(lines[r])).Split(',');
                    evaGridView1.Rows.Add(dataWords);
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    foreach (string headerWord in headerLabels)
                    {
                        dr[headerWord] = dataWords[columnIndex++];
                    }
                    dt.Rows.Add(dr);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (evaGridView1.SelectedColumns == null || evaGridView1.SelectedColumns.Count < 1 || evaGridView1.SelectedColumns.Count > 2)
            {
                MessageBox.Show("Вы некорректно выбрали столбцы!");
                return;
            }
            chart1.Visible = true;
            Chart ch = new Chart();
            ch.ChartAreas.Add(new ChartArea());
            ch.Series.Add(new Series());
            ch.Legends.Add(new Legend());
            ch.Location = new Point(25, 60);
            ch.Anchor = AnchorStyles.Left;
            ch.Dock = DockStyle.Right;
            chart1.Series[0].Points.Clear();

            Dictionary<string, double> values = new Dictionary<string, double>();
            // Функционал о котором говорилось в текстовом файле.
            // При выборе двух столбцов считает среднее цисловое значение из второго столбца 
            // для каждого различного пункта первого столбца.
            if (evaGridView1.SelectedColumns.Count == 2)
            {
                TwoColumnsSelected(ch, values);
            }
            else if (evaGridView1.SelectedColumns.Count == 1)
            {
                OneColumnSelected(ch, values);
            }
            // Метод создания новой формы с графиком.
            newformCreation(ch, values);
        }
        /// <summary>
        /// Отчистка числовой по смыслу строки от кавычек и других ненужных знаков.
        /// Если подать в него строку без цифр, то он вернет ноль.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static double RemoveQuotesFromNumber(string value)
        {
            char[] symbols = value.ToCharArray();
            List<char> numbers = new List<char>();
            char[] mask = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.' };
            for (int i = 0; i < symbols.Length; i++)
            {
                if (mask.Contains(symbols[i]))
                {
                    if (symbols[i] == '.')
                    {
                        numbers.Add(',');
                    }
                    else
                    {
                        numbers.Add(symbols[i]);
                    }
                }
            }
            string strNumber = String.Concat<char>(numbers.ToArray());
            if (strNumber == "." || strNumber.Length == 0)
            {
                return 0.0;
            }
            else
            {
                return double.TryParse(strNumber, out double b) ? b : 0;
            }
        }
        /// <summary>
        /// Меняем запятые в названиях на бэкслэш.
        /// Это чтобы правильно парсить csv файл.
        /// То есть метод меняет только запятые, стоящие внутри кавычек.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string SaveComma(string input)
        {
            var regex = new Regex("\\\"(.*?)\\\"");
            var output = regex.Replace(input, m => m.Value.Replace(',', '\\'));
            return output;
        }

        // Далее подут методы с формулами для подсчсета всяких значения анализа данных.
        // Они все принимают на вход словарь.

        /// <summary>
        /// Подсчет медиананы по формуле.
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        private static double Mediana(Dictionary<string, double> dict)
        {
            double[] dL = new double[dict.Count];
            int i = 0;
            foreach (string key in dict.Keys)
            {
                dL[i++] = dict[key];
            }
            Array.Sort(dL);
            return dL[(dL.Length + 1) / 2];
        }
        /// <summary>
        /// Подсчет среднего значения по формуле.
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        private static double Average(Dictionary<string, double> dict)
        {
            double[] dL = new double[dict.Count];
            int i = 0;
            foreach (string key in dict.Keys)
            {
                dL[i++] = dict[key];
            }
            return dL.Average();
        }
        /// <summary>
        /// Подсчет среднеквадратического отклонения по формуле через дисперсию.
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        private static double AverageSquare(Dictionary<string, double> dict)
        {
            return Math.Sqrt(Disperce(dict));
        }
        /// <summary>
        /// Подсчет дисперсии по формуле.
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        private static double Disperce(Dictionary<string, double> dict)
        {
            double[] dL = new double[dict.Count];
            int i = 0;
            foreach (string key in dict.Keys)
            {
                dL[i++] = dict[key];
            }
            double sum = 0;
            double aver = dL.Average();
            for (int j = 0; j < dL.Length; j++)
            {
                sum += (dL[j] - aver) * (dL[j] - aver);
            }
            return (sum / dL.Length);
        }
        /// <summary>
        /// Обработка события нажатия на кнопку сохранить график на главной форме.
        /// Сохраняет изображение графика в формате .png.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (chart1.Visible)
            {
                chart1.SaveImage(RemoveQuotesFromString(chart1.Titles[0].Text) + ".png", ChartImageFormat.Png);
                MessageBox.Show("График сохранен!");
            }
            else
            {
                MessageBox.Show("А графика то еще нету ((");
            }
        }
        /// <summary>
        /// Обработка события нажатия на график расположенный на главной форме.
        /// Изменяет цвет графика за счет вызова ColorDialig.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chart1_MouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            chart1.Series[0].Color = cd.Color;
        }
        /// <summary>
        /// Метод создания новой формы с графиком, числовыми значениями и кнопкой сохранить график.
        /// Метод в основном нафодит порядок на новой форме.
        /// Создает форму на основе уже существующего графического конструктора.
        /// </summary>
        /// <param name="ch"> Уже готовый график, построенный в методе выше. </param>
        /// <param name="values"></param>
        private void newformCreation(Chart ch, Dictionary<string, double> values)
        {
            FormGR chartForm = new FormGR();
            chartForm.Text = "График";
            chartForm.Size = new Size(850, 500);
            chartForm.StartPosition = FormStartPosition.CenterScreen;
            Label lab = new Label();
            lab.Dock = DockStyle.Left;
            lab.Text = $"Среднее значение: {Average(values)}\nМедиана: {Mediana(values)}\n" +
                $"Дисперсия: {Disperce(values)}\nСреднеквадратическое отклонение: {AverageSquare(values)}";

            Button saveBtn = (Button)chartForm.Controls[1];
            saveBtn.BackColor = Color.Red;
            saveBtn.Location = new Point(50, 80);
            saveBtn.Size = new Size(50, 50);
            saveBtn.Dock = DockStyle.Bottom;
            saveBtn.Text = "Сохранить график";

            ((Chart)chartForm.Controls[2]).Series[0] = ch.Series[0];
            ((Chart)chartForm.Controls[2]).Titles.Add(new Title(ch.Titles[0].Text));
            ((Chart)chartForm.Controls[2]).Dock = DockStyle.Top;

            chartForm.Controls.Add(lab);
            chartForm.Show();
        }
        /// <summary>
        /// Метод удаляющий кавычки из строки.
        /// Необходим для сохранения графика с иказанным именем.
        /// Ведь кавычки не могут присутствовать в имени файла.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveQuotesFromString(string str)
        {
            char[] symbols = str.ToCharArray();
            List<char> output = new List<char>();
            foreach (char ch in symbols)
            {
                if (ch != '\"')
                {
                    output.Add(ch);
                }
            }
            return String.Concat<char>(output.ToArray());
        }
        /// <summary>
        /// Метод, обрабатывающий ситуация с выбром двух столбцов.
        /// </summary>
        /// <param name="ch"> График составленный ранее. </param>
        /// <param name="values"> Словарь, где ключи - это подписи к OX, а значения - к OY. </param>
        private void TwoColumnsSelected(Chart ch, Dictionary<string, double> values)
        {
            int first = evaGridView1.SelectedColumns[1].Index;
            int second = evaGridView1.SelectedColumns[0].Index;
            string firstName = dt.Columns[first].ColumnName;
            string secondName = dt.Columns[second].ColumnName;
            // Задача дизайнерских параметров графика.
            chart1.Series[0].LegendText = evaGridView1.Columns[second].HeaderText;
            chart1.Titles[0].Text = evaGridView1.Columns[second].HeaderText;
            ch.Titles.Add(new Title(evaGridView1.Columns[second].HeaderText));
            ch.Titles[0].Text = evaGridView1.Columns[second].HeaderText; ;
            ch.Series[0].LegendText = evaGridView1.Columns[second].HeaderText;
            ch.Text = "График " + evaGridView1.Columns[second].HeaderText;
            chart1.Text = "График " + evaGridView1.Columns[second].HeaderText;
            chart1.ChartAreas[0].AxisX.Title = evaGridView1.Columns[first].HeaderText;
            ch.ChartAreas[0].AxisX.Title = evaGridView1.Columns[first].HeaderText;
            ch.Series[0].AxisLabel = evaGridView1.Columns[first].HeaderText;

            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();
            // Заполнение словаря со всеми данными.
            // Данный цикл нужен для поиска совпадающих зачений первого столбца
            foreach (DataRow row in dt.Rows)
            {
                string key = row[firstName].ToString();
                if (!dict.ContainsKey(key))
                {
                    dict.Add(key, new List<double>() { RemoveQuotesFromNumber(row[secondName].ToString()) });
                }
                else
                {
                    dict[key].Add(RemoveQuotesFromNumber(row[secondName].ToString()));
                }
            }

            // Здесь данные предыдущего словаря обрабатываются для дальнейшего отображения на графике.
            // Происходит нахождение среднего значения для каждого ключа.
            foreach (var key in dict.Keys)
            {
                int count = dict[key].Count;
                double sum = 0.0;
                foreach (double item in dict[key])
                {
                    sum += item;
                }
                values.Add(key, sum / count);
            }
            // Сортировка массива ключей для последовательного увеличения значений по оси OX.
            string[] keys = values.Keys.ToArray();
            Array.Sort(keys, SortMethod);
            // Заполнение графика.
            foreach (var key in keys)
            {
                chart1.Series[0].Points.AddXY(key, values[key]);
                ch.Series[0].Points.AddXY(key, values[key]);
            }
        }
        /// <summary>
        /// Метод обрабатывающий собития при выборе одного столбца.
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="values"></param>
        private void OneColumnSelected(Chart ch, Dictionary<string, double> values)
        {
            int first = evaGridView1.SelectedColumns[0].Index;
            string firstName = dt.Columns[first].ColumnName;
            foreach (DataRow row in dt.Rows)
            {
                string key = row[firstName].ToString();
                if (!values.ContainsKey(key))
                {
                    values.Add(key, 1);
                }
                else
                {
                    values[key] += 1;
                }
            }
            // Задача дизайнерских параметров графика.
            chart1.Series[0].LegendText = evaGridView1.Columns[first].HeaderText;
            chart1.Titles[0].Text = evaGridView1.Columns[first].HeaderText;
            ch.Titles.Add(new Title(evaGridView1.Columns[first].HeaderText));
            ch.Titles[0].Text = evaGridView1.Columns[first].HeaderText; ;
            ch.Series[0].LegendText = evaGridView1.Columns[first].HeaderText;
            ch.Text = "График " + evaGridView1.Columns[first].HeaderText;
            chart1.Text = "График " + evaGridView1.Columns[first].HeaderText;
            chart1.ChartAreas[0].AxisX.Title = evaGridView1.Columns[first].HeaderText;
            ch.ChartAreas[0].AxisX.Title = evaGridView1.Columns[first].HeaderText;
            chart1.ChartAreas[0].AxisY.Title = "шт";
            ch.ChartAreas[0].AxisX.Title = "шт";
            ch.Series[0].AxisLabel = evaGridView1.Columns[first].HeaderText;
            // Сортировка массива ключей для последовательного увеличения значений по оси OX.
            string[] keys = values.Keys.ToArray();
            Array.Sort(keys, SortMethod);
            // Заполнение графика.
            foreach (var key in keys)
            {
                chart1.Series[0].Points.AddXY(key, values[key]);
                ch.Series[0].Points.AddXY(key, values[key]);
            }
            ch.Size = new Size(500, 300);
            ch.MouseClick += new MouseEventHandler(chart1_MouseClick);
            ch.Visible = true;
        }
        /// <summary>
        /// Установление параметра сортироки для столбцов.
        /// </summary>
        private void SetSortMode()
        {
            foreach (DataGridViewColumn c in evaGridView1.Columns)
            {
                c.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.evaGridView1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            this.evaGridView1.MultiSelect = true;
        }
        /// <summary>
        /// Проверка на коррекность выбора столбца.
        /// </summary>
        private void CheckSelectedColumns(object sender,EventArgs e)
        {
            if (evaGridView1.SelectedColumns == null || evaGridView1.SelectedColumns.Count < 1 || evaGridView1.SelectedColumns.Count > 2)
            {
                MessageBox.Show("Вы некорректно выбрали столбцы!");
                return;
            }
        }
        /// <summary>
        /// Метод сортировки массива ключей для последовательного увеличения числовых значений по оси OY.
        /// </summary>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <returns></returns>
        private int SortMethod(string item1, string item2)
        {
            if (RemoveQuotesFromNumber(item1) == 0)
            {
                return String.Compare(item1, item2);
            }
            else
            {
                if (RemoveQuotesFromNumber(item1) > RemoveQuotesFromNumber(item2))
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int k = (int)numericUpDown1.Value;
            if (k < 0)
            {
                k = 1 / k;
            }
            chart1.ChartAreas[0].AxisX.Maximum = k;
        }
    }
}
