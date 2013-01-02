using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using Fx.Domain.FxHouse.IService.UserCenter;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse.UserCenterImp
{
    /// <summary>
    /// 用户中心房屋服务
    /// </summary>
    public class HouseUserCenter : IHouseUserCenter
    {
        // <summary>
        /// 根据用户获取所有的房屋转让信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<HouseTransferInfo> GetTransfers(string email)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseTransferInfos
                    .Where(r => r.IsDelete == false && r.UserAccount == email)
                    .ToList();
            }
        }

        /// <summary>
        ///  根据用户获取所有的房屋求购信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<HouseBuyInfo> GetBuys(string email)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseBuyInfos
                    .Where(r => r.IsDelete == false && r.UserAccount == email)
                    .ToList();
            }
        }

        /// <summary>
        /// 管理员获取所有的房屋转让信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public List<HouseTransferInfo> GetAdminTransfers(int page = 0)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseTransferInfos
                    .OrderByDescending(r => r.HouseTransferInfoId)
                    .Where(r => r.IsDelete == false && r.IsPublish == true)
                    .Skip(page * 100).Take(100)
                    .ToList();
            }
        }

        /// <summary>
        /// 管理员获取所有的房屋求购信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public List<HouseBuyInfo> GetAdminBuys(int page = 0)
        {
            using (var content = new FxHouseContext())
            {
                return content.HouseBuyInfos
                    .OrderByDescending(r => r.HouseBuyInfoId)
                    .Where(r => r.IsDelete == false && r.IsPublish == true)
                     .Skip(page * 100).Take(100)
                    .ToList();
            }
        }
    }
}
