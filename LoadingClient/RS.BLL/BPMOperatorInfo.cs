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
    public class BPMOperatorInfo
    {

        SPMOperatorInfo sdalOptInfo = new SPMOperatorInfo();

        /// <summary>
        /// 根据登录号获取操作员信息（直接读取是来自操作员信息表T_PM_OPERATORINFO）
        /// </summary>
        /// <param name="loggingCard">登录号</param>
        /// <returns></returns>
        public MPMOperatorInfo GetOperatorInfoByAccount(string loggingCard)
        {
            return sdalOptInfo.GetOperatorInfoByAccount(loggingCard);
        }

        /// <summary>
        /// 更新操作员信息表
        /// </summary>
        /// <param name="operatorInfo">操作员信息表</param>
        /// <returns>成功：1；失败：0</returns>
        public bool EditOperatorInfo(MPMOperatorInfo operatorInfo)
        {
            return sdalOptInfo.EditOperatorInfo(operatorInfo);
        }

    }
}
