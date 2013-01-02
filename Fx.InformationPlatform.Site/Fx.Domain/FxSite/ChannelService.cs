using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Fx.Entity.FxSite;
using Fx.Infrastructure;

namespace Fx.Domain.FxSite
{
    /// <summary>
    /// 一级频道服务
    /// </summary>
    public class ChannelService : IService.IChannelService
    {
        /// <summary>
        /// 获取所有的一级频道列表
        /// </summary>
        /// <returns></returns>
        public List<Channel> GetAllChannels()
        {
            using (var content = new SiteContext())
            {
                return content.Channels.Include(r=>r.ChannelLists).OrderBy(r => r.Sorted).ToList();
            }
        }
    }
}
