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
    public class SMESWorkInfo
    {
        /// <summary>
        /// 判断该ID的订单开工信息是否存在
        /// </summary>
        /// <param name="monoPartID"></param>
        /// <returns></returns>
        public bool IsExistsWorkInfo(string monoPartID, string processPlanNo)
        {
            bool bResult = false;
            try
            {
                DataTable dtResult = new DataTable();
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT * FROM T_MES_WORKINFO " + " ");
                selectString.AppendLine("WHERE F_MONOPARTID ='" + monoPartID + "'" + " ");
                selectString.AppendLine("AND F_PROCESSPLANNO ='" + processPlanNo + "'" + " ");

                MySqlHelper sHelper = new MySqlHelper();
                dtResult = sHelper.QuerySql(selectString.ToString());

                if (dtResult != null)
                {
                    if (dtResult.Rows.Count > 0)
                    {
                        bResult = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return bResult;
        }

        /// <summary>
        /// 添加开工信息
        /// </summary>
        /// <param name="mWorkInfo"></param>
        /// <returns>添加开工信息 true：添加成功；false：添加失败</returns>
        public bool InsertWorkInfo(MESWorkSignal mWorkInfo)
        {
            try
            {
                string strTemp = "INSERT INTO T_MES_WORKINFO(F_PROCESSPLANNO,F_MONOPARTID,F_STARTWORKER,F_STARTWORKTIME,F_FINISHQTY)" + " ";
                strTemp += "VALUES(" + " ";
                strTemp += "'" + mWorkInfo.processPlanNo + "',";
                strTemp += "'" + mWorkInfo.monoPartId + "',";
                strTemp += "'" + mWorkInfo.startWorker + "',";
                strTemp += "'" + mWorkInfo.startWorkTime + "',";
                strTemp += "'" + mWorkInfo.finishQty + "'";
                strTemp += ")" + " ";

                int iRes = 0;
                MySqlHelper sHelper = new MySqlHelper();
                iRes = sHelper.ExecuteNonQuerySQL(strTemp);
                if (iRes != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        /// <summary>
        /// 添加批次开工信息
        /// </summary>
        /// <param name="mWorkInfo"></param>
        /// <returns>添加批次开工信息 true：添加成功；false：添加失败</returns>
        public bool InsertBatchWorkInfo(MESWorkSignal mWorkInfo)
        {
            try
            {
                string strTemp = "REPLACE INTO T_MES_WORKINFO(F_PROCESSPLANNO,F_MONOPARTID,F_STARTWORKER,F_STARTWORKTIME,F_FINISHQTY)" + " ";
                strTemp += "VALUES(" + " ";
                strTemp += "'" + mWorkInfo.processPlanNo + "',";
                strTemp += "'" + mWorkInfo.monoPartId + "',";
                strTemp += "'" + mWorkInfo.startWorker + "',";
                strTemp += "'" + mWorkInfo.startWorkTime + "',";
                strTemp += "'" + mWorkInfo.finishQty + "'";
                strTemp += ")" + " ";

                int iRes = 0;
                MySqlHelper sHelper = new MySqlHelper();
                iRes = sHelper.ExecuteNonQuerySQL(strTemp);
                if (iRes != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }


        /// <summary>
        /// 添加完工信息
        /// </summary>
        /// <param name="mWorkInfo"></param>
        /// <returns>添加完工信息 true：添加成功；false：添加失败</returns>
        public bool UpdateWorkInfo(MESAlreadyWorkMessage mAlreadyWorkMessage)
        {
            try
            {
                string strTemp = "UPDATE T_MES_WORKINFO" + " ";
                strTemp += "SET F_FINISHWORKER = '" + mAlreadyWorkMessage.finishWorker + "'," + " ";
                strTemp += "F_FINISHWORKTIME = '" + mAlreadyWorkMessage.finishTime + "'," + " ";
                strTemp += "F_FINISHQTY = '" + mAlreadyWorkMessage.finishQty + "'" + " ";
                strTemp += "WHERE F_MONOPARTID = '" + mAlreadyWorkMessage.monoPartId + "' and F_PROCESSPLANNO = '" + mAlreadyWorkMessage.processPlanNo + "'" + " ";

                int iRes = 0;
                MySqlHelper sHelper = new MySqlHelper();
                iRes = sHelper.ExecuteNonQuerySQL(strTemp);
                if (iRes != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        /// <summary>
        /// 添加批次完工信息
        /// </summary>
        /// <param name="mWorkInfo"></param>
        /// <returns>添加批次完工信息 true：添加成功；false：添加失败</returns>
        public bool UpdateBatchWorkInfo(MESAlreadyWorkMessage mAlreadyWorkMessage)
        {
            try
            {
                string strTemp = "UPDATE T_MES_WORKINFO" + " ";
                strTemp += "SET F_FINISHWORKER = '" + mAlreadyWorkMessage.finishWorker + "'," + " ";
                strTemp += "F_FINISHWORKTIME = '" + mAlreadyWorkMessage.finishTime + "'," + " ";
                strTemp += "F_FINISHQTY = isNull(F_FINISHQTY,0) + 1" + " ";
                strTemp += "WHERE F_MONOPARTID = '0' and F_PROCESSPLANNO = '" + mAlreadyWorkMessage.processPlanNo + "'" + " ";

                int iRes = 0;
                MySqlHelper sHelper = new MySqlHelper();
                iRes = sHelper.ExecuteNonQuerySQL(strTemp);
                if (iRes != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
    }
}
