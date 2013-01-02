using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using Fx.Domain.FxGoods.IService.UserCenter;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.UserCenterImp
{
    /// <summary>
    /// 用户中心之物品服务
    /// </summary>
    public class GoodsUserCenter : IGoodsUserCenter
    {
        /// <summary>
        /// 根据用户获取所有的物品转让信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<GoodsTransferInfo> GetTransfers(string email)
        {
            using (var content = new FxGoodsContext())
            {
                return content.GoodsTransferInfos
                    .Where(r => r.IsDelete == false && r.UserAccount == email)
                    .ToList();
            }
        }

        /// <summary>
        ///  根据用户获取所有的物品求购信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public List<GoodsBuyInfo> GetBuys(string email)
        {
            using (var content = new FxGoodsContext())
            {
                return content.GoodsBuyInfos
                    .Where(r => r.IsDelete == false && r.UserAccount == email)
                    .ToList();
            }
        }

        /// <summary>
        /// 管理员获取所有的物品转让信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public List<GoodsTransferInfo> GetAdminTransfers(int page = 0)
        {
            using (var content = new FxGoodsContext())
            {
                return content.GoodsTransferInfos
                    .OrderByDescending(r => r.GoodsTransferInfoId)
                    .Where(r => r.IsDelete == false && r.IsPublish == true)
                    .Skip(page * 100).Take(100)
                    .ToList();
            }
        }

        /// <summary>
        /// 管理员获取所有的物品求购信息
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns></returns>
        public List<GoodsBuyInfo> GetAdminBuys(int page = 0)
        {
            using (var content = new FxGoodsContext())
            {
                return content.GoodsBuyInfos
                    .OrderByDescending(r => r.GoodsBuyInfoId)
                    .Where(r => r.IsDelete == false && r.IsPublish == true)
                    .Skip(page * 100).Take(100)
                    .ToList();
            }
        }
    }
}
