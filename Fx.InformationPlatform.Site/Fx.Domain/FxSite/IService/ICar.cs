using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity.FxSite;

namespace Fx.Domain.FxSite.IService
{
    /// <summary>
    /// 站点下车辆基础信息（基本不变）接口
    /// </summary>
    public interface ICar
    {
        /// <summary>
        /// 根据路由获取车辆转让三级明细列表
        /// </summary>
        /// <param name="ControllerName">控制器名称</param>
        /// <param name="ActionName">方法名称</param>
        /// <returns>三级明细列表</returns>
        List<ChannelListDetail> GetChannelTransferDetail(string ControllerName, string ActionName);

        /// <summary>
        /// 根据路由获取车辆求购三级明细列表
        /// </summary>
        /// <param name="ControllerName">控制器名称</param>
        /// <param name="ActionName">方法名称</param>
        /// <returns>三级明细列表</returns>
        List<ChannelListDetail> GetChannelBuyDetail(string ControllerName, string ActionName);

        /// <summary>
        /// 获取汽车允许显示的生产年份
        /// </summary>
        /// <returns>生产年份列表</returns>
        List<int> GetCarShowYear();

        /// <summary>
        ///  获取汽车显示的英里数
        /// </summary>
        /// <returns>英里数和其相关描述</returns>
        Dictionary<int,string> GetCarMileage();
    }
}
