using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace 语音播报.Model
{
    /// <summary>
    /// 对象工厂
    /// </summary>
    public class MovieObjFactory
    {

        public static IMovieShowList.IMovieShowList GetMovieObj()
        {
            return GetObj<IMovieShowList.IMovieShowList>("MovieList");
        }
       
        
        /// <summary>
        /// 获得对应的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetObj<T>(string key)
        {
            //得到程序集路径
            string objSource = System.Configuration.ConfigurationManager.AppSettings[key];
            string lib = objSource.Split(',')[0];
            string obj = objSource.Split(',')[1];
            //利用反射得到对象
            Assembly ass = Assembly.Load(lib);
            //创建对象
            T movieObj = (T)ass.CreateInstance(obj, true);

            return movieObj;
        }
    }
}
