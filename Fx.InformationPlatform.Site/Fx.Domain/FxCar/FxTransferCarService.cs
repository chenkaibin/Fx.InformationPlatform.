using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Fx.Domain.FxCar.IService;

namespace Fx.Domain.FxCar
{
    /// <summary>
    /// 车辆转让保存读取服务
    /// </summary>
    public class FxTransferCarService : ITransferCar
    {
        /// <summary>
        /// 获取车辆转让信息
        /// </summary>
        /// <param name="Id">车辆转让Id</param>
        /// <returns>车辆转让信息</returns>
        public Entity.FxCar.CarTransferInfo Get(int Id)
        {
            using (FxCarContext context = new FxCarContext())
            {
                return context.CarTransferInfos.Include(r => r.Pictures)
                    .Where(r => r.CarTransferInfoId == Id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 保存车辆转让信息
        /// </summary>
        /// <param name="car">车辆转让信息</param>
        /// <returns>是否保存成功</returns>
        public bool SaveTransferCar(Entity.FxCar.CarTransferInfo car)
        {
            using (FxCarContext context = new FxCarContext())
            {
                context.CarTransferInfos.Add(car);
                context.SaveChanges();
            }
            return car.CarTransferInfoId > 0;
        }
    }
}
