using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 语音播报.Model
{
    /// <summary>
    /// 详细设置信息
    /// </summary>
    internal class SetT
    {
        /// <summary>
        /// 语速
        /// </summary>
        public int Rate { get; set; }

        /// <summary>
        /// 音量
        /// </summary>
        public int Vol { get; set; }

        /// <summary>
        /// 次数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 提前时间
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// 播音者,0-4
        /// </summary>

        public int Per { get; set; }
        /// <summary>
        /// 音调
        /// </summary>
        public int Pit { get; set; }


        /// <summary>
        /// 提前播报时间
        /// </summary>
        public int Min { get; set; }
    }
}
