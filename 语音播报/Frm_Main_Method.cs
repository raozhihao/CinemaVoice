using IMovieShowList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using 语音播报.Model;

namespace 语音播报
{
    partial class Frm_Main
    {


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
        /// 初始化表格和数据源
        /// </summary>
        private void Inits()
        {
            InitDataGridView();
            InitDataSource();
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
            //对表做一些微处理
            dataGridView1.Columns[0].MinimumWidth = 100;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                    Point loc = btnResert.Location;
                    //btnResert.Enabled = false;
                    panelLeft.Controls.Remove(btnResert);
                    btnOut.Location = loc;
                }
                //是Excel源,读取Excel的信息
                ExcelSource ex = new ExcelSource();
                list = ex.GetList4Excel(File.ReadAllText(SetPath.LastSet).Split('|')[1]).OrderBy(m => m.BeginTime).ToList();
            }
            else
            {
                //是api源,获取影片排片表
                List<IMovieShowList.MovieShow> listMovies = MovieObjFactory.GetMovieObj().GetMovieList(DateTime.Now.ToString("yyyyMMdd"));

                //转换排片表
                list = Common.ParseList (listMovies);
            }

            //开始异步下载
            Task.Factory.StartNew(ListLoad, list, cts.Token);
            //启动定时器3
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
                    UpdateEnd = true;
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
        private bool ClearVoice()
        {


            if (PlayState)
            {
                MessageBox.Show("请稍候,正在播报中...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (!Directory.Exists(SetPath.vPath))
            {
                return false;
            }
            DirectoryInfo dir = new DirectoryInfo(SetPath.vPath);
            FileInfo[] fis = dir.GetFiles("*.mp3", SearchOption.TopDirectoryOnly);
            if (DeleteFiles(fis))
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        private bool DeleteFiles(FileInfo[] fis)
        {
            bool ok = true;
            foreach (var item in fis)
            {
                try
                {
                    item.Delete();
                }
                catch
                {
                    ok = false;
                    break;
                }

            }
            return ok;
        }


        /// <summary>
        /// 开始播放
        /// </summary>
        private void StartPlay(string cellTime)
        {

            //直接读取本地文件
            string fileName = cellTime.Replace(":", "") + ".mp3";
            if (File.Exists(SetPath.voicePath + fileName))
            {
                player.URL = SetPath.voicePath + fileName;
                player.Ctlcontrols.play();
                //播放状态
                PlayState = true;
            }

        }



        /// <summary>
        /// 停止播报
        /// </summary>
        private void StopPlay()
        {
            if (player.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                player.Ctlcontrols.stop();
                PlayState = false;
            }

        }

        /// <summary>
        /// 重新下载文件
        /// </summary>
        private void ResetDownLoadVoice()
        {

            if (ClearVoice())
            {
                Task.Factory.StartNew(DownLoadVoice, blList.ToList());
            }

        }

        /// <summary>
        /// 写入log
        /// </summary>
        /// <param name="msg"></param>
        private void WriteLog(string msg)
        {
            using (FileStream fs = new FileStream("log.log", FileMode.Append, FileAccess.Write))
            {
                byte[] bus = Encoding.UTF8.GetBytes(msg);
                fs.Write(bus, 0, bus.Length);
            }
        }

        private static object objLock = new object();
        /// <summary>
        /// 下载语音文件
        /// </summary>
        /// <param name="obj"></param>
        private void DownLoadVoice(object obj)
        {
            lock (objLock)
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
                // WriteLog($"{DateTime.Now.ToShortTimeString()}==> 准备开始下载" + Environment.NewLine);


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
                        Invoke(new Action(() =>
                        {
                            
                        }));

                    }


                }

                //下载完成了,查看有没有下载失败的项
                if (erroList.Count > 0)
                {
                    ResertUpdateEnd = 1;
                    DownLoadVoice(erroList);
                }
                else
                {
                    //下载全部完成
                    ResertUpdateEnd = 3;
                }
            }

        }

    }
}
