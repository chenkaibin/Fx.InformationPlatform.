using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxCar.IService
{
    /// <summary>
    /// 全局缓存车辆统计接口
    /// </summary>
    public interface IGlobalCacheCar
    {
        /// <summary>
        /// 帖子的数量
        /// </summary>
        /// <returns></returns>
        int InfoCount();
    }
}
