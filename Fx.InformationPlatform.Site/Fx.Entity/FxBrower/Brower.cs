using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity.FxBrower
{
    /// <summary>
    /// 用户浏览器信息
    /// </summary>
    public class Brower
    {
        /// <summary>
        /// 用户浏览器信息主键Id
        /// </summary>
        public int BrowerId { get; set; }

        /// <summary>
        /// 浏览器名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 浏览器版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 浏览器所在系统平台
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// 浏览器ECMA脚本版本
        /// </summary>
        public string ECMAScriptVersion { get; set; }

        /// <summary>
        /// 是否手机用户
        /// </summary>
        public bool IsMobileDevice { get; set; }

        /// <summary>
        /// 浏览器UserAgent信息
        /// </summary>
        public string UserAgentDetails { get; set; }

        /// <summary>
        /// 其他的扩展信息
        /// </summary>
        public string Other { get; set; }

        /// <summary>
        /// 当前用户的SessionId
        /// </summary>
        public string SessionID { get; set; }

        /// <summary>
        /// 浏览器记录创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 默认构造
        /// </summary>
        public Brower()
        {
            this.CreatedTime = DateTime.Now;
        }
    }
}
