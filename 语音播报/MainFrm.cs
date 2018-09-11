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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using 语音播报.Model;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Page;

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
                ResetDownLoadVoice();
            };

            f.FomartChanged += () =>
            {
                fmTxt = FomartTxt();
                ResetDownLoadVoice();
            };
            f.WindowState = FormWindowState.Normal;
            f.Focus();
            f.Show();
        }

        private void ResetDownLoadVoice()
        {
            ClearVoice();
            Task.Factory.StartNew(DownLoadVoice, blList.ToList());
        }

        private void DownLoadVoice(object obj)
        {

            List<IMovieShowList.MovieShow> list = obj as List<IMovieShowList.MovieShow>;
            //存储下载失败的项
            List<IMovieShowList.MovieShow> erroList = new List<IMovieShowList.MovieShow>();
            //得到配置文件信息
            var spd = setJson.Rate;//npSpd.Value;
            var vol = setJson.Vol;//npVol.Value;
            var per = setJson.Per; //npPer.Value;
            var pit = setJson.Pit;//npPit.Value;

            var option = new Dictionary<string, object>()
            {
                {"spd",spd },// 语速
                {"vol",vol },// 音量
                {"per",per },// 发音人，4：情感度丫丫童声
                {"pit",pit }
            };

            // 设置APPID/AK/SK
            // var APP_ID = "11339468"; //"你的 App ID";
            var API_KEY = System.Configuration.ConfigurationManager.AppSettings["API_KEY"]; //"你的 Api Key";
            var SECRET_KEY = System.Configuration.ConfigurationManager.AppSettings["SECRET_KEY"];  //"你的 Secret Key";

            var client = new Baidu.Aip.Speech.Tts(API_KEY, SECRET_KEY);
            client.Timeout = 3000;

            string fomartStr = File.ReadAllText(SetPath.FomartPath);
            foreach (IMovieShowList.MovieShow movie in list)
            {
                if (!Directory.Exists(SetPath.voicePath))
                {
                    Directory.CreateDirectory(SetPath.voicePath);
                }

                if (cts.IsCancellationRequested)
                {

                    return;
                }
                string fileName = SetPath.voicePath + movie.BeginTime.Replace(":", "") + ".mp3";
                //下载每一个文件对应的语音包
                //得到配置文件下的格式信息
                string text = ParseText(fomartStr, movie);

                try
                {

                    var result = client.Synthesis(text, option);

                    if (result.Success)  // 或 result.code==0
                    {
                        File.WriteAllBytes(fileName, result.Data);
                    }
                    else
                    {
                        //没有下载成功
                        Invoke(new Action(() =>
                        {
                            erroList.Add(movie);
                        }));
                    }

                }
                catch
                {
                    //出现异常没有下载成功
                    try
                    {
                        Invoke(new Action(() =>
                        {
                            erroList.Add(movie);
                        }));
                    }
                    catch
                    {
                    }

                }
            }
            //下载完成了,查看有没有下载失败的项
            if (erroList.Count > 0)
            {
                DownLoadVoice(erroList);
            }

        }

        /// <summary>
        /// 用以标志下载的时候的取消信息
        /// </summary>
        private CancellationTokenSource cts = new CancellationTokenSource();
        /// <summary>
        /// 窗体初次启动时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrm_Load(object sender, EventArgs e)
        {
            Inits();

            //设置滚动条的属性
            //从配置文件中读取配置
            player.settings.volume = GetSet().PlayVol;
            hScrollBar1.Value = GetSet().PlayVol;
           

            timer3.Enabled = true;
        }

        private void Inits()
        {
            InitDataGridView();
            InitDataSource();
        }

        /// <summary>
        /// 初始化数据信息
        /// </summary>
        private void InitDataSource()
        {
            //创建存储变量
            List<IMovieShowList.MovieShow> list = new List<MovieShow>();
            //判断登陆设置窗体传过来的是Excel源还是Api源
            if (Chose)
            {
                if (Chose)
                {
                    tsmUpload.Enabled = false;
                }
                //是Excel源,读取Excel的信息
                ExcelSource ex = new ExcelSource();
                list = ex.GetList4Excel(File.ReadAllText(SetPath.LastSet).Split('|')[1]).OrderBy(m => m.BeginTime).ToList();
            }
            else
            {
                //是api源,获取影片排片表
                List<IMovieShowList.MovieShow> listMovies = MovieObjFactory.GetMovieObj().GetMovieList(DateTime.Now.ToString("yyyyMMdd"));
                //处理一些厅的信息
                foreach (IMovieShowList.MovieShow movie in listMovies)
                {
                    if (Regex.Match(movie.Room, @"^\d\D$").Success)
                    {

                        movie.Room = movie.Room[0] + "号" + movie.Room[1];

                    }
                }
                //排序排片表
                list = listMovies.OrderBy(m => m.BeginTime).ToList();
            }

            //开始异步下载
            Task.Factory.StartNew(ListLoad, list, cts.Token);
            //启动定时器3
        }

        /// <summary>
        /// 初始化DGV的一些东西
        /// </summary>
        private void InitDataGridView()
        {
            //取消自动设置列功能
            dataGridView1.AutoGenerateColumns = false;
            //添加播放按钮
            MyDataGridViewTextBoxColumn btnStart = new MyDataGridViewTextBoxColumn();
            btnStart.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            btnStart.SortMode = DataGridViewColumnSortMode.NotSortable;

            btnStart.Name = "btnStart";
            btnStart.HeaderText = "操作";
            btnStart.DefaultCellStyle.NullValue = playName;
            btnStart.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(btnStart);

            //添加停止按钮
            MyDataGridViewTextBoxColumn btnStop = new MyDataGridViewTextBoxColumn();
            btnStop.Name = "btnStop";
            btnStop.HeaderText = "操作";
            btnStop.DefaultCellStyle.NullValue = stopName;
            btnStop.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Add(btnStop);

            ////绑定排片表
            dataGridView1.DataSource = blList;
        }

        /// <summary>
        /// 下载语音包
        /// </summary>
        /// <param name="obj"></param>
        private void ListLoad(object obj)
        {
            //下载之前,清除已有
            ClearVoice();
            List<IMovieShowList.MovieShow> list = obj as List<IMovieShowList.MovieShow>;
            UpdateLoad(list);
        }


        /// <summary>
        /// 下载语音信息包
        /// </summary>
        /// <param name="list"></param>
        private void UpdateLoad(List<MovieShow> list)
        {
            //存储下载失败的项
            List<IMovieShowList.MovieShow> erroList = new List<IMovieShowList.MovieShow>();


            //得到配置文件信息
            var spd = GetSet().Rate;//npSpd.Value;
            var vol = GetSet().Vol;//npVol.Value;
            var per = GetSet().Per; //npPer.Value;
            var pit = GetSet().Pit;//npPit.Value;

            var option = new Dictionary<string, object>()
            {
                {"spd",spd },// 语速
                {"vol",vol },// 音量
                {"per",per },// 发音人，4：情感度丫丫童声
                {"pit",pit }
            };

            // 设置APPID/AK/SK
            // var APP_ID = "11339468"; //"你的 App ID";
            var API_KEY = System.Configuration.ConfigurationManager.AppSettings["API_KEY"]; //"你的 Api Key";
            var SECRET_KEY = System.Configuration.ConfigurationManager.AppSettings["SECRET_KEY"];  //"你的 Secret Key";

            var client = new Baidu.Aip.Speech.Tts(API_KEY, SECRET_KEY);
            client.Timeout = 3000;

            string fomartStr = File.ReadAllText(SetPath.FomartPath);
            foreach (IMovieShowList.MovieShow movie in list)
            {
                if (!Directory.Exists(SetPath.voicePath))
                {
                    Directory.CreateDirectory(SetPath.voicePath);
                }

                if (cts.IsCancellationRequested)
                {

                    return;
                }
                string fileName = SetPath.voicePath + movie.BeginTime.Replace(":", "") + ".mp3";
                //下载每一个文件对应的语音包
                //得到配置文件下的格式信息
                string text = ParseText(fomartStr, movie);

                try
                {

                    var result = client.Synthesis(text, option);
                    Invoke(new Action(() =>
                    {
                        Text = $"正在下载:{movie.Name}";
                    }));
                    if (result.Success)  // 或 result.code==0
                    {
                        File.WriteAllBytes(fileName, result.Data);
                        Invoke(new Action(() =>
                        {
                            blList.Add(movie);
                        }));

                        Invoke(new Action(() =>
                        {
                            Text = $"下载:{movie.Name}成功";
                        }));
                    }
                    else
                    {
                        //没有下载成功
                        Invoke(new Action(() =>
                        {
                            erroList.Add(movie);
                        }));
                    }

                }
                catch
                {
                    //出现异常没有下载成功
                    try
                    {
                        Invoke(new Action(() =>
                        {
                            this.Text = $"下载:{movie.Name}失败";
                            erroList.Add(movie);
                        }));
                    }
                    catch
                    {
                    }

                }
            }

            //下载完成了,查看有没有下载失败的项
            if (erroList.Count > 0)
            {
                UpdateLoad(erroList);
            }
            else
            {
                Invoke(new Action(() =>
                {
                    Text = "影院语音播报";
                }));
                //排下序
                Invoke(new Action(() =>
                {
                    blList.OrderByDescending(m => m.BeginTime);
                }));
            }
        }

        /// <summary>
        /// 将占位符替换
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string ParseText(string text, IMovieShowList.MovieShow movie)
        {
            //欢迎光临，$hallName,$movieName,$beginTime的电影已经开始了
            if (text.Contains("$HallName"))
            {
                text = text.Replace("$HallName", movie.Room);
            }
            if (text.Contains("$MovieName"))
            {
                text = text.Replace("$MovieName", movie.Name);
            }
            if (text.Contains("$BeginTime"))
            {
                text = text.Replace("$BeginTime", movie.BeginTime);
            }
            return text;
        }

        /// <summary>
        /// 清除所有已存在的信息
        /// </summary>
        private void ClearVoice()
        {
            if (!Directory.Exists(SetPath.vPath))
            {
                return;
            }
            try
            {
                DirectoryInfo dir = new DirectoryInfo(SetPath.vPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        /// <summary>
        /// 单元格在双击时候发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                StartPlay(time);
                //读取文件夹里的文件读取
                //PalyVoiceOffline(movie);


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
            

            if (player.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                if (count <= setJson.Count)
                {
                    player.URL = VoiceFileName; //VoiceFileName;
                    player.Ctlcontrols.play();
                    count++;
                }
                else
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
            //保存滚动条的值
            //将配置信息写入文件中
            //获得各项数据
            SetT setInfo = GetSet();
            setInfo.PlayVol = hScrollBar1.Value;
            
            string json = js.Serialize(setInfo);

            File.WriteAllText(SetPath.SetTPath, json);
            Application.Exit();
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
        private void StartPlay(string cellTime)
        {

            //直接读取本地文件
            string fileName = cellTime.Replace(":", "") + ".mp3";
            if (File.Exists(SetPath.voicePath + fileName))
            {
                player.URL = SetPath.voicePath + fileName;
                player.Ctlcontrols.play();
            }

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

        private void 重新登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }



        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            player.settings.volume = hScrollBar1.Value;
        }
    }
}
