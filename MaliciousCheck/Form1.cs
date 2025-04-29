using AntdUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Management;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MaliciousCheck
{
    public partial class Form1 : Form
    {
        Function function = new Function();
        Sundry sundry = new Sundry();
        Data data = new Data();
        Configuration configuration = new Configuration();

        AntList<StartUp> StartUpStartUpList = new AntList<StartUp>();
        AntList<StartUp> RegStartUpList = new AntList<StartUp>();
        AntList<StartUp> TaskStartUpList = new AntList<StartUp>();
        AntList<StartUp> ProcessStartUpList = new AntList<StartUp>();
        AntList<Hotfix> UserHotfixList = new AntList<Hotfix>();
        AntList<Hotfix> ConnectHotfies = new AntList<Hotfix>();
        AntList<Hotfix> KBHotfixList = new AntList<Hotfix>();

        int StartUpMaliciousCount = 0;
        int ConnectMaliciousCount = 0;
        int UserMaliciousCount = 0;
        int ProcessMaliciousCount = 0;
        int AllMaliciousCount = 0;

        string SystemInfo = null;
        string NormalYaraRule = null;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        public Form1()
        {
            InitializeComponent();
            configuration.InitializationConfig();
            InitializationConfigTabel();
            InitializationTable();
            CheckForIllegalCrossThreadCalls = false;
            SystemInfo = sundry.GetSystemInfo();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            SetForegroundWindow(handle);
            SystemMessage.Text = SystemInfo;
            AntdUI.Spin.open(this, new AntdUI.Spin.Config
            {
                Back = Color.FromArgb(220, 147, 181, 207),
                Color = Style.Db.Primary,
                Radius = 6,
                Fore = Color.Black,
                Font = new Font("Microsoft YaHei UI", 14f)
            }, delegate (AntdUI.Spin.Config config)
            {
                config.Text = "正在初始化程序...";
                string[] yarFiles = Directory.GetFiles(Environment.CurrentDirectory, "*.yc");
                foreach (string yarFile in yarFiles)
                {
                    select1.Items.Add(Path.GetFileName(yarFile));
                }
                NormalYaraRule = Program.YaraRule;
                select1.Text = NormalYaraRule;
                FristAddTable();
            }, delegate
            {
                new Notification.Config(this, "欢迎使用MaliciousCheck", "当前软件还在测试中，如果你在使用过程中有任何问题欢迎提交Issues", TType.Success, TAlignFrom.TR)
                {
                    Padding = new Size(24, 20),
                    CloseIcon = false,
                    Link = new Notification.ConfigLink("To Github ->", delegate
                    {
                        new AntdUI.Message.Config(this, "已复制链接", TType.Success)
                        {
                            ShowInWindow = true,
                            ClickClose = false,
                            AutoClose = 2
                        }.open();
                        Process.Start("https://github.com/Mangofang/MaliciousCheck");
                        Clipboard.SetDataObject("https://github.com/Mangofang/MaliciousCheck");
                        return true;
                    })
                }.open();
            });
            Thread Data_Syn = new Thread(() =>
            {
                while (true)
                {
                    AllMaliciousCount = StartUpMaliciousCount + ConnectMaliciousCount + UserMaliciousCount + ProcessMaliciousCount;
                    AllCountLab.Text = AllMaliciousCount.ToString();
                    UserCountLab.Text = UserMaliciousCount.ToString();
                    ConnectCountLab.Text = ConnectMaliciousCount.ToString();
                    StartUpCountLab.Text = StartUpMaliciousCount.ToString();
                    ProcessCountLab.Text = ProcessMaliciousCount.ToString();
                    Thread.Sleep(1000);
                }
            });

            Data_Syn.IsBackground = true;
            Data_Syn.Start();
        }
        private void InitializationConfigTabel()
        {
            input1.Text = Program.ChaiTinApiKey;
            input2.Text = Program.ThreatbookApiKey;
            switch1.Checked = Program.AutoCheckIP;
        }
        private void InitializationTable()
        {
            HotfixAbout.Columns = new ColumnCollection
            {
                new Column("ID", "编号",ColumnAlign.Center),
                new Column("CellLinks", "相关地址", ColumnAlign.Center)
            };
            StartUpAbout.Columns = new ColumnCollection
            {
                new Column("Name", "程序名",ColumnAlign.Center),
                new Column("Position", "路径", ColumnAlign.Center),
                new Column("CellTags", "签名", ColumnAlign.Center),
                new Column("CellBadge", "状态", ColumnAlign.Center),
                new Column("Malicious", "威胁", ColumnAlign.Center),
                new Column("CellLinks", "操作", ColumnAlign.Center)
                {
                    Fixed = true
                }
            };
            RegStartUpAbout.Columns = new ColumnCollection
            {
                new Column("Name", "程序名",ColumnAlign.Center),
                new Column("Position", "路径", ColumnAlign.Center),
                new Column("CellTags", "签名", ColumnAlign.Center),
                new Column("CellBadge", "状态", ColumnAlign.Center),
                new Column("Malicious", "威胁", ColumnAlign.Center),
                new Column("FullPosition", "完整路径(带参数)", ColumnAlign.Left),
                new Column("CellLinks", "操作", ColumnAlign.Center)
                {
                    Fixed = true
                },
            };
            TaskStartUpAbout.Columns = new ColumnCollection
            {
                new Column("Name", "程序名",ColumnAlign.Center),
                new Column("Position", "路径", ColumnAlign.Center),
                new Column("CellTags", "签名", ColumnAlign.Center),
                new Column("CellBadge", "状态", ColumnAlign.Center),
                new Column("Malicious", "威胁", ColumnAlign.Center),
                new Column("FullPosition", "完整路径(带参数)", ColumnAlign.Left),
                new Column("CellLinks", "操作", ColumnAlign.Center)
                {
                    Fixed = true
                },
            };
            UserAbout.Columns = new ColumnCollection
            {
                new Column("ID", "Name",ColumnAlign.Center),
                new Column("Describe", "描述", ColumnAlign.Center),
                new Column("CellTags", "威胁", ColumnAlign.Center),
            };
            ConnectAbout.Columns = new ColumnCollection
            {
                new Column("ID", "IP",ColumnAlign.Center),
                new Column("Pid", "Pid",ColumnAlign.Center),
                new Column("ProcessName", "进程名",ColumnAlign.Center),
                new Column("Describe", "地理位置", ColumnAlign.Center),
                new Column("CellTags", "威胁", ColumnAlign.Center),
                new Column("CellLinks", "操作", ColumnAlign.Center)
                {
                    Fixed = true
                }
            };
            ProcessAbout.Columns = new ColumnCollection
            {
                new Column("Pid", "Pid",ColumnAlign.Center),
                new Column("ProcessName", "进程名",ColumnAlign.Center),
                new Column("Position", "路径", ColumnAlign.Center),
                new Column("CellTags", "威胁", ColumnAlign.Center),
                new Column("CellLinks", "操作", ColumnAlign.Center)
                {
                    Fixed = true
                }
            };
        }
        private void AddStartUpFileToTable(AntdUI.Table table,List<string> StartUp,List<string> FullPath = null)
        {
            AntList<StartUp> StartUpList = null;
            switch (table.Name)
            {
                case "StartUpAbout":
                    StartUpList = StartUpStartUpList;
                    break;
                case "RegStartUpAbout":
                    StartUpList = RegStartUpList;
                    break;
                case "TaskStartUpAbout":
                    StartUpList = TaskStartUpList;
                    break;
            }
            int idx = 0;
            foreach(string path in StartUp)
            {
                if (File.Exists(path))
                {
                    SHA1 Hash = SHA1.Create();
                    using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        byte[] HashByte = Hash.ComputeHash(stream);
                        string HashString = BitConverter.ToString(HashByte).Replace("-", "");
                        bool FileHashInConfig = Program.CheckedFileHash.ContainsKey(HashString);
                        if (FileHashInConfig)
                        {
                            if (Program.CheckedFileHash[HashString] == "危险")
                            {
                                StartUpMaliciousCount += 1;
                            }
                        }
                        string SignText = null;
                        StartUpList.Add(new StartUp
                        {
                            Name = Path.GetFileName(path),
                            Position = new CellLink[1]
                            {
                                new CellLink(path, "点击复制"),
                            },
                            FullPosition = FullPath == null?
                            null : FullPath[idx],
                            CellBadge = FileHashInConfig ?
                            new CellBadge(TState.Success, "已测试") :
                            new CellBadge(TState.Default, "等待测试..."),

                            Malicious = new CellTag[1]
                            {
                                FileHashInConfig?
                                (Program.CheckedFileHash[HashString] == "危险"?
                                new CellTag("危险", TTypeMini.Error)
                                : Program.CheckedFileHash[HashString] == "可疑"?
                                new CellTag("可疑", TTypeMini.Warn)
                                : new CellTag("安全", TTypeMini.Success))
                                : new[] { ".vbs", ".bat" }.Contains(Path.GetExtension(path)) || new[] { "wscript.exe", "cmd.exe","ftp.exe" }.Contains(Path.GetFileName(path))?
                                new CellTag("可疑", TTypeMini.Warn)
                                :new CellTag("未知", TTypeMini.Primary)
                            },
                            CellLinks = new CellLink[2]
                            {
                                FileHashInConfig ?
                                new CellButton(Guid.NewGuid().ToString(), "查看报告", TTypeMini.Primary) :
                                new CellButton(Guid.NewGuid().ToString(), "上传", TTypeMini.Primary),
                                new CellButton(Guid.NewGuid().ToString(), "Yara扫描", TTypeMini.Primary)
                            },
                        });

                        try
                        {
                            X509Certificate cert = X509Certificate.CreateFromSignedFile(path);
                            SignText = cert.Subject.ToString();
                            string companyName = "未知厂商";
                            foreach (var key in data.SignDatas.Keys)
                            {
                                if (SignText.Contains(key))
                                {
                                    companyName = data.SignDatas[key];
                                    break;
                                }
                            }
                            if (sundry.CheckSign(path))
                            {
                                StartUpList[idx].CellTags = new CellTag[1]
                                {
                                    new CellTag(companyName, TTypeMini.Primary),
                                };
                            }
                            else
                            {
                                StartUpList[idx].CellTags = new CellTag[2]
                                {
                                    new CellTag(companyName, TTypeMini.Primary),
                                    new CellTag("无效签名", TTypeMini.Error),
                                };
                                StartUpList[idx].Malicious = new CellTag[1]
                                {
                                    new CellTag("存疑", TTypeMini.Warn),
                                };
                            }
                        }
                        catch (Exception ex)
                        {
                            StartUpList[idx].CellTags = new CellTag[1]
                            {
                                new CellTag("无签名", TTypeMini.Error),
                            };
                        }
                    }
                    idx++;
                }
            }
            table.Binding(StartUpList);
        }
        private void FristAddTable()
        {
            List<string> KBList = sundry.GetKBList(SystemInfo);
            Parallel.ForEach(KBList, KBName =>
            {
                KBHotfixList.Add(new Hotfix
                {
                    ID = KBName,
                    CellLinks = new CellLink[1]
                    {
                        new CellLink($"https://support.microsoft.com/help/{KBName}", $"https://support.microsoft.com/help/{KBName}")
                    },
                });
            });
            HotfixAbout.Binding(KBHotfixList);

            List<string> UserList = function.GetUserName();
            foreach (var (userName, idx) in UserList.Select((value, index) => (value, index)))
            {
                UserHotfixList.Add(new Hotfix
                {
                    ID = userName,
                    Describe = data.UserDatas.ContainsKey(userName) ? data.UserDatas[userName] : "未知用户",
                    CellTags = data.UserDatas.ContainsKey(userName) ? new CellTag[1]
                    {
                        new CellTag("正常", TTypeMini.Success),
                    } : new CellTag[1]
                    {
                        new CellTag("未知用户", TTypeMini.Primary),
                    },
                });
                if (userName.EndsWith("$"))
                {
                    UserMaliciousCount += 1;
                    UserHotfixList[idx].CellTags = new CellTag[1]
                    {
                        new CellTag("高危", TTypeMini.Error),
                    };
                }
            }
            UserAbout.Binding(UserHotfixList);

            ProcessStartInfo StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c netstat -ano",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            Process cmd = Process.Start(StartInfo);
            string Output = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();
            List<string> CheckIp = sundry.NetStatStringCope(Output);
            if (Program.ChaiTinApiKey != "")
            {
                if (!Program.AutoCheckIP)
                {
                    MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                    DialogResult d = MessageBox.Show(this,$"检测到已存在长亭APIKey，是否需要自动检测所有的IP威胁？({CheckIp.Count()}个IP)", "提示", mess);
                    if (d == DialogResult.OK)
                    {
                        var CheckIp_Result = function.ChaiTinIpCheck(CheckIp);
                        var ConnectHotfies = GenerateHotfixes(CheckIp, CheckIp_Result.SecureIps, CheckIp_Result.MaliciousIps, CheckIp_Result.FailIps);
                        ConnectAbout.Binding(ConnectHotfies);
                    }
                    else
                    {
                        var ConnectHotfies = GenerateHotfixes(CheckIp, null, null, null);
                        ConnectAbout.Binding(ConnectHotfies);
                    }
                }
            }
            else
            {
                var ConnectHotfies = GenerateHotfixes(CheckIp, null, null, null);
                ConnectAbout.Binding(ConnectHotfies);
            }
            AddStartUpFileToTable(StartUpAbout, sundry.GetStartMenuItem());
            AddStartUpFileToTable(RegStartUpAbout, sundry.GetAutoRunReg().Path, sundry.GetAutoRunReg().FullPath);
            AddStartUpFileToTable(TaskStartUpAbout, sundry.GetTaskschdItem().TaskschdPath,sundry.GetTaskschdItem().FullTaskschdPath);

            Process[] processes = Process.GetProcesses();
            Parallel.ForEach(processes, process =>
            {
                string query = $"SELECT ExecutablePath FROM Win32_Process WHERE ProcessId = {process.Id.ToString()}";
                string executablePath = null;
                try
                {
                    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
                    {
                        foreach (ManagementObject obj in searcher.Get())
                        {
                            executablePath = obj["ExecutablePath"]?.ToString();
                        }
                    }
                }
                catch { }
                ProcessStartUpList.Add(new StartUp
                {
                    Pid = process.Id.ToString(),
                    ProcessName = process.ProcessName,
                    Position = new CellLink[1]
                    {
                        string.IsNullOrEmpty(executablePath) ?
                        new CellLink("", "无路径") :
                        new CellLink(executablePath, "点击复制"),
                    },
                    Malicious = new CellTag[1]
                    {
                        new CellTag("待检测", TTypeMini.Primary),
                    },
                    CellLinks = new CellLink[1]
                    {
                        new CellButton(Guid.NewGuid().ToString(), "Yara扫描", TTypeMini.Primary)
                    },
                });
            });
            ProcessAbout.Binding(ProcessStartUpList);
        }
        private AntList<Hotfix> GenerateHotfixes(IEnumerable<string> CheckIp,
                                         Dictionary<string, string> SecureIps,
                                         Dictionary<string, string> MaliciousIps,
                                         Dictionary<string, string> FailIps)
        {
            foreach (var (ip, idx) in CheckIp.Select((value, index) => (value, index)))
            {
                string position = "未知位置";
                if (SecureIps != null && SecureIps.ContainsKey(ip))
                {
                    position = SecureIps[ip];
                }
                else if (MaliciousIps != null && MaliciousIps.ContainsKey(ip))
                {
                    position = MaliciousIps[ip];
                }
                else if (FailIps != null && FailIps.ContainsKey(ip))
                {
                    position = FailIps[ip];
                }
                if (MaliciousIps != null && MaliciousIps.ContainsKey(ip))
                {
                    ConnectMaliciousCount += 1;
                }
                string Pid = sundry.GetPidFormIP(ip);
                try
                {
                    ConnectHotfies.Add(new Hotfix
                    {
                        ID = ip,
                        Describe = position,
                        Pid = Pid,
                        ProcessName = Process.GetProcessById(int.Parse(Pid)).ProcessName,
                        CellTags = MaliciousIps != null && MaliciousIps.ContainsKey(ip)
                        ? new CellTag[1] { new CellTag("高危", TTypeMini.Error) }
                        : MaliciousIps == null
                          ? new CellTag[1] { new CellTag("未知", TTypeMini.Primary) }
                          : new CellTag[1] { new CellTag("正常", TTypeMini.Success) },
                        CellLinks = new CellLink[1]
                    {
                              new CellButton(Guid.NewGuid().ToString(),
                              MaliciousIps != null && MaliciousIps.ContainsKey(ip) ? "重新验证" : "验证",
                              TTypeMini.Primary)
                    }
                    });
                }
                catch { Application.Restart(); }
            }
            return ConnectHotfies;
        }
        private void table1_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            string buttontext = e.Btn.Text;

            if (!(e.Record is Hotfix hotfix))
            {
                return;
            }
            if (buttontext.Contains("https://"))
            {
                new AntdUI.Message.Config(this, "已复制", TType.Success)
                {
                    ShowInWindow = true,
                    ClickClose = false,
                    AutoClose = 2
                }.open();
                Clipboard.SetDataObject(buttontext);
            }
        }
        private void StartUpAbout_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            StartUpAbout_Click(e, "StarpUp");
        }
        private void RegStartUpAbout_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            StartUpAbout_Click(e, "Reg");
        }
        private void TaskStartUpAbout_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            StartUpAbout_Click(e, "Task");
        }
        private void ConnectAbout_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            if (Program.ChaiTinApiKey == "")
            {
                new AntdUI.Message.Config(this, "未配置ApiKey", TType.Error)
                {
                    ShowInWindow = true,
                    ClickClose = false,
                    AutoClose = 2
                }.open();
                return;
            }
            string buttontext = e.Btn.Text;
            object record = e.Record;
            Hotfix Hotfies_ = record as Hotfix;
            if (!(record is Hotfix Hotfixs))
            {
                return;
            }
            if (buttontext.Contains("验证"))
            {
                new AntdUI.Message.Config(this, "正在验证...", TType.Info)
                {
                    ShowInWindow = true,
                    ClickClose = false,
                    AutoClose = 2
                }.open();
                var vp = function.ChaiTinIpCheck(Hotfies_.ID);
                string ip = vp.ip;
                string position = vp.position;
                string state = vp.state;
                if (state == "威胁") { ConnectMaliciousCount += 1; }
                int idx = 0;
                foreach (var Hotfix in ConnectHotfies)
                {
                    if (Hotfix.ID == Hotfixs.ID)
                    {
                        ConnectHotfies[idx].Describe = position;
                        ConnectHotfies[idx].CellTags = state != null && state == "威胁"
                        ? new CellTag[1] { new CellTag("高危", TTypeMini.Error) }
                        : state == "未知"
                        ? new CellTag[1] { new CellTag("未知", TTypeMini.Primary) }
                        : new CellTag[1] { new CellTag("正常", TTypeMini.Success) };
                        ConnectHotfies[idx].CellLinks = new CellLink[1]
                        {
                            new CellButton(Guid.NewGuid().ToString(),
                            "重新验证",
                            TTypeMini.Primary)
                        };
                        break;
                    }
                    idx += 1;
                }
                new AntdUI.Message.Config(this, "验证成功", TType.Success)
                {
                    ShowInWindow = true,
                    ClickClose = false,
                    AutoClose = 2
                }.open();
            }
        }
        private void switch1_Click(object sender, EventArgs e)
        {
            if (switch1.Checked == true)
            {
                MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                DialogResult d = MessageBox.Show($"你即将开启自动IP检测\n该项将在程序启动时自动检测所有IP\n这个操作可能消耗大量APIKEY", "提示", mess);
                if (d == DialogResult.OK)
                {
                    configuration.ConfigAutoCheckIPSet();
                    new AntdUI.Message.Config(this, "已开启", TType.Success)
                    {
                        ShowInWindow = true,
                        ClickClose = false,
                        AutoClose = 2
                    }.open();
                }
                else switch1.Checked = false;
            }
            else { configuration.ConfigAutoCheckIPSet(); }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new AntdUI.Message.Config(this, "已保存", TType.Success)
            {
                ShowInWindow = true,
                ClickClose = false,
                AutoClose = 2
            }.open();
            configuration.ConfigSetAPIKey(input1.Text, input2.Text);
        }
        public string FileUploadCheck(string filepath)
        {
            string filehash = sundry.GetFileHash(filepath);
            JsonDocument document = JsonDocument.Parse(function.GetThreatbookFileReport(filehash));
            JsonElement root = document.RootElement;
            if (root.GetProperty("verbose_msg").ToString() != "NO_AUTHORITY")
            {
                if (root.GetProperty("response_code").ToString() == "4")
                {
                    return "wait";
                }
                else
                {
                    JsonElement address = root.GetProperty("data").GetProperty("multiengines");
                    return address.GetProperty("threat_level").ToString();
                }
            }
            else 
            {
                return "过速";
            }
            
        }
        private void StartUpAbout_Click(TableButtonEventArgs e,string list)
        {
            AntList<StartUp> StartUpList = new AntList<StartUp>();
            switch (list)
            {
                case "StarpUp":
                    StartUpList = StartUpStartUpList;
                    break;
                case "Reg":
                    StartUpList = RegStartUpList;
                    break;
                case "Task":
                    StartUpList = TaskStartUpList;
                    break;
            }
            string buttontext = e.Btn.Text;
            object record = e.Record;
            Hotfix Hotfies_ = record as Hotfix;
            if (!(record is StartUp StartUps))
            {
                return;
            }
            switch (buttontext)
            {
                case "点击复制":
                    new AntdUI.Message.Config(this, StartUps.Position.FirstOrDefault().Id, TType.Success)
                    {
                        ShowInWindow = true,
                        ClickClose = false,
                        AutoClose = 2
                    }.open();
                    Clipboard.SetDataObject(StartUps.Position.FirstOrDefault().Id);
                    break;
                case "上传":
                    if (Program.ThreatbookApiKey != "")
                    {
                        int idx = 0;
                        foreach (var StartUp in StartUpList)
                        {
                            if (StartUp.Name == StartUps.Name)
                            {
                                StartUpList[idx].CellBadge =
                                    new CellBadge(TState.Primary, "检测中...");
                                new AntdUI.Message.Config(this, "上传成功", TType.Success)
                                {
                                    ShowInWindow = true,
                                    ClickClose = false,
                                    AutoClose = 2
                                }.open();
                                string filepath = StartUps.Position.FirstOrDefault().Id;
                                string CheckResult = FileUploadCheck(filepath);
                                if (CheckResult == "wait")
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
                                        config.Text = "正在等待返回结果...";
                                        function.ThreatbookFileCheck(filepath);
                                        Thread.Sleep(15000);
                                        CheckResult = FileUploadCheck(filepath);
                                    }, delegate
                                    {
                                        if (CheckResult != "error")
                                        {
                                            switch (CheckResult)
                                            {
                                                case "clean":
                                                    StartUpList[idx].CellBadge =
                                                        new CellBadge(TState.Success, "已检测");
                                                    StartUpList[idx].Malicious = new CellTag[1]
                                                    {
                                                new CellTag("安全", TTypeMini.Success)
                                                    };
                                                    StartUpList[idx].CellLinks = new CellLink[1]
                                                    {
                                                new CellButton(Guid.NewGuid().ToString(), "查看报告", TTypeMini.Primary)
                                                    };
                                                    configuration.ConfigCheckedFileHashAdd(sundry.GetFileHash(filepath), "安全");
                                                    break;
                                                case "suspicious":
                                                    StartUpList[idx].CellBadge =
                                                        new CellBadge(TState.Success, "已检测");
                                                    StartUpList[idx].Malicious = new CellTag[1]
                                                    {
                                                new CellTag("可疑", TTypeMini.Warn)
                                                    };
                                                    StartUpList[idx].CellLinks = new CellLink[1]
                                                    {
                                                new CellButton(Guid.NewGuid().ToString(), "查看报告", TTypeMini.Primary)
                                                    };
                                                    configuration.ConfigCheckedFileHashAdd(sundry.GetFileHash(filepath), "存疑");
                                                    break;
                                                case "malicious":
                                                    StartUpList[idx].CellBadge =
                                                        new CellBadge(TState.Success, "已检测");
                                                    StartUpList[idx].Malicious = new CellTag[1]
                                                    {
                                                new CellTag("危险", TTypeMini.Error)
                                                    };
                                                    StartUpList[idx].CellLinks = new CellLink[1]
                                                    {
                                                new CellButton(Guid.NewGuid().ToString(), "查看报告", TTypeMini.Primary)
                                                    };
                                                    StartUpMaliciousCount += 1;
                                                    configuration.ConfigCheckedFileHashAdd(sundry.GetFileHash(filepath), "危险");
                                                    break;
                                                case "过速":
                                                    new AntdUI.Message.Config(this, "上传速度过快", TType.Error)
                                                    {
                                                        ShowInWindow = true,
                                                        ClickClose = false,
                                                        AutoClose = 2
                                                    }.open();
                                                    StartUpList[idx].CellBadge =
                                                        new CellBadge(TState.Error, "检测失败");
                                                    StartUpList[idx].Malicious = new CellTag[1]
                                                    {
                                                new CellTag("未知", TTypeMini.Primary)
                                                    };
                                                    break;
                                                default:
                                                    StartUpList[idx].CellBadge =
                                                        new CellBadge(TState.Warn, "检查失败");
                                                    StartUpList[idx].Malicious = new CellTag[1]
                                                    {
                                                new CellTag("未知", TTypeMini.Primary)
                                                    };
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            StartUpList[idx].CellBadge =
                                                new CellBadge(TState.Error, "失败");
                                            StartUpList[idx].Malicious = new CellTag[1]
                                            {
                                        new CellTag("检测失败", TTypeMini.Error)
                                            };
                                        }
                                    });
                                }
                                if (CheckResult != "error")
                                {
                                    switch (CheckResult)
                                    {
                                        case "clean":
                                            StartUpList[idx].CellBadge =
                                                new CellBadge(TState.Success, "已检测");
                                            StartUpList[idx].Malicious = new CellTag[1]
                                            {
                                                new CellTag("安全", TTypeMini.Success)
                                            };
                                            StartUpList[idx].CellLinks = new CellLink[1]
                                            {
                                                new CellButton(Guid.NewGuid().ToString(), "查看报告", TTypeMini.Primary)
                                            };
                                            configuration.ConfigCheckedFileHashAdd(sundry.GetFileHash(filepath), "安全");
                                            break;
                                        case "suspicious":
                                            StartUpList[idx].CellBadge =
                                                new CellBadge(TState.Success, "已检测");
                                            StartUpList[idx].Malicious = new CellTag[1]
                                            {
                                                new CellTag("可疑", TTypeMini.Warn)
                                            };
                                            StartUpList[idx].CellLinks = new CellLink[1]
                                            {
                                                new CellButton(Guid.NewGuid().ToString(), "查看报告", TTypeMini.Primary)
                                            };
                                            configuration.ConfigCheckedFileHashAdd(sundry.GetFileHash(filepath), "存疑");
                                            break;
                                        case "malicious":
                                            StartUpList[idx].CellBadge =
                                                new CellBadge(TState.Success, "已检测");
                                            StartUpList[idx].Malicious = new CellTag[1]
                                            {
                                                new CellTag("危险", TTypeMini.Error)
                                            };
                                            StartUpList[idx].CellLinks = new CellLink[1]
                                            {
                                                new CellButton(Guid.NewGuid().ToString(), "查看报告", TTypeMini.Primary)
                                            };
                                            StartUpMaliciousCount += 1;
                                            configuration.ConfigCheckedFileHashAdd(sundry.GetFileHash(filepath), "危险");
                                            break;
                                        case "过速":
                                            new AntdUI.Message.Config(this, "上传速度过快", TType.Error)
                                            {
                                                ShowInWindow = true,
                                                ClickClose = false,
                                                AutoClose = 2
                                            }.open();
                                            StartUpList[idx].CellBadge =
                                                new CellBadge(TState.Error, "检测失败");
                                            StartUpList[idx].Malicious = new CellTag[1]
                                            {
                                                new CellTag("未知", TTypeMini.Primary)
                                            };
                                            break;
                                        default:
                                            StartUpList[idx].CellBadge =
                                                new CellBadge(TState.Warn, "检查失败");
                                            StartUpList[idx].Malicious = new CellTag[1]
                                            {
                                                new CellTag("未知", TTypeMini.Primary)
                                            };
                                            break;
                                    }
                                }
                                else
                                {
                                    StartUpList[idx].CellBadge =
                                        new CellBadge(TState.Error, "失败");
                                    StartUpList[idx].Malicious = new CellTag[1]
                                    {
                                        new CellTag("检测失败", TTypeMini.Error)
                                    };
                                }
                                break;
                            }
                            idx += 1;
                        }
                    }
                    else
                    {
                        new AntdUI.Message.Config(this, "未配置ApiKey", TType.Error)
                        {
                            ShowInWindow = true,
                            ClickClose = false,
                            AutoClose = 2
                        }.open();
                        return;
                    }
                    break;
                case "查看报告":
                    new AntdUI.Message.Config(this, "已复制链接", TType.Success)
                    {
                        ShowInWindow = true,
                        ClickClose = false,
                        AutoClose = 2
                    }.open();
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://s.threatbook.cn/search?query=" + sundry.GetFileHash(StartUps.Position.FirstOrDefault().Id) + "&type=md5",
                        UseShellExecute = true // 确保使用默认程序打开
                    });
                    Clipboard.SetDataObject("https://s.threatbook.cn/search?query=" + sundry.GetFileHash(StartUps.Position.FirstOrDefault().Id) + "&type=md5");
                    break;
                case "Yara扫描":
                    YaraScan(StartUpList, StartUps);
                    break;
            }
        }
        private void YaraScan(AntList<StartUp> StartUpList,StartUp StartUps)
        {
            int idx_ = 0;
            foreach (var StartUp in StartUpList)
            {
                if (StartUp.Name == StartUps.Name)
                {
                    StartUpList[idx_].CellBadge = new CellBadge(TState.Success, "检测中");
                    new AntdUI.Message.Config(this, "开始检测", TType.Success)
                    {
                        ShowInWindow = true,
                        ClickClose = false,
                        AutoClose = 2
                    }.open();
                    string fullfilename = fullfilename = StartUps.Position.FirstOrDefault().Id;
                    bool CheckResult = function.YaraScan(null, NormalYaraRule, fullfilename);
                    if (CheckResult)
                    {
                        StartUpList[idx_].CellBadge = new CellBadge(TState.Success, "已检测");
                        StartUpList[idx_].Malicious = new CellTag[1]
                        {
                            new CellTag("危险", TTypeMini.Error)
                        };
                        StartUpMaliciousCount += 1;
                    }
                    else
                    {
                        StartUpList[idx_].CellBadge = new CellBadge(TState.Success, "已检测");
                        StartUpList[idx_].Malicious = new CellTag[1]
                        {
                            new CellTag("安全", TTypeMini.Success)
                        };
                    }
                    break;
                }
                idx_ += 1;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxButtons mess = MessageBoxButtons.OKCancel;
            DialogResult d = MessageBox.Show($"重新扫描，程序将自动重启，你确定要重新启动吗？", "提示", mess);
            if (d == DialogResult.OK)
            {
                Application.Restart();
            }
            else return;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
        private void ProcessAbout_CellButtonClick(object sender, TableButtonEventArgs e)
        {
            string buttontext = e.Btn.Text;
            var record = e.Record;
            if (!(record is StartUp StartUps))
            {
                return;
            }
            if (buttontext.Contains("Yara扫描"))
            {
                AntList<StartUp> StartUpList = new AntList<StartUp>();
                StartUpList = ProcessStartUpList;
                AntdUI.Spin.open(this, new AntdUI.Spin.Config
                {
                    Back = Color.FromArgb(220, 147, 181, 207),
                    Color = Style.Db.Primary,
                    Radius = 6,
                    Fore = Color.Black,
                    Font = new Font("Microsoft YaHei UI", 14f)
                }, delegate (AntdUI.Spin.Config config)
                {
                    config.Text = "正在扫描中...";
                    int idx_ = 0;
                    foreach (var StartUp in StartUpList)
                    {
                        if (StartUp.Pid == StartUps.Pid)
                        {
                            string pid = StartUps.Pid.ToString();
                            bool CheckResult = function.YaraScan(pid, NormalYaraRule, null);
                            if (CheckResult)
                            {
                                StartUpList[idx_].CellTags = new CellTag[1]
                                {
                                 new CellTag("危险", TTypeMini.Error)
                                };
                                ProcessMaliciousCount += 1;
                            }
                            else
                            {
                                StartUpList[idx_].CellTags = new CellTag[1]
                                {
                                new CellTag("安全", TTypeMini.Success)
                                };
                            }
                            break;
                        }
                        idx_ += 1;
                    }
                }, delegate
                {
                    new AntdUI.Message.Config(this, "扫描完成", TType.Success)
                    {
                        ShowInWindow = true,
                        ClickClose = false,
                        AutoClose = 2
                    }.open();
                });
            }
            else if (buttontext.Contains("复制路径"))
            {
                new AntdUI.Message.Config(this, buttontext, TType.Success)
                {
                    ShowInWindow = true,
                    ClickClose = false,
                    AutoClose = 2
                }.open();
                Clipboard.SetDataObject(buttontext);
            }
        }
        private void select1_SelectedIndexChanged(object sender, IntEventArgs e)
        {
            new AntdUI.Message.Config(this, "已切换", TType.Success)
            {
                ShowInWindow = true,
                ClickClose = false,
                AutoClose = 2
            }.open();
            configuration.ConfigSetYaraRule(select1.Items[e.Value].ToString());
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBoxButtons mess = MessageBoxButtons.OKCancel;
            DialogResult d = MessageBox.Show($"当前使用的Yara规则：{Program.YaraRule}\n\n扫描列表：\n·StartUp启动项\n·注册表启动项\n·计划任务\n\n这可能需要一点时间，你确定扫描吗？", "提示", mess);
            if (d == DialogResult.OK)
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
                    AntList<StartUp> StartUpList = new AntList<StartUp>();
                    StartUp StartUps = new StartUp();
                    for (int j = 0; j <= 3; j++)
                    {
                        switch (j)
                        {
                            case 1:
                                config.Text = "正在扫描StartUp启动项...";
                                StartUpList = StartUpStartUpList;
                                int a = 0;
                                while (true)
                                {
                                    try
                                    {
                                        config.Text = $"正在扫描StartUp启动项...( {a + 1}/{StartUpStartUpList.Count()} )";
                                        StartUps = StartUpList[a];
                                        YaraScan(StartUpList, StartUps);
                                        a += 1;
                                    }
                                    catch { break; }
                                }
                                break;
                            case 2:
                                config.Text = "正在扫描注册表启动项...";
                                StartUpList = RegStartUpList;
                                int b = 0;
                                while (true)
                                {
                                    try
                                    {
                                        config.Text = $"正在扫描注册表启动项...( {b + 1}/{RegStartUpList.Count()} )";
                                        StartUps = StartUpList[b];
                                        YaraScan(StartUpList, StartUps);
                                        b += 1;
                                    }
                                    catch { break; }
                                }
                                break;
                            case 3:
                                config.Text = "正在扫描计划任务...";
                                StartUpList = TaskStartUpList;
                                int c = 0;
                                while (true)
                                {
                                    try
                                    {
                                        config.Text = $"正在正在扫描计划任务...( {c + 1}/{TaskStartUpList.Count()} )";
                                        StartUps = StartUpList[c];
                                        YaraScan(StartUpList, StartUps);
                                        c += 1;
                                    }
                                    catch { break; }
                                }
                                break;
                        }
                    }
                }, delegate
                {
                });
            }
            else return;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ShowDialog();
        }

    }
}
