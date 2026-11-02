using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.CRUD;
using RS.DBUtility;
using RS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.SQLServerDAL
{
    public class SCacheOut
    {
        MySqlHelper sHelper = new MySqlHelper();
        public bool InsertCacheOut(MCacheOut mCacheOut)
        {
            bool bResult = false;
            try
            {
                #region 查询字符串
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("INSERT into `t_ts_cache_out`(" + " ");
                selectString.AppendLine("xc_id,whether,cache_area,aisle,type,time" + " ");
                selectString.AppendLine(")VALUES(" + " ");
                selectString.AppendLine("'" + mCacheOut.xc_id+ "', ");
                selectString.AppendLine("'" +mCacheOut.whether+ "', ");
                selectString.AppendLine("'" +mCacheOut.cache_area+ "', ");
                selectString.AppendLine("'" +mCacheOut.aisle+ "', ");
                selectString.AppendLine("'" +mCacheOut.type+ "', ");
                selectString.AppendLine("'" +mCacheOut.time + "') ");
                #endregion 查询字符串
                bResult = sHelper.ExecuteBNonQuerySQL(selectString.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return bResult;
        }

        public bool DeleteCacheOut(MCacheOut mCacheOut)
        {
            bool bResult = false;
            try
            {
                #region 查询字符串
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("UPDATE T_TS_CACHE_OUT SET" + " ");
                selectString.AppendLine("WHETHER='" + mCacheOut.whether + "'," + " ");
                selectString.AppendLine("TIME='" + mCacheOut.time + "'" + " ");
                selectString.AppendLine("WHERE CACHE_AREA='" + mCacheOut.cache_area + "'" + " ");
                selectString.AppendLine("AND AISLE='" + mCacheOut.aisle + "'" + " ");
                selectString.AppendLine("AND XC_ID='" + mCacheOut.xc_id + "'" + " ");
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
        /// 判断是否已经添加了对应的小车号
        /// </summary>
        /// <param name="mCacheOut"></param>
        /// <returns></returns>
        public bool WhietherInCacheOut(MCacheOut mCacheOut)
        {
            bool bResult = false;
            try
            {
                #region 查询字符串
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT * FROM T_TS_CACHE_OUT" + " ");
                selectString.AppendLine("WHERE XC_ID='" + mCacheOut.xc_id + "'" + " ");
                selectString.AppendLine("AND WHETHER='1'" + " ");
                selectString.AppendLine("AND CACHE_AREA='" + mCacheOut.cache_area + "'" + " ");
                #endregion 查询字符串
                DataTable dataTable = sHelper.QuerySql(selectString.ToString());
                if (dataTable != null && dataTable.Rows.Count > 0) 
                {
                    bResult = true;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return bResult;
        }

        /// <summary>
        /// 获取小车号和顺序绑定
        /// </summary>
        /// <param name="cache_area">库存</param>
        /// <returns></returns>
        public Dictionary<string,int> xc_id_seq(string cache_area)
        {
            Dictionary<string, int> keyValuePairs = null;
            try
            {
                #region 查询字符串
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT * FROM T_TS_CACHE_OUT" + " ");
                selectString.AppendLine("WHERE WHETHER='1'" + " ");
                selectString.AppendLine("AND CACHE_AREA='" + cache_area + "'" + " ");
                #endregion 查询字符串
                DataTable dtResult = sHelper.QuerySql(selectString.ToString());
                if(dtResult != null && dtResult.Rows.Count > 0)
                {
                    keyValuePairs = new Dictionary<string, int>();
                    for(int i = 0; i < dtResult.Rows.Count; i++)
                    {
                        string xc_id = (dtResult.Rows[i]["xc_id"] == null) ? "" : dtResult.Rows[i]["xc_id"].ToString();
                        if (!string.IsNullOrEmpty(xc_id))
                        {
                            keyValuePairs.Add(xc_id, i);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return keyValuePairs;
        }
    }
}
