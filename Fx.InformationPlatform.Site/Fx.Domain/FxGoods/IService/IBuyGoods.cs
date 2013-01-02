using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods.IService
{
    /// <summary>
    /// 物品求购保存读取接口
    /// </summary>
    public interface IBuyGoods
    {
        /// <summary>
        /// 获取物品求购信息
        /// </summary>
        /// <param name="Id">物品求购Id</param>
        /// <returns>物品求购信息</returns>
        GoodsBuyInfo Get(int Id);

        /// <summary>
        /// 保存物品求购信息
        /// </summary>
        /// <param name="car">物品求购信息</param>
        /// <returns>是否保存成功</returns>
        bool SaveBuyGoods(GoodsBuyInfo goods);
    }
}
