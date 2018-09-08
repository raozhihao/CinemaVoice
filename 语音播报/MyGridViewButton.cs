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
    class MyDataGridViewTextBox : DataGridViewTextBoxColumn
    {
        public override DataGridViewCell CellTemplate
        {
            get
            {
                
                return new MyDataGridViewCell();
            }

            set
            {
                base.CellTemplate = value;
            }
        }

    }
    class MyDataGridViewCell: DataGridViewTextBoxCell
    {
        protected override void OnMouseEnter(int rowIndex)
        {
            base.DataGridView.Cursor = Cursors.Hand;
            base.OnMouseEnter(rowIndex);
        }

        protected override void OnMouseLeave(int rowIndex)
        {
            base.DataGridView.Cursor = Cursors.Default;
            base.OnMouseLeave(rowIndex);
        }
    }


}
