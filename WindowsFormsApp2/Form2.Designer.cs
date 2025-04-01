using System.Windows.Forms;

namespace WindowsFormsApp2
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.spAddItems = new System.Windows.Forms.Button();
            this.spAddCategory = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3_addItemButton_Click = new System.Windows.Forms.Button();
            this.panel3_ItemNameLabel = new System.Windows.Forms.Label();
            this.panel3_newItemTextBox = new System.Windows.Forms.TextBox();
            this.panel3_SelectCateogoryLabel = new System.Windows.Forms.Label();
            this.panel3_categoryComboBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.spAddItems);
            this.panel1.Controls.Add(this.spAddCategory);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // spAddItems
            // 
            this.spAddItems.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.spAddItems, "spAddItems");
            this.spAddItems.ForeColor = System.Drawing.Color.Black;
            this.spAddItems.Name = "spAddItems";
            this.spAddItems.UseVisualStyleBackColor = false;
            
            // 
            // spAddCategory
            // 
            this.spAddCategory.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this.spAddCategory, "spAddCategory");
            this.spAddCategory.ForeColor = System.Drawing.Color.Black;
            this.spAddCategory.Name = "spAddCategory";
            this.spAddCategory.UseVisualStyleBackColor = false;
            this.spAddCategory.Click += new System.EventHandler(this.spAddCategory_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3_addItemButton_Click);
            this.panel2.Controls.Add(this.panel3_ItemNameLabel);
            this.panel2.Controls.Add(this.panel3_newItemTextBox);
            this.panel2.Controls.Add(this.panel3_SelectCateogoryLabel);
            this.panel2.Controls.Add(this.panel3_categoryComboBox);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel3_addItemButton_Click
            // 
            this.panel3_addItemButton_Click.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.panel3_addItemButton_Click, "panel3_addItemButton_Click");
            this.panel3_addItemButton_Click.Name = "panel3_addItemButton_Click";
            this.panel3_addItemButton_Click.UseVisualStyleBackColor = true;
            this.panel3_addItemButton_Click.Click += new System.EventHandler(this.panel3_addItemButton_Click_Click);
            // 
            // panel3_ItemNameLabel
            // 
            resources.ApplyResources(this.panel3_ItemNameLabel, "panel3_ItemNameLabel");
            this.panel3_ItemNameLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3_ItemNameLabel.Name = "panel3_ItemNameLabel";
            // 
            // panel3_newItemTextBox
            // 
            this.panel3_newItemTextBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            resources.ApplyResources(this.panel3_newItemTextBox, "panel3_newItemTextBox");
            this.panel3_newItemTextBox.Name = "panel3_newItemTextBox";
            // 
            // panel3_SelectCateogoryLabel
            // 
            resources.ApplyResources(this.panel3_SelectCateogoryLabel, "panel3_SelectCateogoryLabel");
            this.panel3_SelectCateogoryLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3_SelectCateogoryLabel.Name = "panel3_SelectCateogoryLabel";
            // 
            // panel3_categoryComboBox
            // 
            this.panel3_categoryComboBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel3_categoryComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.panel3_categoryComboBox, "panel3_categoryComboBox");
            this.panel3_categoryComboBox.Name = "panel3_categoryComboBox";
            
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.FormClosing += new FormClosingEventHandler(Form2_FormClosing);


        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button spAddItems;
        private System.Windows.Forms.Button spAddCategory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button panel3_addItemButton_Click;
        private System.Windows.Forms.Label panel3_ItemNameLabel;
        private System.Windows.Forms.TextBox panel3_newItemTextBox;
        private System.Windows.Forms.Label panel3_SelectCateogoryLabel;
        private System.Windows.Forms.ComboBox panel3_categoryComboBox;
    }
}