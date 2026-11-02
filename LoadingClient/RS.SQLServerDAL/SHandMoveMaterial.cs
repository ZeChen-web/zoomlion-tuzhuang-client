using RS.DBUtility;
using RS.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.SQLServerDAL
{
    public class SHandMoveMaterial
    {
        public bool SaveHandMoveMaterial(MHandMoveMaterial mHandMoveMaterial)
        {
            bool bResult = false;
            try
            {
                string strsql = "INSERT INTO t_ts_hand_move";
                strsql += " " + "(WorkStation,slingMaterial,SlingNo,TC,MaterialCode,MaterialName,aisle,MageText,CreatTime)";
                strsql += " " + "VALUES(";
                strsql += " " + "'" + mHandMoveMaterial.WorkStation + "',";
                strsql += " " + "'" + mHandMoveMaterial.slingMaterial + "',";
                strsql += " " + "'" + mHandMoveMaterial.SlingNo + "',";
                strsql += " " + "'" + mHandMoveMaterial.TC + "',";
                strsql += " " + "'" + mHandMoveMaterial.MaterialCode + "',";
                strsql += " " + "'" + mHandMoveMaterial.MaterialName + "',";
                strsql += " " + "'" + mHandMoveMaterial.aisle + "',";
                strsql += " " + "'" + mHandMoveMaterial.MageText + "',";
                strsql += " " + "'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
                strsql += " " + ")";
                MySqlHelper sHelper = new MySqlHelper();
                bResult = sHelper.ExecuteBNonQuerySQL(strsql);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return bResult;
        }

        public DataTable DataTableHandMoveMaterial(string workStation)
        {
            DataTable dtResult = null;
            try
            {
                DataTable dtTempJobInfo = null;
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT id as 派工单优先级,workStation as 工位,slingMaterial as 全部编码,SlingNo as 吊具号,TC as 移行机类型,MaterialCode as 物料编码,MaterialName as 物料名称,aisle as 库存通道,MageText as 描述,CreatTime as 创建时间 " + " ");
                selectString.AppendLine("FROM `t_ts_hand_move`" + " ");
                selectString.AppendLine("WHERE workStation='"+ workStation + "'" + " ");
                selectString.AppendLine("AND MageText!='成功'" + " ");
                selectString.AppendLine("ORDER BY id ASC" + " ");

                MySqlHelper sHelper = new MySqlHelper();
                DataTable dtJobOrderInfo = null;
                dtJobOrderInfo = sHelper.QuerySql(selectString.ToString());

                if (dtJobOrderInfo != null)
                {
                    if (dtJobOrderInfo.Rows.Count > 0)
                    {
                        if (dtTempJobInfo != null)
                        {
                            dtTempJobInfo.Merge(dtJobOrderInfo);
                        }
                        else
                        {
                            dtTempJobInfo = new DataTable();
                            dtTempJobInfo = dtJobOrderInfo.Copy();
                        }
                    }
                }
                if (dtTempJobInfo != null)
                {
                    DataView dv = dtTempJobInfo.DefaultView;
                    dv.Sort = "派工单优先级 asc";
                    dtResult = dv.ToTable();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dtResult;
        }

    }
}
