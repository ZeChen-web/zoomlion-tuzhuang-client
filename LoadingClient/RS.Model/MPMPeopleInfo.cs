using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    public class MPMPeopleInfo
    {
        // 表名称
        public static readonly string TableName = "T_PM_PEOPLEINFO";

        public static readonly string SequenceName = "SEQ_T_PM_PEOPLEINFO";

        /// <summary>
        ///人员代码
        /// </summary>
        public int F_ID { get; set; }

        /// <summary>
        /// 人员名称
        /// </summary>
        public string F_PEOPLENAME { get; set; }

        /// <summary>
        /// 人员密码
        /// </summary>
        public string F_PEOPLEPWD { get; set; }

        /// <summary>
        /// 人员权限  0:仓库员；1：质检员;2:维修员
        /// </summary>
        public int F_PEOPLEPRIV { get; set; }

        /// <summary>
        /// 登录卡号
        /// </summary>
        public string F_LOGGINGCARD { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string F_IDCARD { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string F_MOBILE { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string F_CREATOR { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? F_CREATIONDATE { get; set; }
    }
}
