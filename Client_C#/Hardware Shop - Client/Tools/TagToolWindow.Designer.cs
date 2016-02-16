namespace Hardware_Shop_Client
{
    partial class TagToolWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.dataGridView_tags = new System.Windows.Forms.DataGridView();
            this.Column_searchID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_searchTag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label_createTag = new System.Windows.Forms.Label();
            this.textBox_createName = new System.Windows.Forms.TextBox();
            this.button_createTag = new System.Windows.Forms.Button();
            this.button_editTag = new System.Windows.Forms.Button();
            this.textBox_editTag = new System.Windows.Forms.TextBox();
            this.label_editTag = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_deleteTag = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tags)).BeginInit();
            this.SuspendLayout();
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(407, 12);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 69;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(245, 14);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(156, 20);
            this.textBox_search.TabIndex = 68;
            this.textBox_search.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_search_KeyPress);
            // 
            // dataGridView_tags
            // 
            this.dataGridView_tags.AllowUserToAddRows = false;
            this.dataGridView_tags.AllowUserToDeleteRows = false;
            this.dataGridView_tags.AllowUserToResizeColumns = false;
            this.dataGridView_tags.AllowUserToResizeRows = false;
            this.dataGridView_tags.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_tags.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_tags.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_tags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_tags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_searchID,
            this.Column_searchTag});
            this.dataGridView_tags.Location = new System.Drawing.Point(245, 48);
            this.dataGridView_tags.MultiSelect = false;
            this.dataGridView_tags.Name = "dataGridView_tags";
            this.dataGridView_tags.ReadOnly = true;
            this.dataGridView_tags.RowHeadersVisible = false;
            this.dataGridView_tags.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView_tags.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_tags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_tags.Size = new System.Drawing.Size(237, 199);
            this.dataGridView_tags.TabIndex = 67;
            this.dataGridView_tags.SelectionChanged += new System.EventHandler(this.dataGridView_tags_SelectionChanged);
            // 
            // Column_searchID
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            this.Column_searchID.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column_searchID.HeaderText = "ID";
            this.Column_searchID.Name = "Column_searchID";
            this.Column_searchID.ReadOnly = true;
            this.Column_searchID.Width = 70;
            // 
            // Column_searchTag
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            this.Column_searchTag.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column_searchTag.HeaderText = "Tag";
            this.Column_searchTag.Name = "Column_searchTag";
            this.Column_searchTag.ReadOnly = true;
            this.Column_searchTag.Width = 167;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Name:";
            // 
            // label_createTag
            // 
            this.label_createTag.AutoSize = true;
            this.label_createTag.Location = new System.Drawing.Point(106, 21);
            this.label_createTag.Name = "label_createTag";
            this.label_createTag.Size = new System.Drawing.Size(56, 13);
            this.label_createTag.TabIndex = 71;
            this.label_createTag.Text = "Create tag";
            // 
            // textBox_createName
            // 
            this.textBox_createName.Location = new System.Drawing.Point(58, 48);
            this.textBox_createName.Name = "textBox_createName";
            this.textBox_createName.Size = new System.Drawing.Size(156, 20);
            this.textBox_createName.TabIndex = 72;
            // 
            // button_createTag
            // 
            this.button_createTag.Location = new System.Drawing.Point(20, 85);
            this.button_createTag.Name = "button_createTag";
            this.button_createTag.Size = new System.Drawing.Size(75, 23);
            this.button_createTag.TabIndex = 73;
            this.button_createTag.Text = "Create";
            this.button_createTag.UseVisualStyleBackColor = true;
            this.button_createTag.Click += new System.EventHandler(this.button_createTag_Click);
            // 
            // button_editTag
            // 
            this.button_editTag.Location = new System.Drawing.Point(20, 208);
            this.button_editTag.Name = "button_editTag";
            this.button_editTag.Size = new System.Drawing.Size(75, 23);
            this.button_editTag.TabIndex = 77;
            this.button_editTag.Text = "Edit";
            this.button_editTag.UseVisualStyleBackColor = true;
            this.button_editTag.Click += new System.EventHandler(this.button_editTag_Click);
            // 
            // textBox_editTag
            // 
            this.textBox_editTag.Location = new System.Drawing.Point(58, 171);
            this.textBox_editTag.Name = "textBox_editTag";
            this.textBox_editTag.Size = new System.Drawing.Size(156, 20);
            this.textBox_editTag.TabIndex = 76;
            // 
            // label_editTag
            // 
            this.label_editTag.AutoSize = true;
            this.label_editTag.Location = new System.Drawing.Point(114, 142);
            this.label_editTag.Name = "label_editTag";
            this.label_editTag.Size = new System.Drawing.Size(43, 13);
            this.label_editTag.TabIndex = 75;
            this.label_editTag.Text = "Edit tag";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 74;
            this.label4.Text = "Name:";
            // 
            // button_deleteTag
            // 
            this.button_deleteTag.Location = new System.Drawing.Point(139, 208);
            this.button_deleteTag.Name = "button_deleteTag";
            this.button_deleteTag.Size = new System.Drawing.Size(75, 23);
            this.button_deleteTag.TabIndex = 78;
            this.button_deleteTag.Text = "Delete";
            this.button_deleteTag.UseVisualStyleBackColor = true;
            this.button_deleteTag.Click += new System.EventHandler(this.button_deleteTag_Click);
            // 
            // TagToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 262);
            this.Controls.Add(this.button_deleteTag);
            this.Controls.Add(this.button_editTag);
            this.Controls.Add(this.textBox_editTag);
            this.Controls.Add(this.label_editTag);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_createTag);
            this.Controls.Add(this.textBox_createName);
            this.Controls.Add(this.label_createTag);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.dataGridView_tags);
            this.Name = "TagToolWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hardware Shop - Tag Tool";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_tags)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.DataGridView dataGridView_tags;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_searchID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_searchTag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_createTag;
        private System.Windows.Forms.TextBox textBox_createName;
        private System.Windows.Forms.Button button_createTag;
        private System.Windows.Forms.Button button_editTag;
        private System.Windows.Forms.TextBox textBox_editTag;
        private System.Windows.Forms.Label label_editTag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_deleteTag;
    }
}