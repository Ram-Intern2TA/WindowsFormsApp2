using System.Windows.Forms;

namespace WindowsFormsApp2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.spAddItems = new System.Windows.Forms.Button();
            this.spAddCategory = new System.Windows.Forms.Button();
            this.addItemButton = new System.Windows.Forms.Button();
            this.AddCategoryLabel = new System.Windows.Forms.Label();
            this.newCategoryTextBox = new System.Windows.Forms.TextBox();
            this.ItemNameLabel = new System.Windows.Forms.Label();
            this.newItemTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.qbMapping_comboBox = new System.Windows.Forms.ComboBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.QbnewAccounttxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ResidentialCheckbox = new System.Windows.Forms.CheckBox();
            this.BusinessCheckbox = new System.Windows.Forms.CheckBox();
            this.OtherCheckBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.QbAccountCodetxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ResidentialEarnedPath = new System.Windows.Forms.TextBox();
            this.ResidentialDeferredPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BusinessDeferredPath = new System.Windows.Forms.TextBox();
            this.BusinessEarnedPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.OtherAccountPath = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.spAddItems);
            this.panel1.Controls.Add(this.spAddCategory);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 614);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(101, 350);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 2;
            // 
            // spAddItems
            // 
            this.spAddItems.BackColor = System.Drawing.Color.Black;
            this.spAddItems.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.spAddItems.ForeColor = System.Drawing.Color.Black;
            this.spAddItems.Image = ((System.Drawing.Image)(resources.GetObject("spAddItems.Image")));
            this.spAddItems.Location = new System.Drawing.Point(0, 146);
            this.spAddItems.Name = "spAddItems";
            this.spAddItems.Size = new System.Drawing.Size(169, 142);
            this.spAddItems.TabIndex = 1;
            this.spAddItems.Text = "Add Items";
            this.spAddItems.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.spAddItems.UseVisualStyleBackColor = false;
            this.spAddItems.Click += new System.EventHandler(this.spAddItems_Click);
            // 
            // spAddCategory
            // 
            this.spAddCategory.BackColor = System.Drawing.Color.Black;
            this.spAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.spAddCategory.ForeColor = System.Drawing.Color.Black;
            this.spAddCategory.Image = ((System.Drawing.Image)(resources.GetObject("spAddCategory.Image")));
            this.spAddCategory.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.spAddCategory.Location = new System.Drawing.Point(0, 0);
            this.spAddCategory.Name = "spAddCategory";
            this.spAddCategory.Size = new System.Drawing.Size(169, 147);
            this.spAddCategory.TabIndex = 0;
            this.spAddCategory.Text = "Add Category";
            this.spAddCategory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.spAddCategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.spAddCategory.UseVisualStyleBackColor = false;
            // 
            // addItemButton
            // 
            this.addItemButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addItemButton.Location = new System.Drawing.Point(191, 562);
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(90, 30);
            this.addItemButton.TabIndex = 17;
            this.addItemButton.Text = "AddItems";
            this.addItemButton.UseVisualStyleBackColor = true;
            this.addItemButton.Click += new System.EventHandler(this.addItemButton_Click);
            // 
            // AddCategoryLabel
            // 
            this.AddCategoryLabel.AutoSize = true;
            this.AddCategoryLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AddCategoryLabel.Location = new System.Drawing.Point(210, 55);
            this.AddCategoryLabel.Name = "AddCategoryLabel";
            this.AddCategoryLabel.Size = new System.Drawing.Size(146, 13);
            this.AddCategoryLabel.TabIndex = 16;
            this.AddCategoryLabel.Text = "Add new Platt category name";
            // 
            // newCategoryTextBox
            // 
            this.newCategoryTextBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.newCategoryTextBox.Location = new System.Drawing.Point(378, 52);
            this.newCategoryTextBox.Name = "newCategoryTextBox";
            this.newCategoryTextBox.Size = new System.Drawing.Size(121, 20);
            this.newCategoryTextBox.TabIndex = 15;
            this.newCategoryTextBox.Leave += new System.EventHandler(this.newCategoryTextBox_Leave);
            // 
            // ItemNameLabel
            // 
            this.ItemNameLabel.AutoSize = true;
            this.ItemNameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ItemNameLabel.Location = new System.Drawing.Point(210, 104);
            this.ItemNameLabel.Name = "ItemNameLabel";
            this.ItemNameLabel.Size = new System.Drawing.Size(99, 13);
            this.ItemNameLabel.TabIndex = 14;
            this.ItemNameLabel.Text = "Invoice Item Name:";
            // 
            // newItemTextBox
            // 
            this.newItemTextBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.newItemTextBox.Location = new System.Drawing.Point(378, 101);
            this.newItemTextBox.Name = "newItemTextBox";
            this.newItemTextBox.Size = new System.Drawing.Size(121, 20);
            this.newItemTextBox.TabIndex = 13;
            this.newItemTextBox.Leave += new System.EventHandler(this.newItemTextBox_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(211, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "QB Account Name:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // qbMapping_comboBox
            // 
            this.qbMapping_comboBox.FormattingEnabled = true;
            this.qbMapping_comboBox.Location = new System.Drawing.Point(378, 147);
            this.qbMapping_comboBox.Name = "qbMapping_comboBox";
            this.qbMapping_comboBox.Size = new System.Drawing.Size(121, 21);
            this.qbMapping_comboBox.TabIndex = 19;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(516, 155);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(54, 13);
            this.linkLabel2.TabIndex = 21;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Add New ";
            // 
            // QbnewAccounttxt
            // 
            this.QbnewAccounttxt.Location = new System.Drawing.Point(594, 155);
            this.QbnewAccounttxt.Name = "QbnewAccounttxt";
            this.QbnewAccounttxt.Size = new System.Drawing.Size(156, 20);
            this.QbnewAccounttxt.TabIndex = 22;
            this.QbnewAccounttxt.Leave += new System.EventHandler(this.QbnewAccounttxt_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(211, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "QB Account type:";
            // 
            // ResidentialCheckbox
            // 
            this.ResidentialCheckbox.AutoSize = true;
            this.ResidentialCheckbox.ForeColor = System.Drawing.Color.Black;
            this.ResidentialCheckbox.Location = new System.Drawing.Point(328, 202);
            this.ResidentialCheckbox.Name = "ResidentialCheckbox";
            this.ResidentialCheckbox.Size = new System.Drawing.Size(125, 17);
            this.ResidentialCheckbox.TabIndex = 24;
            this.ResidentialCheckbox.Text = "Residential Revenue";
            this.ResidentialCheckbox.UseVisualStyleBackColor = true;
            // 
            // BusinessCheckbox
            // 
            this.BusinessCheckbox.AutoSize = true;
            this.BusinessCheckbox.ForeColor = System.Drawing.Color.Black;
            this.BusinessCheckbox.Location = new System.Drawing.Point(459, 202);
            this.BusinessCheckbox.Name = "BusinessCheckbox";
            this.BusinessCheckbox.Size = new System.Drawing.Size(115, 17);
            this.BusinessCheckbox.TabIndex = 25;
            this.BusinessCheckbox.Text = "Business Revenue";
            this.BusinessCheckbox.UseVisualStyleBackColor = true;
            // 
            // OtherCheckBox
            // 
            this.OtherCheckBox.AutoSize = true;
            this.OtherCheckBox.ForeColor = System.Drawing.Color.Black;
            this.OtherCheckBox.Location = new System.Drawing.Point(582, 203);
            this.OtherCheckBox.Name = "OtherCheckBox";
            this.OtherCheckBox.Size = new System.Drawing.Size(122, 17);
            this.OtherCheckBox.TabIndex = 26;
            this.OtherCheckBox.Text = "Other Account Type";
            this.OtherCheckBox.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(211, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Enter Account code :";
            // 
            // QbAccountCodetxt
            // 
            this.QbAccountCodetxt.Location = new System.Drawing.Point(328, 242);
            this.QbAccountCodetxt.Name = "QbAccountCodetxt";
            this.QbAccountCodetxt.Size = new System.Drawing.Size(100, 20);
            this.QbAccountCodetxt.TabIndex = 28;
            this.QbAccountCodetxt.Leave += new System.EventHandler(this.QbAccountCodetxt_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(211, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Residential Earned RevenuePath :";
            // 
            // ResidentialEarnedPath
            // 
            this.ResidentialEarnedPath.Location = new System.Drawing.Point(391, 287);
            this.ResidentialEarnedPath.Name = "ResidentialEarnedPath";
            this.ResidentialEarnedPath.Size = new System.Drawing.Size(462, 20);
            this.ResidentialEarnedPath.TabIndex = 30;
            this.ResidentialEarnedPath.Leave += new System.EventHandler(this.ResidentialEarnedPath_Leave);
            // 
            // ResidentialDeferredPath
            // 
            this.ResidentialDeferredPath.Location = new System.Drawing.Point(391, 328);
            this.ResidentialDeferredPath.Name = "ResidentialDeferredPath";
            this.ResidentialDeferredPath.Size = new System.Drawing.Size(462, 20);
            this.ResidentialDeferredPath.TabIndex = 31;
            this.ResidentialDeferredPath.Leave += new System.EventHandler(this.ResidentialDeferredPath_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(211, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Residential Deferred RevenuePath :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(211, 412);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(171, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Business Deferred Revenue Path :";
            // 
            // BusinessDeferredPath
            // 
            this.BusinessDeferredPath.Location = new System.Drawing.Point(391, 405);
            this.BusinessDeferredPath.Name = "BusinessDeferredPath";
            this.BusinessDeferredPath.Size = new System.Drawing.Size(462, 20);
            this.BusinessDeferredPath.TabIndex = 35;
            this.BusinessDeferredPath.Leave += new System.EventHandler(this.BusinessDeferredPath_Leave);
            // 
            // BusinessEarnedPath
            // 
            this.BusinessEarnedPath.Location = new System.Drawing.Point(391, 368);
            this.BusinessEarnedPath.Name = "BusinessEarnedPath";
            this.BusinessEarnedPath.Size = new System.Drawing.Size(462, 20);
            this.BusinessEarnedPath.TabIndex = 34;
            this.BusinessEarnedPath.Leave += new System.EventHandler(this.BusinessEarnedPath_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(211, 371);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(164, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Business Earned Revenue Path :";
            // 
            // OtherAccountPath
            // 
            this.OtherAccountPath.Location = new System.Drawing.Point(391, 457);
            this.OtherAccountPath.Name = "OtherAccountPath";
            this.OtherAccountPath.Size = new System.Drawing.Size(462, 20);
            this.OtherAccountPath.TabIndex = 38;
            this.OtherAccountPath.Leave += new System.EventHandler(this.OtherAccountPath_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(211, 460);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Other Account Debit Path";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(917, 614);
            this.Controls.Add(this.OtherAccountPath);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BusinessDeferredPath);
            this.Controls.Add(this.BusinessEarnedPath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ResidentialDeferredPath);
            this.Controls.Add(this.ResidentialEarnedPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.QbAccountCodetxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OtherCheckBox);
            this.Controls.Add(this.BusinessCheckbox);
            this.Controls.Add(this.ResidentialCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.QbnewAccounttxt);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.qbMapping_comboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addItemButton);
            this.Controls.Add(this.AddCategoryLabel);
            this.Controls.Add(this.newCategoryTextBox);
            this.Controls.Add(this.ItemNameLabel);
            this.Controls.Add(this.newItemTextBox);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.DarkOrange;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button spAddCategory;
        private System.Windows.Forms.Button spAddItems;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button addItemButton;
        private System.Windows.Forms.Label AddCategoryLabel;
        private System.Windows.Forms.TextBox newCategoryTextBox;
        private System.Windows.Forms.Label ItemNameLabel;
        private System.Windows.Forms.TextBox newItemTextBox;
        private Label label1;
        private ComboBox qbMapping_comboBox;
        private LinkLabel linkLabel2;
        private TextBox QbnewAccounttxt;
        private Label label2;
        private CheckBox ResidentialCheckbox;
        private CheckBox BusinessCheckbox;
        private CheckBox OtherCheckBox;
        private Label label3;
        private TextBox QbAccountCodetxt;
        private Label label4;
        private TextBox ResidentialEarnedPath;
        private TextBox ResidentialDeferredPath;
        private Label label5;
        private Label label6;
        private TextBox BusinessDeferredPath;
        private TextBox BusinessEarnedPath;
        private Label label7;
        private TextBox OtherAccountPath;
        private Label label10;
    }
}

