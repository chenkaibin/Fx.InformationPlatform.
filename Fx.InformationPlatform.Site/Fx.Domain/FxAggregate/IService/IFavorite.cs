using System.Collections.Generic;
using Fx.Entity.FxAggregate;

namespace Fx.Domain.FxAggregate.IService
{
    /// <summary>
    /// 收藏接口
    /// </summary>
    public interface IFavorite
    {
        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="favorite"></param>
        /// <returns></returns>
        DomainResult AddFavorite(Favorite favorite);

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="favorite"></param>
        /// <returns></returns>
        DomainResult DeleteFavorite(Favorite favorite);

        /// <summary>
        /// 获取收藏信息
        /// </summary>
        /// <param name="ChannelCatagroy">频道</param>
        /// <param name="infoId">帖子id</param>
        /// <param name="accountUser">用户帐号</param>
        /// <returns>收藏信息</returns>
        Favorite GetFavorite(int ChannelCatagroy, int infoId, string accountUser);

        /// <summary>
        /// 获取帐号下所有的收藏信息
        /// </summary>
        /// <param name="accountUser">帐号</param>
        /// <returns>收藏信息列表</returns>
        List<Favorite> GetFavorite(string accountUser);

        /// <summary>
        /// 根据Id获取收藏信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Favorite GetById(int id);

        /// <summary>
        /// 查询帖子是否已收藏
        /// </summary>
        /// <param name="ChannelCatagroy">频道</param>
        /// <param name="infoId">帖子id</param>
        /// <param name="accountUser">帐号</param>
        /// <returns>是收已收藏</returns>
        bool IsFavorite(int ChannelCatagroy, int infoId, string accountUser);
    }
}
