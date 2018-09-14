namespace 语音播报
{
    partial class NewLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewLogin));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lbTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnPlayList = new System.Windows.Forms.Button();
            this.btnAPIEnter = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panelPIc = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.picInfo = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.panelApi = new System.Windows.Forms.Panel();
            this.panelExcel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEn = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnShowExcelStyle = new System.Windows.Forms.Button();
            this.txtExcel = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.player = new AxWMPLib.AxWindowsMediaPlayer();
            this.panelTitle.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            this.panelApi.SuspendLayout();
            this.panelExcel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.panelTitle.Controls.Add(this.pictureBox4);
            this.panelTitle.Controls.Add(this.picInfo);
            this.panelTitle.Controls.Add(this.label3);
            this.panelTitle.Controls.Add(this.picClose);
            this.panelTitle.Controls.Add(this.picMin);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(480, 40);
            this.panelTitle.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(47, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "影院语音播报";
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Black;
            this.panelLeft.Controls.Add(this.lbTime);
            this.panelLeft.Controls.Add(this.player);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Controls.Add(this.pictureBox1);
            this.panelLeft.Controls.Add(this.btnPlayList);
            this.panelLeft.Controls.Add(this.button2);
            this.panelLeft.Controls.Add(this.btnSet);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 40);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(195, 350);
            this.panelLeft.TabIndex = 8;
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
            this.btnSet.Location = new System.Drawing.Point(32, 241);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(162, 31);
            this.btnSet.TabIndex = 1;
            this.btnSet.Text = "自定义Excel(&T)";
            this.btnSet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
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
            this.btnPlayList.Location = new System.Drawing.Point(33, 195);
            this.btnPlayList.Name = "btnPlayList";
            this.btnPlayList.Size = new System.Drawing.Size(162, 31);
            this.btnPlayList.TabIndex = 0;
            this.btnPlayList.Text = "使用API(&L)";
            this.btnPlayList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlayList.UseVisualStyleBackColor = true;
            this.btnPlayList.Click += new System.EventHandler(this.btnPlayList_Click);
            // 
            // btnAPIEnter
            // 
            this.btnAPIEnter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnAPIEnter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAPIEnter.ForeColor = System.Drawing.Color.White;
            this.btnAPIEnter.Location = new System.Drawing.Point(65, 285);
            this.btnAPIEnter.Name = "btnAPIEnter";
            this.btnAPIEnter.Size = new System.Drawing.Size(183, 44);
            this.btnAPIEnter.TabIndex = 10;
            this.btnAPIEnter.Text = "确   定";
            this.btnAPIEnter.UseVisualStyleBackColor = false;
            this.btnAPIEnter.Click += new System.EventHandler(this.btnAPIEnter_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelExcel);
            this.panelMain.Controls.Add(this.panelApi);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(195, 40);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(285, 350);
            this.panelMain.TabIndex = 11;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(33, 286);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(162, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "排片查询(&P)";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelPIc
            // 
            this.panelPIc.BackgroundImage = global::语音播报.Properties.Resources.cinema;
            this.panelPIc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panelPIc.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPIc.Location = new System.Drawing.Point(0, 0);
            this.panelPIc.Name = "panelPIc";
            this.panelPIc.Size = new System.Drawing.Size(285, 194);
            this.panelPIc.TabIndex = 9;
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
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::语音播报.Properties.Resources.voice;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(11, 9);
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
            this.picInfo.Location = new System.Drawing.Point(380, 11);
            this.picInfo.Name = "picInfo";
            this.picInfo.Size = new System.Drawing.Size(23, 18);
            this.picInfo.TabIndex = 6;
            this.picInfo.TabStop = false;
            this.picInfo.Click += new System.EventHandler(this.picInfo_Click);
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picClose.BackgroundImage")));
            this.picClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Location = new System.Drawing.Point(440, 10);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(20, 20);
            this.picClose.TabIndex = 0;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // picMin
            // 
            this.picMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picMin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picMin.BackgroundImage")));
            this.picMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picMin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMin.Location = new System.Drawing.Point(413, 9);
            this.picMin.Name = "picMin";
            this.picMin.Size = new System.Drawing.Size(22, 22);
            this.picMin.TabIndex = 0;
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.picMin_Click);
            // 
            // panelApi
            // 
            this.panelApi.Controls.Add(this.label2);
            this.panelApi.Controls.Add(this.panelPIc);
            this.panelApi.Controls.Add(this.btnAPIEnter);
            this.panelApi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelApi.Location = new System.Drawing.Point(0, 0);
            this.panelApi.Name = "panelApi";
            this.panelApi.Size = new System.Drawing.Size(285, 350);
            this.panelApi.TabIndex = 11;
            // 
            // panelExcel
            // 
            this.panelExcel.Controls.Add(this.panel1);
            this.panelExcel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelExcel.Location = new System.Drawing.Point(0, 0);
            this.panelExcel.Name = "panelExcel";
            this.panelExcel.Size = new System.Drawing.Size(285, 350);
            this.panelExcel.TabIndex = 12;
            this.panelExcel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnShowExcelStyle);
            this.panel1.Controls.Add(this.txtExcel);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 350);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnEn);
            this.panel2.Controls.Add(this.btnExcel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 256);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(285, 58);
            this.panel2.TabIndex = 13;
            // 
            // btnEn
            // 
            this.btnEn.BackColor = System.Drawing.Color.Black;
            this.btnEn.FlatAppearance.BorderSize = 0;
            this.btnEn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEn.ForeColor = System.Drawing.Color.White;
            this.btnEn.Location = new System.Drawing.Point(163, 14);
            this.btnEn.Name = "btnEn";
            this.btnEn.Size = new System.Drawing.Size(110, 30);
            this.btnEn.TabIndex = 1;
            this.btnEn.Text = "确定";
            this.btnEn.UseVisualStyleBackColor = false;
            this.btnEn.Click += new System.EventHandler(this.btnEn_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.Black;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(12, 14);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(110, 30);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "打开";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnShowExcelStyle
            // 
            this.btnShowExcelStyle.BackColor = System.Drawing.Color.Black;
            this.btnShowExcelStyle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnShowExcelStyle.Location = new System.Drawing.Point(0, 314);
            this.btnShowExcelStyle.Name = "btnShowExcelStyle";
            this.btnShowExcelStyle.Size = new System.Drawing.Size(285, 36);
            this.btnShowExcelStyle.TabIndex = 1;
            this.btnShowExcelStyle.Text = "Excel源模板格式查看";
            this.btnShowExcelStyle.UseVisualStyleBackColor = false;
            this.btnShowExcelStyle.Click += new System.EventHandler(this.btnShowExcelStyle_Click);
            // 
            // txtExcel
            // 
            this.txtExcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtExcel.Location = new System.Drawing.Point(0, 194);
            this.txtExcel.Name = "txtExcel";
            this.txtExcel.Size = new System.Drawing.Size(285, 62);
            this.txtExcel.TabIndex = 0;
            this.txtExcel.Text = "";
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::语音播报.Properties.Resources.cinema;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(285, 194);
            this.panel3.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(77, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 60);
            this.label2.TabIndex = 11;
            this.label2.Text = "dll文件建议放在主目录下\r\n\r\n具体请参阅目录下接口文档\r\n\r\n及其它相关说明性文档";
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
            // NewLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(480, 390);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.panelTitle);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "NewLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewLogin";
            this.Load += new System.EventHandler(this.NewLogin_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.NewLogin_Paint);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            this.panelApi.ResumeLayout(false);
            this.panelApi.PerformLayout();
            this.panelExcel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox picInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lbTime;
        private AxWMPLib.AxWindowsMediaPlayer player;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnPlayList;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Panel panelPIc;
        private System.Windows.Forms.Button btnAPIEnter;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelExcel;
        private System.Windows.Forms.Panel panelApi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnEn;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnShowExcelStyle;
        private System.Windows.Forms.RichTextBox txtExcel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
    }
}