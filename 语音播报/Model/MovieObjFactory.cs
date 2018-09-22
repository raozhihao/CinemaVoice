using IMovieShowList;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace 语音播报.Model
{
    /// <summary>
    /// 对象工厂
    /// </summary>
    internal class MovieObjFactory
    {
        /// <summary>
        /// 获取api对象
        /// </summary>
        /// <returns></returns>
        internal static IMovieShowList.IMovieShowList GetMovieObj()
        {
            return GetObj<IMovieShowList.IMovieShowList>("MovieList");
        }

        /// <summary>
        /// 获取名称搜索的对象
        /// </summary>
        /// <returns></returns>
        internal static IGetMovieName GetSearchObj()
        {
            return GetObj<IMovieShowList.IGetMovieName>("Search");
        }
        /// <summary>
        /// 获得对应的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        internal static T GetObj<T>(string key)
        {
            //得到程序集路径
            string objSource = System.Configuration.ConfigurationManager.AppSettings[key];
            string lib = objSource.Split(',')[0];
            string obj = objSource.Split(',')[1];
            //利用反射得到对象
            try
            {
                Assembly ass = Assembly.Load(lib);
                //创建对象
                T movieObj = (T)ass.CreateInstance(obj, true);
                return movieObj;
            }
            catch (Exception)
            {

                MessageBox.Show("请正确配置API源");
                return default(T);
                
            }
           
           

            
        }
    }
}
