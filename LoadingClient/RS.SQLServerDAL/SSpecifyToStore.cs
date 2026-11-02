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
    /// <summary>
    /// 操作数据表t_ts_hand_move_index
    /// </summary>
    public class SSpecifyToStore
    {
        /// <summary>
        /// 更新停/开库信息
        /// </summary>
        /// <param name="MageText">是否停库</param>
        /// <param name="id">工位</param>
        /// <returns>true入库成功false入库失败</returns>
        public bool UpdateSpecifyToStore(string MageText,string id)
        {
            bool bResult = false;
            try
            {
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("UPDATE T_TS_CACHE_STOP SET " + " ");
                selectString.AppendLine("WHETHER_STOP='" + MageText+ "', ");
                selectString.AppendLine("UPDATE_TIME='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+ "' ");
                selectString.AppendLine("WHERE id='" + id+ "' ");
                MySqlHelper sHelper = new MySqlHelper();
                bResult = sHelper.ExecuteBNonQuerySQL(selectString.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return bResult;
        }
        public DataTable MSpecifyToStoreDataTable()
        {
            DataTable dtresult = null;
            try
            {
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("select Id,line_code,aisle,cache_area,whether_stop,update_time from t_ts_cache_stop");
                MySqlHelper sHelper = new MySqlHelper();
                dtresult = sHelper.QuerySql(selectString.ToString());
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return dtresult;
        }

        public List<string> t_ts_cache_stop(string line_code,string aisle)
        {
            List<string> strings = new List<string>();
            try
            {
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT * FROM T_TS_CACHE_STOP" + " ");
                selectString.AppendLine("WHERE LINE_CODE='" + line_code + "'" + " ");
                selectString.AppendLine("AND AISLE LIKE'" + aisle + "'" + " ");
                MySqlHelper sHelper = new MySqlHelper();
                DataTable dtresult = sHelper.QuerySql(selectString.ToString());
                if (dtresult != null && dtresult.Rows.Count > 0)
                {
                    for(int i = 0; i < dtresult.Rows.Count; i++)
                    {
                        string tc_type = (dtresult.Rows[i]["tc_type"] == null) ? "00" : dtresult.Rows[i]["tc_type"].ToString();
                        strings.Add(tc_type);
                    }
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return strings;
        }

        public bool updateType(string line_code,string aisle,string tc_type)
        {
            bool bResult = false;
            try
            {
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("UPDATE T_TS_CACHE_STOP SET" + " ");
                selectString.AppendLine("TC_TYPE='"+tc_type+"'," + " ");
                selectString.AppendLine("UPDATE_TIME='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'" + " ");
                selectString.AppendLine("WHERE LINE_CODE = '" + line_code + "'" + " ");
                selectString.AppendLine("AND AISLE = '" + aisle + "'" + " ");
                MySqlHelper sHelper = new MySqlHelper();
                bResult = sHelper.ExecuteBNonQuerySQL(selectString.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return bResult;
        }
    }
}
