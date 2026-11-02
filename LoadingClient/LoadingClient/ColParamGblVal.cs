using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using RS.Model;

namespace RS.Common
{
    /// <summary>
    /// 采集参数设置公共值
    /// </summary>
    public class ColParamGblVal
    {
        /// <summary>
        /// Redis中处理DB库号码
        /// </summary>
        public static int G_DbNumD = 8;
        /// <summary>
        /// Redis中实时DB库号码
        /// </summary>
        public static int G_DbNumR = 10;

        /// <summary>
        /// 线程读写的状态变量
        /// </summary>
        public static bool G_IsReadValue = true;

        #region 数据采集周期与循环保存节点值
        /// <summary>
        /// 控制器每次采集间隔时间
        /// </summary>
        public static int G_DataColPeriod = 1000;        //1000毫秒-1秒
        /// <summary> 
        /// 设备参数值采集信息存储周期
        /// </summary>
        private static int G_ParamStdPeriod = 2000;       //2000毫秒-2秒
        /// <summary> 
        /// 设备参数值采集信息中存储时间节点需要循环采集次数
        /// </summary>
        public static int G_ParamStdPoint = G_ParamStdPeriod / G_DataColPeriod;       //2000毫秒-2秒

        #endregion 数据采集周期与循环保存节点值


    }

}
