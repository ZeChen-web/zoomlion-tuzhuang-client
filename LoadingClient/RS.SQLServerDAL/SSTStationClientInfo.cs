using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using RS.Model;
using RS.DBUtility;
namespace RS.SQLServerDAL
{
    public class SSTStationClientInfo
    {

        /// <summary>
        /// 根据客户端编码查询机台设备信息列表（客户端管理的机台设备）
        /// </summary>
        /// <param name="srcClientNo">客户端编码</param>
        /// <returns>机台设备信息列表</returns>
        public List<MSTStationInfo> GetStationInfoListByClientNo(string srcClientNo)
        {
            List<MSTStationInfo> stationInfoList = null;
            try
            {
                #region 查询字符串

                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT ST.F_ID,ST.F_STATIONNO,ST.F_STATIONNAME,ST.F_LINENO,ST.F_LINENAME,ST.F_CREATOR," + " ");
                selectString.AppendLine("ST.F_CREATIONDATE FROM T_ST_STATIONINFO ST,T_ST_STATIONCLIENTREINFO SC" + " ");
                selectString.AppendLine("WHERE SC.F_CLIENTNO='" + srcClientNo + "'");
                selectString.AppendLine("AND SC.F_STATIONNO=ST.F_STATIONNO" + " ");
                selectString.AppendLine("ORDER BY ST.F_STATIONNO ASC");

                DataTable dtResult = new DataTable();
                MySqlHelper sHelper = new MySqlHelper();
                dtResult = sHelper.QuerySql(selectString.ToString());

                #endregion 查询字符串

                int row_count = dtResult.Rows.Count;
                if (row_count > 0)
                {
                    stationInfoList = new List<MSTStationInfo>();
                    for (int i = 0; i < row_count; i++)
                    {
                        MSTStationInfo stationInfo = new MSTStationInfo();

                        object objID = dtResult.Rows[i]["F_ID"];
                        stationInfo.F_ID = ((objID == null) || (objID.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objID.ToString().Trim());

                        stationInfo.F_STATIONNO = (dtResult.Rows[i]["F_STATIONNO"] == null) ? "" : dtResult.Rows[i]["F_STATIONNO"].ToString();
                        stationInfo.F_STATIONNAME = (dtResult.Rows[i]["F_STATIONNAME"] == null) ? "" : dtResult.Rows[i]["F_STATIONNAME"].ToString();

                        stationInfo.F_LINENO = (dtResult.Rows[i]["F_LINENO"] == null) ? "" : dtResult.Rows[i]["F_LINENO"].ToString();
                        stationInfo.F_LINENAME = (dtResult.Rows[i]["F_LINENAME"] == null) ? "" : dtResult.Rows[i]["F_LINENAME"].ToString();

                        stationInfo.F_CREATOR = (dtResult.Rows[i]["F_CREATOR"] == null) ? "" : dtResult.Rows[i]["F_CREATOR"].ToString();
                        object objCREATIONDATE = dtResult.Rows[i]["F_CREATIONDATE"];
                        stationInfo.F_CREATIONDATE = ((objCREATIONDATE == null) || (objCREATIONDATE.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objCREATIONDATE.ToString().Trim());

                        stationInfoList.Add(stationInfo);
                    }
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            return stationInfoList;
        }

        /// <summary>
        /// 根据客户端编码查询机台设备信息列表（客户端管理的机台设备）
        /// </summary>
        /// <param name="srcClientNo">客户端编码</param>
        /// <returns>机台设备信息列表</returns>
        public DataTable GetStationInfoByClientNo(string srcClientNo)
        {
            DataTable dtResult = null;
            try
            {
                #region 查询字符串

                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT ST.F_ID,ST.F_STATIONNO,ST.F_STATIONNAME,ST.F_LINENO,ST.F_LINENAME,ST.F_CREATOR," + " ");
                selectString.AppendLine("ST.F_CREATIONDATE FROM T_ST_STATIONINFO ST,T_ST_STATIONCLIENTREINFO SC" + " ");
                selectString.AppendLine("WHERE SC.F_CLIENTNO='" + srcClientNo + "'");
                selectString.AppendLine("AND SC.F_STATIONNO=ST.F_STATIONNO" + " ");
                selectString.AppendLine("ORDER BY ST.F_STATIONNO ASC");

                MySqlHelper sHelper = new MySqlHelper();
                dtResult = sHelper.QuerySql(selectString.ToString());

                #endregion 查询字符串

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dtResult;
        }
    }
}
