using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using 影院语音播报;
using 语音播报.Model;

namespace 语音播报
{
    public partial class Frm_MovieListGet : Form
    {
        /// <summary>
        /// 源选择
        /// </summary>
        private bool Chose;
        public Frm_MovieListGet(bool chose)
        {
            InitializeComponent();
            this.Chose = chose;
        }


        /// <summary>
        /// 创建工作薄对象
        /// </summary>
        static HSSFWorkbook hssfworkbook;

        /// <summary>
        /// 创建影片排片集合对象,存储从类库中读取到的数据 
        /// </summary>
        List<IMovieShowList.MovieShow> movieList = new List<IMovieShowList.MovieShow>();



        private void 拉取信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //获取当前选定的日期
            string date = DateTime.Now.ToString("yyyyMMdd");
            try
            {
                //根据日期拉取对应的信息
                LoadList(date);
                lbInfo.Text = MessageInfo(date);
                MessageBox.Show("拉取成功");
            }
            catch
            {
                MessageBox.Show("拉取失败");
            }
        }

        private string MessageInfo(string date)
        {
            return $"现在拉取的是: {date}";
        }

        /// <summary>
        /// 程序启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            if (Chose)
            {
                //隐藏一些按钮
                tsmToday.Enabled = false;
                tsmNex.Enabled = false;
                dateTimePicker1.Enabled = false;
               

                //选择Excel源
                //从Excel中读取数据
                string setPath = File.ReadAllText(SetPath.LastSet);
                //得到Excel源
                string excelPath = setPath.Split('|')[1];
                ExcelSource excel = new ExcelSource();
                List<IMovieShowList.MovieShow> list = excel.GetList4Excel(excelPath);
                if (!excel.isOk)
                {
                    MessageBox.Show(excel.Msg);
                    this.Close();
                }
                MovieEndTime end = new MovieEndTime();
                movieList = end.GetMovieEndTimeList(list);
            }
            else
            {
                //程序第一次启动时,拉取第二日的信息
                // 获取第二天日期
                string date = GetAddDay();
                LoadList(date);
                lbInfo.Text = MessageInfo(date);
            }

        }

        /// <summary>
        /// 获得第二天的日期
        /// </summary>
        /// <returns></returns>
        private string GetAddDay()
        {
            //获得当天的日期
            DateTime dtThis = DateTime.Now;
            //获得第二天的日期
            dtThis = dtThis.AddDays(1);
            //将日期进行格式化
            string date = dtThis.ToString("yyyyMMdd");
            //返回第二天的日期
            return date;
        }

        /// <summary>
        /// 时间设置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ///打开时间设置
            SetMovieEndTime set = new SetMovieEndTime();
            set.Changed += (() =>
            {
                //刷新时间
                LoadList(GetAddDay());
            });
            set.ShowDialog();

        }



        /// <summary>
        /// 场务表的导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 场务表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region MyRegion
            ///创建集合用以保存排片信息
            List<IMovieShowList.MovieShow> list = new List<IMovieShowList.MovieShow>();
            try
            {
                if (newExcel)
                {
                    ExcelSource ex = new ExcelSource();
                    list = ex.GetList4Excel(newFileName);
                    if (!ex.isOk)
                    {
                        MessageBox.Show(ex.Msg);
                        return;
                    }
                    MovieEndTime end = new MovieEndTime();
                    list = end.GetMovieEndTimeList(list);

                }
                else
                {
                    //排片信息读取
                    list = movieList;
                }
                

                if (list.Count == 0)
                {
                    MessageBox.Show("没有排片信息");
                    return;
                }
            }
            catch
            {

                MessageBox.Show("未知错误,请重试");
                return;
            }



            //将信息按时间排序
            List<IMovieShowList.MovieShow> iList = list.OrderBy(i => i.BeginTime).ToList<IMovieShowList.MovieShow>();
            string headeValue = string.Empty;

            bool ok = IsExcelOrApi(out headeValue, iList);
            if (!ok)
            {
                return;
            }
            
            //创建一个工作薄对象
            hssfworkbook = new HSSFWorkbook();

            //创建一张表
            Sheet sheet = hssfworkbook.CreateSheet("场务表");

            //创建第一行表头行
            CreateR1(sheet, 0, 0, 0, 5, headeValue);

            ///-----设置列宽格式  开始------//        
            //设置第1列到第3列
            SetColWidth(sheet, 0, 3, 10);
            //设置第4列(电影名称列)
            sheet.SetColumnWidth(3, 26 * 256 + 200);
            //设置第5列到第6列
            SetColWidth(sheet, 4, 2, 15);
            ///-----设置格式  结束------//  

            //创建一个单元格样式对象
            CellStyle styleCell = SetCellAllCenterBorder();
            #region 读取出数据


            //创建行标识(第二行开始)
            int count = 1;
            //循环读取排片信息集合
            foreach (IMovieShowList.MovieShow item in iList)
            {
                //创建行
                Row rowCell = sheet.CreateRow(count);
                //设置行高
                rowCell.HeightInPoints = 20;
                //写入行信息
                SetCellMovieInfo(rowCell, styleCell, item);
                count++;
            }

            #endregion

            //打开一个保存对话框,让用户保存数据
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "excel|*.xls";
            save.FileName = headeValue + "--场务";//设置默认文件名
            DialogResult res = save.ShowDialog();
            if (res == DialogResult.OK)
            {
                string path = save.FileName;
                try
                {
                    FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
                    hssfworkbook.Write(file);
                    file.Close();
                    MessageBox.Show("保存成功");
                }
                catch
                {

                    MessageBox.Show("文件已打开,请先关闭文件");
                    return;
                }
            }
            else
            {
                return;
            }

            #endregion


        }

        /// <summary>
        /// 左对齐全边框
        /// </summary>
        /// <returns></returns>
        private CellStyle cellLeftAllBorder()
        {
            CellStyle styleLeft = hssfworkbook.CreateCellStyle();
            styleLeft.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;
            styleLeft.BorderLeft = CellBorderType.THIN;
            styleLeft.BorderBottom = CellBorderType.THIN;
            styleLeft.BorderRight = CellBorderType.THIN;
            styleLeft.BorderTop = CellBorderType.THIN;
            styleLeft.VerticalAlignment = VerticalAlignment.CENTER;
            styleLeft.SetFont(cellFont());
            return styleLeft;
        }

        /// <summary>
        /// 创建电影排片信息字段
        /// </summary>
        /// <param name="row"></param>
        /// <param name="style"></param>
        /// <param name="info"></param>
        private void SetCellMovieInfo(Row row, CellStyle style, IMovieShowList.MovieShow info)
        {
            CellStyle styleLeft = cellLeftAllBorder();
            NPOI.SS.UserModel.Font font = cellFont();

            Cell cellth = row.CreateCell(0);
            cellth.SetCellValue(info.Room);
            cellth.CellStyle = style;


            Cell bt = row.CreateCell(1);
            bt.SetCellValue(info.BeginTime);
            bt.CellStyle = style;


            //散场时间
            Cell cellend = row.CreateCell(2);
            cellend.SetCellValue(info.EndTime);
            cellend.CellStyle = style;


            Cell cellname = row.CreateCell(3);
            cellname.SetCellValue(info.Name);
            cellname.CellStyle = styleLeft;



            Cell cellVersion = row.CreateCell(4);
            cellVersion.CellStyle = styleLeft;
            cellVersion.SetCellValue(info.Version);
            Cell celly = row.CreateCell(5);
            celly.CellStyle = styleLeft;
            celly.SetCellValue(info.Language);

        }

        /// <summary>
        /// 单元格的字体样式(宋体,12号)
        /// </summary>
        /// <returns></returns>
        public NPOI.SS.UserModel.Font cellFont()
        {
            NPOI.SS.UserModel.Font cellsFont = hssfworkbook.CreateFont();
            cellsFont.FontHeightInPoints = 12;
            cellsFont.FontName = "宋体";
            return cellsFont;
        }

        /// <summary>
        /// 设置第一行的表头
        /// </summary>
        /// <param name="sheet"></param>
        private void CreateR1(Sheet sheet, int firstRow, int lastRow, int firstCol, int lastCol, string value)
        {
            //创建字体样式第一行表头大标题
            NPOI.SS.UserModel.Font fontHeader = hssfworkbook.CreateFont();
            //fontHeader.FontHeight = 22 * 22;
            fontHeader.FontHeightInPoints = 16;
            fontHeader.Boldweight = 700;


            //创建第一行表头
            Row rowHeader = sheet.CreateRow(0);
            rowHeader.RowStyle = SetCellAllCenterNoBorder();
            rowHeader.HeightInPoints = 32;

            Cell cellHeader = rowHeader.CreateCell(0);
            cellHeader.SetCellValue(value);
            cellHeader.CellStyle = SetCellAllCenterNoBorder();
            cellHeader.CellStyle.SetFont(fontHeader);

            //将表头跨列合并           
            sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(firstRow, lastRow, firstCol, lastCol));


        }

        /// <summary>
        /// 设定单元格的列宽
        /// </summary>
        /// <param name="sheet">表</param>
        /// <param name="index">列索引</param>
        /// <param name="width">宽度</param>
        /// <param name="count">列数</param>
        private void SetColWidth(Sheet sheet, int index, int count, int width)
        {
            //创建头字段
            //设置列宽
            for (int i = 0; i < count; i++)
            {
                sheet.SetColumnWidth(index + i, width * 256 + 200);
            }
        }

        /// <summary>
        /// 设置单元格样式为中对齐无边框
        /// </summary>
        /// <returns></returns>
        private CellStyle SetCellAllCenterNoBorder()
        {
            //创建表头单元格对齐样式
            CellStyle styleCell = hssfworkbook.CreateCellStyle();
            styleCell.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            styleCell.VerticalAlignment = VerticalAlignment.CENTER;
            return styleCell;
        }

        /// <summary>
        /// 创建四边框中对齐样式
        /// </summary>
        /// <returns></returns>
        private CellStyle SetCellAllCenterBorder()
        {
            //创建其它单元格的样式
            CellStyle styleCell = hssfworkbook.CreateCellStyle();
            styleCell.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER_SELECTION;
            styleCell.VerticalAlignment = VerticalAlignment.CENTER;
            styleCell.BorderLeft = CellBorderType.THIN;
            styleCell.BorderRight = CellBorderType.THIN;
            styleCell.BorderTop = CellBorderType.THIN;
            styleCell.BorderBottom = CellBorderType.THIN;
            styleCell.SetFont(cellFont());

            return styleCell;
        }

        /// <summary>
        /// 放映表导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 放映表ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            //创建排片信息集合对象,用以保存信息
            List<IMovieShowList.MovieShow> listMovie = new List<IMovieShowList.MovieShow>();

            try
            {
                if (newExcel)
                {
                    ExcelSource ex = new ExcelSource();
                    listMovie = ex.GetList4Excel(newFileName);
                    if (!ex.isOk)
                    {
                        MessageBox.Show(ex.Msg);
                        return;
                    }
                    MovieEndTime end = new MovieEndTime();
                    listMovie = end.GetMovieEndTimeList(listMovie);

                }
                else
                {
                    //排片信息读取
                    listMovie = movieList;
                }


                if (listMovie.Count == 0)
                {
                    MessageBox.Show("没有排片信息");
                    return;
                }
            }
            catch
            {

                MessageBox.Show("未知错误,请重试");
                return;
            }

            //try
            //{
            //    //获取到缓存的信息
            //    listMovie = movieList;
            //}
            //catch
            //{

            //    MessageBox.Show("未知错误,请稍候重试");
            //    return;
            //}
            string headeValue = string.Empty;

            //是否Excel源或Api源
            bool ok = IsExcelOrApi(out headeValue, listMovie);

            if (!ok)
            {
                return;
            }


            //让排片信息以厅号来排序
            var iList = listMovie.OrderBy(i => i.Room[0]);

            //提取所有厅号
            var a = from room in iList select room.Room;

            //去重之后放映厅的集合
            List<string> RoomInfo = a.Distinct().ToList();

            //创建放映表
            hssfworkbook = new HSSFWorkbook();

            Sheet sheet = hssfworkbook.CreateSheet("放映表");
            sheet.PrintSetup.Landscape = true;//设置为横向


            //设定列宽
            for (int i = 0; i < 12; i++)
            {
                if ((i + 1) % 3 == 0)
                {
                    //将包含电影名称的列设置列宽
                    sheet.SetColumnWidth(i, 23 * 256 + 200);
                }
                else
                {
                    //其它的列设置列宽
                    sheet.SetColumnWidth(i, 6 * 256 + 200);
                }
            }


            //创建第一行
            CreateR1(sheet, 0, 0, 0, 11, headeValue);

            //行标识从第2行开始
            int roomCout = 1;
            Dictionary<string, int> roomIndex = new Dictionary<string, int>();

            //创建当前行
            Row row = sheet.CreateRow(roomCout);
            row.HeightInPoints = 30;

            int j = -1;
            //保存厅号的位置信息
            List<Cell> listCell = new List<Cell>();

            //创建其它字段
            for (int i = 0; i < RoomInfo.Count; i++)
            {
                //创建第四个厅的时候转折
                if ((i + 1) % 5 == 0)
                {
                    //并且前面空余8格
                    roomCout += 9;
                    row = sheet.CreateRow(roomCout);
                    row.HeightInPoints = 30;
                    j = -1;

                }
                j++;
                //创建单元格
                //创建字体样式
                NPOI.SS.UserModel.Font fontHeader = hssfworkbook.CreateFont();
                fontHeader.FontHeightInPoints = 12;
                fontHeader.Boldweight = 700;

                int count = j * 3;
                Cell cell = row.CreateCell(count);
                cell.SetCellValue(RoomInfo[i]);
                cell.CellStyle = SetCellAllCenterBorder();
                cell.CellStyle.SetFont(fontHeader);
                //将后面的两个单元格设置出来
                SetCell(row, count + 1, string.Empty);
                SetCell(row, count + 2, string.Empty);
                //进行单元格合并
                sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(roomCout, roomCout, count, count + 2));


                listCell.Add(cell);
            }

            //将影片信息按厅排列
            List<IMovieShowList.MovieShow> li = listMovie.OrderBy(x => x.Room[0]).ToList<IMovieShowList.MovieShow>();


            int rowIndex = 0;
            int indexCol;

            foreach (var item in listCell)
            {

                //当前厅名
                string room = item.StringCellValue;
                //找到当前厅的所有子集并且进行排序
                List<IMovieShowList.MovieShow> s = (from i in li where i.Room == room select i).OrderBy(x => x.BeginTime).ToList<IMovieShowList.MovieShow>();
                //如果rowIndex与上次一致,则不创建行,直接在原有的行上创建单元格
                //保存之前的rowIndex;

                rowIndex = item.RowIndex + 1;//3

                indexCol = item.ColumnIndex;//0

                //循环子集添加
                foreach (var movie in s)
                {

                    //获得下一行
                    Row rowCell = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
                    //设置行高
                    rowCell.HeightInPoints = 20;
                    //在行下面创建三个单元格填充值                   
                    SetCell(rowCell, indexCol, movie.BeginTime);
                    SetCell(rowCell, indexCol + 1, movie.EndTime);

                    //单独处理电影名称,让其左对齐
                    //SetCell(rowCell, indexCol+2, movie.Name);
                    Cell cellName = rowCell.CreateCell(indexCol + 2);
                    cellName.CellStyle = cellLeftAllBorder();
                    cellName.SetCellValue(movie.Name);
                    rowIndex++;
                }
            }

            //打开一个保存对话框,让用户保存数据
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "excel|*.xls";
            save.FileName = headeValue + "--放映 ";
            DialogResult res = save.ShowDialog();
            if (res == DialogResult.OK)
            {
                string path = save.FileName;
                try
                {
                    FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
                    hssfworkbook.Write(file);
                    file.Close();
                    MessageBox.Show("保存成功");
                }
                catch
                {

                    MessageBox.Show("文件已打开,请先关闭文件");
                    return;
                }
            }
            else
            {
                return;
            }

        }

        /// <summary>
        /// 判断当前的源是Excel还是Api
        /// </summary>
        /// <param name="headeValue">导出的表头的名字</param>
        /// <param name="listMovie">电影列表</param>
        /// <returns>false为用户不需要导出表</returns>
        private bool IsExcelOrApi(out string headeValue, List<IMovieShowList.MovieShow> listMovie)
        {
            if (!Chose)
            {
                //获取当前选定的日期
                string showDate = this.dateTimePicker1.Value.ToString("yyyyMMdd");
                string date = listMovie[0].Data;
                string headDate = date.Substring(4);
                //如果当前选定的日期不等于当前缓存中的日期
                if (listMovie[0].Data != showDate)
                {
                    //提示用户
                    DialogResult re = MessageBox.Show("现在即将导出的是" + listMovie[0].Data + "请问需要继续导出吗", "提示", MessageBoxButtons.YesNo);
                    if (re == DialogResult.No)
                    {
                        headeValue = string.Empty;
                        return false;
                    }

                }
                lbInfo.Text = MessageInfo(date);
                headeValue = string.Format("{0}月{1}日排片表", headDate.Substring(0, 2), headDate.Substring(2, 2));
                return true;
            }
            else
            {
                headeValue = "今日排片";
                return true;
            }
        }

        /// <summary>
        /// 设定单元格
        /// </summary>
        /// <param name="rowCell">行</param>
        /// <param name="indexCol">单元格位置</param>
        /// <param name="value">单元格内容</param>
        private void SetCell(Row rowCell, int indexCol, string value)
        {

            Cell cell1 = rowCell.CreateCell(indexCol);
            cell1.CellStyle = SetCellAllCenterBorder();
            cell1.SetCellValue(value);
        }

        private void 重新获取信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string date = GetAddDay();
            try
            {
                LoadList(date);
                lbInfo.Text = MessageInfo(date);



            }
            catch
            {

                MessageBox.Show("获取失败");
            }
        }


        /// <summary>
        /// 加载信息
        /// </summary>
        private void LoadList(string date)
        {

            #region 运用类库
            List<IMovieShowList.MovieShow> list = new List<IMovieShowList.MovieShow>();
            if (!Chose)
            {
                list = MovieObjFactory.GetMovieObj().GetMovieList(date); //getList.GetMovieList(date);
            }
            else
            {
                //读取排片表的数据
                ExcelSource ex = new ExcelSource();
                list = ex.GetList4Excel(File.ReadAllText(SetPath.LastSet).Split('|')[1]);
            }

            MovieEndTime end = new MovieEndTime();
            list = end.GetMovieEndTimeList(list);
            movieList = list;

            #endregion
        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString("yyyyMMdd");
            LoadList(date);
            lbInfo.Text = MessageInfo(date);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("readme.txt");
            }
            catch
            {

                return;
            }
        }
        bool newExcel;
        string newFileName;
        private void btnNew_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel|*.xls";
           var re= of.ShowDialog();
            if (re== DialogResult.OK)
            {
                newExcel = true;
                newFileName = of.FileName;
            }
            
        }
    }
}
