using System.Collections.Generic;
using Fx.Entity.FxSite;

namespace Fx.Domain.FxSite.IService
{
    /// <summary>
    /// 一级频道服务接口
    /// </summary>
    public interface IChannelService
    {
        /// <summary>
        /// 获取所有的一级频道列表
        /// </summary>
        /// <returns></returns>
        List<Channel> GetAllChannels();
    }
}
