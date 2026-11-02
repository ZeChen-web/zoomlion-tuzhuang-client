using RS.Model;
using RS.SQLServerDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.BLL
{
    public class BSpecifyToStore
    {
        SSpecifyToStore SSpecifyToStore = new SSpecifyToStore();
        public bool UpdateSpecifyToStore(string MageText, string id)
        {
            return SSpecifyToStore.UpdateSpecifyToStore(MageText,id);
        }
        public DataTable MSpecifyToStoreDataTable()
        {
            return SSpecifyToStore.MSpecifyToStoreDataTable();
        }
        public List<string> t_ts_cache_stop(string line_code, string aisle)
        {
            return SSpecifyToStore.t_ts_cache_stop(line_code, aisle);
        }
        public bool updateType(string line_code, string aisle, string tc_type)
        {
            return SSpecifyToStore.updateType(line_code, aisle, tc_type);
        }

    }
}
