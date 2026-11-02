using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RS.Model
{
    public class MPMOperatorInfo
    {
        // 表名称
        public static readonly string TableName = "T_PM_OPERATORINFO";

        public static readonly string SequenceName = "SEQ_T_PM_OPERATORINFO";

        /// <summary>
        /// 操作员代码
        /// </summary>
        public int F_ID { get; set; }
        /// <summary>
        /// 登录ID
        /// </summary>
        public string F_OPERATORID { get; set; }
        /// <summary>
        /// 操作员名称
        /// </summary>
        public string F_OPERATORNAME { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        public string F_OPERATORPWD { get; set; }

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
        /// 操作员状态;0:禁用；1:启用
        /// </summary>
        public string F_STATUS { get; set; }

        /// <summary>
        /// 0:操作员；1：检验人员;2:呼叫人员;3:呼叫处理人员
        /// </summary>
        public int? F_OPERATORTYPE { get; set; }

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
