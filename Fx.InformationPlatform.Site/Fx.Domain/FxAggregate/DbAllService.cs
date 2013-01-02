using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxAggregate.IService;

namespace Fx.Domain.FxAggregate
{
    /// <summary>
    /// 数据库聚合统计服务
    /// </summary>
    public class DbAllService : IDbAll
    {
        /// <summary>
        /// 所有帖子的数量
        /// </summary>
        /// <returns>帖子数量</returns>
        public long InfoCount()
        {
            int carBuy = 0;
            int carTransfer = 0;
            int goodsBuy = 0;
            int goodsTransfer = 0;
            int houseBuy = 0;
            int houseTransfer = 0;
            using (var context = new FxCar.FxCarContext())
            {
                carBuy = context.CarBuyInfos.Count();
                carTransfer = context.CarTransferInfos.Count();
            }
            using (var context = new FxGoods.FxGoodsContext())
            {
                goodsBuy = context.GoodsBuyInfos.Count();
                goodsTransfer = context.GoodsTransferInfos.Count();
            }
            using (var context = new FxHouse.FxHouseContext())
            {
                houseBuy = context.HouseBuyInfos.Count();
                houseTransfer = context.HouseTransferInfos.Count();
            }
            return carBuy + carTransfer + goodsBuy + goodsTransfer + houseBuy + houseTransfer;
        }

        /// <summary>
        /// 所有交易已完成的数量
        /// </summary>
        /// <returns>帖子数量</returns>
        public long InfoEndCount()
        {
            int carBuy = 0;
            int carTransfer = 0;
            int goodsBuy = 0;
            int goodsTransfer = 0;
            int houseBuy = 0;
            int houseTransfer = 0;
            using (var context = new FxCar.FxCarContext())
            {
                carBuy = context.CarBuyInfos.Where(r=>r.InfoProcessState==(int)Fx.Entity.ProcessState.End).Count();
                carTransfer = context.CarTransferInfos.Where(r => r.InfoProcessState == (int)Fx.Entity.ProcessState.End).Count();
            }
            using (var context = new FxGoods.FxGoodsContext())
            {
                goodsBuy = context.GoodsBuyInfos.Where(r => r.InfoProcessState == (int)Fx.Entity.ProcessState.End).Count();
                goodsTransfer = context.GoodsTransferInfos.Where(r => r.InfoProcessState == (int)Fx.Entity.ProcessState.End).Count();
            }
            using (var context = new FxHouse.FxHouseContext())
            {
                houseBuy = context.HouseBuyInfos.Where(r => r.InfoProcessState == (int)Fx.Entity.ProcessState.End).Count();
                houseTransfer = context.HouseTransferInfos.Where(r => r.InfoProcessState == (int)Fx.Entity.ProcessState.End).Count();
            }
            return carBuy + carTransfer + goodsBuy + goodsTransfer + houseBuy + houseTransfer;
        }
    }
}
