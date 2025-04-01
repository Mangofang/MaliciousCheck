using AntdUI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MaliciousCheck
{
    public partial class Form3 : Form
    {
        Function function = new Function();
        string[] MaliciousIp = null;
        AntList<Log> BanedIpsList = new AntList<Log>();
        string FirewallRuleName = "MaliciousCheckCreatedRule";
        public Form3()
        {
            InitializeComponent();
            BanedIpTable.Columns = new ColumnCollection
            {
                new Column("Sourceip", "已被禁止的Ip地址", ColumnAlign.Center),
            };
            BanedIpTable.Binding(BanedIpsList);
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            string[] BanedIps = function.GetFirewallRuleIPs(FirewallRuleName);
            MaliciousIp = function.DbScan("疑似密码爆破", 0, 200, true).ToArray();
            selectMultiple1.Items.AddRange(MaliciousIp);
            if (BanedIps != null)
            {
                selectMultiple2.Items.AddRange(BanedIps);
                foreach (string ip in BanedIps)
                {
                    BanedIpsList.Add(new Log
                    {
                        Sourceip = ip
                    });
                }
            }

        }
        private void FormUpdate()
        {
            string[] BanedIps = function.GetFirewallRuleIPs(FirewallRuleName);
            if (BanedIps != null)
            {
                selectMultiple2.Items.Clear();
                selectMultiple2.Items.AddRange(BanedIps);
                BanedIpsList.Clear();
                foreach (string ip in BanedIps)
                {
                    BanedIpsList.Add(new Log
                    {
                        Sourceip = ip
                    });
                }
            }
            else
            {
                BanedIpsList.Clear();
                selectMultiple2.Items.Clear();
                BanedIps = null;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            AntdUI.Spin.open(this, new AntdUI.Spin.Config
            {
                Back = Color.FromArgb(220, 147, 181, 207),
                Color = Style.Db.Primary,
                Radius = 6,
                Fore = Color.Black,
                Font = new Font("Microsoft YaHei UI", 14f)
            }, delegate (AntdUI.Spin.Config config)
            {
                config.Text = "正在添加...";
                if (string.IsNullOrEmpty(selectMultiple1.Text))
                {
                    string[] Ips = Array.ConvertAll(selectMultiple1.SelectedValue, item => item.ToString());
                    if (Ips.Length == 0)
                    {
                        MessageBox.Show("请选择要禁止的Ip地址");
                        return;
                    }
                    function.ActionFirewallRule(FirewallRuleName, Ips, "add");
                    FormUpdate();
                }
                else
                {
                    string[] Ips = { selectMultiple1.Text };
                    function.ActionFirewallRule(FirewallRuleName, Ips, "add");
                    FormUpdate();
                }
            }, delegate
            {
                new AntdUI.Message.Config(this, "已添加", TType.Success)
                {
                    ShowInWindow = true,
                    ClickClose = false,
                    AutoClose = 2
                }.open();
                selectMultiple1.Text = "";
                selectMultiple1.SelectedValue = new object[] { };
            });
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AntdUI.Spin.open(this, new AntdUI.Spin.Config
            {
                Back = Color.FromArgb(220, 147, 181, 207),
                Color = Style.Db.Primary,
                Radius = 6,
                Fore = Color.Black,
                Font = new Font("Microsoft YaHei UI", 14f)
            }, delegate (AntdUI.Spin.Config config)
            {
                config.Text = "正在删除...";
                if (string.IsNullOrEmpty(selectMultiple2.Text))
                {
                    string[] Ips = Array.ConvertAll(selectMultiple2.SelectedValue, item => item.ToString());
                    if (Ips.Length == 0)
                    {
                        MessageBox.Show("请选择要解除禁封的Ip地址");
                        return;
                    }
                    function.ActionFirewallRule(FirewallRuleName, Ips, "remove");
                    FormUpdate();
                }
                else
                {
                    string[] Ips = { selectMultiple1.Text };
                    function.ActionFirewallRule(FirewallRuleName, Ips, "remove");
                    FormUpdate();
                }
            }, delegate
            {
                new AntdUI.Message.Config(this, "已删除", TType.Success)
                {
                    ShowInWindow = true,
                    ClickClose = false,
                    AutoClose = 2
                }.open();
                selectMultiple2.Text = "";
                selectMultiple2.SelectedValue = new object[] { };
            });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            function.ActionFirewallRule(FirewallRuleName, MaliciousIp, "add");
            FormUpdate();
            new AntdUI.Message.Config(this, $"已禁止 {MaliciousIp.Length} 个IP", TType.Success)
            {
                ShowInWindow = true,
                ClickClose = false,
                AutoClose = 2
            }.open();
        }
    }
}
