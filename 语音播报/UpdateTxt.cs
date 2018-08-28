using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 语音播报.Model;

namespace 语音播报
{
    public partial class UpdateTxt : Form
    {
        public UpdateTxt()
        {
            InitializeComponent();
        }

        private void UpdateTxt_Load(object sender, EventArgs e)
        {
            //查询有无更新文件
           if(File.Exists(SetPath.Update))
            {
                this.richTextBox1.Text = File.ReadAllText(SetPath.Update);
            }
        }
    }
}
