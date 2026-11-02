using System;
using System.Data;
using RS.Common;
using RS.DBUtility;

namespace RS.SQLServerDAL
{
    public class SDataBaseManage
    {
        /// <summary>
        /// 数据库是否连接
        /// </summary>
        /// <returns></returns>
        public bool DBIsConnected()
        {
            bool isConnected = false;
            try
            {
                MySqlHelper sqlHelper = new MySqlHelper();
                sqlHelper.DBConnection();
                //确认是否已打开连接，为打开则打开连接
                if (sqlHelper.SqlConn.State == ConnectionState.Open)
                {
                    isConnected = true;
                }
                return isConnected;
            }
            catch(Exception ex)
            {
                ex.ToString();
                LogInfo.LogInfoInstance.WriteLogInfo("异常信息：" + ex, LogType.Information, "数据库连接异常");
                return isConnected;
            }
        }
    }
}
