using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class OverviewScrolling : Form
    {
        public OverviewScrolling()
        {
            InitializeComponent();
        }

        private void OverviewScrolling_Load(object sender, EventArgs e)
        {
            InitDataGridView();
        }

        private void InitDataGridView()
        {
            dataGridView1.ColumnCount = 8;
            dataGridView1.RowCount = 20;
        }

        /// <summary>
        /// 处理滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        /// ScrollOrientation属性指示了滚动的方向
        /// NewValue指示了滚动后的新位置，注意水平方向基于像素，垂直方向则基于行索引。
        /// </param>
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            ScrollOrientation orientation = e.ScrollOrientation;
            if (orientation == ScrollOrientation.HorizontalScroll && e.NewValue >= 200)
            {
                MessageBox.Show("你已经水平滚动了200像素！", "Scrolling");
            }
            else if (orientation == ScrollOrientation.VerticalScroll && e.NewValue >= 5)
            {
                MessageBox.Show("你已经垂直滚动到了第六行！", "Scrolling");
            }
        }
    }
}