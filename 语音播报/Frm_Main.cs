using IMovieShowList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using 语音播报.Model;

namespace 语音播报
{
    public partial class Frm_Main : Form
    {
        public Frm_Main(bool chose)
        {
            this.Chose = chose;
            InitializeComponent();
        }
       
        private  void Frm_Main_Load(object sender, EventArgs e)
        {
            MoveForm mt = new Model.MoveForm(panelTitle, this);
            MoveForm ml = new Model.MoveForm(panelLeft, this);

            set = new NewSet(); //(NewSet)ShowForm(new NewSet(), panelMain);
            set.SetChanged += Set_SetChanged;
            set.ResertLoad += Set_ResertLoad;
            set.LoadUpdateEnd += Set_LoadUpdateEnd;
            set.GetPlayState += Set_GetPlayState;
            //set.Show();
            frm_MovieList = new Frm_MovieListGet(Chose);
            //设置滚动条的属性
            //从配置文件中读取配置
            setJson = GetSet();
            player.settings.volume = setJson.PlayVol;
            scroll.Value = setJson.PlayVol;
           
            lbVol.Text = scroll.Value.ToString();
            //scroll.ValueChanged += S_ValueChanged;
            //panelLeft.Controls.Add(scroll);

            //让第一个按钮反色
            //btnPlayList.BackColor = Color.White;
            //btnPlayList.ForeColor = Color.Black;
            //第一个按钮的事件启动
            btnPlayList_Click(null, null);
            Inits();

            
            timer3.Enabled = true;

            
            AllField.PlayCount = GetSet().Count;
            AllField.AdvanceTime = GetSet().Time;
        }

        /// <summary>
        /// 滚动条的值发生改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void S_ValueChanged(object sender, EventArgs e)
        {
            SundayRXScrollBar s = sender as SundayRXScrollBar;
            lbVol.Text = s.Value.ToString();
        }

        /// <summary>
        /// 窗体重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_Main_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panelLeft.CreateGraphics();
            int bottom = label1.Location.Y + label1.Height + 20;
            g.DrawLine(Pens.WhiteSmoke, 10, bottom, panelLeft.Width-10, bottom);
            
        }

        private void button2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.Black, 0, 0, this.Width, this.Height);
        }

        /// <summary>
        /// 关闭按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要退出吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }
        /// <summary>
        /// 放大按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState== FormWindowState.Maximized)
            {
                //如果当前是最大化,点击的时候应该回复
                this.WindowState = FormWindowState.Normal;
               // picMax.BackgroundImage = Image.FromFile("pic\\最大化.png");
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
               // picMax.BackgroundImage = Image.FromFile("pic\\回复.png");

            }
            
        }
        /// <summary>
        /// 标题栏鼠标双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //让窗口最大化
            picMax_Click(null, null);
        }
        /// <summary>
        /// 最小化按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// 左边栏重绘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {
            //画一条小白线
            Frm_Main_Paint(null, null);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex > this.dataGridView1.Rows.Count)
            {
                //没有点击在表格内
                return;
            }
            ////拿到当前点击的行,并转换成集合对象
            //DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            //IMovieShowList.MovieShow movieInfo = row.DataBoundItem as IMovieShowList.MovieShow;
            //拿到当前点击的单元格
            var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //获取当前点击单元格的行的开场时间
            string timeCell = dataGridView1.Rows[cell.RowIndex].Cells[1].Value.ToString();
            //获取当前单元格上的文本值
            string cellText = cell.FormattedValue.ToString();
            switch (cellText)
            {
                case playName:
                    //双击了播放按钮
                    StartPlay(timeCell);
                    break;
                case stopName:
                    //双击了停止按钮
                    StopPlay();
                    break;
                default:
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (player.playState == WMPLib.WMPPlayState.wmppsStopped || player.playState == WMPLib.WMPPlayState.wmppsUndefined || player.playState == WMPLib.WMPPlayState.wmppsReady)
            {
                PlayState = false;
            }

            //获得当前时间往后推10分钟

            //使用  HH:mm 进行格式化
            // string now = DateTime.Now.AddMinutes(setJson.Time).ToString("HH:mm");
            string now = DateTime.Now.AddMinutes(AllField.AdvanceTime).ToString("HH:mm");


            //获取数据
            List<IMovieShowList.MovieShow> list = new List<MovieShow>(blList);

            //查看是否有当前需要播报的

            IMovieShowList.MovieShow movie = list.SingleOrDefault(x => x.BeginTime == now);

            if (movie != null)
            {
                //将本计时器暂停
                timer1.Enabled = false;


                //获取模板信息
                string text = fmTxt;

                CellTime = movie.BeginTime;

               // StartPlay(time);
                //读取文件夹里的文件读取
               // PalyVoiceOffline(movie);


                //将计时器2启动起来
                timer2.Enabled = true;

            }
        }
       

        private void timer2_Tick(object sender, EventArgs e)
        {

            if (player.playState == WMPLib.WMPPlayState.wmppsStopped||player.playState== WMPLib.WMPPlayState.wmppsUndefined||player.playState== WMPLib.WMPPlayState.wmppsReady)
            {
               
                if (count <= AllField.PlayCount)
                {
                   //开始播放
                    StartPlay(CellTime);
                    count++;
                   
                }
                else
                {
                    player.Ctlcontrols.stop();
                    PlayState = false;
                    //检查现在时间是否已经过了播报时间了
                    //得到当前的播放列表
                    List<IMovieShowList.MovieShow> list = new List<MovieShow>(blList);
                    //获取当前时间加10分钟
                    //string nowTime = DateTime.Now.AddMinutes(setJson.Time).ToString("HH:mm");
                    string nowTime = DateTime.Now.AddMinutes(AllField.AdvanceTime).ToString("HH:mm");


                    //查看是否有当前需要播报的
                    //查看当前的时间中是否有需要播报的
                    IMovieShowList.MovieShow movie = list.SingleOrDefault(x => x.BeginTime == nowTime);


                    //因为现在正在播报当前的,而且已经播报完了指定的次数
                    //所以当前的不用播报了
                    if (movie == null)
                    {
                        
                        //让计时器1启动
                        timer1.Enabled = true;
                        //回复计数
                        count = 1;
                        //让计时器2停止
                        timer2.Enabled = false;

                    }
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (player.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                player.close();

            }
            //清除掉数据
            // 获取数据
            List<IMovieShowList.MovieShow> list = new List<MovieShow>(blList);
            //查看当前的时间比对
            DateTime now = DateTime.Now;
            //得到当前时间的整数
            int hour = now.Hour;
            int min = now.Minute;
            int nowNum = hour * 100 + min;
            //当前等候删除的集合中的数据,应先拿出来与当前时间对比,如果大于10分钟以上就予以删除
            //遍历当前数据集合
            for (int i = 0; i < blList.Count; i++)
            {
                //得到当前的数据的时间
                string[] times = blList[i].BeginTime.Split(':');
                int h, m;
                try
                {
                    h = Convert.ToInt32(times[0]);
                    m = Convert.ToInt32(times[1]);
                    int num = h * 100 + m;
                    //如果超时10分钟及以上,则删除当条信息
                    if (nowNum - num > 10)
                    {
                        blList.Remove(blList[i]);

                    }
                }
                catch
                {

                    blList.Remove(blList[i]);
                }

            }
        }
       
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            this.Visible = true;
            SwitchToThisWindow(this.Handle, true);
            //显示主界面
            this.WindowState = FormWindowState.Normal;
            //this.Select();
            //this.Focus();
        }

        private void tmMain_Click(object sender, EventArgs e)
        {
            //显示主界面
            this.WindowState = FormWindowState.Maximized;
            this.Visible = true;
            SwitchToThisWindow(this.Handle, true);
        }


        private void tmExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要退出吗?","提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        
        private void btnList_Click(object sender, EventArgs e)
        {

            ShowForm(frm_MovieList, panelMain);


            ShowBtn(btnList);
        }

        /// <summary>
        /// 隐藏右边主窗口的所有控件
        /// </summary>
        private void HiddenControls()
        {
            foreach (Control item in panelMain.Controls)
            {
                item.Visible = false;
            }
        }

        private void btnPlayList_Click(object sender, EventArgs e)
        {
            HiddenControls();
            dataGridView1.Visible = true;

            ShowBtn(btnPlayList);

        }
       

        private void ShowBtn(Button cto)
        {
            foreach (Control c in panelLeft.Controls)
            {
                //将所有的颜色变回来
                if (c is Button)
                {
                    Button btn = c as Button;
                    btn.BackColor =  Color.Black;
                    btn.ForeColor =  Color.White;
                    btn.FlatAppearance.BorderColor = Color.Black;
                    btn.FlatAppearance.MouseOverBackColor = Color.Black;
                }
            }

            cto.BackColor = Color.FromArgb(255,255,255);
            cto.ForeColor = Color.Black;
            cto.FlatAppearance.BorderColor = Color.White;
            cto.FlatAppearance.MouseOverBackColor = Color.White;
        }

        private void panelMain_Resize(object sender, EventArgs e)
        {
            foreach (Control item in panelMain.Controls)
            {
                if (item is Form)
                {
                    Form f = item as Form;
                    if (f.Parent == panelMain)
                    {
                        //找到当前的子窗体,让其填充panel
                        f.Dock = DockStyle.Fill;
                    }
                }
            }
        }
       
        private void btnSet_Click(object sender, EventArgs e)
        {
            //NewSet set = (NewSet)ShowForm(new NewSet(), panelMain);
           
            ShowForm(set,panelMain);
            
            ShowBtn(btnSet);
        }

       
        private void Set_SetChanged()
        {
           // 重新读取配置文件
                setJson = GetSet();
            //获取模板信息
            fmTxt = File.ReadAllText(SetPath.FomartPath);
            ResetDownLoadVoice();
        }

        /// <summary>
        /// 是否重新下载完成的通知
        /// </summary>
        /// <returns></returns>
        private int Set_ResertLoad()
        {
            return ResertUpdateEnd;
        }
        /// <summary>
        /// 是否下载完成的通知
        /// </summary>
        /// <returns></returns>
        private bool Set_LoadUpdateEnd()
        {
            return UpdateEnd;
        }
        /// <summary>
        /// 获取当前播放器是否正在播放中
        /// </summary>
        /// <returns></returns>
        private bool Set_GetPlayState()
        {
            return this.PlayState;
        }

        private Form ShowForm(Form frm,Control parent)
        {
            HiddenControls();
            frm.TopLevel = false;
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            parent.Controls.Add(frm);
            frm.Visible = true;
           // frm.Show();
            return frm;
        }


       
        private void btnHand_Click(object sender, EventArgs e)
        {
            if (!autoPlay)
            {
                var re = MessageBox.Show("你确定不再自动播放吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (re == DialogResult.Yes)
                {
                    //停止1.2的计时器的活动
                    timer2.Enabled = false;
                    timer2.Stop();
                    timer1.Enabled = false;
                    timer1.Stop();

                    btnHand.Text = "自动播放";
                    autoPlay = true;
                }
            }
            else
            {
                var re = MessageBox.Show("你确定自动播放吗?", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (re == DialogResult.Yes)
                {
                    //停止1.2的计时器的活动
                    timer1.Enabled = true;
                    timer1.Start();
                    timer2.Enabled = true;
                    timer2.Start();
                    btnHand.Text = "设置手动";
                    autoPlay = false;
                }

            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("你确定要重新登陆吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res== DialogResult.Yes)
            {
                
                //这里只保存播放音量,播放次数以及提前时间,其它的设置保存应该在"保存"按钮中保存
                string jsonStr = File.ReadAllText(SetPath.SetTPath);
                SetT sets = js.Deserialize<SetT>(jsonStr);
                sets.Count = AllField.PlayCount;
                sets.Time = AllField.AdvanceTime;
                sets.PlayVol = AllField.PlayVol;
                string json = js.Serialize(sets);
                File.WriteAllText(SetPath.SetTPath, json);

                ShowLogin?.Invoke();
                this.Close();
            }
           
        }

        private void btnResert_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("btnStart");
            dataGridView1.Columns.Remove("btnStop");
            Frm_Main_Load(null, null);
        }

      

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

       

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.White, new Rectangle(0, 0, this.dataGridView1.Width - 1, this.dataGridView1.Height - 1));
        }

        private void picInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"在本软件中使用过程中遇到的任何问题,请联系:{Environment.NewLine}389598161@qq.com", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            pt = new Point(e.X, e.Y);

        }

        private void panelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            //鼠标放开后的位置
            Point pm = new Point(e.X, e.Y);
            if (pm.X-pt.X>Math.Abs(10)||pm.Y-pt.Y>Math.Abs(10))
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
        }

        private void Frm_Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;


            }
            else if(this.WindowState == FormWindowState.Maximized)
            {
                //如果当前是最大化,点击的时候应该回复
                picMax.BackgroundImage = Image.FromFile("pic\\回复.png");
            }
            else
            {
                picMax.BackgroundImage = Image.FromFile("pic\\最大化.png");
            }

          
        }


        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button== MouseButtons.Left)
            {
                notifyIcon1_MouseDoubleClick(sender, null);
            }
        }

        private void panelLeft_Resize(object sender, EventArgs e)
        {
            //让滚动条的长度更改
            scroll.Location = new Point(3, btnPlayList.Location.Y);
            scroll.Height = lbVolInfo.Bottom - btnPlayList.Top;
           
        }

        private void scroll_ValueChanged(object sender, EventArgs e)
        {
            player.settings.volume = scroll.Value;
            lbVol.Text = player.settings.volume.ToString();
            AllField.PlayVol = player.settings.volume;
        }
    }
}
