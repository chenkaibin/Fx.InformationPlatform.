using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxAggregate
{
    /// <summary>
    /// 置顶信息
    /// </summary>
    public class TopShow
    {
        /// <summary>
        /// 置顶信息主键Id
        /// </summary>
        public int TopShowId { get; set; }

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
        /// 图片 暂时不用
        /// </summary>
        public string HeadPicture { get; set; }

        /// <summary>
        /// 转让/求购价格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 置顶创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 默认构造
        /// </summary>
        public TopShow()
        {
            this.CreatedTime = DateTime.Now;
        }
    }
}
