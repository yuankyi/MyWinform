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
    // ʹ��ö�����������������Ƽ佨����ϵ�����ṩ�����ڵļ��
    // ͬʱҲ�ɷ���ش洢����
    public enum ColumnName
    {
        EmployeeId,
        LastName,
        FirstName,
        Title,
        TitleOfCourtesy,
        BirthDate,
        HireDate,
        Address,
        City,
        Region,
        PostalCode,
        Country,
        HomePhone,
        Extension,
        Photo,
        Notes,
        ReportsTo,
        PhotoPath,
        OutOfOffice
    };

    public partial class ManipulateDataComboBoxColumn : Form
    {
        string connectionString = ConfigReader.GetConfig("DefaultConnString");

        public ManipulateDataComboBoxColumn()
        {
            InitializeComponent();
        }

        private void ManipulateDataComboBoxColumn_Load(object sender, EventArgs e)
        {
            try
            {
                SetUpForm();
                SetUpDataGridView1();
                SetupDataGridView2();
            }
            catch(Exception)
            {
                MessageBox.Show("��ȡ���ݿ������ȷ�������ַ�����ȷ��", "DataGridViewColumns", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region ��ʼ�����������DataGridView

        private void SetUpForm()
        {
            this.Size = new Size(800, 600);
            FlowLayoutPanel flowLayout = new FlowLayoutPanel();
            flowLayout.FlowDirection = FlowDirection.TopDown;
            flowLayout.Dock = DockStyle.Fill;
            this.Controls.Add(flowLayout);
            this.Text = "DataGridView�е��÷�";
            flowLayout.Controls.Add(dataGridView1);
            flowLayout.Controls.Add(dataGridView2);
        }

        private void SetupDataGridView2()
        {
            dataGridView2.Dock = DockStyle.Bottom;
            dataGridView2.TopLeftHeaderCell.Value = "Sales Details";
            dataGridView2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }

        private void SetUpDataGridView1()
        {
            dataGridView1.DataError += new 
                DataGridViewDataErrorEventHandler(dataGridView1_DataError);
            dataGridView1.CellContentClick += new 
                DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            dataGridView1.CellValuePushed += new 
                DataGridViewCellValueEventHandler(dataGridView1_CellValuePushed);
            dataGridView1.CellValueNeeded += new 
                DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);

            // Virtual mode is turned on so that the
            // unbound DataGridViewCheckBoxColumn will
            // keep its state when the bound columns are
            // sorted.       
            dataGridView1.VirtualMode = true;
            dataGridView1.AutoSize = true;
            dataGridView1.DataSource = Populate("SELECT * FROM Employees");
            dataGridView1.TopLeftHeaderCell.Value = "Employees";
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            // �Ƴ����������Զ����ɵ��У�ʹ�ú����ֶ���ӵ���
            dataGridView1.Columns.Remove(ColumnName.TitleOfCourtesy.ToString());
            dataGridView1.Columns.Remove(ColumnName.ReportsTo.ToString());

            // ���Image��Ϊnull������ʾ�κ����ݣ�������������ã�����ʾ"X"ͼ��
            dataGridView1.Columns[ColumnName.Photo.ToString()].DefaultCellStyle.NullValue = null;

            // ����DataGridView��ʹ��֧�ֻ���
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            AddLinkColumn();
            AddComboBoxColumns();
            AddButtonColumn();
            AddOutOfOfficeColumn();
        }

        /// <summary>
        /// �������ComboBox��
        /// </summary>
        /// ���ComboBox�������ַ�����һ��ͨ������Դ�������ֶ����
        /// ���������ֱ�������ַ����������
        private void AddComboBoxColumns()
        {
            // ͨ������Դ���ComboBox���е���
            DataGridViewComboBoxColumn comboboxColumn = new DataGridViewComboBoxColumn();
            comboboxColumn = CreateComboBoxColumn();
            SetAlternateChoicesUsingDataSource(ref comboboxColumn);
            comboboxColumn.HeaderText = "TitleOfCourtesy (via DataSource property)";
            dataGridView1.Columns.Insert(0, comboboxColumn);

            // �ֶ����ComboBox���е���
            comboboxColumn = CreateComboBoxColumn();
            SetAlternateChoicesUsingItems(ref comboboxColumn);
            comboboxColumn.HeaderText = "TitleOfCourtesy (via Items property)";
            // ��������ӵ����һ��
            dataGridView1.Columns.Add(comboboxColumn);
        }

        /// <summary>
        /// ���Link��
        /// </summary>
        private void AddLinkColumn()
        {
            DataGridViewLinkColumn links = new DataGridViewLinkColumn();

            links.HeaderText = ColumnName.ReportsTo.ToString();
            links.DataPropertyName = ColumnName.ReportsTo.ToString();
            links.ActiveLinkColor = Color.White;
            links.LinkBehavior = LinkBehavior.SystemDefault;
            links.LinkColor = Color.Blue;
            links.TrackVisitedState = true;
            links.VisitedLinkColor = Color.YellowGreen;

            dataGridView1.Columns.Add(links);
        }

        private DataGridViewComboBoxColumn CreateComboBoxColumn()
        {
            DataGridViewComboBoxColumn column =
                new DataGridViewComboBoxColumn();
            {
                column.DataPropertyName = ColumnName.TitleOfCourtesy.ToString();
                column.HeaderText = ColumnName.TitleOfCourtesy.ToString();
                column.DropDownWidth = 160;
                column.Width = 90;
                column.MaxDropDownItems = 3;
                column.FlatStyle = FlatStyle.Flat;
            }
            return column;
        }

        private void SetAlternateChoicesUsingDataSource(ref DataGridViewComboBoxColumn comboboxColumn)
        {
            {
                comboboxColumn.DataSource = RetrieveAlternativeTitles();
                comboboxColumn.ValueMember = ColumnName.TitleOfCourtesy.ToString();
                comboboxColumn.DisplayMember = comboboxColumn.ValueMember;
            }
        }

        private static void SetAlternateChoicesUsingItems(ref DataGridViewComboBoxColumn comboboxColumn)
        {
            {
                comboboxColumn.Items.AddRange(
                    new string[] { "Mr.", "Ms.", "Mrs.", "Dr." });
            }
        }

        private DataTable RetrieveAlternativeTitles()
        {
            return Populate("SELECT distinct TitleOfCourtesy FROM Employees");
        }

        private DataTable Populate(string sqlCommand)
        {
            SqlConnection northwindConnection = new SqlConnection(connectionString);
            northwindConnection.Open();

            SqlCommand command = new SqlCommand(sqlCommand, northwindConnection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);

            return table;
        }

        /// <summary>
        /// ���Sales��ť��
        /// </summary>
        private void AddButtonColumn()
        {
            DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            {
                buttons.HeaderText = "Sales";
                buttons.Text = "Sales";
                buttons.UseColumnTextForButtonValue = true;
                buttons.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                buttons.FlatStyle = FlatStyle.Standard;
                buttons.CellTemplate.Style.BackColor = Color.Honeydew;
                // ���ø��е����������������е�λ��
                buttons.DisplayIndex = 0;
            }

            dataGridView1.Columns.Add(buttons);
        }

        /// <summary>
        /// ���OutOfOffice CheckBox��
        /// </summary>
        private void AddOutOfOfficeColumn()
        {
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.HeaderText = ColumnName.OutOfOffice.ToString();
                column.Name = ColumnName.OutOfOffice.ToString();
                column.AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.DisplayedCells;
                column.FlatStyle = FlatStyle.Standard;
                column.ThreeState = true;
                column.CellTemplate = new DataGridViewCheckBoxCell();
                column.CellTemplate.Style.BackColor = Color.Beige;
            }

            // �����в��ڵ�һ��
            dataGridView1.Columns.Insert(0, column);
        }

        #endregion ��ʼ�����������DataGridView

        #region "SQL Error handling"

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {

            MessageBox.Show("Error happened " + anError.Context.ToString());

            if (anError.Context == DataGridViewDataErrorContexts.Commit)
            {
                MessageBox.Show("Commit error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
            {
                MessageBox.Show("Cell change");
            }
            if (anError.Context == DataGridViewDataErrorContexts.Parsing)
            {
                MessageBox.Show("Parsing error");
            }
            if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
            {
                MessageBox.Show("Leave control error");
            }

            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }

        #endregion "SQL Error handling"

        #region "CellContentClick event handling"

        // ������ButtonColumn��LinkColumn������CellContentClick�¼�
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // ��������¼��ĵ�Ԫ��������ΪLink�У����Ҳ��Ǳ��ⵥԪ��
            if (IsANonHeaderLinkCell(e))
            {
                MoveToLinked(e);
            }
            else if (IsANonHeaderButtonCell(e))
            {
                PopulateSales(e);
            }
        }

        private void MoveToLinked(DataGridViewCellEventArgs e)
        {
            string employeeId;
            object value = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (value is DBNull) { return; }

            employeeId = value.ToString();
            DataGridViewCell boss = RetrieveSuperiorsLastNameCell(employeeId);
            if (boss != null)
            {
                dataGridView1.CurrentCell = boss;
            }
        }

        private void PopulateSales(DataGridViewCellEventArgs buttonClick)
        {
            string employeeId = dataGridView1.Rows[buttonClick.RowIndex].Cells[ColumnName.EmployeeId.ToString()].Value.ToString();
            dataGridView2.DataSource = Populate("SELECT * FROM Orders WHERE EmployeeId = " + employeeId);
        }

        private bool IsANonHeaderLinkCell(DataGridViewCellEventArgs cellEvent)
        {
            if (dataGridView1.Columns[cellEvent.ColumnIndex] is DataGridViewLinkColumn && cellEvent.RowIndex != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsANonHeaderButtonCell(DataGridViewCellEventArgs cellEvent)
        {
            if (dataGridView1.Columns[cellEvent.ColumnIndex] is DataGridViewButtonColumn && cellEvent.RowIndex != -1)
            {
                return true;
            }
            else
            {
                return (false);
            }
        }

        private DataGridViewCell RetrieveSuperiorsLastNameCell(string employeeId)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) { return null; }
                if (row.Cells[ColumnName.EmployeeId.ToString()].Value.ToString().Equals(employeeId))
                {
                    return row.Cells[ColumnName.LastName.ToString()];
                }
            }
            return null;
        }

        #endregion "CellContent Click handling"

        #region "CheckBox state"

        Dictionary<string, bool> inOffice = new Dictionary<string, bool>();

        // CheckBox�е����ݸı�󣬽������ύ������Դʱ�������¼�
        private void dataGridView1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            if (IsCheckBoxColumn(e.ColumnIndex))
            {
                string employeeId = GetKey(e);
                if (!inOffice.ContainsKey(employeeId))
                {
                    inOffice.Add(employeeId, (Boolean)e.Value);
                }
                else
                {
                    inOffice[employeeId] = (Boolean)e.Value;
                }
            }
        }

        private string GetKey(DataGridViewCellValueEventArgs cell)
        {
            return dataGridView1.Rows[cell.RowIndex].Cells[ColumnName.EmployeeId.ToString()].Value.ToString();
        }

        // ���CheckBox���͵�Ԫ��ʱ�������¼�������Ӧ���ڷǰ���
        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (IsCheckBoxColumn(e.ColumnIndex))
            {
                string employeeId = GetKey(e);
                if (!inOffice.ContainsKey(employeeId))
                {
                    bool defaultValue = false;
                    inOffice.Add(employeeId, defaultValue);
                }

                e.Value = inOffice[employeeId];
            }
        }

        private bool IsCheckBoxColumn(int columnIndex)
        {
            DataGridViewColumn outOfOfficeColumn = dataGridView1.Columns[ColumnName.OutOfOffice.ToString()];
            if (dataGridView1.Columns[columnIndex] == outOfOfficeColumn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}