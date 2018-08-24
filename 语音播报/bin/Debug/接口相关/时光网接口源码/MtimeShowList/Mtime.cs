using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMovieShowList;

namespace MtimeShowList
{
    public class Mtime : IMovieShowList.IMovieShowList
    {
       
        public List<IMovieShowList.MovieShow> GetMovieList(string dateTime)
        {
            ///主url
            string baseUrl = "http://service.theater.mtime.com";

            //参数url
            string dataUrl = string.Format("Cinema.api?Ajax_CallBack=true&Ajax_CallBackType=Mtime.Cinema.Services&Ajax_CallBackMethod=GetShowtimesJsonObjectByCinemaId&Ajax_CrossDomain=1&Ajax_RequestUrl=http://theater.mtime.com/China_Hubei_Province_Xianning_ChongYangXian/8430/?d={0}&Ajax_CallBackArgument0=8430&Ajax_CallBackArgument1={0}", dateTime);

            
            GetMitmeInfo get = new MtimeShowList.GetMitmeInfo(baseUrl, dataUrl);

            //返回数据列表
            return get.GetMoiveInfo(dateTime);
        }
    }
}
