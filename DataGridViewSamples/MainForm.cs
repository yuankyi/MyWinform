using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            // 关闭窗体
            this.Close();
        }

        private void ShowDialogForm(Form form)
        {
            form.Owner = this;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        #region 处理 DGV结构 相关的菜单

        private void mnuArchColumn_Click(object sender, EventArgs e)
        {
            ArchitectureColumn columnForm = new ArchitectureColumn();
            ShowDialogForm(columnForm);
        }

        private void mnuArchCell_Click(object sender, EventArgs e)
        {
            ArchitectureCell cellForm = new ArchitectureCell();
            ShowDialogForm(cellForm);
        }

        private void mnuArchEditCtrl_Click(object sender, EventArgs e)
        {
            ColumnCellComboxBoxColumn archComboForm = new ColumnCellComboxBoxColumn();
            ShowDialogForm(archComboForm);
        }

        private void mnuArchRow_Click(object sender, EventArgs e)
        {
            ArchitectureRow rowForm = new ArchitectureRow();
            ShowDialogForm(rowForm);
        }

        #endregion 处理 DGV结构 相关的菜单

        #region 处理 列/单元格类型 相关的菜单

        private void mnuColumnCellComboBox_Click(object sender, EventArgs e)
        {
            ColumnCellComboxBoxColumn comboTypeForm = new ColumnCellComboxBoxColumn();
            ShowDialogForm(comboTypeForm);
        }

        private void mnuColumnCellTextbox_Click(object sender, EventArgs e)
        {
            ColumnCellTextBoxColumn textTypeForm = new ColumnCellTextBoxColumn();
            ShowDialogForm(textTypeForm);
        }

        #endregion 处理 列/单元格类型 相关的菜单

        #region 处理 操作数据相关的菜单

        private void mnuDataMasterDetail_Click(object sender, EventArgs e)
        {
            ManipulateDataMasterDetail mdForm = new ManipulateDataMasterDetail();
            ShowDialogForm(mdForm);
        }

        private void mnuDataComboBoxColumn_Click(object sender, EventArgs e)
        {
            ManipulateDataComboBoxColumn comboForm = new ManipulateDataComboBoxColumn();
            ShowDialogForm(comboForm);
        }

        private void mnuDataEntryValicating_Click(object sender, EventArgs e)
        {
            ManipulateDataValidating mdvalForm = new ManipulateDataValidating();
            ShowDialogForm(mdvalForm);
        }

        private void mnuDataAdapter_Click(object sender, EventArgs e)
        {
            ManipulateDataAdapter daForm = new ManipulateDataAdapter();
            ShowDialogForm(daForm);
        }

        private void mnuDataCustomError_Click(object sender, EventArgs e)
        {
            ManipulateDataCustomErrorIcon errorIconForm = new ManipulateDataCustomErrorIcon();
            ShowDialogForm(errorIconForm);
        }

        private void mnuDataUnbound_Click(object sender, EventArgs e)
        {
            ManipulateDataUnboundMode unboundForm = new ManipulateDataUnboundMode();
            ShowDialogForm(unboundForm);
        }

        #endregion 处理 操作数据相关的菜单

        #region 处理 特性纵览相关的菜单

        private void mnuOverviewStyle_Click(object sender, EventArgs e)
        {
            OverviewStyleForm styleForm = new OverviewStyleForm();
            ShowDialogForm(styleForm);
        }

        private void mnuOverviewPainting_Click(object sender, EventArgs e)
        {
            OverviewCustomPainting paintForm = new OverviewCustomPainting();
            ShowDialogForm(paintForm);
        }

        private void mnuOverviewAutoSize_Click(object sender, EventArgs e)
        {
            OverviewAutosize sizeForm = new OverviewAutosize();
            ShowDialogForm(sizeForm);
        }

        private void mnuOverviewSelMode_Click(object sender, EventArgs e)
        {
            OverviewSelection selForm = new OverviewSelection();
            ShowDialogForm(selForm);
        }

        private void mnuOverviewScroll_Click(object sender, EventArgs e)
        {
            OverviewScrolling scrollForm = new OverviewScrolling();
            ShowDialogForm(scrollForm);
        }

        private void mnuOverviewBorderStyle_Click(object sender, EventArgs e)
        {
            OverviewBorderStyle borderForm = new OverviewBorderStyle();
            ShowDialogForm(borderForm);
        }

        private void mnuOverviewEnterEditMode_Click(object sender, EventArgs e)
        {
            OverviewEnterEditMode editForm = new OverviewEnterEditMode();
            ShowDialogForm(editForm);
        }

        private void mnuOverviewClipboard_Click(object sender, EventArgs e)
        {
            OverviewClipboard clipForm = new OverviewClipboard();
            ShowDialogForm(clipForm);
        }

        private void mnuOverviewFrozen_Click(object sender, EventArgs e)
        {
            OverviewFrozenColumnOrRow frozenForm = new OverviewFrozenColumnOrRow();
            ShowDialogForm(frozenForm);
        }

        private void mnuOverviewSort_Click(object sender, EventArgs e)
        {
            // TODO:
        }

        private void mnuOverviewVirtualMode_Click(object sender, EventArgs e)
        {
            OverviewVirtualMode virtualForm = new OverviewVirtualMode();
            ShowDialogForm(virtualForm);
        }

        #endregion 处理 特性纵览相关的菜单

        #region 处理 最佳实践相关的菜单

        private void mnuBestPracticeVirtualMode_Click(object sender, EventArgs e)
        {
            BestPracticePerformance performanceForm = new BestPracticePerformance();
            ShowDialogForm(performanceForm);
        }

        #endregion 处理 最佳实践相关的菜单

        #region 处理 帮助相关的菜单

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            HelpAboutMe aboutForm = new HelpAboutMe();
            ShowDialogForm(aboutForm);
        }

        #endregion 处理 帮助相关的菜单
    }
}