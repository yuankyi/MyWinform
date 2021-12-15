using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class OverviewCustomPainting : Form
    {
        public OverviewCustomPainting()
        {
            InitializeComponent();
        }

        private void OverviewCustomPainting_Load(object sender, EventArgs e)
        {
            SetDataSource();
            BindDataGridView1();
            BindDataGridView2();
        }

        #region DataBinding

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

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "C3";
            dataGridView1.Columns.Add(col2);
            col2.SortMode = DataGridViewColumnSortMode.Programmatic;
            col2.HeaderCell.SortGlyphDirection = SortOrder.Ascending;

            // 避免自动生成列
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
        }

        private void BindDataGridView2()
        {
            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.DataPropertyName = "C1";
            dataGridView2.Columns.Add(col0);
            col0.SortMode = DataGridViewColumnSortMode.Programmatic;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.DataPropertyName = "C2";
            dataGridView2.Columns.Add(col1);
            col1.SortMode = DataGridViewColumnSortMode.Programmatic;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "C3";
            dataGridView2.Columns.Add(col2);
            col2.SortMode = DataGridViewColumnSortMode.Programmatic;

            // 避免自动生成列
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = bindingSource;
        }

        #endregion DataBinding

        private void dataGridView2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts = DataGridViewPaintParts.All & ~(DataGridViewPaintParts.Focus | DataGridViewPaintParts.SelectionBackground | DataGridViewPaintParts.ContentBackground);
        }

        //
    }
}