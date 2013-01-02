using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Fx.Domain.FxGoods.IService;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods
{
    /// <summary>
    /// 车辆转让保存读取服务
    /// </summary>
    public class FxTransferGoodService : ITransferGoods
    {
        /// <summary>
        /// 获取物品转让信息
        /// </summary>
        /// <param name="Id">物品转让Id</param>
        /// <returns>物品转让信息</returns>
        public Entity.FxGoods.GoodsTransferInfo Get(int  Id)
        {
            using (FxGoodsContext context = new FxGoodsContext())
            {
                return context.GoodsTransferInfos.Include(r => r.Pictures)
                    .Where(r => r.GoodsTransferInfoId == Id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 保存物品转让信息
        /// </summary>
        /// <param name="goods">物品转让信息</param>
        /// <returns>是否保存成功</returns>
        public bool SaveTransferGoods(GoodsTransferInfo goods)
        {
            using (FxGoodsContext context = new FxGoodsContext())
            {
                context.GoodsTransferInfos.Add(goods);
                context.SaveChanges();
            }
            return goods.GoodsTransferInfoId > 0;
        }
    }
}
