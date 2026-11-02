using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RS.Model;
using RS.Common;
using RS.BLL;
using System.Net.NetworkInformation;
using RS.SQLServerDAL;
using Sunny.UI;

namespace LoadingClient
{
    public partial class ucTwoStationWeldClient : UserControl
    {
        BWOJobOrderInfo dalJobOrderInfo = new BWOJobOrderInfo();
        MWOJobOrderInfo cgCurrentS1JobOrderInfo = null;
        MWOJobOrderInfo cgCurrentS2JobOrderInfo = null;

        List<MWOJobOrderInfo> cgCurrentS1JobOrderInfoLst = null;
        List<MWOJobOrderInfo> cgCurrentS2JobOrderInfoLst = null;

        BBDWorkInStruction dalWorkInStruction = new BBDWorkInStruction();
        List<string> cgWorkInStructionFilePathList = null;
        private int cgCurrentFilePathIndex = 0;

        UIPage uiPage = new UIPage();

        public static Discrete.FUN_DATA_CB data_callback = new Discrete.FUN_DATA_CB(DataCallBack);

        static string RFIDIP = "";
        static int RFIDPort = 0;
        static int device = 0;
        int RWBank = 1; //EPC
        int Length = 13;

        //RFID写入结果展示
        private delegate void PrintRfidResultInfoCallBack(string str);
        private PrintRfidResultInfoCallBack MsgRfidResultInfoPrint;

        public ucTwoStationWeldClient()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            SetInitInfo();  //查询、设置、展示初始化信息
            MsgRfidResultInfoPrint = new PrintRfidResultInfoCallBack(PrintRfidResultInfo);
        }

        /// <summary>
        /// 查询、设置、展示初始化信息
        /// </summary>
        private void SetInitInfo()
        {
            SetJobOrderInfo();  //设置派工单信息

            //GenerateDataGridViewColumns();
            //加载并显示关键物料信息
            PrintMainMaterialInfo();

            //初始展示工艺指导书
            InitPrintWorkInStruction();

        }

        /// <summary>
        /// 设置派工单信息
        /// </summary>
        private void SetJobOrderInfo()
        {
            if (PublicParams.G_StationInfoList != null && PublicParams.G_StationInfoList.Count > 1)
            {
                cgCurrentS1JobOrderInfoLst = dalJobOrderInfo.GetJobOrderInfoListByStationNo(PublicParams.G_StationInfoList[0].F_STATIONNO);
                cgCurrentS2JobOrderInfoLst = dalJobOrderInfo.GetJobOrderInfoListByStationNo(PublicParams.G_StationInfoList[1].F_STATIONNO);

                if (cgCurrentS1JobOrderInfoLst != null)
                {
                    if (cgCurrentS1JobOrderInfoLst.Count > 0)
                    {
                        cgCurrentS1JobOrderInfo = cgCurrentS1JobOrderInfoLst[0];
                    }
                    else
                    {
                        cgCurrentS1JobOrderInfo = null;
                    }
                }
                else
                {
                    cgCurrentS1JobOrderInfo = null;
                }

                if (cgCurrentS2JobOrderInfoLst != null)
                {
                    if (cgCurrentS2JobOrderInfoLst.Count > 0)
                    {
                        cgCurrentS2JobOrderInfo = cgCurrentS2JobOrderInfoLst[0];
                    }
                    else
                    {
                        cgCurrentS2JobOrderInfo = null;
                    }
                }
                else
                {
                    cgCurrentS2JobOrderInfo = null;
                }
            }
            if (cgCurrentS1JobOrderInfo != null)
            {
                lblS1JOBORDERNO.Text = cgCurrentS1JobOrderInfo.F_JOBORDERNO;
                lblS1PRODNAME.Text = cgCurrentS1JobOrderInfo.F_PRODNAME;
                lblS1JOBORDERQTY.Text = cgCurrentS1JobOrderInfo.F_JOBORDERQTY.ToString();
                string strS1JobFshedQty = cgCurrentS1JobOrderInfo.F_JOBFSHEDQTY.ToString();
                lblS1JOBFSHEDQTY.Text = string.IsNullOrEmpty(strS1JobFshedQty) ? "0" : strS1JobFshedQty;

                btnS1RfidWriteCode.Enabled = true;
                btnS1OpenWork.Enabled = true;
                btnS1FinishWork.Enabled = true;
            }
            else
            {
                btnS1RfidWriteCode.Enabled = false;
                btnS1OpenWork.Enabled = false;
                btnS1FinishWork.Enabled = false;

                lblS1JOBORDERNO.Text = "";
                lblS1PRODNAME.Text = "";
                lblS1JOBORDERQTY.Text = "";
                lblS1JOBFSHEDQTY.Text = "";
            }
            if (cgCurrentS2JobOrderInfo != null)
            {
                lblS2JOBORDERNO.Text = cgCurrentS2JobOrderInfo.F_JOBORDERNO;
                lblS2PRODNAME.Text = cgCurrentS2JobOrderInfo.F_PRODNAME;
                lblS2JOBORDERQTY.Text = cgCurrentS2JobOrderInfo.F_JOBORDERQTY.ToString();
                string strS2JobFshedQty = cgCurrentS2JobOrderInfo.F_JOBFSHEDQTY.ToString();
                lblS2JOBFSHEDQTY.Text = string.IsNullOrEmpty(strS2JobFshedQty) ? "0" : strS2JobFshedQty;

                btnS2RfidWriteCode.Enabled = true;
                btnS2OpenWork.Enabled = true;
                btnS2FinishWork.Enabled = true;
            }
            else
            {
                btnS2RfidWriteCode.Enabled = false;
                btnS2OpenWork.Enabled = false;
                btnS2FinishWork.Enabled = false;

                lblS2JOBORDERNO.Text = "";
                lblS2PRODNAME.Text = "";
                lblS2JOBORDERQTY.Text = "";
                lblS2JOBFSHEDQTY.Text = "";
            }
        }
        
        /// <summary>
        /// 一号机台RFID字符写入按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnS1RfidWriteCode_Click(object sender, EventArgs e)
        {
            if(uiPage.ShowAskDialog("您确认要给当前产品写码吗?"))
            {
                int result = Discrete.ConnectDev(ref device, data_callback, RFIDIP, RFIDPort);
                if (result == 1)
                {
                    string strTip = "正在写入" + cgCurrentS1JobOrderInfo.F_PRODNAME + "的RFID芯片编码...";
                    FrmWaitingBox f = new FrmWaitingBox((obj, args) =>
                    {
                        WriteValueToS1Rfid();
                    }, 120, strTip, true, false);
                    f.ShowDialog(this);
                }
                else
                {
                    uiPage.ShowErrorDialog(RFIDIP + ":" + "RFID连接失败,请检查客户端与RFID之间网络是否连通！");
                }
            }
        }
        /// <summary>
        /// 二号机台RFID字符写入按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnS2RfidWriteCode_Click(object sender, EventArgs e)
        {
            if (uiPage.ShowAskDialog("您确认要给当前产品写码吗?"))
            {
                int result = Discrete.ConnectDev(ref device, data_callback, RFIDIP, RFIDPort);
                if (result == 1)
                {
                    string strTip = "正在写入" + cgCurrentS2JobOrderInfo.F_PRODNAME + "的RFID芯片编码...";
                    FrmWaitingBox f = new FrmWaitingBox((obj, args) =>
                    {
                        WriteValueToS2Rfid();
                    }, 120, strTip, true, false);
                    f.ShowDialog(this);
                }
                else
                {
                    uiPage.ShowErrorDialog(RFIDIP + ":" + "RFID连接失败,请检查客户端与RFID之间网络是否连通！");
                }
            }
        }

        public static void DataCallBack(int hDevs, ref OutputInfoStruct outputInfo)
        {
            if (outputInfo.connect_exception > 0)//Network Excpetion
            {
                //networkException(hDevs, outputInfo);
            }
            else
            {
                //updateTagData(hDevs, outputInfo);
            }
        }

        /// <summary>
        /// 一号机台写RFID的EPC参数值
        /// </summary>
        private void WriteValueToS1Rfid()
        {
            FrmMessageBox frmMess = new FrmMessageBox();
            if (cgCurrentS1JobOrderInfo != null)
            {
                if (cgCurrentS1JobOrderInfo.F_PRODNO != null && cgCurrentS1JobOrderInfo.F_PRODNO.Trim() != "")
                {
                    string writeTemp = cgCurrentS1JobOrderInfo.F_PRODNO + DateTime.Now.ToString("yyyyMMddHHmmss");
                    string strTemp = ByteConvert.Str2HexStr(writeTemp);
                    byte[] writeResult = ByteConvert.ToByteByHexStr(strTemp);
                    int StartAdd = 1;

                    int result = Discrete.WriteTagData(device, (byte)RWBank, (byte)StartAdd, (byte)Length, writeResult);
                    if (result == 0)
                    {
                        frmMess.F_Status = 1;
                        frmMess.F_ProdName = cgCurrentS1JobOrderInfo.F_PRODNAME;
                        frmMess.ShowDialog();
                    }
                    else
                    {
                        frmMess.F_Status = 0;
                        frmMess.F_ProdName = cgCurrentS1JobOrderInfo.F_PRODNAME;
                        frmMess.ShowDialog();
                    }
                    Discrete.DisconnectDev(device);
                }
            }
            else
            {
                uiPage.ShowWarningDialog("您选择了无派工单工位，请重新选择派工单！");
            }
        }
        /// <summary>
        /// 二号机台写RFID的EPC参数值
        /// </summary>
        private void WriteValueToS2Rfid()
        {
            FrmMessageBox frmMess = new FrmMessageBox();
            if (cgCurrentS2JobOrderInfo != null)
            {
                if (cgCurrentS2JobOrderInfo.F_PRODNO != null && cgCurrentS2JobOrderInfo.F_PRODNO.Trim() != "")
                {
                    string writeTemp = cgCurrentS2JobOrderInfo.F_PRODNO + DateTime.Now.ToString("yyyyMMddHHmmss");
                    string strTemp = ByteConvert.Str2HexStr(writeTemp);
                    byte[] writeResult = ByteConvert.ToByteByHexStr(strTemp);
                    int StartAdd = 1;

                    int result = Discrete.WriteTagData(device, (byte)RWBank, (byte)StartAdd, (byte)Length, writeResult);
                    if (result == 0)
                    {
                        frmMess.F_Status = 1;
                        frmMess.F_ProdName = cgCurrentS2JobOrderInfo.F_PRODNAME;
                        frmMess.ShowDialog();
                    }
                    else
                    {
                        frmMess.F_Status = 0;
                        frmMess.F_ProdName = cgCurrentS2JobOrderInfo.F_PRODNAME;
                        frmMess.ShowDialog();
                    }
                    Discrete.DisconnectDev(device);
                }
            }
            else
            {
                uiPage.ShowWarningDialog("您选择了无派工单工位，请重新选择派工单！");
            }
        }

        #region 中间的左侧按钮事件

        /// <summary>
        /// 获取当前派工单中需要展示的工艺指导书文件路径列表
        /// </summary>
        public void GetCurrentWorkInStructionPathFileList(bool isLocalPic)
        {
            #region 第一个机台派工单工艺指导文件
            if (cgCurrentS1JobOrderInfo != null)
            {
                string s1ProdNo = "";
                string s1ProcessNo = "";
                s1ProcessNo = cgCurrentS1JobOrderInfo.F_PROCESSNO;
                s1ProdNo = cgCurrentS1JobOrderInfo.F_PRODNO;
                List<string> FolderPathList = dalWorkInStruction.GetWorkInStructionFolderPathList(s1ProdNo, s1ProcessNo);
                if (FolderPathList != null)
                {
                    if (FolderPathList.Count > 0)
                    {
                        if (cgWorkInStructionFilePathList == null)
                        {
                            cgWorkInStructionFilePathList = new List<string>();
                        }
                        for (int i = 0; i < FolderPathList.Count; i++)
                        {
                            string strPathFolder = FolderPathList[i].Trim();
                            if (strPathFolder != "")
                            {
                                string strPathFolderResult = Application.StartupPath + strPathFolder;

                                if (!isLocalPic)
                                {
                                    PublicParams.ftpRemotePath = strPathFolder.Remove(0, 1).Replace("\\", "/");

                                    #region FTP文件加载
                                    try
                                    {
                                        Ping objPingSender = new Ping();
                                        PingOptions objPinOptions = new PingOptions();
                                        objPinOptions.DontFragment = true;
                                        string data = "";
                                        byte[] buffer = Encoding.UTF8.GetBytes(data);
                                        int intTimeout = 200;
                                        PingReply objPinReply = objPingSender.Send(PublicParams.ftpServerIP, intTimeout, buffer, objPinOptions);
                                        string strInfo = objPinReply.Status.ToString();
                                        if (strInfo == "Success")
                                        {
                                            FtpWebInfo fweb = new FtpWebInfo(PublicParams.ftpServerIP, PublicParams.ftpRemotePath, PublicParams.ftpUserName, PublicParams.ftpPassword);
                                            string[] strFiles = fweb.GetFileList("");
                                            if (strFiles != null)
                                            {
                                                if (strFiles.Count() > 0)
                                                {
                                                    for (int k = 0; k < strFiles.Count(); k++)
                                                    {
                                                        fweb.Download(strPathFolderResult, strFiles[k]);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        ex.ToString();
                                    }
                                    #endregion FTP文件加载

                                }

                                FileHelper hlpFile = new FileHelper();
                                List<string> lstFileName = hlpFile.GetFileNamesByFolderPath(strPathFolderResult, "png");
                                if (lstFileName != null)
                                {
                                    if (lstFileName.Count > 0)
                                    {
                                        for (int j = 0; j < lstFileName.Count; j++)
                                        {
                                            cgWorkInStructionFilePathList.Add(lstFileName[j]);
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            #endregion 第一个机台派工单工艺指导文件

            #region 第二个机台派工单工艺指导文件
            if (cgCurrentS2JobOrderInfo != null)
            {
                string s2ProdNo = "";
                string s2ProcessNo = "";
                s2ProcessNo = cgCurrentS2JobOrderInfo.F_PROCESSNO;
                s2ProdNo = cgCurrentS2JobOrderInfo.F_PRODNO;
                List<string> FolderPathList = dalWorkInStruction.GetWorkInStructionFolderPathList(s2ProdNo, s2ProcessNo);
                if (FolderPathList != null)
                {
                    if (FolderPathList.Count > 0)
                    {
                        if (cgWorkInStructionFilePathList == null)
                        {
                            cgWorkInStructionFilePathList = new List<string>();
                        }
                        for (int i = 0; i < FolderPathList.Count; i++)
                        {
                            string strPathFolder = FolderPathList[i].Trim();
                            if (strPathFolder != "")
                            {
                                string strPathFolderResult = Application.StartupPath + strPathFolder;
                                if (!isLocalPic)
                                {
                                    PublicParams.ftpRemotePath = strPathFolder.Remove(0, 1).Replace("\\", "/");

                                    #region FTP文件加载
                                    try
                                    {
                                        Ping objPingSender = new Ping();
                                        PingOptions objPinOptions = new PingOptions();
                                        objPinOptions.DontFragment = true;
                                        string data = "";
                                        byte[] buffer = Encoding.UTF8.GetBytes(data);
                                        int intTimeout = 200;
                                        PingReply objPinReply = objPingSender.Send(PublicParams.ftpServerIP, intTimeout, buffer, objPinOptions);
                                        string strInfo = objPinReply.Status.ToString();
                                        if (strInfo == "Success")
                                        {
                                            FtpWebInfo fweb = new FtpWebInfo(PublicParams.ftpServerIP, PublicParams.ftpRemotePath, PublicParams.ftpUserName, PublicParams.ftpPassword);
                                            string[] strFiles = fweb.GetFileList("");
                                            if (strFiles != null)
                                            {
                                                if (strFiles.Count() > 0)
                                                {
                                                    for (int k = 0; k < strFiles.Count(); k++)
                                                    {
                                                        fweb.Download(strPathFolderResult, strFiles[k]);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        ex.ToString();
                                    }
                                    #endregion FTP文件加载

                                }

                                FileHelper hlpFile = new FileHelper();
                                List<string> lstFileName = hlpFile.GetFileNamesByFolderPath(strPathFolderResult, "png");
                                if (lstFileName != null)
                                {
                                    if (lstFileName.Count > 0)
                                    {
                                        for (int j = 0; j < lstFileName.Count; j++)
                                        {
                                            cgWorkInStructionFilePathList.Add(lstFileName[j]);
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }
            #endregion 第二个机台派工单工艺指导文件
        }

        /// <summary>
        /// 初始展示工艺指导书
        /// </summary>
        private void InitPrintWorkInStruction()
        {
            if (cgWorkInStructionFilePathList == null)
            {
                GetCurrentWorkInStructionPathFileList(false);
            }
            if (cgWorkInStructionFilePathList != null)
            {
                if (cgWorkInStructionFilePathList.Count > 0)
                {
                    cgCurrentFilePathIndex = 0;
                    OpenTechFileDialog(cgWorkInStructionFilePathList[cgCurrentFilePathIndex]);
                }
            }
        }

        /// <summary>
        /// 打开工艺指导书文件
        /// </summary>
        private void OpenTechFileDialog(string pathFile)
        {
            try
            {
                plView.BackgroundImage = Image.FromFile(pathFile);
            }
            catch
            {
                uiPage.ShowWarningDialog("工艺指导文件打开失败！");
            }
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if (cgWorkInStructionFilePathList != null)
            {
                if (cgWorkInStructionFilePathList.Count > 0)
                {
                    if (cgCurrentFilePathIndex > 0)
                    {
                        cgCurrentFilePathIndex -= 1;
                        OpenTechFileDialog(cgWorkInStructionFilePathList[cgCurrentFilePathIndex]);
                        if (cgCurrentFilePathIndex == 0)
                        {
                            btnPrevPage.Enabled = false;
                            btnNextPage.Enabled = true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (cgWorkInStructionFilePathList != null)
            {
                if (cgWorkInStructionFilePathList.Count > 0)
                {
                    int fileCount = cgWorkInStructionFilePathList.Count;
                    if (cgCurrentFilePathIndex < fileCount - 1 && cgCurrentFilePathIndex >= 0)
                    {
                        cgCurrentFilePathIndex += 1;
                        OpenTechFileDialog(cgWorkInStructionFilePathList[cgCurrentFilePathIndex]);
                        if (cgCurrentFilePathIndex == fileCount - 1)
                        {
                            btnPrevPage.Enabled = true;
                            btnNextPage.Enabled = false;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 信息更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfoUpdate_Click(object sender, EventArgs e)
        {
            SetJobOrderInfo();  //设置派工单信息

            //初始展示工艺指导书
            InitPrintWorkInStruction();

            //加载并显示关键物料信息
            PrintMainMaterialInfo();
        }
        /// <summary>
        /// 工单手动选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJobOrderChoice_Click(object sender, EventArgs e)
        {
            try
            {
                FrmJobOrderInfo frmOrderInfo = new FrmJobOrderInfo();
                if (frmOrderInfo.ShowDialog() == DialogResult.OK)
                {
                    cgCurrentS1JobOrderInfo = PublicParams.G_CurrentS1JobOrderInfo;

                    cgCurrentS2JobOrderInfo = PublicParams.G_CurrentS2JobOrderInfo;

                    SetCgJobOrderInfo();  //设置派工单信息
                    //加载并显示关键物料信息
                    PrintMainMaterialInfo();
                    //初始展示工艺指导书
                    InitPrintWorkInStruction();
                }
            }
            catch { }
        }

        /// <summary>
        /// 设置派工单信息
        /// </summary>
        private void SetCgJobOrderInfo()
        {
            if (cgCurrentS1JobOrderInfo != null)
            {
                lblS1JOBORDERNO.Text = cgCurrentS1JobOrderInfo.F_JOBORDERNO;
                lblS1PRODNAME.Text = cgCurrentS1JobOrderInfo.F_PRODNAME;
                lblS1JOBORDERQTY.Text = cgCurrentS1JobOrderInfo.F_JOBORDERQTY.ToString();
                lblS1JOBFSHEDQTY.Text = cgCurrentS1JobOrderInfo.F_JOBFSHEDQTY.ToString();

                btnS1RfidWriteCode.Enabled = true;
                btnS1OpenWork.Enabled = true;
                btnS1FinishWork.Enabled = true;
            }
            else
            {
                lblS1JOBORDERNO.Text = "";
                lblS1PRODNAME.Text = "";
                lblS1JOBORDERQTY.Text = "";
                lblS1JOBFSHEDQTY.Text = "";

                btnS1RfidWriteCode.Enabled = false;
                btnS1OpenWork.Enabled = false;
                btnS1FinishWork.Enabled = false;
            }
            if (cgCurrentS2JobOrderInfo != null)
            {
                lblS2JOBORDERNO.Text = cgCurrentS2JobOrderInfo.F_JOBORDERNO;
                lblS2PRODNAME.Text = cgCurrentS2JobOrderInfo.F_PRODNAME;
                lblS2JOBORDERQTY.Text = cgCurrentS2JobOrderInfo.F_JOBORDERQTY.ToString();
                lblS2JOBFSHEDQTY.Text = cgCurrentS2JobOrderInfo.F_JOBFSHEDQTY.ToString();

                btnS2RfidWriteCode.Enabled = true;
                btnS2OpenWork.Enabled = true;
                btnS2FinishWork.Enabled = true;
            }
            else
            {
                lblS2JOBORDERNO.Text = "";
                lblS2PRODNAME.Text = "";
                lblS2JOBORDERQTY.Text = "";
                lblS2JOBFSHEDQTY.Text = "";

                btnS2RfidWriteCode.Enabled = false;
                btnS2OpenWork.Enabled = false;
                btnS2FinishWork.Enabled = false;
            }
        }

        #endregion 中间的左侧按钮事件

        #region 中间的右侧按钮事件

        /// <summary>
        /// 一号机台开工报工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnS1OpenWork_Click(object sender, EventArgs e)
        {
            if(uiPage.ShowAskDialog("您确认要开工吗?"))
            {
                //string strJsonMsg = "";
                MESWorkSignal mWorkSignal = new MESWorkSignal();
                mWorkSignal.processPlanNo = cgCurrentS1JobOrderInfo.F_PLANNO;
                mWorkSignal.monoPartId = cgCurrentS1JobOrderInfo.F_MONOPARTID;
                string strOperator = "";
                for (int i = 0; i < PublicParams.G_OperatorList.Count; i++)
                {
                    strOperator += PublicParams.G_OperatorList[i].F_OPERATORID + ",";
                }
                mWorkSignal.startWorker = strOperator.Substring(0, strOperator.Length - 1);
                mWorkSignal.startWorkTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                mWorkSignal.finishQty = "0";

                ////将信息发送给后台
                //JsonSerializerSettings jsetting = new JsonSerializerSettings();
                //strJsonMsg = JsonConvert.SerializeObject(mWorkSignal, Formatting.Indented, jsetting);

                //WRMESWebService.ProviderIMSWebserviceImplService iMSWebService = new WRMESWebService.ProviderIMSWebserviceImplService();
                //iMSWebService.transferWorkSignal(strJsonMsg);
                //LogInfo.LogInfoInstance.WriteLogInfo(strJsonMsg, LogType.Information, "IMSToMESLog");

                SMESWorkInfo sdalWorkInfo = new SMESWorkInfo();
                if (!String.IsNullOrEmpty(mWorkSignal.monoPartId))
                {
                    if (!sdalWorkInfo.IsExistsWorkInfo(mWorkSignal.monoPartId, mWorkSignal.processPlanNo))
                    {
                        bool bResult = sdalWorkInfo.InsertWorkInfo(mWorkSignal);
                        if (bResult)
                        {
                            LogInfo.LogInfoInstance.WriteLogInfo("1号机台产品信息开工报工成功!", LogType.Information, "MESWorkSignalLog");
                            uiPage.ShowSuccessDialog("1号机台产品信息开工报工成功！");
                        }
                    }
                    else
                    {
                        LogInfo.LogInfoInstance.WriteLogInfo("该工单已经开工报工过，请刷新工单信息或手动选择工单信息!", LogType.Error, "MESWorkSignalLog");
                        uiPage.ShowWarningDialog("该工单已经开工报工过，请刷新工单信息或手动选择工单信息！");
                    }
                }
                else
                {
                    bool bResult = sdalWorkInfo.InsertBatchWorkInfo(mWorkSignal);
                    if (bResult)
                    {
                        LogInfo.LogInfoInstance.WriteLogInfo("1号机台产品信息开工报工成功!", LogType.Information, "MESWorkSignalLog");
                        uiPage.ShowSuccessDialog("1号机台产品信息开工报工成功！");
                    }
                }
            }
        }
        /// <summary>
        /// 二号机台开工报工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnS2OpenWork_Click(object sender, EventArgs e)
        {
            if (uiPage.ShowAskDialog("您确认要开工吗?"))
            {
                //string strJsonMsg = "";
                MESWorkSignal mWorkSignal = new MESWorkSignal();
                mWorkSignal.processPlanNo = cgCurrentS2JobOrderInfo.F_PLANNO;
                mWorkSignal.monoPartId = cgCurrentS2JobOrderInfo.F_MONOPARTID;
                string strOperator = "";
                for (int i = 0; i < PublicParams.G_OperatorList.Count; i++)
                {
                    strOperator += PublicParams.G_OperatorList[i].F_OPERATORID + ",";
                }
                mWorkSignal.startWorker = strOperator.Substring(0, strOperator.Length - 1);
                mWorkSignal.startWorkTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                mWorkSignal.finishQty = "0";

                ////将信息发送给后台
                //JsonSerializerSettings jsetting = new JsonSerializerSettings();
                //strJsonMsg = JsonConvert.SerializeObject(mWorkSignal, Formatting.Indented, jsetting);

                //WRMESWebService.ProviderIMSWebserviceImplService iMSWebService = new WRMESWebService.ProviderIMSWebserviceImplService();
                //iMSWebService.transferWorkSignal(strJsonMsg);
                //LogInfo.LogInfoInstance.WriteLogInfo(strJsonMsg, LogType.Information, "IMSToMESLog");

                SMESWorkInfo sdalWorkInfo = new SMESWorkInfo();
                if (!String.IsNullOrEmpty(mWorkSignal.monoPartId))
                {
                    if (!sdalWorkInfo.IsExistsWorkInfo(mWorkSignal.monoPartId, mWorkSignal.processPlanNo))
                    {
                        bool bResult = sdalWorkInfo.InsertWorkInfo(mWorkSignal);
                        if (bResult)
                        {
                            LogInfo.LogInfoInstance.WriteLogInfo("2号机台产品信息开工报工成功!", LogType.Information, "MESWorkSignalLog");
                            uiPage.ShowSuccessDialog("2号机台产品信息开工报工成功！");
                        }
                        else
                        {
                            LogInfo.LogInfoInstance.WriteLogInfo("该工单已经开工报工过，请刷新工单信息或手动选择工单信息!", LogType.Error, "MESWorkSignalLog");
                            uiPage.ShowWarningDialog("该工单已经开工报工过，请刷新工单信息或手动选择工单信息！");
                        }
                    }
                }
                else
                {
                    bool bResult = sdalWorkInfo.InsertBatchWorkInfo(mWorkSignal);
                    if (bResult)
                    {
                        LogInfo.LogInfoInstance.WriteLogInfo("2号机台产品信息开工报工成功!", LogType.Information, "MESWorkSignalLog");
                        uiPage.ShowSuccessDialog("2号机台产品信息开工报工成功！");
                    }
                }
            }
        }
        /// <summary>
        /// 一号机台完工报工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnS1FinishWork_Click(object sender, EventArgs e)
        {
            if (uiPage.ShowAskDialog("您确认要完工吗?"))
            {
                //string strJsonMsg = "";

                MESAlreadyWorkMessage mAlreadyWorkMessage = new MESAlreadyWorkMessage();
                mAlreadyWorkMessage.processPlanNo = cgCurrentS1JobOrderInfo.F_PLANNO;
                mAlreadyWorkMessage.monoPartId = cgCurrentS1JobOrderInfo.F_MONOPARTID;
                mAlreadyWorkMessage.finishQty = "1";
                string strOperator = "";
                for (int i = 0; i < PublicParams.G_OperatorList.Count; i++)
                {
                    strOperator += PublicParams.G_OperatorList[i].F_OPERATORID + ",";
                }
                mAlreadyWorkMessage.finishWorker = strOperator.Substring(0, strOperator.Length - 1);
                mAlreadyWorkMessage.finishTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                ////将信息发送给后台
                //JsonSerializerSettings jsetting = new JsonSerializerSettings();
                //strJsonMsg = JsonConvert.SerializeObject(mAlreadyWorkMessage, Formatting.Indented, jsetting);

                //WRMESWebService.ProviderIMSWebserviceImplService iMSWebService = new WRMESWebService.ProviderIMSWebserviceImplService();
                //iMSWebService.transferAlreadyWorkMessage(strJsonMsg);
                //LogInfo.LogInfoInstance.WriteLogInfo(strJsonMsg, LogType.Information, "IMSToMESLog");

                S1StationProdFinished();//1号机台完成信息记录并更新到派工单表 

                SMESWorkInfo sdalWorkInfo = new SMESWorkInfo();
                if (!String.IsNullOrEmpty(mAlreadyWorkMessage.monoPartId))
                {
                    bool bResult = sdalWorkInfo.UpdateWorkInfo(mAlreadyWorkMessage);
                    if (bResult)
                    {
                        LogInfo.LogInfoInstance.WriteLogInfo("1号机台产品信息完工报工成功!", LogType.Information, "MESAlreadyWorkMessageLog");
                        uiPage.ShowSuccessDialog("1号机台产品信息完工报工成功！");
                    }
                    else
                    {
                        LogInfo.LogInfoInstance.WriteLogInfo("该工单还未开工报工过，请开工报工!", LogType.Error, "MESWorkSignalLog");
                        uiPage.ShowWarningDialog("该工单还未开工报工过，请开工报工！");
                    }
                }
                else
                {
                    bool bResult = sdalWorkInfo.UpdateBatchWorkInfo(mAlreadyWorkMessage);
                    if (bResult)
                    {
                        LogInfo.LogInfoInstance.WriteLogInfo("1号机台产品信息完工报工成功!", LogType.Information, "MESAlreadyWorkMessageLog");
                        uiPage.ShowSuccessDialog("1号机台产品信息完工报工成功！");
                    }
                    else
                    {
                        LogInfo.LogInfoInstance.WriteLogInfo("该工单还未开工报工过，请开工报工!", LogType.Error, "MESWorkSignalLog");
                        uiPage.ShowWarningDialog("该工单还未开工报工过，请开工报工！");
                    }
                }
            }
        }
        /// <summary>
        /// 二号机台完工报工
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnS2FinishWork_Click(object sender, EventArgs e)
        {
            if (uiPage.ShowAskDialog("您确认要完工吗?"))
            {
                //string strJsonMsg = "";

                MESAlreadyWorkMessage mAlreadyWorkMessage = new MESAlreadyWorkMessage();
                mAlreadyWorkMessage.processPlanNo = cgCurrentS2JobOrderInfo.F_PLANNO;
                mAlreadyWorkMessage.monoPartId = cgCurrentS2JobOrderInfo.F_MONOPARTID;
                mAlreadyWorkMessage.finishQty = "1";
                string strOperator = "";
                for (int i = 0; i < PublicParams.G_OperatorList.Count; i++)
                {
                    strOperator += PublicParams.G_OperatorList[i].F_OPERATORID + ",";
                }
                mAlreadyWorkMessage.finishWorker = strOperator.Substring(0, strOperator.Length - 1);
                mAlreadyWorkMessage.finishTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                ////将信息发送给后台
                //JsonSerializerSettings jsetting = new JsonSerializerSettings();
                //strJsonMsg = JsonConvert.SerializeObject(mAlreadyWorkMessage, Formatting.Indented, jsetting);

                //WRMESWebService.ProviderIMSWebserviceImplService iMSWebService = new WRMESWebService.ProviderIMSWebserviceImplService();
                //iMSWebService.transferAlreadyWorkMessage(strJsonMsg);
                //LogInfo.LogInfoInstance.WriteLogInfo(strJsonMsg, LogType.Information, "IMSToMESLog");

                S2StationProdFinished();//2号机台完成信息记录并更新到派工单表

                SMESWorkInfo sdalWorkInfo = new SMESWorkInfo();
                if (!String.IsNullOrEmpty(mAlreadyWorkMessage.monoPartId))
                {
                    bool bResult = sdalWorkInfo.UpdateWorkInfo(mAlreadyWorkMessage);
                    if (bResult)
                    {
                        LogInfo.LogInfoInstance.WriteLogInfo("2号机台产品信息完工报工成功!", LogType.Information, "MESAlreadyWorkMessageLog");
                        uiPage.ShowSuccessDialog("2号机台产品信息完工报工成功！");
                    }
                    else
                    {
                        LogInfo.LogInfoInstance.WriteLogInfo("该工单还未开工报工过，请开工报工!", LogType.Error, "MESWorkSignalLog");
                        uiPage.ShowWarningDialog("该工单还未开工报工过，请开工报工！");
                    }
                }
                else
                {
                    bool bResult = sdalWorkInfo.UpdateBatchWorkInfo(mAlreadyWorkMessage);
                    if (bResult)
                    {
                        LogInfo.LogInfoInstance.WriteLogInfo("2号机台产品信息完工报工成功!", LogType.Information, "MESAlreadyWorkMessageLog");
                        uiPage.ShowSuccessDialog("2号机台产品信息完工报工成功！");
                    }
                    else
                    {
                        LogInfo.LogInfoInstance.WriteLogInfo("该工单还未开工报工过，请开工报工!", LogType.Error, "MESWorkSignalLog");
                        uiPage.ShowWarningDialog("该工单还未开工报工过，请开工报工！");
                    }
                } 
            }
        }

        /// <summary>
        /// 1号机台完成信息记录并更新到派工单表
        /// </summary>
        private void S1StationProdFinished()
        {
            if (cgCurrentS1JobOrderInfo != null)
            {
                if (cgCurrentS1JobOrderInfo.F_PRODNO != null)
                {
                    if (cgCurrentS1JobOrderInfo.F_PRODNO.Trim() != "")
                    {
                        cgCurrentS1JobOrderInfo.F_JOBFSHEDQTY += 1;

                        lblS1JOBFSHEDQTY.Invoke(MsgRfidResultInfoPrint, "");
                        if (cgCurrentS1JobOrderInfoLst != null)
                        {
                            if (cgCurrentS1JobOrderInfoLst.Count > 0)
                            {
                                foreach (var q in cgCurrentS1JobOrderInfoLst)
                                {
                                    if (q.F_JOBORDERNO == cgCurrentS1JobOrderInfo.F_JOBORDERNO)
                                    {
                                        q.F_JOBFSHEDQTY = cgCurrentS1JobOrderInfo.F_JOBFSHEDQTY;
                                        break;
                                    }
                                }
                            }
                        }

                        cgCurrentS1JobOrderInfo.F_UPDATETIME = DateTime.Now;
                        if (Convert.ToSingle(cgCurrentS1JobOrderInfo.F_JOBFSHEDQTY) == cgCurrentS1JobOrderInfo.F_JOBORDERQTY)
                        {
                            cgCurrentS1JobOrderInfo.F_STATUS = 3;
                        }
                        else
                        {
                            cgCurrentS1JobOrderInfo.F_STATUS = 2;
                        }
                        dalJobOrderInfo.UpdateCurrentJobOrderInfo(cgCurrentS1JobOrderInfo);
                        if (cgCurrentS1JobOrderInfo.F_STATUS == 3)
                        {
                            //设置派工单信息
                            SetJobOrderInfo();
                            //加载并显示关键物料信息
                            PrintMainMaterialInfo();
                            //初始展示工艺指导书
                            InitPrintWorkInStruction();
                        }
                    }
                }
            }
            else
            {
                MessageUtil.ShowWarning("本机台无派工单，请重新选择！");
            }
        }


        /// <summary>
        /// 2号机台完成信息记录并更新到派工单表
        /// </summary>
        private void S2StationProdFinished()
        {
            if (cgCurrentS2JobOrderInfo != null)
            {
                if (cgCurrentS2JobOrderInfo.F_PRODNO != null)
                {
                    if (cgCurrentS2JobOrderInfo.F_PRODNO.Trim() != "")
                    {
                        cgCurrentS2JobOrderInfo.F_JOBFSHEDQTY += 1;
                        lblS2JOBFSHEDQTY.Invoke(MsgRfidResultInfoPrint, "");
                        if (cgCurrentS2JobOrderInfoLst != null)
                        {
                            if (cgCurrentS2JobOrderInfoLst.Count > 0)
                            {
                                foreach (var q in cgCurrentS2JobOrderInfoLst)
                                {
                                    if (q.F_JOBORDERNO == cgCurrentS2JobOrderInfo.F_JOBORDERNO)
                                    {
                                        q.F_JOBFSHEDQTY = cgCurrentS2JobOrderInfo.F_JOBFSHEDQTY;
                                        break;
                                    }
                                }
                            }
                        }

                        cgCurrentS2JobOrderInfo.F_UPDATETIME = DateTime.Now;
                        if (Convert.ToSingle(cgCurrentS2JobOrderInfo.F_JOBFSHEDQTY) == cgCurrentS2JobOrderInfo.F_JOBORDERQTY)
                        {
                            cgCurrentS2JobOrderInfo.F_STATUS = 3;
                        }
                        else
                        {
                            cgCurrentS2JobOrderInfo.F_STATUS = 2;
                        }
                        dalJobOrderInfo.UpdateCurrentJobOrderInfo(cgCurrentS2JobOrderInfo);
                        if (cgCurrentS2JobOrderInfo.F_STATUS == 3)
                        {
                            //设置派工单信息
                            SetJobOrderInfo();
                            //加载并显示关键物料信息
                            PrintMainMaterialInfo();
                            //初始展示工艺指导书
                            InitPrintWorkInStruction();
                        }
                    }
                }
            }
            else
            {
                MessageUtil.ShowWarning("本机台无派工单，请重新选择！");
            }
        }

        /// <summary>
        /// 展示RFID读写结果
        /// </summary>
        /// <param name="str"></param>
        private void PrintRfidResultInfo(string str)
        {
            if (lblS1JOBORDERNO.Text.Trim() != "")
            {
                if (cgCurrentS1JobOrderInfo != null)
                {
                    lblS1JOBFSHEDQTY.Text = cgCurrentS1JobOrderInfo.F_JOBFSHEDQTY.ToString();
                    btnS1RfidWriteCode.Enabled = true;
                }
            }
            if (lblS2JOBORDERNO.Text.Trim() != "")
            {
                if (cgCurrentS2JobOrderInfo != null)
                {
                    lblS2JOBFSHEDQTY.Text = cgCurrentS2JobOrderInfo.F_JOBFSHEDQTY.ToString();
                    btnS2RfidWriteCode.Enabled = true;
                }
            }
        }

        #endregion 中间的右侧按钮事件

        #region 物料清单查询与显示

        /// <summary>
        /// 加载并显示关键物料信息
        /// </summary>
        private void PrintMainMaterialInfo()
        {
            LoadData();
        }
        DataGridViewHandle gridHandle = new DataGridViewHandle();
        /// <summary>
        /// 创建初始的DataGrid表格
        /// </summary>
        /// <param name="srcDgv"></param>
        private void GenerateDataGridViewColumns()  // 生成DataGridView列
        {
            //gridHandle._dbgrid = dgvMaterialInfo;
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_ID", HeaderText = "序号", Width = 5, Visible = false });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_BOMNO", HeaderText = "物料清单编号", Width = 5, Visible = false });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_MATERIALCODE", HeaderText = "物料编码", Width = 5, Visible = true });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_MATERIALNAME", HeaderText = "物料名称", Width = 5, Visible = true });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_MATERIALMODEL", HeaderText = "规格型号", Width = 5, Visible = true });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_MATERIALNUM", HeaderText = "物料数量", Width = 5, Visible = true });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_WEIGHT", HeaderText = "重量", Width = 5, Visible = true });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_STATIONNO", HeaderText = "机台设备编号", Width = 5, Visible = false });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_STATIONNAME", HeaderText = "机台设备名称", Width = 5, Visible = true });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_UNITNAME", HeaderText = "单位名称", Width = 5, Visible = true });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_LOSSRATE", HeaderText = "损耗率", Width = 5, Visible = false });

            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_PROCESSNO", HeaderText = "工序编号", Width = 5, Visible = false });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_PROCESSNAME", HeaderText = "工序名称", Width = 5, Visible = true });

            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_ISMAIN", HeaderText = "是否关键件", Width = 5, Visible = false });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_USEDSTATUS", HeaderText = "启用状态", Width = 5, Visible = false });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_CREATOR", HeaderText = "创建者", Width = 5, Visible = false });
            //gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_CREATIONDATE", HeaderText = "创建时间", Width = 5, Visible = false });

            //gridHandle.GenerateBaseDataGridView();


            //dgvMaterialInfo.AddColumn("物料编码", "F_MATERIALCODE").SetFixedMode(150);
            //dgvMaterialInfo.AddColumn("物料名称", "F_MATERIALNAME").SetFixedMode(150);
            //dgvMaterialInfo.AddColumn("工序名称", "F_PROCESSNAME").SetFixedMode(150);
            //dgvMaterialInfo.AddColumn("单位名称", "F_UNITNAME").SetFixedMode(150);
            //dgvMaterialInfo.ReadOnly = true;

        }

        /// <summary>
        /// 加载物料需求信息数据
        /// </summary>
        /// <param name="jobOrderInfo">派工单信息</param>
        private void LoadData()
        {
            try
            {
                if (cgCurrentS1JobOrderInfoLst != null)
                {
                    if (cgCurrentS1JobOrderInfoLst.Count > 0)
                    {
                        SBMBOMDetailInfo sdalBomDetailInfo = new SBMBOMDetailInfo();
                        if (PublicParams.G_StationInfoList != null)
                        {
                            DataTable dtResult = new DataTable();
                            List<string> stdNoList = new List<string>();
                            foreach (var q in PublicParams.G_StationInfoList)
                            {
                                stdNoList.Add(q.F_STATIONNO);
                            }
                            dtResult = sdalBomDetailInfo.GetBomDetailInfo(cgCurrentS1JobOrderInfoLst[0].F_PRODNO, stdNoList);
                            int rownum = dtResult.Rows.Count;
                            lbTxtCheckMtlCount.Text = rownum.ToString();
                            dgvMaterialInfo.DataSource = dtResult;
                        }
                    }
                }
                if (cgCurrentS2JobOrderInfoLst != null)
                {
                    if (cgCurrentS2JobOrderInfoLst.Count > 0)
                    {
                        SBMBOMDetailInfo sdalBomDetailInfo = new SBMBOMDetailInfo();
                        if (PublicParams.G_StationInfoList != null)
                        {
                            DataTable dtResult = new DataTable();
                            List<string> stdNoList = new List<string>();
                            foreach (var q in PublicParams.G_StationInfoList)
                            {
                                stdNoList.Add(q.F_STATIONNO);
                            }
                            dtResult = sdalBomDetailInfo.GetBomDetailInfo(cgCurrentS2JobOrderInfoLst[0].F_PRODNO, stdNoList);
                            int rownum = dtResult.Rows.Count;
                            lbTxtCheckMtlCount.Text = rownum.ToString();
                            dgvMaterialInfo.DataSource = dtResult;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                throw;
            }
        }

        #endregion 物料清单查询与显示
    }
}
