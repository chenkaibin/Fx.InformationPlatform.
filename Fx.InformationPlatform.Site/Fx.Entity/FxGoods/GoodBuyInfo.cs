using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxGoods
{
    /// <summary>
    /// 物品求购帖子
    /// </summary>
    public class GoodsBuyInfo : GoodsBase
    {
        /// <summary>
        /// 物品求购帖子主键Id
        /// </summary>
        public int GoodsBuyInfoId { get; set; }

        /// <summary>
        /// 新旧程度Id
        /// </summary>
        public int GoodsconditonId { get; set; }

        /// <summary>
        /// 物品功能问题描述
        /// </summary>
        public string GoodsConditionMsg { get; set; }

        /// <summary>
        /// 物品求购帖子相关图片信息
        /// </summary>
        public virtual List<BuyPicture> Pictures { get; set; }

        /// <summary>
        /// 物品求购帖子相关日志信息
        /// </summary>
        public virtual ICollection<GoodsBuyLog> Logs { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public GoodsBuyInfo()
        {
            this.Pictures = new List<BuyPicture>();
            this.Logs = new List<GoodsBuyLog>();
        }
    }
}
