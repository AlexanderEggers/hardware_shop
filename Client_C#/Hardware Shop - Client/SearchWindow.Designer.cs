namespace Hardware_Shop_Client
{
    partial class SearchWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_search = new System.Windows.Forms.Button();
            this.button_editor = new System.Windows.Forms.Button();
            this.button_tags = new System.Windows.Forms.Button();
            this.button_userlist = new System.Windows.Forms.Button();
            this.button_category = new System.Windows.Forms.Button();
            this.button_subcategory = new System.Windows.Forms.Button();
            this.button_manufacture = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label_editor = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.comboBox_editor = new System.Windows.Forms.ComboBox();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.comboBox_category = new System.Windows.Forms.ComboBox();
            this.label_category = new System.Windows.Forms.Label();
            this.comboBox_subCategory = new System.Windows.Forms.ComboBox();
            this.label_subCategory = new System.Windows.Forms.Label();
            this.comboBox_manufacture = new System.Windows.Forms.ComboBox();
            this.label_manufacture = new System.Windows.Forms.Label();
            this.date_creationDate = new System.Windows.Forms.DateTimePicker();
            this.date_editDate = new System.Windows.Forms.DateTimePicker();
            this.label_date = new System.Windows.Forms.Label();
            this.label_edit = new System.Windows.Forms.Label();
            this.label_maxResults = new System.Windows.Forms.Label();
            this.textBox_maxResults = new System.Windows.Forms.TextBox();
            this.comboBox_sortBy = new System.Windows.Forms.ComboBox();
            this.label_sortBy = new System.Windows.Forms.Label();
            this.checkBox_sortItems = new System.Windows.Forms.CheckBox();
            this.searchDataView = new System.Windows.Forms.DataGridView();
            this.Column_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Editor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_SubCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.searchDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // button_search
            // 
            this.button_search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_search.Location = new System.Drawing.Point(-1, -1);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(87, 31);
            this.button_search.TabIndex = 0;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            // 
            // button_editor
            // 
            this.button_editor.Location = new System.Drawing.Point(85, -1);
            this.button_editor.Name = "button_editor";
            this.button_editor.Size = new System.Drawing.Size(87, 31);
            this.button_editor.TabIndex = 1;
            this.button_editor.Text = "Editor";
            this.button_editor.UseVisualStyleBackColor = true;
            // 
            // button_tags
            // 
            this.button_tags.Location = new System.Drawing.Point(171, -1);
            this.button_tags.Name = "button_tags";
            this.button_tags.Size = new System.Drawing.Size(87, 31);
            this.button_tags.TabIndex = 2;
            this.button_tags.Text = "Tags";
            this.button_tags.UseVisualStyleBackColor = true;
            // 
            // button_userlist
            // 
            this.button_userlist.Location = new System.Drawing.Point(257, -1);
            this.button_userlist.Name = "button_userlist";
            this.button_userlist.Size = new System.Drawing.Size(87, 31);
            this.button_userlist.TabIndex = 3;
            this.button_userlist.Text = "Userlist";
            this.button_userlist.UseVisualStyleBackColor = true;
            // 
            // button_category
            // 
            this.button_category.Location = new System.Drawing.Point(343, -1);
            this.button_category.Name = "button_category";
            this.button_category.Size = new System.Drawing.Size(87, 31);
            this.button_category.TabIndex = 4;
            this.button_category.Text = "Category";
            this.button_category.UseVisualStyleBackColor = true;
            // 
            // button_subcategory
            // 
            this.button_subcategory.Location = new System.Drawing.Point(429, -1);
            this.button_subcategory.Name = "button_subcategory";
            this.button_subcategory.Size = new System.Drawing.Size(87, 31);
            this.button_subcategory.TabIndex = 5;
            this.button_subcategory.Text = "Subcategory";
            this.button_subcategory.UseVisualStyleBackColor = true;
            // 
            // button_manufacture
            // 
            this.button_manufacture.Location = new System.Drawing.Point(515, -1);
            this.button_manufacture.Name = "button_manufacture";
            this.button_manufacture.Size = new System.Drawing.Size(87, 31);
            this.button_manufacture.TabIndex = 6;
            this.button_manufacture.Text = "Manufacture";
            this.button_manufacture.UseVisualStyleBackColor = true;
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(29, 40);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(143, 20);
            this.textBox_search.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_search_Click);
            // 
            // label_editor
            // 
            this.label_editor.AutoSize = true;
            this.label_editor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_editor.Location = new System.Drawing.Point(26, 80);
            this.label_editor.Name = "label_editor";
            this.label_editor.Size = new System.Drawing.Size(37, 13);
            this.label_editor.TabIndex = 9;
            this.label_editor.Text = "Editor:";
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_status.Location = new System.Drawing.Point(26, 113);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(40, 13);
            this.label_status.TabIndex = 10;
            this.label_status.Text = "Status:";
            // 
            // comboBox_editor
            // 
            this.comboBox_editor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_editor.FormattingEnabled = true;
            this.comboBox_editor.Location = new System.Drawing.Point(83, 77);
            this.comboBox_editor.Name = "comboBox_editor";
            this.comboBox_editor.Size = new System.Drawing.Size(170, 21);
            this.comboBox_editor.TabIndex = 11;
            // 
            // comboBox_status
            // 
            this.comboBox_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Items.AddRange(new object[] {
            "published",
            "work in progess",
            "disabled"});
            this.comboBox_status.Location = new System.Drawing.Point(83, 110);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(170, 21);
            this.comboBox_status.TabIndex = 12;
            // 
            // comboBox_category
            // 
            this.comboBox_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_category.FormattingEnabled = true;
            this.comboBox_category.Location = new System.Drawing.Point(365, 40);
            this.comboBox_category.Name = "comboBox_category";
            this.comboBox_category.Size = new System.Drawing.Size(121, 21);
            this.comboBox_category.TabIndex = 14;
            // 
            // label_category
            // 
            this.label_category.AutoSize = true;
            this.label_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_category.Location = new System.Drawing.Point(285, 43);
            this.label_category.Name = "label_category";
            this.label_category.Size = new System.Drawing.Size(52, 13);
            this.label_category.TabIndex = 13;
            this.label_category.Text = "Category:";
            // 
            // comboBox_subCategory
            // 
            this.comboBox_subCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_subCategory.FormattingEnabled = true;
            this.comboBox_subCategory.Location = new System.Drawing.Point(365, 77);
            this.comboBox_subCategory.Name = "comboBox_subCategory";
            this.comboBox_subCategory.Size = new System.Drawing.Size(121, 21);
            this.comboBox_subCategory.TabIndex = 16;
            // 
            // label_subCategory
            // 
            this.label_subCategory.AutoSize = true;
            this.label_subCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_subCategory.Location = new System.Drawing.Point(285, 80);
            this.label_subCategory.Name = "label_subCategory";
            this.label_subCategory.Size = new System.Drawing.Size(74, 13);
            this.label_subCategory.TabIndex = 15;
            this.label_subCategory.Text = "Sub-Category:";
            // 
            // comboBox_manufacture
            // 
            this.comboBox_manufacture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_manufacture.FormattingEnabled = true;
            this.comboBox_manufacture.Location = new System.Drawing.Point(365, 113);
            this.comboBox_manufacture.Name = "comboBox_manufacture";
            this.comboBox_manufacture.Size = new System.Drawing.Size(121, 21);
            this.comboBox_manufacture.TabIndex = 18;
            // 
            // label_manufacture
            // 
            this.label_manufacture.AutoSize = true;
            this.label_manufacture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_manufacture.Location = new System.Drawing.Point(285, 116);
            this.label_manufacture.Name = "label_manufacture";
            this.label_manufacture.Size = new System.Drawing.Size(70, 13);
            this.label_manufacture.TabIndex = 17;
            this.label_manufacture.Text = "Manufacture:";
            // 
            // date_creationDate
            // 
            this.date_creationDate.Location = new System.Drawing.Point(586, 39);
            this.date_creationDate.Name = "date_creationDate";
            this.date_creationDate.Size = new System.Drawing.Size(145, 20);
            this.date_creationDate.TabIndex = 19;
            // 
            // date_editDate
            // 
            this.date_editDate.Location = new System.Drawing.Point(586, 77);
            this.date_editDate.Name = "date_editDate";
            this.date_editDate.Size = new System.Drawing.Size(145, 20);
            this.date_editDate.TabIndex = 20;
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Location = new System.Drawing.Point(530, 43);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(33, 13);
            this.label_date.TabIndex = 21;
            this.label_date.Text = "Date:";
            // 
            // label_edit
            // 
            this.label_edit.AutoSize = true;
            this.label_edit.Location = new System.Drawing.Point(530, 83);
            this.label_edit.Name = "label_edit";
            this.label_edit.Size = new System.Drawing.Size(28, 13);
            this.label_edit.TabIndex = 22;
            this.label_edit.Text = "Edit:";
            // 
            // label_maxResults
            // 
            this.label_maxResults.AutoSize = true;
            this.label_maxResults.Location = new System.Drawing.Point(773, 38);
            this.label_maxResults.Name = "label_maxResults";
            this.label_maxResults.Size = new System.Drawing.Size(74, 13);
            this.label_maxResults.TabIndex = 23;
            this.label_maxResults.Text = "Max. Results: ";
            // 
            // textBox_maxResults
            // 
            this.textBox_maxResults.Location = new System.Drawing.Point(881, 35);
            this.textBox_maxResults.Name = "textBox_maxResults";
            this.textBox_maxResults.Size = new System.Drawing.Size(44, 20);
            this.textBox_maxResults.TabIndex = 24;
            // 
            // comboBox_sortBy
            // 
            this.comboBox_sortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_sortBy.FormattingEnabled = true;
            this.comboBox_sortBy.Location = new System.Drawing.Point(881, 74);
            this.comboBox_sortBy.Name = "comboBox_sortBy";
            this.comboBox_sortBy.Size = new System.Drawing.Size(95, 21);
            this.comboBox_sortBy.TabIndex = 26;
            // 
            // label_sortBy
            // 
            this.label_sortBy.AutoSize = true;
            this.label_sortBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_sortBy.Location = new System.Drawing.Point(773, 77);
            this.label_sortBy.Name = "label_sortBy";
            this.label_sortBy.Size = new System.Drawing.Size(43, 13);
            this.label_sortBy.TabIndex = 25;
            this.label_sortBy.Text = "Sort by:";
            // 
            // checkBox_sortItems
            // 
            this.checkBox_sortItems.AutoSize = true;
            this.checkBox_sortItems.Location = new System.Drawing.Point(776, 112);
            this.checkBox_sortItems.Name = "checkBox_sortItems";
            this.checkBox_sortItems.Size = new System.Drawing.Size(72, 17);
            this.checkBox_sortItems.TabIndex = 27;
            this.checkBox_sortItems.Text = "Sort items";
            this.checkBox_sortItems.UseVisualStyleBackColor = true;
            // 
            // searchDataView
            // 
            this.searchDataView.AllowUserToDeleteRows = false;
            this.searchDataView.AllowUserToResizeColumns = false;
            this.searchDataView.AllowUserToResizeRows = false;
            this.searchDataView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.searchDataView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.searchDataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.searchDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_ID,
            this.Column_Editor,
            this.Column_Category,
            this.Column_SubCategory});
            this.searchDataView.Location = new System.Drawing.Point(3, 150);
            this.searchDataView.Name = "searchDataView";
            this.searchDataView.ReadOnly = true;
            this.searchDataView.RowHeadersVisible = false;
            this.searchDataView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.searchDataView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.searchDataView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.searchDataView.Size = new System.Drawing.Size(982, 416);
            this.searchDataView.TabIndex = 28;
            this.searchDataView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.searchDataView_CellMouseDoubleClick);
            // 
            // Column_ID
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.Column_ID.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column_ID.HeaderText = "ID";
            this.Column_ID.Name = "Column_ID";
            this.Column_ID.ReadOnly = true;
            this.Column_ID.Width = 245;
            // 
            // Column_Editor
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.Column_Editor.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column_Editor.HeaderText = "Editor";
            this.Column_Editor.Name = "Column_Editor";
            this.Column_Editor.ReadOnly = true;
            this.Column_Editor.Width = 245;
            // 
            // Column_Category
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.Column_Category.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column_Category.HeaderText = "Category";
            this.Column_Category.Name = "Column_Category";
            this.Column_Category.ReadOnly = true;
            this.Column_Category.Width = 245;
            // 
            // Column_SubCategory
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            this.Column_SubCategory.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column_SubCategory.HeaderText = "SubCategory";
            this.Column_SubCategory.Name = "Column_SubCategory";
            this.Column_SubCategory.ReadOnly = true;
            this.Column_SubCategory.Width = 245;
            // 
            // SearchWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 568);
            this.Controls.Add(this.searchDataView);
            this.Controls.Add(this.checkBox_sortItems);
            this.Controls.Add(this.comboBox_sortBy);
            this.Controls.Add(this.label_sortBy);
            this.Controls.Add(this.textBox_maxResults);
            this.Controls.Add(this.label_maxResults);
            this.Controls.Add(this.label_edit);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.date_editDate);
            this.Controls.Add(this.date_creationDate);
            this.Controls.Add(this.comboBox_manufacture);
            this.Controls.Add(this.label_manufacture);
            this.Controls.Add(this.comboBox_subCategory);
            this.Controls.Add(this.label_subCategory);
            this.Controls.Add(this.comboBox_category);
            this.Controls.Add(this.label_category);
            this.Controls.Add(this.comboBox_status);
            this.Controls.Add(this.comboBox_editor);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.label_editor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.button_manufacture);
            this.Controls.Add(this.button_subcategory);
            this.Controls.Add(this.button_category);
            this.Controls.Add(this.button_userlist);
            this.Controls.Add(this.button_tags);
            this.Controls.Add(this.button_editor);
            this.Controls.Add(this.button_search);
            this.Name = "SearchWindow";
            this.Text = "Hardware Shop - Search";
            ((System.ComponentModel.ISupportInitialize)(this.searchDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_editor;
        private System.Windows.Forms.Button button_tags;
        private System.Windows.Forms.Button button_userlist;
        private System.Windows.Forms.Button button_category;
        private System.Windows.Forms.Button button_subcategory;
        private System.Windows.Forms.Button button_manufacture;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_editor;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.ComboBox comboBox_editor;
        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.ComboBox comboBox_category;
        private System.Windows.Forms.Label label_category;
        private System.Windows.Forms.ComboBox comboBox_subCategory;
        private System.Windows.Forms.Label label_subCategory;
        private System.Windows.Forms.ComboBox comboBox_manufacture;
        private System.Windows.Forms.Label label_manufacture;
        private System.Windows.Forms.DateTimePicker date_creationDate;
        private System.Windows.Forms.DateTimePicker date_editDate;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.Label label_edit;
        private System.Windows.Forms.Label label_maxResults;
        private System.Windows.Forms.TextBox textBox_maxResults;
        private System.Windows.Forms.ComboBox comboBox_sortBy;
        private System.Windows.Forms.Label label_sortBy;
        private System.Windows.Forms.CheckBox checkBox_sortItems;
        private System.Windows.Forms.DataGridView searchDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Editor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_SubCategory;
    }
}