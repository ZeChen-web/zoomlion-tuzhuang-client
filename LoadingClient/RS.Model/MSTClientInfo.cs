using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    public class MSTClientInfo
    {
        // 表名
        public static readonly string TableName = "T_ST_CLIENTINFO";

        public static readonly string SequenceName = "SEQ_T_ST_CLIENTINFO";

        /// <summary>
        /// 客户端代码
        /// </summary>
        public int F_ID { get; set; }

        /// <summary>
        /// 客户端编号
        /// </summary>
        public string F_CLIENTNO { get; set; }

        /// <summary>
        /// 客户端名称
        /// </summary>
        public string F_CLIENTNAME { get; set; }

        /// <summary>
        /// 客户端IP
        /// </summary>
        public string F_CLIENTIP { get; set; }

        /// <summary>
        /// 产线编码
        /// </summary>
        public string F_LINENO { get; set; }

        /// <summary>
        /// 产线名称
        /// </summary>
        public string F_LINENAME { get; set; }

        /// <summary>
        /// 车间编码
        /// </summary>
        public string F_WORKSHOPNO { get; set; }

        /// <summary>
        /// 车间名称
        /// </summary>
        public string F_WORKSHOPNAME { get; set; }

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
