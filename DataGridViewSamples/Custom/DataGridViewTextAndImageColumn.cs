using System;
using System.Drawing;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewSamples
{
    class DataGridViewTextAndImageColumn : DataGridViewTextBoxColumn
    {
        private Image imageValue;
        private Size imageSize;

        public DataGridViewTextAndImageColumn()
        {
            this.CellTemplate = new DataGridViewTextAndImageCell();
        }

        public override object Clone()
        {
            DataGridViewTextAndImageColumn column = base.Clone() as DataGridViewTextAndImageColumn;
            column.imageValue = this.imageValue;
            column.imageSize = this.imageSize;
            return column;
        }

        public Image Image
        {
            get
            {
                return this.imageValue;
            }
            set
            {
                if (this.Image != value)
                {
                    this.imageValue = value;
                    this.imageSize = value.Size;

                    if (this.InheritedStyle != null)
                    {
                        Padding inheritedPadding = this.InheritedStyle.Padding;
                        this.DefaultCellStyle.Padding = new Padding(imageSize.Width, inheritedPadding.Top, inheritedPadding.Right, inheritedPadding.Bottom);
                    }
                }
            }
        }

        private DataGridViewTextAndImageCell TextAndImageCellTemplate
        {
            get
            {
                return this.CellTemplate as DataGridViewTextAndImageCell;
            }
        }

        internal Size ImageSize
        {
            get
            {
                return imageSize;
            }
        }
    }

    class DataGridViewTextAndImageCell : DataGridViewTextBoxCell
    {
        private Image imageValue;
        private Size imageSize;

        public override object Clone()
        {
            DataGridViewTextAndImageCell cell = base.Clone() as DataGridViewTextAndImageCell;
            cell.imageValue = this.imageValue;
            cell.imageSize = this.imageSize;
            return cell;
        }

        /// <summary>
        /// 获取或设置该单元格显示的图片
        /// </summary>
        public Image Image
        {
            get
            {
                if (this.OwningColumn == null || this.OwningTextAndImageColumn == null)
                {
                    return imageValue;
                }
                else if (this.imageValue != null)
                {
                    return this.imageValue;
                }
                else
                {
                    return this.OwningTextAndImageColumn.Image;
                }
            }
            set
            {
                if (this.imageValue != value)
                {
                    this.imageValue = value;
                    this.imageSize = value.Size;

                    Padding inheritedPadding = this.InheritedStyle.Padding;
                    this.Style.Padding = new Padding(imageSize.Width,
                    inheritedPadding.Top, inheritedPadding.Right,
                    inheritedPadding.Bottom);
                }
            }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState,
        object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle,
        DataGridViewPaintParts paintParts)
        {
            // 绘制基类内容
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            if (this.Image != null)
            {
                // 绘制单元格的内容
                System.Drawing.Drawing2D.GraphicsContainer container =
                graphics.BeginContainer();

                graphics.SetClip(cellBounds);
                graphics.DrawImageUnscaled(this.Image, new Point(cellBounds.Location.X + 50, cellBounds.Y + 5));

                graphics.EndContainer(container);
            }
        }

        private DataGridViewTextAndImageColumn OwningTextAndImageColumn
        {
            get { return this.OwningColumn as DataGridViewTextAndImageColumn; }
        }
    }
}
