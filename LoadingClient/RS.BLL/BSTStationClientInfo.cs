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
    public class BSTStationClientInfo
    {

        SSTStationClientInfo sdalStationClientInfo = new SSTStationClientInfo();

        /// <summary>
        /// 根据客户端编码查询机台设备信息列表（客户端管理的机台设备）
        /// </summary>
        /// <param name="srcClientNo">客户端编码</param>
        /// <returns>机台设备信息列表</returns>
        public List<MSTStationInfo> GetStationInfoListByClientNo(string srcClientNo)
        {
            return sdalStationClientInfo.GetStationInfoListByClientNo(srcClientNo);
        }

    }
}
