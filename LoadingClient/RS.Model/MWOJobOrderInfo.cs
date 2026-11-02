using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    public class MWOJobOrderInfo
    {
        // 表名
        public static readonly string TableName = "T_WO_JOBORDERINFO";

        public static readonly string SequenceName = "SEQ_T_WO_JOBORDERINFO";

        public int F_ID { get; set; }    // 序号
        public string F_JOBORDERNO { get; set; }  // 派工单号
        public string F_PLANNO { get; set; }  // 生产计划号
        public int? F_PRIORITYLEVEL { get; set; }  // 派工单优先级
        public string F_PRODNO { get; set; }   // 产品编码
        public string F_PRODNAME { get; set; }  //产品名称
        public string F_PROCESSNO { get; set; }   //工序编号
        public string F_PROCESSNAME { get; set; } //工序名称
        public string F_STATIONNO { get; set; }    //机台设备编号
        public string F_STATIONNAME { get; set; }  //机台设备名称
        public float? F_QUOTATIME { get; set; }  //额定工时
        public float? F_JOBORDERQTY { get; set; }      //派工数量
        public float? F_JOBFSHEDQTY { get; set; }      //完成数量
        public int? F_UNITID { get; set; }        //单位序号
        public string F_UNITNAME { get; set; }   //单位名称
        public int? F_OPERATORNUM { get; set; }   //操作人数
        public string F_WORKSHOPNO { get; set; }    //车间编码
        public string F_WORKSHOPNAME { get; set; }  //车间名称
        public DateTime? F_JOBSTART { get; set; } //计划开工日期
        public DateTime? F_JOBEND { get; set; }   //计划结束日期
        public string F_VERHICLETYPE { get; set; }  //车型型号
        public int? F_JOBORDERTYPE { get; set; }   //派工单类型 0：自动派单；1：手动派单
        public int? F_STATUS { get; set; }      //生产状态
        public DateTime? F_UPDATETIME { get; set; }  //状态更新时间
        public string F_CREATOR { get; set; }       //创建者
        public DateTime? F_CREATIONDATE { get; set; }  // 创建时间
        public string F_WORKCENTERCODE { get; set; }    //工作中心code
        public string F_MONOPARTID { get; set; }  //单件号
        public string F_BATCHNO { get; set; }  //批次号

    }
}
