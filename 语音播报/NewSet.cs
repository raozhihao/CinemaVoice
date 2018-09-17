using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using 语音播报.Model;

namespace 语音播报
{
    public partial class NewSet : Form
    {
        /// <summary>
        /// 当更改配置信息时通知主窗体
        /// </summary>
        public event Action SetChanged;
        public NewSet()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void NewSet_Resize(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private bool play = false;
        /// <summary>
        /// 测试按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (GetPlayState!=null)
            {
                bool playState = GetPlayState();
                if (playState)
                {
                    MessageBox.Show("正在播报中,不能测试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            if (play)
            {
                //点击了停止
                //当前正在播报
                play = false;

                button2.Text = "测试";
                //当前是需要停止
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                axWindowsMediaPlayer1.close();
                if (File.Exists("测试.mp3"))
                {
                    //删除测试
                    File.Delete("测试.mp3");

                }

                return;
            }
            else
            {
                button2.Text = "停止";

                play = true;


            }


            string text = textBox1.Text;

            //测试
            //欢迎光临，$hallName,$movieName,$beginTime的电影已经开始了
            if (text.Contains("$HallName"))
            {
                text = text.Replace("$HallName", "一号厅");
            }
            if (text.Contains("$MovieName"))
            {
                text = text.Replace("$MovieName", "测试影片");
            }
            if (text.Contains("$BeginTime"))
            {
                text = text.Replace("$BeginTime", "12:30");
            }


            BaiduApiUser b = new BaiduApiUser();
            //获得各项数据
            SetT set = new SetT()
            {
                Count = (int)npCount.Value,
                Rate = (int)npSpd.Value,
                Time = (int)npTime.Value,
                Vol = (int)npVol.Value,
                Per = comboBox1.SelectedIndex, //(int)npPer.Value,
                Pit = (int)npPit.Value,
            };

            var spd = set.Rate;//npSpd.Value;
            var vol = set.Vol;//npVol.Value;
            var per = set.Per; //npPer.Value;
            var pit = set.Pit;//npPit.Value;

            var option = new Dictionary<string, object>()
            {
                {"spd",spd },// 语速
                {"vol",vol },// 音量
                {"per",per },// 发音人，4：情感度丫丫童声
                {"pit",pit }
            };
            string path = "测试.mp3";

            bool reslut = b.Send(text, option, path);
            if (reslut)
            {
                axWindowsMediaPlayer1.URL = path;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }

        }

        /// <summary>
        /// 获取主窗体的播放状态
        /// </summary>
        public event Func<bool> GetPlayState;
        /// <summary>
        /// 获取主窗体的下载状态
        /// </summary>
        public event Func<bool> LoadUpdateEnd;
        /// <summary>
        /// 获取主窗体下重新下载的状态
        /// </summary>
        public event Func<bool> ResertLoad;
        private void button3_Click(object sender, EventArgs e)
        {

            if (ResertLoad != null)
            {

                bool resert = ResertLoad();
                if (!resert)
                {
                    MessageBox.Show("正在更新文件中,请稍候重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            if (LoadUpdateEnd!=null)
            {

                bool update = LoadUpdateEnd();
                if (!update)
                {
                    MessageBox.Show("正在下载文件中,请稍候重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            if (GetPlayState != null)
            {
                bool playState = GetPlayState();
                if (playState || axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    //如果主窗口正在播放中,则应该先中止此按钮的功能,并向用户提示
                    MessageBox.Show("正在播放中,请等待播放停止", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);


                    return;
                }
            }
            try
            {
                //如果主窗口正在播放中,则应该先中止此按钮的功能,并向用户提示
                //怎么得到主窗口的状态呢


                //将模板信息写入本地文件中
                string txt = textBox1.Text;
                File.WriteAllText(SetPath.FomartPath, txt);
                // FomartChanged?.Invoke();
                //MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //获得各项数据
                SetT setInfo = new SetT()
                {
                    Count = (int)npCount.Value,
                    Rate = (int)npSpd.Value,
                    Time = (int)npTime.Value,
                    Vol = (int)npVol.Value,
                    Per = comboBox1.SelectedIndex, //(int)npPer.Value,
                    Pit = (int)npPit.Value,
                };


                //序列化
                JavaScriptSerializer js = new JavaScriptSerializer();

                string json = js.Serialize(setInfo);

                File.WriteAllText(SetPath.SetTPath, json);

             
                //修改过后应向主窗体通知
                SetChanged?.Invoke();
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void NewSet_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            axWindowsMediaPlayer1.Visible = false;
            //读取配置文件,如果有的话
            ReadSet();
        }

        /// <summary>
        /// 读取配置文件信息并加载(如果存在)
        /// </summary>
        private void ReadSet()
        {
            //读取格式化信息
            string fpStr = string.Empty;
            try
            {
                fpStr = File.ReadAllText(SetPath.FomartPath);
            }
            catch
            {

            }
            if (!string.IsNullOrEmpty(fpStr))
            {
                //如果存在,则写入
                textBox1.Text = fpStr;
            }

            //读取配置信息
            string setJson = string.Empty;
            try
            {
                setJson = File.ReadAllText(SetPath.SetTPath);
            }
            catch
            {

                throw;
            }

            if (!string.IsNullOrEmpty(setJson))
            {
                System.Web.Script.Serialization.JavaScriptSerializer js = new JavaScriptSerializer();
                SetT sets = js.Deserialize<SetT>(setJson);
                //赋值
                npCount.Value = sets.Count;
                npPit.Value = sets.Pit;
                npSpd.Value = sets.Rate;
                npTime.Value = sets.Time;
                npVol.Value = sets.Vol;
                comboBox1.SelectedIndex = sets.Per;
            }
        }
    }
}
