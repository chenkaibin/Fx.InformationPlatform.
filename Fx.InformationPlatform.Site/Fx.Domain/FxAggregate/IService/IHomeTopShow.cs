using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxAggregate.IService
{
    /// <summary>
    /// 首页获取置顶数据相关接口 只读
    /// </summary>
    public interface IHomeTopShow
    {
        /// <summary>
        /// 获取首页车辆的置顶展示
        /// </summary>
        /// <returns></returns>
        List<Fx.Entity.FxCar.CarTransferInfo> GetHomeCarTopShow();

        /// <summary>
        /// 获取首页物品的置顶展示
        /// </summary>
        /// <returns></returns>
        List<Fx.Entity.FxGoods.GoodsTransferInfo> GetHomeGoodsTopShow();

        /// <summary>
        /// 获取首页房屋的置顶展示
        /// </summary>
        /// <returns></returns>
        List<Fx.Entity.FxHouse.HouseTransferInfo> GetHomeHouseTopShow();
    }
}
