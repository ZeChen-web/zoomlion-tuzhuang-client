using RS.Model;
using RS.SQLServerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.BLL
{
    public class BCacheOut
    {
        SCacheOut sCacheOut = new SCacheOut();
        public bool InsertCacheOut(MCacheOut mCacheOut)
        {
            return sCacheOut.InsertCacheOut(mCacheOut);
        }
        public bool DeleteCacheOut(MCacheOut mCacheOut)
        {
            return sCacheOut.DeleteCacheOut(mCacheOut);
        }

        /// <summary>
        /// 判断是否已经添加了对应的小车号
        /// </summary>
        /// <param name="mCacheOut"></param>
        /// <returns>设置了true没设置false</returns>
        public bool WhietherInCacheOut(MCacheOut mCacheOut)
        {
            return sCacheOut.WhietherInCacheOut(mCacheOut);
        }
        /// <summary>
        /// 获取小车号和顺序绑定
        /// </summary>
        /// <param name="cache_area">库存</param>
        /// <returns></returns>
        public Dictionary<string, int> xc_id_seq(string cache_area)
        {
            return sCacheOut.xc_id_seq(cache_area);
        }
    }
}
