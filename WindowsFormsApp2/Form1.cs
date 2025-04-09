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
using System.Reflection.Emit;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Diagnostics.Eventing.Reader;

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
            newItemTextBox.Enabled = false;
            qbMapping_comboBox.Enabled = false;
            QbnewAccounttxt.Enabled = false;
            ResidentialCheckbox.Enabled = false;
            BusinessCheckbox.Enabled = false;
            OtherCheckBox.Enabled = false;
            QbAccountCodetxt.Enabled = false;
            ResidentialEarnedPath.Enabled = false;
            ResidentialDeferredPath.Enabled = false;
            BusinessEarnedPath.Enabled = false;
            BusinessDeferredPath.Enabled = false;
            AddNewAccount.Enabled = false;

        }

        public string PlatCategoryFilepath = ConfigurationManager.AppSettings["_PlatCategoryFilepath"];

        public string QBMappingspath = ConfigurationManager.AppSettings["_QBMappingspath"];

        public string QBAccountCodePath = ConfigurationManager.AppSettings["_QBAccountCodePath"];

        public string QBAccountPath = ConfigurationManager.AppSettings["_QBAccountPath"];



        //Load all the xml files to xml document

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


        //Load QBmapping to the dropdown 
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


        //Sidepanel button to add item 
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

        // checks and update if category is present or not
        private void newCategoryTextBox_TextChanged(object sender, EventArgs e)
        {
            string NewCategoryTextBox = newCategoryTextBox.Text.Trim().Replace(" ", "").ToLower();
            CheckCategoryExists(NewCategoryTextBox);

        }


        //checks and update if item is present 
        private void newItemTextBox_TextChanged(object sender, EventArgs e)
        {
            string NewItemTextBox = newItemTextBox.Text.Trim().Replace(" ", "").ToLower();
            CheckItemExists(NewItemTextBox);

        }

        private void qbMapping_comboBox_TextChanged(object sender, EventArgs e)
        {
            
            qbMapping_comboBox.DroppedDown = true;

        }

        private void QbnewAccounttxt_TextChanged(object sender, EventArgs e)
        {
            string QbnewAccountName = QbnewAccounttxt.Text.Trim().Replace(" ", "").ToLower();
            CheckQBAccountNameExists(QbnewAccountName);


        }

   

        private void QbAccountCodetxt_TextChanged(object sender, EventArgs e)
        {
            string QbnewAccountCode = QbAccountCodetxt.Text.Trim().Replace(" ", "").ToLower();
            CheckAccountCodeExists(QbnewAccountCode);

        }

        private void ResidentialEarnedPath_TextChanged(object sender, EventArgs e)
        {
            string NewResidentialEarnedPath = ResidentialEarnedPath.Text.Trim().Replace(" ", "").ToLower();
            label12.Visible = true;
            label12.Text = CheckAccountPathExists(NewResidentialEarnedPath);
        }

        private void ResidentialDeferredPath_TextChanged(object sender, EventArgs e)
        {
            string NewResidentialDeferredPath = ResidentialDeferredPath.Text.Trim().Replace(" ", "").ToLower();
            label13.Text = CheckAccountPathExists(NewResidentialDeferredPath);
            label13.Visible = true;


        }

        private void BusinessEarnedPath_TextChanged(object sender, EventArgs e)
        {
            string NewBusinessEarnedPath = BusinessEarnedPath.Text.Trim().Replace(" ", "").ToLower();
            label14.Visible = true;
            label14.Text = CheckAccountPathExists(NewBusinessEarnedPath);

        }

        private void BusinessDeferredPath_TextChanged(object sender, EventArgs e)
        {
            string NewBusinessDeferredPath = BusinessDeferredPath.Text.Trim().Replace(" ", "").ToLower();
            label15.Visible = true;
            label15.Text = CheckAccountPathExists(NewBusinessDeferredPath);


        }




        // Button to add new category,item,qbaccount,accountcode , account path
        private void addCategoryButton_Click(object sender, EventArgs e)
        {
            XmlService xmlService = new XmlService();

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
            else if (qbMapping_comboBox.SelectedIndex != -1 && string.IsNullOrEmpty(QbnewAccounttxt.Text))
            {
               
               
                xmlService.AddToCategoryXml(PlatCategoryXml(), PlatCategoryFilepath, newCategoryTextBox.Text, newItemTextBox.Text);

                xmlService.AddToMappingXml(QbMappingsXml(), QBMappingspath, qbMapping_comboBox.Text, newCategoryTextBox.Text);



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
            else if ((ResidentialCheckbox.Checked || OtherCheckBox.Checked) && (string.IsNullOrEmpty(ResidentialEarnedPath.Text) || string.IsNullOrEmpty(ResidentialDeferredPath.Text)))
            {
                MessageBox.Show("Please provde the path for Residential Revenue Earned and Deferred.");
                return;
            }

            else if ((BusinessCheckbox.Checked || OtherCheckBox.Checked) && (string.IsNullOrEmpty(BusinessEarnedPath.Text) || string.IsNullOrEmpty(BusinessDeferredPath.Text)))
            {
                MessageBox.Show("Please provde the path for Business Revenue Earned and Deferred.");
                return;
            }

            else
            {
                //Add category and item in category xml
                try
                {



                    //Add category and item in category xml
                    var _PlatCategory = PlatCategoryXml();

                    XmlElement root = _PlatCategory.DocumentElement;

                    XmlNode existingCategory = _PlatCategory.SelectSingleNode($"Categories/Category[@Id = '{newCategoryId}']");

                    if (existingCategory != null)
                    {
                        MessageBox.Show("Category already exists");
                        return;
                    }

                    XmlElement newCategory = _PlatCategory.CreateElement("Category");
                    newCategory.SetAttribute("Id", newCategoryId);

                    if (string.IsNullOrEmpty(newItem))
                    {
                        MessageBox.Show("Please Enter the Item name");
                        return;
                    }
                    XmlNode existingItem = _PlatCategory.SelectSingleNode($"Categories/Category/Item[text() = '{newItem}']");

                    if (existingItem != null)
                    {
                        MessageBox.Show("Item already exists");
                        return;
                    }



                    XmlElement newItemElement = _PlatCategory.CreateElement("Item");
                    newItemElement.InnerText = newItem;
                    newCategory.AppendChild(newItemElement);

                    root.AppendChild(newCategory);

                    _PlatCategory.Save(PlatCategoryFilepath);

                    MessageBox.Show($"New Category:{newCategoryId} and New Invoice Item {newItem} added successfully ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error while trying to save new Category due to {ex.Message}");
                    return;
                }



                //Add Category  QB Account in AccountMapping XML

                try
                {
                    var _QbMappingXml = QbMappingsXml();

                    XmlElement root = _QbMappingXml.DocumentElement;

                    if (qbMapping_comboBox.SelectedIndex != -1)


                    {
                        string _qbMapping_comboBox = qbMapping_comboBox.SelectedItem.ToString();
                        XmlNode ExistingMapping = QbMappingsXml().SelectSingleNode($"AccountMappings/Account[@Id = '{_qbMapping_comboBox}']");

                        XmlElement newCategory = _QbMappingXml.CreateElement("Category");
                        newCategory.InnerText = newCategoryId;
                        ExistingMapping.AppendChild(newCategory);

                        _QbMappingXml.Save(QBMappingspath);
                        return;




                    }


                    else if (!string.IsNullOrEmpty(QbnewAccounttxt.Text))
                    {

                        XmlNode existingAccount = _QbMappingXml.SelectSingleNode($"AccountMappings/Account[@Id = {QbnewAccounttxt.Text}]");
                        if (existingAccount != null)
                        {
                            MessageBox.Show($"QB Account : {QbnewAccounttxt} already exist ,Please select from the dropdown ");
                            return;
                        }

                        XmlElement newAccountId = _QbMappingXml.CreateElement("Account");
                        newAccountId.SetAttribute("Id", QbnewAccounttxt.Text);



                        XmlNode existingCategory1 = _QbMappingXml.SelectSingleNode($"AccountMappings/Account/Category[text()= '{newCategoryId}']");
                        if (existingCategory1 != null)
                        {
                            MessageBox.Show($"Category: {newCategoryId} already exist and mapped");
                            return;
                        }

                        XmlElement newCategory = _QbMappingXml.CreateElement("Category");
                        newCategory.InnerText = newCategoryId;
                        newAccountId.AppendChild(newCategory);

                        root.AppendChild(newAccountId);

                        _QbMappingXml.Save(QBMappingspath);

                        MessageBox.Show($"Category {newCategoryId} added to {QbnewAccounttxt.Text} ");

                    }

                }



                catch (Exception ex)
                {
                    MessageBox.Show($"Error while adding Category to QB Account Mapping due to {ex.Message}");
                    return;

                }

                //Create new Account code based on business and Revenue

                try
                {
                    var _QbAccountCodeXml = QbAccountCodeXml();

                    XmlElement root = _QbAccountCodeXml.DocumentElement;

                    if (!string.IsNullOrEmpty(QbAccountCodetxt.Text))
                    {

                        XmlNode existingAccountCode = _QbAccountCodeXml.SelectSingleNode($"AccountCodeMappings/AccountCode[@Id = '{QbAccountCodetxt.Text}']");
                        XmlNode existingAccountCodeR = _QbAccountCodeXml.SelectSingleNode($"AccountCodeMappings/AccountCode[@Id = 'R{QbAccountCodetxt.Text}']");
                        XmlNode existingAccountCodeB = _QbAccountCodeXml.SelectSingleNode($"AccountCodeMappings/AccountCode[@Id = 'B{QbAccountCodetxt.Text}']");

                        if (existingAccountCode != null || existingAccountCodeR != null || existingAccountCodeB != null)
                        {
                            MessageBox.Show($"Account Code already exist, Please provide a new one ");
                            return;
                        }

                        if (ResidentialCheckbox.Checked || OtherCheckBox.Checked)
                        {
                            XmlElement NewRevenueAccountCode = _QbAccountCodeXml.CreateElement("AccountCode");
                            NewRevenueAccountCode.SetAttribute("Id", "R" + QbAccountCodetxt.Text.ToUpper());

                            XmlElement NewAccountName = _QbAccountCodeXml.CreateElement("AccountName");
                            NewAccountName.InnerText = QbnewAccounttxt.Text;

                            NewRevenueAccountCode.AppendChild(NewAccountName);


                            root.AppendChild(NewRevenueAccountCode);

                            _QbAccountCodeXml.Save(QBAccountCodePath);

                            MessageBox.Show($"Revenue Account {QbAccountCodetxt.Text} Created");

                        }

                        if (BusinessCheckbox.Checked || OtherCheckBox.Checked)
                        {
                            XmlElement NewRevenueAccountCode = _QbAccountCodeXml.CreateElement("AccountCode");
                            NewRevenueAccountCode.SetAttribute("Id", "B" + QbAccountCodetxt.Text.ToUpper());

                            XmlElement NewAccountName = _QbAccountCodeXml.CreateElement("AccountName");
                            NewAccountName.InnerText = QbnewAccounttxt.Text;

                            NewRevenueAccountCode.AppendChild(NewAccountName);


                            root.AppendChild(NewRevenueAccountCode);

                            _QbAccountCodeXml.Save(QBAccountCodePath);

                            MessageBox.Show($"Business Account {QbAccountCodetxt.Text} Created");

                        }

                        //if (BusinessCheckbox.Checked)
                        //{
                        //    XmlElement NewRevenueAccountCode = _QbAccountCodeXml.CreateElement("AccountCode");
                        //    NewRevenueAccountCode.SetAttribute("Id", "B" + QbAccountCodetxt.Text.ToUpper());

                        //    XmlElement NewAccountName = _QbAccountCodeXml.CreateElement("AccountName");
                        //    NewAccountName.InnerText = QbnewAccounttxt.Text;

                        //    NewRevenueAccountCode.AppendChild(NewAccountName);


                        //    root.AppendChild(NewRevenueAccountCode);

                        //    _QbAccountCodeXml.Save(QBAccountCodePath);

                        //    MessageBox.Show($"Business Account {QbAccountCodetxt.Text} Created");

                        //}






                    }
                    else
                    {
                        MessageBox.Show($"Account code cannot be empty");
                        return;
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Error while adding account code due to {ex.Message}");
                }


                //Create Account Path based on the Revenue and Business

                try
                {
                    var _QBAccountsPath = QBAccountsPath();

                    XmlElement root = _QBAccountsPath.DocumentElement;

                    if ((ResidentialCheckbox.Checked && !string.IsNullOrEmpty(ResidentialEarnedPath.Text) && !string.IsNullOrEmpty(ResidentialDeferredPath.Text) ||
                        OtherCheckBox.Checked && !string.IsNullOrEmpty(ResidentialEarnedPath.Text) && !string.IsNullOrEmpty(ResidentialDeferredPath.Text)))
                    {
                        XmlElement newResidentialEarnedPath = _QBAccountsPath.CreateElement("Path");
                        newResidentialEarnedPath.SetAttribute("Id", "Earned");
                        newResidentialEarnedPath.InnerText = ResidentialEarnedPath.Text;

                        XmlElement newResidentialDeferredPath = _QBAccountsPath.CreateElement("Path");
                        newResidentialEarnedPath.SetAttribute("Id", "Deferred");
                        newResidentialEarnedPath.InnerText = ResidentialDeferredPath.Text;


                        XmlElement newRevenueAccountCode = _QBAccountsPath.CreateElement("AccountCode");
                        newRevenueAccountCode.SetAttribute("Id", "R" + QbAccountCodetxt.Text);

                        newRevenueAccountCode.AppendChild(newResidentialEarnedPath);
                        newRevenueAccountCode.AppendChild(newResidentialDeferredPath);

                        root.AppendChild(newRevenueAccountCode);

                        _QBAccountsPath.Save(QBAccountPath);

                    }

                    if (BusinessCheckbox.Checked && !string.IsNullOrEmpty(BusinessEarnedPath.Text) && !string.IsNullOrEmpty(BusinessDeferredPath.Text) ||
                        OtherCheckBox.Checked && !string.IsNullOrEmpty(BusinessEarnedPath.Text) && !string.IsNullOrEmpty(BusinessDeferredPath.Text))
                    {
                        XmlElement newBusinessEarnedPath = _QBAccountsPath.CreateElement("Path");
                        newBusinessEarnedPath.SetAttribute("Id", "Earned");
                        newBusinessEarnedPath.InnerText = BusinessEarnedPath.Text;

                        XmlElement newBusinessDeferredPath = _QBAccountsPath.CreateElement("Path");
                        newBusinessDeferredPath.SetAttribute("Id", "Deferred");
                        newBusinessDeferredPath.InnerText = BusinessDeferredPath.Text;


                        XmlElement newBusinessAccountCode = _QBAccountsPath.CreateElement("AccountCode");
                        newBusinessAccountCode.SetAttribute("Id", "B" + QbAccountCodetxt.Text);

                        newBusinessAccountCode.AppendChild(newBusinessEarnedPath);
                        newBusinessAccountCode.AppendChild(newBusinessDeferredPath);

                        root.AppendChild(newBusinessAccountCode);

                        _QBAccountsPath.Save(QBAccountPath);

                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding Filepath: {ex.Message}");
                }


                MessageBox.Show($"All the required fields added successfully");

            }
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
                        label8.Text = "Category already exists!";
                        label8.Visible = true;
                        label8.ForeColor = Color.Red;
                        
                        InputEnabledFalse();
                        return;  // Exit as we found a match
                    }
                }

                // If no match is found, proceed with other logic
                //MessageBox.Show("Category is available for use.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label8.ForeColor = Color.Green;
                label8.Visible = true;
                label8.Text = @"Category is available for use.";
                newItemTextBox.Enabled = true;



            }
        }




        //method to check if the category already exist     
       

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
                        // MessageBox.Show("Item already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //qbMapping_comboBox.Enabled = false;
                        //AddNewAccount.Enabled = false;

                        label9.ForeColor = Color.Red;
                        label9.Visible = true;
                        label9.Text = "Item is not available for use.";
                        InputEnabledFalse();
                        return;  // Exit as we found a match
                    }
                }

                // If no match is found, proceed with other logic
                // MessageBox.Show("Item is available for use.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label9.Visible = true;
                label9.ForeColor = Color.Green;
                label9.Text = "Item is available for use.";
                qbMapping_comboBox.Enabled = true;
                AddNewAccount.Enabled = true;


            }
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
                        //MessageBox.Show("Quickbooks Account Name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        label10.Visible = true;
                        label10.Text = "Quickbooks Account Name already exists!";
                        label10.ForeColor = Color.Red;
                        InputEnabledFalse();

                        return;  // Exit as we found a match
                    }
                }

                // If no match is found, proceed with other logic
                // MessageBox.Show("Quickbooks Account Name is available for use.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label10.Visible = true;
                label10.Text = "Quickbooks Account Name is available for use.";
                label10.ForeColor = Color.Green;
                ResidentialCheckbox.Enabled = true;
                BusinessCheckbox.Enabled = true;
                OtherCheckBox.Enabled = true;
                QbAccountCodetxt.Enabled = true;


            }
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
                        label11.Text = " Account Code already exists";
                        InputEnabledFalse();
                        return;  // Exit as we found a match
                    }
                }

                // If no match is found, proceed with other logic
                //MessageBox.Show(" Account Code is available for use.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label11.Visible = true;
                label11.Text = " Account Code is available for use.";
                ResidentialEarnedPath.Enabled = true;
                ResidentialDeferredPath.Enabled = true;
                BusinessEarnedPath.Enabled = true;
                BusinessDeferredPath.Enabled = true;



            }
        }

        

        private string  CheckAccountPathExists(string QbnewAccountPath )
        {
            string returnString = "";
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
                        returnString = " Account Path already exists!";
                        return returnString;  // Exit as we found a match
                    }
                }

                // If no match is found, proceed with other logic
                returnString = " Account Path is available for use.";
                return returnString;
               


            }
            return returnString;
        }

     
        private void AddNewAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QbnewAccounttxt.Enabled = true;
            qbMapping_comboBox.ResetText();


        }

        private void qbMapping_comboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            QbnewAccounttxt.Enabled = false;
            QbnewAccounttxt.Clear();
        }


        public void InputEnabledFalse()
        {
            if (label8.Text.ToString() == "Category already exists!")
            {
                ItemVisibleFalse();
                AccountNameVisibleFalse();
                AccountTextVisibleFalse();
                CheckboxVisibleFalse();
                AccountCodeVisibleFalse();
                PathVisibleFalse();
            }

            else if (label9.Text.ToString() == "Item is not available for use.")
            {
                AccountNameVisibleFalse();
                AccountTextVisibleFalse();
                CheckboxVisibleFalse();
                AccountCodeVisibleFalse();
                PathVisibleFalse();
            }
            else if (label10.Text.ToString() == "Quickbooks Account Name already exists!")
            {
               
                CheckboxVisibleFalse();
                AccountCodeVisibleFalse();
                PathVisibleFalse();

            }

            else if (label11.Text.ToString() == " Account Code already exists")
            {
               
                PathVisibleFalse();
            }

           



        }

        public void ItemVisibleFalse()
        {
            newItemTextBox.Enabled = false;
            label9.Visible = false;
            newItemTextBox.Clear();

        }

        public void AccountNameVisibleFalse()
        {
            qbMapping_comboBox.Enabled = false;
            qbMapping_comboBox.ResetText();


        }

        public void AccountTextVisibleFalse()
        {
            QbnewAccounttxt.Enabled = false;
            label10.Visible = false;
            QbnewAccounttxt.Clear();

        }

        public void CheckboxVisibleFalse()
        {
            ResidentialCheckbox.Enabled = false;
            BusinessCheckbox.Enabled = false;
            OtherCheckBox.Enabled = false;
            ResidentialCheckbox.Checked = false;
            BusinessCheckbox.Checked = false;
            OtherCheckBox.Checked = false;



        }

        public void AccountCodeVisibleFalse()
        {
            QbAccountCodetxt.Enabled = false;
            label11.Visible = false;
            QbAccountCodetxt.Clear();
        }

        public void PathVisibleFalse()
        {
            ResidentialEarnedPath.Enabled = false;
            ResidentialDeferredPath.Enabled = false;
            BusinessEarnedPath.Enabled = false;
            BusinessDeferredPath.Enabled = false;

            ResidentialEarnedPath.Clear();
            ResidentialDeferredPath.Clear();
            BusinessEarnedPath.Clear();
            BusinessDeferredPath.Clear();

            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
        }



    }
}






