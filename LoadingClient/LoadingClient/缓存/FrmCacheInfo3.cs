using Newtonsoft.Json;
using RS.BLL;
using RS.Common;
using RS.Model;
using RS.RealTimeDBO;
using RS.SQLServerDAL;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadingClient
{
    public partial class FrmCacheInfo3 : Form
    {
        RedisHelper rdsReal = new RedisHelper(10); //指定连接的库，默认是10
        string strRedisKeyRealValue1 = "YunTongColCache4";//存储缓存板链
        List<JsonMaterialInfo> cacheJsonMaterialInfos1 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> cacheJsonMaterialInfos2 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> cacheJsonMaterialInfos3 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> cacheJsonMaterialInfos4 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> cacheJsonMaterialInfos5 = new List<JsonMaterialInfo>();
        List<List<JsonMaterialInfo>> cacheJsonMaterialInfos = new List<List<JsonMaterialInfo>>();
        BMaterialInfo bMaterialInfo = new BMaterialInfo();

        private delegate void PrintSysTime();  //委托事件
        private PrintSysTime DgRealSysTimeValue;
        /// <summary>
        /// 采集线程列表
        /// </summary>
        private List<Thread> collectThreadList = new List<Thread>();  //采集线程集合

        int aisle = -9;
        int location = -9;
        UIPage uiPage = new UIPage();
        BSelectInfo bSelectInfo = new BSelectInfo();
        JsonSerializerSettings jsetting = new JsonSerializerSettings();

        #region 系统时间

        /// <summary>
        /// 显示实时系统时间
        /// </summary>
        private void PrintRealSysTime()
        {
            //这里一直监控是否有请求和同意
            //当前功能界面的同意
            int bAgree = bSelectInfo.agreeRequest(3);
            if (bAgree == 2)
            {

                BtnAdd.Enabled = true;
                BtnDelete.Enabled = true;
                BtnUpdate.Enabled = true;
                BtnInsert.Enabled = true;
            }
            else
            {

                BtnAdd.Enabled = false;
                BtnDelete.Enabled = false;
                BtnUpdate.Enabled = false;
                BtnInsert.Enabled = false;
            }
        }

        /// <summary>
        /// 开始显示实时系统时间
        /// </summary>
        private void StartPrintRealTime()
        {
            while (true)
            {
                if (this.IsHandleCreated)
                {
                    BtnAdd.Invoke(DgRealSysTimeValue, null);
                }
                Thread.Sleep(1000);
            }
        }

        #endregion 系统时间

        public FrmCacheInfo3()
        {
            InitializeComponent();
        }

        private void FrmCacheInfo3_Load(object sender, EventArgs e)
        {
            #region 库存下拉

            DataTable DTable = new DataTable();
            DTable.Columns.Add("FromAddrCode", typeof(int));
            DTable.Columns.Add("FromAddrName", typeof(string));
            DTable.Rows.Add(0, "TC1 TC2 1道");
            DTable.Rows.Add(1, "TC1 TC2 2道");
            DTable.Rows.Add(2, "TC1 TC2 3道");
            DTable.Rows.Add(3, "TC1 TC2 4道");
            DTable.Rows.Add(4, "TC1 TC2 5道");
            InventoryAreaCodeBox.DataSource = DTable;
            InventoryAreaCodeBox.DisplayMember = "FromAddrName";
            InventoryAreaCodeBox.ValueMember = "FromAddrCode";

            DataTable DMaterial = bMaterialInfo.DTMaterialInfo(PublicParams.line_code2);
            MaterialCode.DataSource = DMaterial;
            MaterialCode.DisplayMember = "prod_no";
            MaterialCode.ValueMember = "prod_no";

            #endregion 库存下拉

            #region 实时系统时间
            DgRealSysTimeValue = new PrintSysTime(PrintRealSysTime);

            //开始显示实时系统时间线程
            Thread printRealTimeThread = new Thread(StartPrintRealTime);
            printRealTimeThread.IsBackground = true;
            printRealTimeThread.Start();
            collectThreadList.Add(printRealTimeThread);
            #endregion 实时系统时间

            this.WindowState = FormWindowState.Maximized;

            addMaterial();
        }


        void addMaterial()
        {
            #region 清空文字信息

            MaterialInfo1_0.Text = null;
            MaterialInfo1_1.Text = null;
            MaterialInfo1_2.Text = null;
            MaterialInfo1_3.Text = null;
            MaterialInfo1_4.Text = null;
            MaterialInfo1_5.Text = null;
            MaterialInfo1_6.Text = null;
            MaterialInfo1_7.Text = null;
            MaterialInfo1_8.Text = null;
            MaterialInfo1_9.Text = null;
            MaterialInfo1_10.Text = null;

            MaterialInfo2_0.Text = null;
            MaterialInfo2_1.Text = null;
            MaterialInfo2_2.Text = null;
            MaterialInfo2_3.Text = null;
            MaterialInfo2_4.Text = null;
            MaterialInfo2_5.Text = null;
            MaterialInfo2_6.Text = null;
            MaterialInfo2_7.Text = null;
            MaterialInfo2_8.Text = null;
            MaterialInfo2_9.Text = null;
            MaterialInfo2_10.Text = null;

            MaterialInfo3_0.Text = null;
            MaterialInfo3_1.Text = null;
            MaterialInfo3_2.Text = null;
            MaterialInfo3_3.Text = null;
            MaterialInfo3_4.Text = null;
            MaterialInfo3_5.Text = null;
            MaterialInfo3_6.Text = null;
            MaterialInfo3_7.Text = null;
            MaterialInfo3_8.Text = null;
            MaterialInfo3_9.Text = null;
            MaterialInfo3_10.Text = null;

            MaterialInfo4_0.Text = null;
            MaterialInfo4_1.Text = null;
            MaterialInfo4_2.Text = null;
            MaterialInfo4_3.Text = null;
            MaterialInfo4_4.Text = null;
            MaterialInfo4_5.Text = null;
            MaterialInfo4_6.Text = null;
            MaterialInfo4_7.Text = null;
            MaterialInfo4_8.Text = null;
            MaterialInfo4_9.Text = null;
            MaterialInfo4_10.Text = null;

            MaterialInfo5_0.Text = null;
            MaterialInfo5_1.Text = null;
            MaterialInfo5_2.Text = null;
            MaterialInfo5_3.Text = null;
            MaterialInfo5_4.Text = null;
            MaterialInfo5_5.Text = null;
            MaterialInfo5_6.Text = null;
            MaterialInfo5_7.Text = null;
            MaterialInfo5_8.Text = null;
            MaterialInfo5_9.Text = null;
            MaterialInfo5_10.Text = null;

            #endregion 清空文字信息

            #region 按钮

            MaterialInfo1_0.Enabled = false;
            MaterialInfo1_1.Enabled = false;
            MaterialInfo1_2.Enabled = false;
            MaterialInfo1_3.Enabled = false;
            MaterialInfo1_4.Enabled = false;
            MaterialInfo1_5.Enabled = false;
            MaterialInfo1_6.Enabled = false;
            MaterialInfo1_7.Enabled = false;
            MaterialInfo1_8.Enabled = false;
            MaterialInfo1_9.Enabled = false;
            MaterialInfo1_10.Enabled = false;

            MaterialInfo2_0.Enabled = false;
            MaterialInfo2_1.Enabled = false;
            MaterialInfo2_2.Enabled = false;
            MaterialInfo2_3.Enabled = false;
            MaterialInfo2_4.Enabled = false;
            MaterialInfo2_5.Enabled = false;
            MaterialInfo2_6.Enabled = false;
            MaterialInfo2_7.Enabled = false;
            MaterialInfo2_8.Enabled = false;
            MaterialInfo2_9.Enabled = false;
            MaterialInfo2_10.Enabled = false;

            MaterialInfo3_0.Enabled = false;
            MaterialInfo3_1.Enabled = false;
            MaterialInfo3_2.Enabled = false;
            MaterialInfo3_3.Enabled = false;
            MaterialInfo3_4.Enabled = false;
            MaterialInfo3_5.Enabled = false;
            MaterialInfo3_6.Enabled = false;
            MaterialInfo3_7.Enabled = false;
            MaterialInfo3_8.Enabled = false;
            MaterialInfo3_9.Enabled = false;
            MaterialInfo3_10.Enabled = false;

            MaterialInfo4_0.Enabled = false;
            MaterialInfo4_1.Enabled = false;
            MaterialInfo4_2.Enabled = false;
            MaterialInfo4_3.Enabled = false;
            MaterialInfo4_4.Enabled = false;
            MaterialInfo4_5.Enabled = false;
            MaterialInfo4_6.Enabled = false;
            MaterialInfo4_7.Enabled = false;
            MaterialInfo4_8.Enabled = false;
            MaterialInfo4_9.Enabled = false;
            MaterialInfo4_10.Enabled = false;

            MaterialInfo5_0.Enabled = false;
            MaterialInfo5_1.Enabled = false;
            MaterialInfo5_2.Enabled = false;
            MaterialInfo5_3.Enabled = false;
            MaterialInfo5_4.Enabled = false;
            MaterialInfo5_5.Enabled = false;
            MaterialInfo5_6.Enabled = false;
            MaterialInfo5_7.Enabled = false;
            MaterialInfo5_8.Enabled = false;
            MaterialInfo5_9.Enabled = false;
            MaterialInfo5_10.Enabled = false;

            #endregion 

            string strJsonArmCacheRealValue = rdsReal.GetStrValue(strRedisKeyRealValue1);
            if (!string.IsNullOrEmpty(strJsonArmCacheRealValue))
            {
                cacheJsonMaterialInfos = JsonConvert.DeserializeObject<List<List<JsonMaterialInfo>>>(strJsonArmCacheRealValue);
                if (cacheJsonMaterialInfos.Count >= 5)
                {
                    cacheJsonMaterialInfos1 = cacheJsonMaterialInfos[0];
                    cacheJsonMaterialInfos2 = cacheJsonMaterialInfos[1];
                    cacheJsonMaterialInfos3 = cacheJsonMaterialInfos[2];
                    cacheJsonMaterialInfos4 = cacheJsonMaterialInfos[3];
                    cacheJsonMaterialInfos5 = cacheJsonMaterialInfos[4];
                }
            }

            #region 加载并显示物料信息

            if (cacheJsonMaterialInfos1 != null && cacheJsonMaterialInfos1.Count > 0)
            {
                for (int i = 0; i < cacheJsonMaterialInfos1.Count; i++)
                {
                    if (i > 10) break;
                    JsonMaterialInfo JsonMaterialInfo = cacheJsonMaterialInfos1[i];
                    string btn = "MaterialInfo1_" + i;
                    object obj = this.GetType().GetField(btn, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    UIButton uIButton = (UIButton)obj;
                    uIButton.Enabled = true;
                    if (!string.IsNullOrEmpty(JsonMaterialInfo.MaterialCode))
                        uIButton.Text = "               " + JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                    else
                        uIButton.Text = "" + JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                }
            }
            if (cacheJsonMaterialInfos2 != null && cacheJsonMaterialInfos2.Count > 0)
            {
                for (int i = 0; i < cacheJsonMaterialInfos2.Count; i++)
                {
                    if (i > 10) break;
                    JsonMaterialInfo JsonMaterialInfo = cacheJsonMaterialInfos2[i];
                    string btn = "MaterialInfo2_" + i;
                    object obj = this.GetType().GetField(btn, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    UIButton uIButton = (UIButton)obj;
                    uIButton.Enabled = true;
                    if (!string.IsNullOrEmpty(JsonMaterialInfo.MaterialCode))
                        uIButton.Text = "               " + JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                    else
                        uIButton.Text = "" + JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                }
            }
            if (cacheJsonMaterialInfos3 != null && cacheJsonMaterialInfos3.Count > 0)
            {
                for (int i = 0; i < cacheJsonMaterialInfos3.Count; i++)
                {
                    if (i > 10) break;
                    JsonMaterialInfo JsonMaterialInfo = cacheJsonMaterialInfos3[i];
                    string btn = "MaterialInfo3_" + i;
                    object obj = this.GetType().GetField(btn, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    UIButton uIButton = (UIButton)obj;
                    uIButton.Enabled = true;
                    if (!string.IsNullOrEmpty(JsonMaterialInfo.MaterialCode))
                        uIButton.Text = "              " + JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                    else
                        uIButton.Text = "" + JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                }
            }
            if (cacheJsonMaterialInfos4 != null && cacheJsonMaterialInfos4.Count > 0)
            {
                for (int i = 0; i < cacheJsonMaterialInfos4.Count; i++)
                {
                    if (i > 10) break;
                    JsonMaterialInfo JsonMaterialInfo = cacheJsonMaterialInfos4[i];
                    string btn = "MaterialInfo4_" + i;
                    object obj = this.GetType().GetField(btn, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    UIButton uIButton = (UIButton)obj;
                    uIButton.Enabled = true;
                    if (!string.IsNullOrEmpty(JsonMaterialInfo.MaterialCode))
                        uIButton.Text = "              " + JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                    else
                        uIButton.Text = "" + JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                }
            }
            if (cacheJsonMaterialInfos5 != null && cacheJsonMaterialInfos5.Count > 0)
            {
                for (int i = 0; i < cacheJsonMaterialInfos5.Count; i++)
                {
                    if (i > 10) break;
                    JsonMaterialInfo JsonMaterialInfo = cacheJsonMaterialInfos5[i];
                    string btn = "MaterialInfo5_" + i;
                    object obj = this.GetType().GetField(btn, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    UIButton uIButton = (UIButton)obj;
                    uIButton.Enabled = true;
                    if (!string.IsNullOrEmpty(JsonMaterialInfo.MaterialCode))
                        uIButton.Text = "              " + JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                    else
                        uIButton.Text = "" + JsonMaterialInfo.SlingNo + "\n" + JsonMaterialInfo.MaterialCode;
                }
            }

            #endregion 

        }

        #region 功能区按钮
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SlingNoBox.Text))
            {
                uiPage.ShowErrorDialog("请检查小车号是否输入正确");
                return;
            }

            JsonMaterialInfo JsonMaterialInfo = new JsonMaterialInfo();
            JsonMaterialInfo.SlingNo = SlingNoBox.Text;
            JsonMaterialInfo.Route = "0";
            if (MaterialCode.Text.Length > 10)
                JsonMaterialInfo.Type = MaterialCode.Text.Substring(7, 2);
            else
                JsonMaterialInfo.Type = "00";
            JsonMaterialInfo.Colour = "0";
            JsonMaterialInfo.SN = DateTime.Now.ToString("yyyyMMddHHmmss");
            JsonMaterialInfo.MaterialCode = MaterialCode.Text;
            if (cacheJsonMaterialInfos.Count > 0)
            {
                cacheJsonMaterialInfos[InventoryAreaCodeBox.SelectedIndex].Add(JsonMaterialInfo);//添加新的
                SaveRedisInfos();
            }
            else
            {
                uiPage.ShowErrorDialog("更改失败，请重试");
            }
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SlingNoBox.Text))
            {
                uiPage.ShowErrorDialog("请检查小车号是否输入正确");
                return;
            }

            if (aisle < 0 && location < 0)
            {
                uiPage.ShowErrorDialog("请选择插入位置");
                return;
            }

            JsonMaterialInfo JsonMaterialInfo = new JsonMaterialInfo();
            JsonMaterialInfo.SlingNo = SlingNoBox.Text;
            JsonMaterialInfo.Route = "0";
            if (MaterialCode.Text.Length > 10)
                JsonMaterialInfo.Type = MaterialCode.Text.Substring(7, 2);
            else
                JsonMaterialInfo.Type = "00";
            JsonMaterialInfo.Colour = "0";
            JsonMaterialInfo.SN = DateTime.Now.ToString("yyyyMMddHHmmss");
            JsonMaterialInfo.MaterialCode = MaterialCode.Text;
            if (cacheJsonMaterialInfos.Count > 0)
            {
                cacheJsonMaterialInfos[aisle].Insert(location, JsonMaterialInfo);//添加新的
                SaveRedisInfos();
            }
            else
            {
                uiPage.ShowErrorDialog("更改失败，请重试");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (aisle < 0 && location < 0)
            {
                uiPage.ShowErrorDialog("请选择要删除的小车");
                return;
            }
            if (cacheJsonMaterialInfos.Count > 0)
            {
                cacheJsonMaterialInfos[aisle].RemoveAt(location);//添加新的
                SaveRedisInfos();
            }
            else
            {
                uiPage.ShowErrorDialog("更改失败，请重试");
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SlingNoBox.Text))
            {
                uiPage.ShowErrorDialog("请检查小车号是否输入正确");
                return;
            }

            if (aisle < 0 && location < 0)
            {
                uiPage.ShowErrorDialog("请选择要更改的小车信息");
                return;
            }

            JsonMaterialInfo JsonMaterialInfo = new JsonMaterialInfo();
            JsonMaterialInfo.SlingNo = SlingNoBox.Text;
            JsonMaterialInfo.Route = "0";
            if (MaterialCode.Text.Length > 10)
                JsonMaterialInfo.Type = MaterialCode.Text.Substring(7, 2);
            else
                JsonMaterialInfo.Type = "00";
            JsonMaterialInfo.Colour = "0";
            JsonMaterialInfo.SN = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            JsonMaterialInfo.MaterialCode = MaterialCode.Text;
            if (cacheJsonMaterialInfos.Count > 0)
            {
                cacheJsonMaterialInfos[aisle].RemoveAt(location);//删除原来的
                cacheJsonMaterialInfos[aisle].Insert(location, JsonMaterialInfo);//添加新的
                SaveRedisInfos();
            }
            else
            {
                uiPage.ShowErrorDialog("更改失败，请重试");
            }
        }

        private void btnFunDes_Click(object sender, EventArgs e)
        {
            bool bRequest = bSelectInfo.SetRequest(3, 1);
            if (bRequest)
            {
                uiPage.ShowAskDialog("已发送请求更改");
            }
            else
            {
                uiPage.ShowAskDialog("请求失败");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            addMaterial();
        }

        #endregion 功能区按钮

        /// <summary>
        /// 保存到Redis
        /// </summary>
        void SaveRedisInfos()
        {
            //保存前先询问
            //收到回复才能保存
            int iAgree = bSelectInfo.agreeRequest(3);
            if (iAgree != 2)
            {
                uiPage.ShowErrorTip("更改失败，超时或未同意，请重新请求更改");
                return;
            }

            #region 保存物料信息到Redis

            string result = JsonConvert.SerializeObject(cacheJsonMaterialInfos, Formatting.Indented, jsetting);
            Task<bool> result1 = rdsReal.SetStrValueAsync(strRedisKeyRealValue1, result);
            bSelectInfo.UpdateRequest(3, 3);
            uiPage.ShowSuccessNotifier("操作完成");
            #endregion 保存物料信息到Redis

            addMaterial();
        }

        #region 按钮

        private void MaterialInfo1_0_Click(object sender, EventArgs e)
        {
            aisle = 0;
            location = 0;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo1_0.Text);
        }

        private void MaterialInfo1_1_Click(object sender, EventArgs e)
        {
            aisle = 0;
            location = 1;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo1_1.Text);
        }

        private void MaterialInfo1_2_Click(object sender, EventArgs e)
        {
            aisle = 0;
            location = 2;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo1_2.Text);
        }

        private void MaterialInfo1_3_Click(object sender, EventArgs e)
        {
            aisle = 0;
            location = 3;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo1_3.Text);
        }

        private void MaterialInfo1_4_Click(object sender, EventArgs e)
        {
            aisle = 0;
            location = 4;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo1_4.Text);
        }

        private void MaterialInfo1_5_Click(object sender, EventArgs e)
        {
            aisle = 0;
            location = 5;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo1_5.Text);
        }

        private void MaterialInfo1_6_Click(object sender, EventArgs e)
        {
            aisle = 0;
            location = 6;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo1_6.Text);
        }

        private void MaterialInfo1_7_Click(object sender, EventArgs e)
        {
            aisle = 0;
            location = 7;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo1_7.Text);
        }

        private void MaterialInfo1_8_Click(object sender, EventArgs e)
        {
            aisle = 0;
            location = 8;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo1_8.Text);
        }

        private void MaterialInfo1_9_Click(object sender, EventArgs e)
        {
            aisle = 0;
            location = 9;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo1_9.Text);
        }

        private void MaterialInfo1_10_Click(object sender, EventArgs e)
        {

        }

        private void MaterialInfo2_0_Click(object sender, EventArgs e)
        {
            aisle = 1;
            location = 0;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo2_0.Text);
        }

        private void MaterialInfo2_1_Click(object sender, EventArgs e)
        {
            aisle = 1;
            location = 1;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo2_1.Text);
        }

        private void MaterialInfo2_2_Click(object sender, EventArgs e)
        {
            aisle = 1;
            location = 2;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo2_2.Text);
        }

        private void MaterialInfo2_3_Click(object sender, EventArgs e)
        {
            aisle = 1;
            location = 3;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo2_3.Text);
        }

        private void MaterialInfo2_4_Click(object sender, EventArgs e)
        {
            aisle = 1;
            location = 4;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo2_4.Text);
        }

        private void MaterialInfo2_5_Click(object sender, EventArgs e)
        {
            aisle = 1;
            location = 5;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo2_5.Text);
        }

        private void MaterialInfo2_6_Click(object sender, EventArgs e)
        {
            aisle = 1;
            location = 6;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo2_6.Text);
        }

        private void MaterialInfo2_7_Click(object sender, EventArgs e)
        {
            aisle = 1;
            location = 7;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo2_7.Text);
        }

        private void MaterialInfo2_8_Click(object sender, EventArgs e)
        {
            aisle = 1;
            location = 8;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo2_8.Text);
        }

        private void MaterialInfo2_9_Click(object sender, EventArgs e)
        {
            aisle = 1;
            location = 9;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo2_9.Text);
        }

        private void MaterialInfo2_10_Click(object sender, EventArgs e)
        {
            aisle = 1;
            location = 10;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo2_10.Text);
        }

        private void MaterialInfo3_0_Click(object sender, EventArgs e)
        {
            aisle = 2;
            location = 0;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo3_0.Text);
        }

        private void MaterialInfo3_1_Click(object sender, EventArgs e)
        {
            aisle = 2;
            location = 1;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo3_1.Text);
        }

        private void MaterialInfo3_2_Click(object sender, EventArgs e)
        {
            aisle = 2;
            location = 2;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo3_2.Text);
        }

        private void MaterialInfo3_3_Click(object sender, EventArgs e)
        {
            aisle = 2;
            location = 3;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo3_3.Text);
        }

        private void MaterialInfo3_4_Click(object sender, EventArgs e)
        {
            aisle = 2;
            location = 4;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo3_4.Text);
        }

        private void MaterialInfo3_5_Click(object sender, EventArgs e)
        {
            aisle = 2;
            location = 5;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo3_5.Text);
        }

        private void MaterialInfo3_6_Click(object sender, EventArgs e)
        {
            aisle = 2;
            location = 6;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo3_6.Text);
        }

        private void MaterialInfo3_7_Click(object sender, EventArgs e)
        {
            aisle = 2;
            location = 7;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo3_7.Text);
        }

        private void MaterialInfo3_8_Click(object sender, EventArgs e)
        {
            aisle = 2;
            location = 8;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo3_8.Text);
        }

        private void MaterialInfo3_9_Click(object sender, EventArgs e)
        {
            aisle = 2;
            location = 9;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo3_9.Text);
        }

        private void MaterialInfo3_10_Click(object sender, EventArgs e)
        {
            aisle = 2;
            location = 10;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo3_10.Text);
        }

        private void MaterialInfo4_0_Click(object sender, EventArgs e)
        {
            aisle = 3;
            location = 0;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo4_0.Text);
        }

        private void MaterialInfo4_1_Click(object sender, EventArgs e)
        {
            aisle = 3;
            location = 1;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo4_1.Text);
        }

        private void MaterialInfo4_2_Click(object sender, EventArgs e)
        {
            aisle = 3;
            location = 2;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo4_2.Text);
        }

        private void MaterialInfo4_3_Click(object sender, EventArgs e)
        {
            aisle = 3;
            location = 3;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo4_3.Text);
        }

        private void MaterialInfo4_4_Click(object sender, EventArgs e)
        {
            aisle = 3;
            location = 4;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo4_4.Text);
        }

        private void MaterialInfo4_5_Click(object sender, EventArgs e)
        {
            aisle = 3;
            location = 5;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo4_5.Text);
        }

        private void MaterialInfo4_6_Click(object sender, EventArgs e)
        {
            aisle = 3;
            location = 6;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo4_6.Text);
        }

        private void MaterialInfo4_7_Click(object sender, EventArgs e)
        {
            aisle = 3;
            location = 7;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo4_7.Text);
        }

        private void MaterialInfo4_8_Click(object sender, EventArgs e)
        {
            aisle = 3;
            location = 8;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo4_8.Text);
        }

        private void MaterialInfo4_9_Click(object sender, EventArgs e)
        {
            aisle = 3;
            location = 9;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo4_9.Text);
        }

        private void MaterialInfo4_10_Click(object sender, EventArgs e)
        {
            aisle = 3;
            location = 10;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo4_10.Text);
        }

        private void MaterialInfo5_0_Click(object sender, EventArgs e)
        {
            aisle = 4;
            location = 0;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo5_0.Text);
        }

        private void MaterialInfo5_1_Click(object sender, EventArgs e)
        {
            aisle = 4;
            location = 1;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo5_1.Text);
        }

        private void MaterialInfo5_2_Click(object sender, EventArgs e)
        {
            aisle = 4;
            location = 2;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo5_2.Text);
        }

        private void MaterialInfo5_3_Click(object sender, EventArgs e)
        {
            aisle = 4;
            location = 3;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo5_3.Text);
        }

        private void MaterialInfo5_4_Click(object sender, EventArgs e)
        {
            aisle = 4;
            location = 4;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo5_4.Text);
        }

        private void MaterialInfo5_5_Click(object sender, EventArgs e)
        {
            aisle = 4;
            location = 5;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo5_5.Text);
        }

        private void MaterialInfo5_6_Click(object sender, EventArgs e)
        {
            aisle = 4;
            location = 6;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo5_6.Text);
        }

        private void MaterialInfo5_7_Click(object sender, EventArgs e)
        {
            aisle = 4;
            location = 7;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo5_7.Text);
        }

        private void MaterialInfo5_8_Click(object sender, EventArgs e)
        {
            aisle = 4;
            location = 8;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo5_8.Text);
        }

        private void MaterialInfo5_9_Click(object sender, EventArgs e)
        {
            aisle = 4;
            location = 9;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo5_9.Text);
        }

        private void MaterialInfo5_10_Click(object sender, EventArgs e)
        {
            aisle = 4;
            location = 10;
            uiPage.ShowSuccessTip("已选择" + MaterialInfo5_10.Text);
        }

        #endregion 按钮

        private void SlingNoBox_TextChanged(object sender, EventArgs e)
        {
            if (SlingNoBox.Text != null)
            {
                if (SlingNoBox.Text.Length > 0)
                {
                    if (!int.TryParse(SlingNoBox.Text, out int sbgdfl))
                    {
                        SlingNoBox.Text = null;
                    }
                    if (sbgdfl == 0)
                    {
                        SlingNoBox.Text = null;
                    }
                }
                if (SlingNoBox.Text.Length > 3)
                {
                    SlingNoBox.Text = null;
                }
            }
        }
    }
}
