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
    public partial class FrmFaultType : Form
    {
        public FrmFaultType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 打开异常反馈界面
        /// </summary>
        public void OpenExFrm(string exceptionType)
        {
            FrmFaultInfo faultResult = new FrmFaultInfo(exceptionType);
            faultResult.ShowDialog();
        }
        /// <summary>
        /// 设备异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeviceEx_Click(object sender, EventArgs e)
        {
            //OpenExFrm(ExceptionType.DeviceException.ToString());
            OpenExFrm("设备异常");
        }
        /// <summary>
        /// 一般物料异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNMaterialEx_Click(object sender, EventArgs e)
        {
            //OpenExFrm(ExceptionType.NormalMaterialException.ToString());
            OpenExFrm("一般物料异常");
        }
        /// <summary>
        /// 工位异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStationEx_Click(object sender, EventArgs e)
        {
            //OpenExFrm(ExceptionType.StationException.ToString());
            OpenExFrm("工位异常");
        }
        /// <summary>
        /// 工装夹具异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnToolEx_Click(object sender, EventArgs e)
        {
            //OpenExFrm(ExceptionType.ToolException.ToString());
            OpenExFrm("工装夹具异常");
        }
        /// <summary>
        /// 严重物料异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDMetarialEx_Click(object sender, EventArgs e)
        {
            //OpenExFrm(ExceptionType.DetailMaterialException.ToString());
            OpenExFrm("严重物料异常");
        }
        /// <summary>
        /// 其他异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOtherEx_Click(object sender, EventArgs e)
        {
            //OpenExFrm(ExceptionType.OtherException.ToString());
            OpenExFrm("其他异常");
        }
        /// <summary>
        /// 物料异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCallHandle_Click(object sender, EventArgs e)
        {
            //this.Close();
            new FrmCallHandleLogin().ShowDialog();
        }

        private void FrmFaultType_Load(object sender, EventArgs e)
        {

        }
    }
}
