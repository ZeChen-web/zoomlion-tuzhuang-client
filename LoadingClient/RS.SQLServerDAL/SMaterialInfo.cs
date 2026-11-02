using RS.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.SQLServerDAL
{
    /// <summary>
    /// 查询所有物料信息
    /// </summary>
    public class SMaterialInfo
    {
        /// <summary>
        /// 查询物料编码
        /// </summary>
        /// <param name="line_code"></param>
        /// <returns></returns>
        public DataTable DTMaterialInfo(string line_code)
        {
            DataTable dtresult = null;
            try
            {
                StringBuilder selectString = new StringBuilder();
                selectString.AppendLine("SELECT * FROM `t_mi_material_info`" +
                    " WHERE line_code='" + line_code + "'");
                MySqlHelper sHelper = new MySqlHelper();
                dtresult = sHelper.QuerySql(selectString.ToString());
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dtresult;
        }

    }
}
