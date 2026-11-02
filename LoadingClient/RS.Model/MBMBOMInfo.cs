using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    /// <summary>
    /// 物料清单
    /// </summary>
    public class MBMBOMInfo
    {
        // 表名
        public static readonly string TableName = "T_BM_BOMINFO";

        public static readonly string SequenceName = "SEQ_T_BM_BOMINFO";

        /// <summary>
        /// 物料清单ID
        /// </summary>
        public int F_ID { get; set; }

        /// <summary>
        /// 物料清单编号
        /// </summary>
        public string F_BOMNO { get; set; }

        /// <summary>
        /// 物料清单名称
        /// </summary>
        public string F_BOMNAME { get; set; }

        /// <summary>
        /// 上级BOM的ID
        /// </summary>
        public int F_PARENTNO { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string F_VERSION { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public string F_PRODUCTNO { get; set; }


        public string F_PRODUCTNAME { get; set; }


        public string F_PRODUCTSPEC { get; set; }

        public decimal? F_NORMALNUM { get; set; }


        public string F_LOSSRATE { get; set; }


        public string F_WEIGHT { get; set; }


        public string F_UNITNAME { get; set; }

        public string F_USEDSTATUS { get; set; }

        public string F_CREATOR { get; set; }

        public DateTime F_CREATIONDATE { get; set; }
    }
}
