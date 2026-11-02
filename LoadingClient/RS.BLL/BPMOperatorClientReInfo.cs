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
    public class BPMOperatorClientReInfo
    {
        SPMOperatorClientReInfo sdalOptClientReInfo = new SPMOperatorClientReInfo();

        /// <summary>
        /// 根据操作者ID得到该操作者可操作的客户端ID
        /// </summary>
        /// <param name="strOperatorID"></param>
        /// <returns></returns>
        public List<string> GetClientNOListByOperatorID(int strOperatorID)
        {
            return sdalOptClientReInfo.GetClientNOListByOperatorID(strOperatorID);
        }




    }
}
