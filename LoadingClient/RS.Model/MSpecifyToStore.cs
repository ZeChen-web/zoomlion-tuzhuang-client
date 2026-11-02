using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    /// <summary>
    /// 指定入库
    /// </summary>
    public class MSpecifyToStore
    {
        public static readonly string TableName = "T_TS_HAND_MOVE_INDEX";

        public static readonly string SequenceName = "SEQ_T_TS_HAND_MOVE_INDEX";
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 工位
        /// </summary>
        public string WorkStation { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 移行机类型
        /// </summary>
        public string TC { get; set; }
        /// <summary>
        /// 库存通道
        /// </summary>
        public string Aisle { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string MageText { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string UpdateTime { get; set; }
        /// <summary>
        /// 查询索引
        /// </summary>
        public string TCIndex { get; set; }

    }
}
