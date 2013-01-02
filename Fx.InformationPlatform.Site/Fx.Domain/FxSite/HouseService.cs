using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using Fx.Domain.FxSite.IService;
using Fx.Entity.FxSite;
using Fx.Infrastructure;
using Fx.Infrastructure.Caching;

namespace Fx.Domain.FxSite
{
    /// <summary>
    /// 站点下房屋基础信息服务（基本不变）
    /// </summary>
    public class HouseService : IHouse
    {
        /// <summary>
        /// 根据路由获取房屋转让三级明细列表
        /// </summary>
        /// <param name="ControllerName">控制器名称</param>
        /// <param name="ActionName">方法名称</param>
        /// <returns>三级明细列表</returns>
        public List<Entity.FxSite.ChannelListDetail> GetChannelBuyDetail(string ControllerName, string ActionName)
        {
            ChannelList channelList;
            using (var content = new SiteContext())
            {
                channelList = content.ChannelLists.Include(r => r.ChannelListDetails)
                    .Where(r => r.BuyController == ControllerName && 
                        r.ActionName == ActionName).FirstOrDefault();
            }
            if (channelList != null)
            {
                var details = channelList.ChannelListDetails.OrderBy(r => r.Sorted).ToList();
                return details;
            }
            return new List<Entity.FxSite.ChannelListDetail>();
        }

        /// <summary>
        /// 根据路由获取房屋求购三级明细列表
        /// </summary>
        /// <param name="ControllerName">控制器名称</param>
        /// <param name="ActionName">方法名称</param>
        /// <returns>三级明细列表</returns>
        public List<Entity.FxSite.ChannelListDetail> GetChannelTransferDetail(string ControllerName, string ActionName)
        {
            ChannelList channelList;
            using (var content = new SiteContext())
            {
                channelList = content.ChannelLists.Include(r => r.ChannelListDetails)
                    .Where(r => r.TransferController == ControllerName && 
                        r.ActionName == ActionName).FirstOrDefault();
            }
            if (channelList != null)
            {
                var details = channelList.ChannelListDetails.OrderBy(r => r.Sorted).ToList();
                return details;
            }
            return new List<Entity.FxSite.ChannelListDetail>();
        }
    }
}
