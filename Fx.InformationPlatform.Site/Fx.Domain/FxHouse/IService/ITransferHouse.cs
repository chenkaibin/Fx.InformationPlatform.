using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse.IService
{
    /// <summary>
    /// 房屋转让保存读取接口
    /// </summary>
    public interface ITransferHouse
    {
        /// <summary>
        /// 获取房屋转让信息
        /// </summary>
        /// <param name="Id">房屋转让Id</param>
        /// <returns>房屋转让信息</returns>
        HouseTransferInfo Get(int Id);

        /// <summary>
        /// 保存房屋转让信息
        /// </summary>
        /// <param name="car">房屋转让信息</param>
        /// <returns>是否保存成功</returns>
        bool SaveTransferHouse(HouseTransferInfo goods);
    }
}
