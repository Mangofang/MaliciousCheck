namespace MaliciousCheck
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.pageHeader1 = new AntdUI.PageHeader();
            this.panel1 = new AntdUI.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.divider1 = new AntdUI.Divider();
            this.uploadDragger1 = new AntdUI.UploadDragger();
            this.panel2 = new AntdUI.Panel();
            this.ScanResult = new AntdUI.Table();
            this.button5 = new AntdUI.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.pageHeader1.Size = new System.Drawing.Size(512, 32);
            this.pageHeader1.TabIndex = 1;
            this.pageHeader1.Text = "MaliciousCheck → Yara扫描";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.uploadDragger1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.divider1);
            this.panel1.Location = new System.Drawing.Point(9, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(493, 185);
            this.panel1.TabIndex = 2;
            this.panel1.Text = "panel1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "选择文件";
            // 
            // divider1
            // 
            this.divider1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.divider1.ColorSplit = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(188)))), ((int)(((byte)(188)))));
            this.divider1.Cursor = System.Windows.Forms.Cursors.Default;
            this.divider1.Location = new System.Drawing.Point(0, 29);
            this.divider1.Name = "divider1";
            this.divider1.Orientation = AntdUI.TOrientation.Left;
            this.divider1.Size = new System.Drawing.Size(490, 23);
            this.divider1.TabIndex = 2;
            this.divider1.Text = "";
            // 
            // uploadDragger1
            // 
            this.uploadDragger1.Location = new System.Drawing.Point(7, 58);
            this.uploadDragger1.Name = "uploadDragger1";
            this.uploadDragger1.Size = new System.Drawing.Size(478, 85);
            this.uploadDragger1.TabIndex = 4;
            this.uploadDragger1.Text = "拖入或点击选择文件";
            this.uploadDragger1.DragChanged += new AntdUI.IControl.DragEventHandler(this.uploadDragger1_DragChanged);
            this.uploadDragger1.Click += new System.EventHandler(this.uploadDragger1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ScanResult);
            this.panel2.Location = new System.Drawing.Point(9, 228);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(493, 156);
            this.panel2.TabIndex = 3;
            this.panel2.Text = "panel2";
            // 
            // ScanResult
            // 
            this.ScanResult.Location = new System.Drawing.Point(7, 6);
            this.ScanResult.Name = "ScanResult";
            this.ScanResult.Size = new System.Drawing.Size(478, 143);
            this.ScanResult.TabIndex = 1;
            this.ScanResult.Tag = "";
            // 
            // button5
            // 
            this.button5.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(119)))), ((int)(((byte)(255)))));
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button5.Location = new System.Drawing.Point(7, 146);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(478, 36);
            this.button5.TabIndex = 18;
            this.button5.Text = "扫描（使用默认Yara）";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 396);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pageHeader1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.PageHeader pageHeader1;
        private AntdUI.Panel panel1;
        private System.Windows.Forms.Label label1;
        private AntdUI.Divider divider1;
        private AntdUI.UploadDragger uploadDragger1;
        private AntdUI.Panel panel2;
        private AntdUI.Table ScanResult;
        private AntdUI.Button button5;
    }
}