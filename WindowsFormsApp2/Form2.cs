using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        
        public string Filepath = "C:\\Users\\Intern\\Desktop\\Installer sample\\WindowsFormsApp2\\WindowsFormsApp2\\CategoryProvider\\Categories.xml";

        private XmlDocument myXml()
        {
            XmlDocument _myXml = new XmlDocument();
            _myXml.Load(Filepath);
            return _myXml;
        }
        public Form2()
        {
            InitializeComponent();
            
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {

            panel3_categoryComboBox.Items.Clear();



            LoadCategories(myXml());

            panel3_categoryComboBox.DropDownStyle = ComboBoxStyle.DropDown; // Enable typing
            panel3_categoryComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend; // Enable suggestions while typing
            panel3_categoryComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void LoadCategories(XmlDocument myXml)
        {


            panel3_categoryComboBox.Items.Clear();

            XmlElement root = myXml.DocumentElement;
            foreach (XmlNode node in root.SelectNodes("Category"))
            {
                var CategoryID = node.Attributes["Id"]?.Value;
                if (CategoryID != null)
                {

                    panel3_categoryComboBox.Items.Add(CategoryID);

                }
            }

        }

        private void panel3_addItemButton_Click_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(panel3_categoryComboBox.SelectedItem?.ToString()))

            {
                MessageBox.Show("Please Select the Category  to proceed");
                return;
            }
            if (string.IsNullOrEmpty(panel3_newItemTextBox?.Text))
            {
                MessageBox.Show("Please enter item  to proceed");
                return;
            }
            string SelectedCategory = panel3_categoryComboBox.SelectedItem.ToString();
            string newItem = panel3_newItemTextBox.Text;

            if (string.IsNullOrEmpty(newItem))
            {
                MessageBox.Show("Please enter an item to add");
                return;
            }

            var _myXml = myXml();

            XmlNode categoryNode = _myXml.SelectSingleNode($"Categories//Category[@Id='{SelectedCategory}']");

            if (categoryNode != null)
            {
                XmlElement newItemElement = _myXml.CreateElement("Item");
                newItemElement.InnerText = newItem;
                categoryNode.AppendChild(newItemElement);

                _myXml.Save(Filepath);

                MessageBox.Show($"Item {newItem} added to the Category {SelectedCategory}");

                LoadCategories(myXml());
            }
        }

        private void spAddCategory_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            if (this.WindowState == FormWindowState.Maximized)
            {
                // If Form1 is maximized, open Form2 in full screen
                form1.WindowState = FormWindowState.Maximized;
            }
            // Check if Form1 is minimized
            else if (this.WindowState == FormWindowState.Minimized)
            {
                // If Form1 is minimized, open Form2 in minimized state
                form1.WindowState = FormWindowState.Minimized;
            }
            else
            {
                // If Form1 is in normal state, open Form2 in normal size
                form1.WindowState = FormWindowState.Normal;
            }


            form1.Show();

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ask the user for confirmation before closing Form1
            var result = MessageBox.Show("Are you sure you want to close Form1?", "Confirm Close", MessageBoxButtons.YesNo);

            if (result == DialogResult.No)
            {
                // If the user clicked "No", prevent Form1 from closing
                e.Cancel = true;
            }
            else
            {
                // Otherwise, allow the form to close
                e.Cancel = false;
            }
        }

    }
}
