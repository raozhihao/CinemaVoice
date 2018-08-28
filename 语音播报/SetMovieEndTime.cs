using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;
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
        /// 修改之前的电影名称
        /// </summary>
        private string oldName;

        /// <summary>
        /// 修改之前的放映时间
        /// </summary>
        private string oldTime;

        /// <summary>
        /// 窗体启动时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetMovieEndTime_Load(object sender, EventArgs e)
        {
            ///禁止dg自动创建列
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView2.RowTemplate.Height = 30;
            InitList();
        }

        /// <summary>
        /// 初始化表格
        /// </summary>
        private void InitList()
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
                dataGridView1.DataSource = list ?? new List<SetTime>();
            }
        }


        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string time = txtTime.Text.Trim();


            time = time.Contains("：") ? time.Replace("：", ":") : time;

            List<SetTime> list = dataGridView1.DataSource as List<SetTime>;

            //判断当前加入的电影是否已在列表中
            SetTime s = list?.Find(x => x.MovieName == name);
            if (s != null)
            {
                //如果在,则提示用户是否覆盖
                DialogResult re = MessageBox.Show("您即将添加的电话" + name + ",已在列表中,请问要覆盖吗?", "已存在", MessageBoxButtons.OKCancel);
                if (re == DialogResult.OK)
                {
                    //用户要覆盖,则将其本身存在去除掉
                    list.Remove(s);
                }
                else
                {
                    return;
                }
            }

            list.Add(new SetTime() { MovieName = name, MovieTime = time });
            SaveJson(list);
            InitList();
        }

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

        /// <summary>
        /// 双击单元格任意部位时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取当前单击的单元格
            if (e.RowIndex < 0)
            {
                return;
            }
            oldName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            oldTime = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = oldName;
            txtTime.Text = oldTime;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.SelectedRows[0];
            if (row == null)
            {
                MessageBox.Show("请选择要修改的数据", "未选定数据");
                return;
            }
            string name = txtName.Text.Trim();
            string time = txtTime.Text.Trim();



            time = time.Contains("：") ? time.Replace("：", ":") : time;
            List<SetTime> list = dataGridView1.DataSource as List<SetTime>;

            DialogResult re = MessageBox.Show("你确定要修改吗?你正在修改的是\r\n" + list[row.Index].MovieName + "\r\n修改后的时间为\r\n:" + time, "请确认", MessageBoxButtons.OKCancel);
            if (re == DialogResult.Cancel)
            {
                return;
            }

            //修改数据
            list[row.Index] = new SetTime() { MovieName = name, MovieTime = time };
            //保存
            SaveJson(list);
            InitList();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.SelectedRows;
            if (row.Count <= 0)
            {
                MessageBox.Show("请选择行");
                return;
            }
            string name = row[0].Cells[0].Value.ToString();
            string time = row[0].Cells[1].Value.ToString();

            List<SetTime> list = dataGridView1.DataSource as List<SetTime>;

            DialogResult re = MessageBox.Show($"你确认要删除: {name} 吗?", "请确认", MessageBoxButtons.OKCancel);
            if (re == DialogResult.Cancel)
            {
                return;
            }

            list.RemoveAt(row[0].Index);
            SaveJson(list);
            InitList();
            MessageBox.Show("删除成功");

        }

        public event Action Changed;
        private void SetMovieEndTime_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭之后刷新
            Changed?.Invoke();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //获取要搜索的字符串
            string word = txtName.Text.Trim();


            #region 通过工厂获得


            dataGridView2.DataSource = MovieObjFactory.GetSearchObj().GetMovieNameList(word);//g.GetSearchList(word);


            #endregion

        }


        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //如果当前没有点击任何单元格
            if (e.RowIndex < 0)
            {
                return;
            }


            //获得现在点击的中文名称
            string set = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            //将中文名称填入
            txtName.Text = set;
            //让中文名称和英文名称这两列自适应宽度
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        private void SetMovieEndTime_Activated(object sender, EventArgs e)
        {
            //使文本框获得焦点
            txtName.Focus();
        }
    }
}
