using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using Fx.Domain.FxCar.IService.UserCenter;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar.UserCenterImp
{
    /// <summary>
    /// 车辆用户中心服务
    /// </summary>
    public class CarUserCenter : ICarUserCenter
    {
        /// <summary>
        /// 根据用户获取所有的车辆转让信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<CarTransferInfo> GetTransfers(string email)
        {
            using (var content = new FxCarContext())
            {
                return content.CarTransferInfos
                    .Where(r => r.IsDelete == false && r.UserAccount == email)
                    .ToList();
            }
        }

        /// <summary>
        ///  根据用户获取所有的车辆求购信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<CarBuyInfo> GetBuys(string email)
        {
            using (var content = new FxCarContext())
            {
                return content.CarBuyInfos
                    .Where(r => r.IsDelete == false && r.UserAccount == email)
                    .ToList();
            }
        }

        /// <summary>
        /// 管理员获取所有的车辆转让信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public List<CarTransferInfo> GetAdminTransfers(int page = 0)
        {
            using (var content = new FxCarContext())
            {
                return content.CarTransferInfos
                    .OrderByDescending(r => r.CarTransferInfoId)
                    .Where(r => r.IsDelete == false && r.IsPublish == true)
                    .Skip(page * 100).Take(100)
                    .ToList();
            }
        }

        /// <summary>
        /// 管理员获取所有的车辆求购信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public List<CarBuyInfo> GetAdminBuys(int page = 0)
        {
            using (var content = new FxCarContext())
            {
                return content.CarBuyInfos
                    .OrderByDescending(r => r.CarBuyInfoId)
                    .Where(r => r.IsDelete == false && r.IsPublish == true)
                    .Skip(page * 100).Take(100)
                    .ToList();
            }
        }
    }
}
