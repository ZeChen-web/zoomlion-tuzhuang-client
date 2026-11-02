using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    /// <summary>
    /// 操作工登录记录表
    /// </summary>
    public class MRTOperatorLoginInfo
    {

        // 表名称
        public static readonly string TableName = "T_RT_OPERATORLOGININFO";

        public static readonly string SequenceName = "SEQ_T_RT_OPERATORLOGININFO";

        /// <summary>
        /// 索引ID
        /// </summary>
        public int F_ID { get; set; }

        /// <summary>
        /// 登录卡号(ID)
        /// </summary>
        public string F_LOGGINGCARD { get; set; }

        /// <summary>
        /// 登录名称
        /// </summary>
        public string F_OPERATORNAME { get; set; }

        /// <summary>
        /// 客户端ID
        /// </summary>
        public string F_CLIENTNO { get; set; }

        /// <summary>
        /// 客户端名称
        /// </summary>
        public string F_CLIENTNAME { get; set; }
        /// <summary>
        /// 产线ID
        /// </summary>
        public string F_LINEID { get; set; }

        /// <summary>
        /// 产线名称
        /// </summary>
        public string F_LINENAME { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? F_LOGINTIME { get; set; }

        /// <summary>
        /// 退出时间
        /// </summary>
        public DateTime? F_LOGINOUTTIME { get; set; }

        /// <summary>
        /// 操作员类型。0:操作员；1：装配人员；2：准备人员；3：检验人员；
        /// </summary>
        public string F_OPERATORTYPE { get; set; }
    }
}
