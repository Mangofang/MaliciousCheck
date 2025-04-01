using AntdUI;
using System.Collections.Generic;

namespace MaliciousCheck
{
    public class Data
    {
        public Dictionary<string, string> SignDatas = new Dictionary<string, string>
        {
            { "Tencent Technology", "腾讯" },
            { "Microsoft Corporation", "微软" },
            { "Beijing Duyou", "百度" },
        };
        public Dictionary<string, string> UserDatas = new Dictionary<string, string>
        {
            { "Administrator", "用于管理计算机/域的内置帐户" },
            { "DefaultAccount", "由系统管理的用户帐户。" },
            { "Guest", "用于访客访问计算机/域的内置帐户" },
            { "WDAGUtilityAccount", "系统为Windows Defender Application Guard场景管理和使用的用户帐户。" },
            { "$","隐藏用户" }
        };
        public Dictionary<string, string> LoginType = new Dictionary<string, string>
        {
            { "2", "本地登录" },
            { "3", "网络登录" },
            { "4", "批处理登录" },
            { "5", "服务登录" },
            { "7","解锁登录" },
            { "8","网络明文登录" },
            { "9","新凭证登录" },
            { "10","远程交互登录" },
            { "11","缓存交互登录" },
            { "-","-" },
            { "0","0"},
        };
    }
    public class ServiceCreateLog : NotifyProperty
    {
        private string time;
        private string type;
        private string source;
        private string starttype;
        private string stattfilename;
        private string sign;    
        private bool ismalicious;
        private CellImage[] cellImages;
        private CellTag[] cellTags;
        private CellBadge cellBadge;
        private CellText cellText;
        private CellLink[] cellLinks;
        private CellProgress cellProgress;
        private CellDivider cellDivider;
        private ServiceCreateLog[] servicecreatelogs;
        public string StartFileName
        {
            get
            {
                return stattfilename;
            }
            set
            {
                if (!(stattfilename == value))
                {
                    stattfilename = value;
                    OnPropertyChanged("StartFileName");
                }
            }
        }
        public string StartType
        {
            get
            {
                return starttype;
            }
            set
            {
                if (!(starttype == value))
                {
                    starttype = value;
                    OnPropertyChanged("StartType");
                }
            }
        }
        public string Source
        {
            get
            {
                return source;
            }
            set
            {
                if (!(source == value))
                {
                    source = value;
                    OnPropertyChanged("Source");
                }
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (!(type == value))
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                if (!(time == value))
                {
                    time = value;
                    OnPropertyChanged("Time");
                }
            }
        }
        public string Sign
        {
            get
            {
                return sign;
            }
            set
            {
                if (!(sign == value))
                {
                    sign = value;
                    OnPropertyChanged("sign");
                }
            }
        }
        public bool IsMalicious
        {
            get
            {
                return ismalicious;
            }
            set
            {
                if (ismalicious != value)
                {
                    ismalicious = value;
                    OnPropertyChanged("IsMalicious");
                }
            }
        }
        public CellImage[] CellImages
        {
            get
            {
                return cellImages;
            }
            set
            {
                if (cellImages != value)
                {
                    cellImages = value;
                    OnPropertyChanged("CellImages");
                }
            }
        }
        public CellTag[] CellTags
        {
            get
            {
                return cellTags;
            }
            set
            {
                if (cellTags != value)
                {
                    cellTags = value;
                    OnPropertyChanged("CellTags");
                }
            }
        }
        public CellBadge CellBadge
        {
            get
            {
                return cellBadge;
            }
            set
            {
                if (cellBadge != value)
                {
                    cellBadge = value;
                    OnPropertyChanged("CellBadge");
                }
            }
        }
        public CellText CellText
        {
            get
            {
                return cellText;
            }
            set
            {
                if (cellText != value)
                {
                    cellText = value;
                    OnPropertyChanged("CellText");
                }
            }
        }
        public CellLink[] CellLinks
        {
            get
            {
                return cellLinks;
            }
            set
            {
                if (cellLinks != value)
                {
                    cellLinks = value;
                    OnPropertyChanged("CellLinks");
                }
            }
        }
        public CellProgress CellProgress
        {
            get
            {
                return cellProgress;
            }
            set
            {
                if (cellProgress != value)
                {
                    cellProgress = value;
                    OnPropertyChanged("CellProgress");
                }
            }
        }
        public CellDivider CellDivider
        {
            get
            {
                return cellDivider;
            }
            set
            {
                if (cellDivider != value)
                {
                    cellDivider = value;
                    OnPropertyChanged("CellDivider");
                }
            }
        }
        public ServiceCreateLog[] ServiceCreateLogs
        {
            get
            {
                return servicecreatelogs;
            }
            set
            {
                if (servicecreatelogs != value)
                {
                    servicecreatelogs = value;
                    OnPropertyChanged("ServiceCreateLog");
                }
            }
        }
    }
    public class PowerShellLog : NotifyProperty
    {
        private string time;
        private string type;
        private string source;
        private string commandexec;
        private string sign;
        private bool ismalicious;
        private CellImage[] cellImages;
        private CellTag[] cellTags;
        private CellBadge cellBadge;
        private CellText cellText;
        private CellLink[] cellLinks;
        private CellProgress cellProgress;
        private CellDivider cellDivider;
        private PowerShellLog[] PowerShellLogs;
        public string CommandExec
        {
            get
            {
                return commandexec;
            }
            set
            {
                if (!(commandexec == value))
                {
                    commandexec = value;
                    OnPropertyChanged("CommandExec");
                }
            }
        }
        public string Source
        {
            get
            {
                return source;
            }
            set
            {
                if (!(source == value))
                {
                    source = value;
                    OnPropertyChanged("Source");
                }
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (!(type == value))
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                if (!(time == value))
                {
                    time = value;
                    OnPropertyChanged("Time");
                }
            }
        }
        public string Sign
        {
            get
            {
                return sign;
            }
            set
            {
                if (!(sign == value))
                {
                    sign = value;
                    OnPropertyChanged("sign");
                }
            }
        }
        public bool IsMalicious
        {
            get
            {
                return ismalicious;
            }
            set
            {
                if (ismalicious != value)
                {
                    ismalicious = value;
                    OnPropertyChanged("IsMalicious");
                }
            }
        }
        public CellImage[] CellImages
        {
            get
            {
                return cellImages;
            }
            set
            {
                if (cellImages != value)
                {
                    cellImages = value;
                    OnPropertyChanged("CellImages");
                }
            }
        }
        public CellTag[] CellTags
        {
            get
            {
                return cellTags;
            }
            set
            {
                if (cellTags != value)
                {
                    cellTags = value;
                    OnPropertyChanged("CellTags");
                }
            }
        }
        public CellBadge CellBadge
        {
            get
            {
                return cellBadge;
            }
            set
            {
                if (cellBadge != value)
                {
                    cellBadge = value;
                    OnPropertyChanged("CellBadge");
                }
            }
        }
        public CellText CellText
        {
            get
            {
                return cellText;
            }
            set
            {
                if (cellText != value)
                {
                    cellText = value;
                    OnPropertyChanged("CellText");
                }
            }
        }
        public CellLink[] CellLinks
        {
            get
            {
                return cellLinks;
            }
            set
            {
                if (cellLinks != value)
                {
                    cellLinks = value;
                    OnPropertyChanged("CellLinks");
                }
            }
        }
        public CellProgress CellProgress
        {
            get
            {
                return cellProgress;
            }
            set
            {
                if (cellProgress != value)
                {
                    cellProgress = value;
                    OnPropertyChanged("CellProgress");
                }
            }
        }
        public CellDivider CellDivider
        {
            get
            {
                return cellDivider;
            }
            set
            {
                if (cellDivider != value)
                {
                    cellDivider = value;
                    OnPropertyChanged("CellDivider");
                }
            }
        }
        public PowerShellLog[] powershelllogs
        {
            get
            {
                return powershelllogs;
            }
            set
            {
                if (powershelllogs != value)
                {
                    powershelllogs = value;
                    OnPropertyChanged("PowerShellLog");
                }
            }
        }
    }
    public class Log : NotifyProperty
    {
        private string time;
        private string id;
        private string logintype;
        private string logtype;
        private string source;
        private string sourceip;
        private string sourcename;
        private string localip;
        private string loginname;
        private string process;
        private CellLink[] position;
        private CellTag[] malicious;
        private string sign;
        private bool ismalicious;
        private CellImage[] cellImages;
        private CellTag[] cellTags;
        private CellBadge cellBadge;
        private CellText cellText;
        private CellLink[] cellLinks;
        private CellProgress cellProgress;
        private CellDivider cellDivider;
        private Log[] Logs;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                if (!(id == value))
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
        public string Sourcename
        {
            get
            {
                return sourcename;
            }
            set
            {
                if (!(sourcename == value))
                {
                    sourcename = value;
                    OnPropertyChanged("Sourcename");
                }
            }
        }
        public string Logintype
        {
            get
            {
                return logintype;
            }
            set
            {
                if (!(logintype == value))
                {
                    logintype = value;
                    OnPropertyChanged("Logintype");
                }
            }
        }
        public string Logtype
        {
            get
            {
                return logtype;
            }
            set
            {
                if (!(logtype == value))
                {
                    logtype = value;
                    OnPropertyChanged("Logtype");
                }
            }
        }
        public string Time
        {
            get
            {
                return time;
            }
            set
            {
                if (!(time == value))
                {
                    time = value;
                    OnPropertyChanged("Time");
                }
            }
        }
        public string Source
        {
            get
            {
                return source;
            }
            set
            {
                if (!(source == value))
                {
                    source = value;
                    OnPropertyChanged("Source");
                }
            }
        }
        public string Sourceip
        {
            get
            {
                return sourceip;
            }
            set
            {
                if (!(sourceip == value))
                {
                    sourceip = value;
                    OnPropertyChanged("Sourceip");
                }
            }
        }
        public string LocalIp
        {
            get
            {
                return localip;
            }
            set
            {
                if (!(localip == value))
                {
                    localip = value;
                    OnPropertyChanged("localip");
                }
            }
        }
        public string Loginname
        {
            get
            {
                return loginname;
            }
            set
            {
                if (!(loginname == value))
                {
                    loginname = value;
                    OnPropertyChanged("Loginname");
                }
            }
        }
        public string Process
        {
            get
            {
                return process;
            }
            set
            {
                if (!(process == value))
                {
                    process = value;
                    OnPropertyChanged("Process");
                }
            }
        }
        public CellLink[] Position
        {
            get
            {
                return position;
            }
            set
            {
                if (position != value)
                {
                    position = value;
                    OnPropertyChanged("Position");
                }
            }
        }
        public CellTag[] Malicious
        {
            get
            {
                return malicious;
            }
            set
            {
                if (malicious != value)
                {
                    malicious = value;
                    OnPropertyChanged("Malicious");
                }
            }
        }
        public string Sign
        {
            get
            {
                return sign;
            }
            set
            {
                if (!(sign == value))
                {
                    sign = value;
                    OnPropertyChanged("sign");
                }
            }
        }
        public bool IsMalicious
        {
            get
            {
                return ismalicious;
            }
            set
            {
                if (ismalicious != value)
                {
                    ismalicious = value;
                    OnPropertyChanged("IsMalicious");
                }
            }
        }
        public CellImage[] CellImages
        {
            get
            {
                return cellImages;
            }
            set
            {
                if (cellImages != value)
                {
                    cellImages = value;
                    OnPropertyChanged("CellImages");
                }
            }
        }
        public CellTag[] CellTags
        {
            get
            {
                return cellTags;
            }
            set
            {
                if (cellTags != value)
                {
                    cellTags = value;
                    OnPropertyChanged("CellTags");
                }
            }
        }
        public CellBadge CellBadge
        {
            get
            {
                return cellBadge;
            }
            set
            {
                if (cellBadge != value)
                {
                    cellBadge = value;
                    OnPropertyChanged("CellBadge");
                }
            }
        }
        public CellText CellText
        {
            get
            {
                return cellText;
            }
            set
            {
                if (cellText != value)
                {
                    cellText = value;
                    OnPropertyChanged("CellText");
                }
            }
        }
        public CellLink[] CellLinks
        {
            get
            {
                return cellLinks;
            }
            set
            {
                if (cellLinks != value)
                {
                    cellLinks = value;
                    OnPropertyChanged("CellLinks");
                }
            }
        }
        public CellProgress CellProgress
        {
            get
            {
                return cellProgress;
            }
            set
            {
                if (cellProgress != value)
                {
                    cellProgress = value;
                    OnPropertyChanged("CellProgress");
                }
            }
        }
        public CellDivider CellDivider
        {
            get
            {
                return cellDivider;
            }
            set
            {
                if (cellDivider != value)
                {
                    cellDivider = value;
                    OnPropertyChanged("CellDivider");
                }
            }
        }
        public Log[] logs
        {
            get
            {
                return logs;
            }
            set
            {
                if (logs != value)
                {
                    logs = value;
                    OnPropertyChanged("Log");
                }
            }
        }
    }
    public class Hotfix : NotifyProperty
    {
        private bool selected;
        private string id;
        private string describe;
        private string processname;
        private string pid;
        private bool enabled;
        private CellImage[] cellImages;
        private CellTag[] cellTags;
        private CellBadge cellBadge;
        private CellText cellText;
        private CellLink[] cellLinks;
        private CellProgress cellProgress;
        private CellDivider cellDivider;
        private Hotfix[] Hotfixs;
        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                if (selected != value)
                {
                    selected = value;
                    OnPropertyChanged("Selected");
                }
            }
        }
        public string Describe
        {
            get
            {
                return describe;
            }
            set
            {
                if (!(describe == value))
                {
                    describe = value;
                    OnPropertyChanged("Describe");
                }
            }
        }
        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                if (!(id == value))
                {
                    id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        public string ProcessName
        {
            get
            {
                return processname;
            }
            set
            {
                if (!(processname == value))
                {
                    processname = value;
                    OnPropertyChanged("ProcessName");
                }
            }
        }
        public string Pid
        {
            get
            {
                return pid;
            }
            set
            {
                if (!(pid == value))
                {
                    pid = value;
                    OnPropertyChanged("Pid");
                }
            }
        }
        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                if (enabled != value)
                {
                    enabled = value;
                    OnPropertyChanged("Enabled");
                }
            }
        }
        public CellImage[] CellImages
        {
            get
            {
                return cellImages;
            }
            set
            {
                if (cellImages != value)
                {
                    cellImages = value;
                    OnPropertyChanged("CellImages");
                }
            }
        }
        public CellTag[] CellTags
        {
            get
            {
                return cellTags;
            }
            set
            {
                if (cellTags != value)
                {
                    cellTags = value;
                    OnPropertyChanged("CellTags");
                }
            }
        }
        public CellBadge CellBadge
        {
            get
            {
                return cellBadge;
            }
            set
            {
                if (cellBadge != value)
                {
                    cellBadge = value;
                    OnPropertyChanged("CellBadge");
                }
            }
        }
        public CellText CellText
        {
            get
            {
                return cellText;
            }
            set
            {
                if (cellText != value)
                {
                    cellText = value;
                    OnPropertyChanged("CellText");
                }
            }
        }
        public CellLink[] CellLinks
        {
            get
            {
                return cellLinks;
            }
            set
            {
                if (cellLinks != value)
                {
                    cellLinks = value;
                    OnPropertyChanged("CellLinks");
                }
            }
        }
        public CellProgress CellProgress
        {
            get
            {
                return cellProgress;
            }
            set
            {
                if (cellProgress != value)
                {
                    cellProgress = value;
                    OnPropertyChanged("CellProgress");
                }
            }
        }
        public CellDivider CellDivider
        {
            get
            {
                return cellDivider;
            }
            set
            {
                if (cellDivider != value)
                {
                    cellDivider = value;
                    OnPropertyChanged("CellDivider");
                }
            }
        }
        public Hotfix[] hotfixs
        {
            get
            {
                return hotfixs;
            }
            set
            {
                if (hotfixs != value)
                {
                    hotfixs = value;
                    OnPropertyChanged("Hotfix");
                }
            }
        }
    }
    public class StartUp : NotifyProperty
    {
        private string processname;
        private string pid;
        private bool selected;
        private string name;
        private CellLink[] position;
        private string fullposition;
        private CellTag[] malicious;
        private string sign;
        private bool ismalicious;
        private CellImage[] cellImages;
        private CellTag[] cellTags;
        private CellBadge cellBadge;
        private CellText cellText;
        private CellLink[] cellLinks;
        private CellProgress cellProgress;
        private CellDivider cellDivider;
        private StartUp[] StartUps;
        public string FullPosition
        {
            get
            {
                return fullposition;
            }
            set
            {
                if (!(fullposition == value))
                {
                    fullposition = value;
                    OnPropertyChanged("FullPosition");
                }
            }
        }
        public string ProcessName
        {
            get
            {
                return processname;
            }
            set
            {
                if (!(processname == value))
                {
                    processname = value;
                    OnPropertyChanged("ProcessName");
                }
            }
        }
        public string Pid
        {
            get
            {
                return pid;
            }
            set
            {
                if (!(pid == value))
                {
                    pid = value;
                    OnPropertyChanged("Pid");
                }
            }
        }
        public bool Selected
        {
            get
            {
                return selected;
            }
            set
            {
                if (selected != value)
                {
                    selected = value;
                    OnPropertyChanged("Selected");
                }
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!(name == value))
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        public CellLink[] Position
        {
            get
            {
                return position;
            }
            set
            {
                if (position != value)
                {
                    position = value;
                    OnPropertyChanged("Position");
                }
            }
        }
        public CellTag[] Malicious
        {
            get
            {
                return malicious;
            }
            set
            {
                if (malicious != value)
                {
                    malicious = value;
                    OnPropertyChanged("Malicious");
                }
            }
        }
        public string Sign
        {
            get
            {
                return sign;
            }
            set
            {
                if (!(sign == value))
                {
                    sign = value;
                    OnPropertyChanged("sign");
                }
            }
        }
        public bool IsMalicious
        {
            get
            {
                return ismalicious;
            }
            set
            {
                if (ismalicious != value)
                {
                    ismalicious = value;
                    OnPropertyChanged("IsMalicious");
                }
            }
        }
        public CellImage[] CellImages
        {
            get
            {
                return cellImages;
            }
            set
            {
                if (cellImages != value)
                {
                    cellImages = value;
                    OnPropertyChanged("CellImages");
                }
            }
        }
        public CellTag[] CellTags
        {
            get
            {
                return cellTags;
            }
            set
            {
                if (cellTags != value)
                {
                    cellTags = value;
                    OnPropertyChanged("CellTags");
                }
            }
        }
        public CellBadge CellBadge
        {
            get
            {
                return cellBadge;
            }
            set
            {
                if (cellBadge != value)
                {
                    cellBadge = value;
                    OnPropertyChanged("CellBadge");
                }
            }
        }
        public CellText CellText
        {
            get
            {
                return cellText;
            }
            set
            {
                if (cellText != value)
                {
                    cellText = value;
                    OnPropertyChanged("CellText");
                }
            }
        }
        public CellLink[] CellLinks
        {
            get
            {
                return cellLinks;
            }
            set
            {
                if (cellLinks != value)
                {
                    cellLinks = value;
                    OnPropertyChanged("CellLinks");
                }
            }
        }
        public CellProgress CellProgress
        {
            get
            {
                return cellProgress;
            }
            set
            {
                if (cellProgress != value)
                {
                    cellProgress = value;
                    OnPropertyChanged("CellProgress");
                }
            }
        }
        public CellDivider CellDivider
        {
            get
            {
                return cellDivider;
            }
            set
            {
                if (cellDivider != value)
                {
                    cellDivider = value;
                    OnPropertyChanged("CellDivider");
                }
            }
        }
        public StartUp[] startups
        {
            get
            {
                return startups;
            }
            set
            {
                if (startups != value)
                {
                    startups = value;
                    OnPropertyChanged("StartUp");
                }
            }
        }
    }
}
