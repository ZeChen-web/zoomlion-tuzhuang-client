using System.Linq;
using System.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RS.Model;
using RS.DBUtility;

namespace RS.SQLServerDAL
{
    public class SPMOperatorClientReInfo
    {

        /// <summary>
        /// 根据操作者ID得到该操作者可操作的客户端ID
        /// </summary>
        /// <param name="strOperatorID"></param>
        /// <returns></returns>
        public List<string> GetClientNOListByOperatorID(int strOperatorID)
        {
            List<string> clientNOList = null;

            #region 查询字符串

            StringBuilder selectString = new StringBuilder();
            selectString.AppendLine("SELECT F_CLIENTNO FROM T_PM_OPERATORCLIENTREINFO" + " ");
            selectString.AppendLine("WHERE F_OPERATORID='" + strOperatorID + "'");
            DataTable resultTable = new DataTable();
            MySqlHelper sHelper = new MySqlHelper();
            resultTable = sHelper.QuerySql(selectString.ToString());

            #endregion 查询字符串

            int row_count = resultTable.Rows.Count;
            if (row_count > 0)
            {
                clientNOList = new List<string>();
                for (int i = 0; i < row_count; i++)
                {
                    string clientNO = "";
                    clientNO = resultTable.Rows[i]["F_CLIENTNO"].ToString().Trim();
                    if (clientNO != "")
                    {
                        clientNOList.Add(clientNO);
                    }
                }
                clientNOList = clientNOList.Distinct().ToList();
            }
            return clientNOList;
        }


    }
}
