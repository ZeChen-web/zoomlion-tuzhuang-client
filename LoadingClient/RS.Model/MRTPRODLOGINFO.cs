using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    public class MRTProdLogInfo
    {
        // 表名
        public static readonly string TableName = "T_RT_PRODLOGINFO";

        public static readonly string SequenceName = "SEQ_T_RT_PRODLOGINFO";

        public int F_ID { get; set; }    // 序号
        public string F_TEMPCODE { get; set; }    //临时码
        public string F_PRODNO { get; set; }      // 产品编码
        public string F_PRODNAME { get; set; }    //产品名称
        public string F_STATIONNO { get; set; }   //机台设备编号
        public string F_STATIONNAME { get; set; } //机台设备名称
        /// <summary>
        /// 操作类型;0:普通操作；1：上线；2：下线
        /// </summary>
        public int? F_OPTTYPE { get; set; }
        /// <summary>
        /// 是否合格
        /// </summary>
        public int? F_ISPASS { get; set; }
        /// <summary>
        /// 是否一次性合格
        /// </summary>
        public int? F_ISONEPASS { get; set; }
        /// <summary>
        /// 返修次数
        /// </summary>
        public int? F_REPAIRNUM { get; set; }
        public DateTime? F_UPDATETIME { get; set; }  // 存储时间
    }
}
