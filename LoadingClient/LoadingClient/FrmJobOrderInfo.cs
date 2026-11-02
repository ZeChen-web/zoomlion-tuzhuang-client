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

namespace LoadingClient
{
    public partial class FrmJobOrderInfo : Form
    {
        DataGridViewHandle gridHdl = new DataGridViewHandle();
        BWOJobOrderInfo dalJobOrderInfo = new BWOJobOrderInfo();

        /// <summary>
        /// 已选择派工单
        /// </summary>
        private MWOJobOrderInfo _ChoiceJobOrderInfo = null;
        public FrmJobOrderInfo()
        {
            InitializeComponent();
        }

        private void FrmJobOrderInfo_Load(object sender, EventArgs e)
        {
            // 窗体最大化
            this.WindowState = FormWindowState.Maximized;
            //GenerateDataGridViewColumns();
            LoadData();  //加载数据
        }

        private void GenerateDataGridViewColumns()  // 生成DataGridView列
        {
            gridHdl._dbgrid = dgvJobOrderInfo;
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_ID", HeaderText = "序号", Visible = true });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_BATCHNO", HeaderText = "批次号", Visible = true });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_MONOPARTID", HeaderText = "ID号", Visible = true });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_JOBORDERNO", HeaderText = "派工单号", Visible = true });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_WKORDERNO", HeaderText = "工单号", Visible = false });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_PLANNO", HeaderText = "生产计划号", Visible = false });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_PRIORITYLEVEL", HeaderText = "派工单优先级", Visible = false });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_PRODNO", HeaderText = "产品编码", Visible = true });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_PRODNAME", HeaderText = "产品名称", Visible = true });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_PRODTYPE", HeaderText = "产品型号", Visible = false });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_PRODSPEC", HeaderText = "规格", Visible = false });

            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_PROCESSNO", HeaderText = "工序编号", Visible = false });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_PROCESSNAME", HeaderText = "工序名称", Visible = true });

            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_STATIONNO", HeaderText = "机台设备编号", Visible = false });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_STATIONNAME", HeaderText = "机台设备名称", Visible = true });

            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_QUOTATIME", HeaderText = "额定工时", Visible = false });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_PLANQTY", HeaderText = "计划数量", Visible = false });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_STARTQTY", HeaderText = "投产数量", Visible = false });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_FINISHEDQTY", HeaderText = "已生产数量", Visible = false });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_JOBORDERQTY", HeaderText = "派工数量", Visible = true });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_JOBFSHEDQTY", HeaderText = "完成数量", Visible = true });

            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_UNITID", HeaderText = "单位序号", Visible = false });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_UNITNAME", HeaderText = "单位名称", Visible = false });

            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_OPERATORNUM", HeaderText = "操作人数", Visible = false });

            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_WORKSHOPNO", HeaderText = "车间编码", Visible = false });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_WORKSHOPNAME", HeaderText = "车间名称", Visible = false });

            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_JOBSTART", HeaderText = "计划开工日期", Visible = true });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_JOBEND", HeaderText = "计划结束日期", Visible = true });

            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_STATUS", HeaderText = "生产状态", Visible = false });

            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_CREATOR", HeaderText = "创建者", Visible = false });
            gridHdl._Fields.Add(new DataGridField() { DataPropertyName = "F_CREATIONDATE", HeaderText = "创建时间", Visible = false });

            gridHdl.GenerateBaseDataGridView();
        }

        private void LoadData()
        {
            try
            {
                DataTable dtResult = null;
                List<string> lstStationNo = null;
                if (PublicParams.G_StationInfoList != null && PublicParams.G_StationInfoList.Count > 0)
                {
                    lstStationNo = new List<string>();
                    for (int i = 0; i < PublicParams.G_StationInfoList.Count; i++)
                    {
                        lstStationNo.Add(PublicParams.G_StationInfoList[i].F_STATIONNO);
                    }
                }
                if (lstStationNo != null)
                {
                    dtResult = dalJobOrderInfo.GetJobOrderInfoTableByStationNoList(lstStationNo);
                }
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
                                    _ChoiceJobOrderInfo = jobOrderInfo;

                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 选择工单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChoice_Click(object sender, EventArgs e)
        {
            if (_ChoiceJobOrderInfo != null)
            {
                PublicParams.G_CurrentS1JobOrderInfo = _ChoiceJobOrderInfo;
            }
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 窗体关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
