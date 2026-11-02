using RS.SQLServerDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.BLL
{
    public class BMaterialInfo
    {
        SMaterialInfo SMaterialInfo = new SMaterialInfo();
        /// <summary>
        /// 查询所有物料编码
        /// </summary>
        /// <param name="line_code"></param>
        /// <returns></returns>
        public DataTable DTMaterialInfo(string line_code)
        {
            return SMaterialInfo.DTMaterialInfo(line_code);
        }
    }
}
