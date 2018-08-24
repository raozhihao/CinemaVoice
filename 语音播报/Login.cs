using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 语音播报
{
    public partial class Login : Form
    {
        private string fileExcel;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            SetLastChecked();
        }

        /// <summary>
        /// 读取设置上次的设置
        /// </summary>
        private void SetLastChecked()
        {
            //读取配置文件
            //如果配置文件存在
            if (File.Exists("Setting/lastSet.txt"))
            {
                //读取配置文件
                string setStr = File.ReadAllText("Setting/lastSet.txt");
                if (!string.IsNullOrEmpty(setStr))
                {
                    //如果有,则将设置放上去
                    string[] strs = setStr.Split('|');
                    if (strs[0] == "0" && strs[1] != "")
                    {
                        rdExcel.Checked = true;
                        txtExcel.Text = strs[1];
                    }
                    else
                    {
                        rdAPI.Checked = true;

                    }

                }
            }

        }

        /// <summary>
        /// 打开Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {

            OpenFile("excel|*.xls", txtExcel);
        }

        private void rdExcel_CheckedChanged(object sender, EventArgs e)
        {
            //改变选择的时候,对应的按钮也改变
            btnExcel.Enabled = rdExcel.Checked;

        }



        private void OpenFile(string filter, TextBox txtBox)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filter;
            ofd.ShowDialog();
            fileExcel = ofd.FileName;
            txtBox.Text = ofd.FileName;
        }

        /// <summary>
        /// 确认按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEn_Click(object sender, EventArgs e)
        {
            string check = "0";
            string checkFileName = string.Empty;
            //如果没有,则让用户设置将设置保存
            //找出当前被选中的选择
            if (rdExcel.Checked)
            {
                check = "0";
                checkFileName = txtExcel.Text;

            }
            else
            {
                //判断是否在目录下有api
                string apiName = System.Configuration.ConfigurationManager.AppSettings["apiPath"];
                if (File.Exists(apiName))
                {
                    check = "1";
                    checkFileName = apiName;
                }
                else
                {
                    MessageBox.Show("不存在");
                }
            }

            //写入
            File.WriteAllText("Setting/lastSet.txt", string.Format("{0}|{1}", check, checkFileName));

            //打开主窗体
            MainFrm mf = new MainFrm(rdExcel.Checked);
            mf.Show();
            this.Hide();
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //waveOut.Dispose();
        }


    }
}
