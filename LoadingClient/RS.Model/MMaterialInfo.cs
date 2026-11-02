using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    /// <summary>
    /// 所有物料集合
    /// </summary>
    public class MMaterialInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int F_ID { get; set; }
        /// <summary>
        /// 派工单号
        /// </summary>
        public string F_JOBORDERNO { get; set; }
        /// <summary>
        /// 产品编码
        /// </summary>
        public string F_PRODNO { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string F_PRODNAME { get; set; }
        /// <summary>
        /// 工序名称
        /// </summary>
        public string F_PROCESSNAME { get; set; }
        /// <summary>
        /// 机台设备名称
        /// </summary>
        public string F_STATIONNAME { get; set; }
        /// <summary>
        /// 派工数量
        /// </summary>
        public string F_JOBORDERQTY { get; set; }
        /// <summary>
        /// 完成数量
        /// </summary>
        public string F_JOBFSHEDQTY { get; set; }
        /// <summary>
        /// 计划开工日期
        /// </summary>
        public string F_JOBSTART { get; set; }
        /// <summary>
        /// 计划结束日期
        /// </summary>
        public string F_JOBEND { get; set; }
        /// <summary>
        /// 派工单优先级
        /// </summary>
        public string F_PRIORITYLEVEL { get; set; }

    }
}
