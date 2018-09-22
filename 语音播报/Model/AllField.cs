namespace 语音播报.Model
{
    /// <summary>
    /// 储存所有需要动态使用的公共字段
    /// </summary>
    internal class AllField
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
