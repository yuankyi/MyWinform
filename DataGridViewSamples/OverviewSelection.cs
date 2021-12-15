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
            // ������Դ��������
            view.Sort = "C2 ASC, C3 ASC";
            bindingSource.DataSource = view;
        }

        private void BindDataGridView1()
        {
            // ��ʱʹ��DGV�Զ�������
            dataGridView1.DataSource = bindingSource;
        }

        /// <summary>
        /// �������һ�еĿ��
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

            cboSelectionMode.Items.Insert(0, "���趨ѡ��ģʽ");
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
                    MessageBox.Show("�ı�ѡ��ģʽʱ����" + ex.Message, "Selection Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                message = "��ѡ��ȫ��";
            }
            else
            {
                message = "��δѡ��ȫ��";
            }
            MessageBox.Show(message, "Selection Mode");
        }

        private void btnSelectedItemsInfo_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            message += "ѡ�е�Ԫ������" + dataGridView1.GetCellCount(DataGridViewElementStates.Selected).ToString() + Environment.NewLine;
            message += "ѡ��������" + dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected).ToString() + Environment.NewLine;
            message += "ѡ��������" + dataGridView1.Columns.GetColumnCount(DataGridViewElementStates.Selected).ToString();

            MessageBox.Show(message, "Selection Mode");
        }
    }
}