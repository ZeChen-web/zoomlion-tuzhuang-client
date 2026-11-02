using System.Linq;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RS.Model;
using RS.DBUtility;

namespace RS.SQLServerDAL
{
    public class SSTClientInfo
    {
        #region 条件查询客户端信息
        /// <summary>
        /// 根据IP地址查询客户端信息
        /// </summary>
        /// <param name="srcIPAddr">客户端IP地址</param>
        /// <returns>客户端信息</returns>
        public MSTClientInfo GetClientInfoByClientIP(string srcIPAddr)
        {

            try
            {
                MSTClientInfo mdClientInfo = null;

                #region 查询字符串

                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT * FROM T_ST_CLIENTINFO" + " ");
                selectString.AppendLine("WHERE F_CLIENTIP='" + srcIPAddr.Trim() + "'" + " ");
                DataTable resultTable = new DataTable();
                MySqlHelper sHelper = new MySqlHelper();
                resultTable = sHelper.QuerySql(selectString.ToString());

                #endregion 查询字符串

                int row_count = resultTable.Rows.Count;
                if (row_count > 0)
                {
                    mdClientInfo = new MSTClientInfo();
                    string strID = resultTable.Rows[0]["F_ID"].ToString();
                    mdClientInfo.F_ID = ((strID == null) || (strID.Trim() == "")) ? 0 : Convert.ToInt32(strID);
                    mdClientInfo.F_CLIENTNO = resultTable.Rows[0]["F_CLIENTNO"].ToString();
                    mdClientInfo.F_CLIENTNAME = resultTable.Rows[0]["F_CLIENTNAME"].ToString();
                    mdClientInfo.F_CLIENTIP= resultTable.Rows[0]["F_CLIENTIP"].ToString();
                    mdClientInfo.F_LINENO = resultTable.Rows[0]["F_LINENO"].ToString();
                    mdClientInfo.F_LINENAME = resultTable.Rows[0]["F_LINENAME"].ToString();
                    mdClientInfo.F_WORKSHOPNO = resultTable.Rows[0]["F_WORKSHOPNO"].ToString();
                    mdClientInfo.F_WORKSHOPNAME = resultTable.Rows[0]["F_WORKSHOPNAME"].ToString();
                }
                return mdClientInfo;
            }
            catch
            {
                return null;
            }
        }
        #endregion 条件查询客户端信息
    }
}
