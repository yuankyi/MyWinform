using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class ColumnCellComboxBoxColumn : Form
    {
        int textBoxColumnIndex = 2;
        int comboBoxColumnIndex = 3;
        DataGridViewCellEventArgs currentCell;

        public ColumnCellComboxBoxColumn()
        {
            InitializeComponent();
        }

        private void ColumnCellComboxBoxColumn_Load(object sender, EventArgs e)
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
            SetItemsManually();
            DataGridViewUtility.FillLastColumnWidth(dataGridView1);

            dataGridView1.Columns[0].ReadOnly = true;
        }

        private void BindDataGridView1()
        {
            string query = "Select * From Employees";
            bindingSource1.DataSource = DBHelper.Instance.ExecuteDataSet(query).Tables[0];

            dataGridView1.DataSource = bindingSource1;
        }

        private void SetItemsManually()
        {
            DataGridViewComboBoxColumn comboColumn = dataGridView1.Columns["colTitle"] as DataGridViewComboBoxColumn;

            comboColumn.DataPropertyName = "TitleOfCourtesy";
            comboColumn.DropDownWidth = 160;
            comboColumn.Width = 90;
            comboColumn.MaxDropDownItems = 4;
            comboColumn.FlatStyle = FlatStyle.Flat;

            comboColumn.Items.AddRange(new string[] { "Mr.", "Ms.", "Mrs.", "Dr." });
        }

        #region Ϊ�༭�ؼ�����¼�������

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentCell = e;
        }

        /// <summary>
        /// ������ Ϊ�༭�ؼ�����¼�������
        /// </summary>
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = currentCell.ColumnIndex;

            if (columnIndex == comboBoxColumnIndex)
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    // ʹ��ComboBox�ؼ���������ֵ
                    cb.DropDownStyle = ComboBoxStyle.DropDown;

                    // �Ƚ��Ѵ��ڵ��¼��������Ƴ���������Ӷ���ظ�������
                    cb.SelectedIndexChanged -= new EventHandler(cb_SelectedIndexChanged);

                    cb.SelectedIndexChanged += new EventHandler(cb_SelectedIndexChanged);
                }
            }
            else if (columnIndex == textBoxColumnIndex)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.TextChanged -= new EventHandler(tb_TextChanged);

                    tb.TextChanged += new EventHandler(tb_TextChanged);
                }
            }
        }

        void tb_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("You Changed the firstName!");
        }

        void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("You Changed the title!");
        }

        #endregion Ϊ�༭�ؼ�����¼�������

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == comboBoxColumnIndex)
            {
                DataGridViewComboBoxColumn comboBoxColumn = dataGridView1.Columns[comboBoxColumnIndex] as DataGridViewComboBoxColumn;
                if (!comboBoxColumn.Items.Contains(e.FormattedValue))
                {
                    comboBoxColumn.Items.Add(e.FormattedValue);
                }
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}