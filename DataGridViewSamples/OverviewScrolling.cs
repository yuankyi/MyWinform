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
        /// ��������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">
        /// ScrollOrientation����ָʾ�˹����ķ���
        /// NewValueָʾ�˹��������λ�ã�ע��ˮƽ����������أ���ֱ�����������������
        /// </param>
        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            ScrollOrientation orientation = e.ScrollOrientation;
            if (orientation == ScrollOrientation.HorizontalScroll && e.NewValue >= 200)
            {
                MessageBox.Show("���Ѿ�ˮƽ������200���أ�", "Scrolling");
            }
            else if (orientation == ScrollOrientation.VerticalScroll && e.NewValue >= 5)
            {
                MessageBox.Show("���Ѿ���ֱ�������˵����У�", "Scrolling");
            }
        }
    }
}