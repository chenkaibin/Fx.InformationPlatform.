using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fx.Domain.FxAggregate.IService;
using Fx.Entity;
using Fx.Entity.FxAggregate;

namespace Fx.Domain.FxAggregate
{
    /// <summary>
    /// 收藏服务
    /// </summary>
    public class FavoriteService : IFavorite
    {
        protected IAggregateInfo aggregateInfoService;
        public FavoriteService(IAggregateInfo aggregateInfoService)
        {
            this.aggregateInfoService = aggregateInfoService;
        }

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="favorite"></param>
        /// <returns></returns>
        public DomainResult AddFavorite(Entity.FxAggregate.Favorite favorite)
        {

            using (var context = new FxAggregateContext())
            {
                var fav = GetFavorite(favorite.ChannelCatagroy, favorite.InfoId, favorite.UserAccount);
                if (fav != null)
                {
                    return new DomainResult(false) { ResultMsg = "您已对此帖子进行收藏了" };
                }
                var info = aggregateInfoService.GetInfoByCatatgroyAndId(favorite.ChannelCatagroy, favorite.InfoId);
                if (info == null || aggregateInfoService.IsValid(info) == false)
                {
                    return new DomainResult(false) { ResultMsg = "您不能对此帖子进行收藏(可能已删除或者未发布)" };
                }
                else
                {
                    context.Favorites.Add(favorite);
                    context.SaveChanges();
                    return DomainResult.GetDefault();
                }
            }
        }

        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="favorite"></param>
        /// <returns></returns>
        public DomainResult DeleteFavorite(Entity.FxAggregate.Favorite favorite)
        {
            using (var context = new FxAggregateContext())
            {
                favorite = context.Favorites.Where(r => r.FavoriteId == favorite.FavoriteId).FirstOrDefault();
                if (favorite != null)
                {
                    context.Favorites.Remove(favorite);
                    context.SaveChanges();
                    return DomainResult.GetDefault();
                }
                else
                {
                    return new DomainResult(false) { ResultMsg = "收藏失败，此帖子可能已被删除" };
                }
            }
        }

        /// <summary>
        /// 获取收藏信息
        /// </summary>
        /// <param name="ChannelCatagroy">频道</param>
        /// <param name="infoId">帖子id</param>
        /// <param name="accountUser">用户帐号</param>
        /// <returns>收藏信息</returns>
        public Favorite GetFavorite(int ChannelCatagroy, int infoId, string userAccount)
        {
            using (var context = new FxAggregateContext())
            {
                return context.Favorites
                    .Where(r => r.ChannelCatagroy == ChannelCatagroy &&
                              r.InfoId == infoId &&
                              r.UserAccount == userAccount).FirstOrDefault();
            }
        }

        /// <summary>
        /// 获取帐号下所有的收藏信息
        /// </summary>
        /// <param name="accountUser">帐号</param>
        /// <returns>收藏信息列表</returns>
        public List<Favorite> GetFavorite(string accountUser)
        {
            using (var context = new FxAggregateContext())
            {
                return context.Favorites
                    .Where(r => r.UserAccount == accountUser).ToList();
            }
        }

        /// <summary>
        /// 根据Id获取收藏信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Favorite GetById(int id)
        {
            using (var context = new FxAggregateContext())
            {
                return context.Favorites
                    .Where(r => r.FavoriteId == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// 查询帖子是否已收藏
        /// </summary>
        /// <param name="ChannelCatagroy">频道</param>
        /// <param name="infoId">帖子id</param>
        /// <param name="accountUser">帐号</param>
        /// <returns>是否已收藏</returns>
        public bool IsFavorite(int ChannelCatagroy, int infoId, string accountUser)
        {
            return GetFavorite(ChannelCatagroy, infoId, accountUser) != null;
        }
    }
}
