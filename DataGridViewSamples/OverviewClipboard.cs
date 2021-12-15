using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class OverviewClipboard : Form
    {
        public OverviewClipboard()
        {
            InitializeComponent();
        }

        private void OverviewClipboard_Load(object sender, EventArgs e)
        {
            SetDataSource();
            BindDataGridView1();
            SetLastColumnWidth();

            InitClipbrdCopyModesList();
        }

        private void SetDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("C1", typeof(int));
            dt.Columns.Add("C2", typeof(string));
            dt.Columns.Add("C3", typeof(string));

            dt.Rows.Add(1, "1", "Test1");
            dt.Rows.Add(2, "2", "Test2");
            dt.Rows.Add(2, "2", "Test1");
            dt.Rows.Add(3, "3", "Test3");
            dt.Rows.Add(4, "4", "Test4");
            dt.Rows.Add(4, "4", "Test3");

            DataView view = dt.DefaultView;
            // 对数据源进行排序
            view.Sort = "C2 ASC, C3 ASC";
            bindingSource.DataSource = view;
        }

        private void BindDataGridView1()
        {
            // 绑定时使用DGV自动生成列
            dataGridView1.DataSource = bindingSource;

            // 设置行标题文字
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = "Row" + i.ToString();
            }
        }

        /// <summary>
        /// 设置最后一列的宽度
        /// </summary>
        private void SetLastColumnWidth()
        {
            int columnIndex = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns[columnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void InitClipbrdCopyModesList()
        {
            cboClipbrdCopyModes.Items.Add("请选择剪贴板复制模式");

            cboClipbrdCopyModes.Items.Add("Disable");
            cboClipbrdCopyModes.Items.Add("EnableAlwaysIncludeHeaderText");
            cboClipbrdCopyModes.Items.Add("EnableWithAutoHeaderText");
            cboClipbrdCopyModes.Items.Add("EnableWithoutHeaderText");

            cboClipbrdCopyModes.SelectedIndex = 0;
        }

        private void cboClipbrdCopyModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClipbrdCopyModes.SelectedIndex > 0)
            {
                try
                {
                    string mode = cboClipbrdCopyModes.Text;
                    dataGridView1.ClipboardCopyMode = (DataGridViewClipboardCopyMode)(Enum.Parse(typeof(DataGridViewClipboardCopyMode), mode, true));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("改变剪贴板复制模式时出错：" + ex.Message, "ClipboardCopy Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClipbrdContent_Click(object sender, EventArgs e)
        {
            // 获取剪贴板当前内容
            IDataObject obj = Clipboard.GetDataObject();

            // 剪贴板内容如果可以转换为文本
            if (obj.GetDataPresent(DataFormats.Text))
            {
                rtfClipbrdContent.Text = obj.GetData(DataFormats.Text).ToString();
            }
            else
            {
                MessageBox.Show("对不起，我这里只能接收文本内容", "ClipboardCopy Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}