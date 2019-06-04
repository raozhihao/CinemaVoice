using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMovieShowList;

namespace SimpleDemo
{
    /// <summary>
    /// 一个简单的Demo，必须引用相应的dll文件，并且实现这个接口的方法
    /// </summary>
    public class Simple : IMovieShowList.IMovieShowList
    {
        /// <summary>
        /// 接口方法
        /// </summary>
        /// <param name="dateTime">由客户端传入的时间，其格式为：yyyyMMdd ("20181130")</param>
        /// <returns>返回一个电影信息集合</returns>
        public List<MovieShow> GetMovieList (string dateTime)
        {
            //影片信息集合
            List<IMovieShowList.MovieShow> list = new List<IMovieShowList.MovieShow> ()
            {
                //添加影片信息
                new MovieShow ()
                {
                    BeginTime = "22:00" ,
                    Data = "20181130" ,
                    Language = "中文" ,
                    Name = "无名之辈" ,
                    Room = "3号厅" ,
                    Version = "2D"
                },
                new MovieShow ()
                {
                    BeginTime = "13:20" ,
                    Data = "20181130" ,
                    Language = "印度" ,
                    Name = "老爸102岁" ,
                    Room = "4号厅" ,
                    Version = "2D"
                },
                new MovieShow ()
                {
                    BeginTime = "13:50" ,
                    Data = "20181130" ,
                    Language = "英语" ,
                    Name = "毒液：致命守护者" ,
                    Room = "1号厅" ,
                    Version = "3D"
                },
                new MovieShow ()
                {
                    BeginTime = "14:20" ,
                    Data = "20181130" ,
                    Language = "中文" ,
                    Name = "无名之辈" ,
                    Room = "3号厅" ,
                    Version = "2D"
                },
                new MovieShow ()
                {
                    BeginTime = "13:00" ,
                    Data = "20181201" ,
                    Language = "中文" ,
                    Name = "无名之辈" ,
                    Room = "3号厅" ,
                    Version = "2D"
                },
            };
            //根据请求参数返回对应的信息
            var returnList = list.Where (x => x.Data.Equals (dateTime)).ToList ();
            return returnList;

        }
    }
}
