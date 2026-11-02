using RS.BLL;
using RS.Common;
using RS.Model;
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

namespace LoadingClient
{
    public partial class FrmOutboundQuery : Form
    {
        SHandMoveMaterial SHandMoveMaterial = new SHandMoveMaterial();
        string _workStation = "";
        public string F_workStation
        {
            set
            {
                _workStation = value;
            }
        }
        public FrmOutboundQuery()
        {
            InitializeComponent();
        }
        public FrmOutboundQuery(string workStation)
        {
            _workStation = workStation; 
            InitializeComponent();
        }
        private void FrmOutboundQuery_Load(object sender, EventArgs e)
        {
            // 窗体最大化
            this.WindowState = FormWindowState.Maximized;
            //GenerateDataGridViewColumns();
            LoadData();  //加载数据
        }

        private void LoadData()
        {
            try
            {
                DataTable dtResult = null;
                dtResult = SHandMoveMaterial.DataTableHandMoveMaterial(_workStation);
                if (dtResult != null)
                {
                    dgvJobOrderInfo.DataSource = dtResult;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        /// <summary>
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
                    dgvJobOrderInfo.ClearSelection();
                    dgvJobOrderInfo.Rows[e.RowIndex].Selected = true;
                    if (dgvJobOrderInfo.Rows.Count > 0)
                    {
                        string jobOrderNo = dgvJobOrderInfo.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                        if (jobOrderNo != null)
                        {
                            BWOJobOrderInfo dalJobOrderInfo = new BWOJobOrderInfo();
                            MWOJobOrderInfo jobOrderInfo = dalJobOrderInfo.GetJobOrderInfoByJobOrderNo(jobOrderNo);
                            if (jobOrderInfo != null)
                            {
                                if (jobOrderInfo.F_JOBORDERNO != null)
                                {
                                    //_ChoiceJobOrderInfo = jobOrderInfo;

                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoice_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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
