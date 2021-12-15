using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class BestPracticePerformance : Form
    {
        private const int initialValue = -1;
        private const int initialSize = 500000;

        private int numberOfRows = initialSize;
        private Dictionary<int, int> store = new Dictionary<int, int>();

        private DataGridView dataGridView1 = new DataGridView();

        public BestPracticePerformance()
        {
            InitializeComponent();

            this.Text = "DataGridView Virtual Mode Sample";
            dataGridView1.NewRowNeeded += new DataGridViewRowEventHandler(dataGridView1_NewRowNeeded);
            dataGridView1.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView1_RowsAdded);
            dataGridView1.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridView1_CellValidating);
            dataGridView1.CellValueNeeded += new DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);
            dataGridView1.CellValuePushed += new DataGridViewCellValueEventHandler(dataGridView1_CellValuePushed);

            this.Controls.Add(dataGridView1);
            dataGridView1.VirtualMode = true;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.Columns.Add("Numbers", "Positive Numbers");
            dataGridView1.Rows.AddCopies(0, initialSize);
        }

        private void dataGridView1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {
            store.Add(e.RowIndex, int.Parse(e.Value.ToString()));
        }

        private void dataGridView1_CellValueNeeded(object sender,
            DataGridViewCellValueEventArgs e)
        {
            if (store.ContainsKey(e.RowIndex))
            {
                // Use the store if the e value has been modified 
                // and stored.            
                e.Value = store[e.RowIndex];
            }
            else if (newRowNeeded && e.RowIndex == numberOfRows)
            {
                if (dataGridView1.IsCurrentCellInEditMode)
                {
                    e.Value = initialValue;
                }
                else
                {
                    // Show a blank value if the cursor is just resting
                    // on the last row.
                    e.Value = String.Empty;
                }
            }
            else
            {
                e.Value = e.RowIndex;
            }
        }

        void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].ErrorText = "";
            int newInteger;

            // Don't try to validate the 'new row' until finished 
            // editing since there
            // is not any point in validating its initial value.
            if (dataGridView1.Rows[e.RowIndex].IsNewRow) { return; }
            if (!int.TryParse(e.FormattedValue.ToString(),
                out newInteger) || newInteger < 0)
            {
                e.Cancel = true;
                dataGridView1.Rows[e.RowIndex].ErrorText = "the value must be a non-negative integer";
            }
        }

        void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (newRowNeeded)
            {
                newRowNeeded = false;
                numberOfRows++;
            }
        }

        bool newRowNeeded;
        void dataGridView1_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            newRowNeeded = true;
        }

        private void OverviewVirtualMode_Load(object sender, EventArgs e)
        {

        }
    }
}