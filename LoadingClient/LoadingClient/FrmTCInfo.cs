using Newtonsoft.Json;
using RS.Common;
using RS.Model;
using RS.RealTimeDBO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadingClient
{
    public partial class FrmTCInfo : Form
    {
        
        public FrmTCInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTCInfo_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            RedisHelper rdsReal = new RedisHelper(ColParamGblVal.G_DbNumR); //指定连接的库，默认是10
            string YunTongColCache3 = "YunTongColCache3";//存储缓存板链
            string YunTongColCache6 = "YunTongColCache6";//存储缓存板链
            string YunTongColCache7 = "YunTongColCache7";//存储缓存板链
            string YunTongColCache8 = "YunTongColCache8";//存储缓存板链
            string strJsonArmEndTabRealValue3 = rdsReal.GetStrValue(YunTongColCache3);
            string strJsonArmEndTabRealValue6 = rdsReal.GetStrValue(YunTongColCache6);
            string strJsonArmEndTabRealValue7 = rdsReal.GetStrValue(YunTongColCache7);
            string strJsonArmEndTabRealValue8 = rdsReal.GetStrValue(YunTongColCache8);

            #region 创建数据表
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            dt1.Columns.Add("column00", System.Type.GetType("System.String"));//TC
            dt1.Columns.Add("column01", typeof(String));                      //完成	
            dt1.Columns.Add("column02", typeof(String));                      //忙碌	
            dt1.Columns.Add("column03", typeof(String));                      //请求入库
            dt1.Columns.Add("column04", typeof(String));                      //故障	
            dt1.Columns.Add("column05", typeof(String));                      //TC位置	
            dt1.Columns.Add("column06", typeof(String));                      //吊具	
            dt1.Columns.Add("column07", typeof(String));                      //路由	
            dt1.Columns.Add("column08", typeof(String));                      //类型	
            dt1.Columns.Add("column09", typeof(String));                      //颜色	
            dt1.Columns.Add("column10", typeof(String));                      //编码
            dt1.Columns.Add("column11", typeof(String));                      //控制方式
            dt1.Columns.Add("column12", typeof(String));                      //手动调度
            dt1.Columns.Add("column13", typeof(String));                      //手动调度

            dt2.Columns.Add("column00", System.Type.GetType("System.String"));//TC
            dt2.Columns.Add("column01", typeof(String));                      //入库巷道
            dt2.Columns.Add("column02", typeof(String));                      //出库巷道
            dt2.Columns.Add("column03", typeof(String));                      //工作方式  0==无作业  1==正常出库  2==倒库   3==整返
            dt2.Columns.Add("column04", typeof(String));                      //吊具号
            dt2.Columns.Add("column05", typeof(String));                      //物料编码	
            dt2.Columns.Add("column06", typeof(String));                      //工件码
            #endregion

            #region 
            if (!string.IsNullOrEmpty(strJsonArmEndTabRealValue3))
            {
                JsonSwingArm jsonSwingArm = JsonConvert.DeserializeObject<JsonSwingArm>(strJsonArmEndTabRealValue3);
                if (jsonSwingArm != null)
                {
                    #region 解析并转换数据

                    DataRow dr1 = dt1.NewRow();
                    DataRow dr2 = dt1.NewRow();
                    DataRow dr3 = dt1.NewRow();
                    DataRow dr4 = dt1.NewRow();
                    dr1["column00"] = "动臂斗杆移行机1";
                    dr1["column01"] = jsonSwingArm.accomplish1;
                    dr1["column02"] = jsonSwingArm.busy1;
                    dr1["column03"] = jsonSwingArm.requestInStorage1;
                    dr1["column04"] = jsonSwingArm.malfunction1;
                    dr1["column05"] = jsonSwingArm.location1;
                    dr1["column06"] = jsonSwingArm.slingNo1;
                    dr1["column07"] = jsonSwingArm.route1;
                    dr1["column08"] = jsonSwingArm.type1;
                    dr1["column09"] = jsonSwingArm.colour1;
                    dr1["column10"] = jsonSwingArm.materialCode1;
                    dr1["column11"] = jsonSwingArm.controlmode1;
                    dr1["column12"] = jsonSwingArm.manualControl1;
                    dr1["column13"] = jsonSwingArm.heartbeat1;
                    dt1.Rows.Add(dr1);

                    dr2["column00"] = "动臂斗杆移行机2";
                    dr2["column01"] = jsonSwingArm.accomplish2;
                    dr2["column02"] = jsonSwingArm.busy2;
                    dr2["column03"] = jsonSwingArm.requestInStorage2;
                    dr2["column04"] = jsonSwingArm.malfunction2;
                    dr2["column05"] = jsonSwingArm.location2;
                    dr2["column06"] = jsonSwingArm.slingNo2;
                    dr2["column07"] = jsonSwingArm.route2;
                    dr2["column08"] = jsonSwingArm.type2;
                    dr2["column09"] = jsonSwingArm.colour2;
                    dr2["column10"] = jsonSwingArm.materialCode2;
                    dr2["column11"] = jsonSwingArm.controlmode2;
                    dr2["column12"] = jsonSwingArm.manualControl2;
                    dr2["column13"] = jsonSwingArm.heartbeat2;
                    dt1.Rows.Add(dr2);

                    dr3["column00"] = "动臂斗杆移行机3";
                    dr3["column01"] = jsonSwingArm.accomplish3;
                    dr3["column02"] = jsonSwingArm.busy3;
                    dr3["column03"] = jsonSwingArm.requestInStorage3;
                    dr3["column04"] = jsonSwingArm.malfunction3;
                    dr3["column05"] = jsonSwingArm.location3;
                    dr3["column06"] = jsonSwingArm.slingNo3;
                    dr3["column07"] = jsonSwingArm.route3;
                    dr3["column08"] = jsonSwingArm.type3;
                    dr3["column09"] = jsonSwingArm.colour3;
                    dr3["column10"] = jsonSwingArm.materialCode3;
                    dr3["column11"] = jsonSwingArm.controlmode3;
                    dr3["column12"] = jsonSwingArm.manualControl3;
                    dr3["column13"] = jsonSwingArm.heartbeat3;
                    dt1.Rows.Add(dr3);

                    dr4["column00"] = "动臂斗杆移行机4";
                    dr4["column01"] = jsonSwingArm.accomplish4;
                    dr4["column02"] = jsonSwingArm.busy4;
                    dr4["column03"] = jsonSwingArm.requestInStorage4;
                    dr4["column04"] = jsonSwingArm.malfunction4;
                    dr4["column05"] = jsonSwingArm.location4;
                    dr4["column06"] = jsonSwingArm.slingNo4;
                    dr4["column07"] = jsonSwingArm.route4;
                    dr4["column08"] = jsonSwingArm.type4;
                    dr4["column09"] = jsonSwingArm.colour4;
                    dr4["column10"] = jsonSwingArm.materialCode4;
                    dr4["column11"] = jsonSwingArm.controlmode4;
                    dr4["column12"] = jsonSwingArm.manualControl4;
                    dr4["column13"] = jsonSwingArm.heartbeat4;
                    dt1.Rows.Add(dr4);
                    #endregion 解析并转换数据
                }
            }
            if (!string.IsNullOrEmpty(strJsonArmEndTabRealValue6))
            {
                JsonSwingArm jsonSwingArm = JsonConvert.DeserializeObject<JsonSwingArm>(strJsonArmEndTabRealValue6);
                if (jsonSwingArm != null)
                {
                    #region 解析并转换数据

                    DataRow dr1 = dt1.NewRow();
                    DataRow dr2 = dt1.NewRow();
                    DataRow dr3 = dt1.NewRow();
                    DataRow dr4 = dt1.NewRow();
                    dr1["column00"] = "履带转台移行机1";
                    dr1["column01"] = jsonSwingArm.accomplish1;
                    dr1["column02"] = jsonSwingArm.busy1;
                    dr1["column03"] = jsonSwingArm.requestInStorage1;
                    dr1["column04"] = jsonSwingArm.malfunction1;
                    dr1["column05"] = jsonSwingArm.location1;
                    dr1["column06"] = jsonSwingArm.slingNo1;
                    dr1["column07"] = jsonSwingArm.route1;
                    dr1["column08"] = jsonSwingArm.type1;
                    dr1["column09"] = jsonSwingArm.colour1;
                    dr1["column10"] = jsonSwingArm.materialCode1;
                    dr1["column11"] = jsonSwingArm.controlmode1;
                    dr1["column12"] = jsonSwingArm.manualControl1;
                    dr1["column13"] = jsonSwingArm.heartbeat1;
                    dt1.Rows.Add(dr1);

                    dr2["column00"] = "履带转台移行机2";
                    dr2["column01"] = jsonSwingArm.accomplish2;
                    dr2["column02"] = jsonSwingArm.busy2;
                    dr2["column03"] = jsonSwingArm.requestInStorage2;
                    dr2["column04"] = jsonSwingArm.malfunction2;
                    dr2["column05"] = jsonSwingArm.location2;
                    dr2["column06"] = jsonSwingArm.slingNo2;
                    dr2["column07"] = jsonSwingArm.route2;
                    dr2["column08"] = jsonSwingArm.type2;
                    dr2["column09"] = jsonSwingArm.colour2;
                    dr2["column10"] = jsonSwingArm.materialCode2;
                    dr2["column11"] = jsonSwingArm.controlmode2;
                    dr2["column12"] = jsonSwingArm.manualControl2;
                    dr2["column13"] = jsonSwingArm.heartbeat2;
                    dt1.Rows.Add(dr2);

                    dr3["column00"] = "履带转台移行机3";
                    dr3["column01"] = jsonSwingArm.accomplish3;
                    dr3["column02"] = jsonSwingArm.busy3;
                    dr3["column03"] = jsonSwingArm.requestInStorage3;
                    dr3["column04"] = jsonSwingArm.malfunction3;
                    dr3["column05"] = jsonSwingArm.location3;
                    dr3["column06"] = jsonSwingArm.slingNo3;
                    dr3["column07"] = jsonSwingArm.route3;
                    dr3["column08"] = jsonSwingArm.type3;
                    dr3["column09"] = jsonSwingArm.colour3;
                    dr3["column10"] = jsonSwingArm.materialCode3;
                    dr3["column11"] = jsonSwingArm.controlmode3;
                    dr3["column12"] = jsonSwingArm.manualControl3;
                    dr3["column13"] = jsonSwingArm.heartbeat3;
                    dt1.Rows.Add(dr3);

                    dr4["column00"] = "履带转台移行机4";
                    dr4["column01"] = jsonSwingArm.accomplish4;
                    dr4["column02"] = jsonSwingArm.busy4;
                    dr4["column03"] = jsonSwingArm.requestInStorage4;
                    dr4["column04"] = jsonSwingArm.malfunction4;
                    dr4["column05"] = jsonSwingArm.location4;
                    dr4["column06"] = jsonSwingArm.slingNo4;
                    dr4["column07"] = jsonSwingArm.route4;
                    dr4["column08"] = jsonSwingArm.type4;
                    dr4["column09"] = jsonSwingArm.colour4;
                    dr4["column10"] = jsonSwingArm.materialCode4;
                    dr4["column11"] = jsonSwingArm.controlmode4;
                    dr4["column12"] = jsonSwingArm.manualControl4;
                    dr4["column13"] = jsonSwingArm.heartbeat4;
                    dt1.Rows.Add(dr4);
                    #endregion 解析并转换数据
                }
            }

            if (!string.IsNullOrEmpty(strJsonArmEndTabRealValue7))
            {
                JsonSwingArmInfo jsonSwingArmInfo = JsonConvert.DeserializeObject<JsonSwingArmInfo>(strJsonArmEndTabRealValue7);
                if (jsonSwingArmInfo != null)
                {
                    #region 解析并转换数据
                    
                    DataRow dr1 = dt2.NewRow();
                    DataRow dr2 = dt2.NewRow();
                    DataRow dr3 = dt2.NewRow();
                    DataRow dr4 = dt2.NewRow();
                    dr1["column00"] = "动臂斗杆移行机1";
                    dr1["column01"] = jsonSwingArmInfo.aisleIn1;
                    dr1["column02"] = jsonSwingArmInfo.aisleOut1;
                    dr1["column03"] = workType(jsonSwingArmInfo.workType1);
                    dr1["column04"] = jsonSwingArmInfo.xc_id1;
                    dr1["column05"] = jsonSwingArmInfo.ml_id1;
                    dr1["column06"] = jsonSwingArmInfo.artifactCode1;
                    dt2.Rows.Add(dr1);

                    dr2["column00"] = "动臂斗杆移行机2";
                    dr2["column01"] = jsonSwingArmInfo.aisleIn2;
                    dr2["column02"] = jsonSwingArmInfo.aisleOut2;
                    dr2["column03"] = workType(jsonSwingArmInfo.workType2);
                    dr2["column04"] = jsonSwingArmInfo.xc_id2;
                    dr2["column05"] = jsonSwingArmInfo.ml_id2;
                    dr2["column06"] = jsonSwingArmInfo.artifactCode2;
                    dt2.Rows.Add(dr2);

                    dr3["column00"] = "动臂斗杆移行机3";
                    dr3["column01"] = jsonSwingArmInfo.aisleIn3;
                    dr3["column02"] = jsonSwingArmInfo.aisleOut3;
                    dr3["column03"] = workType(jsonSwingArmInfo.workType3);
                    dr3["column04"] = jsonSwingArmInfo.xc_id3;
                    dr3["column05"] = jsonSwingArmInfo.ml_id3;
                    dr3["column06"] = jsonSwingArmInfo.artifactCode3;
                    dt2.Rows.Add(dr3);

                    dr4["column00"] = "动臂斗杆移行机4";
                    dr4["column01"] = jsonSwingArmInfo.aisleIn4;
                    dr4["column02"] = jsonSwingArmInfo.aisleOut4;
                    dr4["column03"] = workType(jsonSwingArmInfo.workType4);
                    dr4["column04"] = jsonSwingArmInfo.xc_id4;
                    dr4["column05"] = jsonSwingArmInfo.ml_id4;
                    dr4["column06"] = jsonSwingArmInfo.artifactCode4;
                    dt2.Rows.Add(dr4);
                    #endregion 解析并转换数据
                }
            }
            if (!string.IsNullOrEmpty(strJsonArmEndTabRealValue8))
            {
                JsonSwingArmInfo jsonSwingArmInfo = JsonConvert.DeserializeObject<JsonSwingArmInfo>(strJsonArmEndTabRealValue8);
                if (jsonSwingArmInfo != null)
                {
                    #region 解析并转换数据

                    DataRow dr1 = dt2.NewRow();
                    DataRow dr2 = dt2.NewRow();
                    DataRow dr3 = dt2.NewRow();
                    DataRow dr4 = dt2.NewRow();
                    dr1["column00"] = "履带转台移行机1";
                    dr1["column01"] = jsonSwingArmInfo.aisleIn1;
                    dr1["column02"] = jsonSwingArmInfo.aisleOut1;
                    dr1["column03"] = workType(jsonSwingArmInfo.workType1);
                    dr1["column04"] = jsonSwingArmInfo.xc_id1;
                    dr1["column05"] = jsonSwingArmInfo.ml_id1;
                    dr1["column06"] = jsonSwingArmInfo.artifactCode1;
                    dt2.Rows.Add(dr1);

                    dr2["column00"] = "履带转台移行机2";
                    dr2["column01"] = jsonSwingArmInfo.aisleIn2;
                    dr2["column02"] = jsonSwingArmInfo.aisleOut2;
                    dr2["column03"] = workType(jsonSwingArmInfo.workType2);
                    dr2["column04"] = jsonSwingArmInfo.xc_id2;
                    dr2["column05"] = jsonSwingArmInfo.ml_id2;
                    dr2["column06"] = jsonSwingArmInfo.artifactCode2;
                    dt2.Rows.Add(dr2);

                    dr3["column00"] = "履带转台移行机3";
                    dr3["column01"] = jsonSwingArmInfo.aisleIn3;
                    dr3["column02"] = jsonSwingArmInfo.aisleOut3;
                    dr3["column03"] = workType(jsonSwingArmInfo.workType3);
                    dr3["column04"] = jsonSwingArmInfo.xc_id3;
                    dr3["column05"] = jsonSwingArmInfo.ml_id3;
                    dr3["column06"] = jsonSwingArmInfo.artifactCode3;
                    dt2.Rows.Add(dr3);

                    dr4["column00"] = "履带转台移行机4";
                    dr4["column01"] = jsonSwingArmInfo.aisleIn4;
                    dr4["column02"] = jsonSwingArmInfo.aisleOut4;
                    dr4["column03"] = workType(jsonSwingArmInfo.workType4);
                    dr4["column04"] = jsonSwingArmInfo.xc_id4;
                    dr4["column05"] = jsonSwingArmInfo.ml_id4;
                    dr4["column06"] = jsonSwingArmInfo.artifactCode4;
                    dt2.Rows.Add(dr4);
                    #endregion 解析并转换数据
                }
            }
            #endregion

            uiDataGridView1.DataSource = dt1;
            GenerateDataGridViewColumns1();
            uiDataGridView2.DataSource = dt2;
            GenerateDataGridViewColumns2();

        }

        private void GenerateDataGridViewColumns1()  // 生成DataGridView列
        {
            uiDataGridView1.Columns[0].HeaderText = "移行机编号";
            uiDataGridView1.Columns[1].HeaderText =  "完成";
            uiDataGridView1.Columns[2].HeaderText =  "忙碌";
            uiDataGridView1.Columns[3].HeaderText =  "请求入库";
            uiDataGridView1.Columns[4].HeaderText =  "故障";
            uiDataGridView1.Columns[5].HeaderText =  "TC位置";
            uiDataGridView1.Columns[6].HeaderText =  "吊具";
            uiDataGridView1.Columns[7].HeaderText =  "路由";
            uiDataGridView1.Columns[8].HeaderText =  "类型";
            uiDataGridView1.Columns[9].HeaderText =  "颜色";
            uiDataGridView1.Columns[10].HeaderText = "编码";
            uiDataGridView1.Columns[11].HeaderText = "控制方式";
            uiDataGridView1.Columns[12].HeaderText = "手动调度";
            uiDataGridView1.Columns[13].HeaderText = "心跳";

            DataGridViewHandle gridHdl = new DataGridViewHandle();
            gridHdl._dbgrid = uiDataGridView1;
            gridHdl.GenerateBaseDataGridView();
        }

        private void GenerateDataGridViewColumns2()  // 生成DataGridView列
        {
            uiDataGridView2.Columns[0].HeaderText = "TC";
            uiDataGridView2.Columns[1].HeaderText = "入库巷道";
            uiDataGridView2.Columns[2].HeaderText = "出库巷道";
            uiDataGridView2.Columns[3].HeaderText = "工作方式";
            uiDataGridView2.Columns[4].HeaderText = "吊具号";
            uiDataGridView2.Columns[5].HeaderText = "物料编码";
            uiDataGridView2.Columns[6].HeaderText = "工件码";

            DataGridViewHandle gridHdl = new DataGridViewHandle();
            gridHdl._dbgrid = uiDataGridView2;
            gridHdl.GenerateBaseDataGridView();
        }
        /// <summary>
        /// 工件码显示
        /// </summary>
        /// <param name="workType">0==无作业  1==正常出库  2==倒库   3==整返</param>
        /// <returns></returns>
        private string workType(int workType)
        {
            switch (workType)
            {
                case 0:
                    return "无作业";
                case 1:
                    return "正常出库";
                case 2:
                    return "倒库";
                case 3:
                    return "整返";
                default:
                    return "";
                    
            }
        }

        private void btnHandleResult_Click(object sender, EventArgs e)
        {
            FrmTCInfo_Load(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
