using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class OverviewFrozenColumnOrRow : Form
    {
        public OverviewFrozenColumnOrRow()
        {
            InitializeComponent();
        }

        private void OverviewFrozenColumnOrRow_Load(object sender, EventArgs e)
        {
            BindDataGridView1();
            FreezeSomeColumns();
        }

        /// <summary>
        /// ∞Û∂®DataGridView
        /// </summary>
        private void BindDataGridView1()
        {
            DataTable dt = DBFactory.GetLargeDataTable();
            bindingSource.DataSource = dt.DefaultView;

            dataGridView1.DataSource = bindingSource;
        }

        /// <summary>
        /// ∂≥Ω·¡–
        /// </summary>
        private void FreezeSomeColumns()
        {
            dataGridView1.Columns[0].Frozen = true;
        }
    }
}