using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxHouse
{
    /// <summary>
    /// 房屋求购帖子
    /// </summary>
    public class HouseBuyInfo : HouseBase
    {
        /// <summary>
        /// 房屋求购帖子主键Id
        /// </summary>
        public int HouseBuyInfoId { get; set; }

        /// <summary>
        /// 房屋求购帖子相关日志
        /// </summary>
        public virtual ICollection<HouseBuyLog> Logs { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HouseBuyInfo()
        {
            this.Logs = new List<HouseBuyLog>();
        }
    }
}
