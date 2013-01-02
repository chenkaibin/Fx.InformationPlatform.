using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar.IService
{
    /// <summary>
    /// 车辆求购保存读取接口
    /// </summary>
    public interface IBuyCar
    {
        /// <summary>
        /// 获取车辆求购信息
        /// </summary>
        /// <param name="Id">车辆求购Id</param>
        /// <returns>车辆求购信息</returns>
        CarBuyInfo Get(int Id);

        /// <summary>
        /// 保存车辆求购信息
        /// </summary>
        /// <param name="car">车辆求购信息</param>
        /// <returns>是否保存成功</returns>
        bool SaveBuyCar(CarBuyInfo car);
    }
}
