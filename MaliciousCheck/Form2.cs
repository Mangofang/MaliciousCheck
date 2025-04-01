using AntdUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using System.Threading.Tasks;

namespace MaliciousCheck
{
    public partial class Form2 : Form
    {
        AntList<Log> LogList = new AntList<Log>();
        AntList<PowerShellLog> PowerShellLogList = new AntList<PowerShellLog>();
        AntList<ServiceCreateLog> ServiceCreateLogList = new AntList<ServiceCreateLog>();
        Data data = new Data();
        Function function = new Function();
        int page = 0;
        int pageSize = 200;
        static EventLog eventLog = new EventLog("Security");
        List<EventLogEntry> entries = new List<EventLogEntry>();
        string ConnectString = "Data Source=LogsDatabase.db";
        public Form2()
        {
            InitializeComponent();
            SecLog.Columns = new ColumnCollection
            {
                new Column("Time", "时间",ColumnAlign.Center),
                new Column("Id", "事件ID", ColumnAlign.Center),
                new Column("Logtype", "事件类型", ColumnAlign.Center),
                new Column("Logintype", "登录类型", ColumnAlign.Center),
                new Column("Sourceip", "源IP", ColumnAlign.Center),
                new Column("Sourcename", "源用户名", ColumnAlign.Center),
                new Column("Loginname", "目标用户名", ColumnAlign.Center),
                new Column("Process", "进程", ColumnAlign.Center),
                new Column("Sign", "备注", ColumnAlign.Center),
            };
            PowerShellLog.Columns = new ColumnCollection
            {
                new Column("Time", "时间",ColumnAlign.Center),
                new Column("Source", "来源", ColumnAlign.Center),
                new Column("Type", "类型", ColumnAlign.Center),
                new Column("Sign", "备注", ColumnAlign.Center),
                new Column("CommandExec", "命令执行", ColumnAlign.Left),
            };
            ServiceCreateLog.Columns = new ColumnCollection
            {
                new Column("Time", "时间",ColumnAlign.Center),
                new Column("Source", "来源", ColumnAlign.Center),
                new Column("Type", "服务类型", ColumnAlign.Center),
                new Column("StartType", "服务启动类型", ColumnAlign.Center),
                new Column("StartFileName", "启动文件", ColumnAlign.Left),
                new Column("Sign", "备注", ColumnAlign.Center),
            };
            checkbox1.Visible = false;
            PowerShellLog.Binding(PowerShellLogList);
            ServiceCreateLog.Binding(ServiceCreateLogList);
            SecLog.Binding(LogList);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (File.Exists("LogsDatabase.db"))
            {
                MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                DialogResult d = MessageBox.Show($"检测到当前已收集的日志文件，是否重新收集？\n这可能需要一点时间？", "提示", mess);
                if (d == DialogResult.OK)
                {
                    File.Delete("LogsDatabase.db");
                    AntdUI.Spin.open(this, new AntdUI.Spin.Config
                    {
                        Back = Color.FromArgb(220, 147, 181, 207),
                        Color = Style.Db.Primary,
                        Radius = 6,
                        Fore = Color.Black,
                        Font = new Font("Microsoft YaHei UI", 14f)
                    }, delegate (AntdUI.Spin.Config config)
                    {
                        config.Text = "正在收集日志...";
                        CreateDb(config);
                    }, delegate
                    {
                        LoadLog();
                    });
                }
                else
                {
                    LoadLog();
                }
            }
            else
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
                    config.Text = "正在收集日志...";
                    CreateDb(config);
                }, delegate
                {
                    new AntdUI.Message.Config(this, "已完成", TType.Success)
                    {
                        ShowInWindow = true,
                        ClickClose = false,
                        AutoClose = 2
                    }.open();
                    LoadLog();
                });
            }

        }
        private string GetHostApplication(string message)
        {
            string keyword = "HostApplication=";
            int startIndex = message.IndexOf(keyword) + keyword.Length;
            int endIndex = message.IndexOf("\n", startIndex);
            string hostApplication = message.Substring(startIndex, endIndex - startIndex).Trim();
            return hostApplication;
        }
        private void LoadLog()
        {
            using (var connection = new SqliteConnection(ConnectString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM SecLogs";

                using (var command = new SqliteCommand(query, connection))
                {
                    var count = command.ExecuteScalar();
                    label10.Text = $"第 {page + 1} 页 页面数量:{pageSize} 总大小:{count}";
                }
            }
            using (SqliteConnection connection = new SqliteConnection(ConnectString))
            {
                connection.Open();
                string query = $"SELECT * FROM SecLogs order by Time DESC LIMIT {pageSize} OFFSET ({page} * {pageSize})";

                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string Time = reader["Time"].ToString();
                            string Id = reader["EventId"].ToString();
                            string Logtype = reader["Logtype"].ToString();
                            string Logintype = reader["Logintype"].ToString();
                            string Sourceip = reader["Sourceip"].ToString();
                            string Sourcename = reader["Sourcename"].ToString();
                            string Loginname = reader["Loginname"].ToString();
                            string Process = reader["Process"].ToString();
                            string Sign = reader["Sign"].ToString();
                            LogList.Add(new Log
                            {
                                Time = Time,
                                Id = Id,
                                Logtype = Logtype,
                                Logintype = Logintype,
                                Sourceip = Sourceip,
                                Sourcename = Sourcename,
                                Loginname = Loginname,
                                Process = Process,
                                Sign = Sign,
                            });
                        }
                    }
                }
            }
        }
        private void CreateDb(AntdUI.Spin.Config config)
        {
            Parallel.ForEach(eventLog.Entries.Cast<EventLogEntry>(), entry =>
            {
                lock (entries)
                {
                    entries.Add(entry);
                }
            });
            using (SqliteConnection connection = new SqliteConnection(ConnectString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS SecLogs (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        EventId INTEGER,
                        Time TEXT,
                        Logtype TEXT,
                        Logintype TEXT,
                        Sourceip TEXT,
                        Sourcename TEXT,
                        Loginname TEXT,
                        Keyword TEXT,
                        Process TEXT,
                        Sign TEXT
                        )";
                SqliteCommand command = connection.CreateCommand();
                command.CommandText = createTableQuery;
                command.ExecuteNonQuery();
                command.Dispose();
            }
            using (SqliteConnection connection = new SqliteConnection(ConnectString))
            {
                connection.Open();

                using (SqliteTransaction transaction = connection.BeginTransaction())
                {
                    List<string> valuesList = new List<string>();
                    int counter = 0;
                    if (EventLog.Exists("Security"))
                    {
                        object lockObj = new object();
                        Dictionary<string, List<DateTime>> ipFailures = new Dictionary<string, List<DateTime>>(); // 记录IP的失败时间列表
                        int failThreshold = 5; //阈值
                        TimeSpan timeWindow = TimeSpan.FromMinutes(1); //时间窗口

                        Parallel.ForEach(entries, entry =>
                        {
                            string LoginType = data.LoginType[ParseDetails(entry.Message, "登录类型").Replace(":", "").Replace("\t", "")];
                            string Time = entry.TimeWritten.ToString("yyyy-MM-dd HH:mm:ss");
                            string Id = entry.InstanceId.ToString();
                            string LogType = entry.Category;
                            string SourceIp = ParseDetails(entry.Message, "源网络地址").Replace(":","").Replace("\t","");
                            string SourceName = ExtractAccountName(entry.Message, "使用者") ?? "-";
                            string LoginName = ExtractAccountName(entry.Message, "新登录") ?? "-";
                            string Process = Path.GetFileName(ParseDetails(entry.Message, "进程名称").Replace(":", "").Replace("\t", ""));
                            string KeyWord = GetEventKeywords(entry.InstanceId, "Security");
                            string Sign = "无";

                            if (Id == "4625")
                            {
                                DateTime failTime = entry.TimeWritten;

                                lock (lockObj)
                                {
                                    if (!ipFailures.ContainsKey(SourceIp))
                                    {
                                        ipFailures[SourceIp] = new List<DateTime>();
                                    }
                                    ipFailures[SourceIp].Add(failTime);
                                    ipFailures[SourceIp].RemoveAll(t => (failTime - t) > timeWindow);
                                    if (ipFailures[SourceIp].Count >= failThreshold)
                                    {
                                        Sign = "疑似密码爆破";
                                    }
                                }
                            }

                            string value = $"({Id}, '{Time}', '{LogType}', '{LoginType}', '{SourceIp}', '{SourceName}', '{LoginName}', '{KeyWord}', '{Process}', '{Sign}')";
                            
                            lock (lockObj)
                            {
                                valuesList.Add(value);
                                counter++;
                                config.Text = $"正在收集日志...[{counter} / {entries.Count()}]";
                                if (counter % 1000 == 0)
                                {
                                    string bulkInsertQuery = "INSERT INTO SecLogs (EventId, Time, Logtype, Logintype, Sourceip, Sourcename, Loginname, Keyword, Process, Sign) VALUES "
                                                            + string.Join(",", valuesList);

                                    using (var command = new SqliteCommand(bulkInsertQuery, connection, transaction))
                                    {
                                        command.ExecuteNonQuery();
                                    }
                                    valuesList.Clear();
                                }
                            }
                        });
                        if (valuesList.Count > 0)
                        {
                            string bulkInsertQuery = "INSERT INTO SecLogs (EventId, Time, Logtype, Logintype, Sourceip, Sourcename, Loginname, Keyword, Process, Sign) VALUES "
                                                    + string.Join(",", valuesList);

                            using (var command = new SqliteCommand(bulkInsertQuery, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                }
            }
        }
        static string GetEventKeywords(long instanceId, string logName)
        {
            string query = $"*[System/EventID={instanceId}]";
            EventLogQuery eventLogQuery = new EventLogQuery(logName, PathType.LogName, query);

            using (EventLogReader eventLogReader = new EventLogReader(eventLogQuery))
            {
                EventRecord eventRecord = eventLogReader.ReadEvent();
                if (eventRecord != null && eventRecord.KeywordsDisplayNames != null)
                {
                    return string.Join(", ", eventRecord.KeywordsDisplayNames);
                }
            }

            return "无关键字";
        }
        static string ExtractAccountName(string message, string section)
        {
            string pattern = $@"{section}:\s+.*\n\s+帐户名称:\s+(?<AccountName>.+)";
            Match match = Regex.Match(message, pattern);

            if (match.Success)
            {
                return match.Groups["AccountName"].Value.Trim();
            }

            return null;
        }
        private string ParseDetails(string message, string contains)
        {
            if (message.Contains(contains))
            {
                int Start = message.IndexOf(contains) + contains.Length;
                int End = message.IndexOf('\n', Start);
                if (End == -1)
                {
                    return "-";
                }
                string result = message.Substring(Start, End - Start).Trim();
                return result;
            }
            return "-";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string SourceIpInput = SecSourceIpInput.Text;
            string LoginTypeInput = SecLoginTypeInput.Text;
            string KeywordInput = SecKeywordInput.Text;
            string SourceNameInput = SecSourceNameInput.Text;
            DateTime TimeStart = new DateTime();
            DateTime TimeEnd = new DateTime();
            if (SecTimeInput.Value != null)
            {
                if (TimeStart == TimeEnd)
                {
                    TimeStart = SecTimeInput.Value[0];
                    TimeEnd = TimeStart.AddDays(1).AddSeconds(-1);
                }
                else
                {
                    TimeStart = SecTimeInput.Value[0];
                    TimeEnd = SecTimeInput.Value[1];
                }
            }
            string EventIdInput = SecEnvenIdInput.Text;
            string LocalNameInput = SecLocalNameInput.Text;
            string SignInput = SecSignInput.Text;

            if (page != 0)
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
                    config.Text = "正在加载日志...";
                    page -= 1;
                    if (string.IsNullOrEmpty(SourceIpInput) || string.IsNullOrEmpty(LoginTypeInput) ||
                        string.IsNullOrEmpty(KeywordInput) || string.IsNullOrEmpty(SourceNameInput) ||
                        string.IsNullOrEmpty(EventIdInput) || string.IsNullOrEmpty(LocalNameInput) ||
                        string.IsNullOrEmpty(SignInput) ||
                        TimeStart != DateTime.MinValue || TimeEnd != DateTime.MinValue)
                    {
                        label10.Text = $"第 {page + 1} 页 页面数量:{pageSize}";
                        function.DbScan(LogList,SourceIpInput, LoginTypeInput, KeywordInput, SourceNameInput, TimeStart, TimeEnd, EventIdInput, LocalNameInput,SignInput, page, pageSize);
                    }
                    else
                    {
                        LoadLog();
                    }
                }, delegate
                {
                    new AntdUI.Message.Config(this, "已加载", TType.Success)
                    {
                        ShowInWindow = true,
                        ClickClose = false,
                        AutoClose = 2
                    }.open();
                });
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            page = 0;
            string SourceIpInput = SecSourceIpInput.Text;
            string LoginTypeInput = SecLoginTypeInput.Text;
            string KeywordInput = SecKeywordInput.Text;
            string SourceNameInput = SecSourceNameInput.Text;
            DateTime TimeStart = new DateTime();
            DateTime TimeEnd = new DateTime();
            if (SecTimeInput.Value != null)
            {
                if (TimeStart == TimeEnd)
                {
                    TimeStart = SecTimeInput.Value[0];
                    TimeEnd = TimeStart.AddDays(1).AddSeconds(-1);
                }
                else
                {
                    TimeStart = SecTimeInput.Value[0];
                    TimeEnd = SecTimeInput.Value[1];
                }
            }
            string EventIdInput = SecEnvenIdInput.Text;
            string LocalNameInput = SecLocalNameInput.Text;
            string SignInput = SecSignInput.Text;

            AntdUI.Spin.open(this, new AntdUI.Spin.Config
            {
                Back = Color.FromArgb(220, 147, 181, 207),
                Color = Style.Db.Primary,
                Radius = 6,
                Fore = Color.Black,
                Font = new Font("Microsoft YaHei UI", 14f)
            }, delegate (AntdUI.Spin.Config config)
            {
                config.Text = "正在检索...";
                label10.Text = $"第 {page+1} 页 页面数量:{pageSize}";
                function.DbScan(LogList,SourceIpInput, LoginTypeInput, KeywordInput, SourceNameInput, TimeStart, TimeEnd, EventIdInput, LocalNameInput,SignInput, page, pageSize);
            }, delegate
            {
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
                config.Text = "正在加载日志...";
                LogList.Clear();
                SecTimeInput.Value = null;
                LoginSuccessRadio.Checked = false;
                LoginFailRadio.Checked = false;
                RDPLoginRadio.Checked = false;
                PasswordAttackRadio.Checked = false;
                SecSourceIpInput.Text = "";
                SecLoginTypeInput.Text = "";
                SecKeywordInput.Text = "";
                SecSourceNameInput.Text = "";
                SecTimeInput.Text = "";
                SecEnvenIdInput.Text = "";
                SecLocalNameInput.Text = "";
                SecSignInput.Text = "";
                checkbox1.Checked = false;
                checkbox1.Visible = false;
                page = 0;
                LoadLog();
            }, delegate
            {
            });
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string SourceIpInput = SecSourceIpInput.Text;
            string LoginTypeInput = SecLoginTypeInput.Text;
            string KeywordInput = SecKeywordInput.Text;
            string SourceNameInput = SecSourceNameInput.Text;
            DateTime TimeStart = new DateTime();
            DateTime TimeEnd = new DateTime();
            if (SecTimeInput.Value != null)
            {
                if (TimeStart == TimeEnd)
                {
                    TimeStart = SecTimeInput.Value[0];
                    TimeEnd = TimeStart.AddDays(1).AddSeconds(-1);
                }
                else
                {
                    TimeStart = SecTimeInput.Value[0];
                    TimeEnd = SecTimeInput.Value[1];
                }
            }
            string EventIdInput = SecEnvenIdInput.Text;
            string LocalNameInput = SecLocalNameInput.Text;
            string SignInput = SecSignInput.Text;

            AntdUI.Spin.open(this, new AntdUI.Spin.Config
            {
                Back = Color.FromArgb(220, 147, 181, 207),
                Color = Style.Db.Primary,
                Radius = 6,
                Fore = Color.Black,
                Font = new Font("Microsoft YaHei UI", 14f)
            }, delegate (AntdUI.Spin.Config config)
            {
                config.Text = "正在加载日志...";
                page += 1;
                if (string.IsNullOrEmpty(SourceIpInput) || string.IsNullOrEmpty(LoginTypeInput) ||
                    string.IsNullOrEmpty(KeywordInput) || string.IsNullOrEmpty(SourceNameInput) ||
                    string.IsNullOrEmpty(EventIdInput) || string.IsNullOrEmpty(LocalNameInput) ||
                    string.IsNullOrEmpty(SignInput) ||
                    TimeStart != DateTime.MinValue || TimeEnd != DateTime.MinValue)
                {
                    label10.Text = $"第 {page + 1} 页 页面数量:{pageSize}";
                    function.DbScan(LogList,SourceIpInput, LoginTypeInput, KeywordInput, SourceNameInput, TimeStart, TimeEnd, EventIdInput, LocalNameInput,SignInput, page, pageSize);
                }
                else
                {
                    LoadLog();
                }
            }, delegate
            {
                new AntdUI.Message.Config(this, "已加载", TType.Success)
                {
                    ShowInWindow = true,
                    ClickClose = false,
                    AutoClose = 2
                }.open();
            });
        }
        private void LoginSuccessRadio_CheckedChanged(object sender, BoolEventArgs e)
        {
            if (LoginSuccessRadio.Checked)
            {
                SecTimeInput.Value = null;
                SecSourceIpInput.Text = "";
                SecLoginTypeInput.Text = "";
                SecKeywordInput.Text = "";
                SecSourceNameInput.Text = "";
                SecTimeInput.Text = "";
                SecLocalNameInput.Text = "";
                SecEnvenIdInput.Text = "4624";
                SecSignInput.Text = "";
                button1_Click(sender, e);
            }
        }
        private void LoginFailRadio_CheckedChanged(object sender, BoolEventArgs e)
        {
            if (LoginFailRadio.Checked)
            {
                SecTimeInput.Value = null;
                SecSourceIpInput.Text = "";
                SecLoginTypeInput.Text = "";
                SecKeywordInput.Text = "";
                SecSourceNameInput.Text = "";
                SecTimeInput.Text = "";
                SecLocalNameInput.Text = "";
                SecEnvenIdInput.Text = "4625";
                SecSignInput.Text = "";
                button1_Click(sender, e);
            }
        }
        private void RDPLoginRadio_CheckedChanged(object sender, BoolEventArgs e)
        {
            if (RDPLoginRadio.Checked)
            {
                SecTimeInput.Value = null;
                SecSourceIpInput.Text = "";
                SecKeywordInput.Text = "";
                SecSourceNameInput.Text = "";
                SecTimeInput.Text = "";
                SecLocalNameInput.Text = "";
                SecLoginTypeInput.Text = "远程交互登录";
                SecSignInput.Text = "";
                SecEnvenIdInput.Text = "";
                button1_Click(sender, e);
            }
        }
        private void PasswordAttackRadio_CheckedChanged(object sender, BoolEventArgs e)
        {
            if (PasswordAttackRadio.Checked)
            {
                SecTimeInput.Value = null;
                SecSourceIpInput.Text = "";
                SecKeywordInput.Text = "";
                SecSourceNameInput.Text = "";
                SecTimeInput.Text = "";
                SecLocalNameInput.Text = "";
                SecLoginTypeInput.Text = "";
                SecSignInput.Text = "疑似密码爆破";
                SecEnvenIdInput.Text = "";
                checkbox1.Visible = true;
                button1_Click(sender, e);
            }
            else
            {
                checkbox1.Visible = false;
            }
        }
        private void checkbox1_CheckedChanged(object sender, BoolEventArgs e)
        {
            if (checkbox1.Checked)
            {
                page = 0;
                string SourceIpInput = SecSourceIpInput.Text;
                string LoginTypeInput = SecLoginTypeInput.Text;
                string KeywordInput = SecKeywordInput.Text;
                string SourceNameInput = SecSourceNameInput.Text;
                DateTime TimeStart = new DateTime();
                DateTime TimeEnd = new DateTime();
                if (SecTimeInput.Value != null)
                {
                    if (TimeStart == TimeEnd)
                    {
                        TimeStart = SecTimeInput.Value[0];
                        TimeEnd = TimeStart.AddDays(1).AddSeconds(-1);
                    }
                    else
                    {
                        TimeStart = SecTimeInput.Value[0];
                        TimeEnd = SecTimeInput.Value[1];
                    }
                }
                string EventIdInput = SecEnvenIdInput.Text;
                string LocalNameInput = SecLocalNameInput.Text;
                string SignInput = SecSignInput.Text;

                AntdUI.Spin.open(this, new AntdUI.Spin.Config
                {
                    Back = Color.FromArgb(220, 147, 181, 207),
                    Color = Style.Db.Primary,
                    Radius = 6,
                    Fore = Color.Black,
                    Font = new Font("Microsoft YaHei UI", 14f)
                }, delegate (AntdUI.Spin.Config config)
                {
                    config.Text = "正在检索...";
                    label10.Text = $"第 {page + 1} 页 页面数量:{pageSize}";
                    function.DbScan(LogList,SourceIpInput, LoginTypeInput, KeywordInput, SourceNameInput, TimeStart, TimeEnd, EventIdInput, LocalNameInput, SignInput, page, pageSize, true);
                }, delegate
                {
                });
            }
            else
            {
                PasswordAttackRadio_CheckedChanged(sender, e);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
        private void tabs1_SelectedIndexChanged(object sender, IntEventArgs e)
        {
            switch(e.Value)
            {
                case 1:
                    if (ServiceCreateLogList.Count == 0)
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
                            string logName = "System";
                            EventLog eventLog = new EventLog(logName);

                            List<EventLogEntry> ServiceCrateLogEntries = eventLog.Entries.Cast<EventLogEntry>()
                                                  .Where(entry => entry.EventID == 7045)
                                                  .OrderByDescending(entry => entry.TimeGenerated)
                                                  .ToList();
                            int counter = 0;
                            foreach (EventLogEntry entry in ServiceCrateLogEntries)
                            {
                                string Time = entry.TimeGenerated.ToString();
                                string Source = entry.Source;
                                string Type = entry.EntryType.ToString();
                                string StartType = ParseDetails(entry.Message, "服务启动类型").Replace(":", "");
                                string StartFileName = ParseDetails(entry.Message, "服务文件名").Replace(":", "");
                                string Sign = "无";
                                counter += 1;
                                config.Text = $"正在收集日志...[{counter} / {ServiceCrateLogEntries.Count()}]";
                                ServiceCreateLogList.Add(new ServiceCreateLog
                                {
                                    Time = Time,
                                    Source = Source,
                                    Type = Type,
                                    StartFileName = StartFileName,
                                    StartType = StartType,
                                    Sign = Sign
                                });
                            }
                        }, delegate
                        {
                            new AntdUI.Message.Config(this, "已完成", TType.Success)
                            {
                                ShowInWindow = true,
                                ClickClose = false,
                                AutoClose = 2
                            }.open();
                        });
                    }
                    break;
                case 2:
                    if (PowerShellLogList.Count == 0)
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
                            string logName = "Windows PowerShell";
                            EventLog eventLog = new EventLog(logName);
                            List<EventLogEntry> PowerShellLogEntries = eventLog.Entries.Cast<EventLogEntry>()
                                         .OrderByDescending(entry => entry.TimeGenerated)
                                         .ToList();
                            int counter = 0;
                            foreach (EventLogEntry entry in PowerShellLogEntries)
                            {
                                string Time = entry.TimeGenerated.ToString();
                                string Source = entry.Source;
                                string Type = entry.EntryType.ToString();
                                string CommandExec = GetHostApplication(entry.Message);
                                string Sign = "无";

                                counter += 1;
                                config.Text = $"正在收集日志...[{counter} / {PowerShellLogEntries.Count()}]";

                                PowerShellLogList.Add(new PowerShellLog
                                {
                                    Time = Time,
                                    Source = Source,
                                    Type = Type,
                                    CommandExec = CommandExec,
                                    Sign = Sign
                                });
                            }
                        }, delegate
                        {
                            new AntdUI.Message.Config(this, "已完成", TType.Success)
                            {
                                ShowInWindow = true,
                                ClickClose = false,
                                AutoClose = 2
                            }.open();
                        });
                    }
                    break;
                case 3:
                    MessageBoxButtons mess = MessageBoxButtons.OKCancel;
                    DialogResult d = MessageBox.Show($"这个操作将同时打开文件路径及ConsoleHost_history文件\n你确定吗？", "提示", mess);
                    if (d == DialogResult.OK)
                    {
                        string Path = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\AppData\Roaming\Microsoft\Windows\PowerShell\PSReadLine\");
                        Process.Start("explorer.exe", $"/e,{Path}");
                        if (File.Exists($"{Path}\\ConsoleHost_history.txt"))
                        {
                            Process.Start($"{Path}\\ConsoleHost_history.txt");
                        }
                    }
                    tabs1.SelectTab(0);
                    break;
            }
        }
    }
}
