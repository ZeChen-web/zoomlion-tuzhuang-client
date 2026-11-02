using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using System.Text;
using RS.Model;
using RS.DBUtility;

namespace RS.SQLServerDAL
{
    public class SRTOperatorLoginInfo
    {
        /// <summary>
        /// 添加操作员登录信息
        /// </summary>
        /// <param name="srcOptLoginInfo"></param>
        /// <returns></returns>
        public bool AddOperatorLoginInInfo(MRTOperatorLoginInfo srcOptLoginInfo)
        {
            try
            {
                bool bRes = false;
                #region 数据更新操作字符串

                string resultString = SqlHelper.GetInsertSQL<MRTOperatorLoginInfo>(MRTOperatorLoginInfo.TableName, srcOptLoginInfo, "F_ID");
                MySqlHelper sHelper = new MySqlHelper();
                int iRes = sHelper.ExecuteNonQuerySQL(resultString);

                #endregion 数据更新操作字符串
                if (iRes != 0)
                {
                    bRes = true;
                }

                return bRes;
            }
            catch(Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        /// <summary>
        /// 编辑操作员退出时间
        /// </summary>
        /// <param name="srcOptLoginInfo"></param>
        /// <returns></returns>
        public bool EditOperatorLoginOutInfo(MRTOperatorLoginInfo srcOptLoginInfo)
        {
            try
            {
                bool bRes = false;
                #region 数据更新操作字符串
                srcOptLoginInfo.F_LOGINOUTTIME = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                string strTemp = "UPDATE {0} SET F_LOGINOUTTIME ='{1}'";
                strTemp += " " + " WHERE F_ID=(SELECT ub.F_ID FROM";
                strTemp += " " + " (SELECT ua.F_ID FROM {0} ua";
                strTemp += " " + "WHERE  ua.F_LOGGINGCARD='{2}'";
                strTemp += " " + "AND ua.F_CLIENTNO='{3}'";
                strTemp += " " + " AND ua.F_LINEID='{4}'";
                strTemp += " " + "ORDER BY ua.F_ID DESC LIMIT 0,1)ub)";
                string strSQL = "";
                strSQL = String.Format(strTemp, MRTOperatorLoginInfo.TableName, srcOptLoginInfo.F_LOGINOUTTIME, srcOptLoginInfo.F_LOGGINGCARD, srcOptLoginInfo.F_CLIENTNO, srcOptLoginInfo.F_LINEID);
                MySqlHelper sHelper = new MySqlHelper();
                int iRes = sHelper.ExecuteNonQuerySQL(strSQL);

                #endregion 数据更新操作字符串
                if (iRes != 0)
                {
                    bRes = true;
                }

                return bRes;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }


    }
}
