namespace 语音播报
{
    partial class Frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lbTime = new System.Windows.Forms.Label();
            this.scroll = new 语音播报.Model.SundayRXScrollBar();
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.lbVol = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOut = new System.Windows.Forms.Button();
            this.btnList = new System.Windows.Forms.Button();
            this.btnHand = new System.Windows.Forms.Button();
            this.btnPlayList = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnResert = new System.Windows.Forms.Button();
            this.panelMain_frm = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.VideoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovieData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.picInfo = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMax = new System.Windows.Forms.PictureBox();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tmMain = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelMain_frm.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.lbTime);
            this.panelLeft.Controls.Add(this.scroll);
            this.panelLeft.Controls.Add(this.player);
            this.panelLeft.Controls.Add(this.lbVol);
            this.panelLeft.Controls.Add(this.label2);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Controls.Add(this.pictureBox1);
            this.panelLeft.Controls.Add(this.btnOut);
            this.panelLeft.Controls.Add(this.btnList);
            this.panelLeft.Controls.Add(this.btnHand);
            this.panelLeft.Controls.Add(this.btnPlayList);
            this.panelLeft.Controls.Add(this.btnSet);
            this.panelLeft.Controls.Add(this.btnResert);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(195, 615);
            this.panelLeft.TabIndex = 0;
            this.panelLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLeft_Paint);
            // 
            // lbTime
            // 
            this.lbTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTime.AutoSize = true;
            this.lbTime.ForeColor = System.Drawing.Color.White;
            this.lbTime.Location = new System.Drawing.Point(71, 9);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(0, 12);
            this.lbTime.TabIndex = 8;
            // 
            // scroll
            // 
            this.scroll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scroll.BottomColor = System.Drawing.Color.Black;
            this.scroll.Location = new System.Drawing.Point(3, 215);
            this.scroll.MouseDownSliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(235)))), ((int)(((byte)(239)))));
            this.scroll.MouseOverSliderColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.scroll.Name = "scroll";
            this.scroll.Size = new System.Drawing.Size(21, 327);
            this.scroll.SliderColor = System.Drawing.Color.Gray;
            this.scroll.SliderHeight = 100;
            this.scroll.SliderWidthPercent = 0.4D;
            this.scroll.SmallChange = 1;
            this.scroll.TabIndex = 6;
            this.scroll.Value = 0;
            // 
            // player
            // 
            this.player.Enabled = true;
            this.player.Location = new System.Drawing.Point(12, 593);
            this.player.Name = "player";
            this.player.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("player.OcxState")));
            this.player.Size = new System.Drawing.Size(10, 10);
            this.player.TabIndex = 5;
            this.player.Visible = false;
            // 
            // lbVol
            // 
            this.lbVol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbVol.AutoSize = true;
            this.lbVol.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lbVol.Location = new System.Drawing.Point(103, 530);
            this.lbVol.Name = "lbVol";
            this.lbVol.Size = new System.Drawing.Size(0, 12);
            this.lbVol.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(38, 530);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "当前音量:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(53, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "欢迎使用";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(25, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 84);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btnOut
            // 
            this.btnOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOut.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnOut.FlatAppearance.BorderSize = 0;
            this.btnOut.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Desktop;
            this.btnOut.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOut.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOut.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOut.ForeColor = System.Drawing.SystemColors.Control;
            this.btnOut.Location = new System.Drawing.Point(33, 415);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(162, 31);
            this.btnOut.TabIndex = 5;
            this.btnOut.Text = "重新登陆(&O)";
            this.btnOut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOut.UseVisualStyleBackColor = true;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnList
            // 
            this.btnList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnList.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnList.FlatAppearance.BorderSize = 0;
            this.btnList.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnList.ForeColor = System.Drawing.SystemColors.Control;
            this.btnList.Location = new System.Drawing.Point(33, 295);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(162, 31);
            this.btnList.TabIndex = 2;
            this.btnList.Text = "排片查询(&P)";
            this.btnList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnHand
            // 
            this.btnHand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHand.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnHand.FlatAppearance.BorderSize = 0;
            this.btnHand.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Desktop;
            this.btnHand.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHand.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHand.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnHand.ForeColor = System.Drawing.SystemColors.Control;
            this.btnHand.Location = new System.Drawing.Point(33, 335);
            this.btnHand.Name = "btnHand";
            this.btnHand.Size = new System.Drawing.Size(162, 31);
            this.btnHand.TabIndex = 3;
            this.btnHand.Text = "设置手动(&B)";
            this.btnHand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHand.UseVisualStyleBackColor = true;
            this.btnHand.Click += new System.EventHandler(this.btnHand_Click);
            // 
            // btnPlayList
            // 
            this.btnPlayList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlayList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPlayList.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPlayList.FlatAppearance.BorderSize = 0;
            this.btnPlayList.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnPlayList.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnPlayList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnPlayList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlayList.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPlayList.Location = new System.Drawing.Point(34, 215);
            this.btnPlayList.Name = "btnPlayList";
            this.btnPlayList.Size = new System.Drawing.Size(162, 31);
            this.btnPlayList.TabIndex = 0;
            this.btnPlayList.Text = "播放列表(&L)";
            this.btnPlayList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlayList.UseVisualStyleBackColor = true;
            this.btnPlayList.Click += new System.EventHandler(this.btnPlayList_Click);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSet.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSet.FlatAppearance.BorderSize = 0;
            this.btnSet.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.btnSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSet.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSet.ForeColor = System.Drawing.SystemColors.Control;
            this.btnSet.Location = new System.Drawing.Point(33, 255);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(162, 31);
            this.btnSet.TabIndex = 1;
            this.btnSet.Text = "设置信息(&T)";
            this.btnSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // btnResert
            // 
            this.btnResert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResert.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnResert.FlatAppearance.BorderSize = 0;
            this.btnResert.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.Desktop;
            this.btnResert.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnResert.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnResert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResert.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnResert.ForeColor = System.Drawing.SystemColors.Control;
            this.btnResert.Location = new System.Drawing.Point(33, 375);
            this.btnResert.Name = "btnResert";
            this.btnResert.Size = new System.Drawing.Size(162, 31);
            this.btnResert.TabIndex = 4;
            this.btnResert.Text = "重新获取(&A)";
            this.btnResert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResert.UseVisualStyleBackColor = true;
            this.btnResert.Click += new System.EventHandler(this.btnResert_Click);
            // 
            // panelMain_frm
            // 
            this.panelMain_frm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelMain_frm.Controls.Add(this.panelMain);
            this.panelMain_frm.Controls.Add(this.panelLeft);
            this.panelMain_frm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain_frm.Location = new System.Drawing.Point(0, 0);
            this.panelMain_frm.Name = "panelMain_frm";
            this.panelMain_frm.Size = new System.Drawing.Size(840, 615);
            this.panelMain_frm.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.dataGridView1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(195, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(645, 615);
            this.panelMain.TabIndex = 2;
            this.panelMain.Resize += new System.EventHandler(this.panelMain_Resize);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeight = 30;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VideoName,
            this.BeginTime,
            this.MovieData,
            this.Room});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(10);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(645, 615);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.Paint += new System.Windows.Forms.PaintEventHandler(this.dataGridView1_Paint);
            // 
            // VideoName
            // 
            this.VideoName.DataPropertyName = "Name";
            this.VideoName.HeaderText = "电影名称";
            this.VideoName.Name = "VideoName";
            this.VideoName.ReadOnly = true;
            // 
            // BeginTime
            // 
            this.BeginTime.DataPropertyName = "beginTime";
            this.BeginTime.HeaderText = "开场时间";
            this.BeginTime.Name = "BeginTime";
            this.BeginTime.ReadOnly = true;
            // 
            // MovieData
            // 
            this.MovieData.DataPropertyName = "Date";
            this.MovieData.HeaderText = "日期";
            this.MovieData.Name = "MovieData";
            this.MovieData.ReadOnly = true;
            // 
            // Room
            // 
            this.Room.DataPropertyName = "Room";
            this.Room.HeaderText = "放映厅";
            this.Room.Name = "Room";
            this.Room.ReadOnly = true;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.panelTitle.Controls.Add(this.pictureBox4);
            this.panelTitle.Controls.Add(this.picInfo);
            this.panelTitle.Controls.Add(this.label3);
            this.panelTitle.Controls.Add(this.picClose);
            this.panelTitle.Controls.Add(this.picMax);
            this.panelTitle.Controls.Add(this.picMin);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(840, 40);
            this.panelTitle.TabIndex = 1;
            this.panelTitle.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDoubleClick);
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            this.panelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseUp);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::语音播报.Properties.Resources.voice;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(17, 9);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(32, 22);
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // picInfo
            // 
            this.picInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picInfo.BackgroundImage = global::语音播报.Properties.Resources.信息;
            this.picInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picInfo.Location = new System.Drawing.Point(703, 11);
            this.picInfo.Name = "picInfo";
            this.picInfo.Size = new System.Drawing.Size(23, 18);
            this.picInfo.TabIndex = 6;
            this.picInfo.TabStop = false;
            this.picInfo.Click += new System.EventHandler(this.picInfo_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(53, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "影院语音播报";
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picClose.BackgroundImage")));
            this.picClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Location = new System.Drawing.Point(800, 10);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.TabIndex = 0;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picMax
            // 
            this.picMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMax.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picMax.BackgroundImage")));
            this.picMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMax.Location = new System.Drawing.Point(768, 9);
            this.picMax.Name = "picMax";
            this.picMax.Size = new System.Drawing.Size(22, 22);
            this.picMax.TabIndex = 0;
            this.picMax.TabStop = false;
            this.picMax.Click += new System.EventHandler(this.picMax_Click);
            // 
            // picMin
            // 
            this.picMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picMin.BackgroundImage")));
            this.picMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMin.Location = new System.Drawing.Point(736, 9);
            this.picMin.Name = "picMin";
            this.picMin.Size = new System.Drawing.Size(22, 22);
            this.picMin.TabIndex = 0;
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.picMin_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 3000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "语音播报系统";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tmMain,
            this.toolStripSeparator1,
            this.tmExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 54);
            // 
            // tmMain
            // 
            this.tmMain.Name = "tmMain";
            this.tmMain.Size = new System.Drawing.Size(112, 22);
            this.tmMain.Text = "主界面";
            this.tmMain.Click += new System.EventHandler(this.tmMain_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(109, 6);
            // 
            // tmExit
            // 
            this.tmExit.Name = "tmExit";
            this.tmExit.Size = new System.Drawing.Size(112, 22);
            this.tmExit.Text = "退出";
            this.tmExit.Click += new System.EventHandler(this.tmExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelMain_frm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 615);
            this.panel1.TabIndex = 3;
            // 
            // timer4
            // 
            this.timer4.Enabled = true;
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "电影名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 156;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "beginTime";
            this.dataGridViewTextBoxColumn2.HeaderText = "开场时间";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 156;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn3.HeaderText = "日期";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 156;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Room";
            this.dataGridViewTextBoxColumn4.HeaderText = "放映厅";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 156;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(840, 655);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(840, 655);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Frm_Main_Paint);
            this.Resize += new System.EventHandler(this.Frm_Main_Resize);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelMain_frm.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button btnOut;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnHand;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnResert;
        private System.Windows.Forms.Panel panelMain_frm;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMax;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.Label lbVol;
        private System.Windows.Forms.Label label2;
        private AxWMPLib.AxWindowsMediaPlayer player;
        private System.Windows.Forms.DataGridViewTextBoxColumn VideoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BeginTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovieData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tmMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tmExit;
        private System.Windows.Forms.Button btnPlayList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picInfo;
        private Model.SundayRXScrollBar scroll;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Timer timer4;
    }
}