using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Model
{
    /// <summary>
    /// 信息化传输的信息
    /// </summary>
    public class JsonSwingArmInfo
    {
        //Scard-To-输送
        //入库巷道
        //出库巷道
        //工作方式  0==无作业  1==正常出库  2==倒库   3==整返
        //吊具号
        //物料编码
        //工件码

        #region 入库巷道
        /// <summary>
        /// 入库巷道
        /// </summary>
        public int aisleIn1 { get; set; }
        /// <summary>
        /// 入库巷道
        /// </summary>
        public int aisleIn2 { get; set; }
        /// <summary>
        /// 入库巷道
        /// </summary>
        public int aisleIn3 { get; set; }
        /// <summary>
        /// 入库巷道
        /// </summary>
        public int aisleIn4 { get; set; }
        #endregion 入库巷道

        #region 出库巷道
        /// <summary>
        /// 出库巷道
        /// </summary>
        public int aisleOut1 { get; set; }
        /// <summary>
        /// 出库巷道
        /// </summary>
        public int aisleOut2 { get; set; }
        /// <summary>
        /// 出库巷道
        /// </summary>
        public int aisleOut3 { get; set; }
        /// <summary>
        /// 出库巷道
        /// </summary>
        public int aisleOut4 { get; set; }
        #endregion 出库巷道

        #region 工作方式
        /// <summary>
        /// 工作方式（0无作业  1正常出库  2倒库   3整返 4去装配 9空吊具）
        /// </summary>
        public int workType1 { get; set; }
        /// <summary>
        /// 工作方式（0无作业  1正常出库  2倒库   3整返 4去装配 9空吊具）
        /// </summary>
        public int workType2 { get; set; }
        /// <summary>
        /// 工作方式（0无作业  1正常出库  2倒库   3整返 4去装配 9空吊具）
        /// </summary>
        public int workType3 { get; set; }
        /// <summary>
        /// 工作方式（0无作业  1正常出库  2倒库   3整返 4去装配 9空吊具）
        /// </summary>
        public int workType4 { get; set; }

        #endregion 工作方式

        #region 工件码
        /// <summary>
        /// 工件码
        /// </summary>
        public string artifactCode1 { get; set; }
        /// <summary>
        /// 工件码
        /// </summary>
        public string artifactCode2 { get; set; }
        /// <summary>
        /// 工件码
        /// </summary>
        public string artifactCode3 { get; set; }
        /// <summary>
        /// 工件码
        /// </summary>
        public string artifactCode4 { get; set; }
        #endregion 工件码

        #region 吊具号
        /// <summary>
        /// 吊具号
        /// </summary>
        public string xc_id1 { get; set; }
        /// <summary>
        /// 吊具号
        /// </summary>
        public string xc_id2 { get; set; }
        /// <summary>
        /// 吊具号
        /// </summary>
        public string xc_id3 { get; set; }
        /// <summary>
        /// 吊具号
        /// </summary>
        public string xc_id4 { get; set; }
        #endregion 吊具号

        #region 物料码
        /// <summary>
        /// 物料码
        /// </summary>
        public string ml_id1 { get; set; }
        /// <summary>
        /// 物料码
        /// </summary>
        public string ml_id2 { get; set; }
        /// <summary>
        /// 物料码
        /// </summary>
        public string ml_id3 { get; set; }
        /// <summary>
        /// 物料码
        /// </summary>
        public string ml_id4 { get; set; }
        #endregion 物料码

    }
}
