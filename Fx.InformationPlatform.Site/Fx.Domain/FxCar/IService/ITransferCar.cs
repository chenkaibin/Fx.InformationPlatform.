using Fx.Entity.FxCar;

namespace Fx.Domain.FxCar.IService
{
    /// <summary>
    /// 车辆转让保存读取接口
    /// </summary>
    public interface ITransferCar
    {
        /// <summary>
        /// 获取车辆转让信息
        /// </summary>
        /// <param name="Id">车辆转让Id</param>
        /// <returns>车辆转让信息</returns>
        CarTransferInfo Get(int Id);

        /// <summary>
        /// 保存车辆转让信息
        /// </summary>
        /// <param name="car">车辆转让信息</param>
        /// <returns>是否保存成功</returns>
        bool SaveTransferCar(CarTransferInfo car);
    }
}
