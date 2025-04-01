using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System;
using System.DirectoryServices.AccountManagement;
using System.Text.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Data.Sqlite;
using AntdUI;
using NetFwTypeLib;

namespace MaliciousCheck
{
    internal class Function
    {
        public string[] GetFirewallRuleIPs(string ruleName)
            {
                List<string> Ips = new List<string>();
                Type type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(type);

                foreach (INetFwRule rule in firewallPolicy.Rules)
                {
                    if (rule.Name == ruleName)
                    {
                        string[] Addresses = rule.RemoteAddresses.Split(',');
                        foreach (string ip in Addresses)
                        {
                            Ips.Add(ip.Split('/')[0]);
                        }
                        return Ips.ToArray();
                    }
                }
                return null;
            }
        public void ActionFirewallRule(string ruleName, string[] ips, string action)
        {
            string[] currentIPs = GetFirewallRuleIPs(ruleName);

            Type type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(type);

            if (currentIPs == null)
            {
                if (action == "add")
                {
                    INetFwRule rule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwRule"));
                    rule.Name = ruleName;
                    rule.Description = "该规则创建自MaliciousCheck，用于封禁IP地址。";
                    rule.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                    rule.Direction = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                    rule.Enabled = true;
                    rule.RemoteAddresses = string.Join(",", ips);
                    rule.InterfaceTypes = "All";
                    firewallPolicy.Rules.Add(rule);
                }
                return;
            }

            HashSet<string> ipSet = new HashSet<string>(currentIPs);

            if (action == "add")
            {
                foreach (var ip in ips)
                {
                    ipSet.Add(ip);
                }
            }
            else if (action == "remove")
            {
                foreach (var ip in ips)
                {
                    if (ipSet.Contains(ip))
                    {
                        ipSet.Remove(ip);
                    }
                }

                if (ipSet.Count == 0)
                {
                    foreach (INetFwRule existingRule in firewallPolicy.Rules)
                    {
                        if (existingRule.Name == ruleName)
                        {
                            firewallPolicy.Rules.Remove(ruleName);
                            return;
                        }
                    }
                }
            }
            foreach (INetFwRule existingRule in firewallPolicy.Rules)
            {
                if (existingRule.Name == ruleName)
                {
                    existingRule.RemoteAddresses = string.Join(",", ipSet);
                    break;
                }
            }
        }

        public List<string> DbScan(string SignInput, int page, int pageSize, bool IpOnlyOne = false)
        {
            string ConnectString = "Data Source=LogsDatabase.db";
            List<string> Ips = new List<string>();
            using (SqliteConnection connection = new SqliteConnection(ConnectString))
            {
                connection.Open();
                string query = $"SELECT * FROM SecLogs WHERE 1=1";
                if (!string.IsNullOrEmpty(SignInput))
                {
                    query += $" AND Sign LIKE @SignInput";
                }
                if (IpOnlyOne)
                {
                    query += $" GROUP BY Sourceip";
                }

                query += $" ORDER BY Time DESC LIMIT @PageSize OFFSET @Offset";

                Console.WriteLine(query);
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SignInput", SignInput);
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@Offset", page * pageSize);
                    Console.WriteLine(command.CommandText);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string Sourceip = reader["Sourceip"].ToString();
                            Ips.Add(Sourceip);
                        }
                    }
                }
            }
            return Ips;
        }
        public void DbScan(AntList<Log> LogList,string SourceIpInput, string LoginTypeInput, string KeywordInput, string SourceNameInput,
    DateTime TimeStart, DateTime TimeEnd, string EventIdInput, string LocalNameInput, string SignInput, int page, int pageSize, bool IpOnlyOne = false)
        {
            string ConnectString = "Data Source=LogsDatabase.db";
            LogList.Clear();
            using (SqliteConnection connection = new SqliteConnection(ConnectString))
            {
                connection.Open();
                string query = $"SELECT * FROM SecLogs WHERE 1=1";
                if (!string.IsNullOrEmpty(SourceIpInput))
                {
                    query += $" AND Sourceip = @SourceIpInput";
                }
                if (!string.IsNullOrEmpty(LoginTypeInput))
                {
                    query += $" AND Logintype = @LoginTypeInput";
                }
                if (!string.IsNullOrEmpty(KeywordInput))
                {
                    query += $" AND (Logtype LIKE @KeywordInput OR Loginname LIKE @KeywordInput OR Process LIKE @KeywordInput OR Sign LIKE @KeywordInput)";
                }
                if (!string.IsNullOrEmpty(SourceNameInput))
                {
                    query += $" AND Sourcename = @SourceNameInput";
                }
                if (TimeStart != DateTime.MinValue && TimeEnd != DateTime.MinValue)
                {
                    query += $" AND Time BETWEEN @TimeStart AND @TimeEnd";
                }
                if (!string.IsNullOrEmpty(EventIdInput))
                {
                    query += $" AND EventId = @EventIdInput";
                }
                if (!string.IsNullOrEmpty(LocalNameInput))
                {
                    query += $" AND Loginname = @LocalNameInput";
                }
                if (!string.IsNullOrEmpty(SignInput))
                {
                    query += $" AND Sign LIKE @SignInput";
                }
                if (IpOnlyOne)
                {
                    query += $" GROUP BY Sourceip";
                }

                query += $" ORDER BY Time DESC LIMIT @PageSize OFFSET @Offset";

                Console.WriteLine(query);
                using (SqliteCommand command = new SqliteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SourceIpInput", SourceIpInput);
                    command.Parameters.AddWithValue("@LoginTypeInput", LoginTypeInput);
                    command.Parameters.AddWithValue("@KeywordInput", $"%{KeywordInput}%");
                    command.Parameters.AddWithValue("@SourceNameInput", SourceNameInput);
                    command.Parameters.AddWithValue("@TimeStart", TimeStart);
                    command.Parameters.AddWithValue("@TimeEnd", TimeEnd);
                    command.Parameters.AddWithValue("@EventIdInput", EventIdInput);
                    command.Parameters.AddWithValue("@LocalNameInput", LocalNameInput);
                    command.Parameters.AddWithValue("@SignInput", SignInput);
                    command.Parameters.AddWithValue("@PageSize", pageSize);
                    command.Parameters.AddWithValue("@Offset", page * pageSize);
                    Console.WriteLine(command.CommandText);
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
        public bool YaraScan(string pid,string YaraRule,string FullFileName)
        {
            string Arguments = "";
            if (string.IsNullOrEmpty(pid))
            {
                Arguments = $"/c yara64.exe -w -C {YaraRule} \"{FullFileName}\"";
            }
            else
            {
                Arguments = $"/c yara64.exe -w -C {YaraRule} {pid}";
            }
            ProcessStartInfo ProcessInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = Arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            Process cmd = Process.Start(ProcessInfo);
            string result = cmd.StandardOutput.ReadToEnd();
            string error = cmd.StandardError.ReadToEnd();
            cmd.WaitForExit();
            if (string.IsNullOrEmpty(error))
            {
                if (!string.IsNullOrEmpty(result))
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        public List<string> GetUserName()
        {
            List<string> Name = new List<string>();
            using (PrincipalContext context = new PrincipalContext(ContextType.Machine))
            {
                using (PrincipalSearcher searcher = new PrincipalSearcher(new UserPrincipal(context)))
                {
                    foreach (Principal result in searcher.FindAll())
                    {
                        Name.Add(result.SamAccountName);
                    }
                }
            }
            return Name;
        }
        public string GetThreatbookFileReport(string hash)
        {
            string url = $"https://api.threatbook.cn/v3/file/report/multiengines?apikey={Program.ThreatbookApiKey}&resource={hash}&type=md5";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                string data = reader.ReadToEnd();
                return data;
            }
        }
        public string ThreatbookFileCheck(string FilePath)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (MultipartFormDataContent form = new MultipartFormDataContent())
                {
                    form.Add(new StringContent(Program.ThreatbookApiKey), "apikey");
                    StreamContent fileContent = new StreamContent(new FileStream(FilePath, FileMode.Open, FileAccess.Read));
                    fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    form.Add(fileContent, "file", Path.GetFileName(FilePath));

                    HttpResponseMessage response = httpClient.PostAsync("https://api.threatbook.cn/v3/file/upload", form).Result;
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
        }
        public (Dictionary<string, string> MaliciousIps, Dictionary<string, string> SecureIps, Dictionary<string, string> FailIps) ChaiTinIpCheck(List<string> CheckIp)
        {
            Dictionary<string, string> MaliciousIps = new Dictionary<string, string>();
            Dictionary<string, string> SecureIps = new Dictionary<string, string>();
            Dictionary<string, string> FailIps = new Dictionary<string, string>();

            foreach (string ip in CheckIp)
            {
                string url = url = $"https://ip-0.rivers.chaitin.cn/api/share/s?sk={Program.ChaiTinApiKey}&ip={ip}";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537";
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string data = reader.ReadToEnd();
                    JsonDocument document = JsonDocument.Parse(data);
                    JsonElement root = document.RootElement;
                    JsonElement address = root.GetProperty("data")
                                              .GetProperty("ip_info")
                                              .GetProperty("address");
                    string country = address.GetProperty("country").GetString();
                    string province = address.GetProperty("province").GetString();
                    string city = address.GetProperty("city").GetString();
                    string isp = address.GetProperty("isp").GetString();
                    string position = $"{country}-{province}-{city}-{isp}";
                    if (data.Contains("\"success\":true"))
                    {
                        if (data.Contains("\"status\":\"malicious\""))
                        {
                            MaliciousIps.Add(ip, position);
                        }
                        else
                        {
                            SecureIps.Add(ip, position);
                        }
                    }
                    else
                    {
                        FailIps.Add(ip, position);
                    }
                }
            }

            return (MaliciousIps, SecureIps, FailIps);
        }
        public (string ip,string position,string state) ChaiTinIpCheck(string ip)
        {
            string url = url = $"https://ip-0.rivers.chaitin.cn/api/share/s?sk={Program.ChaiTinApiKey}&ip={ip}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                try
                {
                    string data = reader.ReadToEnd();
                    JsonDocument document = JsonDocument.Parse(data);
                    JsonElement root = document.RootElement;
                    JsonElement address = root.GetProperty("data")
                                              .GetProperty("ip_info")
                                              .GetProperty("address");
                    string country = address.GetProperty("country").GetString();
                    string province = address.GetProperty("province").GetString();
                    string city = address.GetProperty("city").GetString();
                    string isp = address.GetProperty("isp").GetString();
                    string position = $"{country}-{province}-{city}-{isp}";
                    if (data.Contains("\"success\":true"))
                    {
                        if (data.Contains("\"status\":\"malicious\""))
                        {
                            return (ip, position, "威胁");
                        }
                        else
                        {
                            return (ip, position, "安全");
                        }
                    }
                    else
                    {
                        return (ip, "未知", "验证失败");
                    }
                }
                catch (Exception ex) { return (ip, "未知", "验证失败"); }
            }
        }
    }
}
