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
    public partial class ManipulateDataAdapter : Form
    {
        string connectionString = ConfigReader.GetConfig("DefaultConnString");
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataAdapter employeeAdapter = null;
        DataSet ds = new DataSet();

        public ManipulateDataAdapter()
        {
            InitializeComponent();
        }

        private void ManipulateDataAdapter_Load(object sender, EventArgs e)
        {
            SetupDataSource();

            dataGridView1.DataSource = bindingSource1;

            // ���Image��Ϊnull������ʾ�κ����ݣ�������������ã�����ʾ"X"ͼ��
            dataGridView1.Columns[ColumnName.Photo.ToString()].DefaultCellStyle.NullValue = null;
        }

        private void SetupDataSource()
        {
            conn = new SqlConnection(connectionString);

            string query = "SELECT * FROM Employees";
            cmd = new SqlCommand(query, conn);
            employeeAdapter = new SqlDataAdapter(cmd);

            employeeAdapter.Fill(ds, "Employees");
            new SqlCommandBuilder(employeeAdapter);

            bindingSource1.DataSource = ds;
            bindingSource1.DataMember = "Employees";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bindingSource1.EndEdit();
            this.employeeAdapter.Update(ds, "Employees");
        }
    }
}