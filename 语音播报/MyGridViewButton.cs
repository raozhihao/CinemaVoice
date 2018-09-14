using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 语音播报
{
    class MyDataGridViewTextBoxColumn : DataGridViewTextBoxColumn
    {
        /// <summary>
        /// 重写CellTemplate
        /// </summary>
        public override DataGridViewCell CellTemplate
        {
            get
            {
                ///返回自定义的DataGridViewTextBoxCell
                return new MyDataGridViewTextBoxCell();
            }

            set
            {
                base.CellTemplate = value;
            }
        }

    }

    /// <summary>
    /// 重写DataGridViewTextBoxCell
    /// </summary>
    class MyDataGridViewTextBoxCell : DataGridViewTextBoxCell
    {
        /// <summary>
        /// 鼠标进入单元格时
        /// </summary>
        /// <param name="rowIndex"></param>
        protected override void OnMouseEnter(int rowIndex)
        {
            //变化成手形
            base.DataGridView.Cursor = Cursors.Hand;
            base.OnMouseEnter(rowIndex);
        }

        /// <summary>
        /// 鼠标离开单元格时
        /// </summary>
        /// <param name="rowIndex"></param>
        protected override void OnMouseLeave(int rowIndex)
        {
            ///鼠标变回默认
            base.DataGridView.Cursor = Cursors.Default;
            base.OnMouseLeave(rowIndex);
        }
    }

   class MyButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            pevent.Graphics.DrawRectangle(Pens.Black, 0, 0, this.Width, this.Height);
        }
    }
}
