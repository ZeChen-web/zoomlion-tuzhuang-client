using MySqlX.XDevAPI.Common;
using RS.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.SQLServerDAL
{
    /// <summary>
    /// 创建更改请求
    /// </summary>
    public class SSelectInfo
    {
        MySqlHelper sHelper = new MySqlHelper();

        /// <summary>
        /// 建立更改请求
        /// </summary>
        /// <param name="cache_area">库区号</param>
        /// <param name="request">请求(0无请求1请求更改2同意更改3更改完成)</param>
        /// <returns></returns>
        public bool SetRequest(int cache_area, int request)
        {
            bool bResult = false;
            try
            {
                #region 查询字符串
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("UPDATE F_MT_MATERIAL_CHANGE SET" + " ");
                selectString.AppendLine("REQUEST = " + request + ", ");
                selectString.AppendLine("TIME='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ");
                selectString.AppendLine("WHERE CACHE_AREA=" + cache_area + " ");
                #endregion 查询字符串
                bResult = sHelper.ExecuteBNonQuerySQL(selectString.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return bResult;
        }

        /// <summary>
        /// 查询是否同意更改
        /// </summary>
        /// <param name="cache_area">库区号</param>
        /// <param name="request">请求(0无请求1请求更改2同意更改3更改完成)</param>
        /// <returns></returns>
        public int agreeRequest(int cache_area)
        {
            int iResult = 0;
            try
            {
                #region 查询字符串
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT * FROM F_MT_MATERIAL_CHANGE" + " ");
                selectString.AppendLine("WHERE CACHE_AREA='" + cache_area + "' ");
                DataTable resultTable = sHelper.QuerySql(selectString.ToString());
                #endregion 查询字符串
                if (resultTable.Rows.Count > 0)
                {
                    iResult = (resultTable.Rows[0]["request"] == null) ? 0 : Convert.ToInt16(resultTable.Rows[0]["request"]);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return iResult;
        }

        #region 收到请求后同意
        /// <summary>
        /// 收到请求后发送同意
        /// </summary>
        /// <param name="cache_area">库区号</param>
        /// <param name="request">请求</param>
        /// <returns></returns>
        public bool UpdateRequest(int cache_area, int request)
        {
            bool bResult = false;
            try
            {
                #region 查询字符串
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("UPDATE F_MT_MATERIAL_CHANGE SET" + " ");
                selectString.AppendLine("REQUEST = " + request + ", ");
                selectString.AppendLine("TIME='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' ");
                selectString.AppendLine("WHERE CACHE_AREA=" + cache_area + " ");
                #endregion 查询字符串
                bResult = sHelper.ExecuteBNonQuerySQL(selectString.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return bResult;
        }
        #endregion 收到请求后同意
    }
}
