using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    public class MRFDevStopOrReady
    {
        // 表名
        public static readonly string TableName = "T_RF_DevStopOrReady";

        public static readonly string SequenceName = "SEQ_T_RF_DevStopOrReady";

        /// <summary>
        /// ID
        /// </summary>
        public int F_ID { get; set; }

        /// <summary>
        /// 停待机原因
        /// </summary>
        public string F_StopOrReadyContent { get; set; }

        /// <summary>
        /// 工序名称
        /// </summary>
        public string F_ProcessName { get; set; }

        /// <summary>
        /// 机台设备名称
        /// </summary>
        public string F_StationName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime F_Createtime { get; set; }
    }
}
