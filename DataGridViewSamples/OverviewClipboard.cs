using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class OverviewClipboard : Form
    {
        public OverviewClipboard()
        {
            InitializeComponent();
        }

        private void OverviewClipboard_Load(object sender, EventArgs e)
        {
            SetDataSource();
            BindDataGridView1();
            SetLastColumnWidth();

            InitClipbrdCopyModesList();
        }

        private void SetDataSource()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("C1", typeof(int));
            dt.Columns.Add("C2", typeof(string));
            dt.Columns.Add("C3", typeof(string));

            dt.Rows.Add(1, "1", "Test1");
            dt.Rows.Add(2, "2", "Test2");
            dt.Rows.Add(2, "2", "Test1");
            dt.Rows.Add(3, "3", "Test3");
            dt.Rows.Add(4, "4", "Test4");
            dt.Rows.Add(4, "4", "Test3");

            DataView view = dt.DefaultView;
            // ������Դ��������
            view.Sort = "C2 ASC, C3 ASC";
            bindingSource.DataSource = view;
        }

        private void BindDataGridView1()
        {
            // ��ʱʹ��DGV�Զ�������
            dataGridView1.DataSource = bindingSource;

            // �����б�������
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].HeaderCell.Value = "Row" + i.ToString();
            }
        }

        /// <summary>
        /// �������һ�еĿ��
        /// </summary>
        private void SetLastColumnWidth()
        {
            int columnIndex = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns[columnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void InitClipbrdCopyModesList()
        {
            cboClipbrdCopyModes.Items.Add("��ѡ������帴��ģʽ");

            cboClipbrdCopyModes.Items.Add("Disable");
            cboClipbrdCopyModes.Items.Add("EnableAlwaysIncludeHeaderText");
            cboClipbrdCopyModes.Items.Add("EnableWithAutoHeaderText");
            cboClipbrdCopyModes.Items.Add("EnableWithoutHeaderText");

            cboClipbrdCopyModes.SelectedIndex = 0;
        }

        private void cboClipbrdCopyModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClipbrdCopyModes.SelectedIndex > 0)
            {
                try
                {
                    string mode = cboClipbrdCopyModes.Text;
                    dataGridView1.ClipboardCopyMode = (DataGridViewClipboardCopyMode)(Enum.Parse(typeof(DataGridViewClipboardCopyMode), mode, true));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�ı�����帴��ģʽʱ����" + ex.Message, "ClipboardCopy Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClipbrdContent_Click(object sender, EventArgs e)
        {
            // ��ȡ�����嵱ǰ����
            IDataObject obj = Clipboard.GetDataObject();

            // �����������������ת��Ϊ�ı�
            if (obj.GetDataPresent(DataFormats.Text))
            {
                rtfClipbrdContent.Text = obj.GetData(DataFormats.Text).ToString();
            }
            else
            {
                MessageBox.Show("�Բ���������ֻ�ܽ����ı�����", "ClipboardCopy Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}