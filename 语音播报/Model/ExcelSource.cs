using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Collections.Generic;
using System.IO;

namespace 语音播报.Model
{
    class ExcelSource
    {
        public List<IMovieShowList.MovieShow> GetList4Excel(string fileName)
        {
            List<IMovieShowList.MovieShow> list = new List<IMovieShowList.MovieShow>();
            string filePath =File.ReadAllText("Setting/lastSet.txt");
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
                    if (row.GetCell(0) == null)
                    {
                        break;
                    }
                    Cell c1 = row.GetCell(0);

                    Cell c2 = row.GetCell(1);
                    Cell c3 = row.GetCell(2);

                    list.Add(new IMovieShowList.MovieShow()
                    {
                        Room = c1.StringCellValue,
                        BeginTime = c2.StringCellValue,
                        Name = c3.StringCellValue
                    });
                    rowIndex++;
                }
            }

            return list;
        }
    }
}
