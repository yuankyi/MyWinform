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
            // ��DataGridView�󶨵�BindingSource
            masterDataGridView.DataSource = masterBindingSource;
            detailsDataGridView.DataSource = detailsBindingSource;
            // �����ݿ��������
            GetData();

            // ������DataGridView��������Ӧ�¼��ص�����
            masterDataGridView.AutoResizeColumns();
            // ���ô�DataGridView��ʹ��������������ݵı仯�Զ������п��
            detailsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void GetData()
        {
            try
            {
                string connectionString = ConfigReader.GetConfig("DefaultConnString");

                SqlConnection connection = new SqlConnection(connectionString);

                // ����DataSet
                DataSet data = new DataSet();
                data.Locale = System.Globalization.CultureInfo.InvariantCulture;

                // ��Customers���������ӵ�DataSet
                SqlDataAdapter masterDataAdapter = new
                    SqlDataAdapter("select * from Customers", connection);
                masterDataAdapter.Fill(data, "Customers");

                // ��Orders���������ӵ�DataSet
                SqlDataAdapter detailsDataAdapter = new
                    SqlDataAdapter("select * from Orders", connection);
                detailsDataAdapter.Fill(data, "Orders");

                // ������DataTable�佨����ϵ
                DataRelation relation = new DataRelation("CustomersOrders", data.Tables["Customers"].Columns["CustomerID"], data.Tables["Orders"].Columns["CustomerID"]);
                data.Relations.Add(relation);

                // ��Customers(����)�󶨵�masterBindingSource
                masterBindingSource.DataSource = data;
                masterBindingSource.DataMember = "Customers";

                // Bind the details data connector to the master data connector,
                //ʹ��DataRelation����������ǰ���ݽ��й��� 
                detailsBindingSource.DataSource = masterBindingSource;
                detailsBindingSource.DataMember = "CustomersOrders";

            }
            catch(SqlException)
            {
                MessageBox.Show("Ҫʹ��ʾ����ȷ���У���ȷ�������ַ�������ȷ��");
            }
        }
    }
}