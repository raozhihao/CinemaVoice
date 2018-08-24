using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtimeShowList
{
    public class Movies
    {
        //"movieId": 240425,
        //    "movieTitleCn": "红海行动",
        //    "movieTitleEn": "Operation Red Sea",
        //    "coverSrc": "http://img5.mtime.cn/mt/2018/02/17/150049.57218452_182X243X4.jpg",
        //    "bigRating": 8,
        //    "smallRating": 2,
        //    "trailerId": 69484,
        //    "director": "林超贤",
        //    "actor": "张译",
        //    "actor2": "黄景瑜",
        //    "runtime": "138分钟",
        //    "property": "动作/剧情",
        //    "viewProperty": "动作/剧情",
        //    "movieDetailUrl": "http://movie.mtime.com/240425/",
        //    "year": "2018"
        /// <summary>
        /// 电影id
        /// </summary>
        public int movieId { get; set; }
        /// <summary>
        /// 电影中文名称
        /// </summary>
        public string movieTitleCn { get; set; }
        /// <summary>
        /// 电影英文名称
        /// </summary>
        public string movieTitleEn { get; set; }
        /// <summary>
        /// 电影小海报url地址
        /// </summary>
        public string coverSrc { get; set; }
        /// <summary>
        /// 评分
        /// </summary>
        public int bigRating { get; set; }
        /// <summary>
        /// 最低评分
        /// </summary>
        public int smallRating { get; set; }
        /// <summary>
        /// 预告片ID
        /// </summary>
        public int trailerId { get; set; }
        /// <summary>
        /// 导演
        /// </summary>
        public string director { get; set; }
        /// <summary>
        /// 编剧1
        /// </summary>
        public string actor { get; set; }
        /// <summary>
        /// 编剧2
        /// </summary>
        public string actor2 { get; set; }
        /// <summary>
        /// 电影时长
        /// </summary>
        public string runtime { get; set; }
        /// <summary>
        /// 电影类型
        /// </summary>
        public string property { get; set; }
        /// <summary>
        /// 电影类型
        /// </summary>
        public string viewProperty { get; set; }
        /// <summary>
        /// 电影详细信息url
        /// </summary>
        public string movieDetailUrl { get; set; }
        /// <summary>
        /// 上映年份
        /// </summary>
        public string year { get; set; }
    }
}
