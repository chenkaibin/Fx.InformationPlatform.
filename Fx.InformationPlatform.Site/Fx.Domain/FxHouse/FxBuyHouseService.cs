using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxHouse.IService;

namespace Fx.Domain.FxHouse
{
    /// <summary>
    /// 房屋求购保存读取服务
    /// </summary>
    public class FxBuyHouseService : IBuyHouse
    {
        /// <summary>
        /// 获取房屋求购信息
        /// </summary>
        /// <param name="Id">房屋求购Id</param>
        /// <returns>房屋求购信息</returns>
        public Entity.FxHouse.HouseBuyInfo Get(int Id)
        {
            using (FxHouseContext context = new FxHouseContext())
            {
                return context.HouseBuyInfos.Where(r => r.HouseBuyInfoId == Id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 保存房屋求购信息
        /// </summary>
        /// <param name="house">房屋求购信息</param>
        /// <returns>是否保存成功</returns>
        public bool SaveBuyHouse(Entity.FxHouse.HouseBuyInfo house)
        {
            using (FxHouseContext context = new FxHouseContext())
            {
                context.HouseBuyInfos.Add(house);
                context.SaveChanges();
            }
            return house.HouseBuyInfoId > 0;
        }
    }
}
