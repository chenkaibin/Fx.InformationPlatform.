using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxGoods.IService
{
    /// <summary>
    /// 全局物品缓存接口
    /// </summary>
    public interface IGlobalCacheGoods
    {
        /// <summary>
        /// 帖子数量
        /// </summary>
        /// <returns></returns>
        int InfoCount();
    }
}
