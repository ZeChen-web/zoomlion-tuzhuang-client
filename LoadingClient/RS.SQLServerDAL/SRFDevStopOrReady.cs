using RS.DBUtility;
using RS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.SQLServerDAL
{
    /// <summary>
    /// 停待机原因录入
    /// </summary>
    public class SRFDevStopOrReady
    {
        public bool AddStopReadyContentDetail(MRFDevStopOrReady srcDevStopReadyInfo)
        {
            try
            {
                bool bRes = false;
                #region 数据更新操作字符串
                string strTemp = "INSERT INTO T_RF_DevStopOrReady(F_StopOrReadyContent,F_ProcessName,";
                strTemp += "F_StationName,F_Createtime)VALUES" + " ";
                strTemp += "(" + " ";
                strTemp += "'" + srcDevStopReadyInfo.F_StopOrReadyContent + "'," + " ";
                strTemp += "'" + srcDevStopReadyInfo.F_ProcessName + "'," + " ";
                strTemp += "'" + srcDevStopReadyInfo.F_StationName + "'," + " ";
                strTemp += "'" + DateTime.Now + "'" + " ";
                strTemp += ")" + " ";

                MySqlHelper sHelper = new MySqlHelper();
                int iRes = sHelper.ExecuteNonQuerySQL(strTemp);

                #endregion 数据更新操作字符串
                if (iRes != 0)
                {
                    bRes = true;
                }

                return bRes;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
    }
}
