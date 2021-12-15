using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class ColumnCellTextBoxColumn : Form
    {
        public ColumnCellTextBoxColumn()
        {
            InitializeComponent();
        }

        private void ColumnCellTextBoxColumn_Load(object sender, EventArgs e)
        {
            SetUpDataGridView1();
        }

        /// <summary>
        /// ��ʼ��dataGridView1
        /// </summary>
        private void SetUpDataGridView1()
        {
            dataGridView1.AutoGenerateColumns = false;
            BindDataGridView1();

            dataGridView1.Columns[0].ReadOnly = true;
            SetColumnWrapMode();
        }

        private void BindDataGridView1()
        {
            string query = "Select * From Employees";
            bindingSource1.DataSource = DBHelper.Instance.ExecuteDataSet(query).Tables[0];

            dataGridView1.DataSource = bindingSource1;
        }

        int titleColumnIndex = 4;
        private void SetColumnWrapMode()
        {
            // ʹ��Ԫ����ı����Ի���
            dataGridView1.Columns[titleColumnIndex].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        #region CellFormatting & CellParsing �¼�

        int firstNameColumnIndex = 2;

        // ��ʾ��Ԫ��ǰ�������ʽ��ʱ�������¼�
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // ��������У�Ӧ����������׳��쳣
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if (row.IsNewRow) { return; }

            if (e.ColumnIndex == firstNameColumnIndex && e.Value.ToString().StartsWith("A"))
            {
                // ��FirstName����A��ͷ�ĵ�Ԫ���ı�����Ϊ��ɫ
                e.CellStyle.ForeColor = Color.Red;
            }
        }

        // �û��޸ĵ�Ԫ��ֵ�󣬽����ύʱ����Ҫ������������ʾ
        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            string firstName = e.Value.ToString();
            if (e.ColumnIndex == firstNameColumnIndex && firstName.Length < 4)
            {
                MessageBox.Show("FirstName����С��4λ");
            }
        }

        #endregion CellFormatting & CellParsing �¼�

    }
}