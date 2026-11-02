using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    public class MMaterialCodeInfo
    {
        /// <summary>
        /// 缓存区号
        /// </summary>
        public string CacheAreaCode { get; set; }
        /// <summary>
        /// 吊具号 0-2
        /// </summary>
        public string SlingNo { get; set; }
        /// <summary>
        /// 路由 =0正常；=1空过；2整返 
        /// </summary>
        public string Route { get; set; }
        /// <summary>
        /// 类型  4-5
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 颜色   6
        /// </summary>
        public string Colour { get; set; }
        /// <summary>
        /// 备用   7
        /// </summary>
        public string Spare { get; set; }
        /// <summary>
        /// 物料编码 8-26位物料编码
        /// </summary>
        public string MaterialCode { get; set; }
    }
}
