using RS.BLL;
using RS.Common;
using RS.Model;
using Sunny.UI;
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
    public partial class FrmFaultInfo : Form
    {
        #region 变量

        // 异常类型
        private string exceptionType;

        // 异常呼叫逻辑处理类
        private BException bException = new BException();

        private MBFException exception = new MBFException();
        private MWOJobOrderInfo choiceJobOrderInfo = new MWOJobOrderInfo();
        private MSTStationInfo choiceStationInfo = new MSTStationInfo();
        #endregion 变量

        UIPage uiPage = new UIPage();
        public FrmFaultInfo(string exceptionType)
        {
            InitializeComponent();
            this.exceptionType = exceptionType;
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            if (PublicParams.G_ClientInfo != null && PublicParams.G_ClientInfo.F_CLIENTNO.Trim() != "")
            {
                //异常编号
                this.txtFaultNo.Text = PublicParams.G_ClientInfo.F_CLIENTNO.Trim() + DateTime.Now.ToString("yyyyMMddHHmmss");
                this.txtExceptionType.Text = this.exceptionType;
                lbltitle.Text = this.exceptionType;
                BindStationNoToComboBox();
                this.txtReportOperator.Text = PublicParams.G_OperatorInfo.F_OPERATORNAME.Trim();
                BindJobOrderNoToComboBox();
                this.txtExceptionDesc.Text = this.exceptionType;
            }
        }

        /// <summary>
        /// 绑定工位编码到工位编码下拉菜单
        /// </summary>
        private void BindStationNoToComboBox()
        {
            if (PublicParams.G_StationInfoList != null)
            {
                if (PublicParams.G_StationInfoList.Count > 0)
                {
                    cmbStationNo.Items.Clear();
                    for (int i = 0; i < PublicParams.G_StationInfoList.Count; i++)
                    {
                        cmbStationNo.Items.Add(PublicParams.G_StationInfoList[i].F_STATIONNO.Trim());
                    }
                    cmbStationNo.SelectedIndex = 0;
                    choiceStationInfo = PublicParams.G_StationInfoList[0];
                }
            }
        }

        /// <summary>
        /// 绑定派工单编码到派工单编码下拉菜单
        /// </summary>
        private void BindJobOrderNoToComboBox()
        {
            if (PublicParams.G_JobOrderInfoList != null)
            {
                if (PublicParams.G_JobOrderInfoList.Count > 0)
                {
                    cmbJobOrderNo.Items.Clear();
                    for (int i = 0; i < PublicParams.G_JobOrderInfoList.Count; i++)
                    {
                        cmbJobOrderNo.Items.Add(PublicParams.G_JobOrderInfoList[i].F_JOBORDERNO.Trim());
                    }
                    cmbJobOrderNo.Text = "";
                }
            }
        }

        private void FrmFaultInfo_Load(object sender, EventArgs e)
        {
            InitData();  //初始化数据
        }

        MHTClientFaultLogInfo fLogInfo = new MHTClientFaultLogInfo();

        /// <summary>
        /// 反馈
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReport_Click(object sender, EventArgs e)
        {
            fLogInfo.F_FAULTNO = txtFaultNo.Text.Trim();
            fLogInfo.F_FAULTTYPE = txtExceptionType.Text.Trim();
            fLogInfo.F_STATIONNO = cmbStationNo.Text.Trim();
            fLogInfo.F_STATIONNAME = choiceStationInfo.F_STATIONNAME;
            fLogInfo.F_OPERATOR = txtReportOperator.Text.Trim();
            fLogInfo.F_REPAIRTIME = DateTime.Now;
            fLogInfo.F_NORMALTIME = DateTime.Now;
            fLogInfo.F_FAULTDESC = txtExceptionDesc.Text.Trim();
            fLogInfo.F_REPAIRCONTENT = txtResultDesc.Text.Trim();
            fLogInfo.F_RESTORER = txtDealOperator.Text.Trim();
            fLogInfo.F_REPAIRRESULT = 0;
            fLogInfo.F_JOBORDERNO = cmbJobOrderNo.Text.Trim();
            BHTClientFaultLogInfo dalFaultLogInfo = new BHTClientFaultLogInfo();
            dalFaultLogInfo.InsertClientFaultLogInfo(fLogInfo);
            uiPage.ShowSuccessTip("异常反馈成功！");
        }
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            fLogInfo.F_FAULTNO = txtFaultNo.Text.Trim();
            fLogInfo.F_FAULTTYPE = txtExceptionType.Text.Trim();
            fLogInfo.F_STATIONNO = cmbStationNo.Text.Trim();
            fLogInfo.F_STATIONNAME = choiceStationInfo.F_STATIONNAME;
            fLogInfo.F_OPERATOR = txtReportOperator.Text.Trim();
            fLogInfo.F_REPAIRTIME = DateTime.Now;
            fLogInfo.F_NORMALTIME = DateTime.Now;
            fLogInfo.F_FAULTDESC = txtExceptionDesc.Text.Trim();
            fLogInfo.F_REPAIRCONTENT = txtResultDesc.Text.Trim();
            fLogInfo.F_RESTORER = txtDealOperator.Text.Trim();
            fLogInfo.F_REPAIRRESULT = 1;
            fLogInfo.F_JOBORDERNO = cmbJobOrderNo.Text.Trim();
            BHTClientFaultLogInfo dalFaultLogInfo = new BHTClientFaultLogInfo();
            dalFaultLogInfo.InsertClientFaultLogInfo(fLogInfo);
            if(uiPage.ShowAskDialog("异常处理成功，关闭处理窗口！"))
            {
                Application.Exit();
            }
        }
        /// <summary>
        /// 机台属性值发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStationNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stationNo = cmbStationNo.Text.Trim();
            if (PublicParams.G_StationInfoList != null)
            {
                foreach (var q in PublicParams.G_StationInfoList)
                {
                    if (q.F_STATIONNO == stationNo)
                    {
                        choiceStationInfo = q;
                    }
                }
                if (PublicParams.G_JobOrderInfoList != null)
                {
                    cmbJobOrderNo.Text = "";
                    foreach (var jobInfo in PublicParams.G_JobOrderInfoList)
                    {
                        if (jobInfo.F_STATIONNO == stationNo)
                        {
                            choiceJobOrderInfo = jobInfo;
                            cmbJobOrderNo.Text = jobInfo.F_JOBORDERNO;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 派工单属性值发生改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbJobOrderNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string jobOrderNo = cmbJobOrderNo.Text.Trim();
            if (PublicParams.G_JobOrderInfoList != null)
            {
                foreach (var q in PublicParams.G_JobOrderInfoList)
                {
                    if (q.F_JOBORDERNO == jobOrderNo)
                    {
                        choiceJobOrderInfo = q;
                        choiceStationInfo.F_STATIONNO = q.F_STATIONNO;
                        choiceStationInfo.F_STATIONNAME = q.F_STATIONNAME;
                        cmbStationNo.Text = q.F_STATIONNO;
                    }
                }
            }
        }
    }
}
