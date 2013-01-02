using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using Fx.Domain.FxGoods.IService;

namespace Fx.Domain.FxGoods
{
    /// <summary>
    /// 物品求购保存读取服务
    /// </summary>
    public class FxBuyGoodsService : IBuyGoods
    {
        /// <summary>
        /// 获取物品求购信息
        /// </summary>
        /// <param name="Id">物品求购Id</param>
        /// <returns>物品求购信息</returns>
        public Entity.FxGoods.GoodsBuyInfo Get(int Id)
        {
            using (FxGoodsContext context = new FxGoodsContext())
            {
                return context.GoodsBuyInfos.Include(r=>r.Pictures)
                    .Where(r => r.GoodsBuyInfoId == Id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 保存物品求购信息
        /// </summary>
        /// <param name="goods">物品求购信息</param>
        /// <returns>是否保存成功</returns>
        public bool SaveBuyGoods(Entity.FxGoods.GoodsBuyInfo goods)
        {
            using (FxGoodsContext context = new FxGoodsContext())
            {
                context.GoodsBuyInfos.Add(goods);
                context.SaveChanges();
            }
            return goods.GoodsBuyInfoId > 0;
        }
    }
}
