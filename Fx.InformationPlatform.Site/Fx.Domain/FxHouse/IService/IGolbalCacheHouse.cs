using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxHouse.IService
{
    /// <summary>
    /// 全局缓存房屋统计接口
    /// </summary>
    public interface IGolbalCacheHouse
    {
        /// <summary>
        /// 房屋帖子数量
        /// </summary>
        /// <returns></returns>
        int InfoCount();
    }
}
