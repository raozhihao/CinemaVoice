using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 语音播报.Model
{
    internal class BaiduApiUser
    {

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
