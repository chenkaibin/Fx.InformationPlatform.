using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Fx.Domain.FxHouse.IService;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse
{
    /// <summary>
    /// 房屋转让保存读取服务
    /// </summary>
   public  class FxTransferHouseService:ITransferHouse
    {
        /// <summary>
        /// 获取房屋转让信息
        /// </summary>
        /// <param name="Id">房屋转让Id</param>
        /// <returns>房屋转让信息</returns>
        public Entity.FxHouse.HouseTransferInfo Get(int Id)
        {
            using (FxHouseContext context = new FxHouseContext())
            {
                return context.HouseTransferInfos.Include(r => r.Pictures)
                    .Where(r => r.HouseTransferInfoId == Id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 保存房屋转让信息
        /// </summary>
        /// <param name="house">房屋转让信息</param>
        /// <returns>是否保存成功</returns>
        public bool SaveTransferHouse(HouseTransferInfo house)
        {
            using (var context = new FxHouseContext())
            {
                context.HouseTransferInfos.Add(house);
                context.SaveChanges();
            }
            return house.HouseTransferInfoId > 0;
        }
    }
}
