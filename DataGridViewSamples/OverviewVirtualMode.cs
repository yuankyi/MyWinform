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
        // 用于数据存储
        private ArrayList customers = new ArrayList();

        // 声明一个Customer对象来保存当前编辑对象的数据
        private Customer customerInEdit;

        // 声明一个变量来存储当前编辑的行索引
        // 如果值为-1，表示没有任何行处于编辑状态
        private int rowInEdit = -1;

        // 声明一个变量来表示提交的范围，如果为true，表示提交行，否则提交一个单元格
        private bool rowScopeCommit = true;

        public OverviewVirtualMode()
        {
            InitializeComponent();

            this.dataGridView1.Dock = DockStyle.Fill;
            this.Text = "DataGridView控件的虚拟模式";
        }

        private void BestPracticeVirtualMode_Load(object sender, EventArgs e)
        {
            // 使用虚拟模式
            this.dataGridView1.VirtualMode = true;

            // 为虚拟模式相关的事件添加处理函数 
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

            // 为DataGridView添加列
            DataGridViewTextBoxColumn companyNameColumn = new DataGridViewTextBoxColumn();
            companyNameColumn.HeaderText = "Company Name";
            companyNameColumn.Name = "Company Name";
            DataGridViewTextBoxColumn contactNameColumn = new DataGridViewTextBoxColumn();
            contactNameColumn.HeaderText = "Contact Name";
            contactNameColumn.Name = "Contact Name";
            this.dataGridView1.Columns.Add(companyNameColumn);
            this.dataGridView1.Columns.Add(contactNameColumn);
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // 添加示例数据
            this.customers.Add(new Customer("Bon app'", "Laurence Lebihan"));
            this.customers.Add(new Customer("Bottom-Dollar Markets", "Elizabeth Lincoln"));
            this.customers.Add(new Customer("B's Beverages", "Victoria Ashworth"));

            // 设置行数，包括新行
            this.dataGridView1.RowCount = 4;
        }

        private void dataGridView1_CellValueNeeded(object sender, System.Windows.Forms.DataGridViewCellValueEventArgs e)
        {
            // 如果为新行，不需要任何值
            if (e.RowIndex == this.dataGridView1.RowCount - 1) { return; }

            Customer customerTmp = null;

            // 为要绘制的行保存Customer对象的引用；
            if (e.RowIndex == rowInEdit)
            {
                customerTmp = this.customerInEdit;
            }
            else
            {
                customerTmp = (Customer)this.customers[e.RowIndex];
            }

            // 用获得的Customer对象来绘制单元格的值
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

            // 保存当前编辑行对应的Customer对象的引用；
            if (e.RowIndex < this.customers.Count)
            {
                // 如果用户在编辑新行，创建一个新的Customer对象；
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

            // 保存单元格的值到Customer对象的属性；
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
            // 如果要编辑新行，创建一个新的Customer对象；
            this.customerInEdit = new Customer();
            this.rowInEdit = this.dataGridView1.Rows.Count - 1;
        }

        // 该事件发生在 对一行的验证完成后
        private void dataGridView1_RowValidated(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            // 保存所做的任何修改，释放当前编辑对象的引用
            // 第一种情况是 该行为“旧”的新行
            if (e.RowIndex >= this.customers.Count && e.RowIndex != this.dataGridView1.Rows.Count - 1)
            {
                // 添加新对象到数据源
                this.customers.Add(this.customerInEdit);
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
            // 第二种情况是 该行为旧行
            else if (this.customerInEdit != null && e.RowIndex < this.customers.Count)
            {
                // 保存修改后的数据源
                this.customers[e.RowIndex] = this.customerInEdit;
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
            // 第二种情况是 该行为新行，此时放弃修改
            else if (this.dataGridView1.ContainsFocus)
            {
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
        }

        // 该事件用于查看 是否有未提交的修改
        private void dataGridView1_RowDirtyStateNeeded(object sender, System.Windows.Forms.QuestionEventArgs e)
        {
            if (!rowScopeCommit)
            {
                // In cell-level commit scope, indicate whether the value
                // of the current cell has been modified.
                e.Response = this.dataGridView1.IsCurrentCellDirty;
            }
        }

        // 如果用户 取消了对一行的编辑
        private void dataGridView1_CancelRowEdit(object sender, System.Windows.Forms.QuestionEventArgs e)
        {
            if (this.rowInEdit == this.dataGridView1.Rows.Count - 2 && this.rowInEdit == this.customers.Count)
            {
                // 如果用户取消了对新添加行的编辑，则使用一个新的空对象表示当前编辑对象；
                this.customerInEdit = new Customer();
            }
            else
            {
                // 如果取消了对现有行的编辑，释放相应的对象
                this.customerInEdit = null;
                this.rowInEdit = -1;
            }
        }

        // 如果用户 要删除一行
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