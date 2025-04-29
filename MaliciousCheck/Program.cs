using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace MaliciousCheck
{
    internal static class Program
    {
        public static string ChaiTinApiKey = "";
        public static string ThreatbookApiKey = "";
        public static bool AutoCheckIP = false;
        public static bool AutoRun = false;
        public static string YaraRule = "";
        public static Dictionary<string, string> CheckedFileHash = new Dictionary<string, string>();
        [STAThread]
        static void Main()
        {
            /*
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                string exeName = System.Reflection.Assembly.GetExecutingAssembly().Location;

                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.UseShellExecute = true;
                processStartInfo.Verb = "runas";
                processStartInfo.FileName = exeName;
                try
                {
                    Process.Start(processStartInfo);
                    Process.GetCurrentProcess().Kill();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("请使用管理员启动程序", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Process.GetCurrentProcess().Kill();
                }
            }*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Batteries.Init();
            Application.Run(new Form1());
        }
    }
}
