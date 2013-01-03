using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxAggregate
{
    /// <summary>
    /// 私信
    /// </summary>
    public class PrivateMessage
    {
        /// <summary>
        /// 私信主键Id
        /// </summary>
        public int PrivateMessageId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 感兴趣的对象帐号
        /// </summary>
        public string InterestingEmail { get; set; }

        /// <summary>
        /// 频道
        /// </summary>
        public int ChannelCatagroy { get; set; }

        /// <summary>
        /// 发帖子的用户
        /// </summary>
        public string UserAccount { get; set; }

        /// <summary>
        /// 私信内容
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 帖子Id
        /// </summary>
        public int SourceId { get; set; }

        /// <summary>
        /// 默认构造
        /// </summary>
        public PrivateMessage()
        {
            this.CreatedTime = DateTime.Now;
        }
    }
}
