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
using System.Threading.Tasks;
using System.Windows.Forms;
using 语音播报.Model;

namespace 语音播报
{
    public partial class NewLogin : Form
    {
        public NewLogin()
        {
            InitializeComponent();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("你确定要退出吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void picMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"在本软件中使用过程中遇到的任何问题,请联系:{Environment.NewLine}389598161@qq.com", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void NewLogin_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panelLeft.CreateGraphics();
            int bottom = label1.Location.Y + label1.Height + 20;
            g.DrawLine(Pens.WhiteSmoke, 10, bottom, panelLeft.Width - 10, bottom);
        }

        /// <summary>
        /// 存储选定的是Api还是Excel
        /// true为Excel,false为api
        /// </summary>
        private bool Chose;
        private void btnPlayList_Click(object sender, EventArgs e)
        {
            panelApi.Visible = true;
            panelExcel.Visible = false;
            Chose = false;
            ShowBtn(btnPlayList);
        }

        /// <summary>
        /// 更改各按钮的颜色
        /// </summary>
        /// <param name="cto"></param>
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

            cto.BackColor = Color.FromArgb(255, 255, 255);
            cto.ForeColor = Color.Black;
            cto.FlatAppearance.BorderColor = Color.White;
            cto.FlatAppearance.MouseOverBackColor = Color.White;
        }

        private void HiddenControls()
        {
            foreach (Control item in panelMain.Controls)
            {
                item.Visible = false;
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            panelApi.Visible = false;
            panelExcel.Visible = true;
            Chose = true;
            ShowBtn(btnSet);
        }

        private void NewLogin_Load(object sender, EventArgs e)
        {
            MoveForm mt = new Model.MoveForm(panelTitle, this);
            MoveForm ml = new Model.MoveForm(panelLeft, this);
            btnPlayList_Click(null, null);
        }

        /// <summary>
        /// 存储打开的Excel文件名
        /// </summary>
        private string fileExcel;
        private void btnExcel_Click(object sender, EventArgs e)
        {
            OpenFile("excel|*.xls", txtExcel);
        }

        /// <summary>
        /// 打开Excel文件
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="txtBox"></param>
        private void OpenFile(string filter, RichTextBox txtBox)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = filter;
            ofd.ShowDialog();
            fileExcel = ofd.FileName;
            txtBox.Text = ofd.FileName;
        }

        private void btnEn_Click(object sender, EventArgs e)
        {
            string check = "0";
            string checkFileName = string.Empty;
            if (Chose)
            {
                check = "0";
                //判断有无文件
                if (!File.Exists(txtExcel.Text))
                {
                    MessageBox.Show("请选择正确的Excel文件导入");
                    txtExcel.Text = string.Empty;
                    return;
                }
                checkFileName = txtExcel.Text;

                //是Excel源,读取Excel的信息
                //在这里做个检测
                ExcelSource ex = new ExcelSource();
                string msg = string.Empty;
                List<IMovieShowList.MovieShow> list = new List<MovieShow>();
                //获取一下信息
                list = ex.GetList4Excel(txtExcel.Text);
                if (!ex.isOk)
                {
                    //判断里面有无错误
                    MessageBox.Show(ex.Msg);
                    return;
                }
                ShowFrmMain(check, checkFileName);
               
            }
        }

        private void btnAPIEnter_Click(object sender, EventArgs e)
        {
            //判断是否在目录下有api
            string apiName = System.Configuration.ConfigurationManager.AppSettings["apiPath"];
            if (File.Exists(apiName))
            {
               
                string check = "1";
               string checkFileName = apiName;
              

                ShowFrmMain(check,checkFileName);
            }
            else
            {
                MessageBox.Show("API不存在或配置错误");
                return;
            }
        }

        /// <summary>
        /// 显示主窗体,并向配置中写入一些信息
        /// </summary>
        /// <param name="check"></param>
        /// <param name="checkFileName"></param>
        private void ShowFrmMain(string check,string checkFileName)
        {
            //写入
            File.WriteAllText(SetPath.LastSet, string.Format("{0}|{1}", check, checkFileName));

            this.Hide();

            Frm_Main main = new Frm_Main(Chose);
            main.ShowLogin += () =>
            {
                this.Show();
            };
            main.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //首先查看目前点击的是哪种源
            if (Chose)
            {
                //点击的是excel源
                if (!File.Exists(txtExcel.Text))
                {
                    MessageBox.Show("未选中Excel源或Excel源未导入");
                    return;
                }
                else
                {
                    //写入
                    File.WriteAllText(SetPath.LastSet, string.Format("0|{0}", txtExcel.Text));
                }
            }
            else
            {
                //使用的api源
                if (MovieObjFactory.GetMovieObj() == null)
                {
                    return;
                }
            }



            Frm_MovieListGet mg = new 语音播报.Frm_MovieListGet(Chose);
            mg.ShowSome += () =>
            {
                mg.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            };
            mg.Show();
        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {
            NewLogin_Paint(null, null);
        }

        private void btnShowExcelStyle_Click(object sender, EventArgs e)
        {
            ShowExcelStyle show = new ShowExcelStyle();
            show.ShowDialog();
        }
    }
}
