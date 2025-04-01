using AntdUI;
using System;
using System.IO;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MaliciousCheck
{
    public partial class Form4 : Form
    {
        AntList<StartUp> ScanResultList = new AntList<StartUp>();
        Function function = new Function();
        string[] Files = null;
        public Form4()
        {
            InitializeComponent();
            ScanResult.Columns = new ColumnCollection
            {
                new Column("Sign", "扫描时间",ColumnAlign.Center),
                new Column("Name", "文件名", ColumnAlign.Center),
                new Column("Malicious", "威胁", ColumnAlign.Center),
            };
            ScanResult.Binding(ScanResultList);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Files == null)
            {
                MessageBox.Show("请选择文件");
                return;
            }
            foreach (string file in Files)
            {
                string Time = DateTime.Now.ToString();
                string FileName = Path.GetFileName(file);
                bool Malicious = function.YaraScan(null,Program.YaraRule,file);
                ScanResultList.Add(new StartUp
                { 
                    Sign = Time,
                    Name = FileName,
                    Malicious = new CellTag[1]{
                        Malicious?
                        new CellTag("危险", TTypeMini.Error):
                        new CellTag("安全", TTypeMini.Success)
                    }
                });
            }
            new AntdUI.Message.Config(this, "扫描完成", TType.Success)
            {
                ShowInWindow = true,
                ClickClose = false,
                AutoClose = 2
            }.open();
        }
        private void uploadDragger1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "所有文件 (*.*)|*.*";
            openFileDialog.Title = "选择文件";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Files = openFileDialog.FileNames;
                if (Files != null)
                {
                    int num = 0;
                    uploadDragger1.Text = "";
                    foreach (string file in Files)
                    {
                        if (num >= 2)
                        {
                            uploadDragger1.Text += "...";
                            break;
                        }
                        uploadDragger1.Text += $"{Path.GetFileName(file)}、";
                        num++;
                    }
                }
            }
        }
        private void uploadDragger1_DragChanged(object sender, StringsEventArgs e)
        {
            Files = e.Value;
            if (Files != null)
            {
                int num = 0;
                uploadDragger1.Text = "";
                foreach (string file in Files)
                {
                    if (num >= 2)
                    {
                        uploadDragger1.Text += "...";
                        break;
                    }
                    uploadDragger1.Text += $"{Path.GetFileName(file)}、";
                    num++;
                }
            }
        }
    }
}
