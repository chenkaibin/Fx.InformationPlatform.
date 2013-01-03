using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxCar
{
    /// <summary>
    /// 车辆转让帖子
    /// </summary>
    public class CarTransferInfo : CarBase
    {
        /// <summary>
        /// 车辆转让帖子主键Id
        /// </summary>
        public int CarTransferInfoId { get; set; }

        /// <summary>
        /// 车辆转让帖子相关图片
        /// </summary>
        public virtual List<TransferPicture> Pictures { get; set; }

        /// <summary>
        /// 车辆转让帖子相关日志
        /// </summary>
        public virtual ICollection<CarTransferLog> Logs { get; set; }

        /// <summary>
        /// 默认构造
        /// </summary>
        public CarTransferInfo()
        {
            this.Pictures = new List<TransferPicture>();
            this.Logs = new List<CarTransferLog>();
        }
    }
}
