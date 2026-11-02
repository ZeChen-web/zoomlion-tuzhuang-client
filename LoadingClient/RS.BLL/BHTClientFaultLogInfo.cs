using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RS.Model;
using RS.SQLServerDAL;
using RS.Common;

namespace RS.BLL
{
    public class BHTClientFaultLogInfo
    {
        SHTClientFaultLogInfo sdalFaultInfo = new SHTClientFaultLogInfo();

        /// <summary>
        /// 添加客户端异常信息
        /// </summary>
        /// <param name="fLogInfo"></param>
        public void InsertClientFaultLogInfo(MHTClientFaultLogInfo fLogInfo)
        {
            sdalFaultInfo.InsertClientFaultLogInfo(fLogInfo);
        }

        /// <summary>
        /// 更新客户端异常信息
        /// </summary>
        /// <param name="fLogInfo">客户端异常信息</param>
        public void UpdateClientFaultLogInfo(MHTClientFaultLogInfo fLogInfo)
        {
            sdalFaultInfo.UpdateClientFaultLogInfo(fLogInfo);
        }

    }
}
