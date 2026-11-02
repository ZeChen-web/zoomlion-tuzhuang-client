using Newtonsoft.Json;
using RS.BLL;
using RS.Common;
using RS.Model;
using RS.RealTimeDBO;
using RS.SQLServerDAL;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadingClient
{
    public partial class FrmMaterialSelect : Form
    {
        /// <summary>
        /// 获取鼠标选中的行
        /// </summary>
        int MouseSelectedRow = -1;
        /// <summary>
        /// 功能（1，动臂斗杆1,2动臂斗杆2----3履带转台缓存1,4履带转台缓存2）
        /// </summary>
        private string function = "";
        private delegate void SetTxtCallBack(string msg);
        private SetTxtCallBack MsgDlgOptBarCode;

        private delegate void PrintSysTime();  //委托事件
        private PrintSysTime DgRealSysTimeValue;

        UIPage uiPage = new UIPage();
        DataTable dTable = new DataTable();
        DataGridViewHandle gridHdl = new DataGridViewHandle();
        MMaterialCodeInfo MMaterialCodeInfo = new MMaterialCodeInfo();
        JsonSerializerSettings jsetting = new JsonSerializerSettings();
        List<MMaterialCodeInfo> ListMaterialCodeInfos = new List<MMaterialCodeInfo>();
        /// <summary>
        /// 吊具信息类
        /// </summary>
        JsonMaterialInfo JsonMaterialInfo = null;
        BSelectInfo bSelectInfo = new BSelectInfo();
        /// <summary>
        /// 采集线程列表
        /// </summary>
        private List<Thread> collectThreadList = new List<Thread>();  //采集线程集合
        /// <summary>
        /// 功能
        /// </summary>
        public string Function
        {
            set
            {
                function = value;
            }
        }

        public FrmMaterialSelect(string _function)
        {
            function= _function;
            InitializeComponent();
            try
            {
                MsgDlgOptBarCode = new SetTxtCallBack(DisplayTxtOptLogin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 在文本框中显示主机条形码
        /// </summary>
        private void DisplayTxtOptLogin(string msg)
        {
            if (uiDataGridView1.InvokeRequired)
            {
                uiDataGridView1.Invoke(MsgDlgOptBarCode, msg);
            }
            else
            {
                //uiLabelMesss.Text = msg;
            }

        }
        #region 系统时间

        /// <summary>
        /// 显示实时系统时间
        /// </summary>
        private void PrintRealSysTime()
        {
            //这里一直监控是否有请求和同意
            //当前功能界面的同意
            int bAgree = bSelectInfo.agreeRequest(Convert.ToInt32(function));
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

        #region 查询redis
        RedisHelper rdsReal = new RedisHelper(10); //指定连接的库，默认是10
        string strRedisKeyRealValue1 = "YunTongColCache1";//存储缓存板链
        string strRedisKeyRealValue2 = "YunTongColCache2";//存储排序板链
        string strRedisKeyRealValue4 = "YunTongColCache4";//存储缓存板链
        string strRedisKeyRealValue5 = "YunTongColCache5";//存储排序板链
        List<JsonMaterialInfo> cacheJsonMaterialInfos1 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> cacheJsonMaterialInfos2 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> cacheJsonMaterialInfos3 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> cacheJsonMaterialInfos4 = new List<JsonMaterialInfo>();
        List<List<JsonMaterialInfo>> cacheJsonMaterialInfos = new List<List<JsonMaterialInfo>>();

        List<JsonMaterialInfo> needJsonMaterialInfos1 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> needJsonMaterialInfos2 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> needJsonMaterialInfos3 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> needJsonMaterialInfos4 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> needJsonMaterialInfos5 = new List<JsonMaterialInfo>();
        List<JsonMaterialInfo> needJsonMaterialInfos6 = new List<JsonMaterialInfo>();
        List<List<JsonMaterialInfo>> needJsonMaterialInfos = new List<List<JsonMaterialInfo>>();
        #endregion 查询Redis

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMaterialSelect_Load(object sender, EventArgs e)
        {
            #region 添加下拉

            #region 物料下拉
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("FromAddrCode", typeof(string));
            dtResult.Columns.Add("FromAddrName", typeof(string));
            if (function.Equals("1")|| function.Equals("2"))
            {
                dtResult.Rows.Add("不限", "--不限--");
                dtResult.Rows.Add("003010314A0200000", "动臂ZE135E-10/ZE135E-10F/ZE135E-10土耳其");
                dtResult.Rows.Add("003010015A0200000", "斗杆ZE135E-10/ZE135E-10土耳其/ZE155E-10");
                dtResult.Rows.Add("003010715A0200000", "斗杆ZE135E-10F");
                dtResult.Rows.Add("003010014A0200000", "动臂ZE155E-10");
                dtResult.Rows.Add("003011514A0200000", "动臂ZE200E-10/ZE200E-10s/ZE205E-10/ZE205E-10pro/ZE215E/ZE215E I2CN/ZE215E-10/ZE220E-10/ZE220EK-10s/ZE210Ei/ZE220Ei");
                dtResult.Rows.Add("003001415A0200000", "斗杆ZE200E-10/ZE200E-10s/ZE205E-10pro/ZE220EK-10s/ZE210Ei/ZE220Ei");
                dtResult.Rows.Add("003011015A0200001", "斗杆ZE205E-10/ZE215E/ZE215E I2CN/ZE215E-10/ZE220E-10");
                dtResult.Rows.Add("003012215A0200000", "斗杆ZE245E-10plus/ZE245E/ZE265E-10");
                dtResult.Rows.Add("003012214A0200000", "动臂ZE245E-10plus/ZE265E-10");
                dtResult.Rows.Add("003004814A0200000", "动臂ZE245E");
                dtResult.Rows.Add("003006115A0200000", "斗杆ZE330E-10/ZE335E");
                dtResult.Rows.Add("003006114A0200000", "动臂ZE330E-10/ZE335E");
                dtResult.Rows.Add("003024515A0200000", "斗杆ZE370E/ZE370E金矿版");
                dtResult.Rows.Add("003024514A0200000", "动臂ZE370E/ZE370E金矿版");
                dtResult.Rows.Add("003024315A0200000", "斗杆ZE370E-10VC行走马达/ZE370E-10VD行走马达");
                dtResult.Rows.Add("003024314A0200000", "动臂ZE370E-10VC行走马达/ZE370E-10VD行走马达/ZE375Ek-10VC行走马达/ZE375Ek-10VD行走马达");
                dtResult.Rows.Add("003024415A0200000", "斗杆ZE375Ek-10VC行走马达/ZE375Ek-10VD行走马达");
                dtResult.Rows.Add("00000000000000000", "空吊具");
                MaterilaCodeBox.DataSource = dtResult;
                MaterilaCodeBox.DisplayMember = "FromAddrName";
                MaterilaCodeBox.ValueMember = "FromAddrCode";
            }
            else
            {
                dtResult.Rows.Add("不限", "--不限--");
                dtResult.Rows.Add("003010307A0200000", "转台ZE135E-10/ZE135E-10土耳其");
                dtResult.Rows.Add("003010017A0200001", "履带ZE135E-10/ZE135E-10土耳其/ZE155E-10");
                dtResult.Rows.Add("003010717B0200000", "履带ZE135E-10F");
                dtResult.Rows.Add("003010707A0200000", "转台ZE135E-10F");
                dtResult.Rows.Add("003010207A0200000", "转台ZE155E-10");
                dtResult.Rows.Add("003001517A0200000", "履带ZE200E-10/ZE200E-10s/ZE210Ei");
                dtResult.Rows.Add("003001507C0200000", "转台ZE200E-10");
                dtResult.Rows.Add("003001507B0200000", "转台ZE200E-10");
                dtResult.Rows.Add("003001507A0200000", "转台ZE200E-10");
                dtResult.Rows.Add("003021307A0200000", "转台ZE200E-10s");
                dtResult.Rows.Add("003011017A0200000", "履带ZE205E-10/ZE205E-10pro/ZE215E/ZE215E I2CN");
                dtResult.Rows.Add("003001307A0200000", "转台ZE205E-10");
                dtResult.Rows.Add("003001407B0200000", "转台ZE205E-10pro");
                dtResult.Rows.Add("003001407A0200000", "转台ZE205E-10pro");
                dtResult.Rows.Add("003001307B0200000", "转台ZE205E-10pro");
                dtResult.Rows.Add("003011707A0200001", "转台ZE215E");
                dtResult.Rows.Add("003011707A0200000", "转台ZE215E");
                dtResult.Rows.Add("003001607A0200001", "转台ZE215E I2CN");
                dtResult.Rows.Add("003001607A0200000", "转台ZE215E I2CN");
                dtResult.Rows.Add("003011817A0200000", "履带ZE215E-10/ZE220E-10/ZE220Ei");
                dtResult.Rows.Add("003011507A0200000", "转台ZE215E-10");
                dtResult.Rows.Add("003011607A0200000", "转台ZE220E-10");
                dtResult.Rows.Add("003021207A0200000", "转台ZE220EK-10s");
                dtResult.Rows.Add("003011817B0200000", "履带ZE220EK-10s");
                dtResult.Rows.Add("003012207A0200000", "转台ZE245E-10plus/ZE265E-10");
                dtResult.Rows.Add("003004917B0200000", "履带ZE245E-10plus");
                dtResult.Rows.Add("003012307A0200000", "转台ZE245E");
                dtResult.Rows.Add("003004917A0200000", "履带ZE245E");
                dtResult.Rows.Add("003012417A0200000", "履带ZE265E-10");
                dtResult.Rows.Add("003006117A0200000", "履带ZE330E-10/ZE335E");
                dtResult.Rows.Add("003006107A0200000", "转台ZE330E-10");
                dtResult.Rows.Add("003006207A0200000", "转台ZE335E");
                dtResult.Rows.Add("003024517A0200001", "履带ZE370E/ZE370E金矿版");
                dtResult.Rows.Add("003024507A0200000", "转台ZE370E/ZE370E金矿版");
                dtResult.Rows.Add("003024317A0200000", "履带ZE370E-10VC行走马达/ZE375Ek-10VC行走马达");
                dtResult.Rows.Add("003024307A0200001", "转台ZE370E-10VC行走马达/ZE370E-10VD行走马达/ZE375Ek-10VC行走马达/ZE375Ek-10VD行走马达");
                dtResult.Rows.Add("003024317B0200000", "履带ZE370E-10VD行走马达/ZE375Ek-10VD行走马达");
                dtResult.Rows.Add("003026107B0200000", "转台ZE210Ei/ZE220Ei");
                dtResult.Rows.Add("00000000000000000", "空吊具");
                MaterilaCodeBox.DataSource = dtResult;
                MaterilaCodeBox.DisplayMember = "FromAddrName";
                MaterilaCodeBox.ValueMember = "FromAddrCode";
            }
                

            #endregion 物料下拉

            #region 库存下拉
            if (function.Equals("1"))
            {
                DataTable DTable = new DataTable();
                DTable.Columns.Add("FromAddrCode", typeof(int));
                DTable.Columns.Add("FromAddrName", typeof(string));
                DTable.Rows.Add(0, "--不限--");
                DTable.Rows.Add(1, "巷道1");
                DTable.Rows.Add(2, "巷道2");
                DTable.Rows.Add(3, "巷道3");
                InventoryAreaCodeBox.DataSource = DTable;
                InventoryAreaCodeBox.DisplayMember = "FromAddrName";
                InventoryAreaCodeBox.ValueMember = "FromAddrCode";
            }
            if (function.Equals("3")|| function.Equals("4"))
            {
                DataTable DTable = new DataTable();
                DTable.Columns.Add("FromAddrCode", typeof(int));
                DTable.Columns.Add("FromAddrName", typeof(string));
                DTable.Rows.Add(0, "--不限--");
                DTable.Rows.Add(1, "巷道1");
                DTable.Rows.Add(2, "巷道2");
                DTable.Rows.Add(3, "巷道3");
                DTable.Rows.Add(4, "巷道4");
                InventoryAreaCodeBox.DataSource = DTable;
                InventoryAreaCodeBox.DisplayMember = "FromAddrName";
                InventoryAreaCodeBox.ValueMember = "FromAddrCode";
            }
            else if (function.Equals("2"))
            {
                DataTable DTable = new DataTable();
                DTable.Columns.Add("FromAddrCode", typeof(int));
                DTable.Columns.Add("FromAddrName", typeof(string));
                DTable.Rows.Add(0, "--不限--");
                DTable.Rows.Add(1, "巷道1");
                DTable.Rows.Add(2, "巷道2");
                DTable.Rows.Add(3, "巷道3");
                DTable.Rows.Add(4, "巷道4");
                DTable.Rows.Add(5, "巷道5");
                DTable.Rows.Add(6, "巷道6");
                InventoryAreaCodeBox.DataSource = DTable;
                InventoryAreaCodeBox.DisplayMember = "FromAddrName";
                InventoryAreaCodeBox.ValueMember = "FromAddrCode";
            }
            #endregion 库存下拉

            #region 颜色下拉
            DataTable ColorTable = new DataTable();
            ColorTable.Columns.Add("FromAddrCode", typeof(string));
            ColorTable.Columns.Add("FromAddrName", typeof(string));
            ColorTable.Rows.Add("--不限--", "--不限--");
            ColorTable.Rows.Add("1", "红");
            ColorTable.Rows.Add("2", "橙");
            ColorTable.Rows.Add("3", "黄");
            ColorTable.Rows.Add("4", "绿");
            ColorTable.Rows.Add("5", "青");
            ColorTable.Rows.Add("6", "蓝");
            ColorTable.Rows.Add("7", "紫");
            ColorTable.Rows.Add("8", "黑");
            ColorTable.Rows.Add("9", "白");
            ColorBox.DataSource = ColorTable;
            ColorBox.DisplayMember = "FromAddrName";
            ColorBox.ValueMember = "FromAddrCode";
            ColorBox.SelectedIndex = 0;
            #endregion 颜色下拉

            #region 路由下拉
            DataTable RouteTable = new DataTable();
            RouteTable.Columns.Add("FromAddrCode", typeof(string));
            RouteTable.Columns.Add("FromAddrName", typeof(string));
            RouteTable.Rows.Add("--不限--", "--不限--");
            RouteTable.Rows.Add("0", "正常");
            RouteTable.Rows.Add("1", "空过");
            RouteTable.Rows.Add("2", "整返");
            RouteBox.DataSource = RouteTable;
            RouteBox.DisplayMember = "FromAddrName";
            RouteBox.ValueMember = "FromAddrCode";
            RouteBox.SelectedIndex = 0;
            #endregion 路由下拉

            #region 类型下拉
            DataTable TypeTable = new DataTable();
            TypeTable.Columns.Add("FromAddrCode", typeof(string));
            TypeTable.Columns.Add("FromAddrName", typeof(string));
            if (function.Equals("1") || function.Equals("2"))
            {
                TypeTable.Rows.Add("--不限--", "--不限--");
                TypeTable.Rows.Add("00", "空车");
                TypeTable.Rows.Add("14", "动臂");
                TypeTable.Rows.Add("15", "斗杆");
                TypeBox.DataSource = TypeTable;
                TypeBox.DisplayMember = "FromAddrName";
                TypeBox.ValueMember = "FromAddrCode";
                TypeBox.SelectedIndex = 0;
            }
            else
            {
                TypeTable.Rows.Add("--不限--", "--不限--");
                TypeTable.Rows.Add("00", "空车");
                TypeTable.Rows.Add("17", "履带");
                TypeTable.Rows.Add("07", "转台");
                TypeBox.DataSource = TypeTable;
                TypeBox.DisplayMember = "FromAddrName";
                TypeBox.ValueMember = "FromAddrCode";
                TypeBox.SelectedIndex = 0;
            }
            
            #endregion 类型下拉

            #endregion 添加下拉

            #region 实时系统时间
            DgRealSysTimeValue = new PrintSysTime(PrintRealSysTime);

            //开始显示实时系统时间线程
            Thread printRealTimeThread = new Thread(StartPrintRealTime);
            printRealTimeThread.IsBackground = true;
            printRealTimeThread.Start();
            collectThreadList.Add(printRealTimeThread);
            #endregion 实时系统时间

            BtnSelect_Click(sender, e);
        }
        /// <summary>
        /// 生成DataGridView列
        /// </summary>
        private void GenerateDataGridViewColumns() 
        {
            uiDataGridView1.Columns[0].HeaderText = "巷道";
            uiDataGridView1.Columns[1].HeaderText = "吊具号";
            uiDataGridView1.Columns[2].HeaderText = "路由";
            uiDataGridView1.Columns[3].HeaderText = "类型";
            uiDataGridView1.Columns[4].HeaderText = "颜色";
            uiDataGridView1.Columns[5].HeaderText = "SN";
            uiDataGridView1.Columns[6].HeaderText = "物料";
            gridHdl._dbgrid = uiDataGridView1;
            gridHdl.GenerateBaseDataGridView();
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelect_Click(object sender, EventArgs e)
        {
            #region 物料信息查询
            if(function.Equals("1")|| function.Equals("2"))
            {
                string strJsonArmCacheRealValue = rdsReal.GetStrValue(strRedisKeyRealValue1);
                string strJsonArmNeedRealValue = rdsReal.GetStrValue(strRedisKeyRealValue2);
                //读取到的Json值反序列化
                if (!String.IsNullOrEmpty(strJsonArmCacheRealValue))
                {
                    cacheJsonMaterialInfos = JsonConvert.DeserializeObject<List<List<JsonMaterialInfo>>>(strJsonArmCacheRealValue);
                    cacheJsonMaterialInfos1 = cacheJsonMaterialInfos[0];
                    cacheJsonMaterialInfos2 = cacheJsonMaterialInfos[1];
                    cacheJsonMaterialInfos3 = cacheJsonMaterialInfos[2];
                    //cacheJsonMaterialInfos4 = cacheJsonMaterialInfos[3];
                }
                if (!String.IsNullOrEmpty(strJsonArmNeedRealValue))
                {
                    needJsonMaterialInfos = JsonConvert.DeserializeObject<List<List<JsonMaterialInfo>>>(strJsonArmNeedRealValue);
                    needJsonMaterialInfos1 = needJsonMaterialInfos[0];
                    needJsonMaterialInfos2 = needJsonMaterialInfos[1];
                    needJsonMaterialInfos3 = needJsonMaterialInfos[2];
                    needJsonMaterialInfos4 = needJsonMaterialInfos[3];
                    needJsonMaterialInfos5 = needJsonMaterialInfos[4];
                    needJsonMaterialInfos6 = needJsonMaterialInfos[5];
                }
            }
            else if (function.Equals("3") || function.Equals("4"))
            {
                string strJsonArmCacheRealValue = rdsReal.GetStrValue(strRedisKeyRealValue4);
                string strJsonArmNeedRealValue = rdsReal.GetStrValue(strRedisKeyRealValue5);
                //读取到的Json值反序列化
                if (!String.IsNullOrEmpty(strJsonArmCacheRealValue))
                {
                    cacheJsonMaterialInfos = JsonConvert.DeserializeObject<List<List<JsonMaterialInfo>>>(strJsonArmCacheRealValue);
                    cacheJsonMaterialInfos1 = cacheJsonMaterialInfos[0];
                    cacheJsonMaterialInfos2 = cacheJsonMaterialInfos[1];
                    cacheJsonMaterialInfos3 = cacheJsonMaterialInfos[2];
                    cacheJsonMaterialInfos4 = cacheJsonMaterialInfos[3];
                }
                if (!String.IsNullOrEmpty(strJsonArmNeedRealValue))
                {
                    needJsonMaterialInfos = JsonConvert.DeserializeObject<List<List<JsonMaterialInfo>>>(strJsonArmNeedRealValue);
                    needJsonMaterialInfos1 = needJsonMaterialInfos[0];
                    needJsonMaterialInfos2 = needJsonMaterialInfos[1];
                    needJsonMaterialInfos3 = needJsonMaterialInfos[2];
                    needJsonMaterialInfos4 = needJsonMaterialInfos[3];
                }
            }
            #endregion 物料信息查询

            #region 物料信息加载
            ListMaterialCodeInfos.Clear();
            if (function.Equals("1"))
            {
                for (int i = 0; i < cacheJsonMaterialInfos1.Count; i++)
                {
                    JsonMaterialInfo = cacheJsonMaterialInfos1[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "1";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                for (int i = 0; i < cacheJsonMaterialInfos2.Count; i++)
                {
                    JsonMaterialInfo = cacheJsonMaterialInfos2[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "2";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                for (int i = 0; i < cacheJsonMaterialInfos3.Count; i++)
                {
                    JsonMaterialInfo = cacheJsonMaterialInfos3[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "3";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                //for (int i = 0; i < cacheJsonMaterialInfos4.Count; i++)
                //{
                //    JsonMaterialInfo = cacheJsonMaterialInfos4[i];
                //    MMaterialCodeInfo = new MMaterialCodeInfo();
                //    MMaterialCodeInfo.CacheAreaCode = "4";
                //    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                //    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                //    MMaterialCodeInfo.Type = JsonMaterialInfo.Type;
                //    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                //    MMaterialCodeInfo.Spare = JsonMaterialInfo.Spare;
                //    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                //    {
                //        MMaterialCodeInfo.MaterialCode = "空吊具";
                //    }
                //    else
                //    {
                //        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                //    }
                //    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                //    JsonMaterialInfo = null;
                //    MMaterialCodeInfo = null;
                //}
            }
            else if (function.Equals("2"))
            {
                for (int i = 0; i < needJsonMaterialInfos1.Count; i++)
                {
                    JsonMaterialInfo = needJsonMaterialInfos1[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "1";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                for (int i = 0; i < needJsonMaterialInfos2.Count; i++)
                {
                    JsonMaterialInfo = needJsonMaterialInfos2[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "2";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                for (int i = 0; i < needJsonMaterialInfos3.Count; i++)
                {
                    JsonMaterialInfo = needJsonMaterialInfos3[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "3";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                for (int i = 0; i < needJsonMaterialInfos4.Count; i++)
                {
                    JsonMaterialInfo = needJsonMaterialInfos4[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "4";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                for (int i = 0; i < needJsonMaterialInfos5.Count; i++)
                {
                    JsonMaterialInfo = needJsonMaterialInfos5[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "5";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                for (int i = 0; i < needJsonMaterialInfos6.Count; i++)
                {
                    JsonMaterialInfo = needJsonMaterialInfos6[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "6";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
            }
            else if (function.Equals("3"))
            {
                for (int i = 0; i < cacheJsonMaterialInfos1.Count; i++)
                {
                    JsonMaterialInfo = cacheJsonMaterialInfos1[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "1";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                for (int i = 0; i < cacheJsonMaterialInfos2.Count; i++)
                {
                    JsonMaterialInfo = cacheJsonMaterialInfos2[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "2";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                for (int i = 0; i < cacheJsonMaterialInfos3.Count; i++)
                {
                    JsonMaterialInfo = cacheJsonMaterialInfos3[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "3";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                for (int i = 0; i < cacheJsonMaterialInfos4.Count; i++)
                {
                    JsonMaterialInfo = cacheJsonMaterialInfos4[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "4";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
            }
            else if (function.Equals("4"))
            {
                for (int i = 0; i < needJsonMaterialInfos1.Count; i++)
                {
                    JsonMaterialInfo = needJsonMaterialInfos1[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "1";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                for (int i = 0; i < needJsonMaterialInfos2.Count; i++)
                {
                    JsonMaterialInfo = needJsonMaterialInfos2[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "2";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                for (int i = 0; i < needJsonMaterialInfos3.Count; i++)
                {
                    JsonMaterialInfo = needJsonMaterialInfos3[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "3";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
                for (int i = 0; i < needJsonMaterialInfos4.Count; i++)
                {
                    JsonMaterialInfo = needJsonMaterialInfos4[i];
                    MMaterialCodeInfo = new MMaterialCodeInfo();
                    MMaterialCodeInfo.CacheAreaCode = "4";
                    MMaterialCodeInfo.SlingNo = JsonMaterialInfo.SlingNo;
                    MMaterialCodeInfo.Route = PublicParams.proNoRoute.TryGetValue(JsonMaterialInfo.Route, out string Route) ? Route : JsonMaterialInfo.Route;
                    MMaterialCodeInfo.Type = PublicParams.proNoType.TryGetValue(JsonMaterialInfo.Type, out string Type) ? Type : JsonMaterialInfo.Type;
                    MMaterialCodeInfo.Colour = PublicParams.proNoColour.TryGetValue(JsonMaterialInfo.Colour.ToString(), out string colour) ? colour : JsonMaterialInfo.Colour;
                    MMaterialCodeInfo.Spare = JsonMaterialInfo.SN;
                    if (string.IsNullOrWhiteSpace(JsonMaterialInfo.MaterialCode))
                    {
                        MMaterialCodeInfo.MaterialCode = "空吊具";
                    }
                    else
                    {
                        MMaterialCodeInfo.MaterialCode = PublicParams.prodNoValToMsg.TryGetValue(JsonMaterialInfo.MaterialCode, out string MaterialCode) ? MaterialCode : JsonMaterialInfo.MaterialCode;
                    }
                    ListMaterialCodeInfos.Add(MMaterialCodeInfo);
                    JsonMaterialInfo = null;
                    MMaterialCodeInfo = null;
                }
            }

            #endregion 物料信息加载

            #region 查询字符串
            string strSql = "";
            strSql += (InventoryAreaCodeBox.SelectedIndex == 0) ? null : " " + "CacheAreaCode='" + InventoryAreaCodeBox.SelectedValue + "'";//定义查询条件（库存区号）
            string strSql2 = string.IsNullOrEmpty(SlingNoBox.Text) ? null : "SlingNo='" + SlingNoBox.Text + "'";      //定义查询条件（吊具号）
            if (!string.IsNullOrEmpty(strSql) && !string.IsNullOrEmpty(strSql2))
            {
                strSql += " AND " + strSql2;
            }
            else if (!string.IsNullOrEmpty(strSql2))
            {
                strSql += strSql2;
            }
            string strSql3 = (RouteBox.SelectedIndex == 0) ? null : " " + "Route='" + RouteBox.SelectedText + "'";//定义查询条件（路由）
            if (!string.IsNullOrEmpty(strSql) && !string.IsNullOrEmpty(strSql3))
            {
                strSql += " AND" + strSql3;
            }
            else if (!string.IsNullOrEmpty(strSql3))
            {
                strSql += strSql3;
            }
            string strSql4 = (TypeBox.SelectedIndex == 0) ? null : " " + "Type='" + TypeBox.SelectedValue + "'";//定义查询条件（类型）
            if (!string.IsNullOrEmpty(strSql) && !string.IsNullOrEmpty(strSql4))
            {
                strSql += " AND" + strSql4;
            }
            else
            {
                strSql += strSql4;
            }
            string strSql5 = (ColorBox.SelectedIndex == 0) ? null : " " + "Colour='" + ColorBox.SelectedText + "'";//定义查询条件（颜色）
            if (!string.IsNullOrEmpty(strSql) && !string.IsNullOrEmpty(strSql5))
            {
                strSql += " AND" + strSql5;
            }
            else if (!string.IsNullOrEmpty(strSql5))
            {
                strSql += strSql5;
            }
            /*string strSql6 = (string.IsNullOrEmpty(SNBox.Text.Trim()) ? null : " " + "Spare='" + SNBox.Text.Trim() + "'" );//SN
            if (!string.IsNullOrEmpty(strSql) && !string.IsNullOrEmpty(strSql6))
            {
                strSql += " AND" + strSql6;
            }
            else
            {
                strSql += strSql6;
            }*/
            string strSql7 = (MaterilaCodeBox.SelectedIndex == 0) ? null : " " + "MaterialCode='" + MaterilaCodeBox.SelectedText + "'";//（物料类型）
            if (!string.IsNullOrEmpty(strSql) && !string.IsNullOrEmpty(strSql7))
            {
                strSql += " AND" + strSql7;
            }
            else if (!string.IsNullOrEmpty(strSql7))
            {
                strSql += strSql7;
            }
            #endregion 查询字符串

            dTable = DataTableHelpe.ToDataTable(ListMaterialCodeInfos);//获取DataTable所有数据，准备进行查询
            if (!string.IsNullOrEmpty(strSql))
            {
                DataRow[] dtRow = dTable.Select(strSql);//根据查询条件，筛选出所有满足条件的列
                DataTable dtNew = dTable.Clone();//克隆与原表结构相同的新表(不包括数据)
                foreach (DataRow item in dtRow)//把满足条件的所有列赛到新表中
                {
                    dtNew.ImportRow(item);
                }
                if (dtNew != null)
                {
                    uiDataGridView1.DataSource = dtNew;
                    GenerateDataGridViewColumns();
                }
            }
            else
            {
                uiDataGridView1.DataSource = dTable;
                GenerateDataGridViewColumns();
            }
        }

        /// <summary>
        /// 鼠标按钮按下时发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvJobOrderInfo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.RowIndex >= 0)
                {
                    MouseSelectedRow = e.RowIndex;

                    uiDataGridView1.ClearSelection();
                    uiDataGridView1.Rows[e.RowIndex].Selected = true;
                    if (uiDataGridView1.Rows.Count > 0)
                    {
                        string sel = uiDataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString().Trim();
                        uiPage.ShowSuccessTip("已选择吊具号" + sel);
                    }
                }
            }
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            #region 检查是否未选择
            if (InventoryAreaCodeBox.SelectedIndex == 0)
            {
                uiPage.ShowWarningDialog("未选择库存区号");
                return;
            }
            if (string.IsNullOrEmpty(SlingNoBox.Text))
            {
                uiPage.ShowWarningDialog("未选择吊具号");
                return;
            }
            if (RouteBox.SelectedIndex == 0)
            {
                uiPage.ShowWarningDialog("未选择路由");
                return;
            }
            /*if (string.IsNullOrEmpty(SNBox.Text))
            {
                uiPage.ShowWarningDialog("未填写SN");
                return;
            }*/
            if (TypeBox.SelectedIndex == 0)
            {
                uiPage.ShowWarningDialog("未选择类型");
                return;
            }
            if (ColorBox.SelectedIndex == 0)
            {
                uiPage.ShowWarningDialog("未选择颜色");
                return;
            }
            if (MaterilaCodeBox.SelectedIndex == 0)
            {
                uiPage.ShowWarningDialog("未选择物料编码");
                return;
            }
            #endregion 检查是否未选择

            #region 将物料添加到所选的末尾位置
            DialogResult dgRst = MessageBox.Show(this, "您确认要添加物料?", "警告", MessageBoxButtons.OKCancel);
            if (dgRst == DialogResult.OK)
            {
                int CacheAreaCode = Convert.ToInt32(InventoryAreaCodeBox.SelectedIndex);//获得库存区号
                string SlingNo = SlingNoBox.Text;//获得吊具号
                if (function.Equals("1")|| function.Equals("3"))
                {
                    object obj = this.GetType().GetField("cacheJsonMaterialInfos" + CacheAreaCode.ToString(), System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    List<JsonMaterialInfo> cacheJsonMaterialInfos = (List<JsonMaterialInfo>)obj;
                    JsonMaterialInfo = new JsonMaterialInfo();
                    JsonMaterialInfo.SlingNo = SlingNoBox.Text;
                    JsonMaterialInfo.Route = RouteBox.SelectedValue.ToString();
                    JsonMaterialInfo.Type = TypeBox.SelectedValue.ToString();
                    JsonMaterialInfo.Colour = ColorBox.SelectedValue.ToString();
                    JsonMaterialInfo.SN = DateTime.Now.ToString("yyyyMMddHHmmss");
                    JsonMaterialInfo.MaterialCode = MaterilaCodeBox.SelectedValue.ToString();

                    cacheJsonMaterialInfos.Add(JsonMaterialInfo);//添加到库存尾部
                    //uiPage.ShowWarningDialog("增加成功!");
                    JsonMaterialInfo = null;
                }
                else if (function.Equals("2") || function.Equals("4"))
                {
                    object obj = this.GetType().GetField("needJsonMaterialInfos" + CacheAreaCode.ToString(), System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    List<JsonMaterialInfo> needJsonMaterialInfos = (List<JsonMaterialInfo>)obj;
                    JsonMaterialInfo = new JsonMaterialInfo();
                    JsonMaterialInfo.SlingNo = SlingNoBox.Text;
                    JsonMaterialInfo.Route = RouteBox.SelectedValue.ToString();
                    JsonMaterialInfo.Type = TypeBox.SelectedValue.ToString();
                    JsonMaterialInfo.Colour = ColorBox.SelectedValue.ToString();
                    JsonMaterialInfo.SN = DateTime.Now.ToString("yyyyMMddHHmmss");
                    JsonMaterialInfo.MaterialCode = MaterilaCodeBox.SelectedValue.ToString();

                    needJsonMaterialInfos.Add(JsonMaterialInfo);//添加到库存尾部
                    //uiPage.ShowWarningDialog("增加成功!");
                    JsonMaterialInfo = null;
                }

                SaveRedisInfos();
                Emptying();
                BtnSelect_Click(sender, e);
            }
            #endregion 将所选物料添加到末尾位置
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string message;
            if (MouseSelectedRow >= 0)
            {
                message = "您确认要删除吊具号为{0}的物料信息!";
            }
            else
            {
                message = "未选择要删除的物料!";
                return;
            }
            string SlingNo = uiDataGridView1.Rows[MouseSelectedRow].Cells[1].Value.ToString().Trim();//获得吊具号
            DialogResult dgRst = MessageBox.Show(this, String.Format(message, SlingNo), "警告", MessageBoxButtons.OKCancel);
            if (dgRst == DialogResult.OK)
            {
                if (function.Equals("1") || function.Equals("3"))
                {
                    int CacheAreaCode = Convert.ToInt32(uiDataGridView1.Rows[MouseSelectedRow].Cells[0].Value.ToString().Trim());//获得库存区号
                    object obj = this.GetType().GetField("cacheJsonMaterialInfos" + CacheAreaCode.ToString(), System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    List<JsonMaterialInfo> cacheJsonMaterialInfos = (List<JsonMaterialInfo>)obj;

                    List<string> listSlingNo = new List<string>();//全是选中的那个库的吊具号
                    for (int i = 0; i < cacheJsonMaterialInfos.Count; i++)
                    {
                        listSlingNo.Add(cacheJsonMaterialInfos[i].SlingNo);
                    }
                    int SlingNoIndex = listSlingNo.IndexOf(SlingNo);//根据吊具号获取在库存中的位置
                    if (SlingNoIndex == -1)
                    {
                        uiPage.ShowWarningDialog("删除失败!");
                        return;
                    }
                    cacheJsonMaterialInfos.RemoveAt(SlingNoIndex);//删除指定位置的元素
                    //uiPage.ShowWarningDialog("删除成功!");
                    SaveRedisInfos();
                    FrmMaterialSelect_Load(sender, e);
                }
                else if (function.Equals("2") || function.Equals("4"))
                {
                    int CacheAreaCode = Convert.ToInt32(uiDataGridView1.Rows[MouseSelectedRow].Cells[0].Value.ToString().Trim());//获得库存区号
                    object obj = this.GetType().GetField("needJsonMaterialInfos" + CacheAreaCode.ToString(), System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    List<JsonMaterialInfo> needJsonMaterialInfos = (List<JsonMaterialInfo>)obj;

                    List<string> listSlingNo = new List<string>();//全是选中的那个库的吊具号
                    for (int i = 0; i < needJsonMaterialInfos.Count; i++)
                    {
                        listSlingNo.Add(needJsonMaterialInfos[i].SlingNo);
                    }
                    int SlingNoIndex = listSlingNo.IndexOf(SlingNo);//根据吊具号获取在库存中的位置
                    if (SlingNoIndex == -1)
                    {
                        uiPage.ShowWarningDialog("删除失败!");
                        return;
                    }
                    needJsonMaterialInfos.RemoveAt(SlingNoIndex);//删除指定位置的元素
                    //uiPage.ShowWarningDialog("删除成功!");
                    SaveRedisInfos();
                    FrmMaterialSelect_Load(sender, e);
                }
            }
        }
        /// <summary>
        /// 更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string message;
            if (MouseSelectedRow >= 0)
            {
                message = "您确认要更改吊具号为{0}的物料信息!";
            }
            else
            {
                message = "未选择要删除的物料!";
                return;
            }
            string SlingNo = uiDataGridView1.Rows[MouseSelectedRow].Cells[1].Value.ToString().Trim();//获得吊具号
            DialogResult dgRst = MessageBox.Show(this, String.Format(message, SlingNo), "警告", MessageBoxButtons.OKCancel);
            if (dgRst == DialogResult.OK)
            {
                if (function.Equals("1") || function.Equals("3"))
                {
                    int CacheAreaCode = Convert.ToInt32(uiDataGridView1.Rows[MouseSelectedRow].Cells[0].Value.ToString().Trim());//获得库存区号
                    object obj = this.GetType().GetField("cacheJsonMaterialInfos" + CacheAreaCode.ToString(), System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    List<JsonMaterialInfo> cacheJsonMaterialInfos = (List<JsonMaterialInfo>)obj;//要改的库
                    List<string> listSlingNo = new List<string>();//全是选中的那个库的吊具号
                    for (int i = 0; i < cacheJsonMaterialInfos.Count; i++)
                    {
                        listSlingNo.Add(cacheJsonMaterialInfos[i].SlingNo);
                    }
                    int SlingNoIndex = listSlingNo.IndexOf(SlingNo);//根据吊具号获取在库存中的位置
                    JsonMaterialInfo = new JsonMaterialInfo();

                    JsonMaterialInfo.SlingNo = string.IsNullOrEmpty(SlingNoBox.Text)? cacheJsonMaterialInfos[SlingNoIndex].SlingNo : SlingNoBox.Text;
                    JsonMaterialInfo.Route = RouteBox.SelectedIndex == 0 ? cacheJsonMaterialInfos[SlingNoIndex].Route : RouteBox.SelectedValue.ToString();
                    JsonMaterialInfo.Type = TypeBox.SelectedIndex == 0 ? cacheJsonMaterialInfos[SlingNoIndex].Type : TypeBox.SelectedValue.ToString();
                    JsonMaterialInfo.Colour = ColorBox.SelectedIndex == 0 ? cacheJsonMaterialInfos[SlingNoIndex].Colour : ColorBox.SelectedValue.ToString();
                    JsonMaterialInfo.SN = DateTime.Now.ToString("yyyyMMddHHmmss");
                    JsonMaterialInfo.MaterialCode = MaterilaCodeBox.SelectedIndex == 0 ? cacheJsonMaterialInfos[SlingNoIndex].MaterialCode : MaterilaCodeBox.SelectedValue.ToString();
                    if (SlingNoIndex == -1)
                    {
                        uiPage.ShowWarningDialog("修改失败!");
                        return;
                    }
                    cacheJsonMaterialInfos.RemoveAt(SlingNoIndex);//删除原来的
                    cacheJsonMaterialInfos.Insert(SlingNoIndex, JsonMaterialInfo);//添加新的
                    //uiPage.ShowWarningDialog("修改成功!");
                }
                else if (function.Equals("2") || function.Equals("4"))
                {
                    int CacheAreaCode = Convert.ToInt32(uiDataGridView1.Rows[MouseSelectedRow].Cells[0].Value.ToString().Trim());//获得库存区号
                    object obj = this.GetType().GetField("needJsonMaterialInfos" + CacheAreaCode.ToString(), System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    List<JsonMaterialInfo> needJsonMaterialInfos = (List<JsonMaterialInfo>)obj;//要改的库
                    List<string> listSlingNo = new List<string>();//全是选中的那个库的吊具号
                    for (int i = 0; i < needJsonMaterialInfos.Count; i++)
                    {
                        listSlingNo.Add(needJsonMaterialInfos[i].SlingNo);
                    }
                    int SlingNoIndex = listSlingNo.IndexOf(SlingNo);//根据吊具号获取在库存中的位置
                    JsonMaterialInfo = new JsonMaterialInfo();
                    JsonMaterialInfo.SlingNo = string.IsNullOrEmpty(SlingNoBox.Text) ? needJsonMaterialInfos[SlingNoIndex].SlingNo : SlingNoBox.Text;
                    JsonMaterialInfo.Route = RouteBox.SelectedIndex == 0 ? needJsonMaterialInfos[SlingNoIndex].Route : RouteBox.SelectedValue.ToString();
                    JsonMaterialInfo.Type = TypeBox.SelectedIndex == 0 ? needJsonMaterialInfos[SlingNoIndex].Type : TypeBox.SelectedValue.ToString();
                    JsonMaterialInfo.Colour = ColorBox.SelectedIndex == 0 ? needJsonMaterialInfos[SlingNoIndex].Colour : ColorBox.SelectedValue.ToString();
                    JsonMaterialInfo.SN = DateTime.Now.ToString("yyyyMMddHHmmss");
                    JsonMaterialInfo.MaterialCode = MaterilaCodeBox.SelectedIndex == 0 ? needJsonMaterialInfos[SlingNoIndex].MaterialCode : MaterilaCodeBox.SelectedValue.ToString();
                    if (SlingNoIndex == -1)
                    {
                        uiPage.ShowWarningDialog("修改失败!");
                        return;
                    }
                    needJsonMaterialInfos.RemoveAt(SlingNoIndex);//删除原来的
                    needJsonMaterialInfos.Insert(SlingNoIndex, JsonMaterialInfo);//添加新的
                    //uiPage.ShowWarningDialog("修改成功!");
                }

                JsonMaterialInfo = null;
                SaveRedisInfos();
                Emptying();//清空选择和索引
                BtnSelect_Click(sender, e);//重新查询加载
            }
            
        }
        /// <summary>
        /// 插入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            #region 检查是否未选择
            if (uiDataGridView1.Rows.Count == 0)
            {
                uiPage.ShowWarningDialog("未选择物料");
                return;
            }
            if (string.IsNullOrEmpty(SlingNoBox.Text))
            {
                uiPage.ShowWarningDialog("未选择吊具号");
                return;
            }
            if (RouteBox.SelectedIndex == 0)
            {
                uiPage.ShowWarningDialog("未选择路由");
                return;
            }
            /*if (string.IsNullOrEmpty(SNBox.Text))
            {
                uiPage.ShowWarningDialog("未输入SN");
                return;
            }
            if (TypeBox.SelectedIndex == 0)
            {
                uiPage.ShowWarningDialog("未选择类型");
                return;
            }*/
            if (ColorBox.SelectedIndex == 0)
            {
                uiPage.ShowWarningDialog("未选择物料");
                return;
            }
            if (MaterilaCodeBox.SelectedIndex == 0)
            {
                uiPage.ShowWarningDialog("未选择物料编码");
                return;
            }
            #endregion 检查是否未选择

            #region 物料插入

            string message;
            if (MouseSelectedRow >= 0)
            {
                message = "您确认要添加物料到所选位置?";
            }
            else
            {
                MessageBox.Show(this, "您未选着要插入物料的位置", "警告");
                return;
            }
            DialogResult dgRst = MessageBox.Show(this, message, "警告", MessageBoxButtons.OKCancel);
            if (dgRst == DialogResult.OK)
            {
                if (function.Equals("1") || function.Equals("3"))
                {
                    int CacheAreaCode = Convert.ToInt32(uiDataGridView1.Rows[MouseSelectedRow].Cells[0].Value.ToString().Trim());//获得库存区号
                    string SlingNo = uiDataGridView1.Rows[MouseSelectedRow].Cells[1].Value.ToString().Trim();//获得吊具号
                    object obj = this.GetType().GetField("cacheJsonMaterialInfos" + CacheAreaCode.ToString(), System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    List<JsonMaterialInfo> cacheJsonMaterialInfos = (List<JsonMaterialInfo>)obj;
                    JsonMaterialInfo = new JsonMaterialInfo();
                    JsonMaterialInfo.SlingNo = SlingNoBox.Text;
                    JsonMaterialInfo.Route = RouteBox.SelectedValue.ToString();
                    JsonMaterialInfo.Type = TypeBox.SelectedValue.ToString();
                    JsonMaterialInfo.Colour = ColorBox.SelectedValue.ToString();
                    JsonMaterialInfo.SN = DateTime.Now.ToString("yyyyMMddHHmmss");
                    JsonMaterialInfo.MaterialCode = MaterilaCodeBox.SelectedValue.ToString();

                    List<string> listSlingNo = new List<string>();//全是选中的那个库的吊具号
                    for (int i = 0; i < cacheJsonMaterialInfos.Count; i++)
                    {
                        listSlingNo.Add(cacheJsonMaterialInfos[i].SlingNo);
                    }
                    int SlingNoIndex = listSlingNo.IndexOf(SlingNo);//根据吊具号获取在库存中的位置
                    if (SlingNoIndex == -1)
                    {
                        uiPage.ShowWarningDialog("插入失败!");
                        return;
                    }
                    cacheJsonMaterialInfos.Insert(SlingNoIndex, JsonMaterialInfo);//添加到指定位置之前
                    //uiPage.ShowWarningDialog("插入成功!");
                }
                else if (function.Equals("2") || function.Equals("4"))
                {
                    int CacheAreaCode = Convert.ToInt32(uiDataGridView1.Rows[MouseSelectedRow].Cells[0].Value.ToString().Trim());//获得库存区号
                    string SlingNo = uiDataGridView1.Rows[MouseSelectedRow].Cells[1].Value.ToString().Trim();//获得吊具号
                    object obj = this.GetType().GetField("needJsonMaterialInfos" + CacheAreaCode.ToString(), System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).GetValue(this);
                    List<JsonMaterialInfo> needJsonMaterialInfos = (List<JsonMaterialInfo>)obj;
                    JsonMaterialInfo = new JsonMaterialInfo();
                    JsonMaterialInfo.SlingNo = SlingNoBox.Text;
                    JsonMaterialInfo.Route = RouteBox.SelectedValue.ToString();
                    JsonMaterialInfo.Type = TypeBox.SelectedValue.ToString();
                    JsonMaterialInfo.Colour = ColorBox.SelectedValue.ToString();
                    JsonMaterialInfo.SN = DateTime.Now.ToString("yyyyMMddHHmmss");
                    JsonMaterialInfo.MaterialCode = MaterilaCodeBox.SelectedValue.ToString();

                    List<string> listSlingNo = new List<string>();//全是选中的那个库的吊具号
                    for (int i = 0; i < needJsonMaterialInfos.Count; i++)
                    {
                        listSlingNo.Add(needJsonMaterialInfos[i].SlingNo);
                    }
                    int SlingNoIndex = listSlingNo.IndexOf(SlingNo);//根据吊具号获取在库存中的位置
                    if (SlingNoIndex == -1)
                    {
                        uiPage.ShowWarningDialog("插入失败!");
                        return;
                    }
                    needJsonMaterialInfos.Insert(SlingNoIndex, JsonMaterialInfo);//添加到指定位置之前
                    //uiPage.ShowWarningDialog("插入成功!");
                }

                JsonMaterialInfo = null;
                SaveRedisInfos();
                Emptying();
                FrmMaterialSelect_Load(sender, e);
            }

            #endregion 插入物料
        }
        /// <summary>
        /// 请求更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFunDes_Click(object sender, EventArgs e)
        {
            //uiPage.ShowAskDialog("添加：即添加到库存区的末尾；\n插入：即插入到所选物料位置之前\n修改：即修改物料信息\n查询：即按条件查询物料的信息");
            bool bRequest = bSelectInfo.SetRequest(Convert.ToInt32(function), 1);
            if (bRequest)
            {
                uiPage.ShowAskDialog("已发送请求更改");
            }
            else
            {
                uiPage.ShowAskDialog("请求失败");
            }
        }


        /// <summary>
        /// 保存到Redis
        /// </summary>
        void SaveRedisInfos()
        {
            //保存前先询问
            //收到回复才能保存
            int iAgree = bSelectInfo.agreeRequest(Convert.ToInt32(function));
            if (iAgree != 2)
            {
                uiPage.ShowErrorTip("更改失败，超时或未同意，请重新请求更改");
                return;
            }

            #region 保存物料信息到Redis
            if (function.Equals("1"))
            {
                cacheJsonMaterialInfos.Clear();
                cacheJsonMaterialInfos.Add(cacheJsonMaterialInfos1);
                cacheJsonMaterialInfos.Add(cacheJsonMaterialInfos2);
                cacheJsonMaterialInfos.Add(cacheJsonMaterialInfos3);
                //cacheJsonMaterialInfos.Add(cacheJsonMaterialInfos4);
                string result = JsonConvert.SerializeObject(cacheJsonMaterialInfos, Formatting.Indented, jsetting);
                Task<bool> result1 = rdsReal.SetStrValueAsync(strRedisKeyRealValue1, result);
                bSelectInfo.UpdateRequest(1, 3);
            }
            else if (function.Equals("2"))
            {
                needJsonMaterialInfos.Clear();
                needJsonMaterialInfos.Add(needJsonMaterialInfos1);
                needJsonMaterialInfos.Add(needJsonMaterialInfos2);
                needJsonMaterialInfos.Add(needJsonMaterialInfos3);
                needJsonMaterialInfos.Add(needJsonMaterialInfos4);
                needJsonMaterialInfos.Add(needJsonMaterialInfos5);
                needJsonMaterialInfos.Add(needJsonMaterialInfos6);
                string result = JsonConvert.SerializeObject(needJsonMaterialInfos, Formatting.Indented, jsetting);
                Task<bool> result1 = rdsReal.SetStrValueAsync(strRedisKeyRealValue2, result);
                bSelectInfo.UpdateRequest(2, 3);
            }
            else if (function.Equals("3"))
            {
                cacheJsonMaterialInfos.Clear();
                cacheJsonMaterialInfos.Add(cacheJsonMaterialInfos1);
                cacheJsonMaterialInfos.Add(cacheJsonMaterialInfos2);
                cacheJsonMaterialInfos.Add(cacheJsonMaterialInfos3);
                cacheJsonMaterialInfos.Add(cacheJsonMaterialInfos4);
                string result = JsonConvert.SerializeObject(cacheJsonMaterialInfos, Formatting.Indented, jsetting);
                Task<bool> result1 = rdsReal.SetStrValueAsync(strRedisKeyRealValue4, result);
                bSelectInfo.UpdateRequest(3, 3);
            }
            else if (function.Equals("4"))
            {
                needJsonMaterialInfos.Clear();
                needJsonMaterialInfos.Add(needJsonMaterialInfos1);
                needJsonMaterialInfos.Add(needJsonMaterialInfos2);
                needJsonMaterialInfos.Add(needJsonMaterialInfos3);
                needJsonMaterialInfos.Add(needJsonMaterialInfos4);
                string result = JsonConvert.SerializeObject(needJsonMaterialInfos, Formatting.Indented, jsetting);
                Task<bool> result1 = rdsReal.SetStrValueAsync(strRedisKeyRealValue5, result);
                bSelectInfo.UpdateRequest(4, 3);
            }
            #endregion 保存物料信息到Redis
        }

        /// <summary>
        /// 功能执行完毕清空选择和索引
        /// </summary>
        private void Emptying()
        {
            InventoryAreaCodeBox.SelectedIndex = 0;
            RouteBox.SelectedIndex = 0;
            SlingNoBox.Text = null;
            TypeBox.SelectedIndex = 0;
            ColorBox.SelectedIndex = 0;
            //SNBox.Text = null;
            MaterilaCodeBox.SelectedIndex = 0;
        }

        private void SlingNoBox_TextChanged(object sender, EventArgs e)
        {
            if(SlingNoBox.Text != null)
            {
                if (SlingNoBox.Text.Length > 0)
                {
                    if(!int.TryParse(SlingNoBox.Text, out int sbgdfl))
                    {
                        SlingNoBox.Text = null;
                    }
                    if (sbgdfl == 0)
                    {
                        SlingNoBox.Text = null;
                    }
                }
                if(SlingNoBox.Text.Length > 3)
                {
                    SlingNoBox.Text = null;
                }
            }
        }
    }
}