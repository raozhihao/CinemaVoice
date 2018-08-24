
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MtimeShowList
{
    /// <summary>
    /// 获得电影的信息
    /// </summary>
    public class GetMitmeInfo
    {
        /// <summary>
        /// url host
        /// </summary>
        private string baseUrl;

        /// <summary>
        /// data url
        /// </summary>
        private string dataUrl;

        /// <summary>
        /// 创建保存获取到的json数据
        /// </summary>
        private string dataJson;

        /// <summary>
        /// 创建序列化对象
        /// </summary>
        JavaScriptSerializer jss = new JavaScriptSerializer();

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="bUrl">基础url</param>
        /// <param name="dUrl">包含发送数据的url</param>
        public GetMitmeInfo(string bUrl, string dUrl)
        {
            //赋值
            this.baseUrl = bUrl;
            this.dataUrl = dUrl;
            //获取信息
            //Http ht = new Http(baseUrl);
            IMovieShowList.Http ht =new IMovieShowList.Http(baseUrl);
            string get = ht.Get(dataUrl);

            //---对返回的字符串进行一些处理,主要是new Data()无法转成json
            Match m = Regex.Match(get, "{.+}");
            string d = m.Value;
            string s = Regex.Replace(d, "\"date\".+?\".+?\".+?,", "");
            //处理"realtime": new Date("March, 4 2018 14:00:00"),里面的new Date
            //string s = "new Date(\"March, 4 2018 14:00:00\")";
            //处理日期项
            string o = Regex.Replace(s, "new Date(.+?)", "$1", RegexOptions.IgnoreCase).Replace("(", "").Replace(")", "");
            string y = o; //Regex.Replace(s, "\"realtime\".+?\".+?\".+?,", "");
            //--处理完成--
            dataJson = y;
        }


        /// <summary>
        /// 得到影片放映列表
        /// </summary>
        /// <returns></returns>
        private List<Movies> GetMoviesList()
        {
            Match l = Regex.Match(dataJson, "\"movies\":(.+),\"showtimes");
            string s = l.Groups[1].Value;
            List<Movies> list = jss.Deserialize<List<Movies>>(s);
            return list;
        }

        /// <summary>
        /// 得到播放列表
        /// </summary>
        /// <returns></returns>
        private List<ShowTimes> GetShowTimesList()
        {
            //\"showtimes\":.+,\"totalMovieCount
            Match l = Regex.Match(dataJson, "\"showtimes\":(.+),\"totalMovieCount");
            string s = l.Groups[1].Value;
            List<ShowTimes> list = jss.Deserialize<List<ShowTimes>>(s);
            return list;
        }

        /// <summary>
        /// 获得排片信息
        /// </summary>
        /// <returns></returns>
        public List<IMovieShowList.MovieShow> GetMoiveInfo(string date)
        {
            List<IMovieShowList.MovieShow> listMovieShow = new List<IMovieShowList.MovieShow>();
          
            //先获得电影列表
            List<Movies> listMovies = GetMoviesList();
            //查找当前日期下的影片
            List<ShowTimes> listShowTimes = GetShowTimesList();
            foreach (Movies m in listMovies)
            {
                int movieId = m.movieId;
                //根据id去查找影片
                List<ShowTimes> showIDs = listShowTimes.FindAll(x => { return x.movieId == movieId; });
                foreach (ShowTimes item in showIDs)
                {
                    IMovieShowList.MovieShow show = new IMovieShowList.MovieShow();
                    show.Name = m.movieTitleCn;
                    show.Room = item.hallName;
                    show.Version = item.version == "2D" ? "" : "3D";
                    show.Language = item.language == "" ? "" : (item.language == "中文版" ? "" : item.language[0].ToString());
                    show.Data = date;
                    //将时间单独提取出来
                    string time = Regex.Match(item.realtime, "\\d{2}:\\d{2}").Value;
                    show.BeginTime = time;
                   
                    show.EndTime = item.movieEndTime;
                    listMovieShow.Add(show);
                }

            }
            return listMovieShow;
        }
    }
}
