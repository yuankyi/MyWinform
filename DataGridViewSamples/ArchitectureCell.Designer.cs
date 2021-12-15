namespace DataGridViewSamples
{
    partial class ArchitectureCell
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
            this.btnShowReturnChar = new System.Windows.Forms.Button();
            this.btnConvertReturnChar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(379, 247);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnShowReturnChar
            // 
            this.btnShowReturnChar.Location = new System.Drawing.Point(59, 290);
            this.btnShowReturnChar.Name = "btnShowReturnChar";
            this.btnShowReturnChar.Size = new System.Drawing.Size(75, 23);
            this.btnShowReturnChar.TabIndex = 1;
            this.btnShowReturnChar.Text = "显示换行符";
            this.btnShowReturnChar.UseVisualStyleBackColor = true;
            this.btnShowReturnChar.Click += new System.EventHandler(this.btnShowReturnChar_Click);
            // 
            // btnConvertReturnChar
            // 
            this.btnConvertReturnChar.Location = new System.Drawing.Point(157, 290);
            this.btnConvertReturnChar.Name = "btnConvertReturnChar";
            this.btnConvertReturnChar.Size = new System.Drawing.Size(75, 23);
            this.btnConvertReturnChar.TabIndex = 2;
            this.btnConvertReturnChar.Text = "转换换行符";
            this.btnConvertReturnChar.UseVisualStyleBackColor = true;
            // 
            // ArchitectureCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 406);
            this.Controls.Add(this.btnConvertReturnChar);
            this.Controls.Add(this.btnShowReturnChar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ArchitectureCell";
            this.Text = "DGVCellForm";
            this.Load += new System.EventHandler(this.DGVCellForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button btnShowReturnChar;
        private System.Windows.Forms.Button btnConvertReturnChar;
    }
}