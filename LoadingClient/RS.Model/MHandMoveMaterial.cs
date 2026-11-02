using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    public class MHandMoveMaterial
    {
        public static string tableName = "t_ts_hand_move";
        /// <summary>
        /// 工位
        /// </summary>
        public string WorkStation { get; set; }
        /// <summary>
        /// 全部编码
        /// </summary>
        public string slingMaterial { get; set; }
        /// <summary>
        /// 吊具号
        /// </summary>
        public string SlingNo { get; set; }
        /// <summary>
        /// 移行机类型
        /// </summary>
        public string TC { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string MaterialCode { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 库存通道
        /// </summary>
        public string aisle { get; set; }
        /// <summary>
        /// 描述（成功/失败）
        /// </summary>
        public string MageText { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreatTime { get; set; }
    }
}
