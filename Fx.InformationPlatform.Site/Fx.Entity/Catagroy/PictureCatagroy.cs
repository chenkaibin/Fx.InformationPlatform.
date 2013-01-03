using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
    /// <summary>
    /// 上传图片种类枚举
    /// </summary>
    public enum PictureCatagroy
    {
        /// <summary>
        /// 正面
        /// </summary>
        Head = 0,
        /// <summary>
        /// 侧面或其他
        /// </summary>
        Other = 1,
        /// <summary>
        /// 损坏的图片
        /// </summary>
        Bad = 2
    }
}
