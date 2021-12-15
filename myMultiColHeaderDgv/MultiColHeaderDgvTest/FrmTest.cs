using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiColHeaderDgvTest
{
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtable = new DataTable("Rock");
            //set columns names
            dtable.Columns.Add("Band", typeof(System.String));
            dtable.Columns.Add("Song", typeof(System.String));
            dtable.Columns.Add("Album", typeof(System.String));
            dtable.Columns.Add("Album2", typeof(System.String));


            //Add Rows
            DataRow drow = dtable.NewRow();
            drow["Band"] = "Iron Maiden";
            drow["Song"] = "Wasted Years";
            drow["Album"] = "Ed Hunter";
            drow["Album2"] = "kG";
            dtable.Rows.Add(drow);

            drow = dtable.NewRow();
            drow["Band"] = "Metallica";
            drow["Song"] = "Enter Sandman";
            drow["Album"] = "Metallica";
            drow["Album2"] = "Tracy";
            dtable.Rows.Add(drow);

            drow = dtable.NewRow();
            drow["Band"] = "Jethro Tull";
            drow["Song"] = "Locomotive Breath";
            drow["Album"] = "Aqualung";
            drow["Album2"] = "Md";
            dtable.Rows.Add(drow);

            drow = dtable.NewRow();
            drow["Band"] = "Mr. Big";
            drow["Song"] = "Seven Impossible Days";
            drow["Album"] = "Japandemonium";
            drow["Album2"] = "Hunter";
            dtable.Rows.Add(drow);
        
            multiColHeaderDgv2.DataSource = dtable;
       
        }   
    }
}