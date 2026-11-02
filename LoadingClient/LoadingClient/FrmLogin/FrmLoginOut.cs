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
    public partial class FrmLoginOut : Form
    {
        #region 变量

        private BPMOperatorInfo dalOperatorInfo = new BPMOperatorInfo();  //操作员基础信息查询类
        private BPMOperatorClientReInfo sdalOperatorClientInfo = new BPMOperatorClientReInfo(); //操作员与客户端对应信息查询类

        private MPMOperatorInfo operatorInfo = null;

        private delegate void SetTxtCallBack(string msg);
        private SetTxtCallBack MsgDlgOptBarCode;

        UIPage uiPage = new UIPage();

        #endregion

        public FrmLoginOut()
        {
            InitializeComponent();

            try
            {
                PrintLoginOperatorInfo();
                MsgDlgOptBarCode = new SetTxtCallBack(DisplayTxtOptLogin);
            }
            catch (Exception ex)
            {
                uiPage.ShowErrorDialog(ex.ToString());
            }
        }

        private void PrintLoginOperatorInfo()
        {
            if (PublicParams.G_OperatorLoginInfoList.Count > 0)
            {
                for (int i = 0; i < PublicParams.G_OperatorLoginInfoList.Count; i++)
                {
                    this.lstViewLoginOperator.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = PublicParams.G_OperatorLoginInfoList[i].F_OPERATORNAME.ToString() + "\r\n";
                    lvi.SubItems.Add(PublicParams.G_OperatorLoginInfoList[i].F_OPERATORNAME.ToString());
                    this.lstViewLoginOperator.Items.Add(lvi);
                    this.lstViewLoginOperator.EndUpdate();
                }
            }
        }


        /// <summary>
        /// 在文本框中显示主机条形码
        /// </summary>
        private void DisplayTxtOptLogin(string msg)
        {
            if (txtOperatorName.InvokeRequired)
            {
                txtOperatorName.Invoke(MsgDlgOptBarCode, msg);
            }
            else
            {
                txtOperatorName.Text = msg;
            }
        }


        /// <summary>
        /// 操作员登陆名文本框已填写发生事件
        /// </summary>
        private void OperatorLoggingCardTextChange()
        {
            try
            {
                string optLoginCard = "";
                optLoginCard = txtLoginCard.Text.Trim();

                if (!String.IsNullOrEmpty(optLoginCard))
                {
                    if (optLoginCard.Length >= 4)
                    {
                        dalOperatorInfo = new BPMOperatorInfo();
                        operatorInfo = dalOperatorInfo.GetOperatorInfoByAccount(optLoginCard);
                        if (operatorInfo != null)
                        {
                            // 判断用户状态
                            if (!"1".Equals(operatorInfo.F_STATUS))
                            {
                                operatorInfo = null;
                                uiPage.ShowErrorDialog("当前用户为禁用状态，请切换用户登录！");
                                this.txtLoginCard.Text = "";
                                this.txtLoginCard.Focus();
                                return;
                            }
                            else
                            {
                                this.txtOperatorName.Text = operatorInfo.F_OPERATORNAME;
                            }
                        }
                        else
                        {
                            operatorInfo = null;
                            uiPage.ShowErrorDialog("不存在此操作员信息，请联系管理员！");
                            this.txtLoginCard.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                uiPage.ShowErrorDialog(ex.ToString());
            }
        }

        /// <summary>
        /// 刷卡的时候使用的文本变化变量
        /// </summary>
        private void LoginCardTextChangedEvent()
        {
            if (!String.IsNullOrEmpty(this.txtLoginCard.Text))
            {
                string[] strings = txtLoginCard.Text.ToString().Trim().Split('\n');
                txtLoginCard.Text = strings[0];
                txtLoginCard.Text = txtLoginCard.Text.Trim();
                OperatorLoggingCardTextChange();
            }
        }

        /// <summary>
        /// 操作员登录信息记录
        /// </summary>
        private void AddLoginInfo()
        {
            // 主登陆人基本信息
            if (operatorInfo != null)
            {
                MRTOperatorLoginInfo optLoginInfo = new MRTOperatorLoginInfo();
                optLoginInfo.F_LOGGINGCARD = operatorInfo.F_LOGGINGCARD;
                optLoginInfo.F_OPERATORNAME = operatorInfo.F_OPERATORNAME;
                optLoginInfo.F_CLIENTNO = PublicParams.G_ClientInfo.F_CLIENTNO;
                optLoginInfo.F_CLIENTNAME = PublicParams.G_ClientInfo.F_CLIENTNAME;
                optLoginInfo.F_LINEID = PublicParams.G_ClientInfo.F_LINENO;
                optLoginInfo.F_LINENAME = PublicParams.G_ClientInfo.F_LINENAME;
                optLoginInfo.F_LOGINTIME = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                optLoginInfo.F_LOGINOUTTIME = Convert.ToDateTime("1800-01-01 00:00:00");
                optLoginInfo.F_OPERATORTYPE = "0"; //0:操作员；1:装配人员；2：准备人员；3：检验人员

                try
                {
                    new BLogin().AddOperatorLoginInInfo(optLoginInfo);
                    PublicParams.G_OperatorLoginInfoList.Add(optLoginInfo);
                }
                catch (Exception ex)
                {
                    uiPage.ShowErrorDialog(ex.Message);
                }
            }
        }

        /// <summary>
        /// 添加退出信息
        /// </summary>
        private void AddLogoutInfo(int srcIndex)
        {
            if (PublicParams.G_OperatorLoginInfoList.Count >= srcIndex)
            {
                MRTOperatorLoginInfo optLoginInfo = PublicParams.G_OperatorLoginInfoList[srcIndex];
                new BLogin().EditOperatorLoginOutInfo(optLoginInfo);
                PublicParams.G_OperatorLoginInfoList.RemoveAt(srcIndex);
                PublicParams.G_OperatorList.RemoveAt(srcIndex);
                PublicParams.CurrentWorkerNum -= 1;
            }

        }

        private void FrmLoginOut_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                OperatorLoggingCardTextChange();
                if (txtLoginCard.Text.Trim() != "")
                {
                    if (operatorInfo != null)
                    {
                        string pwd = txtPwd.Text.Trim();
                        if (pwd != "")
                        {
                            string md5Pwd = Md5Util.Encrypt(pwd);
                            List<string> clientNOList = null;
                            if (md5Pwd == operatorInfo.F_OPERATORPWD)
                            {
                                clientNOList = sdalOperatorClientInfo.GetClientNOListByOperatorID(operatorInfo.F_ID);

                                if (clientNOList != null)
                                {
                                    if (clientNOList.Contains(PublicParams.G_ClientInfo.F_CLIENTNO.ToString()))
                                    {
                                        bool isExistOperator = false;

                                        foreach (var q in PublicParams.G_OperatorList)
                                        {
                                            if (q.F_LOGGINGCARD.Trim() == operatorInfo.F_LOGGINGCARD.Trim())
                                            {
                                                isExistOperator = true;
                                            }
                                        }
                                        if (PublicParams.G_OperatorInfo.F_LOGGINGCARD.Trim() == operatorInfo.F_LOGGINGCARD.Trim())
                                        {
                                            isExistOperator = true;
                                        }
                                        if (!isExistOperator)
                                        {
                                            AddLoginInfo(); //操作员登录信息记录

                                            this.lstViewLoginOperator.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
                                            ListViewItem lvi = new ListViewItem();
                                            lvi.Text = operatorInfo.F_OPERATORNAME.ToString();
                                            lvi.SubItems.Add(operatorInfo.F_OPERATORNAME.ToString());
                                            this.lstViewLoginOperator.Items.Add(lvi);
                                            this.lstViewLoginOperator.EndUpdate();

                                            txtLoginCard.Text = "";
                                            txtOperatorName.Text = "";
                                            txtPwd.Text = "";
                                            this.txtLoginCard.Focus();

                                            PublicParams.G_OperatorList.Add(operatorInfo);

                                            PublicParams.CurrentWorkerNum += 1;

                                            //更新状态栏
                                            foreach (Form frm in Application.OpenForms)
                                            {
                                                if (frm.Name == "FrmLoadingClient")
                                                {
                                                    (frm as FrmLoadingClient).InitStatusStripInfo();
                                                }
                                                //else if(frm.Name == "FrmUNScanClientMain")
                                                //{
                                                //    (frm as FrmUNScanClientMain).InitStatusStripInfo();
                                                //}
                                            }

                                        }
                                        else
                                        {
                                            uiPage.ShowErrorDialog("对不起，您已经登入，请不要重复登入！");
                                            this.txtLoginCard.Text = "";
                                            this.txtOperatorName.Text = "";
                                            this.txtPwd.Text = "";
                                            this.txtLoginCard.Focus();
                                        }

                                    }
                                    else
                                    {
                                        uiPage.ShowErrorDialog("对不起，您没有操作该客户端的权限，请联系管理员修改权限！");
                                        this.txtLoginCard.Text = "";
                                        this.txtLoginCard.Focus();
                                    }
                                }
                                else
                                {
                                    uiPage.ShowErrorDialog("对不起，您没有操作该客户端的权限，请联系管理员修改权限！");
                                }
                            }
                            else
                            {
                                uiPage.ShowErrorDialog("密码错误！请重新输入");
                            }
                        }
                        else
                        {
                            uiPage.ShowErrorDialog("密码未填写，请输入密码！");
                        }

                    }
                }
                else
                {
                    uiPage.ShowWarningDialog("您还没有刷卡，请刷卡！");
                }
            }
            catch (Exception ex)
            {
                uiPage.ShowErrorDialog(ex.Message);
            }
        }
        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (lstViewLoginOperator.SelectedItems.Count == 0)
            {
                uiPage.ShowWarningDialog("未选择要退出的人员！");
                return;
            }
            lstViewLoginOperator.BeginUpdate();

            foreach (ListViewItem lvi in lstViewLoginOperator.SelectedItems)
            {
                ListViewItem lviSelectedItem = lvi;
                int indexSelectedItem = lvi.Index;
                lstViewLoginOperator.Items.RemoveAt(indexSelectedItem);

                AddLogoutInfo(indexSelectedItem); //添加退出信息

                //更新状态栏
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Name == "FrmLoadingClient")
                    {
                        (frm as FrmLoadingClient).InitStatusStripInfo();
                    }
                    //else if (frm.Name == "FrmUNScanClientMain")
                    //{
                    //    (frm as FrmUNScanClientMain).InitStatusStripInfo();
                    //}
                }
            }

            lstViewLoginOperator.EndUpdate();

            if (lstViewLoginOperator.Items.Count > 0 && lstViewLoginOperator.SelectedItems.Count > 0)
            {
                lstViewLoginOperator.Focus();
                lstViewLoginOperator.SelectedItems[0].Focused = true;
                lstViewLoginOperator.SelectedItems[0].EnsureVisible();
            }
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 文本变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLoginCard_TextChanged(object sender, EventArgs e)
        {
            LoginCardTextChangedEvent();
        }
    }
}
