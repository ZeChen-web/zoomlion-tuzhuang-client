using HslCommunication.Profinet.Siemens;
using Newtonsoft.Json;
using RS.BLL;
using RS.Common;
using RS.Model;
using RS.RealTimeDBO;
using Sunny.UI;
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
    public partial class FrmStopLibrary : Form
    {
        DataGridViewHandle gridHdl = new DataGridViewHandle();
        private delegate void SetTxtCallBack(string msg);
        private SetTxtCallBack MsgDlgOptBarCode;
        UIPage uiPage = new UIPage();
        BSpecifyToStore BSpecifyToStore = new BSpecifyToStore();
        DataTable dTable = new DataTable();
        /// <summary>
        /// 获取鼠标选中的行
        /// </summary>
        int MouseSelectedRow = -1;
        /// <summary>
        /// 构造函数
        /// </summary>
        public FrmStopLibrary()
        {
            InitializeComponent();
            try
            {
                MsgDlgOptBarCode = new SetTxtCallBack(DisplayTxtOptLogin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 在文本框中显示主机条形码
        /// </summary>
        private void DisplayTxtOptLogin(string msg)
        {
            if (uiDataGridView1.InvokeRequired)
            {
                uiDataGridView1.Invoke(MsgDlgOptBarCode, msg);
            }
            else
            {
                //uiLabelMesss.Text = msg;
            }
        }

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStopLibrary_Load(object sender, EventArgs e)
        {
            // 窗体最大化
            //this.WindowState = FormWindowState.Maximized;

            string strTip = "正在加载...";
            FrmWaitingBox f = new FrmWaitingBox((obj, args) =>
            {
                dTable = BSpecifyToStore.MSpecifyToStoreDataTable();//获取DataTable所有数据，准备进行查询
            }, 120, strTip, true, false);
            f.ShowDialog(this);            
            uiDataGridView1.DataSource = dTable;
            GenerateDataGridViewColumns();
            ////取消跨线程检查
            //Control.CheckForIllegalCrossThreadCalls = false;

        }
        private void GenerateDataGridViewColumns()  // 生成DataGridView列
        {
            uiDataGridView1.Columns[0].HeaderText = "序号";
            uiDataGridView1.Columns[1].HeaderText = "产线编码";
            uiDataGridView1.Columns[2].HeaderText = "移行机编码";
            uiDataGridView1.Columns[3].HeaderText = "缓存区编码";
            uiDataGridView1.Columns[4].HeaderText = "是否停库";
            uiDataGridView1.Columns[5].HeaderText = "更新时间";
            gridHdl._dbgrid = uiDataGridView1;
            gridHdl.GenerateBaseDataGridView();
        }
        // <summary>
        /// 鼠标按钮按下时发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvJobOrderInfo_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.RowIndex >= 0)
                {
                    uiDataGridView1.ClearSelection();
                    uiDataGridView1.Rows[e.RowIndex].Selected = true;
                    if (uiDataGridView1.Rows.Count > 0)
                    {
                        MouseSelectedRow = e.RowIndex;
                        string sel = uiDataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString().Trim();
                        uiPage.ShowSuccessTip("已选择移行机" + sel);
                    }
                }
            }
        }

        /// <summary>
        /// 停/开库
        /// 入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAssign_Click(object sender, EventArgs e)
        {
            if (MouseSelectedRow != -1)
            {
                bool b1 = Convert.ToBoolean(uiDataGridView1.Rows[MouseSelectedRow].Cells[4].Value);
                string MageText = b1 == false ? "停" : "开"; 
                string message = uiDataGridView1.Rows[MouseSelectedRow].Cells[2].Value.ToString().Trim();
                string id= uiDataGridView1.Rows[MouseSelectedRow].Cells[0].Value.ToString().Trim();
                DialogResult dgRst = MessageBox.Show(this, String.Format("您确认要{0}{1}的库!", MageText, message), "警告", MessageBoxButtons.OKCancel);
                if (dgRst == DialogResult.OK)
                {
                    MageText = MageText == "停" ? "1" : "0";
                    bool bSuccess = BSpecifyToStore.UpdateSpecifyToStore(MageText, id);
                    if (bSuccess)
                    {
                        uiPage.ShowWarningDialog("成功");
                        FrmStopLibrary_Load(sender, e);
                    }
                }
            }
            else
            {
                uiPage.ShowWarningDialog("您未选择库存!");
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
