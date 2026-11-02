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
    public class BDataBaseManage
    {
        SDataBaseManage sdalDataBaseManage = new SDataBaseManage();

        /// <summary>
        /// 数据库是否连接
        /// </summary>
        /// <returns></returns>
        public bool DBIsConnected()
        {
            return sdalDataBaseManage.DBIsConnected();
        }
    }
}
