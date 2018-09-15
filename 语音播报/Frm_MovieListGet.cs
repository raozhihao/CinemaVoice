using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using 语音播报.Model;

namespace 语音播报
{
    public partial class Frm_MovieListGet : Form
    {
        /// <summary>
        /// 源选择
        /// </summary>
        private bool Chose;

        public event Action ShowSome;
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
                //lbInfo.Text = MessageInfo(date);
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
            ShowSome?.Invoke();
            Frm_MovieListGet_Paint(sender, null);

            if (Chose)
            {
                //隐藏一些按钮
                tsmToday.Enabled = false;
                tsmNex.Enabled = false;
                dateTimePicker1.Enabled = false;
                lbApiInfo.Visible = false;
                lbApiDate.Visible = false;

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
                lbApiDate.Text = date;
                //lbInfo.Text = MessageInfo(date);
            }

            InitDataGridView();
           

        }

        private void InitDataGridView()
        {
            dataGridView2.AutoGenerateColumns = false;

            //添加按钮
            MyDataGridViewTextBoxColumn txtUpdate = new MyDataGridViewTextBoxColumn();

            txtUpdate.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtUpdate.SortMode = DataGridViewColumnSortMode.NotSortable;
            txtUpdate.ReadOnly = true;
            txtUpdate.Name = "btnStart";
            txtUpdate.HeaderText = "操作";
            txtUpdate.DefaultCellStyle.NullValue = "更新";
            txtUpdate.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //添加按钮
            MyDataGridViewTextBoxColumn txtDel = new MyDataGridViewTextBoxColumn();

            txtDel.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            txtDel.SortMode = DataGridViewColumnSortMode.NotSortable;
            txtDel.ReadOnly = true;
            txtDel.Name = "btnStart";
            txtDel.HeaderText = "操作";
            txtDel.DefaultCellStyle.NullValue = "删除";
            txtDel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView2.Columns.Add(txtUpdate);
            dataGridView2.Columns.Add(txtDel);
            initTable();
            txtName.Select();
        }

        /// <summary>
        /// 创建序列化对象
        /// </summary>
        JavaScriptSerializer jss = new JavaScriptSerializer();
        private void initTable()
        {
            List<SetTime> list = new List<SetTime>();
            if (!File.Exists(SetPath.TimeJosnPath))
            {
                //如果不存在,则创建
                //  File.Create("time.txt");
                using (FileStream file = new FileStream(SetPath.TimeJosnPath, FileMode.Create))
                {

                }
            }
            else
            {
                //存在,则读取
                
                string info = File.ReadAllText(SetPath.TimeJosnPath);
                list = jss.Deserialize<List<SetTime>>(info);
                blist = new BindingList<SetTime>(list);
                dataGridView2.DataSource = blist;
            }
            cellValueChange = true;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="list"></param>
        private void SaveJson(List<SetTime> list)
        {
            //保存
            string info = jss.Serialize(list);
            File.WriteAllText(SetPath.TimeJosnPath, info);
        }


        /// <summary>
        /// 记录右键点击的行坐标
        /// </summary>
        int selectRowIndex;

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
                    //MovieEndTime end = new MovieEndTime();
                    //list = end.GetMovieEndTimeList(list);

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


            MovieEndTime end = new MovieEndTime();
            list = end.GetMovieEndTimeList(list);
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

            MovieEndTime end = new MovieEndTime();
            listMovie = end.GetMovieEndTimeList(listMovie);
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
                //lbInfo.Text = MessageInfo(date);
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
                //lbInfo.Text = MessageInfo(date);



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

            //MovieEndTime end = new MovieEndTime();
            //list = end.GetMovieEndTimeList(list);
            movieList = list;

            #endregion
        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString("yyyyMMdd");
            LoadList(date);
            //lbInfo.Text = MessageInfo(date);
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
                lbExcelInfo.Visible = true;
                
                lbExcelSource.Text = newFileName;
                lbExcelSource.Visible = true;

                lbApiDate.Visible = lbApiInfo.Visible = false;
            }
            
        }

        private void Frm_MovieListGet_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e?.Graphics;
            g?.DrawLine(System.Drawing.Pens.WhiteSmoke, 0, menuStrip1.Height, menuStrip1.Width, menuStrip1.Height);
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down)
            {
                listBox1.SelectedIndex = 0;
                listBox1.Focus();
            }
            if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
            {
                listBox1.Visible = false;
                //listBox1.ClearSelected();
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (!listBox1.Focused)
            {
                listBox1.Visible = false;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            ////获取要搜索的字符串
            string word = txtName.Text.Trim();
            try
            {
                var list = MovieObjFactory.GetSearchObj().GetMovieNameList(word);

                listBox1.Items.Clear();
                listBox1.Visible = true;
                //listBox1.Location = new System.Drawing.Point(toolStripLabel1.Width + toolStripSeparator1.Width, toolStrip1.Height);
                list.ForEach(a =>
                {
                    listBox1.Items.Add(a.titlecn);
                });
            }
            catch
            {

            }
        }

        private void txtTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Addbtn_Click(null, null);
            }
        }
        BindingList<SetTime> blist = new BindingList<SetTime>();
        private void Addbtn_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string time = txtTime.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(time))
            {
                MessageBox.Show("请填写完整影片名称与放映时长", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            time = time.Contains("：") ? time.Replace("：", ":") : time;
            List<SetTime> list = new List<SetTime>((BindingList<SetTime>)this.dataGridView2.DataSource);
            //判断当前加入的电影是否已在列表中
            SetTime s = list?.Find(x => x.MovieName == name);

            if (s != null)
            {
                //如果在,则提示用户是否覆盖
                DialogResult re = MessageBox.Show("您即将添加的电影" + Environment.NewLine + "《" + name + "》\r\n已在列表中,请问要覆盖吗?", "已存在", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (re == DialogResult.OK)
                {

                    //用户要覆盖,则将其本身存在去除掉
                    int index = blist.IndexOf(s);
                    s.MovieTime = time;
                    blist.Remove(s);
                    blist.Insert(index, s);
                   
                }
                else
                {
                    return;
                }
            }
            else
            {
                //不存在,则添加
                blist.Add(new SetTime() { MovieName = name, MovieTime = time });
            }
            SaveJson(new List<SetTime>(blist));
            txtName.Focus();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            HideListBox();
        }
        private void HideListBox()
        {

            txtName.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
            txtTime.Focus();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                HideListBox();

            }
            if (e.KeyData == Keys.Escape)
            {
                txtName.Focus();
                listBox1.Visible = false;
            }
        }

        private void listBox1_Leave(object sender, EventArgs e)
        {
            if (!txtName.Focused)
            {
                listBox1.Visible = false;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellTxt = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue.ToString();
            switch (cellTxt)
            {
                case "更新":
                    EditCell(e.RowIndex, 1);
                    break;
                case "删除":
                    DelRow(e.RowIndex);
                    break;
                default:
                    break;
            }
        }
        private void DelRow(int rowIndex)
        {
            List<SetTime> list = new List<SetTime>((BindingList<SetTime>)this.dataGridView2.DataSource);
            //找到当前的影片
            SetTime movie = dataGridView2.Rows[rowIndex].DataBoundItem as SetTime;

            if (movie != null)
            {
                //如果在,则提示用户是否覆盖
                DialogResult re = MessageBox.Show($"你确定要删除{Environment.NewLine + movie.MovieName + Environment.NewLine}吗,数据删除后不可恢复", "警告", MessageBoxButtons.OKCancel);
                if (re == DialogResult.OK)
                {

                    blist.Remove(movie);
                }
                else
                {
                    return;
                }
            }
        }
        private void EditCell(int rowIndex, int colIndex)
        {
            dataGridView2.CurrentCell = dataGridView2.Rows[rowIndex].Cells[colIndex];
            dataGridView2.BeginEdit(true);
        }

        /// <summary>
        /// 重写键盘按下事件
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //如果按下的是tab键
            if (keyData == Keys.Tab)
            {
                //如果当前下拉框没有显示
                if (listBox1.Visible)
                {
                    listBox1.Visible = false;
                    //listBox1.ClearSelected();
                    txtName.Focus();
                    return true;
                }
                else
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Frm_MovieListGet_Resize(object sender, EventArgs e)
        {
            
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCell(selectRowIndex, 1);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DelRow(selectRowIndex);
        }

        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //如果是鼠标右键
                //记录当前行坐标
                selectRowIndex = e.RowIndex;
            }
        }

        bool cellValueChange=false;
        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (cellValueChange)
            {
                SaveJson(new List<SetTime>(blist));
            }
           
        }

        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SaveJson(new List<SetTime>(blist));
        }

        private void splitContainer1_Resize(object sender, EventArgs e)
        {
            //判断当前窗体状态
            if (splitContainer1.Width >= 700)
            {
                //这是排片查询窗口的宽度
                splitContainer1.Orientation = Orientation.Vertical;
                splitContainer1.Panel1MinSize = 600;
                
            }
            else
            {
                splitContainer1.Orientation = Orientation.Horizontal;
                splitContainer1.Panel1MinSize = 209;
                splitContainer1.SplitterDistance = 210;
            }
        }

        private void tsmNex_Click(object sender, EventArgs e)
        {
            
            LoadList(GetAddDay());
            MessageBox.Show("获取成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsmToday_Click(object sender, EventArgs e)
        {
            LoadList(DateTime.Now.ToString("yyyyMMdd"));
            lbApiDate.Text = DateTime.Now.ToString("yyyyMMdd");
            MessageBox.Show("获取成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
