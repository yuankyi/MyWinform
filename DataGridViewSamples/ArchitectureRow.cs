using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class ArchitectureRow : Form
    {
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

        public ArchitectureRow()
        {
            InitializeComponent();
        }

        private void ArchitectureRow_Load(object sender, EventArgs e)
        {
            BindDataGridView1();
        }

        private void BindDataGridView1()
        {
            DataTable dt = DBFactory.GetCommonDataTable();
            bindingSource1.DataSource = dt.DefaultView;

            dataGridView1.DataSource = bindingSource1;

            //dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            // ����������
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    DragDropEffects dropEffect = dataGridView1.DoDragDrop(dataGridView1.Rows[rowIndexFromMouseDown], DragDropEffects.Move);
                }
            }
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = dataGridView1.HitTest(e.X, e.Y).RowIndex;

            if (rowIndexFromMouseDown != -1)
            {
                Size dragSize = SystemInformation.DragSize;

                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            }
            else
            {
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));

            rowIndexOfItemUnderMouseToDrop = dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (e.Effect == DragDropEffects.Move)
            {
                // ����ʹ����δ��룬����ֻ�����ڷǰ����ݣ�
                //DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                //dataGridView1.Rows.RemoveAt(rowIndexFromMouseDown);
                //dataGridView1.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);

                // ������Դ�л��ԭ���е����ݣ��洢��һ���½�������
                DataTable dt = (bindingSource1.DataSource as DataView).Table;
                object[] rowArray = dt.Rows[rowIndexFromMouseDown].ItemArray;
                DataRow row = dt.NewRow();
                row.ItemArray = rowArray;

                // ��ԭ����ɾ���������µ���
                dt.Rows.RemoveAt(rowIndexFromMouseDown);
                dt.Rows.InsertAt(row, rowIndexOfItemUnderMouseToDrop);
            }
        }
    }
}