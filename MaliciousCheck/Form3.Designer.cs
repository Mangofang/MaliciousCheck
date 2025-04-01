namespace MaliciousCheck
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.pageHeader1 = new AntdUI.PageHeader();
            this.panel1 = new AntdUI.Panel();
            this.button2 = new AntdUI.Button();
            this.selectMultiple2 = new AntdUI.SelectMultiple();
            this.label1 = new AntdUI.Label();
            this.selectMultiple1 = new AntdUI.SelectMultiple();
            this.button1 = new AntdUI.Button();
            this.button4 = new AntdUI.Button();
            this.label4 = new AntdUI.Label();
            this.BanedIpTable = new AntdUI.Table();
            this.panel1.SuspendLayout();
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
            this.pageHeader1.Size = new System.Drawing.Size(517, 32);
            this.pageHeader1.TabIndex = 2;
            this.pageHeader1.Text = "MaliciousCheck → 防火墙";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.selectMultiple2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.selectMultiple1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.BanedIpTable);
            this.panel1.Location = new System.Drawing.Point(5, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 292);
            this.panel1.TabIndex = 3;
            this.panel1.Text = "panel1";
            // 
            // button2
            // 
            this.button2.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.Location = new System.Drawing.Point(238, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 38);
            this.button2.TabIndex = 82;
            this.button2.Text = "从防火墙禁封列表移除";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // selectMultiple2
            // 
            this.selectMultiple2.Location = new System.Drawing.Point(58, 39);
            this.selectMultiple2.Name = "selectMultiple2";
            this.selectMultiple2.Size = new System.Drawing.Size(174, 38);
            this.selectMultiple2.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 23);
            this.label1.TabIndex = 80;
            this.label1.Text = "禁止的IP";
            // 
            // selectMultiple1
            // 
            this.selectMultiple1.Location = new System.Drawing.Point(58, 2);
            this.selectMultiple1.Name = "selectMultiple1";
            this.selectMultiple1.Size = new System.Drawing.Size(174, 38);
            this.selectMultiple1.TabIndex = 79;
            // 
            // button1
            // 
            this.button1.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(387, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 38);
            this.button1.TabIndex = 78;
            this.button1.Text = "一键添加疑似IP";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button4.Location = new System.Drawing.Point(238, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(143, 38);
            this.button4.TabIndex = 77;
            this.button4.Text = "添加到防火墙禁封列表";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(10, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 23);
            this.label4.TabIndex = 67;
            this.label4.Text = "IP地址";
            // 
            // BanedIpTable
            // 
            this.BanedIpTable.Location = new System.Drawing.Point(7, 83);
            this.BanedIpTable.Name = "BanedIpTable";
            this.BanedIpTable.Size = new System.Drawing.Size(494, 204);
            this.BanedIpTable.TabIndex = 66;
            this.BanedIpTable.Tag = "";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 336);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pageHeader1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.PageHeader pageHeader1;
        private AntdUI.Panel panel1;
        private AntdUI.Table BanedIpTable;
        private AntdUI.Label label4;
        private AntdUI.Button button4;
        private AntdUI.Button button1;
        private AntdUI.SelectMultiple selectMultiple1;
        private AntdUI.Button button2;
        private AntdUI.SelectMultiple selectMultiple2;
        private AntdUI.Label label1;
    }
}