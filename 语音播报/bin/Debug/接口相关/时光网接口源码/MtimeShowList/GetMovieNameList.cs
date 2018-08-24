using IMovieShowList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MtimeShowList
{
   
    public class GetMovieNameList : IGetMovieName
    {
        /// <summary>
        /// 创建序列化对象
        /// </summary>
        JavaScriptSerializer jss = new JavaScriptSerializer();
        List<SearchMovies> IGetMovieName.GetMovieNameList(string movieName)
        {
            
            //创建实例
            Http http = new Http("http://service-channel.mtime.com");
            //获取结果
            string s = http.Get($"Search.api?Ajax_CallBack=true&Ajax_CallBackType=Mtime.Channel.Services&Ajax_CallBackArgument0={movieName}&Ajax_CallBackMethod=GetSuggestObjs");

            //将结果匹配正则获得
            string reslut = Regex.Match(s, @"\[.+\]").Value;

            //将结果进行反序列化
            List<SearchMovies> list = jss.Deserialize<List<SearchMovies>>(reslut);
            return list;
        }
    }
}
