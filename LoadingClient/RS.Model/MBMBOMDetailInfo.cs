using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    /// <summary>
    /// 物料清单明细
    /// </summary>
    public class MBMBOMDetailInfo
    {
        // 表名
        public static readonly string TableName = "T_BM_BOMDETAILINFO";

        public static readonly string SequenceName = "SEQ_T_BM_BOMDETAILINFO";

        /// <summary>
        /// 物料清单明细ID
        /// </summary>
        public int F_ID { get; set; }

        /// <summary>
        /// 物料清单编号
        /// </summary>
        public string F_BOMNO { get; set; }

        /// <summary>
        /// 物料编码
        /// </summary>
        public string F_MATERIALCODE { get; set; }

        /// <summary>
        /// 物料名称
        /// </summary>
        public string F_MATERIALNAME { get; set; }

        /// <summary>
        /// 物料规格
        /// </summary>
        public string F_MATERIALMODEL { get; set; }

        /// <summary>
        /// 物料数量
        /// </summary>
        public string F_MATERIALNUM { get; set; }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string F_UNITNAME { get; set; }     

        /// <summary>
        /// 工序编号
        /// </summary>
        public string F_PROCESSNO { get; set; }

        /// <summary>
        /// 工序名称
        /// </summary>
        public string F_PROCESSNAME { get; set; }

        /// <summary>
        /// 工位代码
        /// </summary>
        public string F_STATIONNO { get; set; }

        /// <summary>
        /// 工位名称
        /// </summary>
        public string F_STATIONNAME { get; set; }

        /// <summary>
        /// 中转库编号
        /// </summary>
        public string F_TDCODE { get; set; }

        /// <summary>
        /// 中转库名称
        /// </summary>
        public string F_TDNAME { get; set; }

        /// <summary>
        /// 重量
        /// </summary>
        public string F_WEIGHT { get; set; }
        /// <summary>
        /// 损耗率
        /// </summary>
        public string F_LOSSRATE { get; set; }

        /// <summary>
        /// 是否关键件 0:非关键件；1：关键件
        /// </summary>
        public int? F_ISMAIN { get; set; }

        /// <summary>
        /// 启用状态：(0 停用，1 启用)
        /// </summary>
        public int? F_USEDSTATUS { get; set; }

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
