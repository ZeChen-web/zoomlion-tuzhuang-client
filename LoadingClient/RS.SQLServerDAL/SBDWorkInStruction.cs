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
    public class SBDWorkInStruction
    {
        /// <summary>
        /// 得到工艺指导书基础信息表（根据产品编码，工序编码）
        /// </summary>
        /// <param name="srcProdNo">产品编码</param>
        /// <param name="srcProcessNo">工序编码</param>
        /// <returns>工艺指导书基础信息表</returns>
        public DataTable GetWorkInStructionInfoTable(string srcProdNo,string srcProcessNo)
        {
            try
            {
                DataTable dtResult = null;
                string strSrcSQL = "";
                strSrcSQL += " " + "SELECT *  FROM {0}";
                strSrcSQL += " " + "WHERE F_PROCESSNO='{1}'";
                strSrcSQL += " " + "AND F_PRODUCTNO='{2}'";
                strSrcSQL += " " + "ORDER BY F_ID ASC";
                string strSQL = "";
                strSQL = String.Format(strSrcSQL, MBDWorkInStruction.TableName,srcProcessNo, srcProdNo);
                MySqlHelper sHelper = new MySqlHelper();
                dtResult = sHelper.QuerySql(strSQL.ToString());
                return dtResult;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        /// <summary>
        /// 得到工艺指导书基础信息列表（产品编码，工序编码）
        /// </summary>
        /// <param name="srcStationNo">机台设备编号</param>
        /// <param name="srcProdNo">产品编码</param>
        /// <param name="srcProcessNo">工序编码</param>
        /// <returns>工艺指导书基础信息列表</returns>
        public List<MBDWorkInStruction> GetWorkInStructionInfoList(string srcProdNo, string srcProcessNo)
        {
            List<MBDWorkInStruction> resultList = null;
            try
            {
                DataTable dtResult = GetWorkInStructionInfoTable(srcProdNo, srcProcessNo);
                if(dtResult!=null)
                {
                    int rowNum = 0;
                    rowNum = dtResult.Rows.Count;
                    if(rowNum>0)
                    {
                        resultList = new List<MBDWorkInStruction>();
                        for (int i = 0; i < rowNum; i++)
                        {
                            MBDWorkInStruction wkInStructionInfo = new MBDWorkInStruction();
                            object objID = dtResult.Rows[i]["F_ID"];
                            wkInStructionInfo.F_ID = ((objID == null) || (objID.ToString().Trim() == "")) ? 0 : Convert.ToInt32(objID.ToString().Trim());

                            wkInStructionInfo.F_FILEID = (dtResult.Rows[i]["F_FILEID"] == null) ? "" : dtResult.Rows[i]["F_FILEID"].ToString();
                            wkInStructionInfo.F_FILEPATH = (dtResult.Rows[i]["F_FILEPATH"] == null) ? "" : dtResult.Rows[i]["F_FILEPATH"].ToString();
                            wkInStructionInfo.F_FILETYPE = (dtResult.Rows[i]["F_FILETYPE"] == null) ? "" : dtResult.Rows[i]["F_FILETYPE"].ToString();

                            wkInStructionInfo.F_PRODNO = (dtResult.Rows[i]["F_PRODNO"] == null) ? "" : dtResult.Rows[i]["F_PRODNO"].ToString();
                            wkInStructionInfo.F_PRODNAME = (dtResult.Rows[i]["F_PRODNAME"] == null) ? "" : dtResult.Rows[i]["F_PRODNAME"].ToString();
                            object objPROCESSNo = dtResult.Rows[i]["F_PROCESSNO"];
                            wkInStructionInfo.F_PROCESSNO = (objPROCESSNo == null) ? "" : objPROCESSNo.ToString().Trim();
                            wkInStructionInfo.F_PROCESSNAME = (dtResult.Rows[i]["F_PROCESSNAME"] == null) ? "" : dtResult.Rows[i]["F_PROCESSNAME"].ToString();

                            wkInStructionInfo.F_CREATOR = (dtResult.Rows[i]["F_CREATOR"] == null) ? "" : dtResult.Rows[i]["F_CREATOR"].ToString();
                            object objCREATIONDATE = dtResult.Rows[i]["F_CREATIONDATE"];
                            wkInStructionInfo.F_CREATIONDATE = ((objCREATIONDATE == null) || (objCREATIONDATE.ToString().Trim() == "")) ? Convert.ToDateTime("1800-1-1") : Convert.ToDateTime(objCREATIONDATE.ToString().Trim());

                            resultList.Add(wkInStructionInfo);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return resultList;
        }

        /// <summary>
        /// 得到工艺指导书文件夹路径列表（产品编码，工序编码）
        /// </summary>
        /// <param name="srcProdNo">产品编码</param>
        /// <param name="srcProcessNo">工序编码</param>
        /// <returns>工艺指导书基础信息表</returns>
        public List<string> GetWorkInStructionFolderPathList(string srcProdNo, string srcProcessNo)
        {
            List<string> pathList = null;

            try
            {
                DataTable dtResult = GetWorkInStructionInfoTable(srcProdNo, srcProcessNo);
                if (dtResult != null)
                {
                    int rowNum = 0;
                    rowNum = dtResult.Rows.Count;
                    if (rowNum > 0)
                    {
                        pathList = new List<string>();
                        for (int i = 0; i < rowNum; i++)
                        {
                            string filePath = (dtResult.Rows[i]["F_FILEPATH"] == null) ? "" : dtResult.Rows[i]["F_FILEPATH"].ToString();
                            if(filePath!=null)
                            {
                                if (filePath.Trim() != "")
                                {
                                    pathList.Add(filePath);
                                }
                            }                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return pathList;
        }

    }
}
