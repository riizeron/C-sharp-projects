using System;
using System.Windows.Forms;

namespace First
{
    public partial class Form3 : Form
    {
        TreeNode selectedNode;
        Section choosenSection;
        string name;
        /// <summary>
        /// Конструктор использующийся при добавлении раздела.
        /// </summary>
        /// <param name="selectedNode"> Выбранный элемент дерева. </param>
        public Form3(TreeNode selectedNode)
        {
            InitializeComponent();
            this.selectedNode = selectedNode;
            this.choosenSection = (Section)selectedNode.Tag;
        }
        /// <summary>
        /// Конструктор использующийся приисменении раздела.
        /// </summary>
        /// <param name="treeView"> Дерево. </param>
        public Form3(TreeView treeView)
        {
            InitializeComponent();
            this.selectedNode = treeView.SelectedNode;
            this.choosenSection = (Section)selectedNode.Tag;
            this.name = choosenSection.Name;
            textBox1.Text = name;
            button1.Text = "Изменить";
        }
        /// <summary>
        /// Кнопка вносящая изменения в раздел либо добавляющая его.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            // Изменение.
            if (name != null)
            {
                try
                {
                    choosenSection.Name = textBox1.Text;
                    selectedNode.Text = textBox1.Text;
                    Close();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
            // Создание.
            else
            {
                try
                {
                    Section newSection = new Section(textBox1.Text, choosenSection);
                    choosenSection.UnderSections.Add(newSection);
                    TreeNode newNode = new TreeNode(newSection.Name);
                    newNode.Tag = newSection;
                    selectedNode.Nodes.Add(newNode);
                    this.Close();

                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
        }
        /// <summary>
        /// KeyPress для недопущени яввода некоректной информации.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == ' ')
            {
                if (textBox1.Text.Length == 0)
                {
                    e.Handled = true;
                }
                return;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    button1.Focus();
                }
                return;
            }
            else { return; }
        }
    }
}
