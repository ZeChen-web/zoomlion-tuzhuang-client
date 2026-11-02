using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    /// <summary>
    /// 吊具信息类
    /// </summary>
    public class JsonMaterialInfo
    {
        /// <summary>
        /// 吊具号 0-2
        /// </summary>
        public string SlingNo { get; set; }
        /// <summary>
        /// 路由 =0正常；=1空过；2整返   3
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
        /// 7SN备用
        /// </summary>
        public string SN { get; set; }
        /// <summary>
        /// 物料编码 8-26位物料编码
        /// </summary>
        public string MaterialCode { get; set; }
    }
}
