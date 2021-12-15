using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class OverviewStyleForm : Form
    {
        private Color originalColor = Color.Empty;

        public OverviewStyleForm()
        {
            InitializeComponent();
        }

        private void OverviewStyleForm_Load(object sender, EventArgs e)
        {
            BindDataGridView1();
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
            // ������Դ��������
            view.Sort = "C2 DESC, C3 ASC";
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
            // �����е��������Ϊ���ϵļ�ͷ
            col1.HeaderCell.SortGlyphDirection = SortOrder.Ascending;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.DataPropertyName = "C3";
            dataGridView1.Columns.Add(col2);
            col2.SortMode = DataGridViewColumnSortMode.Programmatic;
            col2.HeaderCell.SortGlyphDirection = SortOrder.Ascending;

            // �����Զ�������
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
        }

        // �������뵥Ԫ������ʱ����
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // ��������б��ⵥԪ���򲻴���
            if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }

            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            originalColor = cell.Style.BackColor;
            cell.Style.BackColor = Color.Red; 
        }

        // ������뿪��Ԫ������ʱ����
        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // ��������б��ⵥԪ���򲻴���
            if (e.RowIndex == -1 || e.ColumnIndex == -1) { return; }

            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            cell.Style.BackColor = originalColor;
        }
    }
}