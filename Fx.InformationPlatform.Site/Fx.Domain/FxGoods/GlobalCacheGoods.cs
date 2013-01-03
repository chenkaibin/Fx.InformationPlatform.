using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxGoods.IService;

namespace Fx.Domain.FxGoods
{
    /// <summary>
    /// 全局缓存物品统计服务
    /// </summary>
    public class GlobalCacheGoods : IGlobalCacheGoods
    {
        /// <summary>
        /// 物品帖子数量（求购+转让）
        /// </summary>
        /// <returns></returns>
        public int InfoCount()
        {
            using (var context = new FxGoodsContext())
            {
                return context.GoodsBuyInfos.Count() + context.GoodsTransferInfos.Count();
            }
        }
    }
}
