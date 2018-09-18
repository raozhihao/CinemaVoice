using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 语音播报.Model
{
    public class AllField
    {
        /// <summary>
        /// 播报次数
        /// </summary>
        public static int PlayCount { get; set; } = 1;
        /// <summary>
        /// 提前时间
        /// </summary>
        public static int AdvanceTime { get; set; } = 10;

        /// <summary>
        /// 播放的音量
        /// </summary>
        public static int PlayVol { get; set; } = 50;
    }
}
