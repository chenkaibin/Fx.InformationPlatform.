using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxHouse;

namespace Fx.Domain.FxHouse.IService
{
    /// <summary>
    /// 房屋求购保存读取接口
    /// </summary>
    public interface IBuyHouse
    {
        /// <summary>
        /// 获取房屋求购信息
        /// </summary>
        /// <param name="Id">房屋求购Id</param>
        /// <returns>房屋求购信息</returns>
        HouseBuyInfo Get(int Id);

        /// <summary>
        /// 保存房屋求购信息
        /// </summary>
        /// <param name="car">房屋求购信息</param>
        /// <returns>是否保存成功</returns>
        bool SaveBuyHouse(HouseBuyInfo goods);
    }
}
