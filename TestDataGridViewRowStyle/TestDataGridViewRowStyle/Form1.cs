using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestDataGridViewRowStyle
{
    public partial class Form1 : Form
    {
        //������������ʽ
        private DataGridViewCellStyle m_RowStyleNormal;
        private DataGridViewCellStyle m_RowStyleAlternate;

        //�ɼ���DataTable
        private DataTable m_GradeTable;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.dgvGrade.AutoGenerateColumns = false;
            this.SetRowStyle();
            this.BindData();
        }

        /// <summary>
        /// ��������ʽ
        /// </summary>
        private void SetRowStyle()
        {
            //�ɸ�����Ҫ���ø�����ʽ���ԣ������塢���롢ǰ��ɫ������ɫ��
            this.m_RowStyleNormal = new DataGridViewCellStyle();
            this.m_RowStyleNormal.BackColor = Color.LightBlue;
            this.m_RowStyleNormal.SelectionBackColor = Color.LightSteelBlue;

            this.m_RowStyleAlternate = new DataGridViewCellStyle();
            this.m_RowStyleAlternate.BackColor = Color.LightGray;
            this.m_RowStyleAlternate.SelectionBackColor = Color.LightSlateGray;
        }

        /// <summary>
        /// ������
        /// </summary>
        private void BindData()
        {
            //����һ��DataTable��������ݣ�Ȼ��󶨵�DataGridView�ؼ���
            m_GradeTable = new DataTable();
            m_GradeTable.Columns.Add("Class", typeof(string));
            m_GradeTable.Columns.Add("Name", typeof(string));
            m_GradeTable.Columns.Add("Grade", typeof(int));
            m_GradeTable.Rows.Add(new string[] { "Class1", "Jim", "89" });
            m_GradeTable.Rows.Add(new string[] { "Class1", "Jack", "77" });
            m_GradeTable.Rows.Add(new string[] { "Class1", "Bill", "91" });
            m_GradeTable.Rows.Add(new string[] { "Class2", "Tom", "58" });
            m_GradeTable.Rows.Add(new string[] { "Class2", "Rose", "95" });
            m_GradeTable.Rows.Add(new string[] { "Class3", "Peter", "64" });
            m_GradeTable.Rows.Add(new string[] { "Class3", "David", "82" });
            m_GradeTable.Rows.Add(new string[] { "Class3", "Eric", "68" });
            m_GradeTable.Rows.Add(new string[] { "Class3", "Lily", "79" });
            this.bdsGrade.DataSource = m_GradeTable;
        }

        private void dgvDataTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //�ڴ˶�����ʽ��������
            
            if (e.ColumnIndex == this.dgvGrade.Columns["ColumnClass"].Index)//���ݰ༶��������ʽ
            {
                DataGridViewRow CurrentRow = this.dgvGrade.Rows[e.RowIndex];
                CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);//��ʾ�кţ�Ҳ�������ó���ʾ������Ϣ
                //CurrentRow.HeaderCell.ToolTipText = "��ǰ��" + Convert.ToString(e.RowIndex + 1) + "��";//����ToolTip��Ϣ

                //����Ϊ������һ�������ж��������Ч��
                if (e.RowIndex == 0)//���б������⴦����������Ϊ������ʽ
                {
                    CurrentRow.DefaultCellStyle = this.m_RowStyleNormal;
                }
                else
                {
                    //�жϺ���һ���Ƿ�����ͬһ���༶���������������ͬ��ʽ������������һ����ʽ
                    //��Ҫ��������DataGridViewCellStyle�����ڽ�����ʾ��Ҳ���Ը�����Ҫ����һЩ����һ���ظ�����Ϣ
                    //���ﵱ������ͬһ���༶ʱ������һ�еİ༶��Ϣ���ص���ѡ��ʱ����ʾ�༶��Ϣ
                    if (CurrentRow.Cells[e.ColumnIndex].Value != DBNull.Value && CurrentRow.Cells[e.ColumnIndex].Value != null
                        && CurrentRow.Cells[e.ColumnIndex].Value.ToString() == this.dgvGrade.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString())
                    {
                        CurrentRow.DefaultCellStyle = this.dgvGrade.Rows[e.RowIndex - 1].DefaultCellStyle;//���ú���һ�е���ʽ��ͬ
                        CurrentRow.Cells[e.ColumnIndex].Style.ForeColor = CurrentRow.DefaultCellStyle.BackColor;//��ǰ��ɫ������Ϣ
                        //�����Ҫѡ��ʱ��ʾ������Ϣ��ע�͸�����һ��
                        //CurrentRow.Cells[e.ColumnIndex].Style.SelectionForeColor = CurrentRow.DefaultCellStyle.SelectionBackColor;//ѡ��ʱҲʹǰ��ɫ���ڱ���ɫ�����������ص�
                    }
                    else//��ǰ�к���һ�в�����ͬһ���༶ʱ
                    {
                        if (this.dgvGrade.Rows[e.RowIndex - 1].DefaultCellStyle == this.m_RowStyleNormal)//������һ�е���ʽ���õ�ǰ�е���ʽ
                            CurrentRow.DefaultCellStyle = this.m_RowStyleAlternate;
                        else
                            CurrentRow.DefaultCellStyle = this.m_RowStyleNormal;
                    }
                }//if(e.RowIndex == 0)
            }
            else if (e.ColumnIndex == this.dgvGrade.Columns["ColumnGrade"].Index)//���ݳɼ����õ�Ԫ����ʽ
            {
                if (this.dgvGrade.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value 
                    && Convert.ToInt32(this.dgvGrade.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) < 60)//�Բ�����ĳɼ�����������ʽ
                {
                    this.dgvGrade.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Red;//����С��60��������ʾΪ��ɫ
                    this.dgvGrade.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Red;
                    this.dgvGrade.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        //�������������б�ͷ
        private void dgvDataTable_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (this.dgvGrade.Rows[e.RowIndex].Cells["ColumnGrade"].Value == DBNull.Value)
                return;

            int intGrade = Convert.ToInt32(this.dgvGrade.Rows[e.RowIndex].Cells["ColumnGrade"].Value);//��ȡ�ɼ�
            Image RowIcon;//��ͷͼ��
            string strToolTip;//��ʾ��Ϣ

            if (intGrade >= 90)
            {
                RowIcon = TestDataGridViewRowStyle.Properties.Resources.GradeA;//����Դ�ļ��л�ȡͼƬ
                strToolTip = "Grade A";
            }
            else if (intGrade >= 80)
            {
                RowIcon = TestDataGridViewRowStyle.Properties.Resources.GradeB;
                strToolTip = "Grade B";
            }
            else if (intGrade >= 70)
            {
                RowIcon = TestDataGridViewRowStyle.Properties.Resources.GradeC;
                strToolTip = "Grade C";
            }
            else if (intGrade >= 60)
            {
                RowIcon = TestDataGridViewRowStyle.Properties.Resources.GradeD;
                strToolTip = "Grade D";
            }
            else
            {
                RowIcon = TestDataGridViewRowStyle.Properties.Resources.GradeF;
                strToolTip = "Grade F";
            }

            e.Graphics.DrawImage(RowIcon, e.RowBounds.Left + this.dgvGrade.RowHeadersWidth - 20, e.RowBounds.Top + 4, 16, 16);//����ͼ��
            this.dgvGrade.Rows[e.RowIndex].HeaderCell.ToolTipText = strToolTip;//������ʾ��Ϣ

        }

        private void dgvGrade_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >=0 && e.ColumnIndex == 2)
            {
                if (this.dgvGrade.Rows[e.RowIndex].Cells["ColumnGrade"].Value == DBNull.Value)
                    return;

                int intGrade = Convert.ToInt32(this.dgvGrade.Rows[e.RowIndex].Cells["ColumnGrade"].Value);
                Image img;
                if (intGrade >= 90)
                {
                    img = TestDataGridViewRowStyle.Properties.Resources.high;
                } 
                else if (intGrade >= 80)
                {
                    img = TestDataGridViewRowStyle.Properties.Resources.arrow;
                }
                else if (intGrade >= 70)
                {
                    img = TestDataGridViewRowStyle.Properties.Resources.up;
                }
                else if (intGrade >= 60)
                {
                    img = TestDataGridViewRowStyle.Properties.Resources.down;
                }
                else
                {
                    img = TestDataGridViewRowStyle.Properties.Resources.low;
                }
                Rectangle newRect = new Rectangle(e.CellBounds.X + 3, e.CellBounds.Y + 5, e.CellBounds.Height - 15, 
                    e.CellBounds.Height - 12);

                using (Brush gridBrush = new SolidBrush(this.dgvGrade.GridColor), backColorBrush = new SolidBrush(e.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush, 2))
                    {
                        // Erase the cell.
                        e.Graphics.FillRectangle(backColorBrush, e.CellBounds);

                        //����
                        Point p1 = new Point(e.CellBounds.Left + e.CellBounds.Width, e.CellBounds.Top);
                        Point p2 = new Point(e.CellBounds.Left + e.CellBounds.Width, e.CellBounds.Top + e.CellBounds.Height);
                        Point p3 = new Point(e.CellBounds.Left, e.CellBounds.Top + e.CellBounds.Height);
                        Point[] ps = new Point[] { p1, p2, p3 };
                        e.Graphics.DrawLines(gridLinePen, ps);

                        //��ͼ��
                        e.Graphics.DrawImage(img, newRect);
                        //���ַ���
                        e.Graphics.DrawString(intGrade.ToString(), e.CellStyle.Font, Brushes.Crimson, 
                            e.CellBounds.Left + 20, e.CellBounds.Top + 5, StringFormat.GenericDefault);
                        e.Handled = true;
                    }
                }
            }
        }
    }
}