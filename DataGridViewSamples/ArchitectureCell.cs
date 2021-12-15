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
            // ������Դ��������
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
            // �����е��������Ϊ���ϵļ�ͷ
            col1.HeaderCell.SortGlyphDirection = SortOrder.Ascending;

            // ���һ���Զ����У�����ʹ���еĵ�Ԫ�񲻿���
            DataGridViewDisableButtonColumn col2 = new DataGridViewDisableButtonColumn();
            col2.DataPropertyName = "C3";
            dataGridView1.Columns.Add(col2);
            col2.SortMode = DataGridViewColumnSortMode.Programmatic;
            col2.HeaderCell.SortGlyphDirection = SortOrder.Ascending;

            // ���һ���Զ����У����п���ͬʱ��ʾ�ı���ͼƬ
            DataGridViewTextAndImageColumn col3 = new DataGridViewTextAndImageColumn();
            col3.DataPropertyName = "C3";
            col3.Image = Image.FromFile(@"xml.gif");
            dataGridView1.Columns.Add(col3);

            // �����Զ�������
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bindingSource;
        }

        /// <summary>
        /// ���õ�Ԫ��Ϊֻ��
        /// </summary>
        private void SetCellsReadonly()
        {
            // ����һ�����е�Ԫ������Ϊֻ��
            dataGridView1.Rows[0].ReadOnly = true;

            // ����һ�����е�Ԫ������Ϊֻ��
            dataGridView1.Columns[0].ReadOnly = true;

            // ���ڶ��еڶ�������Ϊֻ��
            dataGridView1.Rows[1].Cells[1].ReadOnly = true;
        }

        private void SetCellsDisable()
        {
            DataGridViewDisableButtonCell cell = dataGridView1.Rows[1].Cells[2] as DataGridViewDisableButtonCell;
            cell.Enabled = false;
        }

        private void btnShowReturnChar_Click(object sender, EventArgs e)
        {
            // δ��ʵ��FAQ�е���˵�� "����"
            DataGridViewCell cell = dataGridView1.Rows[0].Cells[1];
            cell.Value = string.Format("{0}{1}{2}{1}{3}", "hello", "\r\n", "World", "And Welcome!");
        }
    }
}