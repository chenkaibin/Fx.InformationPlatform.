using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Entity;

namespace Fx.Domain.FxAggregate.IService
{
    /// <summary>
    /// 聚合信息接口
    /// </summary>
    public interface IAggregateInfo
    {
        /// <summary>
        /// 获取帖子
        /// </summary>
        /// <param name="ChannelCatagroy">频道id</param>
        /// <param name="infoId">分散库中的帖子id</param>
        /// <returns>帖子抽像对象（详情对象具体在获取）</returns>
        IInfo GetInfoByCatatgroyAndId(int ChannelCatagroy, int infoId);

        /// <summary>
        /// 帖子是否(可以操作??)发布
        /// </summary>
        /// <param name="info">帖子</param>
        /// <returns>帖子是否可以操作</returns>
        bool IsValid(IInfo info);
    }
}
