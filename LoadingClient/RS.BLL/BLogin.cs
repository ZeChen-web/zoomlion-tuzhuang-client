using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS.Model;
using RS.SQLServerDAL;
using RS.Common;

namespace RS.BLL
{
    public class BLogin
    {

        SRTOperatorLoginInfo sdalOptLoginInfo = new SRTOperatorLoginInfo();

        /// <summary>
        /// 操作员登录日志信息记录
        /// </summary>
        /// <returns></returns>
        public bool AddOperatorLoginInInfo(MRTOperatorLoginInfo srcOptLoginInfo)
        {
            return sdalOptLoginInfo.AddOperatorLoginInInfo(srcOptLoginInfo);
        }

        /// <summary>
        /// 操作员退出日志信息记录
        /// </summary>
        /// <returns></returns>
        public bool EditOperatorLoginOutInfo(MRTOperatorLoginInfo srcOptLoginInfo)
        {
            return sdalOptLoginInfo.EditOperatorLoginOutInfo(srcOptLoginInfo);
        }

        public bool SystemCancleLogOutInfo()
        {            
            try
            {
                bool bResult = false;
                if (PublicParams.G_OpertorLoginInfo!=null)
                {
                    PublicParams.G_OpertorLoginInfo.F_LOGINOUTTIME = DateTime.Now;
                    bResult = EditOperatorLoginOutInfo(PublicParams.G_OpertorLoginInfo);
                }
                if(PublicParams.G_OperatorLoginInfoList!=null)
                {
                    if(PublicParams.G_OperatorLoginInfoList.Count>0)
                    {
                        foreach(var q in PublicParams.G_OperatorLoginInfoList)
                        {
                            q.F_LOGINOUTTIME = DateTime.Now;
                            bool bSave = EditOperatorLoginOutInfo(q);
                            bResult = bResult & bSave;
                        }
                    }
                    PublicParams.G_OperatorLoginInfoList = new List<MRTOperatorLoginInfo>();
                }
                return bResult;
            }
            catch(Exception ex)
            {
                ex.ToString();
                return false;
            }
        }


    }
}
