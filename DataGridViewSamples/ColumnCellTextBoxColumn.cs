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
        /// 初始化dataGridView1
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
            // 使单元格的文本可以换行
            dataGridView1.Columns[titleColumnIndex].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        #region CellFormatting & CellParsing 事件

        int firstNameColumnIndex = 2;

        // 显示单元格前，对其格式化时触发该事件
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 如果是新行，应跳过否则会抛出异常
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if (row.IsNewRow) { return; }

            if (e.ColumnIndex == firstNameColumnIndex && e.Value.ToString().StartsWith("A"))
            {
                // 将FirstName列以A开头的单元格文本设置为红色
                e.CellStyle.ForeColor = Color.Red;
            }
        }

        // 用户修改单元格值后，进行提交时，需要解析数据已显示
        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            string firstName = e.Value.ToString();
            if (e.ColumnIndex == firstNameColumnIndex && firstName.Length < 4)
            {
                MessageBox.Show("FirstName不能小于4位");
            }
        }

        #endregion CellFormatting & CellParsing 事件

    }
}