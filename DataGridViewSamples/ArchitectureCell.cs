using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class ArchitectureCell : Form
    {
        public ArchitectureCell()
        {
            InitializeComponent();
        }

        private void DGVCellForm_Load(object sender, EventArgs e)
        {
            BindDataGridView1();
            SetCellsReadonly();
            SetCellsDisable();
        }

        private void BindDataGridView1()
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

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.DataPropertyName = "C1";
            dataGridView1.Columns.Add(col0);
            col0.SortMode = DataGridViewColumnSortMode.Programmatic;
            col0.HeaderCell.SortGlyphDirection = SortOrder.None;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "C2";
            dataGridView1.Columns.Add(col1);
            col1.SortMode = DataGridViewColumnSortMode.Programmatic;
            // 设置列的排序符号为向上的箭头
            col1.HeaderCell.SortGlyphDirection = SortOrder.Ascending;

            // 添加一个自定义列，可以使该列的单元格不可用
            DataGridViewDisableButtonColumn col2 = new DataGridViewDisableButtonColumn();
            col2.DataPropertyName = "C3";
            dataGridView1.Columns.Add(col2);
            col2.SortMode = DataGridViewColumnSortMode.Programmatic;
            col2.HeaderCell.SortGlyphDirection = SortOrder.Ascending;

            // 添加一个自定义列，该列可以同时显示文本和图片
            DataGridViewTextAndImageColumn col3 = new DataGridViewTextAndImageColumn();
            col3.DataPropertyName = "C3";
            col3.Image = Image.FromFile(@"xml.gif");
            dataGridView1.Columns.Add(col3);

            // 避免自动生成列
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
        }

        /// <summary>
        /// 设置单元格为只读
        /// </summary>
        private void SetCellsReadonly()
        {
            // 将第一行所有单元格设置为只读
            dataGridView1.Rows[0].ReadOnly = true;

            // 将第一列所有单元格设置为只读
            dataGridView1.Columns[0].ReadOnly = true;

            // 将第二行第二列设置为只读
            dataGridView1.Rows[1].Cells[1].ReadOnly = true;
        }

        private void SetCellsDisable()
        {
            DataGridViewDisableButtonCell cell = dataGridView1.Rows[1].Cells[2] as DataGridViewDisableButtonCell;
            cell.Enabled = false;
        }

        private void btnShowReturnChar_Click(object sender, EventArgs e)
        {
            // 未能实现FAQ中的所说的 "方块"
            DataGridViewCell cell = dataGridView1.Rows[0].Cells[1];
            cell.Value = string.Format("{0}{1}{2}{1}{3}", "hello", "\r\n", "World", "And Welcome!");
        }
    }
}