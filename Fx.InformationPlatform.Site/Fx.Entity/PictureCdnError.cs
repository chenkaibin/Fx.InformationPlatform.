using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
    /// <summary>
    /// 图片Cdn错误信息
    /// </summary>
    public class PictureCdnError
    {
        /// <summary>
        /// 图片Cdn错误信息Id
        /// </summary>
        public int PictureCdnErrorId { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErorMsg { get; set; }

        /// <summary>
        /// 关联对象Id
        /// </summary>
        public int ObjectId { get; set; }

        /// <summary>
        /// 来源对象类型 ChannelCatagroy
        /// </summary>      
        public int SourceType { get; set; }
    }
}
