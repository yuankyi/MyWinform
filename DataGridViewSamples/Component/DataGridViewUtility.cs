using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    class DataGridViewUtility
    {
        /// <summary>
        /// ����ĩ�п�ȣ�ʹ֮�����DGV��ʣ������
        /// </summary>
        /// <param name="dgv">Ҫ������DGV</param>
        public static void FillLastColumnWidth(DataGridView dgv)
        {
            if (dgv.Columns.Count < 1){ return; }

            dgv.Columns[dgv.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // ��֤һ����Ԫ��������Ƿ�Ϊ������ʽ
        public static bool ValidateDateTimeCell(DataGridViewCellValidatingEventArgs e)
        {
            string value = e.FormattedValue.ToString();

            try
            {
                DateTime.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
