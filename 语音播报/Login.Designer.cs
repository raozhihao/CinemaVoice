﻿namespace 语音播报
{
    partial class Login
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
            this.btnExcel = new System.Windows.Forms.Button();
            this.txtExcel = new System.Windows.Forms.TextBox();
            this.rdExcel = new System.Windows.Forms.RadioButton();
            this.rdAPI = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(474, 32);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 0;
            this.btnExcel.Text = "打开";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // txtExcel
            // 
            this.txtExcel.Enabled = false;
            this.txtExcel.Location = new System.Drawing.Point(144, 32);
            this.txtExcel.Name = "txtExcel";
            this.txtExcel.Size = new System.Drawing.Size(297, 21);
            this.txtExcel.TabIndex = 2;
            // 
            // rdExcel
            // 
            this.rdExcel.AutoSize = true;
            this.rdExcel.Checked = true;
            this.rdExcel.Location = new System.Drawing.Point(23, 35);
            this.rdExcel.Name = "rdExcel";
            this.rdExcel.Size = new System.Drawing.Size(89, 16);
            this.rdExcel.TabIndex = 3;
            this.rdExcel.TabStop = true;
            this.rdExcel.Text = "设置Excel源";
            this.rdExcel.UseVisualStyleBackColor = true;
            this.rdExcel.CheckedChanged += new System.EventHandler(this.rdExcel_CheckedChanged);
            // 
            // rdAPI
            // 
            this.rdAPI.AutoSize = true;
            this.rdAPI.Location = new System.Drawing.Point(23, 91);
            this.rdAPI.Name = "rdAPI";
            this.rdAPI.Size = new System.Drawing.Size(77, 16);
            this.rdAPI.TabIndex = 3;
            this.rdAPI.Text = "使用API源";
            this.rdAPI.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEn);
            this.groupBox1.Controls.Add(this.rdAPI);
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.rdExcel);
            this.groupBox1.Controls.Add(this.txtExcel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 137);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置源";
            // 
            // btnEn
            // 
            this.btnEn.Location = new System.Drawing.Point(405, 76);
            this.btnEn.Name = "btnEn";
            this.btnEn.Size = new System.Drawing.Size(144, 42);
            this.btnEn.TabIndex = 4;
            this.btnEn.Text = "确定";
            this.btnEn.UseVisualStyleBackColor = true;
            this.btnEn.Click += new System.EventHandler(this.btnEn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 163);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "登陆设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox txtExcel;
        private System.Windows.Forms.RadioButton rdExcel;
        private System.Windows.Forms.RadioButton rdAPI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEn;
    }
}