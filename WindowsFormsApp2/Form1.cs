    using System;
    
    
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Configuration;
    using System.Drawing.Text;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
    using System.Xml;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            qbMapping_comboBox.Items.Clear();
            LoadQBMapping();

        }

        public string PlatCategoryFilepath = ConfigurationManager.AppSettings["_PlatCategoryFilepath"];

        public string QBMappingspath = ConfigurationManager.AppSettings["_QBMappingspath"];

        public string QBAccountCodePath = ConfigurationManager.AppSettings["_QBAccountCodePath"];

        public string QBAccountPath = ConfigurationManager.AppSettings["_QBAccountPath"];





        private XmlDocument PlatCategoryXml()
        {
            XmlDocument _myXml = new XmlDocument();
            _myXml.Load(PlatCategoryFilepath);
            return _myXml;
        }

        private XmlDocument QbMappingsXml()
        {
            XmlDocument _qbMappings = new XmlDocument();
            _qbMappings.Load(QBMappingspath);
            return _qbMappings;
        }

        private XmlDocument QbAccountCodeXml()
        {
            XmlDocument _qbAccountCodeXml = new XmlDocument();
            _qbAccountCodeXml.Load(QBAccountCodePath);
            return _qbAccountCodeXml;
        }

        private XmlDocument QBAccountsPath()
        {
            XmlDocument _qbAccountpathXml = new XmlDocument();
            _qbAccountpathXml.Load(QBAccountPath);
            return _qbAccountpathXml;
        }



        public void LoadQBMapping()
        {
            qbMapping_comboBox.Items.Clear();



            XmlElement root = QbMappingsXml().DocumentElement;
            foreach (XmlNode node in root.SelectNodes("Account"))
            {
                string AccountId = node.Attributes["Id"]?.Value;
                if (!string.IsNullOrEmpty(AccountId))
                {
                    qbMapping_comboBox.Items.Add(AccountId);


                }
            }


        }



        private void spAddItems_Click(object sender, EventArgs e)
        {

            Form2 form2 = new Form2();
            if (this.WindowState == FormWindowState.Maximized)
            {
                // If Form1 is maximized, open Form2 in full screen
                form2.WindowState = FormWindowState.Maximized;
            }
            // Check if Form1 is minimized
            else if (this.WindowState == FormWindowState.Minimized)
            {
                // If Form1 is minimized, open Form2 in minimized state
                form2.WindowState = FormWindowState.Minimized;
            }
            else
            {
                // If Form1 is in normal state, open Form2 in normal size
                form2.WindowState = FormWindowState.Normal;
            }


            form2.Show();




        }







        private void addItemButton_Click(object sender, EventArgs e)
        {
            string newCategoryId = newCategoryTextBox.Text;
            string newItem = newItemTextBox.Text;

            if (string.IsNullOrEmpty(newCategoryId))
            {
                MessageBox.Show("Please enter a category name");
                return;
            }
            else if (string.IsNullOrEmpty(newItemTextBox.Text))
            {
                MessageBox.Show("Please enter an Item name");
                return;

            }
            else if (qbMapping_comboBox.SelectedIndex == -1 && string.IsNullOrEmpty(QbnewAccounttxt.Text))
            {
                // Show an error message if no selection is made
                MessageBox.Show("Please select an Account  from Existing QB AccountName or enter a new  Account proceed further.");
                return;
            }
            else if (string.IsNullOrEmpty(QbAccountCodetxt.Text))
            {
                MessageBox.Show("Please enter an Account Code");
                return;
            }
            else if (!ResidentialCheckbox.Checked && !BusinessCheckbox.Checked && !OtherCheckBox.Checked)
            {
                // Show an error message if no checkbox is checked
                MessageBox.Show("Please select at least one option before proceeding.");
                return;
            }
            else if (ResidentialCheckbox.Checked && (string.IsNullOrEmpty(ResidentialEarnedPath.Text) || string.IsNullOrEmpty(ResidentialDeferredPath.Text)))
            {
                MessageBox.Show("Please provde the path for Residential Revenue Earned and Deferred.");
                return;
            }

            else if (BusinessCheckbox.Checked && (string.IsNullOrEmpty(BusinessEarnedPath.Text) || string.IsNullOrEmpty(BusinessDeferredPath.Text)))
            {
                MessageBox.Show("Please provde the path for Business Revenue Earned and Deferred.");
                return;
            }
            else if (OtherCheckBox.Checked && string.IsNullOrEmpty(OtherAccountPath.Text))
            {
                MessageBox.Show("Please provde the path for Debit and Credit.");
                return;
            }
            else
            {


            }

            //var _myXml = myXml();

            //XmlElement root = _myXml.DocumentElement;

            //XmlNode existingCategory = _myXml.SelectSingleNode($"Categories/Category[@Id = '{newCategoryId}']");

            //if (existingCategory != null)
            //{
            //    MessageBox.Show("Category already exists");
            //    return;
            //}

            //XmlElement newCategory = _myXml.CreateElement("Category");
            //newCategory.SetAttribute("Id", newCategoryId);

            //if (string.IsNullOrEmpty(newItem))
            //{
            //    MessageBox.Show("Please Enter the Item name");
            //    return;
            //}



            //XmlElement newItemElement = _myXml.CreateElement("Item");
            //newItemElement.InnerText = newItem;
            //newCategory.AppendChild(newItemElement);

            //root.AppendChild(newCategory);

            //_myXml.Save(PlatCategoryFilepath);

            ////LoadCategories(myXml());

            //MessageBox.Show($"Category {newCategoryId} added");

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        //Method to Check the category entered in the text box already exists
        private void CheckCategoryExists(string NewCategoryTextBox)
        {
            if (!string.IsNullOrEmpty(NewCategoryTextBox))
            {


                XmlNodeList categoryNodes = PlatCategoryXml().SelectNodes("Categories//Category");

                foreach (XmlNode categoryNode in categoryNodes)
                {
                    // Get the Id attribute of the current Category element
                    string xmlCategoryId = categoryNode.Attributes["Id"].Value.Trim().Replace(" ", "").ToLower();  // Convert to lowercase

                    if (NewCategoryTextBox == xmlCategoryId)
                    {
                        // Category ID exists, show an error message
                        MessageBox.Show("Category already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;  // Exit as we found a match
                    }
                }

                // If no match is found, proceed with other logic
                MessageBox.Show("Category is available for use.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
        }





        private void newCategoryTextBox_Leave(object sender, EventArgs e)
        {
            string NewCategoryTextBox = newCategoryTextBox.Text.Trim().Replace(" ", "").ToLower();
            CheckCategoryExists(NewCategoryTextBox);

        }

        private void CheckItemExists(string NewItemTextBox)
        {
            if (!string.IsNullOrEmpty(NewItemTextBox))
            {


                XmlNodeList ItemNodes = PlatCategoryXml().SelectNodes("Categories//Category//Item");

                foreach (XmlNode ItemNode in ItemNodes)
                {
                    // Get the Id attribute of the current Category element
                    string xmlItem = ItemNode.InnerText.Trim().Replace(" ", "").ToLower();  // Convert to lowercase

                    if (NewItemTextBox == xmlItem)
                    {
                        // Category ID exists, show an error message
                        MessageBox.Show("Item already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;  // Exit as we found a match
                    }
                }

                // If no match is found, proceed with other logic
                MessageBox.Show("Item is available for use.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
        }

        private void newItemTextBox_Leave(object sender, EventArgs e)
        {
            string NewItemTextBox = newItemTextBox.Text.Trim().Replace(" ", "").ToLower();
            CheckItemExists(NewItemTextBox);
        }
    



        private void CheckQBAccountNameExists(string QbnewAccountName)
        {
            if (!string.IsNullOrEmpty(QbnewAccountName))
            {


                XmlNodeList AccountMappingNodes = QbMappingsXml().SelectNodes("AccountMappings//Account");

                foreach (XmlNode AccountMappingNode in AccountMappingNodes)
                {
                    // Get the Id attribute of the current Category element
                    string XmlMappings = AccountMappingNode.Attributes["Id"].Value.Trim().Replace(" ", "").ToLower();  // Convert to lowercase

                    if (QbnewAccountName == XmlMappings)
                    {
                        // Category ID exists, show an error message
                        MessageBox.Show("Quickbooks Account Name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;  // Exit as we found a match
                    }
                }

                // If no match is found, proceed with other logic
                MessageBox.Show("Quickbooks Account Name is available for use.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
        }

        private void QbnewAccounttxt_Leave(object sender, EventArgs e)
        {
            string QbnewAccountName = QbnewAccounttxt.Text.Trim().Replace(" ", "").ToLower();
            CheckQBAccountNameExists(QbnewAccountName);

        }

        private void CheckAccountCodeExists(string QbnewAccountCode)
        {
            if (!string.IsNullOrEmpty(QbnewAccountCode))
            {


                XmlNodeList AccountCodeNodes = QbAccountCodeXml().SelectNodes("AccountCodeMappings//AccountCode");

                foreach (XmlNode AccountCodeNode in AccountCodeNodes)
                {
                    // Get the Id attribute of the current Category element
                    string XmlMappings = AccountCodeNode.Attributes["Id"].Value.Trim().Replace(" ", "").ToLower();  // Convert to lowercase

                    if (QbnewAccountCode == XmlMappings)
                    {
                        // Category ID exists, show an error message
                        MessageBox.Show(" Account Code already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;  // Exit as we found a match
                    }
                }

                // If no match is found, proceed with other logic
                MessageBox.Show(" Account Code is available for use.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
        }

        private void QbAccountCodetxt_Leave(object sender, EventArgs e)
        {
           string  QbnewAccountCode =  QbAccountCodetxt.Text.Trim().Replace(" ", "").ToLower();
            CheckAccountCodeExists(QbnewAccountCode);



        }

        private void CheckAccountPathExists(string QbnewAccountPath)
        {
            if (!string.IsNullOrEmpty(QbnewAccountPath))
            {


                XmlNodeList AccountPathNodes = QBAccountsPath().SelectNodes("Mappings//AccountCode//Path");

                foreach (XmlNode AccountPathNode in AccountPathNodes)
                {
                    // Get the Id attribute of the current Category element
                    string XmlAccountPath = AccountPathNode.InnerText.Trim().Replace(" ", "").ToLower();  // Convert to lowercase

                    if (QbnewAccountPath == XmlAccountPath)
                    {
                        // Category ID exists, show an error message
                        MessageBox.Show(" Account Path already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;  // Exit as we found a match
                    }
                }

                // If no match is found, proceed with other logic
                MessageBox.Show(" Account Path is available for use.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
        }

        private void ResidentialEarnedPath_Leave(object sender, EventArgs e)
        {
            string NewResidentialEarnedPath = ResidentialEarnedPath.Text.Trim().Replace(" ", "").ToLower();
            CheckAccountPathExists(NewResidentialEarnedPath);

        }

        private void ResidentialDeferredPath_Leave(object sender, EventArgs e)
        {
            string NewResidentialDeferredPath = ResidentialDeferredPath.Text.Trim().Replace(" ", "").ToLower();
            CheckAccountPathExists(NewResidentialDeferredPath);

        }

        private void BusinessEarnedPath_Leave(object sender, EventArgs e)
        {
            string NewBusinessEarnedPath = BusinessEarnedPath.Text.Trim().Replace(" ", "").ToLower();
            CheckAccountPathExists (NewBusinessEarnedPath);

        }

        private void BusinessDeferredPath_Leave(object sender, EventArgs e)
        {
            string NewBusinessDeferredPath = BusinessDeferredPath.Text.Trim().Replace(" ", "").ToLower();
            CheckAccountPathExists (NewBusinessDeferredPath);

        }

        private void OtherAccountPath_Leave(object sender, EventArgs e)
        {
            string NewOtherAccountPath = OtherAccountPath.Text.Trim().Replace(" ", "").ToLower();
            CheckAccountPathExists (NewOtherAccountPath);

        }
    }
}






