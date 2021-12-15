namespace DataGridViewSamples
{
    partial class OverviewEnterEditMode
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
            this.cboEnterEditModes = new System.Windows.Forms.ComboBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(415, 314);
            this.dataGridView1.TabIndex = 0;
            // 
            // cboEnterEditModes
            // 
            this.cboEnterEditModes.FormattingEnabled = true;
            this.cboEnterEditModes.Location = new System.Drawing.Point(24, 23);
            this.cboEnterEditModes.Name = "cboEnterEditModes";
            this.cboEnterEditModes.Size = new System.Drawing.Size(121, 20);
            this.cboEnterEditModes.TabIndex = 1;
            this.cboEnterEditModes.SelectedIndexChanged += new System.EventHandler(this.cboEnterEditModes_SelectedIndexChanged);
            // 
            // OverviewEnterEditMode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 414);
            this.Controls.Add(this.cboEnterEditModes);
            this.Controls.Add(this.dataGridView1);
            this.Name = "OverviewEnterEditMode";
            this.Text = "OverviewEnterEditMode";
            this.Load += new System.EventHandler(this.OverviewEnterEditMode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cboEnterEditModes;
        private System.Windows.Forms.BindingSource bindingSource;
    }
}