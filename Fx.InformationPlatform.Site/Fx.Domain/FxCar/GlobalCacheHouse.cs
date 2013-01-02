using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxCar.IService;

namespace Fx.Domain.FxCar
{
    /// <summary>
    /// 全局缓存车辆统计服务
    /// </summary>
    public class GlobalCacheCar : IGlobalCacheCar
    {
        /// <summary>
        /// 车辆帖子的数量（ 求购+转让）
        /// </summary>
        /// <returns></returns>
        public int InfoCount()
        {
            using (var context=new FxCarContext())
            {
                return context.CarBuyInfos.Count() + context.CarTransferInfos.Count();
            }
        }
    }
}
