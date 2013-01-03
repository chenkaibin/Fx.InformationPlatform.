using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxAggregate
{
    /// <summary>
    /// 我的收藏  当帖子被删除的时候 此信息也要被删除
    /// </summary>
    public class Favorite
    {
        /// <summary>
        /// 我的收藏主键Id
        /// </summary>
        public int FavoriteId { get; set; }

        /// <summary>
        /// 频道
        /// </summary>
        public int ChannelCatagroy { get; set; }

        /// <summary>
        /// 帖子Id
        /// </summary>
        public int InfoId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 收藏创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 用户帐号
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 默认构造
        /// </summary>
        public Favorite()
        {
            this.CreatedTime = DateTime.Now;
        }
    }
}
