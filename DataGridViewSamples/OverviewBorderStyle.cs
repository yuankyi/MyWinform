using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class OverviewBorderStyle : Form
    {
        public OverviewBorderStyle()
        {
            InitializeComponent();
        }

        private void OverviewBorderStyle_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            SetGridBorderStyles();
        }

        private void InitDataGridView()
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.RowCount = 10;
        }

        private void SetGridBorderStyles()
        {
            // ���ñ߿�����
            dataGridView1.BorderStyle = BorderStyle.None;
            // ����������ɫ
            dataGridView1.GridColor = Color.Green;
        }
    }
}