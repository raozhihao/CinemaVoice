using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using 语音播报;
using 语音播报.Model;

namespace 影院语音播报
{
    public partial class SetMovieEndTime : Form
    {
        public SetMovieEndTime()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 创建序列化对象
        /// </summary>
        JavaScriptSerializer jss = new JavaScriptSerializer();

        /// <summary>
        /// 创建存储放映时间的json数据的文件存放地址
        /// </summary>
        private string infoName = SetPath.TimeJosnPath;
        
        /// <summary>
        /// 窗体启动时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetMovieEndTime_Load(object sender, EventArgs e)
        {
            dataGridView2.AutoGenerateColumns = false;

            //添加按钮
            MyDataGridViewTextBoxColumn txtUpdate = new MyDataGridViewTextBoxColumn();
           
            txtUpdate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtUpdate.SortMode = DataGridViewColumnSortMode.NotSortable;
            txtUpdate.ReadOnly = true;
            txtUpdate.Name = "btnStart";
            txtUpdate.HeaderText = "操作";
            txtUpdate.DefaultCellStyle.NullValue = "更新";
            txtUpdate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //添加按钮
            MyDataGridViewTextBoxColumn txtDel = new MyDataGridViewTextBoxColumn();

            txtDel.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDel.SortMode = DataGridViewColumnSortMode.NotSortable;
            txtDel.ReadOnly = true;
            txtDel.Name = "btnStart";
            txtDel.HeaderText = "操作";
            txtDel.DefaultCellStyle.NullValue = "删除";
            txtDel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            dataGridView2.Columns.Add(txtUpdate);
            dataGridView2.Columns.Add(txtDel);
            initTable();
            txtName.Select();
           
        }
//        需要修改两个属性
//1修改ColumnHeadersHeader 设置为你想要的高度，比如20；但这时候自动变回来。
//2修改ColumnHeadersHeaderSize属性为 EnableResizing，不要为AutoSize。
//行高的设置:
//RowTemplate属性下的Height 属性。
        private void initTable()
        {
            List<SetTime> list = new List<SetTime>();
            if (!File.Exists(infoName))
            {
                //如果不存在,则创建
                //  File.Create("time.txt");
                using (FileStream file = new FileStream(infoName, FileMode.Create))
                {

                }
            }
            else
            {
                //存在,则读取
                string info = File.ReadAllText(infoName);
                list = jss.Deserialize<List<SetTime>>(info);
                blist = new BindingList<SetTime>(list);
                dataGridView2.DataSource = blist;
            }
        }

        BindingList<SetTime> blist = new BindingList<SetTime>();
       

       
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="list"></param>
        private void SaveJson(List<SetTime> list)
        {
            //保存
            string info = jss.Serialize(list);
            File.WriteAllText(infoName, info);
        }

        

        public event Action Changed;
        private void SetMovieEndTime_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭之后刷新
            Changed?.Invoke();
        }

      

        /// <summary>
        /// 重写键盘按下事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //如果按下的是tab键
            if (keyData == Keys.Tab)
            {
                //如果当前下拉框没有显示
                if (listBox1.Visible)
                {
                    listBox1.Visible = false;
                    //listBox1.ClearSelected();
                    txtName.Focus();
                    return true;
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData== Keys.Enter)
            {
                HideListBox();

            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            HideListBox();
        }

        private void HideListBox()
        {
            
            txtName.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
            txtTime.Focus();
        }

      

        private void listBox1_Leave(object sender, EventArgs e)
        {
            if (!txtName.Focused)
            {
                listBox1.Visible = false;
            }
        }

       

        private void dataGridView2_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {


            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;//离开时恢复默认
            }
        }

        /// <summary>
        /// 记录右键点击的行坐标
        /// </summary>
        int selectRowIndex;

       

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCell(selectRowIndex,0);
        }

       

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellTxt = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();
            switch (cellTxt)
            {
                case "更新":
                    EditCell(e.RowIndex, 1);
                    break;
                case "删除":
                    DelRow(e.RowIndex);
                    break;
                default:
                    break;
            }
        }

        private void DelRow(int rowIndex)
        {
            List<SetTime> list = new List<SetTime>((BindingList<SetTime>)this.dataGridView2.DataSource);
            //找到当前的影片
            SetTime movie = dataGridView2.Rows[rowIndex].DataBoundItem as SetTime;

            if (movie != null)
            {
                //如果在,则提示用户是否覆盖
                DialogResult re = MessageBox.Show($"你确定要删除{Environment.NewLine+ movie.MovieName+Environment.NewLine}吗,数据删除后不可恢复","警告", MessageBoxButtons.OKCancel);
                if (re == DialogResult.OK)
                {

                    blist.Remove(movie);
                }
                else
                {
                    return;
                }
            }
        }

        private void EditCell(int rowIndex,int colIndex)
        {
            dataGridView2.CurrentCell = dataGridView2.Rows[rowIndex].Cells[colIndex];
            dataGridView2.BeginEdit(true);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelRow(selectRowIndex);
        }

        private void SetMovieEndTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            //保存数据
            List<SetTime> list = new List<SetTime>((BindingList<SetTime>)this.dataGridView2.DataSource);
            SaveJson(list);
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string time = txtTime.Text.Trim();

            if (string.IsNullOrEmpty(name)||string.IsNullOrEmpty(time))
            {
                MessageBox.Show("请填写完整影片名称与放映时长", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            time = time.Contains("：") ? time.Replace("：", ":") : time;
            List<SetTime> list = new List<SetTime>((BindingList<SetTime>)this.dataGridView2.DataSource);
            //判断当前加入的电影是否已在列表中
            SetTime s = list?.Find(x => x.MovieName == name);

            if (s != null)
            {
                //如果在,则提示用户是否覆盖
                DialogResult re = MessageBox.Show("您即将添加的电影"+Environment.NewLine+"《" + name + "》\r\n已在列表中,请问要覆盖吗?", "已存在", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (re == DialogResult.OK)
                {

                    //用户要覆盖,则将其本身存在去除掉
                    int index = blist.IndexOf(s);
                    s.MovieTime = time;
                    blist.Remove(s);
                    blist.Insert(index, s);
                }
                else
                {
                    return;
                }
            }
            else
            {
                //不存在,则添加
                blist.Add(new SetTime() { MovieName = name, MovieTime = time });
            }

            txtName.Focus();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                listBox1.SelectedIndex = 0;
                listBox1.Focus();
            }
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
            {
                listBox1.Visible = false;
                //listBox1.ClearSelected();
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (!listBox1.Focused)
            {
                listBox1.Visible = false;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ////获取要搜索的字符串
            string word = txtName.Text.Trim();
            try
            {
                var list = MovieObjFactory.GetSearchObj().GetMovieNameList(word);

                listBox1.Items.Clear();
                listBox1.Visible = true;
                //listBox1.Location = new System.Drawing.Point(toolStripLabel1.Width + toolStripSeparator1.Width, toolStrip1.Height);
                list.ForEach(a =>
                {
                    listBox1.Items.Add(a.titlecn);
                });
            }
            catch
            {

            }
        }

        private void txtTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                Addbtn_Click(null, null);
            }
        }
    }
}
