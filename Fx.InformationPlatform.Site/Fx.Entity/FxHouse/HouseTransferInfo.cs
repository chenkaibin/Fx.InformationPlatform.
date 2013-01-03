using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxHouse
{
    /// <summary>
    /// 房屋转让帖子
    /// </summary>
    public class HouseTransferInfo : HouseBase
    {
        /// <summary>
        /// 房屋转让帖子主键Id
        /// </summary>
        public int HouseTransferInfoId { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string RoadName { get; set; }

        /// <summary>
        /// 房屋转让帖子相关图片信息
        /// </summary>
        public virtual List<TransferPicture> Pictures { get; set; }

        /// <summary>
        /// 房屋转让帖子相关日志记录
        /// </summary>
        public virtual ICollection<HouseTransferLog> Logs { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HouseTransferInfo()
        {
            this.Pictures = new List<TransferPicture>();
            this.Logs = new List<HouseTransferLog>();
        }
    }
}
