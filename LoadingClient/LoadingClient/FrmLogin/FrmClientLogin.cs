using RS.BLL;
using RS.Common;
using RS.Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoadingClient
{
    public partial class FrmClientLogin : Form
    {
        #region 变量

        private BPMOperatorInfo dalOperatorInfo = null;  //操作员基础信息查询类
        private BPMOperatorClientReInfo dalOperatorClientInfo = null; //操作员与客户端对应信息查询类
        private BDataBaseManage dalDbManage = new BDataBaseManage();
        private BLogin bllLogin = new BLogin();
        private BSTStationClientInfo dalStationClientInfo = null;

        private delegate void SetTxtCallBack(string msg);
        //private SetTxtCallBack MsgDlgOptBarCode;

        UIPage uiPage = new UIPage();

        #endregion

        #region 构造函数
        public FrmClientLogin()
        {
            InitializeComponent();
        }
        #endregion 构造函数

        #region 方法

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


        /// <summary>
        /// 得到本机客户端IP地址，根据此判断客户端ID
        /// </summary>
        private void GetClientID()
        {
            try
            {
                string hostName = System.Net.Dns.GetHostName();  //获取主机名称
                System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(hostName);
                //ip地址列表
                System.Net.IPAddress[] addr = ipEntry.AddressList;
                string ipAddr = "";

                if (addr.Count() >= 4)
                {
                    ipAddr = addr[3].ToString().Trim();
                }
                else if (addr.Count() == 3)
                {
                    ipAddr = addr[2].ToString().Trim();
                }
                else if (addr.Count() == 2)
                {
                    ipAddr = addr[1].ToString().Trim();
                }
                else if (addr.Count() == 1)
                {
                    ipAddr = addr[0].ToString().Trim();
                }

                ipAddr = "10.10.10.160";

                if (ipAddr != "")
                {
                    if (ValidateUtil.IsValidIP(ipAddr))
                    {
                        if (ipAddr != "127.0.0.1")
                        {
                            BSTClientInfo bdalClientInfo = new BSTClientInfo();
                            MSTClientInfo mdClientInfo = null;
                            mdClientInfo = bdalClientInfo.GetClientInfoByClientIP(ipAddr);
                            if (mdClientInfo != null)
                            {
                                dalStationClientInfo = new BSTStationClientInfo();
                                PublicParams.G_ClientInfo = mdClientInfo;
                                //查询该客户端监视的机台设备信息列表
                                PublicParams.G_StationInfoList = dalStationClientInfo.GetStationInfoListByClientNo(PublicParams.G_ClientInfo.F_CLIENTNO);
                                if (PublicParams.G_StationInfoList == null || PublicParams.G_StationInfoList.Count == 0)
                                {
                                    uiPage.ShowErrorDialog("对不起，该客户端未配置操作机台的权限，请联系管理员！");
                                    //Application.Exit();
                                }
                            }
                            else
                            {
                                if(uiPage.ShowAskDialog("本机配置的IP地址与服务器配置不相符，请更换IP地址！"))
                                {
                                    Application.Exit();
                                }
                            }
                        }
                        else
                        {
                            uiPage.ShowErrorDialog("网络端口未插网线或本机未配置IP地址，请检查后再操作！");
                        }
                    }
                    else
                    {
                        uiPage.ShowErrorDialog("网络地址配置错误，请重新配置！");
                    }
                }
            }
            catch (Exception ex)
            {
                uiPage.ShowErrorDialog(ex.ToString());
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
                optLoginCard = txtLoggingCard.Text.Trim();

                if (!String.IsNullOrEmpty(optLoginCard))
                {
                    if (optLoginCard.Length >= 6)
                    {
                        MPMOperatorInfo operatorInfo = dalOperatorInfo.GetOperatorInfoByAccount(optLoginCard);
                        if (operatorInfo != null)
                        {
                            // 判断用户状态
                            if ("0".Equals(operatorInfo.F_STATUS))
                            {
                                uiPage.ShowErrorDialog("当前用户为禁用状态，请切换用户登录！");
                                this.txtLoggingCard.Text = "";
                                this.txtLoggingCard.Focus();
                                return;
                            }

                            // 全局变量
                            PublicParams.G_OperatorInfo = operatorInfo;
                            PublicParams.G_OperatorList.Add(operatorInfo);
                        }
                        else
                        {
                            uiPage.ShowErrorDialog("不存在此操作员信息，请联系管理员！");
                            this.txtLoggingCard.Text = "";
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
        /// 点击键盘响应方法
        /// </summary>
        /// <param name="msg">通过引用传递的 <see cref="T:System.Windows.Forms.Message" />，它表示要处理的 Win32 消息。</param>
        /// <param name="keyData"><see cref="T:System.Windows.Forms.Keys" /> 值之一，它表示要处理的键。</param>
        /// <returns>
        /// 如果控件处理并使用击键，则为 true；否则为 false，以允许进一步处理。
        /// </returns>
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)

        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;

            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Enter:
                        btnSubmit_Click(null, null);
                        break;
                    case Keys.Escape:
                        btnExit_Click(null, null);
                        break;
                }
            }

            return false;
        }

        #endregion

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClientLogin_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            // 默认光标位置
            this.txtLoggingCard.Focus();
            try
            {
                bool isConnected = false;
                isConnected = dalDbManage.DBIsConnected();

                if (isConnected)
                {
                    dalOperatorInfo = new BPMOperatorInfo();  //操作员基础信息查询类
                    dalOperatorClientInfo = new BPMOperatorClientReInfo(); //操作员与客户端对应信息查询类

                    GetClientID();
                }
                else
                {
                    if(uiPage.ShowAskDialog("连接数据库服务器失败，请联系数据库管理员！"))
                    {
                        Application.Exit();
                    }
                }
            }
            catch (IOException ex)
            {
                uiPage.ShowErrorDialog(ex.ToString());
            }
        }
        /// <summary>
        /// 登录按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                OperatorLoggingCardTextChange();
                if (txtLoggingCard.Text.Trim() != "")
                {
                    if (PublicParams.G_OperatorInfo != null)
                    {
                        string pwd = txtPwd.Text.Trim();
                        if (pwd != "")
                        {
                            string md5Pwd = Md5Util.Encrypt(pwd);
                            if (md5Pwd == PublicParams.G_OperatorInfo.F_OPERATORPWD)
                            {

                                //List<string> clientNOList = null;  //客户端编号列表
                                //if (clientNOList == null)
                                //{
                                //    clientNOList = dalOperatorClientInfo.GetClientNOListByOperatorID(PublicParams.G_OperatorInfo.F_ID);
                                //}
                                //if (clientNOList != null)
                                //{
                                //    if (clientNOList.Contains(PublicParams.G_ClientInfo.F_CLIENTNO.ToString()))
                                //    {

                                PublicParams.G_OpertorLoginInfo.F_LOGGINGCARD = PublicParams.G_OperatorInfo.F_LOGGINGCARD;
                                PublicParams.G_OpertorLoginInfo.F_OPERATORNAME = PublicParams.G_OperatorInfo.F_OPERATORNAME;
                                PublicParams.G_OpertorLoginInfo.F_CLIENTNO = PublicParams.G_ClientInfo.F_CLIENTNO;
                                PublicParams.G_OpertorLoginInfo.F_CLIENTNAME = PublicParams.G_ClientInfo.F_CLIENTNAME;
                                PublicParams.G_OpertorLoginInfo.F_LINEID = PublicParams.G_ClientInfo.F_LINENO;
                                PublicParams.G_OpertorLoginInfo.F_LINENAME = PublicParams.G_ClientInfo.F_LINENAME;
                                PublicParams.G_OpertorLoginInfo.F_LOGINTIME = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                PublicParams.G_OpertorLoginInfo.F_LOGINOUTTIME = Convert.ToDateTime("1800-01-01 00:00:00");
                                PublicParams.G_OpertorLoginInfo.F_OPERATORTYPE = "0"; //0:操作员；1:装配人员；2：准备人员；3：检验人员

                                bool bInsertRes = bllLogin.AddOperatorLoginInInfo(PublicParams.G_OpertorLoginInfo);
                                if (bInsertRes)
                                {
                                    PublicParams.G_OperatorLoginInfoList.Add(PublicParams.G_OpertorLoginInfo);
                                    DialogResult = DialogResult.OK;
                                }
                                else
                                {
                                    uiPage.ShowErrorDialog("对不起，登录信息数据库添加失败，请联系管理员并重新登录！");
                                }
                                //}
                                //    else
                                //    {
                                //        uiPage.ShowErrorDialog("对不起，您没有操作该客户端的权限，请联系管理员修改权限！");
                                //        this.txtLoggingCard.Focus();
                                //    }
                                //}
                                //else
                                //{
                                //    uiPage.ShowErrorDialog("对不起，您没有操作该客户端的权限，请联系管理员修改权限！");
                                //}
                            }
                            else
                            {
                                uiPage.ShowErrorDialog("密码错误！请重新输入");
                            }
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
                uiPage.ShowErrorDialog(ex.ToString());
            }
        }
        /// <summary>
        /// 关闭系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
