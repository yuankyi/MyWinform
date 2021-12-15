using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class OverviewVirtualMode : Form
    {
        // �������ݴ洢
        private ArrayList customers = new ArrayList();

        // ����һ��Customer���������浱ǰ�༭���������
        private Customer customerInEdit;

        // ����һ���������洢��ǰ�༭��������
        // ���ֵΪ-1����ʾû���κ��д��ڱ༭״̬
        private int rowInEdit = -1;

        // ����һ����������ʾ�ύ�ķ�Χ�����Ϊtrue����ʾ�ύ�У������ύһ����Ԫ��
        private bool rowScopeCommit = true;

        public OverviewVirtualMode()
        {
            InitializeComponent();

            this.dataGridView1.Dock = DockStyle.Fill;
            this.Text = "DataGridView�ؼ�������ģʽ";
        }

        private void BestPracticeVirtualMode_Load(object sender, EventArgs e)
        {
            // ʹ������ģʽ
            this.dataGridView1.VirtualMode = true;

            // Ϊ����ģʽ��ص��¼���Ӵ����� 
            this.dataGridView1.CellValueNeeded += new
                DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);
            this.dataGridView1.CellValuePushed += new
                DataGridViewCellValueEventHandler(dataGridView1_CellValuePushed);
            this.dataGridView1.NewRowNeeded += new
                DataGridViewRowEventHandler(dataGridView1_NewRowNeeded);
            this.dataGridView1.RowValidated += new
                DataGridViewCellEventHandler(dataGridView1_RowValidated);
            this.dataGridView1.RowDirtyStateNeeded += new
                QuestionEventHandler(dataGridView1_RowDirtyStateNeeded);
            this.dataGridView1.CancelRowEdit += new
                QuestionEventHandler(dataGridView1_CancelRowEdit);
            this.dataGridView1.UserDeletingRow += new
                DataGridViewRowCancelEventHandler(dataGridView1_UserDeletingRow);

            // ΪDataGridView�����
            DataGridViewTextBoxColumn companyNameColumn = new DataGridViewTextBoxColumn();
            companyNameColumn.HeaderText = "Company Name";
            companyNameColumn.Name = "Company Name";
            DataGridViewTextBoxColumn contactNameColumn = new DataGridViewTextBoxColumn();
            contactNameColumn.HeaderText = "Contact Name";
            contactNameColumn.Name = "Contact Name";
            this.dataGridView1.Columns.Add(companyNameColumn);
            this.dataGridView1.Columns.Add(contactNameColumn);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // ���ʾ������
            this.customers.Add(new Customer("Bon app'", "Laurence Lebihan"));
            this.customers.Add(new Customer("Bottom-Dollar Markets", "Elizabeth Lincoln"));
            this.customers.Add(new Customer("B's Beverages", "Victoria Ashworth"));

            // ������������������
            this.dataGridView1.RowCount = 4;
        }

        private void dataGridView1_CellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
        {
            // ���Ϊ���У�����Ҫ�κ�ֵ
            if (e.RowIndex == this.dataGridView1.RowCount - 1) { return; }

            Customer customerTmp = null;

            // ΪҪ���Ƶ��б���Customer��������ã�
            if (e.RowIndex == rowInEdit)
            {
                customerTmp = this.customerInEdit;
            }
            else
            {
                customerTmp = (Customer)this.customers[e.RowIndex];
            }

            // �û�õ�Customer���������Ƶ�Ԫ���ֵ
            switch (this.dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Company Name":
                    e.Value = customerTmp.CompanyName;
                    break;

                case "Contact Name":
                    e.Value = customerTmp.ContactName;
                    break;
            }
        }

        private void dataGridView1_CellValuePushed(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
        {
            Customer customerTmp = null;

            // ���浱ǰ�༭�ж�Ӧ��Customer��������ã�
            if (e.RowIndex < this.customers.Count)
            {
                // ����û��ڱ༭���У�����һ���µ�Customer����
                if (this.customerInEdit == null)
                {
                    this.customerInEdit = new Customer(
                        ((Customer)this.customers[e.RowIndex]).CompanyName,
                        ((Customer)this.customers[e.RowIndex]).ContactName);
                }
                customerTmp = this.customerInEdit;
                this.rowInEdit = e.RowIndex;
            }
            else
            {
                customerTmp = this.customerInEdit;
            }

            // ���浥Ԫ���ֵ��Customer��������ԣ�
            String newValue = e.Value as String;
            switch (this.dataGridView1.Columns[e.ColumnIndex].Name)
            {
                case "Company Name":
                    customerTmp.CompanyName = newValue;
                    break;

                case "Contact Name":
                    customerTmp.ContactName = newValue;
                    break;
            }
        }

        private void dataGridView1_NewRowNeeded(object sender, System.Windows.Forms.DataGridViewRowEventArgs e)
        {
            // ���Ҫ�༭���У�����һ���µ�Customer����
            this.customerInEdit = new Customer();
            this.rowInEdit = this.dataGridView1.Rows.Count - 1;
        }

        // ���¼������� ��һ�е���֤��ɺ�
        private void dataGridView1_RowValidated(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            // �����������κ��޸ģ��ͷŵ�ǰ�༭���������
            // ��һ������� ����Ϊ���ɡ�������
            if (e.RowIndex >= this.customers.Count && e.RowIndex != this.dataGridView1.Rows.Count - 1)
            {
                // ����¶�������Դ
                this.customers.Add(this.customerInEdit);
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
            // �ڶ�������� ����Ϊ����
            else if (this.customerInEdit != null && e.RowIndex < this.customers.Count)
            {
                // �����޸ĺ������Դ
                this.customers[e.RowIndex] = this.customerInEdit;
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
            // �ڶ�������� ����Ϊ���У���ʱ�����޸�
            else if (this.dataGridView1.ContainsFocus)
            {
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
        }

        // ���¼����ڲ鿴 �Ƿ���δ�ύ���޸�
        private void dataGridView1_RowDirtyStateNeeded(object sender, System.Windows.Forms.QuestionEventArgs e)
        {
            if (!rowScopeCommit)
            {
                // In cell-level commit scope, indicate whether the value
                // of the current cell has been modified.
                e.Response = this.dataGridView1.IsCurrentCellDirty;
            }
        }

        // ����û� ȡ���˶�һ�еı༭
        private void dataGridView1_CancelRowEdit(object sender, System.Windows.Forms.QuestionEventArgs e)
        {
            if (this.rowInEdit == this.dataGridView1.Rows.Count - 2 && this.rowInEdit == this.customers.Count)
            {
                // ����û�ȡ���˶�������еı༭����ʹ��һ���µĿն����ʾ��ǰ�༭����
                this.customerInEdit = new Customer();
            }
            else
            {
                // ���ȡ���˶������еı༭���ͷ���Ӧ�Ķ���
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
        }

        // ����û� Ҫɾ��һ��
        private void dataGridView1_UserDeletingRow(object sender, System.Windows.Forms.DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < this.customers.Count)
            {
                // If the user has deleted an existing row, remove the 
                // corresponding Customer object from the data store.
                this.customers.RemoveAt(e.Row.Index);
            }

            if (e.Row.Index == this.rowInEdit)
            {
                // If the user has deleted a newly created row, release
                // the corresponding Customer object. 
                this.rowInEdit = -1;
                this.customerInEdit = null;
            }
        }
    }

    public class Customer
    {
        private String companyNameValue;
        private String contactNameValue;

        public Customer()
        {
            // Leave fields empty.
        }

        public Customer(String companyName, String contactName)
        {
            companyNameValue = companyName;
            contactNameValue = contactName;
        }

        public String CompanyName
        {
            get
            {
                return companyNameValue;
            }
            set
            {
                companyNameValue = value;
            }
        }

        public String ContactName
        {
            get
            {
                return contactNameValue;
            }
            set
            {
                contactNameValue = value;
            }
        }
    }


}