using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    public class MBDWorkInStruction
    {
        // 表名
        public static readonly string TableName = "T_BD_WORKINSTRUCTION";

        public static readonly string SequenceName = "SEQ_T_BD_WORKINSTRUCTION";

        public int F_ID { get; set; }    // 序号
        public string F_FILEID { get; set; }  // 文件编号
        public string F_FILEPATH { get; set; }  // 文件路径
        public string F_FILETYPE { get; set; }  // 文件类型
        public string F_PRODNO { get; set; }   // 产品编码
        public string F_PRODNAME { get; set; }  //产品名称
        public string F_PROCESSNO { get; set; }   //工序编号
        public string F_PROCESSNAME { get; set; } //工序名称
        public string F_CREATOR { get; set; }       //创建者
        public DateTime? F_CREATIONDATE { get; set; }  // 创建时间
    }
}
