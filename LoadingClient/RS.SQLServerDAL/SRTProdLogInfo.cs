using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS.Model;
using RS.DBUtility;
using System.Data;

namespace RS.SQLServerDAL
{
    public class SRTProdLogInfo
    {
        /// <summary>
        /// 添加生产记录信息
        /// </summary>
        /// <param name="srcMesTaskDetailInfo"></param>
        /// <returns></returns>
        public bool AddRTProdLogInfo(MRTProdLogInfo srcProdLogInfo)
        {
            try
            {
                #region 数据更新操作字符串
                string strSql = "";
                if (srcProdLogInfo!=null)
                {
                    strSql += "REPLACE INTO T_RT_PRODLOGINFO" + " ";
                    strSql += "(F_TEMPCODE,F_PRODNO,F_PRODNAME,F_STATIONNO,F_STATIONNAME,";
                    strSql += "F_OPTTYPE,F_ISPASS,F_ISONEPASS,F_REPAIRNUM,F_UPDATETIME)VALUES" + " ";
                    strSql += "(" + " ";
                    strSql += "'" + srcProdLogInfo.F_TEMPCODE + "'," + " ";
                    strSql += "'" + srcProdLogInfo.F_PRODNO + "'," + " ";
                    strSql += "'" + srcProdLogInfo.F_PRODNAME + "'," + " ";
                    strSql += "'" + srcProdLogInfo.F_STATIONNO + "'," + " ";
                    strSql += "'" + srcProdLogInfo.F_STATIONNAME + "'," + " ";
                    strSql += "'" + srcProdLogInfo.F_OPTTYPE + "'," + " ";
                    strSql += "'" + srcProdLogInfo.F_ISPASS + "'," + " ";
                    strSql += "'" + srcProdLogInfo.F_ISONEPASS + "'," + " ";
                    strSql += "'" + srcProdLogInfo.F_REPAIRNUM + "'," + " ";
                    strSql += "'" + DateTime.Now + "'" + " ";
                    strSql += ")" + " ";

                }

                MySqlHelper sHelper = new MySqlHelper();
                bool bRet = sHelper.ExecuteBNonQuerySQL(strSql);

                #endregion 数据更新操作字符串

                return bRet;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        /// <summary>
        /// 判断当前任务是否存在
        /// </summary>
        /// <param name="stationNo"></param>
        /// <returns></returns>
        public bool IsExistsTaskInfo(MRTProdLogInfo srcProdLogInfo)
        {
            bool bResult = false;
            try
            {
                DataTable dtResult = new DataTable();
                #region 数据更新操作字符串
                string strSql = "";
                if (srcProdLogInfo != null)
                {
                    strSql += "SELECT * FROM T_RT_PRODLOGINFO " + " ";
                    strSql += "WHERE F_TEMPCODE='" + srcProdLogInfo.F_TEMPCODE + "'" + " ";
                    strSql += "AND F_STATIONNO='" + srcProdLogInfo.F_STATIONNO + "'" + " ";
                }

                MySqlHelper sHelper = new MySqlHelper();
                dtResult = sHelper.QuerySql(strSql);

                if (dtResult != null)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        bResult = true;
                    }
                }

                #endregion 数据更新操作字符串

                return bResult;
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return bResult;
        }

    }
}
