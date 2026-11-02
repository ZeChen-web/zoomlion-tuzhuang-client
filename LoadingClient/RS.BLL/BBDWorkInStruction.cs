using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RS.Model;
using RS.SQLServerDAL;
using RS.Common;

namespace RS.BLL
{

    public class BBDWorkInStruction
    {

        SBDWorkInStruction sdalWorkInStruction = new SBDWorkInStruction();

        /// <summary>
        /// 得到工艺指导书文件夹路径列表（根据机台设备编号，产品编码，工序编码）
        /// </summary>
        /// <param name="srcProdNo">产品编码</param>
        /// <param name="srcProcessNo">工序编码</param>
        /// <returns>工艺指导书基础信息表</returns>
        public List<string> GetWorkInStructionFolderPathList(string srcProdNo, string srcProcessNo)
        {
            return sdalWorkInStruction.GetWorkInStructionFolderPathList(srcProdNo, srcProcessNo);
        }

    }

}
