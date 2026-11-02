using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS.SQLServerDAL;
using RS.Model;

namespace RS.BLL
{
    /// <summary>
    /// 异常呼叫逻辑处理类
    /// </summary>
    public class BException
    {
        #region 变量
        // 操作员数据库操作类
        private SPMOperatorInfo sdalOperatorInfo = new SPMOperatorInfo();
        #endregion

        #region 方法
        /// <summary>
        /// 获得部门信息
        /// </summary>
        public List<MBDDepartmentInfo> GetDepartment()
        {
            List<MBDDepartmentInfo> departmentList = new List<MBDDepartmentInfo>();

            MBDDepartmentInfo mDeptInfo = new MBDDepartmentInfo();
            mDeptInfo.F_DPTCODE = "DP1001";
            mDeptInfo.F_DPTNAME = "生产部";
            departmentList.Add(mDeptInfo);

            MBDDepartmentInfo mDeptInfoDev = new MBDDepartmentInfo();
            mDeptInfoDev.F_DPTCODE = "DP1002";
            mDeptInfoDev.F_DPTNAME = "设备部";
            departmentList.Add(mDeptInfoDev);

            return departmentList;
        }
        #endregion 

    }
}
