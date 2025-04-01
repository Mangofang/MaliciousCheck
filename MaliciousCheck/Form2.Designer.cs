namespace MaliciousCheck
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            AntdUI.Tabs.StyleCard styleCard1 = new AntdUI.Tabs.StyleCard();
            this.pageHeader1 = new AntdUI.PageHeader();
            this.tabPage15 = new AntdUI.TabPage();
            this.PowerShellLog = new AntdUI.Table();
            this.tabPage13 = new AntdUI.TabPage();
            this.ServiceCreateLog = new AntdUI.Table();
            this.tabPage1 = new AntdUI.TabPage();
            this.button5 = new AntdUI.Button();
            this.checkbox1 = new AntdUI.Checkbox();
            this.SecSignInput = new AntdUI.Input();
            this.label11 = new AntdUI.Label();
            this.PasswordAttackRadio = new AntdUI.Radio();
            this.button4 = new AntdUI.Button();
            this.button2 = new AntdUI.Button();
            this.button1 = new AntdUI.Button();
            this.button3 = new AntdUI.Button();
            this.label10 = new AntdUI.Label();
            this.label9 = new AntdUI.Label();
            this.RDPLoginRadio = new AntdUI.Radio();
            this.LoginFailRadio = new AntdUI.Radio();
            this.LoginSuccessRadio = new AntdUI.Radio();
            this.SecLog = new AntdUI.Table();
            this.SecEnvenIdInput = new AntdUI.Input();
            this.label8 = new AntdUI.Label();
            this.SecKeywordInput = new AntdUI.Input();
            this.label7 = new AntdUI.Label();
            this.label6 = new AntdUI.Label();
            this.SecTimeInput = new AntdUI.DatePickerRange();
            this.SecLoginTypeInput = new AntdUI.Input();
            this.label5 = new AntdUI.Label();
            this.SecLocalNameInput = new AntdUI.Input();
            this.label3 = new AntdUI.Label();
            this.SecSourceNameInput = new AntdUI.Input();
            this.label2 = new AntdUI.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.divider1 = new AntdUI.Divider();
            this.SecSourceIpInput = new AntdUI.Input();
            this.label4 = new AntdUI.Label();
            this.tabs1 = new AntdUI.Tabs();
            this.tabPage2 = new AntdUI.TabPage();
            this.tabPage15.SuspendLayout();
            this.tabPage13.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabs1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageHeader1
            // 
            this.pageHeader1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pageHeader1.DividerShow = true;
            this.pageHeader1.Icon = ((System.Drawing.Image)(resources.GetObject("pageHeader1.Icon")));
            this.pageHeader1.Location = new System.Drawing.Point(0, 0);
            this.pageHeader1.Margin = new System.Windows.Forms.Padding(2);
            this.pageHeader1.MaximizeBox = false;
            this.pageHeader1.Name = "pageHeader1";
            this.pageHeader1.ShowButton = true;
            this.pageHeader1.ShowIcon = true;
            this.pageHeader1.Size = new System.Drawing.Size(893, 32);
            this.pageHeader1.TabIndex = 1;
            this.pageHeader1.Text = "MaliciousCheck → 日志分析";
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.PowerShellLog);
            this.tabPage15.Location = new System.Drawing.Point(-870, -462);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Size = new System.Drawing.Size(870, 462);
            this.tabPage15.TabIndex = 6;
            this.tabPage15.Text = "PowerShell记录（Windows事件查看器）";
            // 
            // PowerShellLog
            // 
            this.PowerShellLog.Location = new System.Drawing.Point(4, 3);
            this.PowerShellLog.Name = "PowerShellLog";
            this.PowerShellLog.Size = new System.Drawing.Size(862, 456);
            this.PowerShellLog.TabIndex = 66;
            this.PowerShellLog.Tag = "";
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.ServiceCreateLog);
            this.tabPage13.Location = new System.Drawing.Point(-870, -462);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Size = new System.Drawing.Size(870, 462);
            this.tabPage13.TabIndex = 4;
            this.tabPage13.Text = "服务创建";
            // 
            // ServiceCreateLog
            // 
            this.ServiceCreateLog.Location = new System.Drawing.Point(4, 3);
            this.ServiceCreateLog.Name = "ServiceCreateLog";
            this.ServiceCreateLog.Size = new System.Drawing.Size(862, 456);
            this.ServiceCreateLog.TabIndex = 68;
            this.ServiceCreateLog.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.checkbox1);
            this.tabPage1.Controls.Add(this.SecSignInput);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.PasswordAttackRadio);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.RDPLoginRadio);
            this.tabPage1.Controls.Add(this.LoginFailRadio);
            this.tabPage1.Controls.Add(this.LoginSuccessRadio);
            this.tabPage1.Controls.Add(this.SecLog);
            this.tabPage1.Controls.Add(this.SecEnvenIdInput);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.SecKeywordInput);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.SecTimeInput);
            this.tabPage1.Controls.Add(this.SecLoginTypeInput);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.SecLocalNameInput);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.SecSourceNameInput);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.divider1);
            this.tabPage1.Controls.Add(this.SecSourceIpInput);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(3, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(870, 462);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "安全日志";
            // 
            // button5
            // 
            this.button5.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button5.Location = new System.Drawing.Point(816, 55);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(51, 68);
            this.button5.TabIndex = 81;
            this.button5.Text = "防火墙\r\n禁封";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkbox1
            // 
            this.checkbox1.Location = new System.Drawing.Point(764, 137);
            this.checkbox1.Name = "checkbox1";
            this.checkbox1.Size = new System.Drawing.Size(103, 22);
            this.checkbox1.TabIndex = 80;
            this.checkbox1.Text = "IP仅保留一条";
            this.checkbox1.CheckedChanged += new AntdUI.BoolEventHandler(this.checkbox1_CheckedChanged);
            // 
            // SecSignInput
            // 
            this.SecSignInput.Location = new System.Drawing.Point(280, 129);
            this.SecSignInput.Name = "SecSignInput";
            this.SecSignInput.Size = new System.Drawing.Size(142, 36);
            this.SecSignInput.TabIndex = 79;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(221, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 23);
            this.label11.TabIndex = 78;
            this.label11.Text = "备注";
            // 
            // PasswordAttackRadio
            // 
            this.PasswordAttackRadio.Location = new System.Drawing.Point(683, 136);
            this.PasswordAttackRadio.Name = "PasswordAttackRadio";
            this.PasswordAttackRadio.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.PasswordAttackRadio.Size = new System.Drawing.Size(75, 23);
            this.PasswordAttackRadio.TabIndex = 77;
            this.PasswordAttackRadio.Text = "密码爆破";
            this.PasswordAttackRadio.CheckedChanged += new AntdUI.BoolEventHandler(this.PasswordAttackRadio_CheckedChanged);
            // 
            // button4
            // 
            this.button4.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button4.Location = new System.Drawing.Point(667, 55);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 31);
            this.button4.TabIndex = 76;
            this.button4.Text = "下一页";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.Location = new System.Drawing.Point(745, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 31);
            this.button2.TabIndex = 75;
            this.button2.Text = "清除";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(745, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 31);
            this.button1.TabIndex = 74;
            this.button1.Text = "检索";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button3.Location = new System.Drawing.Point(667, 93);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 31);
            this.button3.TabIndex = 73;
            this.button3.Text = "上一页";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.label10.Location = new System.Drawing.Point(104, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(269, 23);
            this.label10.TabIndex = 72;
            this.label10.Text = "0";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            this.label9.Location = new System.Drawing.Point(46, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 23);
            this.label9.TabIndex = 71;
            this.label9.Text = "日志数量：";
            // 
            // RDPLoginRadio
            // 
            this.RDPLoginRadio.Location = new System.Drawing.Point(602, 136);
            this.RDPLoginRadio.Name = "RDPLoginRadio";
            this.RDPLoginRadio.RightToLeft = System.Windows.Forms.RightToLeft.Inherit;
            this.RDPLoginRadio.Size = new System.Drawing.Size(75, 23);
            this.RDPLoginRadio.TabIndex = 68;
            this.RDPLoginRadio.Text = "RDP登录";
            this.RDPLoginRadio.CheckedChanged += new AntdUI.BoolEventHandler(this.RDPLoginRadio_CheckedChanged);
            // 
            // LoginFailRadio
            // 
            this.LoginFailRadio.Location = new System.Drawing.Point(521, 136);
            this.LoginFailRadio.Name = "LoginFailRadio";
            this.LoginFailRadio.Size = new System.Drawing.Size(75, 23);
            this.LoginFailRadio.TabIndex = 67;
            this.LoginFailRadio.Text = "登录失败";
            this.LoginFailRadio.CheckedChanged += new AntdUI.BoolEventHandler(this.LoginFailRadio_CheckedChanged);
            // 
            // LoginSuccessRadio
            // 
            this.LoginSuccessRadio.Location = new System.Drawing.Point(440, 136);
            this.LoginSuccessRadio.Name = "LoginSuccessRadio";
            this.LoginSuccessRadio.Size = new System.Drawing.Size(75, 23);
            this.LoginSuccessRadio.TabIndex = 66;
            this.LoginSuccessRadio.Text = "登录成功";
            this.LoginSuccessRadio.CheckedChanged += new AntdUI.BoolEventHandler(this.LoginSuccessRadio_CheckedChanged);
            // 
            // SecLog
            // 
            this.SecLog.Location = new System.Drawing.Point(5, 165);
            this.SecLog.Name = "SecLog";
            this.SecLog.Size = new System.Drawing.Size(862, 294);
            this.SecLog.TabIndex = 65;
            this.SecLog.Tag = "";
            // 
            // SecEnvenIdInput
            // 
            this.SecEnvenIdInput.Location = new System.Drawing.Point(529, 93);
            this.SecEnvenIdInput.Name = "SecEnvenIdInput";
            this.SecEnvenIdInput.Size = new System.Drawing.Size(140, 36);
            this.SecEnvenIdInput.TabIndex = 61;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(484, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 23);
            this.label8.TabIndex = 60;
            this.label8.Text = "事件ID";
            // 
            // SecKeywordInput
            // 
            this.SecKeywordInput.Location = new System.Drawing.Point(529, 50);
            this.SecKeywordInput.Name = "SecKeywordInput";
            this.SecKeywordInput.Size = new System.Drawing.Size(140, 36);
            this.SecKeywordInput.TabIndex = 59;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(484, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 23);
            this.label7.TabIndex = 58;
            this.label7.Text = "关键字";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(223, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 23);
            this.label6.TabIndex = 57;
            this.label6.Text = "时间范围";
            // 
            // SecTimeInput
            // 
            this.SecTimeInput.Location = new System.Drawing.Point(280, 93);
            this.SecTimeInput.Name = "SecTimeInput";
            this.SecTimeInput.Size = new System.Drawing.Size(198, 36);
            this.SecTimeInput.SuffixText = "";
            this.SecTimeInput.TabIndex = 56;
            // 
            // SecLoginTypeInput
            // 
            this.SecLoginTypeInput.Location = new System.Drawing.Point(280, 51);
            this.SecLoginTypeInput.Name = "SecLoginTypeInput";
            this.SecLoginTypeInput.Size = new System.Drawing.Size(198, 36);
            this.SecLoginTypeInput.TabIndex = 53;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(223, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 23);
            this.label5.TabIndex = 52;
            this.label5.Text = "登录类型";
            // 
            // SecLocalNameInput
            // 
            this.SecLocalNameInput.Location = new System.Drawing.Point(73, 129);
            this.SecLocalNameInput.Name = "SecLocalNameInput";
            this.SecLocalNameInput.Size = new System.Drawing.Size(142, 36);
            this.SecLocalNameInput.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(5, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.TabIndex = 50;
            this.label3.Text = "目的用户名";
            // 
            // SecSourceNameInput
            // 
            this.SecSourceNameInput.Location = new System.Drawing.Point(58, 93);
            this.SecSourceNameInput.Name = "SecSourceNameInput";
            this.SecSourceNameInput.Size = new System.Drawing.Size(157, 36);
            this.SecSourceNameInput.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(5, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 23);
            this.label2.TabIndex = 48;
            this.label2.Text = "源登录名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 47;
            this.label1.Text = "筛选";
            // 
            // divider1
            // 
            this.divider1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.divider1.ColorSplit = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.divider1.Cursor = System.Windows.Forms.Cursors.Default;
            this.divider1.Location = new System.Drawing.Point(-3, 31);
            this.divider1.Name = "divider1";
            this.divider1.Orientation = AntdUI.TOrientation.Left;
            this.divider1.Size = new System.Drawing.Size(876, 23);
            this.divider1.TabIndex = 46;
            this.divider1.Text = "";
            // 
            // SecSourceIpInput
            // 
            this.SecSourceIpInput.Location = new System.Drawing.Point(46, 51);
            this.SecSourceIpInput.Name = "SecSourceIpInput";
            this.SecSourceIpInput.Size = new System.Drawing.Size(169, 36);
            this.SecSourceIpInput.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(5, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 23);
            this.label4.TabIndex = 44;
            this.label4.Text = "源地址";
            // 
            // tabs1
            // 
            this.tabs1.BackColor = System.Drawing.Color.White;
            this.tabs1.Controls.Add(this.tabPage1);
            this.tabs1.Controls.Add(this.tabPage13);
            this.tabs1.Controls.Add(this.tabPage15);
            this.tabs1.Controls.Add(this.tabPage2);
            this.tabs1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabs1.Location = new System.Drawing.Point(8, 40);
            this.tabs1.Name = "tabs1";
            this.tabs1.Pages.Add(this.tabPage1);
            this.tabs1.Pages.Add(this.tabPage13);
            this.tabs1.Pages.Add(this.tabPage15);
            this.tabs1.Pages.Add(this.tabPage2);
            this.tabs1.Size = new System.Drawing.Size(876, 490);
            styleCard1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(159)))), ((int)(((byte)(159)))));
            styleCard1.Gap = 8;
            this.tabs1.Style = styleCard1;
            this.tabs1.TabIndex = 44;
            this.tabs1.Text = "tabs1";
            this.tabs1.Type = AntdUI.TabType.Card;
            this.tabs1.SelectedIndexChanged += new AntdUI.IntEventHandler(this.tabs1_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(-870, -462);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(870, 462);
            this.tabPage2.TabIndex = 7;
            this.tabPage2.Text = "PowerShell记录（History）";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(891, 538);
            this.Controls.Add(this.tabs1);
            this.Controls.Add(this.pageHeader1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabPage15.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabs1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.PageHeader pageHeader1;
        private AntdUI.TabPage tabPage15;
        private AntdUI.TabPage tabPage13;
        private AntdUI.TabPage tabPage1;
        private AntdUI.Button button5;
        private AntdUI.Checkbox checkbox1;
        private AntdUI.Input SecSignInput;
        private AntdUI.Label label11;
        private AntdUI.Radio PasswordAttackRadio;
        private AntdUI.Button button4;
        private AntdUI.Button button2;
        private AntdUI.Button button1;
        private AntdUI.Button button3;
        private AntdUI.Label label10;
        private AntdUI.Label label9;
        private AntdUI.Radio RDPLoginRadio;
        private AntdUI.Radio LoginFailRadio;
        private AntdUI.Radio LoginSuccessRadio;
        private AntdUI.Table SecLog;
        private AntdUI.Input SecEnvenIdInput;
        private AntdUI.Label label8;
        private AntdUI.Input SecKeywordInput;
        private AntdUI.Label label7;
        private AntdUI.Label label6;
        private AntdUI.DatePickerRange SecTimeInput;
        private AntdUI.Input SecLoginTypeInput;
        private AntdUI.Label label5;
        private AntdUI.Input SecLocalNameInput;
        private AntdUI.Label label3;
        private AntdUI.Input SecSourceNameInput;
        private AntdUI.Label label2;
        private System.Windows.Forms.Label label1;
        private AntdUI.Divider divider1;
        private AntdUI.Input SecSourceIpInput;
        private AntdUI.Label label4;
        private AntdUI.Tabs tabs1;
        private AntdUI.Table PowerShellLog;
        private AntdUI.TabPage tabPage2;
        private AntdUI.Table ServiceCreateLog;
    }
}