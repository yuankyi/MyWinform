using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class OverviewSelection : Form
    {
        public OverviewSelection()
        {
            InitializeComponent();
        }

        private void OverviewSelection_Load(object sender, EventArgs e)
        {
            SetDataSource();
            BindDataGridView1();
            SetLastColumnWidth();

            InitSelectionModeList();
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
        }

        /// <summary>
        /// 设置最后一列的宽度
        /// </summary>
        private void SetLastColumnWidth()
        {
            int columnIndex = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns[columnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void InitSelectionModeList()
        {
            cboSelectionMode.Items.Add("CellSelect");
            cboSelectionMode.Items.Add("ColumnHeaderSelect");
            cboSelectionMode.Items.Add("FullColumnSelect");
            cboSelectionMode.Items.Add("FullRowSelect");
            cboSelectionMode.Items.Add("RowHeaderSelect");

            cboSelectionMode.Items.Insert(0, "请设定选择模式");
            cboSelectionMode.SelectedIndex = 0;
        }

        private void cboSelectionMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSelectionMode.SelectedIndex > 0)
            {
                try
                {
                    string mode = cboSelectionMode.Text;
                    dataGridView1.SelectionMode = (DataGridViewSelectionMode)(Enum.Parse(typeof(DataGridViewSelectionMode), mode, true));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("改变选择模式时出错：" + ex.Message, "Selection Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectAll();
        }

        private void btnClearSelection_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void btnAreAllCellsSelected_Click(object sender, EventArgs e)
        {
            bool allSelected = dataGridView1.AreAllCellsSelected(false);
            string message = string.Empty;
            if (allSelected)
            {
                message = "已选中全部";
            }
            else
            {
                message = "尚未选中全部";
            }
            MessageBox.Show(message, "Selection Mode");
        }

        private void btnSelectedItemsInfo_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            message += "选中单元格数：" + dataGridView1.GetCellCount(DataGridViewElementStates.Selected).ToString() + Environment.NewLine;
            message += "选中行数：" + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected).ToString() + Environment.NewLine;
            message += "选中列数：" + dataGridView1.Columns.GetColumnCount(DataGridViewElementStates.Selected).ToString();

            MessageBox.Show(message, "Selection Mode");
        }
    }
}