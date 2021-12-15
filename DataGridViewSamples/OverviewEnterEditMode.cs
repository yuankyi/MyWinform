using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class OverviewEnterEditMode : Form
    {
        public OverviewEnterEditMode()
        {
            InitializeComponent();
        }

        private void OverviewEnterEditMode_Load(object sender, EventArgs e)
        {
            SetDataSource();
            BindDataGridView1();
            SetLastColumnWidth();

            InitEnterEditModesList();
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
            // 对数据源进行排序
            view.Sort = "C2 ASC, C3 ASC";
            bindingSource.DataSource = view;
        }

        private void BindDataGridView1()
        {
            // 绑定时使用DGV自动生成列
            dataGridView1.DataSource = bindingSource;
        }

        /// <summary>
        /// 设置最后一列的宽度
        /// </summary>
        private void SetLastColumnWidth()
        {
            int columnIndex = dataGridView1.Columns.Count - 1;
            dataGridView1.Columns[columnIndex].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void InitEnterEditModesList()
        {
            cboEnterEditModes.Items.Add("请选择输入编辑模式");

            cboEnterEditModes.Items.Add("EditOnEnter");
            cboEnterEditModes.Items.Add("EditOnF2");
            cboEnterEditModes.Items.Add("EditOnKeystroke");
            cboEnterEditModes.Items.Add("EditOnKeystrokeOrF2");
            cboEnterEditModes.Items.Add("EditProgrammatically");

            cboEnterEditModes.SelectedIndex = 0;
        }

        private void cboEnterEditModes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEnterEditModes.SelectedIndex > 0)
            {
                try
                {
                    string mode = cboEnterEditModes.Text;
                    dataGridView1.EditMode = (DataGridViewEditMode)(Enum.Parse(typeof(DataGridViewEditMode), mode, true));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("改变编辑模式时出错：" + ex.Message, "Enter-Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}