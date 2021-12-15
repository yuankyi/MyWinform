using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    public partial class ManipulateDataCustomErrorIcon : Form
    {
        private ToolTip errorTooltip;
        private Point cellInError = new Point(-2, -2);

        public ManipulateDataCustomErrorIcon()
        {
            InitializeComponent();

            dataGridView1.ColumnCount = 3;
            dataGridView1.RowCount = 10;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                if (e.FormattedValue.ToString() == "BAD")
                {
                    DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
                    cell.ErrorText = "Invalid data entered in cell.";

                    if (cell.Tag == null)
                    {
                        cell.Tag = cell.Style.Padding;
                        cell.Style.Padding = new Padding(0, 0, 18, 0);
                        cellInError = new Point(e.ColumnIndex, e.RowIndex);
                    }
                    if (errorTooltip == null)
                    {
                        errorTooltip = new ToolTip();
                        errorTooltip.InitialDelay = 0;
                        errorTooltip.ReshowDelay = 0;
                        errorTooltip.Active = false;
                    }
                    e.Cancel = true;
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty && !string.IsNullOrEmpty(e.ErrorText))
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~(DataGridViewPaintParts.ErrorIcon));

                GraphicsContainer container = e.Graphics.BeginContainer();
                e.Graphics.TranslateTransform(18, 0);
                e.Paint(this.ClientRectangle, DataGridViewPaintParts.ErrorIcon);
                e.Graphics.EndContainer(container);

                e.Handled = true;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1[e.ColumnIndex, e.RowIndex].ErrorText != string.Empty)
            {
                DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];
                cellInError = new Point(-2, -2);

                // restore padding for cell. This moves the editing control
                cell.Style.Padding = (Padding)cell.Tag;

                // hide and dispose tooltip
                if (errorTooltip != null)
                {
                    errorTooltip.Hide(dataGridView1);
                    errorTooltip.Dispose();
                    errorTooltip = null;
                }
            }
        }

        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (cellInError.X == e.ColumnIndex && cellInError.Y == e.RowIndex)
            {
                DataGridViewCell cell = dataGridView1[e.ColumnIndex, e.RowIndex];

                if (cell.ErrorText != string.Empty)
                {
                    if (!errorTooltip.Active)
                    {
                        errorTooltip.Show(cell.ErrorText, dataGridView1, 1000);
                    }
                    errorTooltip.Active = true;
                }
            }
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (cellInError.X == e.ColumnIndex && cellInError.Y == e.RowIndex)
            {
                if (errorTooltip.Active)
                {
                    errorTooltip.Hide(dataGridView1);
                    errorTooltip.Active = false;
                }
            }
        }
    }
}