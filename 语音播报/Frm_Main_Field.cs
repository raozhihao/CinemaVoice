using IMovieShowList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using 语音播报.Model;

namespace 语音播报
{
    partial class Frm_Main
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
        private string VoiceFileName;

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
    }
}
