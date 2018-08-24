using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MtimeShowList
{
    /// <summary>
    /// 影片排片信息映射实体类
    /// </summary>
    public class ShowTimes
    {
        //"id": 1775232453,
        //    "showtimeId": 319173146,
        //    "movieId": 228764,
        //    "realtime": new Date("March, 4 2018 13:15:00"),
        //    "specialVersion": "",
        //    "version": "2D",
        //    "language": "",
        //    "movieEndTime": "预计15:35散场",
        //    "hallId": 34076,
        //    "hallName": "3号厅",
        //    "seatCount": 90,
        //    "isSale": false,
        //    "price": "40",
        //    "servicePrice": 0,
        //    "mtimePrice": 20,
        //    "seatUrl": "#",
        //    "isContinueShowtime": false,
        //    "continueMovies": [],
        //    "isMorrowShowtime": false,
        //    "specialTitle": ""

        public int id { get; set; }
        
        public int showtimeId { get; set; }

        /// <summary>
        /// 电影id
        /// </summary>
        public int movieId { get; set; }

        /// <summary>
        /// 开场时间
        /// </summary>
        public string realtime { get; set; }
        public string specialVersion { get; set; }

        /// <summary>
        /// 格式
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public string language { get; set; }
        /// <summary>
        /// 预计放完时间
        /// </summary>
        public string movieEndTime { get; set; }
        /// <summary>
        /// 影厅id
        /// </summary>
        public int hallId { get; set; }
        /// <summary>
        /// 影厅名称
        /// </summary>
        public string hallName { get; set; }
        public int seatCount { get; set; }
        /// <summary>
        /// 是否已售
        /// </summary>
        public bool isSale { get; set; }
        public string price { get; set; }
        public int servicePrice { get; set; }
        public int mtimePrice { get; set; }
        public string seatUrl { get; set; }
        public bool isContinueShowtime { get; set; }
        public object continueMovies { get; set; }
        public bool isMorrowShowtime { get; set; }
        public string specialTitle { get; set; }
    }
}
