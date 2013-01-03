using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxGoods
{
    /// <summary>
    /// 物品转让帖子
    /// </summary>
    public class GoodsTransferInfo : GoodsBase
    {
        /// <summary>
        /// 物品转让帖子主键Id
        /// </summary>
        public int GoodsTransferInfoId { get; set; }

        /// <summary>
        /// 新旧程度Id
        /// </summary>
        public int GoodsconditonId { get; set; }

        /// <summary>
        /// 物品功能问题
        /// </summary>
        public string GoodsConditionMsg { get; set; }
        
        /// <summary>
        /// 物品转让帖子相关图片信息
        /// </summary>
        public virtual List<TransferPicture> Pictures { get; set; }

        /// <summary>
        /// 物品转让帖子相关日志记录
        /// </summary>
        public virtual ICollection<GoodsTransferLog> Logs { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public GoodsTransferInfo()
        {          
            this.Pictures = new List<TransferPicture>();
            this.Logs = new List<GoodsTransferLog>();
        }
    }
}
