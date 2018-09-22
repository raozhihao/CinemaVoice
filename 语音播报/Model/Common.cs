using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace 语音播报.Model
{
    /// <summary>
    /// 一些公共的使用方法
    /// </summary>
    internal class Common
    {
        /// <summary>
        /// 格式化处理列表
        /// </summary>
        /// <param name="list">需要进行处理的列表</param>
        /// <returns></returns>
        internal static List<IMovieShowList.MovieShow> ParseList (IList<IMovieShowList.MovieShow> list)
        {
            List<IMovieShowList.MovieShow> resert = new List<IMovieShowList.MovieShow> ();
            foreach ( IMovieShowList.MovieShow movie in list )
            {
                IMovieShowList.MovieShow m = new IMovieShowList.MovieShow ();
                m.BeginTime = movie.BeginTime;
                m.Data = movie.Data;
                m.EndTime = movie.EndTime;
                m.Language = ParseLanguage(movie.Language);
                m.Name = movie.Name;
                //处理厅名
                m.Room =ParseRoom( movie.Room);
                m.Version = ParseVersion (movie.Version);
                resert.Add (m);
            }
            return resert.OrderBy(m=>m.BeginTime).ToList();
        }

        /// <summary>
        /// 格式化处理版本信息
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        private static string ParseVersion (string version)
        {
            if ( string.IsNullOrEmpty (version) )
            {
                return version;
            }
            if ( version.Contains("2") )
            {
                return string.Empty;
            }
            else
            {
                return version;
            }
        }

        /// <summary>
        /// 格式化处理语言信息
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        private static string ParseLanguage (string language)
        {
            if ( string.IsNullOrEmpty (language) )
            {
                return language;
            }
            if ( language.Contains ("国") || language.Contains ("中") )
            {
                return string.Empty;
            }
            else
            {
                return language[0].ToString();
            }
        }

        /// <summary>
        /// 格式化处理厅号信息
        /// </summary>
        /// <param name="room"></param>
        /// <returns></returns>
        private static string ParseRoom (string room)
        {
            if ( string.IsNullOrEmpty(room) )
            {
                return room;
            }
            string newRoom = room;
            Dictionary<string , string> map = new Dictionary<string , string> ()
            {
                {"一","1" },{"二","2" },{"三","3" },{"四","4" },{"五","5" },{"六","6" },{"七","7" },{"八","8" },{"九","9" },{"十","10" },{"十一","11" },
            };

            if ( map.ContainsKey (room[0].ToString ()) )
            {
                //如果厅号的第一个在map中被找到，需要转义
                newRoom = room.Replace (room[0].ToString () , map[room[0].ToString ()]);
            }

            if ( Regex.IsMatch(newRoom, @"^\d\D$") )
            {
                newRoom = newRoom.Insert (1 , "号");
            }

            return newRoom;
           
        }

    }
}
