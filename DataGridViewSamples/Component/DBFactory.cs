using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataGridViewSamples
{
    class DBFactory
    {
        private DBFactory()
        {
        }

        /// <summary>
        /// ����һ��һ���DataTable����ʾ����
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCommonDataTable()
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

            return dt;
        }

        /// <summary>
        /// ����һ���϶��У��϶��е�DataTable����ʾ����
        /// </summary>
        /// <returns></returns>
        public static DataTable GetLargeDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("C1", typeof(int));
            dt.Columns.Add("C2", typeof(string));
            dt.Columns.Add("C3", typeof(string));
            dt.Columns.Add("C4", typeof(string));
            dt.Columns.Add("C5", typeof(string));
            dt.Columns.Add("C6", typeof(string));

            for (int i = 1; i <= 10; i++)
            {
                dt.Rows.Add(i, "C2TextRow" + i.ToString(), "C3TextRow" + i.ToString(), "C4TextRow" + i.ToString(), "C5TextRow" + i.ToString(), "C6TextRow" + i.ToString());
            }

            return dt;
        }
    }
}
