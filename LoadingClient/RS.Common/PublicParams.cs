using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS.Model;

namespace RS.Common
{
    public class PublicParams
    {
        public static string G_SoftName;   //软件系统名称
        public static string G_LogoName;   //系统Logo名称
        public static readonly string _CurrentVision = "2.0.1.20181015";  //当前软件版本 


        public static MPMOperatorInfo G_OperatorInfo = new MPMOperatorInfo();
        public static MRTOperatorLoginInfo G_OpertorLoginInfo = new MRTOperatorLoginInfo();
        public static MPMPeopleInfo G_CallPeopleInfo = new MPMPeopleInfo();   //呼叫处理人员

        public static int G_DataSaveTime = 60;   //数据库保存时间  单位 天

        /// <summary>
        /// 产线编码(动臂斗杆线)
        /// </summary>
        public static string line_code1 = "TZ01";
        /// <summary>
        /// 产线编码(履带转台线)
        /// </summary>
        public static string line_code2 = "TZ02";

        public static bool TC1Stop1 { get; set; }
        public static bool TC1Stop2 { get; set; }
        public static bool TC1Stop3 { get; set; }
        public static bool TC1Stop4 { get; set; }
        public static bool TC1Stop5 { get; set; }
        public static bool TC2Stop1 { get; set; }
        public static bool TC2Stop2 { get; set; }
        public static bool TC2Stop3 { get; set; }
        public static bool TC2Stop4 { get; set; }
        public static bool TC2Stop5 { get; set; }
        public static bool TC3Stop1 { get; set; }
        public static bool TC3Stop2 { get; set; }
        public static bool TC3Stop3 { get; set; }
        public static bool TC3Stop4 { get; set; }
        public static bool TC3Stop5 { get; set; }
        public static bool TC3Stop6 { get; set; }
        public static bool TC3Stop7 { get; set; }
        public static bool TC4Stop1 { get; set; }
        public static bool TC4Stop2 { get; set; }
        public static bool TC4Stop3 { get; set; }
        public static bool TC4Stop4 { get; set; }
        public static bool TC4Stop5 { get; set; }
        public static bool TC4Stop6 { get; set; }
        public static bool TC4Stop7 { get; set; }

        /// <summary>
        /// 客户端信息
        /// </summary>
        public static MSTClientInfo G_ClientInfo = new MSTClientInfo();
        public static List<MSTStationInfo> G_StationInfoList = new List<MSTStationInfo>();

        /// <summary>
        /// 派工单信息传递变量
        /// </summary>
        public static List<MWOJobOrderInfo> G_JobOrderInfoList = null;

        /// <summary>
        /// 产品编码与工件型号对应表
        /// </summary>
        public static Dictionary<string, string> prodNoValToMsg = new Dictionary<string, string>();
        /// <summary>
        /// 路由编码与值对应表（路由 =0正常；=1空过；2整返 ）
        /// </summary>
        public static Dictionary<string, string> proNoRoute = new Dictionary<string, string>();
        /// <summary>
        /// 类型编码与值对应表
        /// </summary>
        public static Dictionary<string, string> proNoType = new Dictionary<string, string>();
        /// <summary>
        /// 颜色编码与值对应表
        /// </summary>
        public static Dictionary<string, string> proNoColour = new Dictionary<string, string>();
        /// <summary>
        /// 客户端编号与功能对应表
        /// </summary>
        public static Dictionary<string, string> proNoFunc = new Dictionary<string, string>();


        /// <summary>
        /// 当前派工单
        /// </summary>
        public static MWOJobOrderInfo G_CurrentS1JobOrderInfo = null;
        public static MWOJobOrderInfo G_CurrentS2JobOrderInfo = null;
        public static MWOJobOrderInfo G_CurrentS3JobOrderInfo = null;

        /// <summary>
        /// 协同登录
        /// </summary>
        public static List<MPMOperatorInfo> G_OperatorList = new List<MPMOperatorInfo>();                //操作员登录信息列表
        public static List<MRTOperatorLoginInfo> G_OperatorLoginInfoList = new List<MRTOperatorLoginInfo>(); //协同工作的登录人

        public static int CurrentWorkerNum = 0;

        public static string cgMaterialCode = "";

        public static string CurrentLdLocCode = "";

        #region Ftp连接变量
        public static string ftpServerIP= "10.8.8.64";
        public static string ftpRemotePath="";
        public static string ftpUserName = "anonymous";
        public static string ftpPassword= "";
        #endregion Ftp连接变量

        public static string G_NHalfStationNo = "BJZDBSX";
        public static string G_NHalfStationName = "臂架自动北上线";
        public static string G_SHalfStationNo = "BJZDNSX";
        public static string G_SHalfStationName = "臂架自动南上线";
        public static string G_NFullStationNo = "BJZDBXX";
        public static string G_NFullStationName = "臂架自动北下线";
        public static string G_SFullStationNo = "BJZDNXX";
        public static string G_SFullStationName = "臂架自动南下线";

        public static void GetStationTagInfo()
        {
            proNoRoute.Add("0", "正常");
            proNoRoute.Add("1", "空过");
            proNoRoute.Add("2", "整返");

            proNoType.Add("00", "空车");
            proNoType.Add("14", "动臂");
            proNoType.Add("15", "斗杆");
            proNoType.Add("17", "履带");
            proNoType.Add("07", "转台");

            proNoColour.Add("1", "红");
            proNoColour.Add("2", "橙");
            proNoColour.Add("3", "黄");
            proNoColour.Add("4", "绿");
            proNoColour.Add("5", "青");
            proNoColour.Add("7", "蓝");
            proNoColour.Add("8", "紫");
            proNoColour.Add("9", "黑");
            proNoColour.Add("10", "白");

            prodNoValToMsg.Add("003010314A0200000", "动臂ZE135E+D2:D48-10/ZE135E-10F/ZE135E-10土耳其");
            prodNoValToMsg.Add("003010307A0200000", "转台ZE135E-10/ZE135E-10土耳其");
            prodNoValToMsg.Add("003010017A0200001", "履带ZE135E-10/ZE135E-10土耳其/ZE155E-10");
            prodNoValToMsg.Add("003010015A0200000", "斗杆ZE135E-10/ZE135E-10土耳其/ZE155E-10");
            prodNoValToMsg.Add("003010717B0200000", "履带ZE135E-10F");
            prodNoValToMsg.Add("003010715A0200000", "斗杆ZE135E-10F");
            prodNoValToMsg.Add("003010707A0200000", "转台ZE135E-10F");
            prodNoValToMsg.Add("003010207A0200000", "转台ZE155E-10");
            prodNoValToMsg.Add("003010014A0200000", "动臂ZE155E-10");
            prodNoValToMsg.Add("003011514A0200000", "动臂ZE200E-10/ZE200E-10s/ZE205E-10/ZE205E-10pro/ZE215E/ZE215E I2CN/ZE215E-10/ZE220E-10/ZE220EK-10s/ZE210Ei/ZE220Ei");
            prodNoValToMsg.Add("003001517A0200000", "履带ZE200E-10/ZE200E-10s/ZE210Ei");
            prodNoValToMsg.Add("003001507C0200000", "转台ZE200E-10");
            prodNoValToMsg.Add("003001507B0200000", "转台ZE200E-10");
            prodNoValToMsg.Add("003001507A0200000", "转台ZE200E-10");
            prodNoValToMsg.Add("003001415A0200000", "斗杆ZE200E-10/ZE200E-10s/ZE205E-10pro/ZE220EK-10s/ZE210Ei/ZE220Ei");
            prodNoValToMsg.Add("003021307A0200000", "转台ZE200E-10s");
            prodNoValToMsg.Add("003011017A0200000", "履带ZE205E-10/ZE205E-10pro/ZE215E/ZE215E I2CN");
            prodNoValToMsg.Add("003011015A0200001", "斗杆ZE205E-10/ZE215E/ZE215E I2CN/ZE215E-10/ZE220E-10");
            prodNoValToMsg.Add("003001307A0200000", "转台ZE205E-10");
            prodNoValToMsg.Add("003001407B0200000", "转台ZE205E-10pro");
            prodNoValToMsg.Add("003001407A0200000", "转台ZE205E-10pro");
            prodNoValToMsg.Add("003001307B0200000", "转台ZE205E-10pro");
            prodNoValToMsg.Add("003011707A0200001", "转台ZE215E");
            prodNoValToMsg.Add("003011707A0200000", "转台ZE215E");
            prodNoValToMsg.Add("003001607A0200001", "转台ZE215E I2CN");
            prodNoValToMsg.Add("003001607A0200000", "转台ZE215E I2CN");
            prodNoValToMsg.Add("003011817A0200000", "履带ZE215E-10/ZE220E-10/ZE220Ei");
            prodNoValToMsg.Add("003011507A0200000", "转台ZE215E-10");
            prodNoValToMsg.Add("003011607A0200000", "转台ZE220E-10");
            prodNoValToMsg.Add("003021207A0200000", "转台ZE220EK-10s");
            prodNoValToMsg.Add("003011817B0200000", "履带ZE220EK-10s");
            prodNoValToMsg.Add("003012215A0200000", "斗杆ZE245E-10plus/ZE245E/ZE265E-10");
            prodNoValToMsg.Add("003012214A0200000", "动臂ZE245E-10plus/ZE265E-10");
            prodNoValToMsg.Add("003012207A0200000", "转台ZE245E-10plus/ZE265E-10");
            prodNoValToMsg.Add("003004917B0200000", "履带ZE245E-10plus");
            prodNoValToMsg.Add("003012307A0200000", "转台ZE245E");
            prodNoValToMsg.Add("003004917A0200000", "履带ZE245E");
            prodNoValToMsg.Add("003004814A0200000", "动臂ZE245E");
            prodNoValToMsg.Add("003012417A0200000", "履带ZE265E-10");
            prodNoValToMsg.Add("003006117A0200000", "履带ZE330E-10/ZE335E");
            prodNoValToMsg.Add("003006115A0200000", "斗杆ZE330E-10/ZE335E");
            prodNoValToMsg.Add("003006114A0200000", "动臂ZE330E-10/ZE335E");
            prodNoValToMsg.Add("003006107A0200000", "转台ZE330E-10");
            prodNoValToMsg.Add("003006207A0200000", "转台ZE335E");
            prodNoValToMsg.Add("003024517A0200001", "履带ZE370E/ZE370E金矿版");
            prodNoValToMsg.Add("003024515A0200000", "斗杆ZE370E/ZE370E金矿版");
            prodNoValToMsg.Add("003024514A0200000", "动臂ZE370E/ZE370E金矿版");
            prodNoValToMsg.Add("003024507A0200000", "转台ZE370E/ZE370E金矿版");
            prodNoValToMsg.Add("003024317A0200000", "履带ZE370E-10VC行走马达/ZE375Ek-10VC行走马达");
            prodNoValToMsg.Add("003024315A0200000", "斗杆ZE370E-10VC行走马达/ZE370E-10VD行走马达");
            prodNoValToMsg.Add("003024314A0200000", "动臂ZE370E-10VC行走马达/ZE370E-10VD行走马达/ZE375Ek-10VC行走马达/ZE375Ek-10VD行走马达");
            prodNoValToMsg.Add("003024307A0200001", "转台ZE370E-10VC行走马达/ZE370E-10VD行走马达/ZE375Ek-10VC行走马达/ZE375Ek-10VD行走马达");
            prodNoValToMsg.Add("003024317B0200000", "履带ZE370E-10VD行走马达/ZE375Ek-10VD行走马达");
            prodNoValToMsg.Add("003024415A0200000", "斗杆ZE375Ek-10VC行走马达/ZE375Ek-10VD行走马达");
            prodNoValToMsg.Add("003026107B0200000", "转台ZE210Ei/ZE220Ei");
            prodNoValToMsg.Add("00000000000000000", "空吊具");

            proNoFunc.Add("1001", "1");
            proNoFunc.Add("2001", "2");
            proNoFunc.Add("3001", "3");
            proNoFunc.Add("4001", "4");
        }
    }

    public class StatusTagInfo
    {
        private string _locaddrno;
        private string _locname;
        private string _readtagaddr;

        public StatusTagInfo(string locaddrno, string locname, string readtagaddr)
        {
            _locaddrno = locaddrno;
            _locname = locname;
            _readtagaddr = readtagaddr;
        }

        public string LocAddrNo
        {
            get { return _locaddrno; }
            set { _locaddrno = value; }
        } //物料地点位置号

        public string LocName
        {
            get { return _locname; }
            set { _locname = value; }
        }   //物料地点名

        public string ReadTagAddr
        {
            get { return _readtagaddr; }
            set { _readtagaddr = value; }
        }     //PLC读取点

    }
}


