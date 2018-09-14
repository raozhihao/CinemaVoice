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
        /// <summary>
        /// 更改格式化信息时
        /// </summary>
        public event Action FomartChanged;
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

        /// <summary>
        /// 测试按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
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
