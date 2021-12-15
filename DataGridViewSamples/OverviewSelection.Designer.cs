namespace DataGridViewSamples
{
    partial class OverviewSelection
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboSelectionMode = new System.Windows.Forms.ComboBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.btnAreAllCellsSelected = new System.Windows.Forms.Button();
            this.btnSelectedItemsInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(65, 75);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(364, 270);
            this.dataGridView1.TabIndex = 0;
            // 
            // cboSelectionMode
            // 
            this.cboSelectionMode.FormattingEnabled = true;
            this.cboSelectionMode.Location = new System.Drawing.Point(65, 40);
            this.cboSelectionMode.Name = "cboSelectionMode";
            this.cboSelectionMode.Size = new System.Drawing.Size(130, 20);
            this.cboSelectionMode.TabIndex = 1;
            this.cboSelectionMode.SelectedIndexChanged += new System.EventHandler(this.cboSelectionMode_SelectedIndexChanged);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(65, 363);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "选中全部";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Location = new System.Drawing.Point(146, 363);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(75, 23);
            this.btnClearSelection.TabIndex = 3;
            this.btnClearSelection.Text = "清除已选";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // btnAreAllCellsSelected
            // 
            this.btnAreAllCellsSelected.Location = new System.Drawing.Point(227, 363);
            this.btnAreAllCellsSelected.Name = "btnAreAllCellsSelected";
            this.btnAreAllCellsSelected.Size = new System.Drawing.Size(75, 23);
            this.btnAreAllCellsSelected.TabIndex = 4;
            this.btnAreAllCellsSelected.Text = "是否全选？";
            this.btnAreAllCellsSelected.UseVisualStyleBackColor = true;
            this.btnAreAllCellsSelected.Click += new System.EventHandler(this.btnAreAllCellsSelected_Click);
            // 
            // btnSelectedItemsInfo
            // 
            this.btnSelectedItemsInfo.Location = new System.Drawing.Point(308, 363);
            this.btnSelectedItemsInfo.Name = "btnSelectedItemsInfo";
            this.btnSelectedItemsInfo.Size = new System.Drawing.Size(112, 23);
            this.btnSelectedItemsInfo.TabIndex = 5;
            this.btnSelectedItemsInfo.Text = "选中内容统计信息";
            this.btnSelectedItemsInfo.UseVisualStyleBackColor = true;
            this.btnSelectedItemsInfo.Click += new System.EventHandler(this.btnSelectedItemsInfo_Click);
            // 
            // OverviewSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 469);
            this.Controls.Add(this.btnSelectedItemsInfo);
            this.Controls.Add(this.btnAreAllCellsSelected);
            this.Controls.Add(this.btnClearSelection);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.cboSelectionMode);
            this.Controls.Add(this.dataGridView1);
            this.Name = "OverviewSelection";
            this.Text = "OverviewSelection";
            this.Load += new System.EventHandler(this.OverviewSelection_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.ComboBox cboSelectionMode;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnClearSelection;
        private System.Windows.Forms.Button btnAreAllCellsSelected;
        private System.Windows.Forms.Button btnSelectedItemsInfo;
    }
}