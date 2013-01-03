using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxHouse
{
    /// <summary>
    /// 房屋求购日志
    /// </summary>
    public class HouseBuyLog
    {
        /// <summary>
        /// 房屋求购日志主键Id
        /// </summary>
        public int HouseBuyLogId { get; set; }

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
        public HouseBuyLog()
        {
            this.OperteTime = DateTime.Now;
        }
    }
}
