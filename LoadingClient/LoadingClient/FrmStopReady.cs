using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RS.SQLServerDAL;
using RS.Model;
using RS.Common;
using Sunny.UI;

namespace LoadingClient
{
    public partial class FrmStopReady : Form
    {
        public FrmStopReady()
        {
            InitializeComponent();
        }

        UIPage uiPage = new UIPage();
        MRFDevStopOrReady mDevStopReady = new MRFDevStopOrReady();
        SRFDevStopOrReady sdalDevStopReady = new SRFDevStopOrReady();

        private void FrmStopReady_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 录入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, EventArgs e)
        {
            DialogResult dgRst = MessageBox.Show(this, "您确认要录入停待机原因吗?", "警告", MessageBoxButtons.OKCancel);
            if (dgRst == DialogResult.OK)
            {
                mDevStopReady.F_StopOrReadyContent = txtResult.Text.Trim();
                mDevStopReady.F_ProcessName = "转台主体上料";
                mDevStopReady.F_StationName = PublicParams.G_StationInfoList[0].F_STATIONNAME;

                bool bResult = sdalDevStopReady.AddStopReadyContentDetail(mDevStopReady);
                if (bResult)
                {
                    uiPage.ShowSuccessTip("停待机录入成功");
                }
                else
                {
                    uiPage.ShowErrorTip("停待机录入失败");
                }
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
