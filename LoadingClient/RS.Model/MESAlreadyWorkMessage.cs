using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    public class MESAlreadyWorkMessage
    {
        /// <summary>
        /// 工序计划号
        /// </summary>
        public string processPlanNo { get; set; }
        /// <summary>
        /// 单件号
        /// </summary>
        public string monoPartId { get; set; }
        /// <summary>
        /// 完工数量
        /// </summary>
        public string finishQty { get; set; }
        /// <summary>
        /// 完工人
        /// </summary>
        public string finishWorker { get; set; }
        /// <summary>
        /// 完工时间
        /// </summary>
        public string finishTime { get; set; }
    }
}
