namespace Hardware_Shop_Client.Tools
{
    partial class CategoryToolWindow
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
            this.button_deleteCategory = new System.Windows.Forms.Button();
            this.button_editCategory = new System.Windows.Forms.Button();
            this.textBox_editCategory = new System.Windows.Forms.TextBox();
            this.label_editCategory = new System.Windows.Forms.Label();
            this.label_editCategoryName = new System.Windows.Forms.Label();
            this.button_createCategory = new System.Windows.Forms.Button();
            this.textBox_createCategory = new System.Windows.Forms.TextBox();
            this.label_createCategory = new System.Windows.Forms.Label();
            this.label_newCategoryName = new System.Windows.Forms.Label();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.dataGridView_categories = new System.Windows.Forms.DataGridView();
            this.Column_searchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_searchTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_categories)).BeginInit();
            this.SuspendLayout();
            // 
            // button_deleteCategory
            // 
            this.button_deleteCategory.Location = new System.Drawing.Point(137, 210);
            this.button_deleteCategory.Name = "button_deleteCategory";
            this.button_deleteCategory.Size = new System.Drawing.Size(75, 23);
            this.button_deleteCategory.TabIndex = 90;
            this.button_deleteCategory.Text = "Delete";
            this.button_deleteCategory.UseVisualStyleBackColor = true;
            this.button_deleteCategory.Click += new System.EventHandler(this.button_deleteCategory_Click);
            // 
            // button_editCategory
            // 
            this.button_editCategory.Location = new System.Drawing.Point(18, 210);
            this.button_editCategory.Name = "button_editCategory";
            this.button_editCategory.Size = new System.Drawing.Size(75, 23);
            this.button_editCategory.TabIndex = 89;
            this.button_editCategory.Text = "Edit";
            this.button_editCategory.UseVisualStyleBackColor = true;
            this.button_editCategory.Click += new System.EventHandler(this.button_editCategory_Click);
            // 
            // textBox_editCategory
            // 
            this.textBox_editCategory.Location = new System.Drawing.Point(56, 173);
            this.textBox_editCategory.Name = "textBox_editCategory";
            this.textBox_editCategory.Size = new System.Drawing.Size(156, 20);
            this.textBox_editCategory.TabIndex = 88;
            // 
            // label_editCategory
            // 
            this.label_editCategory.AutoSize = true;
            this.label_editCategory.Location = new System.Drawing.Point(112, 144);
            this.label_editCategory.Name = "label_editCategory";
            this.label_editCategory.Size = new System.Drawing.Size(43, 13);
            this.label_editCategory.TabIndex = 87;
            this.label_editCategory.Text = "Edit tag";
            // 
            // label_editCategoryName
            // 
            this.label_editCategoryName.AutoSize = true;
            this.label_editCategoryName.Location = new System.Drawing.Point(15, 176);
            this.label_editCategoryName.Name = "label_editCategoryName";
            this.label_editCategoryName.Size = new System.Drawing.Size(38, 13);
            this.label_editCategoryName.TabIndex = 86;
            this.label_editCategoryName.Text = "Name:";
            // 
            // button_createCategory
            // 
            this.button_createCategory.Location = new System.Drawing.Point(18, 87);
            this.button_createCategory.Name = "button_createCategory";
            this.button_createCategory.Size = new System.Drawing.Size(75, 23);
            this.button_createCategory.TabIndex = 85;
            this.button_createCategory.Text = "Create";
            this.button_createCategory.UseVisualStyleBackColor = true;
            this.button_createCategory.Click += new System.EventHandler(this.button_createCategory_Click);
            // 
            // textBox_createCategory
            // 
            this.textBox_createCategory.Location = new System.Drawing.Point(56, 50);
            this.textBox_createCategory.Name = "textBox_createCategory";
            this.textBox_createCategory.Size = new System.Drawing.Size(156, 20);
            this.textBox_createCategory.TabIndex = 84;
            // 
            // label_createCategory
            // 
            this.label_createCategory.AutoSize = true;
            this.label_createCategory.Location = new System.Drawing.Point(104, 23);
            this.label_createCategory.Name = "label_createCategory";
            this.label_createCategory.Size = new System.Drawing.Size(56, 13);
            this.label_createCategory.TabIndex = 83;
            this.label_createCategory.Text = "Create tag";
            // 
            // label_newCategoryName
            // 
            this.label_newCategoryName.AutoSize = true;
            this.label_newCategoryName.Location = new System.Drawing.Point(15, 53);
            this.label_newCategoryName.Name = "label_newCategoryName";
            this.label_newCategoryName.Size = new System.Drawing.Size(38, 13);
            this.label_newCategoryName.TabIndex = 82;
            this.label_newCategoryName.Text = "Name:";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(405, 14);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 81;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(243, 16);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(156, 20);
            this.textBox_search.TabIndex = 80;
            this.textBox_search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_search_KeyPress);
            // 
            // dataGridView_categories
            // 
            this.dataGridView_categories.AllowUserToAddRows = false;
            this.dataGridView_categories.AllowUserToDeleteRows = false;
            this.dataGridView_categories.AllowUserToResizeColumns = false;
            this.dataGridView_categories.AllowUserToResizeRows = false;
            this.dataGridView_categories.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_categories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_categories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_categories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_categories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_searchID,
            this.Column_searchTag,
            this.Column_Items});
            this.dataGridView_categories.Location = new System.Drawing.Point(243, 50);
            this.dataGridView_categories.MultiSelect = false;
            this.dataGridView_categories.Name = "dataGridView_categories";
            this.dataGridView_categories.ReadOnly = true;
            this.dataGridView_categories.RowHeadersVisible = false;
            this.dataGridView_categories.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_categories.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_categories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_categories.Size = new System.Drawing.Size(237, 199);
            this.dataGridView_categories.TabIndex = 79;
            this.dataGridView_categories.SelectionChanged += new System.EventHandler(this.dataGridView_categories_SelectionChanged);
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
            // CategoryToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 262);
            this.Controls.Add(this.button_deleteCategory);
            this.Controls.Add(this.button_editCategory);
            this.Controls.Add(this.textBox_editCategory);
            this.Controls.Add(this.label_editCategory);
            this.Controls.Add(this.label_editCategoryName);
            this.Controls.Add(this.button_createCategory);
            this.Controls.Add(this.textBox_createCategory);
            this.Controls.Add(this.label_createCategory);
            this.Controls.Add(this.label_newCategoryName);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.dataGridView_categories);
            this.Name = "CategoryToolWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hardware Shop - Category Tool";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_categories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_deleteCategory;
        private System.Windows.Forms.Button button_editCategory;
        private System.Windows.Forms.TextBox textBox_editCategory;
        private System.Windows.Forms.Label label_editCategory;
        private System.Windows.Forms.Label label_editCategoryName;
        private System.Windows.Forms.Button button_createCategory;
        private System.Windows.Forms.TextBox textBox_createCategory;
        private System.Windows.Forms.Label label_createCategory;
        private System.Windows.Forms.Label label_newCategoryName;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.DataGridView dataGridView_categories;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_searchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_searchTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Items;
    }
}