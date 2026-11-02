using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    /// <summary>
    /// 部门实体类
    /// </summary>
    public class MBDDepartmentInfo
    {
        // 表名
        public static readonly string TableName = "T_BD_DEPARTMENTINFO";

        public static readonly string SequenceName = "SEQ_T_BD_DEPARTMENTINFO";

        public int F_DPTID { get; set; }              // 部门ID
        public string F_DPTCODE { get; set; }         // 部门编号
        public string F_DPTNAME { get; set; }         // 部门名称
        public string F_DPTLEVEL { get; set; }        // 部门层级
        public string F_DPTADDRESS { get; set; }      //部门地址
        public string F_DPTDESC { get; set; }         //部门描述
        public string F_USEDSTATUS { get; set; }      //部门状态
        public string F_CREATOR { get; set; }         //创建者
        public DateTime F_CREATIONDATE { get; set; }  // 创建时间
    }
}
