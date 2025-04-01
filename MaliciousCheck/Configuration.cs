using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace MaliciousCheck
{
    internal class Configuration
    {
        static string path = Environment.CurrentDirectory;
        static string Config_Default = "{\t\"ThreatbookApiKey\" : \"\",\r\n\t\"ChaiTinApiKey\" : \"\",\r\n\t\"AutoCheckIP\" : false,\r\n\t\"AutoRun\" : false,\r\n\t\"CheckedFileHash\" : {}}";
        static string data_json = "";
        Config data = null;
        public class Config
        {
            public string ThreatbookApiKey { get; set; }
            public string ChaiTinApiKey { get; set; }
            public bool AutoCheckIP { get; set; }
            public bool AutoRun { get; set; }
            public string YaraRule { get; set; }
            public Dictionary<string,string> CheckedFileHash { get; set; }
        }
        public void InitializationConfig()
        {
            if (File.Exists(path + @"\config.ini"))
            {
                data_json = File.ReadAllText(path + @"\config.ini");
                data = JsonSerializer.Deserialize<Config>(data_json);
                Program.ChaiTinApiKey = data.ChaiTinApiKey;
                Program.ThreatbookApiKey = data.ThreatbookApiKey;
                Program.AutoCheckIP = data.AutoCheckIP;
                Program.AutoRun = data.AutoRun;
                Program.CheckedFileHash = data.CheckedFileHash;
                Program.YaraRule = data.YaraRule;
            }
            else
            {
                FileStream fs = new FileStream(path + @"\config.ini", FileMode.Create, FileAccess.Write);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine(Config_Default);
                sr.Close();
                fs.Close();
                data_json = File.ReadAllText(path + @"\config.ini");
                data = JsonSerializer.Deserialize<Config>(data_json);
            }
        }
        public void ConfigCheckedFileHashAdd(string hash,string state)
        {
            if (!data.CheckedFileHash.ContainsKey(hash))
            {
                data.CheckedFileHash.Add(hash, state);
            }
            string updatedJson = JsonSerializer.Serialize(data);
            File.WriteAllText(path + @"\config.ini", updatedJson);
            InitializationConfig();
        }
        public void ConfigAutoCheckIPSet()
        {
            if (data.AutoCheckIP == true)
            {
                data.AutoCheckIP = false;
            }
            else
            {
                data.AutoCheckIP = true;
            }
            string updatedJson = JsonSerializer.Serialize(data);
            File.WriteAllText(path + @"\config.ini", updatedJson);
            InitializationConfig();
        }
        public void ConfigAutoRunSet()
        {
            if (data.AutoRun == true)
            {
                data.AutoRun = false;
            }
            else
            {
                data.AutoRun = true;
            }
            string updatedJson = JsonSerializer.Serialize(data);
            File.WriteAllText(path + @"\config.ini", updatedJson);
            InitializationConfig();
        }
        public void ConfigSetAPIKey(string ChaiTinApiKey,string ThreatbookApiKey)
        {
            data.ChaiTinApiKey = ChaiTinApiKey;
            data.ThreatbookApiKey = ThreatbookApiKey;
            string updatedJson = JsonSerializer.Serialize(data);
            File.WriteAllText(path + @"\config.ini", updatedJson);
            InitializationConfig();
        }
        public void ConfigSetYaraRule(string YaraRule)
        {
            data.YaraRule = YaraRule;
            string updatedJson = JsonSerializer.Serialize(data);
            File.WriteAllText(path + @"\config.ini", updatedJson);
            InitializationConfig();
        }
    }
}
