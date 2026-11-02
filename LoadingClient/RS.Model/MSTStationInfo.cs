using System;

namespace RS.Model
{
    public class MSTStationInfo
    {
        // 表名
        public static readonly string TableName = "T_ST_STATIONINFO";

        public static readonly string SequenceName = "SEQ_T_ST_STATIONINFO";

        /// <summary>
        /// 机台设备代码
        /// </summary>
        public int? F_ID { get; set; }

        /// <summary>
        /// 机台设备编号
        /// </summary>
        public string F_STATIONNO { get; set; }

        /// <summary>
        /// 机台设备名称
        /// </summary>
        public string F_STATIONNAME { get; set; }

        /// <summary>
        /// 产线编码
        /// </summary>
        public string F_LINENO { get; set; }

        /// <summary>
        /// 产线名称
        /// </summary>
        public string F_LINENAME { get; set; }

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
