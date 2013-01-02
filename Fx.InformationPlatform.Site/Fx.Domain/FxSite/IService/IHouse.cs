using System.Collections.Generic;
using Fx.Entity.FxSite;

namespace Fx.Domain.FxSite.IService
{
    /// <summary>
    /// 站点下房屋基础信息（基本不变）接口
    /// </summary>
    public interface IHouse
    {
        /// <summary>
        /// 根据路由获取房屋转让三级明细列表
        /// </summary>
        /// <param name="ControllerName">控制器名称</param>
        /// <param name="ActionName">方法名称</param>
        /// <returns>三级明细列表</returns>
        List<ChannelListDetail> GetChannelTransferDetail(string ControllerName, string ActionName);

        /// <summary>
        /// 根据路由获取房屋求购三级明细列表
        /// </summary>
        /// <param name="ControllerName">控制器名称</param>
        /// <param name="ActionName">方法名称</param>
        /// <returns>三级明细列表</returns>
        List<ChannelListDetail> GetChannelBuyDetail(string ControllerName, string ActionName);
    }
}
