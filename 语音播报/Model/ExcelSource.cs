using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Collections.Generic;
using System.IO;

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

            //Row r = sheet1.GetRow(0);
            if (sheet != null)
            {


                int rowIndex = 0;
                NPOI.SS.UserModel.Row row = null;
                while ((row = sheet.GetRow(rowIndex)) != null)
                {
                    try
                    {
                        if (row.GetCell(0) == null)
                        {
                            break;
                        }
                        Cell c1 = row.GetCell(0);

                        Cell c2 = row.GetCell(1);

                        Cell c3 = row.GetCell(2);


                        list.Add(new IMovieShowList.MovieShow()
                        {
                            Room = c1.ToString(),
                            BeginTime = c2.ToString(),
                            Name = c3.ToString()
                        });

                        string[] sp = c2.ToString().Split(':');
                        
                    }
                    catch 
                    {
                        isOk = false;

                        Msg = "Excel文件中的时间有错误,在第" + rowIndex+1 + "行";
                        rowIndex++;
                        break;

                    }
                    rowIndex++;
                }
            }
            
            return list;
        }

       
    }
}
