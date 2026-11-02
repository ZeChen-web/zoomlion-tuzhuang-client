using RS.BLL;
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
    public partial class FrmCallHandleLogin : Form
    {
        #region 变量

        private SPMPeopleInfo sdalPeopleInfo = new SPMPeopleInfo();  //操作员基础信息查询类
        private MPMPeopleInfo peopleInfo = null;

        //private delegate void SetTxtCallBack(string msg);
        //private SetTxtCallBack MsgDlgOptBarCode;

        #endregion 变量

        UIPage uiPage = new UIPage();
        public FrmCallHandleLogin()
        {
            InitializeComponent();
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
                        sdalPeopleInfo = new SPMPeopleInfo();
                        peopleInfo = sdalPeopleInfo.GetPeopleInfoByAccount(optLoginCard);
                        if (peopleInfo != null)
                        {

                            if (peopleInfo.F_PEOPLEPRIV == 2)
                            {
                                this.txtOperatorName.Text = peopleInfo.F_PEOPLENAME;
                            }
                            else
                            {
                                peopleInfo = null;
                                uiPage.ShowErrorDialog("当前用户无此操作的权限，请联系管理员！");
                                this.txtLoginCard.Text = "";
                                this.txtLoginCard.Focus();
                                return;
                            }

                        }
                        else
                        {
                            peopleInfo = null;
                            uiPage.ShowErrorDialog("不存在此操作员信息，请联系管理员！");
                            this.txtLoginCard.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            if (peopleInfo != null)
            {
                MRTOperatorLoginInfo optLoginInfo = new MRTOperatorLoginInfo();
                optLoginInfo.F_LOGGINGCARD = peopleInfo.F_LOGGINGCARD;
                optLoginInfo.F_OPERATORNAME = peopleInfo.F_PEOPLENAME;
                optLoginInfo.F_CLIENTNO = PublicParams.G_ClientInfo.F_CLIENTNO;
                optLoginInfo.F_CLIENTNAME = PublicParams.G_ClientInfo.F_CLIENTNAME;
                optLoginInfo.F_LINEID = PublicParams.G_ClientInfo.F_LINENO;
                optLoginInfo.F_LINENAME = PublicParams.G_ClientInfo.F_LINENAME;
                optLoginInfo.F_LOGINTIME = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                optLoginInfo.F_LOGINOUTTIME = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                optLoginInfo.F_OPERATORTYPE = "3"; //0:操作员；1：检验人员;2:呼叫人员;3:呼叫处理人员

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
        /// 登录
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
                    AddLoginInfo();
                    if (peopleInfo != null)
                    {
                        string pwd = txtPwd.Text.Trim();
                        if (pwd != "")
                        {
                            string md5Pwd = Md5Util.Encrypt(pwd);
                            if (md5Pwd == peopleInfo.F_PEOPLEPWD)
                            {
                                PublicParams.G_CallPeopleInfo = peopleInfo;
                                FrmFaultHandle frmFaultHdl = new FrmFaultHandle();
                                this.Close();
                                frmFaultHdl.Show();

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

        private void txtLoginCard_TextChanged(object sender, EventArgs e)
        {
            LoginCardTextChangedEvent();
        }

        private void FrmCallHandleLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
