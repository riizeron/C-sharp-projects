using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;

namespace First
{
    // Да да, некоторые методы немного на руссокм, я разумеется с легкостью мог бы это переделать.
    // Но поймите меня правильно, вижла сама по дефолту предложила мне такие, и как бы вот, ну зачем их менять.
    public partial class Form1 : Form
    {
        // Поля, содержащие элементы которые есть всегда.
        TreeNode rootNodeProducts;
        TreeNode rootNodeServices;
        Section infoProducts = new Section("Товары", null);
        Section infoServices = new Section("Услуги", null);
        // Дефолтное оличество начиная с которого идет запись в csv файл.
        public static int minAmount = 0;
        // Дефолтный путь куда записывается csv.
        public static string csvPath = "XmlProducts.csv";
        public Form1()
        {
            InitializeComponent();
            // Вызов метода, задающего стартовые параметры.
            Start();
            this.treeView1.NodeMouseClick +=
    new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
        }
        /// <summary>
        /// Метод добавления раздела.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void разделToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("Необходимо выбрать раздел!", "Ошибка");
            }
            else
            {
                Section choosenSec = (Section)selectedNode.Tag;
                Form3 sectionForm = new Form3(selectedNode);
                sectionForm.Visible = true;
                sectionForm.Activate();
            }
        }
        /// <summary>
        /// Метод, заполняющий treeView.
        /// </summary>
        /// <param name="subSectionsProducts"> Список подразделов дефолтного объекта класса Section </param>
        /// <param name="subSectionServices"> Список подразделов дефолтного объекта класса Section </param>
        /// <param name="nodeToAddToProducts"> Дефолтная ячейка дерева </param>
        /// <param name="nodeToAddToServices"> Дефолтная ячейка дерева </param>
        private void FillTreeView(List<Section> subSectionsProducts, List<Section> subSectionServices,
            TreeNode nodeToAddToProducts, TreeNode nodeToAddToServices)
        {
            TreeNode aNode;
            List<Section> subSubSections;
            foreach (Section subSection in subSectionsProducts)
            {
                aNode = new TreeNode(subSection.Name, 0, 0);
                aNode.Tag = subSection;
                subSubSections = subSection.UnderSections;
                if (subSubSections.Count != 0)
                {
                    // Используем рекурсию для отображения всех уровней дерева.
                    FillTreeView(subSubSections, subSectionServices, aNode, nodeToAddToProducts);
                }
                nodeToAddToProducts.Nodes.Add(aNode);
            }
            // Цикл аналогичный предыдущему, только для другого дефолтного объекта.
            foreach (Section subSection in subSectionServices)
            {
                aNode = new TreeNode(subSection.Name, 0, 0);
                aNode.Tag = subSection;
                subSubSections = subSection.UnderSections;
                if (subSubSections.Count != 0)
                {
                    FillTreeView(subSectionsProducts, subSubSections, aNode, nodeToAddToServices);
                }
                nodeToAddToServices.Nodes.Add(aNode);
            }
        }
        /// <summary>
        /// Метод заполняющий listView при нажатии на элемент дерева.
        /// Отображает всю продукцию раздела выбранной ячейки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = treeView1.SelectedNode;
            listView1.Items.Clear();
            Section nodeSectionInfo = (Section)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item;

            foreach (Product pr in nodeSectionInfo.Products)
            {
                item = new ListViewItem(pr.Name, 1);
                item.Tag = pr;
                subItems = new ListViewItem.ListViewSubItem[]
                    {   new ListViewItem.ListViewSubItem(item,pr.Code),
                        new ListViewItem.ListViewSubItem(item,pr.Amount.ToString()),
                        new ListViewItem.ListViewSubItem(item,pr.Price.ToString())};
                item.SubItems.AddRange(subItems);
                listView1.Items.Add(item);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        /// <summary>
        /// Метод, задающий начальные параметры деволтных элементов.
        /// </summary>
        private void Start()
        {
            treeView1.Nodes.Clear();
            rootNodeProducts = new TreeNode("Товары");
            rootNodeServices = new TreeNode("Услуги");
            // В тэг каждой ячейки суем объект класса раздела, которому она(ячейка) соответствует.
            rootNodeProducts.Tag = infoProducts;
            rootNodeServices.Tag = infoServices;
            treeView1.Nodes.Add(rootNodeProducts);
            treeView1.Nodes.Add(rootNodeServices);
            FillTreeView(infoProducts.UnderSections, infoServices.UnderSections,
                rootNodeProducts, rootNodeServices);
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        /// <summary>
        /// Добавление товара.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void товарToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("Необходимо выбрать раздел!", "Ошибка");
            }
            else
            {
                Form2 productForm = new Form2((Section)selectedNode.Tag);
                productForm.Visible = true;
                productForm.Activate();
            }
        }
        /// <summary>
        /// Метод изменения раздела или товара.
        /// И то и то выполняется в одном методе.
        /// В зависимости от того, на что мы тыкнули мышью.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (treeView1.SelectedNode.Tag.GetType().Name == "Section"
                && listView1.SelectedItems.Count == 0)
            {
                // Вызываем ту же форму, что и при создании, тк это удобно.
                Form3 changeForm = new Form3(treeView1);
                changeForm.Visible = true;
                changeForm.Activate();
            }
            else if (listView1.SelectedItems[0].Tag.GetType().Name == "Product")
            {
                Product pr = (Product)listView1.SelectedItems[0].Tag;
                // Вызываем ту же форму, что и при создании, тк это удобно.
                Form2 changeForm = new Form2(listView1);
                changeForm.Visible = true;
                changeForm.Activate();
            }
        }
        /// <summary>
        /// Метод, изменяющий listView с продуктами.
        /// </summary>
        /// <param name="listView"> ListView </param>
        public static void ChangeListView(ListView listView)
        {
            ListViewItem selectedItem = listView.SelectedItems[0];
            Product pr = (Product)selectedItem.Tag;
            selectedItem.Remove();
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = new ListViewItem(pr.Name, 1); ;
            item.Tag = pr;
            subItems = new ListViewItem.ListViewSubItem[]
                {       new ListViewItem.ListViewSubItem(item,pr.Code),
                        new ListViewItem.ListViewSubItem(item,pr.Amount.ToString()),
                        new ListViewItem.ListViewSubItem(item,pr.Price.ToString())};
            item.SubItems.AddRange(subItems);
            listView.Items.Add(item);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        /// <summary>
        /// Метод, удаляющий раздел или товар.
        /// В зависимостии от того куда тыкнули мышью.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Удалление раздела.
            if (listView1.SelectedItems.Count == 0 && treeView1.SelectedNode != null)
            {
                Section choosenSec = (Section)treeView1.SelectedNode.Tag;
                if (choosenSec == infoProducts || choosenSec == infoServices)
                {
                    MessageBox.Show("Вы не можете удалить  корневой каталог", "Ошибка");
                }
                else
                {
                    // Проверка на наичие содержимого в разделе.
                    if (choosenSec.UnderSections.Count != 0 || choosenSec.Products.Count != 0)
                    {
                        DialogResult res = MessageBox.Show("В выбранном каталоге есть содержимое" +
                            "\nВсе равно удалить его?", "Удаление", MessageBoxButtons.YesNo);
                        if (res == DialogResult.Yes)
                        {
                            Section.sections.Remove(choosenSec);
                            treeView1.Nodes.Remove(treeView1.SelectedNode);
                            choosenSec.Parent.UnderSections.Remove(choosenSec);
                            treeView1.SelectedNode = null;
                        }
                    }
                    else
                    {
                        Section.sections.Remove(choosenSec);
                        treeView1.Nodes.Remove(treeView1.SelectedNode);
                        choosenSec.Parent.UnderSections.Remove(choosenSec);
                        treeView1.SelectedNode = null;
                    }
                }
            }
            // Удаление товара.
            else if (listView1.SelectedItems[0].Tag.GetType().Name == "Product")
            {
                Product pr = (Product)listView1.SelectedItems[0].Tag;
                Product.products.Remove(pr);
                pr.Parent.Products.Remove(pr);
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }
        // Вызов уже известных методов основного меню, для контекстного меню.
        private void изменитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            изменитьToolStripMenuItem_Click(sender, e);
        }
        // Вызов уже известных методов основного меню, для контекстного меню.
        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            удалитьToolStripMenuItem_Click(sender, e);
        }
        /// <summary>
        /// Отображение контекстного меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.ContextMenuStrip = contextMenuStrip1;
            }
        }
        /// <summary>
        /// Отображение контекстного меню.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                listView1.ContextMenuStrip = contextMenuStrip1;
            }
        }
        /// <summary>
        /// Метод, сохраняющий состояние склада.
        /// Используем SaveFileDialog для выбора пути.
        /// Используется xml сериаизация.
        /// Я бы использовал Json, вот только с циклами он умеет справляться только на NET 5.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // разрешаем сериализовать цикические объекты.
            var dcss = new DataContractSerializerSettings { PreserveObjectReferences = true };
            var dcs = new DataContractSerializer(typeof(List<Section>), dcss);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = $"Сохранить текстовый склад как...";
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            sfd.Filter = "Xml Files(*.xml)|*.xml";
            sfd.ShowHelp = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (Stream fStream = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        dcs.WriteObject(fStream, Section.sections);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Загрузга состояния склада из файла.
        /// Используем OpenFileDialog для выбора нужного файла.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void загрузитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Загрузить xml файл...";
            ofd.Filter = "XML Files(*.xml)|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (XmlReader fStream = XmlReader.Create(ofd.FileName))
                    {
                        DataContractSerializer dsg = new DataContractSerializer(typeof(List<Section>));
                        Section.sections = (List<Section>)dsg.ReadObject(fStream);
                        this.Text = ofd.SafeFileName.Substring(0, ofd.SafeFileName.Length - 4);
                        // Сразу же инициализируем дефолтные элементы после загрузки.
                        infoProducts = Section.sections[0];
                        infoServices = Section.sections[1];
                        rootNodeProducts.Tag = infoProducts;
                        rootNodeServices.Tag = infoServices;
                        FillTreeView(infoProducts.UnderSections, infoServices.UnderSections,
                rootNodeProducts, rootNodeServices);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка");
                }
            }
        }
        /// <summary>
        /// Вызов формы с настройками создания scv файла с товарами.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 settingForm = new Form4();
            settingForm.Visible = true;
            settingForm.Activate();
        }
        /// <summary>
        /// Метод сохдания csv файла с товарами.
        /// Будем вызывать его при каждом изменении или добалении товара.
        /// </summary>
        public static void CsvCreation()
        {
            string csvString = "<путь_классификатора>,артикул,название товара,количество на складе"
                + Environment.NewLine;
            foreach (Product pr in Product.products)
            {
                if (pr.Amount <= minAmount)
                {
                    csvString += $"{pr.Path},{pr.Code},{pr.Name},{pr.Amount}" + Environment.NewLine;
                }
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(csvPath, false, Encoding.Unicode))
                {
                    sw.Write(csvString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
