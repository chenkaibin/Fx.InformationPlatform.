using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Fx.Entity.Catagroy
{
    /// <summary>
    /// 汽车英里描述枚举
    /// </summary>
    public enum MileCatagroy
    {
        /// <summary>
        /// 100英里以下 = 1
        /// </summary>
        [Description("100英里以下")]
        _100英里以下 = 1,

        /// <summary>
        /// 5000英里以下 = 2
        /// </summary>
        [Description("5000英里以下")]
        _5000英里以下 = 2,

        /// <summary>
        /// 10000英里以下 = 3
        /// </summary>
        [Description("10000英里以下")]
        _10000英里以下 = 3,

        /// <summary>
        /// 20000英里以下 = 4
        /// </summary>
        [Description("20000英里以下")]
        _20000英里以下 = 4,
        
        /// <summary>
        /// 40000英里以下 = 5
        /// </summary>
        [Description("40000英里以下")]
        _40000英里以下 = 5,

        /// <summary>
        /// 60000英里以下 = 6
        /// </summary>
        [Description("60000英里以下")]
        _60000英里以下 = 6,

        /// <summary>
        /// 80000英里以下 = 7
        /// </summary>
        [Description("80000英里以下")]
        _80000英里以下 = 7,

        /// <summary>
        /// 100000英里以下 = 8
        /// </summary>
        [Description("100000英里以下")]
        _100000英里以下 = 8,

        /// <summary>
        /// 100000英里以上 = 9
        /// </summary>
        [Description("100000英里以上")]
        _100000英里以上 = 9
    }
}
