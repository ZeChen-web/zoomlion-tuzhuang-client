using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    public class MCacheOut
    {
        /// <summary>
        /// 数据表
        /// </summary>
        public static string table = "t_ts_cache_out";
        /// <summary>
        /// 小车号
        /// </summary>
        public string xc_id { get; set; }
        /// <summary>
        /// 是否出库(1未出库2出库3删除)
        /// </summary>
        public string whether { get; set; }
        /// <summary>
        /// 缓存区
        /// </summary>
        public string cache_area { get; set; }
        /// <summary>
        /// 巷道
        /// </summary>
        public string aisle { get; set; }
        /// <summary>
        /// 类型1正常出库2倒库
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string time { get; set; }
    }
}
