using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.IService.UserCenter
{
    /// <summary>
    /// 用户中心之物品接口
    /// </summary>
    public interface IGoodsUserCenter
    {
        /// <summary>
        /// 根据用户获取所有的物品转让信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        List<GoodsTransferInfo> GetTransfers(string email);

        /// <summary>
        ///  根据用户获取所有的物品求购信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        List<GoodsBuyInfo> GetBuys(string email);

        /// <summary>
        /// 管理员获取所有的物品转让信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        List<GoodsTransferInfo> GetAdminTransfers(int page);

        /// <summary>
        /// 管理员获取所有的物品求购信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        List<GoodsBuyInfo> GetAdminBuys(int page);
    }
}
