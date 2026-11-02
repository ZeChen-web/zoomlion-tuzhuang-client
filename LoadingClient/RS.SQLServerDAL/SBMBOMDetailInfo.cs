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
    public class SBMBOMDetailInfo
    {
        /// <summary>
        /// 根据产品编号(物料清单表）与机台设备编号查询到物料清单明细
        /// </summary>
        /// <param name="srcProdNo">产品编号</param>
        /// <param name="srcStdNoList">机台设备编号列表</param>
        /// <returns>物料清单明细表</returns>
        public DataTable GetBomDetailInfo(string srcProdNo, List<string> srcStdNoList)
        {
            try
            {
                DataTable dtResult = null;
                string strSrcSQL = "";
                strSrcSQL += " " + "SELECT D.F_MATERIALCODE AS 物料编码,D.F_MATERIALNAME AS 物料名称,D.F_MATERIALMODEL AS 规格型号,Convert(D.F_MATERIALNUM/B.F_NORMALNUM,decimal(18,2)) AS 物料数量,D.F_WEIGHT AS 重量,";
                strSrcSQL += " " + "D.F_STATIONNAME AS 机台设备名称,D.F_UNITNAME AS 单位名称,D.F_PROCESSNAME AS 工序名称";
                strSrcSQL += " " + "FROM {0} B,{1} D";
                strSrcSQL += " " + "WHERE B.F_PRODUCTNO='{2}'";
                if (srcStdNoList != null && srcStdNoList.Count > 0)
                {
                    for (int i = 0; i < srcStdNoList.Count; i++)
                    {
                        if (i == 0)
                        {
                            strSrcSQL += " " + "AND D.F_STATIONNO='" + srcStdNoList[i] + "'";
                        }
                        else
                        {
                            strSrcSQL += " " + "OR D.F_STATIONNO='" + srcStdNoList[i] + "'";
                        }
                    }
                }
                strSrcSQL += " " + "AND B.F_BOMNO=D.F_BOMNO";
                strSrcSQL += " " + "ORDER BY D.F_ISMAIN DESC,D.F_ID ASC";
                string strSQL = "";
                strSQL = String.Format(strSrcSQL, MBMBOMInfo.TableName, MBMBOMDetailInfo.TableName, srcProdNo);
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


    }
}
