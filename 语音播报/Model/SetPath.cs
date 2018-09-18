using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 语音播报.Model
{
    /// <summary>
    /// 配置信息存放路径
    /// </summary>
    class SetPath
    {
        /// <summary>
        /// 配置主文件夹
        /// </summary>
        internal const string basePath = @"Setting\";

        /// <summary>
        /// 格式化文本信息存放子路径
        /// </summary>
        private const string fomartPath = "fomart.txt";

        /// <summary>
        /// 详细设置存放子路径
        /// </summary>
        private const string setTPath = "set.json";

        /// <summary>
        /// 打开影片排片应用程序的子路径
        /// </summary>
        private const string CinPath = "path.txt";

        /// <summary>
        /// 语音文件目录
        /// </summary>
        public const string vPath = @"Voice\";

        /// <summary>
        /// 时间文件子路径
        /// </summary>
        private const string timePath = "time.json";

        /// <summary>
        /// 源设置子路径
        /// </summary>
        private const string lastSet = "lastSet.txt";

        /// <summary>
        /// 更新说明文件子路径
        /// </summary>
        private const string updateTxt = "update.txt";


        private const string elseSet = "elseSet.json";
        /// <summary>
        /// 更新说明文件路径
        /// </summary>
        internal static string Update { get { return updateTxt; } }

        /// <summary>
        /// 源设置路径
        /// </summary>

        internal static string LastSet { get { return basePath + lastSet; } }
        /// <summary>
        /// 格式化文本存放路径
        /// </summary>
        internal static string FomartPath { get { return basePath + fomartPath; } }

        /// <summary>
        /// 详细设置存放路径
        /// </summary>
        internal static string SetTPath { get { return basePath + setTPath; } }

        /// <summary>
        /// 打开影片排片应用程序的存放路径
        /// </summary>
        internal static string FilePath { get { return basePath + CinPath; } }

        /// <summary>
        /// 声音文件路径
        /// </summary>
        internal static string voicePath { get { return vPath; } }
        /// <summary>
        /// 时间设置路径
        /// </summary>
        internal static string TimeJosnPath { get { return basePath + timePath; } }

        /// <summary>
        /// 其它设置的存放路径
        /// </summary>
        internal static string ElseSetPath { get { return basePath + elseSet; } }
    }
}
