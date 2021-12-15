namespace DataGridViewSamples
{
    partial class MainForm
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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchCell = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchRow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArchEditCtrl = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColumnCellType = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColumnCellTextbox = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColumnCellCheckBox = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColumnCellImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColumnCellButton = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColumnCellComboBox = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColumnCellLink = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColumnCellAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuData = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataMasterDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataComboBoxColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataEntryValicating = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataAdapter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataCustomError = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataBoundMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDataUnbound = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverview = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverviewStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverviewPainting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverviewAutoSize = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverviewSelMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverviewScroll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverviewSort = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverviewBorderStyle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverviewEnterEditMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverviewClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverviewFrozen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverviewCustomCell = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOverviewVirtualMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBestPractice = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBestPracticeVirtualMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuArch,
            this.mnuColumnCellType,
            this.mnuData,
            this.mnuOverview,
            this.mnuBestPractice,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(660, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(59, 20);
            this.mnuFile.Text = "文件(&F)";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(112, 22);
            this.mnuFileExit.Text = "退出(&E)";
            this.mnuFileExit.Click += new System.EventHandler(this.mnuFileExit_Click);
            // 
            // mnuArch
            // 
            this.mnuArch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchCell,
            this.mnuArchRow,
            this.mnuArchColumn,
            this.mnuArchEditCtrl});
            this.mnuArch.Name = "mnuArch";
            this.mnuArch.Size = new System.Drawing.Size(77, 20);
            this.mnuArch.Text = "DGV结构(&A)";
            // 
            // mnuArchCell
            // 
            this.mnuArchCell.Name = "mnuArchCell";
            this.mnuArchCell.Size = new System.Drawing.Size(118, 22);
            this.mnuArchCell.Text = "单元格";
            this.mnuArchCell.Click += new System.EventHandler(this.mnuArchCell_Click);
            // 
            // mnuArchRow
            // 
            this.mnuArchRow.Name = "mnuArchRow";
            this.mnuArchRow.Size = new System.Drawing.Size(118, 22);
            this.mnuArchRow.Text = "行";
            this.mnuArchRow.Click += new System.EventHandler(this.mnuArchRow_Click);
            // 
            // mnuArchColumn
            // 
            this.mnuArchColumn.Name = "mnuArchColumn";
            this.mnuArchColumn.Size = new System.Drawing.Size(118, 22);
            this.mnuArchColumn.Text = "列";
            this.mnuArchColumn.Click += new System.EventHandler(this.mnuArchColumn_Click);
            // 
            // mnuArchEditCtrl
            // 
            this.mnuArchEditCtrl.Name = "mnuArchEditCtrl";
            this.mnuArchEditCtrl.Size = new System.Drawing.Size(118, 22);
            this.mnuArchEditCtrl.Text = "编辑控件";
            this.mnuArchEditCtrl.Click += new System.EventHandler(this.mnuArchEditCtrl_Click);
            // 
            // mnuColumnCellType
            // 
            this.mnuColumnCellType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuColumnCellTextbox,
            this.mnuColumnCellCheckBox,
            this.mnuColumnCellImage,
            this.mnuColumnCellButton,
            this.mnuColumnCellComboBox,
            this.mnuColumnCellLink,
            this.mnuColumnCellAll});
            this.mnuColumnCellType.Name = "mnuColumnCellType";
            this.mnuColumnCellType.Size = new System.Drawing.Size(113, 20);
            this.mnuColumnCellType.Text = "列/单元格类型(&T)";
            // 
            // mnuColumnCellTextbox
            // 
            this.mnuColumnCellTextbox.Name = "mnuColumnCellTextbox";
            this.mnuColumnCellTextbox.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellTextbox.Text = "TextBox列";
            this.mnuColumnCellTextbox.Click += new System.EventHandler(this.mnuColumnCellTextbox_Click);
            // 
            // mnuColumnCellCheckBox
            // 
            this.mnuColumnCellCheckBox.Name = "mnuColumnCellCheckBox";
            this.mnuColumnCellCheckBox.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellCheckBox.Text = "CheckBox列";
            // 
            // mnuColumnCellImage
            // 
            this.mnuColumnCellImage.Name = "mnuColumnCellImage";
            this.mnuColumnCellImage.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellImage.Text = "Image列";
            // 
            // mnuColumnCellButton
            // 
            this.mnuColumnCellButton.Name = "mnuColumnCellButton";
            this.mnuColumnCellButton.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellButton.Text = "Button列";
            // 
            // mnuColumnCellComboBox
            // 
            this.mnuColumnCellComboBox.Name = "mnuColumnCellComboBox";
            this.mnuColumnCellComboBox.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellComboBox.Text = "ComboBox列";
            this.mnuColumnCellComboBox.Click += new System.EventHandler(this.mnuColumnCellComboBox_Click);
            // 
            // mnuColumnCellLink
            // 
            this.mnuColumnCellLink.Name = "mnuColumnCellLink";
            this.mnuColumnCellLink.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellLink.Text = "Link列";
            // 
            // mnuColumnCellAll
            // 
            this.mnuColumnCellAll.Name = "mnuColumnCellAll";
            this.mnuColumnCellAll.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellAll.Text = "综合使用";
            // 
            // mnuData
            // 
            this.mnuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDataMasterDetail,
            this.mnuDataComboBoxColumn,
            this.mnuDataEntryValicating,
            this.mnuDataAdapter,
            this.mnuDataCustomError,
            this.mnuDataBoundMode,
            this.mnuDataUnbound});
            this.mnuData.Name = "mnuData";
            this.mnuData.Size = new System.Drawing.Size(83, 20);
            this.mnuData.Text = "操作数据(&D)";
            // 
            // mnuDataMasterDetail
            // 
            this.mnuDataMasterDetail.Name = "mnuDataMasterDetail";
            this.mnuDataMasterDetail.Size = new System.Drawing.Size(208, 22);
            this.mnuDataMasterDetail.Text = "使用主从表";
            this.mnuDataMasterDetail.Click += new System.EventHandler(this.mnuDataMasterDetail_Click);
            // 
            // mnuDataComboBoxColumn
            // 
            this.mnuDataComboBoxColumn.Name = "mnuDataComboBoxColumn";
            this.mnuDataComboBoxColumn.Size = new System.Drawing.Size(208, 22);
            this.mnuDataComboBoxColumn.Text = "使用ComboBox列";
            this.mnuDataComboBoxColumn.Click += new System.EventHandler(this.mnuDataComboBoxColumn_Click);
            // 
            // mnuDataEntryValicating
            // 
            this.mnuDataEntryValicating.Name = "mnuDataEntryValicating";
            this.mnuDataEntryValicating.Size = new System.Drawing.Size(208, 22);
            this.mnuDataEntryValicating.Text = "数据输入和验证";
            this.mnuDataEntryValicating.Click += new System.EventHandler(this.mnuDataEntryValicating_Click);
            // 
            // mnuDataAdapter
            // 
            this.mnuDataAdapter.Name = "mnuDataAdapter";
            this.mnuDataAdapter.Size = new System.Drawing.Size(208, 22);
            this.mnuDataAdapter.Text = "使用DataAdapter更新数据";
            this.mnuDataAdapter.Click += new System.EventHandler(this.mnuDataAdapter_Click);
            // 
            // mnuDataCustomError
            // 
            this.mnuDataCustomError.Name = "mnuDataCustomError";
            this.mnuDataCustomError.Size = new System.Drawing.Size(208, 22);
            this.mnuDataCustomError.Text = "显示自定义错误图标";
            this.mnuDataCustomError.Click += new System.EventHandler(this.mnuDataCustomError_Click);
            // 
            // mnuDataBoundMode
            // 
            this.mnuDataBoundMode.Name = "mnuDataBoundMode";
            this.mnuDataBoundMode.Size = new System.Drawing.Size(208, 22);
            this.mnuDataBoundMode.Text = "绑定模式";
            // 
            // mnuDataUnbound
            // 
            this.mnuDataUnbound.Name = "mnuDataUnbound";
            this.mnuDataUnbound.Size = new System.Drawing.Size(208, 22);
            this.mnuDataUnbound.Text = "非绑定模式";
            this.mnuDataUnbound.Click += new System.EventHandler(this.mnuDataUnbound_Click);
            // 
            // mnuOverview
            // 
            this.mnuOverview.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOverviewStyle,
            this.mnuOverviewPainting,
            this.mnuOverviewAutoSize,
            this.mnuOverviewSelMode,
            this.mnuOverviewScroll,
            this.mnuOverviewSort,
            this.mnuOverviewBorderStyle,
            this.mnuOverviewEnterEditMode,
            this.mnuOverviewClipboard,
            this.mnuOverviewFrozen,
            this.mnuOverviewCustomCell,
            this.mnuOverviewVirtualMode});
            this.mnuOverview.Name = "mnuOverview";
            this.mnuOverview.Size = new System.Drawing.Size(83, 20);
            this.mnuOverview.Text = "特性综览(&O)";
            // 
            // mnuOverviewStyle
            // 
            this.mnuOverviewStyle.Name = "mnuOverviewStyle";
            this.mnuOverviewStyle.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewStyle.Text = "式样";
            this.mnuOverviewStyle.Click += new System.EventHandler(this.mnuOverviewStyle_Click);
            // 
            // mnuOverviewPainting
            // 
            this.mnuOverviewPainting.Name = "mnuOverviewPainting";
            this.mnuOverviewPainting.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewPainting.Text = "自定义绘制";
            this.mnuOverviewPainting.Click += new System.EventHandler(this.mnuOverviewPainting_Click);
            // 
            // mnuOverviewAutoSize
            // 
            this.mnuOverviewAutoSize.Name = "mnuOverviewAutoSize";
            this.mnuOverviewAutoSize.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewAutoSize.Text = "自动缩放";
            this.mnuOverviewAutoSize.Click += new System.EventHandler(this.mnuOverviewAutoSize_Click);
            // 
            // mnuOverviewSelMode
            // 
            this.mnuOverviewSelMode.Name = "mnuOverviewSelMode";
            this.mnuOverviewSelMode.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewSelMode.Text = "选择模式";
            this.mnuOverviewSelMode.Click += new System.EventHandler(this.mnuOverviewSelMode_Click);
            // 
            // mnuOverviewScroll
            // 
            this.mnuOverviewScroll.Name = "mnuOverviewScroll";
            this.mnuOverviewScroll.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewScroll.Text = "滚动";
            this.mnuOverviewScroll.Click += new System.EventHandler(this.mnuOverviewScroll_Click);
            // 
            // mnuOverviewSort
            // 
            this.mnuOverviewSort.Name = "mnuOverviewSort";
            this.mnuOverviewSort.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewSort.Text = "排序";
            this.mnuOverviewSort.Click += new System.EventHandler(this.mnuOverviewSort_Click);
            // 
            // mnuOverviewBorderStyle
            // 
            this.mnuOverviewBorderStyle.Name = "mnuOverviewBorderStyle";
            this.mnuOverviewBorderStyle.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewBorderStyle.Text = "边框样式";
            this.mnuOverviewBorderStyle.Click += new System.EventHandler(this.mnuOverviewBorderStyle_Click);
            // 
            // mnuOverviewEnterEditMode
            // 
            this.mnuOverviewEnterEditMode.Name = "mnuOverviewEnterEditMode";
            this.mnuOverviewEnterEditMode.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewEnterEditMode.Text = "输入编辑模式";
            this.mnuOverviewEnterEditMode.Click += new System.EventHandler(this.mnuOverviewEnterEditMode_Click);
            // 
            // mnuOverviewClipboard
            // 
            this.mnuOverviewClipboard.Name = "mnuOverviewClipboard";
            this.mnuOverviewClipboard.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewClipboard.Text = "剪贴板复制模式";
            this.mnuOverviewClipboard.Click += new System.EventHandler(this.mnuOverviewClipboard_Click);
            // 
            // mnuOverviewFrozen
            // 
            this.mnuOverviewFrozen.Name = "mnuOverviewFrozen";
            this.mnuOverviewFrozen.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewFrozen.Text = "冻结列/行";
            this.mnuOverviewFrozen.Click += new System.EventHandler(this.mnuOverviewFrozen_Click);
            // 
            // mnuOverviewCustomCell
            // 
            this.mnuOverviewCustomCell.Name = "mnuOverviewCustomCell";
            this.mnuOverviewCustomCell.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewCustomCell.Text = "自定义单元格和编辑控件";
            // 
            // mnuOverviewVirtualMode
            // 
            this.mnuOverviewVirtualMode.Name = "mnuOverviewVirtualMode";
            this.mnuOverviewVirtualMode.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewVirtualMode.Text = "虚拟模式";
            this.mnuOverviewVirtualMode.Click += new System.EventHandler(this.mnuOverviewVirtualMode_Click);
            // 
            // mnuBestPractice
            // 
            this.mnuBestPractice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBestPracticeVirtualMode});
            this.mnuBestPractice.Name = "mnuBestPractice";
            this.mnuBestPractice.Size = new System.Drawing.Size(83, 20);
            this.mnuBestPractice.Text = "最佳实践(&P)";
            // 
            // mnuBestPracticeVirtualMode
            // 
            this.mnuBestPracticeVirtualMode.Name = "mnuBestPracticeVirtualMode";
            this.mnuBestPracticeVirtualMode.Size = new System.Drawing.Size(190, 22);
            this.mnuBestPracticeVirtualMode.Text = "使用虚拟模式优化性能";
            this.mnuBestPracticeVirtualMode.Click += new System.EventHandler(this.mnuBestPracticeVirtualMode_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(59, 20);
            this.mnuHelp.Text = "帮助(&H)";
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(152, 22);
            this.mnuHelpAbout.Text = "关于";
            this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 497);
            this.Controls.Add(this.mnuMain);
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainForm";
            this.Text = "DataGridView FAQ & Samples";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuArch;
        private System.Windows.Forms.ToolStripMenuItem mnuArchCell;
        private System.Windows.Forms.ToolStripMenuItem mnuArchRow;
        private System.Windows.Forms.ToolStripMenuItem mnuArchColumn;
        private System.Windows.Forms.ToolStripMenuItem mnuArchEditCtrl;
        private System.Windows.Forms.ToolStripMenuItem mnuColumnCellType;
        private System.Windows.Forms.ToolStripMenuItem mnuData;
        private System.Windows.Forms.ToolStripMenuItem mnuOverview;
        private System.Windows.Forms.ToolStripMenuItem mnuOverviewStyle;
        private System.Windows.Forms.ToolStripMenuItem mnuOverviewPainting;
        private System.Windows.Forms.ToolStripMenuItem mnuOverviewAutoSize;
        private System.Windows.Forms.ToolStripMenuItem mnuOverviewSelMode;
        private System.Windows.Forms.ToolStripMenuItem mnuOverviewScroll;
        private System.Windows.Forms.ToolStripMenuItem mnuOverviewSort;
        private System.Windows.Forms.ToolStripMenuItem mnuBestPractice;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuOverviewBorderStyle;
        private System.Windows.Forms.ToolStripMenuItem mnuOverviewEnterEditMode;
        private System.Windows.Forms.ToolStripMenuItem mnuOverviewClipboard;
        private System.Windows.Forms.ToolStripMenuItem mnuOverviewFrozen;
        private System.Windows.Forms.ToolStripMenuItem mnuDataMasterDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuDataComboBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem mnuColumnCellTextbox;
        private System.Windows.Forms.ToolStripMenuItem mnuColumnCellCheckBox;
        private System.Windows.Forms.ToolStripMenuItem mnuColumnCellImage;
        private System.Windows.Forms.ToolStripMenuItem mnuColumnCellButton;
        private System.Windows.Forms.ToolStripMenuItem mnuColumnCellComboBox;
        private System.Windows.Forms.ToolStripMenuItem mnuColumnCellLink;
        private System.Windows.Forms.ToolStripMenuItem mnuColumnCellAll;
        private System.Windows.Forms.ToolStripMenuItem mnuDataEntryValicating;
        private System.Windows.Forms.ToolStripMenuItem mnuDataAdapter;
        private System.Windows.Forms.ToolStripMenuItem mnuDataCustomError;
        private System.Windows.Forms.ToolStripMenuItem mnuDataBoundMode;
        private System.Windows.Forms.ToolStripMenuItem mnuDataUnbound;
        private System.Windows.Forms.ToolStripMenuItem mnuOverviewCustomCell;
        private System.Windows.Forms.ToolStripMenuItem mnuOverviewVirtualMode;
        private System.Windows.Forms.ToolStripMenuItem mnuBestPracticeVirtualMode;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
    }
}