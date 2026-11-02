using RS.Common;
using RS.Model;
using RS.SQLServerDAL;
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
    public partial class FrmFaultHandle : Form
    {
        private MSTStationInfo choiceStationInfo = new MSTStationInfo();
        private List<MHTClientFaultLogInfo> clogInfoList = null;
        private MHTClientFaultLogInfo choiceClientCallLogInfo = null;

        UIPage uiPage = new UIPage();
        public FrmFaultHandle()
        {
            InitializeComponent();
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
        /// 设置处理基础信息
        /// </summary>
        private void SetCLogInfo()
        {
            if (cmbStationNo.Text.Trim() != "")
            {
                SHTClientFaultLogInfo sdalCLogInfo = new SHTClientFaultLogInfo();
                clogInfoList = sdalCLogInfo.GetClientFaultLogInfoListByStationNo(cmbStationNo.Text.Trim());
                if (clogInfoList != null)
                {
                    if (clogInfoList.Count > 0)
                    {
                        cmbCallNo.Text = clogInfoList[0].F_FAULTNO;
                        txtExceptionType.Text = clogInfoList[0].F_FAULTTYPE;
                        txtDealOperator.Text = PublicParams.G_CallPeopleInfo.F_PEOPLENAME;
                        txtFaultDesc.Text = clogInfoList[0].F_FAULTDESC;
                        choiceClientCallLogInfo = clogInfoList[0];
                        cmbCallNo.Items.Clear();
                        foreach (var q in clogInfoList)
                        {
                            if (q.F_FAULTNO != null && q.F_FAULTNO != "")
                            {
                                cmbCallNo.Items.Add(q.F_FAULTNO);
                            }
                        }
                    }
                }
                else
                {
                    cmbCallNo.Text = "";
                    txtExceptionType.Text = "";
                    txtFaultDesc.Text = "";
                    txtHandleDesc.Text = "";
                    cmbCallNo.Items.Clear();
                }
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            if (PublicParams.G_ClientInfo != null && PublicParams.G_ClientInfo.F_CLIENTNO.Trim() != "")
            {
                BindStationNoToComboBox();
                SetCLogInfo();   //设置处理基础信息
            }
        }

        private void FrmFaultHandle_Load(object sender, EventArgs e)
        {
            InitData();  //初始化数据
        }

        /// <summary>
        /// 处理结果提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHandleResult_Click(object sender, EventArgs e)
        {
            choiceClientCallLogInfo.F_STATIONNO = cmbStationNo.Text.Trim();
            choiceClientCallLogInfo.F_STATIONNAME = choiceStationInfo.F_STATIONNAME;
            choiceClientCallLogInfo.F_FAULTDESC = txtFaultDesc.Text.Trim();
            choiceClientCallLogInfo.F_REPAIRCONTENT = txtHandleDesc.Text.Trim();
            choiceClientCallLogInfo.F_RESTORER = PublicParams.G_CallPeopleInfo.F_PEOPLENAME;
            choiceClientCallLogInfo.F_REPAIRRESULT = 1;
            choiceClientCallLogInfo.F_NORMALTIME = DateTime.Now;
            choiceClientCallLogInfo.F_FAULTNO = cmbCallNo.Text.Trim();

            if (cmbCallNo.Text.Trim() != "")
            {
                SHTClientFaultLogInfo sdalCallLogInfo = new SHTClientFaultLogInfo();
                sdalCallLogInfo.UpdateClientFaultLogInfo(choiceClientCallLogInfo);
                uiPage.ShowSuccessTip("异常呼叫处理成功！");
            }
            else
            {
                uiPage.ShowWarningTip("请选择异常编号！");
            }

            SetCLogInfo();  //设置处理基础信息    
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 机台设备变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStationNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCLogInfo();  //设置处理基础信息
        }

        /// <summary>
        /// 异常编号选择变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCallNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCallNo.Text.Trim() != "")
            {
                string callNo = cmbCallNo.Text.Trim();
                if (clogInfoList != null)
                {
                    foreach (var clog in clogInfoList)
                    {
                        if (clog.F_FAULTNO == callNo)
                        {
                            cmbCallNo.Text = clog.F_FAULTNO;
                            txtExceptionType.Text = clog.F_FAULTTYPE;
                            txtFaultDesc.Text = clog.F_FAULTDESC;
                            choiceClientCallLogInfo = clog;
                        }
                    }
                }
            }
        }
    }
}
