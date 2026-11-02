using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    public class MHTClientFaultLogInfo
    {
        // 表名
        public static readonly string TableName = "T_HT_CLIENTFAULTLOGINFO";

        public static readonly string SequenceName = "SEQ_T_HT_CLIENTFAULTLOGINFO";

        /// <summary>
        /// 序号
        /// </summary>
        public int? F_ID { get; set; }

        /// <summary>
        /// 异常编号
        /// </summary>
        public string F_FAULTNO { get; set; }

        /// <summary>
        /// 异常类型
        /// </summary>
        public string F_FAULTTYPE { get; set; }

        /// <summary>
        /// 机台设备编号
        /// </summary>
        public string F_STATIONNO { get; set; }

        /// <summary>
        /// 机台设备名称
        /// </summary>
        public string F_STATIONNAME { get; set; }

        /// <summary>
        /// 提交人
        /// </summary>
        public string F_OPERATOR { get; set; }

        /// <summary>
        /// 故障时间
        /// </summary>
        public DateTime? F_REPAIRTIME { get; set; }

        /// <summary>
        /// 修复时间
        /// </summary>
        public DateTime? F_NORMALTIME { get; set; }

        /// <summary>
        /// 维修人
        /// </summary>
        public string F_RESTORER { get; set; }

        /// <summary>
        /// 故障说明
        /// </summary>
        public string F_FAULTDESC { get; set; }

        /// <summary>
        /// 处理内容
        /// </summary>
        public string F_REPAIRCONTENT { get; set; }

        /// <summary>
        /// 处理结果
        /// </summary>
        public int? F_REPAIRRESULT { get; set; }

        /// <summary>
        /// 派工单号
        /// </summary>
        public string F_JOBORDERNO { get; set; }
    }
}
