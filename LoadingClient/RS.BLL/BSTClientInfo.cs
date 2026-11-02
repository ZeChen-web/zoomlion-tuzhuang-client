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
    public class BSTClientInfo
    {
        SSTClientInfo sdalSTClientInfo = new SSTClientInfo();

        /// <summary>
        /// 根据IP地址查询客户端信息
        /// </summary>
        /// <param name="srcIPAddr">客户端IP地址</param>
        /// <returns>客户端信息</returns>
        public MSTClientInfo GetClientInfoByClientIP(string srcIPAddr)
        {
            return sdalSTClientInfo.GetClientInfoByClientIP(srcIPAddr);
        }

    }
}
