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
        public int Rate { get; set; } = 5;

        /// <summary>
        /// 音量
        /// </summary>
        public int Vol { get; set; } = 14;

        /// <summary>
        /// 次数
        /// </summary>
        public int Count { get; set; } = 2;

        /// <summary>
        /// 提前时间
        /// </summary>
        public int Time { get; set; } = 10;

        /// <summary>
        /// 播音者,0-4
        /// </summary>

        public int Per { get; set; } = 0;
        /// <summary>
        /// 音调
        /// </summary>
        public int Pit { get; set; } = 5;


        /// <summary>
        /// 提前播报时间
        /// </summary>
        public int Min { get; set; } = 0;

        public int PlayVol { get; set; } = 50;
    }
}
