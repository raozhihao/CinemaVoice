using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace 语音播报.Model
{
    public class MovieEndTime
    {
        /// <summary>
        /// 创建序列化对象
        /// </summary>
        JavaScriptSerializer jss = new JavaScriptSerializer();
        public List<IMovieShowList.MovieShow> GetMovieEndTimeList(List<IMovieShowList.MovieShow> list)
        {
            foreach (IMovieShowList.MovieShow item in list)
            {

                item.EndTime = UpdateTime(item.Name, item.BeginTime);

            }
            return list;
        }

        /// <summary>
        /// 计算影片结束时间
        /// </summary>
        /// <param name="name">影片名称</param>
        /// <param name="startTime">开始时间</param>
        /// <returns></returns>
        private string UpdateTime(string name, string startTime)
        {
            //读取timejson中的数据
            if (!File.Exists(SetPath.TimeJosnPath))
            {
                //如果不存在,则创建
                //  File.Create("time.txt");
                using (FileStream file = new FileStream(SetPath.TimeJosnPath, FileMode.Create))
                {

                }
            }
            string timeJson = File.ReadAllText(SetPath.TimeJosnPath);
            List<SetTime> list = jss.Deserialize<List<SetTime>>(timeJson);

            SetTime se = list?.Find(x => { return x.MovieName == name; });
            if (se == null)
            {
                //如果找不到该影片的话
                //则直接把一个空值传递回去
                return "";
            }
            else
            {
                string time = SetMovieTime(se.MovieTime, startTime);
                return time;
            }

        }

        /// <summary>
        /// 设置时间处理
        /// </summary>
        /// <param name="getTime"></param>
        /// <param name="startTIme"></param>
        /// <returns></returns>
        private string SetMovieTime(string getTime, string startTIme)
        {
            //分割开场时间
            string[] t = startTIme.Split(':');    //12 15
            int sHour = Convert.ToInt32(t[0]);
            int sMnn = Convert.ToInt32(t[1]);
            //分割放映时间
            string[] g = getTime.Split(':');
            int gHour = Convert.ToInt32(g[0]);
            int gMin = Convert.ToInt32(g[1]);

            int hour = sHour + gHour;

            int min = sMnn + gMin;

            hour = (hour + min / 60) % 24;
            min = min % 60;

            string time = string.Format("{0:00}:{1:00}", hour, min);
            return time;
        }
    }
}
