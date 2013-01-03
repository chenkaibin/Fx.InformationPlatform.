using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
    /// <summary>
    /// 一级频道枚举
    /// </summary>
    public enum ChannelCatagroy
    {
        /// <summary>
        /// 车辆转让
        /// </summary>
        [Description("车辆转让")]
        FxCarTransfer = 0,
        /// <summary>
        /// 车辆求购
        /// </summary>
        [Description("车辆求购")]
        FxCarBuy = 1,
        /// <summary>
        /// 二手转让
        /// </summary>
        [Description("二手转让")]
        FxGoodsTransfer = 2,
        /// <summary>
        /// 二手转让
        /// </summary>
        [Description("二手转让")]
        FxGoodsBuy = 3,
        /// <summary>
        /// 房屋转让
        /// </summary>
        [Description("房屋转让")]
        FxHouseTrasnfer = 4,
        /// <summary>
        /// 房屋转让
        /// </summary>
        [Description("房屋转让")]
        FxHouseBuy = 5,
    }
}
