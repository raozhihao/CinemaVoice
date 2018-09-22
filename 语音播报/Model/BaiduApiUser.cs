using System.Collections.Generic;

namespace 语音播报.Model
{
    /// <summary>
    /// 百度语音API
    /// </summary>
    internal class BaiduApiUser
    {
        /// <summary>
        /// 发送语音信息并将合成后的语音文件存储到指定位置
        /// </summary>
        /// <param name="text">文本信息</param>
        /// <param name="option">配置信息</param>
        /// <param name="fileName">存储路径</param>
        /// <returns></returns>
        internal bool Send(string text, Dictionary<string, object> option, string fileName)
        {
            // 设置APPID/AK/SK
            //var APP_ID = "11339468"; //"你的 App ID";
            var API_KEY = System.Configuration.ConfigurationManager.AppSettings["API_KEY"];//"你的 Api Key";
            var SECRET_KEY = System.Configuration.ConfigurationManager.AppSettings["SECRET_KEY"]; //"你的 Secret Key";

            var client = new Baidu.Aip.Speech.Tts(API_KEY, SECRET_KEY);


            var result = client.Synthesis(text, option);

            if (result.ErrorCode == 0)  // 或 result.Success
            {

               System.IO.File.WriteAllBytes(fileName, result.Data);

                return true;
            }
            return false;
        }
    }
}
