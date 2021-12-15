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
    public partial class ManipulateDataMasterDetail : Form
    {
        public ManipulateDataMasterDetail()
        {
            InitializeComponent();
        }

        private void ManipulateDataMasterDetail_Load(object sender, EventArgs e)
        {
            // 将DataGridView绑定到BindingSource
            masterDataGridView.DataSource = masterBindingSource;
            detailsDataGridView.DataSource = detailsBindingSource;
            // 从数据库加载数据
            GetData();

            // 调整主DataGridView的列以适应新加载的数据
            masterDataGridView.AutoResizeColumns();
            // 设置从DataGridView，使它能随其加载数据的变化自动调整列宽度
            detailsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void GetData()
        {
            try
            {
                string connectionString = ConfigReader.GetConfig("DefaultConnString");

                SqlConnection connection = new SqlConnection(connectionString);

                // 创建DataSet
                DataSet data = new DataSet();
                data.Locale = System.Globalization.CultureInfo.InvariantCulture;

                // 将Customers表的数据添加到DataSet
                SqlDataAdapter masterDataAdapter = new
                    SqlDataAdapter("select * from Customers", connection);
                masterDataAdapter.Fill(data, "Customers");

                // 将Orders表的数据添加到DataSet
                SqlDataAdapter detailsDataAdapter = new
                    SqlDataAdapter("select * from Orders", connection);
                detailsDataAdapter.Fill(data, "Orders");

                // 在两个DataTable间建立关系
                DataRelation relation = new DataRelation("CustomersOrders", data.Tables["Customers"].Columns["CustomerID"], data.Tables["Orders"].Columns["CustomerID"]);
                data.Relations.Add(relation);

                // 将Customers(主表)绑定到masterBindingSource
                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "Customers";

                // Bind the details data connector to the master data connector,
                //使用DataRelation来根据主表当前数据进行过滤 
                detailsBindingSource.DataSource = masterBindingSource;
                detailsBindingSource.DataMember = "CustomersOrders";

            }
            catch(SqlException)
            {
                MessageBox.Show("要使本示例正确运行，请确保链接字符串是正确的");
            }
        }
    }
}