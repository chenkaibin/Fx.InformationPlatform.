using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxHouse
{
    /// <summary>
    /// 房屋转让日志
    /// </summary>
    public class HouseTransferLog
    {
        /// <summary>
        /// 房屋转让日志主键Id
        /// </summary>
        public int HouseTransferLogId { get; set; }

        /// <summary>
        /// 操作名称
        /// </summary>
        public string OperteName { get; set; }

        /// <summary>
        /// 操作来源 
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperteTime { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HouseTransferLog()
        {
            this.OperteTime = DateTime.Now;
        }
    }
}
