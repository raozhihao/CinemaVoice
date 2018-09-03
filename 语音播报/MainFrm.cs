using IMovieShowList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using 语音播报.Model;

namespace 语音播报
{
    public partial class MainFrm : Form
    {
        /// <summary>
        /// 用于定义单元格上的播放按钮文本
        /// </summary>
        private const string playName = "播放";

        /// <summary>
        /// 用于定义单元格上的停止按钮文本
        /// </summary>
        private const string stopName = "停止";

        /// <summary>
        /// 用于控制单元格内的单次播放与暂停
        /// </summary>
       // private SpeechSynthesizer speechPlay;

        /// <summary>
        /// 用户格式化电影名称
        /// </summary>
        private string movieName;
        /// <summary>
        /// 用户格式化电影放映厅
        /// </summary>
        private string room;
        /// <summary>
        /// 用户格式化电影开场时间
        /// </summary>
        private string time;

        /// <summary>
        /// 序列化对象
        /// </summary>
        System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();

        /// <summary>
        /// 用于向表格绑定数据
        /// </summary>
        private BindingList<IMovieShowList.MovieShow> blList = new BindingList<MovieShow>();

        /// <summary>
        /// 配置对象
        /// </summary>
        private SetT setJson = new SetT();

        /// <summary>
        /// 格式化文本对象
        /// </summary>
        private string fmTxt = string.Empty;

        /// <summary>
        /// 设置播放次数标志符
        /// </summary>
        private int count = 1;

        /// <summary>
        /// 判断当前选择的源是Excel还是dll
        /// </summary>
        private bool Chose;

        /// <summary>
        /// 保存声音文件临时路径
        /// </summary>
        private string VoiceFileName;
        public MainFrm(bool chose)
        {
            InitializeComponent();
            this.Chose = chose;
        }


        /// <summary>
        /// 单击设置按钮时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set f = new 影院语音播报系统.Set();
            Set f = FormFactory<Set>.GetForm();
            f.SetChanged += () =>
            {
                //重新读取配置文件
                setJson = GetSet();
            };

            f.FomartChanged += () =>
            {
                fmTxt = FomartTxt();
            };
            f.WindowState = FormWindowState.Normal;
            f.Focus();
            f.Show();
        }



        /// <summary>
        /// 窗体初次启动时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrm_Load(object sender, EventArgs e)
        {

            //取消自动设置列功能
            dataGridView1.AutoGenerateColumns = false;


            //判断登陆设置窗体传过来的是Excel源还是Api源
            if (Chose)
            {
                if (Chose)
                {
                    tsmUpload.Enabled = false;
                }
                //是Excel源,读取Excel的信息
                ExcelSource ex = new ExcelSource();
                List<IMovieShowList.MovieShow> list = ex.GetList4Excel(File.ReadAllText("Setting/lastSet.txt").Split('|')[1]);
                blList = new BindingList<MovieShow>(list);
            }
            else
            {
                //获取影片排片表
               // My my = new My();
                List<IMovieShowList.MovieShow> listMovies = MovieObjFactory.GetMovieObj().GetMovieList(DateTime.Now.ToString("yyyyMMdd"));

                foreach (IMovieShowList.MovieShow movie in listMovies)
                {
                    if (Regex.Match(movie.Room, @"^\d\D$").Success)
                    {

                        movie.Room = movie.Room[0] + "号" + movie.Room[1];

                    }
                }
                //排序排片表
                var oderyList = listMovies.OrderBy(m => m.BeginTime).ToList();
                //数据赋值
                blList = new BindingList<MovieShow>(oderyList);
            }




            //绑定排片表
            dataGridView1.DataSource = blList; //listMovies.OrderBy(m => m.BeginTime).Where(m => m.Data == "20180602").ToList();

            //添加播放按钮
            DataGridViewButtonColumn btnStart = new DataGridViewButtonColumn();
            btnStart.Name = "btnStart";
            btnStart.HeaderText = "操作";
            btnStart.DefaultCellStyle.NullValue = playName;
            dataGridView1.Columns.Add(btnStart);

            //添加停止按钮
            DataGridViewButtonColumn btnStop = new DataGridViewButtonColumn();
            btnStop.Name = "btnStop";
            btnStop.HeaderText = "操作";
            btnStop.DefaultCellStyle.NullValue = stopName;
            dataGridView1.Columns.Add(btnStop);


            //启动时获取配置信息
            setJson = GetSet();
            //启动时获取模板信息
            fmTxt = FomartTxt();


            //下载声音文件
            DownLoad load = new DownLoad(blList);
            load.ShowFrom += Load_ShowFrom;
            load.ShowDialog();
            this.Hide();
        }




        /// <summary>
        /// 单元格在双击时候发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //拿到当前点击的行,并转换成集合对象
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            IMovieShowList.MovieShow movieInfo = row.DataBoundItem as IMovieShowList.MovieShow;
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
                    StartPlay(movieInfo, timeCell);
                    break;
                case stopName:
                    //双击了停止按钮
                    StopPlay();
                    break;
                default:
                    break;
            }
        }



        /// <summary>
        /// 计时1的启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {

            //获得当前时间往后推10分钟

            //使用  HH:mm 进行格式化
            string now = DateTime.Now.AddMinutes(setJson.Time).ToString("HH:mm");


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

                movieName = movie.Name;
                room = movie.Room;
                time = movie.BeginTime;


                //读取文件夹里的文件读取
                PalyVoiceOffline(movie);


                //将计时器2启动起来
                timer2.Enabled = true;

            }
        }


       
        /// <summary>
        /// 计时2启动,主要用于对计时器1的语音播报的次数的判断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (player.playState== WMPLib.WMPPlayState.wmppsStopped&& count <= setJson.Count - 1)
            {

                player.URL = VoiceFileName; //VoiceFileName;
                player.Ctlcontrols.play();
                count++;
            }
            if (player.playState == WMPLib.WMPPlayState.wmppsStopped && count > setJson.Count - 1)
            {
                player.Ctlcontrols.stop();
                //检查现在时间是否已经过了播报时间了
                //得到当前的播放列表
                List<IMovieShowList.MovieShow> list = new List<MovieShow>(blList);
                //获取当前时间加10分钟
                string nowTime = DateTime.Now.AddMinutes(setJson.Time).ToString("HH:mm");


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


        /// <summary>
        /// 计时器3的启动,主要用于删除过期数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_Tick(object sender, EventArgs e)
        {

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
                int h = Convert.ToInt32(times[0]);
                int m = Convert.ToInt32(times[1]);
                int num = h * 100 + m;
                //如果超时10分钟及以上,则删除当条信息
                if (nowNum - num > 10)
                {
                    blList.Remove(blList[i]);

                }
            }
        }
        private bool autoPlay = false;
        private void 设置全部手动播放ToolStripMenuItem_Click(object sender, EventArgs e)
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

                    设置全部手动播放ToolStripMenuItem.Text = "重新自动播放";
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
                    设置全部手动播放ToolStripMenuItem.Text = "设置全部手动播放";
                    autoPlay = false;
                }

            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //显示主界面
            this.WindowState = FormWindowState.Maximized;
            this.Visible = true;
            this.Focus();
        }

        private void tmMain_Click(object sender, EventArgs e)
        {
            //显示主界面
            this.WindowState = FormWindowState.Maximized;
            this.Visible = true;
            this.Focus();
        }

        private void tmSet_Click(object sender, EventArgs e)
        {
            设置ToolStripMenuItem_Click(sender, e);
        }

        private void tmExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainFrm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;

            }
            else
            {
                this.Visible = true;
            }
        }


        private void 重新获取当日排片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Remove("btnStart");
            dataGridView1.Columns.Remove("btnStop");
            MainFrm_Load(null, null);
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Load_ShowFrom()
        {
            this.Invoke(new Action(() =>
            {
                this.Show();
            }));
        }

        /// <summary>
        /// 停止播报
        /// </summary>
        private void StopPlay()
        {
            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                player.Ctlcontrols.stop();
            }

        }

        /// <summary>
        /// 获取模板信息
        /// </summary>
        /// <returns></returns>
        private string FomartTxt()
        {
            //获取模板信息
            return File.ReadAllText(SetPath.FomartPath);
        }




        /// <summary>
        /// 开始播放
        /// </summary>
        /// <param name="movieInfo"></param>
        private void StartPlay(MovieShow movieInfo, string cellTime)
        {

            //SetT set = GetSet();
            //获得当前时间
            string dt = DateTime.Now.ToString("t");


            string text = fmTxt;

            //赋值
            movieName = movieInfo.Name;
            room = movieInfo.Room;
            time = movieInfo.BeginTime;
            //格式化
            text = ParseText(text);

            Play(setJson, text, cellTime);

        }

        /// <summary>
        /// 加载配置信息
        /// </summary>
        /// <returns></returns>
        private SetT GetSet()
        {
            try
            {
                //加载配置信息
                string json = File.ReadAllText(SetPath.SetTPath);
                return js.Deserialize<SetT>(json);
            }
            catch
            {

                MessageBox.Show("请先设置相关信息,如无设置,则会选取默认信息");
                return new SetT() { Count = 3, Rate = 2, Time = 10, Vol = 100 };
            }

        }

        /// <summary>
        /// 将占位符替换
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string ParseText(string text)
        {
            //欢迎光临，$hallName,$movieName,$beginTime的电影已经开始了
            if (text.Contains("$HallName"))
            {
                text = text.Replace("$HallName", room);
            }
            if (text.Contains("$MovieName"))
            {
                text = text.Replace("$MovieName", movieName);
            }
            if (text.Contains("$BeginTime"))
            {
                text = text.Replace("$BeginTime", time);
            }
            return text;
        }

        /// <summary>
        /// 播放离线文件
        /// </summary>
        /// <param name="movie"></param>
        private void PalyVoiceOffline(IMovieShowList.MovieShow movie)
        {

            string voiceName = movie.BeginTime.Replace(":", "") + ".mp3";
            VoiceFileName = SetPath.voicePath + voiceName;
            player.URL = VoiceFileName;//VoiceFileName;
            player.Ctlcontrols.play();


        }


        private void Play(SetT set, string str, string cellTime)
        {

            //BaiduApiUser b = new BaiduApiUser();

            //var spd = set.Rate;//npSpd.Value;
            //var vol = set.Vol;//npVol.Value;
            //var per = set.Per; //npPer.Value;
            //var pit = set.Pit;//npPit.Value;

            //var option = new Dictionary<string, object>()
            //{
            //    {"spd",spd },// 语速
            //    {"vol",vol },// 音量
            //    {"per",per },// 发音人，4：情感度丫丫童声
            //    {"pit",pit }
            //};
            //string path = "合成的语音文件本地存储地址.mp3";
            //bool reslut = b.Send(str, option, path);
            //if (reslut)
            //{
            //    player.URL = path;
            //    player.Ctlcontrols.play();
            //}
            //直接读取本地文件

            string fileName = cellTime.Replace(":", "") + ".mp3";
            if (File.Exists(SetPath.voicePath + fileName))
            {
                player.URL = SetPath.voicePath + fileName;
                player.Ctlcontrols.play();
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About box = new 语音播报.About();
            box.ShowDialog();
        }

        private void 时间转换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_MovieListGet mov = new 语音播报.Frm_MovieListGet(Chose);
            mov.ShowDialog();
        }

        private void 更新说明ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTxt u = new 语音播报.UpdateTxt();
            u.ShowDialog();
        }
    }
}
