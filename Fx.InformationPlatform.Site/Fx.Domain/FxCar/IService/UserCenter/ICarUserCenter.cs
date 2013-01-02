using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar.IService.UserCenter
{
    /// <summary>
    /// 用户中心之车辆接口
    /// </summary>
    public interface ICarUserCenter
    {
        /// <summary>
        /// 根据用户获取所有的车辆转让信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        List<CarTransferInfo> GetTransfers(string email);

        /// <summary>
        ///  根据用户获取所有的车辆求购信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        List<CarBuyInfo> GetBuys(string email);

        /// <summary>
        /// 管理员获取所有的车辆转让信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        List<CarTransferInfo> GetAdminTransfers(int page);

        /// <summary>
        /// 管理员获取所有的车辆求购信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        List<CarBuyInfo> GetAdminBuys(int page);
    }
}
