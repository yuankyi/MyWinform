using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    class DataGridViewUtility
    {
        /// <summary>
        /// 调整末列宽度，使之能填充DGV的剩余区域
        /// </summary>
        /// <param name="dgv">要调整的DGV</param>
        public static void FillLastColumnWidth(DataGridView dgv)
        {
            if (dgv.Columns.Count < 1){ return; }

            dgv.Columns[dgv.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // 验证一个单元格的内容是否为日期形式
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
