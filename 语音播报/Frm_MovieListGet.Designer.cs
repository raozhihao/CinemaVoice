namespace 语音播报
{
    partial class Frm_MovieListGet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MovieListGet));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmToday = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.场务表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsmFY = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmNex = new System.Windows.Forms.ToolStripMenuItem();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnCW = new System.Windows.Forms.Button();
            this.btnFY = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbInfo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmToday,
            this.导出ExcelToolStripMenuItem,
            this.toolStripMenuItem1,
            this.tsmNex});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(527, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmToday
            // 
            this.tsmToday.Name = "tsmToday";
            this.tsmToday.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.tsmToday.Size = new System.Drawing.Size(82, 21);
            this.tsmToday.Text = "拉取今天(&L)";
            this.tsmToday.Click += new System.EventHandler(this.拉取信息ToolStripMenuItem_Click);
            // 
            // 导出ExcelToolStripMenuItem
            // 
            this.导出ExcelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.场务表ToolStripMenuItem,
            this.tlsmFY,
            this.toolStripSeparator1});
            this.导出ExcelToolStripMenuItem.Name = "导出ExcelToolStripMenuItem";
            this.导出ExcelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.导出ExcelToolStripMenuItem.Size = new System.Drawing.Size(90, 21);
            this.导出ExcelToolStripMenuItem.Text = "导出Excel(&D)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // 场务表ToolStripMenuItem
            // 
            this.场务表ToolStripMenuItem.Name = "场务表ToolStripMenuItem";
            this.场务表ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.场务表ToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.场务表ToolStripMenuItem.Text = "场务表(&C)";
            this.场务表ToolStripMenuItem.Click += new System.EventHandler(this.场务表ToolStripMenuItem_Click);
            // 
            // tlsmFY
            // 
            this.tlsmFY.Name = "tlsmFY";
            this.tlsmFY.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tlsmFY.Size = new System.Drawing.Size(173, 22);
            this.tlsmFY.Text = "放映表(&F)";
            this.tlsmFY.Click += new System.EventHandler(this.放映表ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem1.Size = new System.Drawing.Size(83, 21);
            this.toolStripMenuItem1.Text = "时间设置(&S)";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tsmNex
            // 
            this.tsmNex.Name = "tsmNex";
            this.tsmNex.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.tsmNex.Size = new System.Drawing.Size(109, 21);
            this.tsmNex.Text = "重新获取明天(&H)";
            this.tsmNex.Click += new System.EventHandler(this.重新获取信息ToolStripMenuItem_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(387, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(114, 21);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnCW
            // 
            this.btnCW.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCW.FlatAppearance.BorderSize = 0;
            this.btnCW.Location = new System.Drawing.Point(31, 42);
            this.btnCW.Name = "btnCW";
            this.btnCW.Size = new System.Drawing.Size(248, 50);
            this.btnCW.TabIndex = 0;
            this.btnCW.Text = "导出场务表(Ctrl+C)";
            this.btnCW.UseVisualStyleBackColor = false;
            this.btnCW.Click += new System.EventHandler(this.场务表ToolStripMenuItem_Click);
            // 
            // btnFY
            // 
            this.btnFY.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFY.FlatAppearance.BorderSize = 0;
            this.btnFY.Location = new System.Drawing.Point(31, 98);
            this.btnFY.Name = "btnFY";
            this.btnFY.Size = new System.Drawing.Size(248, 50);
            this.btnFY.TabIndex = 1;
            this.btnFY.Text = "导出放映表(Ctrl+F)";
            this.btnFY.UseVisualStyleBackColor = false;
            this.btnFY.Click += new System.EventHandler(this.放映表ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.lbInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(527, 24);
            this.panel1.TabIndex = 5;
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(11, 6);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(0, 12);
            this.lbInfo.TabIndex = 0;
            // 
            // Frm_MovieListGet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(527, 186);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnFY);
            this.Controls.Add(this.btnCW);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Frm_MovieListGet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "影院排片拉取";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmToday;
        private System.Windows.Forms.ToolStripMenuItem 导出ExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 场务表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tlsmFY;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripMenuItem tsmNex;
        private System.Windows.Forms.Button btnCW;
        private System.Windows.Forms.Button btnFY;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbInfo;
    }
}