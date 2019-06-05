using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Collections.Generic;
using System.IO;
using System;

namespace 语音播报.Model
{
    /// <summary>
    /// 对Excel的一些处理
    /// </summary>
    internal class ExcelSource
    {
        /// <summary>
        /// 提供的消息
        /// </summary>
        public string Msg { get; private set; }
        /// <summary>
        /// 是否没有错误
        /// </summary>
        public bool isOk { get; private set; } = true;

        /// <summary>
        /// 根据Excel获取集合信息
        /// </summary>
        /// <param name="fileName">Excel存储路径</param>
        /// <returns></returns>
        public List<IMovieShowList.MovieShow> GetList4Excel(string fileName)
        {
            List<IMovieShowList.MovieShow> list = new List<IMovieShowList.MovieShow>();
            
            HSSFWorkbook wk = null;
            using (FileStream fs = System.IO.File.Open(fileName, FileMode.Open,
            FileAccess.Read, FileShare.ReadWrite))
            {
                //把xls文件读入workbook变量里，之后就可以关闭了
                wk = new HSSFWorkbook(fs);
                fs.Close();
            }
            HSSFSheet sheet = (HSSFSheet)wk.GetSheetAt(0);

            if (sheet != null)
            {
                int rowIndex = 0;
                NPOI.SS.UserModel.Row row = null;
                while ((row = sheet.GetRow(rowIndex)) != null)
                {
                    try
                    {
                        Cell c1 = row.GetCell (0);
                        string room = c1.RichStringCellValue.String;

                        Cell c2 = row.GetCell (1);
                        string tim = c2.RichStringCellValue.String;

                        Cell c3 = row.GetCell (2);
                        string name = c3.RichStringCellValue.String;

                        if ( string.IsNullOrWhiteSpace (room) || string.IsNullOrWhiteSpace (tim) || string.IsNullOrWhiteSpace (name) )
                        {
                            rowIndex++;
                            continue;
                        }

                        string time = ParseBeginTime (tim);

                        list.Add (new IMovieShowList.MovieShow ()
                        {
                            Room = room ,
                            BeginTime = time ,
                            Name = name
                        });
                        rowIndex++;
                    }
                    catch ( Exception ex )
                    {
                        isOk = false;
                        Msg = "xcel文件中的时间有错误,在" + ( rowIndex + 1 ) + "行" + Environment.NewLine + ex.Message;

                        break;

                    }
                }
                sheet.Dispose ();
            }
            
            return list;
        }


        private string ParseBeginTime (string c2)
        {
            string[] sp = c2.ToString ().Split (new char[] { '：' , ':' } , System.StringSplitOptions.RemoveEmptyEntries);
            string h1 = sp[0];
            string h2 = sp[1];
            if ( h1.Length == 1 )
            {
                h1 = "0" + h1;
            }
            if ( h2.Length == 1 )
            {
                h2 = "0" + h2;
            }
            return h1 + ":" + h2;
        }
    }
}
