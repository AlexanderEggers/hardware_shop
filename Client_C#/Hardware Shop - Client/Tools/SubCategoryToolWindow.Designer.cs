namespace Hardware_Shop_Client.Tools
{
    partial class SubCategoryToolWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_deleteSubCategory = new System.Windows.Forms.Button();
            this.button_editSubCategory = new System.Windows.Forms.Button();
            this.textBox_editSubCategory = new System.Windows.Forms.TextBox();
            this.label_editSubCategory = new System.Windows.Forms.Label();
            this.label_editSubCategoryName = new System.Windows.Forms.Label();
            this.button_createSubCategory = new System.Windows.Forms.Button();
            this.textBox_createSubCategory = new System.Windows.Forms.TextBox();
            this.label_createSubCategory = new System.Windows.Forms.Label();
            this.label_newSubCategoryName = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.dataGridView_subcategories = new System.Windows.Forms.DataGridView();
            this.Column_searchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_searchTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_subcategories)).BeginInit();
            this.SuspendLayout();
            // 
            // button_deleteSubCategory
            // 
            this.button_deleteSubCategory.Location = new System.Drawing.Point(137, 210);
            this.button_deleteSubCategory.Name = "button_deleteSubCategory";
            this.button_deleteSubCategory.Size = new System.Drawing.Size(75, 23);
            this.button_deleteSubCategory.TabIndex = 102;
            this.button_deleteSubCategory.Text = "Delete";
            this.button_deleteSubCategory.UseVisualStyleBackColor = true;
            this.button_deleteSubCategory.Click += new System.EventHandler(this.button_deleteSubCategory_Click);
            // 
            // button_editSubCategory
            // 
            this.button_editSubCategory.Location = new System.Drawing.Point(18, 210);
            this.button_editSubCategory.Name = "button_editSubCategory";
            this.button_editSubCategory.Size = new System.Drawing.Size(75, 23);
            this.button_editSubCategory.TabIndex = 101;
            this.button_editSubCategory.Text = "Edit";
            this.button_editSubCategory.UseVisualStyleBackColor = true;
            this.button_editSubCategory.Click += new System.EventHandler(this.button_editSubCategory_Click);
            // 
            // textBox_editSubCategory
            // 
            this.textBox_editSubCategory.Location = new System.Drawing.Point(56, 173);
            this.textBox_editSubCategory.Name = "textBox_editSubCategory";
            this.textBox_editSubCategory.Size = new System.Drawing.Size(156, 20);
            this.textBox_editSubCategory.TabIndex = 100;
            // 
            // label_editSubCategory
            // 
            this.label_editSubCategory.AutoSize = true;
            this.label_editSubCategory.Location = new System.Drawing.Point(112, 144);
            this.label_editSubCategory.Name = "label_editSubCategory";
            this.label_editSubCategory.Size = new System.Drawing.Size(43, 13);
            this.label_editSubCategory.TabIndex = 99;
            this.label_editSubCategory.Text = "Edit tag";
            // 
            // label_editSubCategoryName
            // 
            this.label_editSubCategoryName.AutoSize = true;
            this.label_editSubCategoryName.Location = new System.Drawing.Point(15, 176);
            this.label_editSubCategoryName.Name = "label_editSubCategoryName";
            this.label_editSubCategoryName.Size = new System.Drawing.Size(38, 13);
            this.label_editSubCategoryName.TabIndex = 98;
            this.label_editSubCategoryName.Text = "Name:";
            // 
            // button_createSubCategory
            // 
            this.button_createSubCategory.Location = new System.Drawing.Point(18, 87);
            this.button_createSubCategory.Name = "button_createSubCategory";
            this.button_createSubCategory.Size = new System.Drawing.Size(75, 23);
            this.button_createSubCategory.TabIndex = 97;
            this.button_createSubCategory.Text = "Create";
            this.button_createSubCategory.UseVisualStyleBackColor = true;
            this.button_createSubCategory.Click += new System.EventHandler(this.button_createSubCategory_Click);
            // 
            // textBox_createCategory
            // 
            this.textBox_createSubCategory.Location = new System.Drawing.Point(56, 50);
            this.textBox_createSubCategory.Name = "textBox_createCategory";
            this.textBox_createSubCategory.Size = new System.Drawing.Size(156, 20);
            this.textBox_createSubCategory.TabIndex = 96;
            // 
            // label_createSubCategory
            // 
            this.label_createSubCategory.AutoSize = true;
            this.label_createSubCategory.Location = new System.Drawing.Point(104, 23);
            this.label_createSubCategory.Name = "label_createSubCategory";
            this.label_createSubCategory.Size = new System.Drawing.Size(56, 13);
            this.label_createSubCategory.TabIndex = 95;
            this.label_createSubCategory.Text = "Create tag";
            // 
            // label_newSubCategoryName
            // 
            this.label_newSubCategoryName.AutoSize = true;
            this.label_newSubCategoryName.Location = new System.Drawing.Point(15, 53);
            this.label_newSubCategoryName.Name = "label_newSubCategoryName";
            this.label_newSubCategoryName.Size = new System.Drawing.Size(38, 13);
            this.label_newSubCategoryName.TabIndex = 94;
            this.label_newSubCategoryName.Text = "Name:";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(405, 14);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 93;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(243, 16);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(156, 20);
            this.textBox_search.TabIndex = 92;
            this.textBox_search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_search_KeyPress);
            // 
            // dataGridView_subcategories
            // 
            this.dataGridView_subcategories.AllowUserToAddRows = false;
            this.dataGridView_subcategories.AllowUserToDeleteRows = false;
            this.dataGridView_subcategories.AllowUserToResizeColumns = false;
            this.dataGridView_subcategories.AllowUserToResizeRows = false;
            this.dataGridView_subcategories.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_subcategories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_subcategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_subcategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_subcategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_searchID,
            this.Column_searchTag,
            this.Column_Items});
            this.dataGridView_subcategories.Location = new System.Drawing.Point(243, 50);
            this.dataGridView_subcategories.MultiSelect = false;
            this.dataGridView_subcategories.Name = "dataGridView_subcategories";
            this.dataGridView_subcategories.ReadOnly = true;
            this.dataGridView_subcategories.RowHeadersVisible = false;
            this.dataGridView_subcategories.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_subcategories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_subcategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_subcategories.Size = new System.Drawing.Size(237, 199);
            this.dataGridView_subcategories.TabIndex = 91;
            this.dataGridView_subcategories.SelectionChanged += new System.EventHandler(this.dataGridView_subcategories_SelectionChanged);
            // 
            // Column_searchID
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.Column_searchID.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column_searchID.HeaderText = "ID";
            this.Column_searchID.Name = "Column_searchID";
            this.Column_searchID.ReadOnly = true;
            this.Column_searchID.Width = 70;
            // 
            // Column_searchTag
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.Column_searchTag.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column_searchTag.HeaderText = "Tag";
            this.Column_searchTag.Name = "Column_searchTag";
            this.Column_searchTag.ReadOnly = true;
            this.Column_searchTag.Width = 105;
            // 
            // Column_Items
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.Column_Items.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column_Items.HeaderText = "Items";
            this.Column_Items.Name = "Column_Items";
            this.Column_Items.ReadOnly = true;
            this.Column_Items.Width = 60;
            // 
            // SubCategoryToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 262);
            this.Controls.Add(this.button_deleteSubCategory);
            this.Controls.Add(this.button_editSubCategory);
            this.Controls.Add(this.textBox_editSubCategory);
            this.Controls.Add(this.label_editSubCategory);
            this.Controls.Add(this.label_editSubCategoryName);
            this.Controls.Add(this.button_createSubCategory);
            this.Controls.Add(this.textBox_createSubCategory);
            this.Controls.Add(this.label_createSubCategory);
            this.Controls.Add(this.label_newSubCategoryName);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.dataGridView_subcategories);
            this.Name = "SubCategoryToolWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hardware Shop - SubCategory Tool";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_subcategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_deleteSubCategory;
        private System.Windows.Forms.Button button_editSubCategory;
        private System.Windows.Forms.TextBox textBox_editSubCategory;
        private System.Windows.Forms.Label label_editSubCategory;
        private System.Windows.Forms.Label label_editSubCategoryName;
        private System.Windows.Forms.Button button_createSubCategory;
        private System.Windows.Forms.TextBox textBox_createSubCategory;
        private System.Windows.Forms.Label label_createSubCategory;
        private System.Windows.Forms.Label label_newSubCategoryName;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.DataGridView dataGridView_subcategories;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_searchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_searchTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Items;
    }
}