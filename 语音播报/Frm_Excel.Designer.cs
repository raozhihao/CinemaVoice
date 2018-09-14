namespace 语音播报
{
    partial class Frm_Excel
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelPIc = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnShowExcelStyle = new System.Windows.Forms.Button();
            this.btnEn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.panelMain.Controls.Add(this.panel1);
            this.panelMain.Controls.Add(this.btnShowExcelStyle);
            this.panelMain.Controls.Add(this.richTextBox1);
            this.panelMain.Controls.Add(this.panelPIc);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(285, 350);
            this.panelMain.TabIndex = 12;
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
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBox1.Location = new System.Drawing.Point(0, 194);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(285, 62);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = "";
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.Black;
            this.btnExcel.FlatAppearance.BorderSize = 0;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Location = new System.Drawing.Point(12, 14);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(100, 30);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Text = "打开";
            this.btnExcel.UseVisualStyleBackColor = false;
            // 
            // btnShowExcelStyle
            // 
            this.btnShowExcelStyle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnShowExcelStyle.Location = new System.Drawing.Point(0, 314);
            this.btnShowExcelStyle.Name = "btnShowExcelStyle";
            this.btnShowExcelStyle.Size = new System.Drawing.Size(285, 36);
            this.btnShowExcelStyle.TabIndex = 12;
            this.btnShowExcelStyle.Text = "Excel源模板格式查看";
            this.btnShowExcelStyle.UseVisualStyleBackColor = true;
            // 
            // btnEn
            // 
            this.btnEn.BackColor = System.Drawing.Color.Black;
            this.btnEn.FlatAppearance.BorderSize = 0;
            this.btnEn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEn.ForeColor = System.Drawing.Color.White;
            this.btnEn.Location = new System.Drawing.Point(173, 14);
            this.btnEn.Name = "btnEn";
            this.btnEn.Size = new System.Drawing.Size(100, 30);
            this.btnEn.TabIndex = 13;
            this.btnEn.Text = "确定";
            this.btnEn.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEn);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 256);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 58);
            this.panel1.TabIndex = 13;
            // 
            // Frm_Excel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 350);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Excel";
            this.Text = "Frm_Excel";
            this.panelMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelPIc;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnShowExcelStyle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnEn;
    }
}