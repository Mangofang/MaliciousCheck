using IWshRuntimeLibrary;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace MaliciousCheck
{

    internal class Sundry
    {
        public string GetFileHash(string filepath)
        {
            FileStream stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            SHA1 Hash = SHA1.Create();
            byte[] HashByte = Hash.ComputeHash(stream);
            string HashString = BitConverter.ToString(HashByte).Replace("-", "");
            return HashString;
        }
        public bool CheckSign(string path)
        {
            string pro_path = Environment.CurrentDirectory;
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = $"{pro_path}\\signtool.exe",
                Arguments = $"verify /v /pa \"{path}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            using (Process process = Process.Start(psi))
            {
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                if (output.Contains("Successfully verified"))
                {
                    return true;
                }
                else { return false; }
            }
        }
        public List<string> GetKBList(string SystemInfo)
        {
            List<string> hotfixes = new List<string>();

            using (StringReader reader = new StringReader(SystemInfo))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains("KB"))
                    {
                        int index = line.IndexOf("]:");
                        if (index != -1)
                        {
                            line = line.Substring(index + 2).Trim();
                        }
                        hotfixes.Add(line);
                    }
                }
            }
            return hotfixes;
        }
        public string GetSystemInfo()
        {
            ProcessStartInfo ProcessInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/c systeminfo",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            Process cmd = Process.Start(ProcessInfo);
            string result = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();
            return result;
        }
        public (List<string> TaskschdPath, List<string> FullTaskschdPath) GetTaskschdItem()
        {
            List<string> TaskschdPath = new List<string>();
            List<string> FullTaskschdPath = new List<string>();
            using (TaskService ts = new TaskService())
            {
                foreach (Task task in ts.AllTasks)
                {
                    if (task.Definition.Actions.Count > 0)
                    {
                        foreach (var action in task.Definition.Actions)
                        {
                            if (action is ExecAction execAction)
                            {
                                string path = execAction.Path;
                                path = Regex.Replace(path, @"[\""]+", "");
                                if (path.Contains("%"))
                                {
                                    path = Environment.ExpandEnvironmentVariables(path);
                                    if (!TaskschdPath.Contains(path))
                                    {
                                        FullTaskschdPath.Add(action.ToString());
                                        TaskschdPath.Add(path);
                                    }
                                }
                                else 
                                {
                                    if (!TaskschdPath.Contains(path))
                                    {
                                        FullTaskschdPath.Add(action.ToString());
                                        TaskschdPath.Add(path);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return (TaskschdPath,FullTaskschdPath);
        }
        public List<string> GetStartMenuItem()
        {
            List<string> Paths = new List<string>();
            List<string> Files = new List<string>();
            Paths.Add(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
            Paths.Add(Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup));
            foreach (string Path in Paths)
            {
                string[] files = Directory.GetFiles(Path, "*.*", SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    if (!Files.Contains(file))
                    {
                        if (System.IO.Path.GetExtension(file).Equals(".lnk", StringComparison.OrdinalIgnoreCase))
                        {
                            WshShell shell = new WshShell();
                            IWshShortcut lnk = (IWshShortcut)shell.CreateShortcut(file);
                            Files.Add(lnk.TargetPath);
                        }
                        else
                        {
                            Files.Add(file);
                        }
                    }
                }
            }
            return Files;
        }
        public (List<string> FullPath, List<string> Path) GetAutoRunReg()
        {
            List<string> Reg_StartUpPath = new List<string>();
            string[] registryPaths = new string[]
            {
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run",
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer\Run",
                @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\RunOnce",
                @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\RunOnce"
            };
            foreach (var registryPath in registryPaths)
            {
                RegistryKey baseKey;
                if (registryPath.StartsWith("HKEY_LOCAL_MACHINE"))
                {
                    baseKey = Registry.LocalMachine;
                }
                else if (registryPath.StartsWith("HKEY_CURRENT_USER"))
                {
                    baseKey = Registry.CurrentUser;
                }
                else
                {
                    continue;
                }
                string subKeyPath = registryPath.Substring(registryPath.IndexOf('\\') + 1);

                using (RegistryKey subKey = baseKey.OpenSubKey(subKeyPath))
                {
                    if (subKey != null)
                    {
                        foreach (var valueName in subKey.GetValueNames())
                        {
                            string value = subKey.GetValue(valueName)?.ToString();
                            if (!string.IsNullOrEmpty(value))
                            {
                                Reg_StartUpPath.Add(value);
                            }
                        }
                    }
                }
            }
            List<string> paths = new List<string>();
            foreach (string reg in Reg_StartUpPath)
            {
                string path = Regex.Match(reg, "\"(.*?)\"").Groups[1].Value;
                paths.Add(path);
            }
            return (Reg_StartUpPath, paths);
        }
        public List<string> NetStatStringCope(string NetStatString)
        {
            List<string> externalIps = new List<string>();
            string[] lines = NetStatString.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                if (line.Contains("TCP") || line.Contains("UDP"))
                {
                    var parts = Regex.Split(line, @"\s+");
                    if (parts.Length >= 4)
                    {
                        var foreignAddress = parts[3];
                        if (foreignAddress.Contains("[::]:0") || foreignAddress.Contains("*:*") || foreignAddress.Contains("0.0.0.0") || foreignAddress.Contains("127.0.0.1"))
                            continue;

                        string ipAddress = foreignAddress.Contains("[") ? foreignAddress.Split(']')[0].Trim('[', ']') : foreignAddress.Split(':')[0];
                        if (!externalIps.Contains(ipAddress))
                        {
                            externalIps.Add(ipAddress);
                        }
                    }
                }
            }
            return externalIps;
        }
        public string GetPidFormIP(string ip)
        {
            ProcessStartInfo ProcessInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c netstat -ano | findstr \"{ip}\"",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };
            Process cmd = Process.Start(ProcessInfo);
            string result = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();
            if (result != "")
            {
                string[] lines = result.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string[] parts = Regex.Split(lines[0], @"\s+");
                return parts[parts.Length - 1];
            }
            else
            {
                return "";
            }
        }
    }
}
