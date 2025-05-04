# MaliciousCheck
![MaliciousCheck](https://socialify.git.ci/Mangofang/MaliciousCheck/image?custom_description=%E5%9F%BA%E4%BA%8EC%23.Net%E7%9A%84%E5%BC%80%E6%BA%90%E5%BA%94%E6%80%A5%E5%93%8D%E5%BA%94%E5%B7%A5%E5%85%B7&description=1&font=Inter&forks=1&issues=1&language=1&logo=https%3A%2F%2Favatars.githubusercontent.com%2Fu%2F38810849%3Fv%3D4&name=1&owner=1&pattern=Circuit+Board&pulls=1&stargazers=1&theme=Dark)

> 基于C#.Net的开源应急响应工具

/// 程序测试中 ///

如果你有任何问题或反馈程序问题请提交`Issues`

![image](https://github.com/user-attachments/assets/6a14bdbe-d872-42f6-9784-5b85c308c301)

## 声明：
1. 文中所涉及的技术、思路和工具仅供以安全为目的的学习交流使用，任何人不得将其用于非法用途以及盈利等目的，否则后果自行承担！
2. 水平不高，纯萌新面向Google编程借鉴了很多大佬的代码，请自行酌情修改

## 支持平台：
Windows && .Net Framework >= 4.6.2

## 已实现的功能
+ **主机信息**：包括当前系统信息、补丁信息、StartUp启动项、注册表启动项、计划任务、用户信息、外部连接和进程的探测和扫描
+ **日志分析**：扫描Windows事件查看器中的信息并整理常见的诸如登录成功、登录失败、RDP登录和Powershell记录
+ **Yara扫描**：你可以通过内置的Yara对启动项和进程进行扫描
+ **云沙箱检测**：你可以通过配置``微步云沙箱API``对启动项进行上传检测
+ **IP威胁检测**：你可以通过配置``长亭IP威胁情报API``对外部连接的IP进行检测


## 更新

2025年5月4日

1.公开仓库


## 可能的更新
1. 代码优化
2. 文件上传扫描
3. 影子用户检测
4. 流量特征分析
5. 探针
6. 进程dll模块扫描
