using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class ManipulateDataValidating : Form
    {
        int employeeIdColumnIndex = 0;
        int lastNameColumnIndex = 1;
        int firstNameColumnIndex = 2;
        int birthDateColumnIndex = 3;
        int hireDateColumnIndex = 4;
        int cityColumnIndex = 5;

        bool rowChanged = false;

        public ManipulateDataValidating()
        {
            InitializeComponent();
        }

        private void ManipulateDataValidating_Load(object sender, EventArgs e)
        {
            SetUpDataGridView1();
        }

        #region 初始化DataGridView1

        /// <summary>
        /// 初始化dataGridView1
        /// </summary>
        private void SetUpDataGridView1()
        {
            dataGridView1.AutoGenerateColumns = false;

            BindDataSource();

            dataGridView1.Columns[0].ReadOnly = true;
        }

        private void BindDataSource()
        {
            string query = "Select * From Employees";
            bindingSource1.DataSource = DBHelper.Instance.ExecuteDataSet(query).Tables[0];

            dataGridView1.DataSource = bindingSource1;
        }

        #endregion 初始化DataGridView1

        #region 验证相关事件的处理方法

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            rowChanged = true;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == birthDateColumnIndex)
            {
                DateTime birthDate;
                DateTime.TryParse(e.FormattedValue.ToString(), out birthDate);

                if (birthDate.Year >= DateTime.Now.Year)
                {
                    DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    cell.ErrorText = "无效的生日日期值";
                }
            }
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!rowChanged) { return; }

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            string valResult = ValidateRowEntry(e);
            if (valResult.Length > 0)
            {
                row.ErrorText = valResult;
                e.Cancel = true;
                return;
            }

            string employeeId = row.Cells[employeeIdColumnIndex].Value.ToString();
            string firstName = row.Cells[firstNameColumnIndex].Value.ToString();
            string lastName = row.Cells[lastNameColumnIndex].Value.ToString();
            string birthDate = row.Cells[birthDateColumnIndex].Value.ToString();
            string hireDate = row.Cells[hireDateColumnIndex].Value.ToString();
            string city = row.Cells[cityColumnIndex].Value.ToString();

            if (string.IsNullOrEmpty(employeeId))
            {
                // 新增Employee
                string query = "Insert Into Employees(LastName, FirstName, BirthDate, HireDate, City) Values('{0}', '{1}', '{2}', '{3}', '{4}')";
                query = string.Format(query, lastName, firstName, birthDate, hireDate, city);
                query += "  Select @@Identity As 'NewEmployeeId'";
                object obj = DBHelper.Instance.ExecuteScalar(query);
                if (obj == null)
                {
                    MessageBox.Show("新建Employee失败！", "数据输入和验证", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    row.Cells[employeeIdColumnIndex].Value = obj;
                }
            }
            else
            {
                string query = "Update Employees Set LastName = '{0}', FirstName = '{1}', BirthDate = '{2}', HireDate = '{3}', City = '{4}' Where EmployeeId = {5}";
                query = string.Format(query, lastName, firstName, birthDate, hireDate, city, employeeId);
                int rowsAffected = DBHelper.Instance.ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    MessageBox.Show("更新Employee成功！", "数据输入和验证", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("更新Employee失败！", "数据输入和验证", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            rowChanged = false;
        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            // 验证结束，去掉本行的错误提示符号
            dataGridView1.Rows[e.RowIndex].ErrorText = string.Empty;
        }

        /// <summary>
        /// 验证一行输入的数据是否有效
        /// </summary>
        /// <param name="rowEntry"></param>
        /// <returns></returns>
        private string ValidateRowEntry(DataGridViewCellCancelEventArgs rowEntry)
        {
            string result = string.Empty;

            DataGridViewRow row = dataGridView1.Rows[rowEntry.RowIndex];

            string lastName = row.Cells[lastNameColumnIndex].Value.ToString();
            string firstName = row.Cells[firstNameColumnIndex].Value.ToString();
            string birthDate = row.Cells[birthDateColumnIndex].Value.ToString();  // 已验证；
            string hireDate = row.Cells[hireDateColumnIndex].Value.ToString();
            string city = row.Cells[cityColumnIndex].Value.ToString();

            if (firstName.Length == 0)
            {
                result += "请输入FirstName" + Environment.NewLine;
            }
            if (lastName.Length == 0)
            {
                result += "请输入LastName" + Environment.NewLine;
            }

            return result;
        }

        #endregion Validating 事件处理

        // 用户添加新记录时，使用该事件为新记录生成默认值
        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[hireDateColumnIndex].Value = DateTime.Now.ToShortDateString();
            e.Row.Cells[cityColumnIndex].Value = "ShangHai";
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string errorText = string.Empty;
            errorText += "您的输入出现错误，位于第" + (e.RowIndex + 1).ToString() + "行，第" + (e.ColumnIndex + 1).ToString() + "列";
            dataGridView1.Rows[e.RowIndex].ErrorText = errorText;

            e.Cancel = true;
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.IsNewRow) { return; }

            DialogResult result = MessageBox.Show("确定要删除该记录？", "数据输入和验证", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                DataGridViewRow row = e.Row;
                string employeeId = row.Cells[employeeIdColumnIndex].Value.ToString();

                string query = "Delete From Employees Where EmployeeId = '{0}'";
                query = string.Format(query, employeeId);
                int rowsAffected = DBHelper.Instance.ExecuteNonQuery(query);
                if (rowsAffected > 0)
                {
                    //MessageBox.Show("删除成功");
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //e.Row;
        }
    }
}