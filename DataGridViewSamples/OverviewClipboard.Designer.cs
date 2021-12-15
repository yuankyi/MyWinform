namespace DataGridViewSamples
{
    partial class OverviewClipboard
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
            this.cboClipbrdCopyModes = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rtfClipbrdContent = new System.Windows.Forms.RichTextBox();
            this.btnClipbrdContent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cboClipbrdCopyModes
            // 
            this.cboClipbrdCopyModes.FormattingEnabled = true;
            this.cboClipbrdCopyModes.Location = new System.Drawing.Point(33, 21);
            this.cboClipbrdCopyModes.Name = "cboClipbrdCopyModes";
            this.cboClipbrdCopyModes.Size = new System.Drawing.Size(121, 20);
            this.cboClipbrdCopyModes.TabIndex = 3;
            this.cboClipbrdCopyModes.SelectedIndexChanged += new System.EventHandler(this.cboClipbrdCopyModes_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(419, 244);
            this.dataGridView1.TabIndex = 2;
            // 
            // rtfClipbrdContent
            // 
            this.rtfClipbrdContent.Location = new System.Drawing.Point(33, 346);
            this.rtfClipbrdContent.Name = "rtfClipbrdContent";
            this.rtfClipbrdContent.ReadOnly = true;
            this.rtfClipbrdContent.Size = new System.Drawing.Size(419, 96);
            this.rtfClipbrdContent.TabIndex = 4;
            this.rtfClipbrdContent.Text = "";
            // 
            // btnClipbrdContent
            // 
            this.btnClipbrdContent.Location = new System.Drawing.Point(33, 318);
            this.btnClipbrdContent.Name = "btnClipbrdContent";
            this.btnClipbrdContent.Size = new System.Drawing.Size(121, 23);
            this.btnClipbrdContent.TabIndex = 5;
            this.btnClipbrdContent.Text = "ÏÔÊ¾¼ôÌù°åµÄÄÚÈÝ";
            this.btnClipbrdContent.UseVisualStyleBackColor = true;
            this.btnClipbrdContent.Click += new System.EventHandler(this.btnClipbrdContent_Click);
            // 
            // OverviewClipboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 457);
            this.Controls.Add(this.btnClipbrdContent);
            this.Controls.Add(this.rtfClipbrdContent);
            this.Controls.Add(this.cboClipbrdCopyModes);
            this.Controls.Add(this.dataGridView1);
            this.Name = "OverviewClipboard";
            this.Text = "OverviewClipboard";
            this.Load += new System.EventHandler(this.OverviewClipboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboClipbrdCopyModes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.RichTextBox rtfClipbrdContent;
        private System.Windows.Forms.Button btnClipbrdContent;
    }
}