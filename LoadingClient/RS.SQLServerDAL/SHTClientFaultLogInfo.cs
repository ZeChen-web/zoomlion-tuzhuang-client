using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RS.Model;
using RS.DBUtility;

namespace RS.SQLServerDAL
{
    public class SHTClientFaultLogInfo
    {

        /// <summary>
        /// 获取机台设备客户端呼叫信息
        /// </summary>
        /// <param name="stationNo"></param>
        /// <returns></returns>
        public List<MHTClientFaultLogInfo> GetClientFaultLogInfoListByStationNo(string stationNo)
        {
            List<MHTClientFaultLogInfo> lstClientCLogInfo = null;

            #region 查询字符串

            StringBuilder selectString = new StringBuilder();
            selectString.AppendLine("SELECT * FROM T_HT_CLIENTFAULTLOGINFO" + " ");
            selectString.AppendLine("WHERE F_STATIONNO='" + stationNo + "'" + " ");
            selectString.AppendLine("AND F_REPAIRRESULT=0" + " ");
            selectString.AppendLine("ORDER BY F_ID");
            DataTable dtResult = new DataTable();
            MySqlHelper sHelper = new MySqlHelper();
            dtResult = sHelper.QuerySql(selectString.ToString());

            #endregion 查询字符串

            int row_count = dtResult.Rows.Count;
            if (row_count > 0)
            {
                lstClientCLogInfo = new List<MHTClientFaultLogInfo>();
                for (int i = 0; i < row_count; i++)
                {
                    MHTClientFaultLogInfo cLogInfo = new MHTClientFaultLogInfo();
                    object objID = dtResult.Rows[i]["F_ID"];
                    cLogInfo.F_ID = ((objID == null) || (objID.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objID.ToString().Trim());

                    cLogInfo.F_FAULTNO = (dtResult.Rows[i]["F_FAULTNO"] == null) ? "" : dtResult.Rows[i]["F_FAULTNO"].ToString();
                    cLogInfo.F_FAULTTYPE = (dtResult.Rows[i]["F_FAULTTYPE"] == null) ? "" : dtResult.Rows[i]["F_FAULTTYPE"].ToString();
                    object objSTATIONNO = dtResult.Rows[i]["F_STATIONNO"];
                    cLogInfo.F_STATIONNO = (objSTATIONNO == null) ? "" : objSTATIONNO.ToString();
                    cLogInfo.F_STATIONNAME = (dtResult.Rows[i]["F_STATIONNAME"] == null) ? "" : dtResult.Rows[i]["F_STATIONNAME"].ToString();

                    cLogInfo.F_OPERATOR = (dtResult.Rows[i]["F_OPERATOR"] == null) ? "" : dtResult.Rows[i]["F_OPERATOR"].ToString();
                    object objREPAIRTIME = dtResult.Rows[i]["F_REPAIRTIME"];
                    cLogInfo.F_REPAIRTIME = ((objREPAIRTIME == null) || (objREPAIRTIME.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objREPAIRTIME.ToString().Trim());
                    object objNORMALTIME = dtResult.Rows[i]["F_NORMALTIME"];
                    cLogInfo.F_NORMALTIME = ((objNORMALTIME == null) || (objNORMALTIME.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objNORMALTIME.ToString().Trim());

                    cLogInfo.F_RESTORER = (dtResult.Rows[i]["F_RESTORER"] == null) ? "" : dtResult.Rows[i]["F_RESTORER"].ToString();
                    cLogInfo.F_FAULTDESC = (dtResult.Rows[i]["F_FAULTDESC"] == null) ? "" : dtResult.Rows[i]["F_FAULTDESC"].ToString();
                    cLogInfo.F_REPAIRCONTENT = (dtResult.Rows[i]["F_REPAIRCONTENT"] == null) ? "" : dtResult.Rows[i]["F_REPAIRCONTENT"].ToString();

                    object objREPAIRRESULT = dtResult.Rows[i]["F_REPAIRRESULT"];
                    cLogInfo.F_REPAIRRESULT = ((objREPAIRRESULT == null) || (objREPAIRRESULT.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objREPAIRRESULT.ToString().Trim());
                    cLogInfo.F_JOBORDERNO = (dtResult.Rows[i]["F_JOBORDERNO"] == null) ? "" : dtResult.Rows[i]["F_JOBORDERNO"].ToString();
                    lstClientCLogInfo.Add(cLogInfo);
                }
            }
            return lstClientCLogInfo;
        }


        /// <summary>
        /// 添加客户端异常信息
        /// </summary>
        /// <param name="fLogInfo"></param>
        public void InsertClientFaultLogInfo(MHTClientFaultLogInfo fLogInfo)
        {
            string strTemp = "REPLACE INTO T_HT_CLIENTFAULTLOGINFO(F_FAULTNO,F_FAULTTYPE,F_STATIONNO,F_STATIONNAME" + " ";
            strTemp += ",F_OPERATOR,F_REPAIRTIME,F_NORMALTIME,F_RESTORER" + " ";
            strTemp += ",F_FAULTDESC,F_REPAIRCONTENT,F_REPAIRRESULT,F_JOBORDERNO)  " + " ";
            strTemp += "VALUES(" + " ";
            strTemp += "'" + fLogInfo.F_FAULTNO + "',";
            strTemp += "'" + fLogInfo.F_FAULTTYPE + "',";
            strTemp += "'" + fLogInfo.F_STATIONNO + "',";
            strTemp += "'" + fLogInfo.F_STATIONNAME + "',";
            strTemp += "'" + fLogInfo.F_OPERATOR + "',";
            strTemp += "'" + fLogInfo.F_REPAIRTIME + "',";
            strTemp += "'" + fLogInfo.F_NORMALTIME + "',";
            strTemp += "'" + fLogInfo.F_RESTORER + "',";
            strTemp += "'" + fLogInfo.F_FAULTDESC + "',";
            strTemp += "'" + fLogInfo.F_REPAIRCONTENT + "',";
            strTemp += "'" + fLogInfo.F_REPAIRRESULT + "',";
            strTemp += "'" + fLogInfo.F_JOBORDERNO + "'";
            strTemp += ")" + " ";

            MySqlHelper sHelper = new MySqlHelper();
            sHelper.ExecuteNonQuerySQL(strTemp);
        }

        /// <summary>
        /// 更新客户端异常信息
        /// </summary>
        /// <param name="fLogInfo">客户端异常信息</param>
        public void UpdateClientFaultLogInfo(MHTClientFaultLogInfo fLogInfo)
        {
            string strTemp = "REPLACE INTO T_HT_CLIENTFAULTLOGINFO(F_FAULTNO,F_FAULTTYPE,F_STATIONNO,F_STATIONNAME" + " ";
            strTemp += ",F_OPERATOR,F_REPAIRTIME,F_NORMALTIME,F_RESTORER" + " ";
            strTemp += ",F_FAULTDESC,F_REPAIRCONTENT,F_REPAIRRESULT,F_JOBORDERNO)  " + " ";
            strTemp += "VALUES(" + " ";
            strTemp += "'" + fLogInfo.F_FAULTNO + "',";
            strTemp += "'" + fLogInfo.F_FAULTTYPE + "',";
            strTemp += "'" + fLogInfo.F_STATIONNO + "',";
            strTemp += "'" + fLogInfo.F_STATIONNAME + "',";
            strTemp += "'" + fLogInfo.F_OPERATOR + "',";
            strTemp += "'" + fLogInfo.F_REPAIRTIME + "',";
            strTemp += "'" + fLogInfo.F_NORMALTIME + "',";
            strTemp += "'" + fLogInfo.F_RESTORER + "',";
            strTemp += "'" + fLogInfo.F_FAULTDESC + "',";
            strTemp += "'" + fLogInfo.F_REPAIRCONTENT + "',";
            strTemp += "'" + fLogInfo.F_REPAIRRESULT + "',";
            strTemp += "'" + fLogInfo.F_JOBORDERNO + "'";
            strTemp += ")" + " ";

            MySqlHelper sHelper = new MySqlHelper();
            sHelper.ExecuteNonQuerySQL(strTemp);
        }
    }
}
