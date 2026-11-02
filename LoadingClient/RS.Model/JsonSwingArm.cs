using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonSwingArm
    {
        #region TC1
        /// <summary>
        /// 完成（请求出库）
        /// </summary>
        public bool accomplish1 { get; set; }

        /// <summary>
        /// 忙碌
        /// </summary>
        public bool busy1 { get; set; }

        /// <summary>
        /// 请求入库
        /// </summary>
        public bool requestInStorage1 { get; set; }

        /// <summary>
        /// 故障
        /// </summary>
        public bool malfunction1 { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public int location1 { get; set; }
        /// <summary>
        /// 吊具号 0-2
        /// </summary>
        public string slingNo1 { get; set; }
        /// <summary>
        /// 路由（0==无作业  1==正常出库  2==倒库   3==整返4==去装配9空吊具出库）
        /// </summary>
        public string route1 { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string type1 { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string colour1 { get; set; }
        /// <summary>
        /// 物料编码 8-26位物料编码
        /// </summary>
        public string materialCode1 { get; set; }
        /// <summary>
        /// 控制方式
        /// </summary>
        public bool controlmode1 { get; set; }
        /// <summary>
        /// 手动进车信号
        /// </summary>
        public bool manualControl1 { get; set; }

        public bool heartbeat1 { get; set; }
        #endregion TC1

        #region TC2
        /// <summary>
        /// 空闲/完成(请求出库)
        /// </summary>
        public bool accomplish2 { get; set; }

        /// <summary>
        /// 忙碌
        /// </summary>
        public bool busy2 { get; set; }

        /// <summary>
        /// 请求入库
        /// </summary>
        public bool requestInStorage2 { get; set; }

        /// <summary>
        /// 故障
        /// </summary>
        public bool malfunction2 { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public int location2 { get; set; }
        /// <summary>
        /// 吊具号 0-2
        /// </summary>
        public string slingNo2 { get; set; }
        /// <summary>
        /// 路由（0==无作业  1==正常出库  2==倒库   3==整返4==去装配9空吊具出库）
        /// </summary>
        public string route2 { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string type2 { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string colour2 { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string materialCode2 { get; set; }
        /// <summary>
        /// 控制方式 true自动false手动
        /// </summary>
        public bool controlmode2 { get; set; }
        /// <summary>
        /// 手动出车信号
        /// </summary>
        public bool manualControl2 { get; set; }

        public bool heartbeat2 { get; set; }

        #endregion TC2

        #region TC3
        /// <summary>
        /// 完成（请求出库）
        /// </summary>
        public bool accomplish3 { get; set; }

        /// <summary>
        /// 忙碌
        /// </summary>
        public bool busy3 { get; set; }

        /// <summary>
        /// 请求入库
        /// </summary>
        public bool requestInStorage3 { get; set; }

        /// <summary>
        /// 故障
        /// </summary>
        public bool malfunction3 { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public int location3 { get; set; }
        /// <summary>
        /// 吊具号 0-2
        /// </summary>
        public string slingNo3 { get; set; }
        /// <summary>
        /// 路由（0==无作业  1==正常出库  2==倒库   3==整返4==去装配9空吊具出库）
        /// </summary>
        public string route3 { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string type3 { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string colour3 { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string materialCode3 { get; set; }
        /// <summary>
        /// 控制方式
        /// </summary>
        public bool controlmode3 { get; set; }
        /// <summary>
        /// 手动进车信号
        /// </summary>
        public bool manualControl3 { get; set; }

        public bool heartbeat3 { get; set; }

        #endregion TC3

        #region TC4
        /// <summary>
        /// 完成（请求出库）
        /// </summary>
        public bool accomplish4 { get; set; }

        /// <summary>
        /// 忙碌
        /// </summary>
        public bool busy4 { get; set; }

        /// <summary>
        /// 请求入库
        /// </summary>
        public bool requestInStorage4 { get; set; }

        /// <summary>
        /// 故障
        /// </summary>
        public bool malfunction4 { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        public int location4 { get; set; }

        /// <summary>
        /// 吊具号 0-2
        /// </summary>
        public string slingNo4 { get; set; }
        /// <summary>
        /// 路由（0==无作业  1==正常出库  2==倒库   3==整返4==去装配9空吊具出库）   
        /// </summary>
        public string route4 { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string type4 { get; set; }
        /// <summary>
        /// 颜色
        /// </summary>
        public string colour4 { get; set; }
        /// <summary>
        /// 物料编码
        /// </summary>
        public string materialCode4 { get; set; }
        /// <summary>
        /// 控制方式
        /// </summary>
        public bool controlmode4 { get; set; }
        /// <summary>
        /// 手动出车信号
        /// </summary>
        public bool manualControl4 { get; set; }

        public bool heartbeat4 { get; set; }

        #endregion TC4
    }
}
