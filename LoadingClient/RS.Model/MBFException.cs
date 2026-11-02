using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RS.Model
{
    #region 异常呼叫实体类
    /// <summary>
    /// 异常呼叫实体类
    /// </summary>
    public class MBFException
    {
        /// <summary> 
        /// 问题反馈索引号  
        /// </summary> 
        public int INDEXID { get; set; }

        // 异常编号
        [XmlElement(ElementName = "ABNORMALNO")]
        public string WORKORDERID { get; set; }
        // 异常类型
        [XmlElement(ElementName = "ABNORMALTYPE")]
        public string EXCEPTIONTYPE { get; set; }
        // 异常备注
        [XmlElement(ElementName = "ABNORMALNOTE")]
        public string EXCEPTIONDESC { get; set; }
        // 异常呼叫部门
        [XmlElement(ElementName = "ABNORMALDEPT")]
        public string EXCEPTIONDEPT { get; set; }
        // 设备编号(工位号)
        [XmlElement(ElementName = "MA_CODICE")]
        public string STATIONNO { get; set; }
        // 提交人
        [XmlElement(ElementName = "CREATE_USER")]
        public string INITIATOR { get; set; }
        // 提交时间
        [XmlElement(ElementName = "CREATE_DATE")]
        public string INITTIME { get; set; }
        // 处理人
        [XmlElement(ElementName = "DEAL_USER")]
        public string HANDLEPERSON { get; set; }
        // 处理方法
        [XmlElement(ElementName = "DEAL_METHOD")]
        public string HANDLERESULT { get; set; }
        // 处理日期
        [XmlElement(ElementName = "DEAL_DATE")]
        public string HANDLETIME { get; set; }
    }
    #endregion

    #region 异常呼叫请求类
    [XmlRoot(ElementName = "ROOT")]
    public class MExceptionRequest
    {
        [XmlElement(ElementName = "ABNORMAL")]
        public MBFException MExceptionCommit { get; set; }
    }
    #endregion

    #region 异常处理结果请求类
    [XmlRoot(ElementName = "ROOT")]
    public class MExceptionResultRequest
    {
        [XmlElement(ElementName = "ABNORMAL")]
        public MBFException MExceptionResult { get; set; }
    }
    #endregion

    #region 异常类型
    public enum ExceptionType
    {
        [Description("设备异常")]
        DeviceException,

        [Description("工位异常")]
        StationException,

        [Description("一般物料异常")]
        NormalMaterialException,

        [Description("严重物料异常")]
        DetailMaterialException,

        [Description("工具工装异常")]
        ToolException,

        [Description("其他")]
        OtherException,
    }

    #endregion
}
