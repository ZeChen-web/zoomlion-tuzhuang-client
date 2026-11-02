//ping通ip类  测试ip地址是否连通
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Diagnostics;

namespace RS.Common
{
    public class PingHelper
    {
        public bool Ping(string ip)
        {
            try
            {
                if (ip == "") return false;
                if (ip == "127.0.0.1" || ip == "localhost") return true;
                Ping pingSender = new Ping();
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string data = "p";
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                int timeout = 500;
                //如果网络连接成功，PING就应该有返回；否则，网络连接有问题
                PingReply reply = pingSender.Send(ip, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }


        public static bool CmdPing(string strIp,int times)
        {
            Process p = new Process(); p.StartInfo.FileName = "cmd.exe";//设定程序名
            p.StartInfo.UseShellExecute = false; //关闭Shell的使用
            p.StartInfo.RedirectStandardInput = true;//重定向标准输入
            p.StartInfo.RedirectStandardOutput = true;//重定向标准输出
            p.StartInfo.RedirectStandardError = true;//重定向错误输出
            p.StartInfo.CreateNoWindow = true;//设置不显示窗口
            string pingrst; 
            p.Start(); 
            p.StandardInput.WriteLine($"ping -n {times} {strIp}");
            p.StandardInput.WriteLine("exit");

            string output = p.StandardOutput.ReadToEnd();
            string error = p.StandardError.ReadToEnd();

            // 等待进程退出
            p.WaitForExit();

            // 检查输出以确定ping是否成功
            if (output.Contains("(0% 丢失)"))
            {
                return true; // ping成功
            }

            //p.Close();

            return false;

        }


    }
}
