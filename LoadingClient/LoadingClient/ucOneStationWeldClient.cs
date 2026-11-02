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
using System.Threading;
using Sunny.UI;
using RS.RealTimeDBO;
using Newtonsoft.Json;

namespace LoadingClient
{
    public partial class ucOneStationWeldClient : UserControl
    {
        BWOJobOrderInfo dalJobOrderInfo = new BWOJobOrderInfo();
        MWOJobOrderInfo cgCurrentJobOrderInfo = null;
        List<MWOJobOrderInfo> cgCurrentJobOrderInfoLst = null;
        BBDWorkInStruction dalWorkInStruction = new BBDWorkInStruction();
        List<string> cgWorkInStructionFilePathList = null;
        private int cgCurrentFilePathIndex = 0;
        public static Discrete.FUN_DATA_CB data_callback = new Discrete.FUN_DATA_CB(DataCallBack);

        //更新生产进度结果
        public delegate void PrintStationFinishedCallBack();
        private PrintStationFinishedCallBack MsgStationFinishedInfoPrint;

        // 更新状态栏委托
        public delegate void InitStatusStripCallBack();

        private delegate void PrintSysTime();  //委托事件
        private PrintSysTime DgRealSysTimeValue;
        private bool IsPrintReadValue = true;
        /// <summary>
        /// 采集线程列表
        /// </summary>
        private List<Thread> collectThreadList = new List<Thread>();  //采集线程集合

        PingHelper Ping = new PingHelper();

        public ucOneStationWeldClient()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 去闪屏
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private void ucOneStationWeldClient_Load(object sender, EventArgs e)
        {
            FrmLoadingClient FrmWeldingClient = new FrmLoadingClient();
            double MultiplyingPower = (double)Screen.PrimaryScreen.Bounds.Width / FrmWeldingClient.Width;
            this.Width = Convert.ToInt32(FrmWeldingClient.plMain.Width * MultiplyingPower) + Convert.ToInt32(10 * MultiplyingPower);
            this.Height = Convert.ToInt32(FrmWeldingClient.plMain.Height * MultiplyingPower) - Convert.ToInt32(20 * MultiplyingPower);
            SetInitInfo();  //查询、设置、展示初始化信息
            MsgStationFinishedInfoPrint = new PrintStationFinishedCallBack(PrintStationFinishedInfo);


            #region 实时系统时间
            DgRealSysTimeValue = new PrintSysTime(PrintRealSysTime);

            //开始显示实时系统时间线程
            Thread printRealTimeThread = new Thread(StartPrintRealTime);
            printRealTimeThread.IsBackground = true;
            printRealTimeThread.Start();
            collectThreadList.Add(printRealTimeThread);
            #endregion 实时系统时间
        }
        /// <summary>
        /// 开始显示实时系统时间
        /// </summary>
        private void StartPrintRealTime()
        {
            while (IsPrintReadValue)
            {
                if (this.IsHandleCreated)
                {
                    lblJOBORDERNO.Invoke(DgRealSysTimeValue, null);
                }
                Thread.Sleep(5000);
            }
        }
        /// <summary>
        /// 显示实时系统时间
        /// </summary>
        private void PrintRealSysTime()
        {
            if (PingHelper.CmdPing("10.96.194.11",1))
            {
                lblJOBORDERNO.Text = "动臂斗杆线通讯正常！";
            }
            else
            {
                lblJOBORDERNO.Text = "动臂斗杆线的工位机与输送plc的网络断开，请检查工位机与输送plc之间的网络连接";
            }

            if (PingHelper.CmdPing("10.96.194.12",1))
            {
                lblJOBORDERQTY.Text = "上下车架线通讯正常！";
            }
            else
            {
                lblJOBORDERQTY.Text = "上下车架线的工位机与输送plc的网络断开，请检查工位机与输送plc之间的网络连接";
            }

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
            if (PublicParams.G_StationInfoList != null && PublicParams.G_StationInfoList.Count > 0)
            {
                cgCurrentJobOrderInfoLst = dalJobOrderInfo.GetJobOrderInfoListByStationNo(PublicParams.G_StationInfoList[0].F_STATIONNO);
               
                if (cgCurrentJobOrderInfoLst != null)
                {
                    if (cgCurrentJobOrderInfoLst.Count > 0)
                    {
                        cgCurrentJobOrderInfo = cgCurrentJobOrderInfoLst[0];
                    }
                    else
                    {
                        cgCurrentJobOrderInfo = null;
                    }
                }
                else
                {
                    cgCurrentJobOrderInfo = null;
                }
            }
            if (cgCurrentJobOrderInfo != null)
            {
                lblJOBORDERNO.Text = cgCurrentJobOrderInfo.F_JOBORDERNO;
                lblPRODNAME.Text = cgCurrentJobOrderInfo.F_PRODNAME;
                lblJOBORDERQTY.Text = cgCurrentJobOrderInfo.F_JOBORDERQTY.ToString();
                string strS1JobFshedQty = cgCurrentJobOrderInfo.F_JOBFSHEDQTY.ToString();
                lblJOBFSHEDQTY.Text = string.IsNullOrEmpty(strS1JobFshedQty) ? "0" : strS1JobFshedQty;

            }
            else
            {
                lblJOBORDERNO.Text = "";
                lblPRODNAME.Text = "";
                lblJOBORDERQTY.Text = "";
                lblJOBFSHEDQTY.Text = "";
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
        

        #region 中间的左侧按钮事件

        /// <summary>
        /// 获取当前派工单中需要展示的工艺指导书文件路径列表
        /// </summary>
        public void GetCurrentWorkInStructionPathFileList()
        {
            string stationNo = "";
            string prodNo = "";
            string processNo = "";
            if (cgCurrentJobOrderInfo != null)
            {
                stationNo = cgCurrentJobOrderInfo.F_STATIONNO;
                processNo = cgCurrentJobOrderInfo.F_PROCESSNO;
                prodNo = cgCurrentJobOrderInfo.F_PRODNO;
                List<string> FolderPathList = dalWorkInStruction.GetWorkInStructionFolderPathList(prodNo, processNo);
                if (FolderPathList != null)
                {
                    if (FolderPathList.Count > 0)
                    {
                        cgWorkInStructionFilePathList = new List<string>();
                        for (int i = 0; i < FolderPathList.Count; i++)
                        {
                            string strPathFolder = FolderPathList[i].Trim();
                            if (strPathFolder != "")
                            {
                                string strPathTemp = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                                string strPathFolderResult = strPathTemp.Substring(0, strPathTemp.LastIndexOf("\\")) + strPathFolder;

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
        }

        /// <summary>
        /// 初始展示工艺指导书
        /// </summary>
        private void InitPrintWorkInStruction()
        {
            if (cgWorkInStructionFilePathList == null)
            {
                GetCurrentWorkInStructionPathFileList();
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
                MessageBox.Show("工艺指导文件打开失败！");
            }
        }

        #endregion 中间的左侧按钮事件

        #region 中间的右侧按钮事件

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
                    cgCurrentJobOrderInfo = PublicParams.G_CurrentS1JobOrderInfo;

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
            if (cgCurrentJobOrderInfo != null)
            {
                lblJOBORDERNO.Text = cgCurrentJobOrderInfo.F_JOBORDERNO;
                lblPRODNAME.Text = cgCurrentJobOrderInfo.F_PRODNAME;
                lblJOBORDERQTY.Text = cgCurrentJobOrderInfo.F_JOBORDERQTY.ToString();
                lblJOBFSHEDQTY.Text = cgCurrentJobOrderInfo.F_JOBFSHEDQTY.ToString();

            }
            else
            {
                lblJOBORDERNO.Text = "";
                lblPRODNAME.Text = "";
                lblJOBORDERQTY.Text = "";
                lblJOBFSHEDQTY.Text = "";

            }
        }

        /// <summary>
        /// 工位工件完成记录完成信息并更新派工单生产结果
        /// </summary>
        private void StationProdFinished()
        {
            if (cgCurrentJobOrderInfo != null)
            {
                if (cgCurrentJobOrderInfo.F_PRODNO != null)
                {
                    if (cgCurrentJobOrderInfo.F_PRODNO.Trim() != "")
                    {
                        cgCurrentJobOrderInfo.F_JOBFSHEDQTY += 1;
                        lblJOBFSHEDQTY.Invoke(MsgStationFinishedInfoPrint, null);

                        if (cgCurrentJobOrderInfoLst != null)
                        {
                            if (cgCurrentJobOrderInfoLst.Count > 0)
                            {
                                foreach (var q in cgCurrentJobOrderInfoLst)
                                {
                                    if (q.F_JOBORDERNO == cgCurrentJobOrderInfo.F_JOBORDERNO)
                                    {
                                        q.F_JOBFSHEDQTY = cgCurrentJobOrderInfo.F_JOBFSHEDQTY;
                                        break;
                                    }
                                }
                            }
                        }

                        cgCurrentJobOrderInfo.F_UPDATETIME = DateTime.Now;
                        if (Convert.ToSingle(cgCurrentJobOrderInfo.F_JOBFSHEDQTY) == cgCurrentJobOrderInfo.F_JOBORDERQTY)
                        {
                            cgCurrentJobOrderInfo.F_STATUS = 3;
                        }
                        else
                        {
                            cgCurrentJobOrderInfo.F_STATUS = 2;
                        }
                        dalJobOrderInfo.UpdateCurrentJobOrderInfo(cgCurrentJobOrderInfo);
                        if (cgCurrentJobOrderInfo.F_STATUS == 3)
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
                MessageBox.Show("本机台无派工单，请重新选择派工单！");
            }
        }

        private void PrintStationFinishedInfo()
        {
            if (cgCurrentJobOrderInfo != null)
            {
                lblJOBFSHEDQTY.Text = cgCurrentJobOrderInfo.F_JOBFSHEDQTY.ToString();
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
            gridHandle._dbgrid = dgvMaterialInfo;
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_ID", HeaderText = "序号", Visible = false });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_BOMNO", HeaderText = "物料清单编号", Visible = false });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_MATERIALCODE", HeaderText = "物料编码", Visible = true });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_MATERIALNAME", HeaderText = "物料名称", Visible = true });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_MATERIALMODEL", HeaderText = "规格型号", Visible = true });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_MATERIALNUM", HeaderText = "物料数量", Visible = true });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_WEIGHT", HeaderText = "重量", Visible = true });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_STATIONNO", HeaderText = "机台设备编号", Visible = false });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_STATIONNAME", HeaderText = "机台设备名称", Visible = true });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_UNITNAME", HeaderText = "单位名称", Visible = true });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_LOSSRATE", HeaderText = "损耗率", Visible = false });

            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_PROCESSNO", HeaderText = "工序编号", Visible = false });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_PROCESSNAME", HeaderText = "工序名称", Visible = true });

            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_ISMAIN", HeaderText = "是否关键件", Visible = false });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_USEDSTATUS", HeaderText = "启用状态", Visible = false });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_CREATOR", HeaderText = "创建者", Visible = false });
            gridHandle._Fields.Add(new DataGridField() { DataPropertyName = "F_CREATIONDATE", HeaderText = "创建时间", Visible = false });

            gridHandle.GenerateBaseDataGridView();
        }

        /// <summary>
        /// 加载物料需求信息数据
        /// </summary>
        /// <param name="jobOrderInfo">派工单信息</param>
        private void LoadData()
        {
            try
            {
                if (cgCurrentJobOrderInfoLst != null)
                {
                    if (cgCurrentJobOrderInfoLst.Count > 0)
                    {
                        DataTable dtResult = new DataTable();
                        SBMBOMDetailInfo sdalBomDetailInfo = new SBMBOMDetailInfo();
                        if (PublicParams.G_StationInfoList != null)
                        {
                            List<string> stdNoList = new List<string>();
                            foreach (var q in PublicParams.G_StationInfoList)
                            {
                                stdNoList.Add(q.F_STATIONNO);
                            }
                            dtResult = sdalBomDetailInfo.GetBomDetailInfo(cgCurrentJobOrderInfoLst[0].F_PRODNO, stdNoList);
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

        /// <summary>
        /// 缓存1出库查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOutboundQuery1_Click(object sender, EventArgs e)
        {
            FrmOutboundQuery frmOutboundQuery = new FrmOutboundQuery("上料库存区");
            frmOutboundQuery.ShowDialog();
        }
        /// <summary>
        /// 缓存2出库查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOutboundQuery_Click(object sender, EventArgs e)
        {
            FrmOutboundQuery frmOutboundQuery = new FrmOutboundQuery("下料库存区");
            frmOutboundQuery.Show();
        }
        /// <summary>
        /// 缓存1手动停库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStopCache_Click(object sender, EventArgs e)
        {
            FrmStopLibrary frmStopLibrary = new FrmStopLibrary();
            frmStopLibrary.ShowDialog();
        }

        /// <summary>
        /// 物料查询1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMaterialSelect_Click(object sender, EventArgs e)
        {
            //string function = PublicParams.proNoFunc[PublicParams.G_ClientInfo.F_CLIENTNO];//获取编号  根据编号获取客户端信息
            //FrmMaterialSelect frmMaterialSelect = new FrmMaterialSelect("1");
            //frmMaterialSelect.ShowDialog();
            new FrmCacheInfo1().ShowDialog();
        }
        /// <summary>
        /// 库存物料2查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInventoryMaterialInquiry2_Click(object sender, EventArgs e)
        {
            //string function = PublicParams.proNoFunc[PublicParams.G_ClientInfo.F_CLIENTNO];//获取编号  根据编号获取客户端信息
            //FrmMaterialSelect frmMaterialSelect = new FrmMaterialSelect("2");
            //frmMaterialSelect.ShowDialog();
            new FrmCacheInfo2().ShowDialog();
        }
        /// <summary>
        /// 履带转台1查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton1_Click(object sender, EventArgs e)
        {
            //FrmMaterialSelect frmMaterialSelect = new FrmMaterialSelect("3");
            //frmMaterialSelect.ShowDialog();
            new FrmCacheInfo3().ShowDialog();
        }
        /// <summary>
        /// 履带转台2查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uiButton2_Click(object sender, EventArgs e)
        {
            //FrmMaterialSelect frmMaterialSelect = new FrmMaterialSelect("4");
            //frmMaterialSelect.ShowDialog();
            new FrmCacheInfo4().ShowDialog();
        }
        /// <summary>
        /// 显示移行机状态信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTCStateInfo_Click(object sender, EventArgs e)
        {
            new FrmTCInfo().ShowDialog();
        }

        private void uiButton3_Click_1(object sender, EventArgs e)
        {
            new FrmMaterialSet().ShowDialog();
        }

        private void uiButton4_Click_1(object sender, EventArgs e)
        {
            new FrmCacheInfoOut1().ShowDialog();
        }

        private void uiButton5_Click(object sender, EventArgs e)
        {
            new FrmCacheInfoOut3().ShowDialog();
        }
    }
}
