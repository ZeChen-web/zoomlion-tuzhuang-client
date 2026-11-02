using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;
using System.Text;
using RS.Model;
using RS.DBUtility;

namespace RS.SQLServerDAL
{
    public class SPMOperatorInfo
    {

        /// <summary>
        /// 根据登录卡号获取操作者基本信息
        /// </summary>
        /// <param name="loggingCard">登录卡号</param>
        /// <returns>操作者基本信息</returns>
        public MPMOperatorInfo GetOperatorInfoByAccount(string loggingCard)
        {
            MPMOperatorInfo infoResult = null;

            #region 查询字符串

            StringBuilder selectString = new StringBuilder();
            selectString.AppendLine("SELECT * FROM T_PM_OPERATORINFO WHERE F_LOGGINGCARD='" + loggingCard + "'");
            DataTable resultTable = new DataTable();
            MySqlHelper sHelper = new MySqlHelper();
            resultTable = sHelper.QuerySql(selectString.ToString());

            #endregion 查询字符串

            int row_count = resultTable.Rows.Count;
            if (row_count > 0)
            {
                infoResult = new MPMOperatorInfo();

                object objOPERATIORID = resultTable.Rows[0]["F_ID"];
                infoResult.F_ID = ((objOPERATIORID == null)|| (objOPERATIORID.ToString().Trim()==""))?0:Convert.ToInt32(objOPERATIORID.ToString().Trim());
                infoResult.F_OPERATORID = resultTable.Rows[0]["F_OPERATORID"].ToString();
                infoResult.F_OPERATORNAME = resultTable.Rows[0]["F_OPERATORNAME"].ToString();
                infoResult.F_OPERATORPWD = resultTable.Rows[0]["F_OPERATORPWD"].ToString();
                infoResult.F_LOGGINGCARD = resultTable.Rows[0]["F_LOGGINGCARD"].ToString();
                infoResult.F_IDCARD = resultTable.Rows[0]["F_IDCARD"].ToString();
                infoResult.F_MOBILE = resultTable.Rows[0]["F_MOBILE"].ToString();
                infoResult.F_STATUS = resultTable.Rows[0]["F_STATUS"].ToString();
                object objOperatorType = resultTable.Rows[0]["F_OPERATORTYPE"];
                infoResult.F_OPERATORTYPE = (objOperatorType == null || objOperatorType.ToString().Trim() == "") ? 0 : Convert.ToInt32(objOperatorType.ToString());
                infoResult.F_CREATOR = resultTable.Rows[0]["F_CREATOR"].ToString();
                object objCREATIONDATE = resultTable.Rows[0]["F_CREATIONDATE"];
                infoResult.F_CREATIONDATE = ((objCREATIONDATE == null) || (objCREATIONDATE.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objCREATIONDATE.ToString().Trim()); 
            }

            return infoResult;
        }

        /// <summary>
        /// 更新操作员信息表
        /// </summary>
        /// <param name="operatorInfo">操作员信息表</param>
        /// <returns>成功：1；失败：0</returns>
        public bool EditOperatorInfo(MPMOperatorInfo operatorInfo)
        {
            try
            {
                #region 数据更新操作字符串

                string resultString = SqlHelper.GetUpdateSql<MPMOperatorInfo>(MPMOperatorInfo.TableName, operatorInfo, new string[] { "F_LOGGINGCARD" }, "F_ID");
                MySqlHelper sHelper = new MySqlHelper();
                sHelper.ExecuteNonQuerySQL(resultString);

                #endregion 数据更新操作字符串

                return true;
            }
            catch
            {
                return false;
            }
        }



    }
}
