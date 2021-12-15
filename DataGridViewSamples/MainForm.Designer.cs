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
            this.mnuFile.Text = "�ļ�(&F)";
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.Size = new System.Drawing.Size(112, 22);
            this.mnuFileExit.Text = "�˳�(&E)";
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
            this.mnuArch.Text = "DGV�ṹ(&A)";
            // 
            // mnuArchCell
            // 
            this.mnuArchCell.Name = "mnuArchCell";
            this.mnuArchCell.Size = new System.Drawing.Size(118, 22);
            this.mnuArchCell.Text = "��Ԫ��";
            this.mnuArchCell.Click += new System.EventHandler(this.mnuArchCell_Click);
            // 
            // mnuArchRow
            // 
            this.mnuArchRow.Name = "mnuArchRow";
            this.mnuArchRow.Size = new System.Drawing.Size(118, 22);
            this.mnuArchRow.Text = "��";
            this.mnuArchRow.Click += new System.EventHandler(this.mnuArchRow_Click);
            // 
            // mnuArchColumn
            // 
            this.mnuArchColumn.Name = "mnuArchColumn";
            this.mnuArchColumn.Size = new System.Drawing.Size(118, 22);
            this.mnuArchColumn.Text = "��";
            this.mnuArchColumn.Click += new System.EventHandler(this.mnuArchColumn_Click);
            // 
            // mnuArchEditCtrl
            // 
            this.mnuArchEditCtrl.Name = "mnuArchEditCtrl";
            this.mnuArchEditCtrl.Size = new System.Drawing.Size(118, 22);
            this.mnuArchEditCtrl.Text = "�༭�ؼ�";
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
            this.mnuColumnCellType.Text = "��/��Ԫ������(&T)";
            // 
            // mnuColumnCellTextbox
            // 
            this.mnuColumnCellTextbox.Name = "mnuColumnCellTextbox";
            this.mnuColumnCellTextbox.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellTextbox.Text = "TextBox��";
            this.mnuColumnCellTextbox.Click += new System.EventHandler(this.mnuColumnCellTextbox_Click);
            // 
            // mnuColumnCellCheckBox
            // 
            this.mnuColumnCellCheckBox.Name = "mnuColumnCellCheckBox";
            this.mnuColumnCellCheckBox.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellCheckBox.Text = "CheckBox��";
            // 
            // mnuColumnCellImage
            // 
            this.mnuColumnCellImage.Name = "mnuColumnCellImage";
            this.mnuColumnCellImage.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellImage.Text = "Image��";
            // 
            // mnuColumnCellButton
            // 
            this.mnuColumnCellButton.Name = "mnuColumnCellButton";
            this.mnuColumnCellButton.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellButton.Text = "Button��";
            // 
            // mnuColumnCellComboBox
            // 
            this.mnuColumnCellComboBox.Name = "mnuColumnCellComboBox";
            this.mnuColumnCellComboBox.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellComboBox.Text = "ComboBox��";
            this.mnuColumnCellComboBox.Click += new System.EventHandler(this.mnuColumnCellComboBox_Click);
            // 
            // mnuColumnCellLink
            // 
            this.mnuColumnCellLink.Name = "mnuColumnCellLink";
            this.mnuColumnCellLink.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellLink.Text = "Link��";
            // 
            // mnuColumnCellAll
            // 
            this.mnuColumnCellAll.Name = "mnuColumnCellAll";
            this.mnuColumnCellAll.Size = new System.Drawing.Size(130, 22);
            this.mnuColumnCellAll.Text = "�ۺ�ʹ��";
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
            this.mnuData.Text = "��������(&D)";
            // 
            // mnuDataMasterDetail
            // 
            this.mnuDataMasterDetail.Name = "mnuDataMasterDetail";
            this.mnuDataMasterDetail.Size = new System.Drawing.Size(208, 22);
            this.mnuDataMasterDetail.Text = "ʹ�����ӱ�";
            this.mnuDataMasterDetail.Click += new System.EventHandler(this.mnuDataMasterDetail_Click);
            // 
            // mnuDataComboBoxColumn
            // 
            this.mnuDataComboBoxColumn.Name = "mnuDataComboBoxColumn";
            this.mnuDataComboBoxColumn.Size = new System.Drawing.Size(208, 22);
            this.mnuDataComboBoxColumn.Text = "ʹ��ComboBox��";
            this.mnuDataComboBoxColumn.Click += new System.EventHandler(this.mnuDataComboBoxColumn_Click);
            // 
            // mnuDataEntryValicating
            // 
            this.mnuDataEntryValicating.Name = "mnuDataEntryValicating";
            this.mnuDataEntryValicating.Size = new System.Drawing.Size(208, 22);
            this.mnuDataEntryValicating.Text = "�����������֤";
            this.mnuDataEntryValicating.Click += new System.EventHandler(this.mnuDataEntryValicating_Click);
            // 
            // mnuDataAdapter
            // 
            this.mnuDataAdapter.Name = "mnuDataAdapter";
            this.mnuDataAdapter.Size = new System.Drawing.Size(208, 22);
            this.mnuDataAdapter.Text = "ʹ��DataAdapter��������";
            this.mnuDataAdapter.Click += new System.EventHandler(this.mnuDataAdapter_Click);
            // 
            // mnuDataCustomError
            // 
            this.mnuDataCustomError.Name = "mnuDataCustomError";
            this.mnuDataCustomError.Size = new System.Drawing.Size(208, 22);
            this.mnuDataCustomError.Text = "��ʾ�Զ������ͼ��";
            this.mnuDataCustomError.Click += new System.EventHandler(this.mnuDataCustomError_Click);
            // 
            // mnuDataBoundMode
            // 
            this.mnuDataBoundMode.Name = "mnuDataBoundMode";
            this.mnuDataBoundMode.Size = new System.Drawing.Size(208, 22);
            this.mnuDataBoundMode.Text = "��ģʽ";
            // 
            // mnuDataUnbound
            // 
            this.mnuDataUnbound.Name = "mnuDataUnbound";
            this.mnuDataUnbound.Size = new System.Drawing.Size(208, 22);
            this.mnuDataUnbound.Text = "�ǰ�ģʽ";
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
            this.mnuOverview.Text = "��������(&O)";
            // 
            // mnuOverviewStyle
            // 
            this.mnuOverviewStyle.Name = "mnuOverviewStyle";
            this.mnuOverviewStyle.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewStyle.Text = "ʽ��";
            this.mnuOverviewStyle.Click += new System.EventHandler(this.mnuOverviewStyle_Click);
            // 
            // mnuOverviewPainting
            // 
            this.mnuOverviewPainting.Name = "mnuOverviewPainting";
            this.mnuOverviewPainting.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewPainting.Text = "�Զ������";
            this.mnuOverviewPainting.Click += new System.EventHandler(this.mnuOverviewPainting_Click);
            // 
            // mnuOverviewAutoSize
            // 
            this.mnuOverviewAutoSize.Name = "mnuOverviewAutoSize";
            this.mnuOverviewAutoSize.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewAutoSize.Text = "�Զ�����";
            this.mnuOverviewAutoSize.Click += new System.EventHandler(this.mnuOverviewAutoSize_Click);
            // 
            // mnuOverviewSelMode
            // 
            this.mnuOverviewSelMode.Name = "mnuOverviewSelMode";
            this.mnuOverviewSelMode.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewSelMode.Text = "ѡ��ģʽ";
            this.mnuOverviewSelMode.Click += new System.EventHandler(this.mnuOverviewSelMode_Click);
            // 
            // mnuOverviewScroll
            // 
            this.mnuOverviewScroll.Name = "mnuOverviewScroll";
            this.mnuOverviewScroll.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewScroll.Text = "����";
            this.mnuOverviewScroll.Click += new System.EventHandler(this.mnuOverviewScroll_Click);
            // 
            // mnuOverviewSort
            // 
            this.mnuOverviewSort.Name = "mnuOverviewSort";
            this.mnuOverviewSort.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewSort.Text = "����";
            this.mnuOverviewSort.Click += new System.EventHandler(this.mnuOverviewSort_Click);
            // 
            // mnuOverviewBorderStyle
            // 
            this.mnuOverviewBorderStyle.Name = "mnuOverviewBorderStyle";
            this.mnuOverviewBorderStyle.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewBorderStyle.Text = "�߿���ʽ";
            this.mnuOverviewBorderStyle.Click += new System.EventHandler(this.mnuOverviewBorderStyle_Click);
            // 
            // mnuOverviewEnterEditMode
            // 
            this.mnuOverviewEnterEditMode.Name = "mnuOverviewEnterEditMode";
            this.mnuOverviewEnterEditMode.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewEnterEditMode.Text = "����༭ģʽ";
            this.mnuOverviewEnterEditMode.Click += new System.EventHandler(this.mnuOverviewEnterEditMode_Click);
            // 
            // mnuOverviewClipboard
            // 
            this.mnuOverviewClipboard.Name = "mnuOverviewClipboard";
            this.mnuOverviewClipboard.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewClipboard.Text = "�����帴��ģʽ";
            this.mnuOverviewClipboard.Click += new System.EventHandler(this.mnuOverviewClipboard_Click);
            // 
            // mnuOverviewFrozen
            // 
            this.mnuOverviewFrozen.Name = "mnuOverviewFrozen";
            this.mnuOverviewFrozen.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewFrozen.Text = "������/��";
            this.mnuOverviewFrozen.Click += new System.EventHandler(this.mnuOverviewFrozen_Click);
            // 
            // mnuOverviewCustomCell
            // 
            this.mnuOverviewCustomCell.Name = "mnuOverviewCustomCell";
            this.mnuOverviewCustomCell.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewCustomCell.Text = "�Զ��嵥Ԫ��ͱ༭�ؼ�";
            // 
            // mnuOverviewVirtualMode
            // 
            this.mnuOverviewVirtualMode.Name = "mnuOverviewVirtualMode";
            this.mnuOverviewVirtualMode.Size = new System.Drawing.Size(202, 22);
            this.mnuOverviewVirtualMode.Text = "����ģʽ";
            this.mnuOverviewVirtualMode.Click += new System.EventHandler(this.mnuOverviewVirtualMode_Click);
            // 
            // mnuBestPractice
            // 
            this.mnuBestPractice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBestPracticeVirtualMode});
            this.mnuBestPractice.Name = "mnuBestPractice";
            this.mnuBestPractice.Size = new System.Drawing.Size(83, 20);
            this.mnuBestPractice.Text = "���ʵ��(&P)";
            // 
            // mnuBestPracticeVirtualMode
            // 
            this.mnuBestPracticeVirtualMode.Name = "mnuBestPracticeVirtualMode";
            this.mnuBestPracticeVirtualMode.Size = new System.Drawing.Size(190, 22);
            this.mnuBestPracticeVirtualMode.Text = "ʹ������ģʽ�Ż�����";
            this.mnuBestPracticeVirtualMode.Click += new System.EventHandler(this.mnuBestPracticeVirtualMode_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(59, 20);
            this.mnuHelp.Text = "����(&H)";
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(152, 22);
            this.mnuHelpAbout.Text = "����";
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