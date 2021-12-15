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

            // 如果Image列为null，则不显示任何内容，如果不作此设置，则显示"X"图像
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