using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxCar
{
    /// <summary>
    /// 汽车求购帖子
    /// </summary>
    public class CarBuyInfo : CarBase
    {
        /// <summary>
        /// 汽车求购帖子主键Id
        /// </summary>
        public int CarBuyInfoId { get; set; }

        /// <summary>
        /// 汽车求购帖子相关日志
        /// </summary>
        public virtual ICollection<CarBuyLog> Logs { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CarBuyInfo()
        {
            this.Logs = new List<CarBuyLog>();
        }
    }
}
