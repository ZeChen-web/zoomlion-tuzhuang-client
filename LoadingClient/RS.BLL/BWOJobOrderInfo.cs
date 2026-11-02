using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using RS.Model;
using RS.SQLServerDAL;
using RS.Common;

namespace RS.BLL
{
    public class BWOJobOrderInfo
    {
        SWOJobOrderInfo sdalJobOrderInfo = new SWOJobOrderInfo();


        /// <summary>
        /// 根据机台设备编号查询已派工的派工单信息表(当天)--（当天的派工单指的是已派工的派工单，按照工单优先级排序）
        /// </summary>
        /// <param name="srcStationNo">机台设备编号</param>
        /// <returns>已派工单信息</returns>
        public DataTable GetJobOrderInfoTableByStationNo(string srcStationNo)
        {
            return sdalJobOrderInfo.GetJobOrderInfoTableByStationNo(srcStationNo);
        }

        /// <summary>
        /// 根据机台设备编号查询已派工的派工单信息列表(当天)--（当天的派工单指的是已派工的派工单，按照工单优先级排序）
        /// </summary>
        /// <param name="srcStationNo">机台设备编号</param>
        /// <returns>已派工单信息</returns>
        public List<MWOJobOrderInfo> GetJobOrderInfoListByStationNo(string srcStationNo)
        {
            return sdalJobOrderInfo.GetJobOrderInfoListByStationNo(srcStationNo);
        }

        /// <summary>
        /// 根据机台设备编号查询已派工的派工单信息(当天)--（当天的派工单指的是已派工的派工单，按照工单优先级排序）
        /// </summary>
        /// <param name="srcStationNo">机台设备编号</param>
        /// <returns>已派工单信息</returns>
        public MWOJobOrderInfo GetCurrentJobOrderInfoByStationNo(string srcStationNo)
        {
            return sdalJobOrderInfo.GetCurrentJobOrderInfoByStationNo(srcStationNo);
        }

        /// <summary>
        /// 根据派工单号查询派工单信息
        /// </summary>
        /// <param name="srcJobOrderNo">派工单号</param>
        /// <returns>派工单信息</returns>
        public MWOJobOrderInfo GetJobOrderInfoByJobOrderNo(string srcJobOrderNo)
        {
            return sdalJobOrderInfo.GetJobOrderInfoByJobOrderNo(srcJobOrderNo);
        }

        /// <summary>
        /// 根据机台设备编号列表查询已派工的派工单信息表(当天)--（当天的派工单指的是已派工的派工单，按照工单优先级排序）
        /// </summary>
        /// <param name="srcStationNoList">机台设备编号列表</param>
        /// <returns>已派工单信息表</returns>
        public DataTable GetJobOrderInfoTableByStationNoList(List<string> srcStationNoList)
        {
            return sdalJobOrderInfo.GetJobOrderInfoTableByStationNoList(srcStationNoList);
        }

        /// <summary>
        /// 更新当前生产派工单信息
        /// </summary>
        /// <param name="srcJobOrderInfo">当前派工单信息</param>
        public void UpdateCurrentJobOrderInfo(MWOJobOrderInfo jdInfo)
        {
            sdalJobOrderInfo.UpdateCurrentJobOrderInfo(jdInfo);
        }

    }
}
