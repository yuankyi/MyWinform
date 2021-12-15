using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class ManipulateDataUnboundMode : Form
    {
        private Dictionary<int, bool> checkState;

        public ManipulateDataUnboundMode()
        {
            InitializeComponent();
        }

        private void ManipulateDataUnboundMode_Load(object sender, EventArgs e)
        {
            SetUpDataGridView1();
        }

        private void SetUpDataGridView1()
        {
            checkState = new Dictionary<int, bool>();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.VirtualMode = true;

            string query = "Select * From Employees";
            DataTable employees = DBHelper.Instance.ExecuteDataSet(query).Tables[0];
            dataGridView1.DataSource = employees;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            AddCheckBoxColumn();

            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void AddCheckBoxColumn()
        {
            DataGridViewCheckBoxColumn selectColumn = new DataGridViewCheckBoxColumn();
            {
                selectColumn.HeaderText = "Select";
                selectColumn.Name = "colSelect";
                selectColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                selectColumn.FlatStyle = FlatStyle.Standard;
                selectColumn.ThreeState = false;
                selectColumn.CellTemplate = new DataGridViewCheckBoxCell();
                selectColumn.CellTemplate.Style.BackColor = Color.Beige;
            }

            dataGridView1.Columns.Insert(0, selectColumn);
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                int employeeId = (int)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                checkState[employeeId] = (bool)dataGridView1.Rows[e.RowIndex].Cells["colSelect"].Value;
            }
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (IsCheckBoxColumn(e.ColumnIndex))
            {
                int employeeId = (int)dataGridView1.Rows[e.RowIndex].Cells["colEmployeeId"].Value;
                if (checkState.ContainsKey(employeeId))
                {
                    e.Value = checkState[employeeId];
                }
                else
                {
                    e.Value = false;
                }
            }
        }

        private void dataGridView1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            if (IsCheckBoxColumn(e.ColumnIndex))
            {
                int employeeId = (int)dataGridView1.Rows[e.RowIndex].Cells["colEmployeeId"].Value;
                if (!checkState.ContainsKey(employeeId))
                {
                    checkState.Add(employeeId, (bool)e.Value);
                }
                else
                {
                    checkState[employeeId] = (bool)e.Value;
                }
            }
        }

        private bool IsCheckBoxColumn(int columnIndex)
        {
            DataGridViewColumn selectColumn = dataGridView1.Columns["colSelect"];
            if (dataGridView1.Columns[columnIndex] == selectColumn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 显示选择雇员的信息
        private void btnOK_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                int employeeId = (int)row.Cells["colEmployeeId"].Value;
                if (checkState.ContainsKey(employeeId) && checkState[employeeId])
                {
                    string firstName = row.Cells["colFirstName"].Value as string;
                    message += firstName + Environment.NewLine;
                }
            }

            if (message.Trim().Length > 0)
            {
                MessageBox.Show("您选择的雇员是：" + Environment.NewLine + message, "混合模式", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("还没选择就好了？", "混合模式", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }
    }
}