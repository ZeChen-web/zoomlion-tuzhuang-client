using System;

namespace RS.Common
{
    /// <summary>
    /// 时间公共类
    /// </summary>
    public class DateTimeUtil
    {
        #region 获得当前时间

        /// <summary>
        /// 当前时间
        /// 格式为:yyyy-MM-dd HH:mm:ss
        /// </summary>
        public static DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// 当前时间
        /// </summary>
        /// <param name="format">格式</param>
        public static string GetCurrentTime(string format)
        {
            try
            {
                return DateTime.Now.ToString(format);
            }
            catch
            {
                throw new Exception("字符串格式异常！");
            }
        }

        #endregion 获得当前时间

        #region 转换时间格式

        /// <summary>
        /// 时间转字符串
        /// </summary>
        public static string GetConvertTime(DateTime time, string format = null)
        {
            if (!String.IsNullOrEmpty(format))
                return time.ToString(format);
            else
                return time.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 字符串转时间
        /// </summary>
        public static DateTime GetConvertTime(string time)
        {
            return Convert.ToDateTime(time);
        }

        #endregion 转换时间格式

        #region 计算两个时间间隔

        public static int DateDiff(DateTime dateStart, DateTime dateEnd)
        {
            DateTime start = Convert.ToDateTime(dateStart.ToShortDateString());
            DateTime end = Convert.ToDateTime(dateEnd.ToShortDateString());

            TimeSpan sp = end.Subtract(start);

            return sp.Days;
        }

        #endregion 计算两个时间间隔

        #region 默认时间转换

        /// <summary>
        /// 将默认时间转换到最近一周
        /// </summary>
        public static void ConvertDefaultDatetime(string sTime, string eTime, out DateTime startTime, out DateTime endTime)
        {
            startTime = String.IsNullOrEmpty(sTime) ? DateTime.Now.AddDays(-7) : Convert.ToDateTime(sTime);
            endTime = Convert.ToDateTime(String.IsNullOrEmpty(eTime) ? DateTime.Now.ToString() : eTime);
        }

        #endregion 默认时间转换
    }
}