using RS.SQLServerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.BLL
{
    /// <summary>
    /// 创建更改请求
    /// </summary>
    public class BSelectInfo
    {
        SSelectInfo sSelectInfo = new SSelectInfo();
        /// <summary>
        /// 建立更改请求
        /// </summary>
        /// <param name="cache_area">库区号</param>
        /// <param name="request">请求(0无请求1请求更改2同意更改3更改完成)</param>
        /// <returns></returns>
        public bool SetRequest(int cache_area, int request)
        {
            return sSelectInfo.SetRequest(cache_area, request);
        }
        /// <summary>
        /// 查询是否同意更改
        /// </summary>
        /// <param name="cache_area">库区号</param>
        /// <param name="request">请求(0无请求1请求更改2同意更改3更改完成)</param>
        /// <returns></returns>
        public int agreeRequest(int cache_area)
        {
            return sSelectInfo.agreeRequest(cache_area);
        }
        /// <summary>
        /// 收到请求后发送同意
        /// </summary>
        /// <param name="cache_area">库区号</param>
        /// <param name="request">请求</param>
        /// <returns></returns>
        public bool UpdateRequest(int cache_area, int request)
        {
            return sSelectInfo.UpdateRequest(cache_area,request);
        }
    }
}
