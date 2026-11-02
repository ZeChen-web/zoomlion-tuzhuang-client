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
    public partial class FrmMessageBox : Form
    {
        #region 属性

        /// <summary>
        /// 状态；0:失败；1：成功
        /// </summary>
        public int F_Status { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string F_ProdName { get; set; }

        #endregion 属性

        public FrmMessageBox()
        {
            InitializeComponent();
        }

        private void FrmMessageBox_Load(object sender, EventArgs e)
        {
            string strPathTemp = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string strPathFolderResult = strPathTemp.Substring(0, strPathTemp.LastIndexOf("\\")) + "\\jpg\\";

            if (F_Status == 1)
            {
                lblTitle.Text = "恭喜您";
                lblResult.Text = "成功！";
                lblIsTip.Visible = false;
                strPathFolderResult += "bom.jpg";
                picTip.BackgroundImage = Image.FromFile(strPathFolderResult);
            }
            else
            {
                lblTitle.Text = "提醒：";
                lblResult.Text = "失败！";
                lblIsTip.Visible = true;
                strPathFolderResult += "bad.jpg";
                picTip.BackgroundImage = Image.FromFile(strPathFolderResult);
            }
            if (F_ProdName != null)
            {
                lblProdName.Text = F_ProdName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
