using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxHouse.IService;

namespace Fx.Domain.FxHouse
{
    /// <summary>
    /// 全局缓存房屋统计
    /// </summary>
    public class GlobalHouseCache : IGolbalCacheHouse
    {
        /// <summary>
        /// 房屋帖子数量(求购+转让)
        /// </summary>
        /// <returns></returns>
        public int InfoCount()
        {
            using (var context = new FxHouseContext())
            {
                return context.HouseBuyInfos.Count() + context.HouseTransferInfos.Count();
            }
        }
    }
}
