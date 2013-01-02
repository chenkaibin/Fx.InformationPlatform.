using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxCar.IService;
using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar
{
    /// <summary>
    /// 车辆求购保存读取服务
    /// </summary>
    public class FxBuyCarService : IBuyCar
    {
        /// <summary>
        /// 获取车辆求购信息
        /// </summary>
        /// <param name="Id">车辆求购Id</param>
        /// <returns>车辆求购信息</returns>
        public Entity.FxCar.CarBuyInfo Get(int Id)
        {
            using (FxCarContext context = new FxCarContext())
            {
                return context.CarBuyInfos
                    .Where(r => r.CarBuyInfoId == Id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 保存车辆求购信息
        /// </summary>
        /// <param name="car">车辆求购信息</param>
        /// <returns>是否保存成功</returns>
        public bool SaveBuyCar(CarBuyInfo car)
        {
            using (FxCarContext context = new FxCarContext())
            {
                context.CarBuyInfos.Add(car);
                context.SaveChanges();
            }
            return car.CarBuyInfoId > 0;
        }
    }
}
