using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS.Model;
using System.Data;
using RS.DBUtility;

namespace RS.SQLServerDAL
{
    public class SPMPeopleInfo
    {
        /// <summary>
        /// 根据登录卡号获取呼叫处理人员基本信息
        /// </summary>
        /// <param name="loggingCard">登录卡号</param>
        /// <returns>呼叫处理人员基本信息</returns>
        public MPMPeopleInfo GetPeopleInfoByAccount(string loggingCard)
        {
            MPMPeopleInfo infoResult = null;

            #region 查询字符串

            StringBuilder selectString = new StringBuilder();
            selectString.AppendLine("SELECT * FROM T_PM_PEOPLEINFO WHERE F_LOGGINGCARD='" + loggingCard + "'");
            DataTable resultTable = new DataTable();
            MySqlHelper sHelper = new MySqlHelper();
            resultTable = sHelper.QuerySql(selectString.ToString());

            #endregion 查询字符串

            int row_count = resultTable.Rows.Count;
            if (row_count > 0)
            {
                infoResult = new MPMPeopleInfo();

                object objOPERATIORID = resultTable.Rows[0]["F_ID"];
                infoResult.F_ID = ((objOPERATIORID == null) || (objOPERATIORID.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objOPERATIORID.ToString().Trim());
                infoResult.F_PEOPLENAME = resultTable.Rows[0]["F_PEOPLENAME"].ToString();
                infoResult.F_PEOPLEPWD = resultTable.Rows[0]["F_PEOPLEPWD"].ToString();
                infoResult.F_LOGGINGCARD = resultTable.Rows[0]["F_LOGGINGCARD"].ToString();
                infoResult.F_IDCARD = resultTable.Rows[0]["F_IDCARD"].ToString();
                infoResult.F_MOBILE = resultTable.Rows[0]["F_MOBILE"].ToString();
                object objOperatorType = resultTable.Rows[0]["F_PEOPLEPRIV"];
                infoResult.F_PEOPLEPRIV = (objOperatorType == null || objOperatorType.ToString().Trim() == "") ? 0 : Convert.ToInt32(objOperatorType.ToString());
                infoResult.F_CREATOR = resultTable.Rows[0]["F_CREATOR"].ToString();
                object objCREATIONDATE = resultTable.Rows[0]["F_CREATIONDATE"];
                infoResult.F_CREATIONDATE = ((objCREATIONDATE == null) || (objCREATIONDATE.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objCREATIONDATE.ToString().Trim());
            }

            return infoResult;
        }
    }
}
