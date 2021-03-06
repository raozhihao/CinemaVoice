﻿using IMovieShowList;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Web.Script.Serialization;
using 语音播报.Model;

namespace 语音播报
{
    partial class Frm_Main
    {
        /// <summary>
        /// 用来显示登陆窗体
        /// </summary>
        public event Action ShowLogin;

        /// <summary>
        /// 用于定义单元格上的播放按钮文本
        /// </summary>
        private const string playName = "播放";

        /// <summary>
        /// 用于定义单元格上的停止按钮文本
        /// </summary>
        private const string stopName = "停止";

        
        /// <summary>
        /// 序列化对象
        /// </summary>
        JavaScriptSerializer js = new JavaScriptSerializer();

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
        private string CellTime;

        /// <summary>
        /// 用以标志下载的时候的取消信息
        /// </summary>
        private CancellationTokenSource cts = new CancellationTokenSource();

        /// <summary>
        /// 设置子窗口
        /// </summary>
        NewSet set;

        /// <summary>
        /// 排片的子窗口
        /// </summary>
        Frm_MovieListGet frm_MovieList;

        /// <summary>
        /// win32api:用于将窗口置顶
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="fAltTab"></param>
        [DllImport("user32.dll", SetLastError = true)]
        static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        /// <summary>
        /// 是否自动播放
        /// </summary>
        private bool autoPlay = false;

        /// <summary>
        /// 记录座标点
        /// </summary>
        private Point pt;

        /// <summary>
        /// 记录当前播放器的状态
        /// true为正在播放中
        /// </summary>
        public bool PlayState { get; set; }

        /// <summary>
        /// 文件是否下载完成
        /// true为下载完成
        /// </summary>
        private bool UpdateEnd = false;

        /// <summary>
        /// 文件是否重新下载完成
        /// 1=>未下载完成
        /// 2=>无操作
        /// 3=>已下载完成
        /// </summary>
        private int ResertUpdateEnd = 2;
    }
}
