using System;
using System.IO;
using System.Reflection;

namespace RS.Common
{

    public enum LogType
    {
        Information,
        Debug,
        Run,
        Failure,
        Warning,
        Error
    }

    public class LogInfo
    {
        #region 实例化
        /// <summary>
        /// log文件锁
        /// </summary>
        private static object logLock;
        /// <summary>
        /// LogInfo实例
        /// </summary>
        private static LogInfo logInstance;
        /// <summary>
        /// 日志文件名
        /// </summary>
        private static string logFileName;
        private LogInfo() { }

        /// <summary>
        /// LogInfo实例
        /// </summary>
        public static LogInfo LogInfoInstance
        {
            get
            {
                if (logInstance == null)
                {
                    logInstance = new LogInfo();
                    logLock = new object();
                    logFileName = Guid.NewGuid() + ".log";
                }
                return logInstance;
            }
        }
        #endregion

        /// <summary>
        /// 写日志到日志文件
        /// </summary>
        /// <param name="logContent">Log内容</param>
        /// <param name="logType">Log类型</param>
        public void WriteLogInfo(string logContent, LogType logType = LogType.Information, string fileName = null)
        {
            try
            {
                string basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                basePath = @"D:\CanSwapLogs";
                if (!Directory.Exists(basePath + "\\RunLog"))
                {
                    Directory.CreateDirectory(basePath + "\\RunLog");
                }

                string strData = DateTime.Now.ToString("yyyy-MM-dd");
                if (!Directory.Exists(basePath + "\\RunLog\\" + strData))
                {
                    Directory.CreateDirectory(basePath + "\\RunLog\\" + strData);
                }

                string[] logText = new string[] { DateTime.Now.ToString("HH:mm:ss.fff") + ": " + logType.ToString() + ": " + logContent + " " + PublicParams.G_OperatorInfo?.F_OPERATORNAME };
                if (!string.IsNullOrEmpty(fileName))
                {
                    fileName = fileName + "_" + DateTime.Now.Hour.ToString();
                }
                else
                {
                    fileName = logFileName;
                }

                lock (logLock)
                {
                    File.AppendAllLines(basePath + "\\RunLog\\" + strData + "\\" + fileName + ".log", logText);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// 写异常日志到文件中
        /// </summary>
        /// <param name="exception">异常类型</param>
        public void WriteExceptionInfo(Exception exception, string specText = null)
        {
            if (exception != null)
            {
                Type exceptionType = exception.GetType();
                string text = string.Empty;
                if (!string.IsNullOrEmpty(specText))
                {
                    text = text + specText + Environment.NewLine;
                }
                text = "Exception: " + exceptionType.Name + Environment.NewLine;
                text += "               " + "Message: " + exception.Message + Environment.NewLine;
                text += "               " + "Source: " + exception.Source + Environment.NewLine;
                text += "               " + "StackTrace: " + exception.StackTrace + Environment.NewLine;
                WriteLogInfo(text, LogType.Error);
            }
        }
    }
}

