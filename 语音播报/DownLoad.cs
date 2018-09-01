using IMovieShowList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using 语音播报.Model;

namespace 语音播报
{
    public partial class DownLoad : Form
    {
        /// <summary>
        /// 显示主窗体事件
        /// </summary>
        public event Action ShowFrom;

        /// <summary>
        /// 用于向表格绑定数据
        /// </summary>
        private BindingList<IMovieShowList.MovieShow> blList = new BindingList<MovieShow>();
        public DownLoad(BindingList<IMovieShowList.MovieShow> list)
        {
            InitializeComponent();
            this.blList = list;
        }

        private void DownLoad_Load(object sender, EventArgs e)
        {
            //下载之前,清除已有
            ClearVoice();
            //模拟下载
            Thread t = new Thread(new ThreadStart(UpdateLoad));
            t.IsBackground = true;
            t.Start();
        }

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

        private void UpdateLoad()
        {
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
            List<IMovieShowList.MovieShow> list = new List<MovieShow>(blList);
            // 设置APPID/AK/SK
            // var APP_ID = "11339468"; //"你的 App ID";
            var API_KEY = System.Configuration.ConfigurationManager.AppSettings["API_KEY"]; //"你的 Api Key";
            var SECRET_KEY = System.Configuration.ConfigurationManager.AppSettings["SECRET_KEY"];  //"你的 Secret Key";

            var client = new Baidu.Aip.Speech.Tts(API_KEY, SECRET_KEY);


            string fomartStr = File.ReadAllText(SetPath.FomartPath);
            foreach (IMovieShowList.MovieShow movie in list)
            {
               if(!Directory.Exists(SetPath.voicePath))
                {
                    Directory.CreateDirectory(SetPath.voicePath);
                }

                
                string fileName = SetPath.voicePath + movie.BeginTime.Replace(":", "") + ".mp3";
                //下载每一个文件对应的语音包
                //得到配置文件下的格式信息
                string text = ParseText(fomartStr, movie);
                try
                {
                    var result = client.Synthesis(text, option);
                    if (result.ErrorCode == 0)  // 或 result.Success
                    {
                        File.WriteAllBytes(fileName, result.Data);
                        listBox1.Invoke(new Action(() =>
                        {
                            listBox1.Items.Add($"正在下载{movie.BeginTime} {movie.Name}");

                        }));
                    }

                }
                catch
                {
                    listBox1.Invoke(new Action(() =>
                    {
                        listBox1.Items.Add($"网络故障,文件:{movie.BeginTime} {movie.Name} 未下载成功");

                    }));

                }
            }

            //下载完了将本窗体关闭
            DialogResult re = MessageBox.Show("已经下载完成了,请确认", "提示", MessageBoxButtons.OK);
            if (re == DialogResult.OK)
            {
                ShowFrom?.Invoke();
                this.Invoke(new Action(() =>
                {
                    this.Close();
                }));

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
                /// <summary>
                /// 序列化对象
                /// </summary>
                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
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

        private void DownLoad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData== Keys.Escape)
            {
                return;
            }
            if (e.KeyData== Keys.Control&&e.KeyData== Keys.F4)
            {
                return;
            }
        }
    }
}
