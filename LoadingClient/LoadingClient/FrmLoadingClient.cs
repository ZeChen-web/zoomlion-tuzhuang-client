using RS.BLL;
using RS.Common;
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
    public partial class FrmLoadingClient : Form
    {
        // 更新状态栏委托
        public delegate void InitStatusStripCallBack();

        private delegate void PrintSysTime();  //委托事件
        private PrintSysTime DgRealSysTimeValue;

        /// <summary>
        /// 采集线程列表
        /// </summary>
        private List<Thread> collectThreadList = new List<Thread>();  //采集线程集合

        private bool IsPrintReadValue = true;

        public FrmLoadingClient()
        {
            InitializeComponent();
        }

        private void FrmLoadingClient_Load(object sender, EventArgs e)
        {
            lblTitle.Text = PublicParams.G_ClientInfo.F_CLIENTNAME;

            //初始化底部菜单（窗脚）信息
            InitStatusStripInfo();

            PublicParams.GetStationTagInfo();

            #region 实时系统时间
            DgRealSysTimeValue = new PrintSysTime(PrintRealSysTime);

            //开始显示实时系统时间线程
            Thread printRealTimeThread = new Thread(StartPrintRealTime);
            printRealTimeThread.IsBackground = true;
            printRealTimeThread.Start();
            collectThreadList.Add(printRealTimeThread);
            #endregion 实时系统时间
        }

        #region 系统时间

        /// <summary>
        /// 显示实时系统时间
        /// </summary>
        private void PrintRealSysTime()
        {
            lblCurrentDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblCurrentTime.Text = DateTime.Now.ToString("HH:mm:ss");
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
                    lblCurrentTime.Invoke(DgRealSysTimeValue, null);
                }
                Thread.Sleep(1000);
            }
        }

        #endregion 系统时间

        public void InitStatusStripInfo()
        {
            if (statusStrip1.InvokeRequired)
            {
                InitStatusStripCallBack dcb = new InitStatusStripCallBack(InitStatusStripInfo);
                this.Invoke(dcb, new object[] { });
            }
            else
            {
                toollblLoginName.Text = PublicParams.G_OperatorInfo.F_OPERATORNAME.ToString();
                //lblCurrentDate.Text = DateTime.Now.Date.ToString("yyyy年MM月dd日");
            }
        }
        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPwdChange_Click(object sender, EventArgs e)
        {
            FrmPwdChange frmPwdChg = new FrmPwdChange();
            frmPwdChg.ShowDialog();
        }
        /// <summary>
        /// 系统注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSysCanle_Click(object sender, EventArgs e)
        {
            // 记录注销信息
            try { new BLogin().SystemCancleLogOutInfo(); } catch (Exception ex) { MessageUtil.ShowError(ex.Message); };
            FrmClientLogin frmOpen = new FrmClientLogin();
            frmOpen.ShowDialog();
        }
        /// <summary>
        /// 系统关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSysClose_Click(object sender, EventArgs e)
        {
            // 记录注销信息
            try { new BLogin().SystemCancleLogOutInfo(); } catch (Exception ex) { MessageUtil.ShowError(ex.Message); };
            Application.Exit();
        }
        /// <summary>
        /// 协同登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogInOut_Click(object sender, EventArgs e)
        {
            FrmLoginOut frmLgOut = new FrmLoginOut();
            frmLgOut.ShowDialog();
        }
        /// <summary>
        /// 异常呼叫
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFaultCall_Click(object sender, EventArgs e)
        {
            FrmFaultType frmFaultType = new FrmFaultType();
            frmFaultType.ShowDialog();
        }
    }
}
