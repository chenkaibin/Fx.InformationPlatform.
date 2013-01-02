using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse.IService.UserCenter
{
    /// <summary>
    /// 用户中心之房屋接口
    /// </summary>
    public interface IHouseUserCenter
    {
        // <summary>
        /// 根据用户获取所有的房屋转让信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        List<HouseTransferInfo> GetTransfers(string email);

        /// <summary>
        ///  根据用户获取所有的房屋求购信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        List<HouseBuyInfo> GetBuys(string email);

        /// <summary>
        /// 管理员获取所有的房屋转让信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        List<HouseTransferInfo> GetAdminTransfers(int page);

        /// <summary>
        /// 管理员获取所有的房屋求购信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        List<HouseBuyInfo> GetAdminBuys(int page);
    }
}
