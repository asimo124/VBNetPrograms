namespace WindowsFormsApplication1
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
            this.components = new System.ComponentModel.Container();
            this.cboPaths = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearchTerm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboFileTypes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvSearchResults = new System.Windows.Forms.DataGridView();
            this.Results = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenPHPStorm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboJustFiles = new System.Windows.Forms.CheckBox();
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tvCurrentPath = new System.Windows.Forms.TreeView();
            this.lblLoading = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.pathDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openNotePadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cboPaths
            // 
            this.cboPaths.FormattingEnabled = true;
            this.cboPaths.Location = new System.Drawing.Point(26, 37);
            this.cboPaths.Name = "cboPaths";
            this.cboPaths.Size = new System.Drawing.Size(390, 21);
            this.cboPaths.TabIndex = 0;
            this.cboPaths.SelectedIndexChanged += new System.EventHandler(this.cboPaths_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Path to Search";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSearchTerm
            // 
            this.txtSearchTerm.Location = new System.Drawing.Point(450, 91);
            this.txtSearchTerm.Name = "txtSearchTerm";
            this.txtSearchTerm.Size = new System.Drawing.Size(347, 20);
            this.txtSearchTerm.TabIndex = 1;
            this.txtSearchTerm.TextChanged += new System.EventHandler(this.txtSearchTerm_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Regex String to Search";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(806, 89);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.button2_Click);
            // 
            // cboFileTypes
            // 
            this.cboFileTypes.FormattingEnabled = true;
            this.cboFileTypes.Location = new System.Drawing.Point(172, 91);
            this.cboFileTypes.Name = "cboFileTypes";
            this.cboFileTypes.Size = new System.Drawing.Size(121, 21);
            this.cboFileTypes.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(169, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "File Type";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dgvSearchResults
            // 
            this.dgvSearchResults.AutoGenerateColumns = false;
            this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pathDataGridViewTextBoxColumn,
            this.Results,
            this.openNotePadDataGridViewTextBoxColumn,
            this.OpenPHPStorm,
            this.OpenPath});
            this.dgvSearchResults.DataSource = this.searchResultBindingSource;
            this.dgvSearchResults.Location = new System.Drawing.Point(291, 155);
            this.dgvSearchResults.Name = "dgvSearchResults";
            this.dgvSearchResults.Size = new System.Drawing.Size(1484, 601);
            this.dgvSearchResults.TabIndex = 8;
            this.dgvSearchResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResults_CellContentClick);
            // 
            // Results
            // 
            this.Results.DataPropertyName = "Results";
            this.Results.HeaderText = "Results";
            this.Results.Name = "Results";
            this.Results.Width = 560;
            // 
            // OpenPHPStorm
            // 
            this.OpenPHPStorm.DataPropertyName = "OpenPHPStorm";
            this.OpenPHPStorm.HeaderText = "Action 2";
            this.OpenPHPStorm.Name = "OpenPHPStorm";
            // 
            // OpenPath
            // 
            this.OpenPath.DataPropertyName = "OpenPath";
            this.OpenPath.HeaderText = "Action 3";
            this.OpenPath.Name = "OpenPath";
            // 
            // cboJustFiles
            // 
            this.cboJustFiles.AutoSize = true;
            this.cboJustFiles.Location = new System.Drawing.Point(328, 91);
            this.cboJustFiles.Name = "cboJustFiles";
            this.cboJustFiles.Size = new System.Drawing.Size(114, 19);
            this.cboJustFiles.TabIndex = 9;
            this.cboJustFiles.Text = "Just File Names";
            this.cboJustFiles.UseVisualStyleBackColor = true;
            this.cboJustFiles.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cboSearchType
            // 
            this.cboSearchType.FormattingEnabled = true;
            this.cboSearchType.Location = new System.Drawing.Point(26, 91);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(121, 21);
            this.cboSearchType.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Search Type";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tvCurrentPath
            // 
            this.tvCurrentPath.Location = new System.Drawing.Point(29, 155);
            this.tvCurrentPath.Name = "tvCurrentPath";
            this.tvCurrentPath.Size = new System.Drawing.Size(239, 601);
            this.tvCurrentPath.TabIndex = 12;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblLoading.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblLoading.Location = new System.Drawing.Point(983, 137);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(61, 15);
            this.lblLoading.TabIndex = 13;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.Visible = false;
            this.lblLoading.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(453, 35);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(130, 23);
            this.btnCopy.TabIndex = 14;
            this.btnCopy.Text = "Copy to Clipboard";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // pathDataGridViewTextBoxColumn
            // 
            this.pathDataGridViewTextBoxColumn.DataPropertyName = "Path";
            this.pathDataGridViewTextBoxColumn.HeaderText = "Path";
            this.pathDataGridViewTextBoxColumn.Name = "pathDataGridViewTextBoxColumn";
            this.pathDataGridViewTextBoxColumn.Width = 560;
            // 
            // openNotePadDataGridViewTextBoxColumn
            // 
            this.openNotePadDataGridViewTextBoxColumn.DataPropertyName = "OpenNotePad";
            this.openNotePadDataGridViewTextBoxColumn.HeaderText = "Action 1";
            this.openNotePadDataGridViewTextBoxColumn.Name = "openNotePadDataGridViewTextBoxColumn";
            this.openNotePadDataGridViewTextBoxColumn.Width = 110;
            // 
            // searchResultBindingSource
            // 
            this.searchResultBindingSource.DataSource = typeof(WindowsFormsApplication1.SearchResult);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1787, 769);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.tvCurrentPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboSearchType);
            this.Controls.Add(this.cboJustFiles);
            this.Controls.Add(this.dgvSearchResults);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSearchTerm);
            this.Controls.Add(this.cboFileTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPaths);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchResultBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPaths;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearchTerm;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboFileTypes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvSearchResults;
        private System.Windows.Forms.BindingSource searchResultBindingSource;
        private System.Windows.Forms.CheckBox cboJustFiles;
        private System.Windows.Forms.ComboBox cboSearchType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView tvCurrentPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pathDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Results;
        private System.Windows.Forms.DataGridViewTextBoxColumn openNotePadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenPHPStorm;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenPath;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.Button btnCopy;
    }
}

