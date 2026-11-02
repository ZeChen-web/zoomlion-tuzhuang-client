using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    public class MMaterialAllInfo
    {
        public static readonly string TableName = "";
        public static readonly string SequenceName = "SEQ_T_BD_DEPARTMENTINFO";
        /// <summary>
        /// 主键
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string materialCode { get; set; }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string materialName { get; set; }
        /// <summary>
        /// 产线编码
        /// </summary>
        public string lineCode { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string updateTime { get; set; }

    }
}
