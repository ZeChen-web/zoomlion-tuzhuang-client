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
    public class SWOJobOrderInfo
    {
        /// <summary>
        /// 根据机台设备编号查询已派工的派工单信息表(当天)--（当天的派工单指的是已派工的派工单，按照工单优先级排序）
        /// </summary>
        /// <param name="srcStationNo">机台设备编号</param>
        /// <returns>已派工单信息</returns>
        public DataTable GetJobOrderInfoTableByStationNo(string srcStationNo)
        {

            DataTable dtResult =  null;
            try
            {
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT * FROM T_WO_JOBORDERINFO" + " ");
                selectString.AppendLine("WHERE F_STATIONNO='" + srcStationNo + "'" + " ");
                selectString.AppendLine("AND F_STATUS<=2" + " ");
                selectString.AppendLine("AND F_STATUS!=0" + " ");
                selectString.AppendLine("ORDER BY F_PRIORITYLEVEL ASC" + " ");

                MySqlHelper sHelper = new MySqlHelper();
                dtResult = sHelper.QuerySql(selectString.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dtResult;
        }

        /// <summary>
        /// 根据机台设备编号查询已派工的派工单信息(当天)--（当天的派工单指的是已派工的派工单，按照工单优先级排序）
        /// </summary>
        /// <param name="srcStationNo">机台设备编号</param>
        /// <returns>已派工单信息</returns>
        public List<MWOJobOrderInfo> GetJobOrderInfoListByStationNo(string srcStationNo)
        {

            List<MWOJobOrderInfo> lstResult = null;
            try
            {
                DataTable dtResult = new DataTable();
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT * FROM T_WO_JOBORDERINFO" + " ");
                selectString.AppendLine("WHERE F_STATIONNO='" + srcStationNo + "'" + " ");
                selectString.AppendLine("AND F_STATUS<=2" + " ");
                selectString.AppendLine("AND F_STATUS!=0" + " ");
                selectString.AppendLine("ORDER BY F_PRIORITYLEVEL ASC,F_STATUS DESC" + " ");

                MySqlHelper sHelper = new MySqlHelper();
                dtResult = sHelper.QuerySql(selectString.ToString());

                if (dtResult != null)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        lstResult = new List<MWOJobOrderInfo>();
                        int rowNum = dtResult.Rows.Count;
                        for (int i = 0; i < rowNum; i++)
                        {
                            MWOJobOrderInfo jbOrderInfo = new MWOJobOrderInfo();
                            object objID = dtResult.Rows[i]["F_ID"];
                            jbOrderInfo.F_ID = ((objID == null) || (objID.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objID.ToString().Trim());
                            jbOrderInfo.F_JOBORDERNO = (dtResult.Rows[i]["F_JOBORDERNO"] == null) ? "" : dtResult.Rows[i]["F_JOBORDERNO"].ToString();
                            jbOrderInfo.F_PLANNO = (dtResult.Rows[i]["F_PLANNO"] == null) ? "" : dtResult.Rows[i]["F_PLANNO"].ToString();
                            object objPRIORITYLEVEL = dtResult.Rows[i]["F_PRIORITYLEVEL"];
                            jbOrderInfo.F_PRIORITYLEVEL = ((objPRIORITYLEVEL == null) || (objPRIORITYLEVEL.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objPRIORITYLEVEL.ToString().Trim());
                                                        
                            jbOrderInfo.F_PRODNO = (dtResult.Rows[i]["F_PRODNO"] == null) ? "" : dtResult.Rows[i]["F_PRODNO"].ToString();
                            jbOrderInfo.F_PRODNAME = (dtResult.Rows[i]["F_PRODNAME"] == null) ? "" : dtResult.Rows[i]["F_PRODNAME"].ToString();

                            object objPROCESSNo = dtResult.Rows[i]["F_PROCESSNO"];
                            jbOrderInfo.F_PROCESSNO = (objPROCESSNo == null) ? "" : objPROCESSNo.ToString().Trim();
                            jbOrderInfo.F_PROCESSNAME = (dtResult.Rows[i]["F_PROCESSNAME"] == null) ? "" : dtResult.Rows[i]["F_PROCESSNAME"].ToString();

                            jbOrderInfo.F_STATIONNO = (dtResult.Rows[i]["F_STATIONNO"] == null) ? "" : dtResult.Rows[i]["F_STATIONNO"].ToString();
                            jbOrderInfo.F_STATIONNAME = (dtResult.Rows[i]["F_STATIONNAME"] == null) ? "" : dtResult.Rows[i]["F_STATIONNAME"].ToString();

                            object objQUOTATIME = dtResult.Rows[i]["F_QUOTATIME"];
                            jbOrderInfo.F_QUOTATIME = ((objQUOTATIME == null) || (objQUOTATIME.ToString().Trim() == "")) ? 0 : Convert.ToSingle(objQUOTATIME.ToString().Trim());

                            object objJOBORDERQTY = dtResult.Rows[i]["F_JOBORDERQTY"];   //派工数量
                            jbOrderInfo.F_JOBORDERQTY = ((objJOBORDERQTY == null) || (objJOBORDERQTY.ToString().Trim() == "")) ? 0 : Convert.ToSingle(objJOBORDERQTY.ToString().Trim());
                            object objJOBFSHEDQTY = dtResult.Rows[i]["F_JOBFSHEDQTY"];   //完成数量
                            jbOrderInfo.F_JOBFSHEDQTY = ((objJOBFSHEDQTY == null) || (objJOBFSHEDQTY.ToString().Trim() == "")) ? 0 : Convert.ToSingle(objJOBFSHEDQTY.ToString().Trim());

                            object objUNITID = dtResult.Rows[i]["F_UNITID"];   //单位序号
                            jbOrderInfo.F_UNITID = ((objUNITID == null) || (objUNITID.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objUNITID.ToString().Trim());
                            jbOrderInfo.F_UNITNAME = (dtResult.Rows[i]["F_UNITNAME"] == null) ? "" : dtResult.Rows[i]["F_UNITNAME"].ToString();

                            object objOPERATORNUM = dtResult.Rows[i]["F_OPERATORNUM"];   //操作人数
                            jbOrderInfo.F_OPERATORNUM = ((objOPERATORNUM == null) || (objOPERATORNUM.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objOPERATORNUM.ToString().Trim());

                            jbOrderInfo.F_WORKSHOPNO = (dtResult.Rows[i]["F_WORKSHOPNO"] == null) ? "" : dtResult.Rows[i]["F_WORKSHOPNO"].ToString();
                            jbOrderInfo.F_WORKSHOPNAME = (dtResult.Rows[i]["F_WORKSHOPNAME"] == null) ? "" : dtResult.Rows[i]["F_WORKSHOPNAME"].ToString();

                            object objJOBSTART = dtResult.Rows[i]["F_JOBSTART"];
                            jbOrderInfo.F_JOBSTART = ((objJOBSTART == null) || (objJOBSTART.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objJOBSTART.ToString().Trim());
                            object objJOBEND = dtResult.Rows[i]["F_JOBEND"];
                            jbOrderInfo.F_JOBEND = ((objJOBEND == null) || (objJOBEND.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objJOBEND.ToString().Trim());

                            jbOrderInfo.F_VERHICLETYPE = (dtResult.Rows[i]["F_VERHICLETYPE"] == null) ? "" : dtResult.Rows[i]["F_VERHICLETYPE"].ToString();
                            object objJOBORDERTYPE = dtResult.Rows[i]["F_JOBORDERTYPE"];   //派工单类型 0：自动派工；1：手动派工
                            jbOrderInfo.F_JOBORDERTYPE = ((objJOBORDERTYPE == null) || (objJOBORDERTYPE.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objJOBORDERTYPE.ToString().Trim());

                            object objSTATUS = dtResult.Rows[i]["F_STATUS"];
                            jbOrderInfo.F_STATUS = ((objSTATUS == null) || (objSTATUS.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objSTATUS.ToString().Trim());
                            object objUPDATETIME = dtResult.Rows[i]["F_UPDATETIME"];
                            jbOrderInfo.F_UPDATETIME = ((objUPDATETIME == null) || (objUPDATETIME.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objUPDATETIME.ToString().Trim());

                            jbOrderInfo.F_WORKCENTERCODE = (dtResult.Rows[i]["F_WORKCENTERCODE"] == null) ? "" : dtResult.Rows[i]["F_WORKCENTERCODE"].ToString();
                            jbOrderInfo.F_MONOPARTID = (dtResult.Rows[i]["F_MONOPARTID"] == null) ? "" : dtResult.Rows[i]["F_MONOPARTID"].ToString();
                            jbOrderInfo.F_BATCHNO = (dtResult.Rows[i]["F_BATCHNO"] == null) ? "" : dtResult.Rows[i]["F_BATCHNO"].ToString();

                            jbOrderInfo.F_CREATOR = (dtResult.Rows[i]["F_CREATOR"] == null) ? "" : dtResult.Rows[i]["F_CREATOR"].ToString();
                            object objCREATIONDATE = dtResult.Rows[i]["F_CREATIONDATE"];
                            jbOrderInfo.F_CREATIONDATE = ((objCREATIONDATE == null) || (objCREATIONDATE.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objCREATIONDATE.ToString().Trim());

                            lstResult.Add(jbOrderInfo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return lstResult;
        }

        /// <summary>
        /// 根据派工单号查询派工单信息
        /// </summary>
        /// <param name="srcJobOrderNo">派工单号</param>
        /// <returns>派工单信息</returns>
        public MWOJobOrderInfo GetJobOrderInfoByJobOrderNo(string srcJobOrderNo)
        {

            MWOJobOrderInfo jbOrderInfo = null;
            try
            {
                DataTable dtResult = new DataTable();
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT * FROM T_WO_JOBORDERINFO" + " ");
                selectString.AppendLine("WHERE F_ID='" + srcJobOrderNo + "'" + " ");

                MySqlHelper sHelper = new MySqlHelper();
                dtResult = sHelper.QuerySql(selectString.ToString());

                if (dtResult != null)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        jbOrderInfo = new MWOJobOrderInfo();
                        int rowNum = dtResult.Rows.Count;
                        for (int i = 0; i < rowNum; i++)
                        {
                            object objID = dtResult.Rows[i]["F_ID"];
                            jbOrderInfo.F_ID = ((objID == null) || (objID.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objID.ToString().Trim());
                            jbOrderInfo.F_JOBORDERNO = (dtResult.Rows[i]["F_JOBORDERNO"] == null) ? "" : dtResult.Rows[i]["F_JOBORDERNO"].ToString();
                            jbOrderInfo.F_PLANNO = (dtResult.Rows[i]["F_PLANNO"] == null) ? "" : dtResult.Rows[i]["F_PLANNO"].ToString();
                            object objPRIORITYLEVEL = dtResult.Rows[i]["F_PRIORITYLEVEL"];
                            jbOrderInfo.F_PRIORITYLEVEL = ((objPRIORITYLEVEL == null) || (objPRIORITYLEVEL.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objPRIORITYLEVEL.ToString().Trim());

                            jbOrderInfo.F_PRODNO = (dtResult.Rows[i]["F_PRODNO"] == null) ? "" : dtResult.Rows[i]["F_PRODNO"].ToString();
                            jbOrderInfo.F_PRODNAME = (dtResult.Rows[i]["F_PRODNAME"] == null) ? "" : dtResult.Rows[i]["F_PRODNAME"].ToString();

                            object objPROCESSNo = dtResult.Rows[i]["F_PROCESSNO"];
                            jbOrderInfo.F_PROCESSNO = (objPROCESSNo == null) ? "" : objPROCESSNo.ToString().Trim();
                            jbOrderInfo.F_PROCESSNAME = (dtResult.Rows[i]["F_PROCESSNAME"] == null) ? "" : dtResult.Rows[i]["F_PROCESSNAME"].ToString();

                            jbOrderInfo.F_STATIONNO = (dtResult.Rows[i]["F_STATIONNO"] == null) ? "" : dtResult.Rows[i]["F_STATIONNO"].ToString();
                            jbOrderInfo.F_STATIONNAME = (dtResult.Rows[i]["F_STATIONNAME"] == null) ? "" : dtResult.Rows[i]["F_STATIONNAME"].ToString();

                            object objQUOTATIME = dtResult.Rows[i]["F_QUOTATIME"];
                            jbOrderInfo.F_QUOTATIME = ((objQUOTATIME == null) || (objQUOTATIME.ToString().Trim() == "")) ? 0 : Convert.ToSingle(objQUOTATIME.ToString().Trim());

                            object objJOBORDERQTY = dtResult.Rows[i]["F_JOBORDERQTY"];   //派工数量
                            jbOrderInfo.F_JOBORDERQTY = ((objJOBORDERQTY == null) || (objJOBORDERQTY.ToString().Trim() == "")) ? 0 : Convert.ToSingle(objJOBORDERQTY.ToString().Trim());
                            object objJOBFSHEDQTY = dtResult.Rows[i]["F_JOBFSHEDQTY"];   //完成数量
                            jbOrderInfo.F_JOBFSHEDQTY = ((objJOBFSHEDQTY == null) || (objJOBFSHEDQTY.ToString().Trim() == "")) ? 0 : Convert.ToSingle(objJOBFSHEDQTY.ToString().Trim());

                            object objUNITID = dtResult.Rows[i]["F_UNITID"];   //单位序号
                            jbOrderInfo.F_UNITID = ((objUNITID == null) || (objUNITID.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objUNITID.ToString().Trim());
                            jbOrderInfo.F_UNITNAME = (dtResult.Rows[i]["F_UNITNAME"] == null) ? "" : dtResult.Rows[i]["F_UNITNAME"].ToString();

                            object objOPERATORNUM = dtResult.Rows[i]["F_OPERATORNUM"];   //操作人数
                            jbOrderInfo.F_OPERATORNUM = ((objOPERATORNUM == null) || (objOPERATORNUM.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objOPERATORNUM.ToString().Trim());

                            jbOrderInfo.F_WORKSHOPNO = (dtResult.Rows[i]["F_WORKSHOPNO"] == null) ? "" : dtResult.Rows[i]["F_WORKSHOPNO"].ToString();
                            jbOrderInfo.F_WORKSHOPNAME = (dtResult.Rows[i]["F_WORKSHOPNAME"] == null) ? "" : dtResult.Rows[i]["F_WORKSHOPNAME"].ToString();

                            object objJOBSTART = dtResult.Rows[i]["F_JOBSTART"];
                            jbOrderInfo.F_JOBSTART = ((objJOBSTART == null) || (objJOBSTART.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objJOBSTART.ToString().Trim());
                            object objJOBEND = dtResult.Rows[i]["F_JOBEND"];
                            jbOrderInfo.F_JOBEND = ((objJOBEND == null) || (objJOBEND.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objJOBEND.ToString().Trim());

                            jbOrderInfo.F_VERHICLETYPE = (dtResult.Rows[i]["F_VERHICLETYPE"] == null) ? "" : dtResult.Rows[i]["F_VERHICLETYPE"].ToString();
                            object objJOBORDERTYPE = dtResult.Rows[i]["F_JOBORDERTYPE"];   //派工单类型 0：自动派工；1：手动派工
                            jbOrderInfo.F_JOBORDERTYPE = ((objJOBORDERTYPE == null) || (objJOBORDERTYPE.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objJOBORDERTYPE.ToString().Trim());

                            object objSTATUS = dtResult.Rows[i]["F_STATUS"];
                            jbOrderInfo.F_STATUS = ((objSTATUS == null) || (objSTATUS.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objSTATUS.ToString().Trim());
                            object objUPDATETIME = dtResult.Rows[i]["F_UPDATETIME"];
                            jbOrderInfo.F_UPDATETIME = ((objUPDATETIME == null) || (objUPDATETIME.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objUPDATETIME.ToString().Trim());

                            jbOrderInfo.F_WORKCENTERCODE = (dtResult.Rows[i]["F_WORKCENTERCODE"] == null) ? "" : dtResult.Rows[i]["F_WORKCENTERCODE"].ToString();
                            jbOrderInfo.F_MONOPARTID = (dtResult.Rows[i]["F_MONOPARTID"] == null) ? "" : dtResult.Rows[i]["F_MONOPARTID"].ToString();
                            jbOrderInfo.F_BATCHNO = (dtResult.Rows[i]["F_BATCHNO"] == null) ? "" : dtResult.Rows[i]["F_BATCHNO"].ToString();

                            jbOrderInfo.F_CREATOR = (dtResult.Rows[i]["F_CREATOR"] == null) ? "" : dtResult.Rows[i]["F_CREATOR"].ToString();
                            object objCREATIONDATE = dtResult.Rows[i]["F_CREATIONDATE"];
                            jbOrderInfo.F_CREATIONDATE = ((objCREATIONDATE == null) || (objCREATIONDATE.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objCREATIONDATE.ToString().Trim());

                        }
                    }
                }
                return jbOrderInfo;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        /// <summary>
        /// 根据机台设备编号列表查询已派工的派工单信息表(当天)--（当天的派工单指的是已派工的派工单，按照工单优先级排序）
        /// </summary>
        /// <param name="srcStationNoList">机台设备编号列表</param>
        /// <returns>已派工单信息表</returns>
        public DataTable GetJobOrderInfoTableByStationNoList(List<string> srcStationNoList)
        {
            DataTable dtResult = null;
            try
            {
                DataTable dtTempJobInfo = null;
                if (srcStationNoList != null)
                {
                    foreach (var stationno in srcStationNoList)
                    {
                        StringBuilder selectString = new StringBuilder();
                        selectString.AppendLine("SELECT F_ID AS 序号, F_BATCHNO AS 批次号,F_MONOPARTID AS ID号,F_JOBORDERNO AS 派工单号,F_PRODNO AS 产品编码,F_PRODNAME AS 产品名称,F_PROCESSNAME AS 工序名称,F_STATIONNAME AS 机台设备名称, F_JOBORDERQTY AS 派工数量, F_JOBFSHEDQTY AS 完成数量, F_JOBSTART AS 计划开工日期, F_JOBEND AS 计划结束日期, F_PRIORITYLEVEL AS 派工单优先级 FROM T_WO_JOBORDERINFO" + " ");
                        selectString.AppendLine("WHERE F_STATIONNO='" + stationno + "'" + " ");
                        selectString.AppendLine("AND F_STATUS<=2" + " ");
                        selectString.AppendLine("AND F_STATUS!=0" + " ");
                        selectString.AppendLine("ORDER BY F_PRIORITYLEVEL ASC" + " ");

                        MySqlHelper sHelper = new MySqlHelper();
                        DataTable dtJobOrderInfo = null;
                        dtJobOrderInfo = sHelper.QuerySql(selectString.ToString());

                        if (dtJobOrderInfo != null)
                        {
                            if (dtJobOrderInfo.Rows.Count > 0)
                            {
                                if (dtTempJobInfo != null)
                                {
                                    dtTempJobInfo.Merge(dtJobOrderInfo);
                                }
                                else
                                {
                                    dtTempJobInfo = new DataTable();
                                    dtTempJobInfo = dtJobOrderInfo.Copy();
                                }
                            }
                        }
                    }
                }
                if (dtTempJobInfo != null)
                {
                    DataView dv = dtTempJobInfo.DefaultView;
                    dv.Sort = "派工单优先级 asc";
                    dtResult = dv.ToTable();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dtResult;
        }

        /// <summary>
        /// 根据机台设备编号查询已派工的派工单信息(当天)--（当天的派工单指的是已派工的派工单，按照工单优先级排序）
        /// </summary>
        /// <param name="srcStationNo">机台设备编号</param>
        /// <returns>已派工单信息</returns>
        public MWOJobOrderInfo GetCurrentJobOrderInfoByStationNo(string srcStationNo)
        {

            MWOJobOrderInfo jbOrderInfo = null;
            try
            {
                List<MWOJobOrderInfo> lstResult = GetJobOrderInfoListByStationNo(srcStationNo);
                if (lstResult != null)
                {
                    if (lstResult.Count > 0)
                    {
                        foreach (var q in lstResult)
                        {
                            if (q.F_STATUS == 2)
                            {
                                jbOrderInfo = q;
                            }
                        }
                        if (jbOrderInfo == null)
                        {
                            jbOrderInfo = lstResult[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return jbOrderInfo;
        }

        /// <summary>
        /// 根据产品编号查询已派工的派工单信息表(当天)--（当天的派工单指的是已派工的派工单，按照工单优先级排序）
        /// </summary>
        /// <param name="srcProdNo">产品编号</param>
        /// <param name="stationNo">机台设备编号</param>
        /// <returns>已派工单信息</returns>
        public MWOJobOrderInfo GetJobOrderInfoTableByProdNo(string srcProdNo, string stationNo)
        {

            MWOJobOrderInfo jbOrderInfo = null;
            try
            {
                DataTable dtResult = new DataTable();
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT * FROM T_WO_JOBORDERINFO" + " ");
                selectString.AppendLine("WHERE F_PRODNO='" + srcProdNo + "'" + " ");
                selectString.AppendLine("AND F_STATIONNO='"+ stationNo + "'" + " ");
                selectString.AppendLine("AND F_STATUS<=2" + " ");
                selectString.AppendLine("AND F_STATUS!=0" + " ");
                selectString.AppendLine("AND F_CREATIONDATE >= '" + DateTime.Now.Date + "'" + " ");
                selectString.AppendLine("AND F_CREATIONDATE <= '" + DateTime.Now.Date.AddDays(1) + "'" + " ");
                selectString.AppendLine("ORDER BY F_STATUS DESC limit 0,1" + " ");

                MySqlHelper sHelper = new MySqlHelper();
                dtResult = sHelper.QuerySql(selectString.ToString());
                if (dtResult != null)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        jbOrderInfo = new MWOJobOrderInfo();
                        int rowNum = dtResult.Rows.Count;
                        for (int i = 0; i < rowNum; i++)
                        {
                            object objID = dtResult.Rows[i]["F_ID"];
                            jbOrderInfo.F_ID = ((objID == null) || (objID.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objID.ToString().Trim());
                            jbOrderInfo.F_JOBORDERNO = (dtResult.Rows[i]["F_JOBORDERNO"] == null) ? "" : dtResult.Rows[i]["F_JOBORDERNO"].ToString();
                            jbOrderInfo.F_PLANNO = (dtResult.Rows[i]["F_PLANNO"] == null) ? "" : dtResult.Rows[i]["F_PLANNO"].ToString();
                            object objPRIORITYLEVEL = dtResult.Rows[i]["F_PRIORITYLEVEL"];
                            jbOrderInfo.F_PRIORITYLEVEL = ((objPRIORITYLEVEL == null) || (objPRIORITYLEVEL.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objPRIORITYLEVEL.ToString().Trim());

                            jbOrderInfo.F_PRODNO = (dtResult.Rows[i]["F_PRODNO"] == null) ? "" : dtResult.Rows[i]["F_PRODNO"].ToString();
                            jbOrderInfo.F_PRODNAME = (dtResult.Rows[i]["F_PRODNAME"] == null) ? "" : dtResult.Rows[i]["F_PRODNAME"].ToString();

                            object objPROCESSNo = dtResult.Rows[i]["F_PROCESSNO"];
                            jbOrderInfo.F_PROCESSNO = (objPROCESSNo == null) ? "" : objPROCESSNo.ToString().Trim();
                            jbOrderInfo.F_PROCESSNAME = (dtResult.Rows[i]["F_PROCESSNAME"] == null) ? "" : dtResult.Rows[i]["F_PROCESSNAME"].ToString();

                            jbOrderInfo.F_STATIONNO = (dtResult.Rows[i]["F_STATIONNO"] == null) ? "" : dtResult.Rows[i]["F_STATIONNO"].ToString();
                            jbOrderInfo.F_STATIONNAME = (dtResult.Rows[i]["F_STATIONNAME"] == null) ? "" : dtResult.Rows[i]["F_STATIONNAME"].ToString();

                            object objQUOTATIME = dtResult.Rows[i]["F_QUOTATIME"];
                            jbOrderInfo.F_QUOTATIME = ((objQUOTATIME == null) || (objQUOTATIME.ToString().Trim() == "")) ? 0 : Convert.ToSingle(objQUOTATIME.ToString().Trim());

                            object objJOBORDERQTY = dtResult.Rows[i]["F_JOBORDERQTY"];   //派工数量
                            jbOrderInfo.F_JOBORDERQTY = ((objJOBORDERQTY == null) || (objJOBORDERQTY.ToString().Trim() == "")) ? 0 : Convert.ToSingle(objJOBORDERQTY.ToString().Trim());
                            object objJOBFSHEDQTY = dtResult.Rows[i]["F_JOBFSHEDQTY"];   //完成数量
                            jbOrderInfo.F_JOBFSHEDQTY = ((objJOBFSHEDQTY == null) || (objJOBFSHEDQTY.ToString().Trim() == "")) ? 0 : Convert.ToSingle(objJOBFSHEDQTY.ToString().Trim());

                            object objUNITID = dtResult.Rows[i]["F_UNITID"];   //单位序号
                            jbOrderInfo.F_UNITID = ((objUNITID == null) || (objUNITID.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objUNITID.ToString().Trim());
                            jbOrderInfo.F_UNITNAME = (dtResult.Rows[i]["F_UNITNAME"] == null) ? "" : dtResult.Rows[i]["F_UNITNAME"].ToString();

                            object objOPERATORNUM = dtResult.Rows[i]["F_OPERATORNUM"];   //操作人数
                            jbOrderInfo.F_OPERATORNUM = ((objOPERATORNUM == null) || (objOPERATORNUM.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objOPERATORNUM.ToString().Trim());

                            jbOrderInfo.F_WORKSHOPNO = (dtResult.Rows[i]["F_WORKSHOPNO"] == null) ? "" : dtResult.Rows[i]["F_WORKSHOPNO"].ToString();
                            jbOrderInfo.F_WORKSHOPNAME = (dtResult.Rows[i]["F_WORKSHOPNAME"] == null) ? "" : dtResult.Rows[i]["F_WORKSHOPNAME"].ToString();

                            object objJOBSTART = dtResult.Rows[i]["F_JOBSTART"];
                            jbOrderInfo.F_JOBSTART = ((objJOBSTART == null) || (objJOBSTART.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objJOBSTART.ToString().Trim());
                            object objJOBEND = dtResult.Rows[i]["F_JOBEND"];
                            jbOrderInfo.F_JOBEND = ((objJOBEND == null) || (objJOBEND.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objJOBEND.ToString().Trim());

                            jbOrderInfo.F_VERHICLETYPE = (dtResult.Rows[i]["F_VERHICLETYPE"] == null) ? "" : dtResult.Rows[i]["F_VERHICLETYPE"].ToString();
                            object objJOBORDERTYPE = dtResult.Rows[i]["F_JOBORDERTYPE"];   //派工单类型 0：自动派工；1：手动派工
                            jbOrderInfo.F_JOBORDERTYPE = ((objJOBORDERTYPE == null) || (objJOBORDERTYPE.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objJOBORDERTYPE.ToString().Trim());

                            object objSTATUS = dtResult.Rows[i]["F_STATUS"];
                            jbOrderInfo.F_STATUS = ((objSTATUS == null) || (objSTATUS.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objSTATUS.ToString().Trim());
                            object objUPDATETIME = dtResult.Rows[i]["F_UPDATETIME"];
                            jbOrderInfo.F_UPDATETIME = ((objUPDATETIME == null) || (objUPDATETIME.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objUPDATETIME.ToString().Trim());

                            jbOrderInfo.F_WORKCENTERCODE = (dtResult.Rows[i]["F_WORKCENTERCODE"] == null) ? "" : dtResult.Rows[i]["F_WORKCENTERCODE"].ToString();
                            jbOrderInfo.F_MONOPARTID = (dtResult.Rows[i]["F_MONOPARTID"] == null) ? "" : dtResult.Rows[i]["F_MONOPARTID"].ToString();
                            jbOrderInfo.F_BATCHNO = (dtResult.Rows[i]["F_BATCHNO"] == null) ? "" : dtResult.Rows[i]["F_BATCHNO"].ToString();

                            jbOrderInfo.F_CREATOR = (dtResult.Rows[i]["F_CREATOR"] == null) ? "" : dtResult.Rows[i]["F_CREATOR"].ToString();
                            object objCREATIONDATE = dtResult.Rows[i]["F_CREATIONDATE"];
                            jbOrderInfo.F_CREATIONDATE = ((objCREATIONDATE == null) || (objCREATIONDATE.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objCREATIONDATE.ToString().Trim());
                        }
                    }
                }
                return jbOrderInfo;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        /// <summary>
        /// 更新当前生产派工单信息
        /// </summary>
        /// <param name="srcJobOrderInfo">当前派工单信息</param>
        public void UpdateCurrentJobOrderInfo(MWOJobOrderInfo jdInfo)
        {
            string strTemp = "UPDATE T_WO_JOBORDERINFO" + " ";
            strTemp += "SET F_JOBFSHEDQTY= '{0}',F_STATUS = '{1}',F_UPDATETIME = '{2}'" + " ";
            strTemp += "WHERE F_JOBORDERNO='{3}'  AND F_PRODNO='{4}'" + " ";
            strTemp += "AND F_PROCESSNO='{5}' AND F_STATIONNO='{6}'" + " ";
            strTemp += "AND F_MONOPARTID='{7}' AND F_BATCHNO='{8}'" + " ";
            string strSQL = string.Format(strTemp, jdInfo.F_JOBFSHEDQTY, jdInfo.F_STATUS, jdInfo.F_UPDATETIME, jdInfo.F_JOBORDERNO, jdInfo.F_PRODNO, jdInfo.F_PROCESSNO, jdInfo.F_STATIONNO, jdInfo.F_MONOPARTID, jdInfo.F_BATCHNO);
            MySqlHelper sHelper = new MySqlHelper();
            sHelper.ExecuteNonQuerySQL(strSQL);
        }
    }
}
