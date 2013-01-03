using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Fx.Entity.Catagroy
{
    /// <summary>
    /// 物品转让新旧程度枚举
    /// </summary>
    public enum GoodsTransferConditionCatagroy
    {
        /// <summary>
        /// 未开封，配件齐全，全新
        /// </summary>
        [Description("未开封，配件齐全，全新")]
        至少未开封配件齐全全新 = 1,

        /// <summary>
        /// 无磨损，配件齐全，功能齐全
        /// </summary>
        [Description("无磨损，配件齐全，功能齐全")]
        至少无磨损配件齐全功能齐全 = 2,

        /// <summary>
        /// 有磨损或配件不齐全，功能齐全
        /// </summary>
        [Description("有磨损或配件不齐全，功能齐全")]
        至少有磨损或配件不齐全功能齐全 = 3,

        /// <summary>
        /// 配件齐全，部分功能不可用
        /// </summary>
        [Description("配件齐全，部分功能不可用")]
        至少配件齐全部分功能不可用 = 4,

        /// <summary>
        /// 配件不全，部分功能不可用
        /// </summary>
        [Description("配件不全，部分功能不可用")]
        至少配件不全部分功能不可用 = 5
    }

    /// <summary>
    /// 物品求购新旧程度枚举
    /// </summary>
    public enum GoodsBuyConditionCatagroy
    {
        /// <summary>
        /// 至少未开封，配件齐全，全新
        /// </summary>
        [Description("至少未开封，配件齐全，全新")]
        至少未开封配件齐全全新 = 1,

        /// <summary>
        /// 至少无磨损，配件齐全，功能齐全
        /// </summary>
        [Description("至少无磨损，配件齐全，功能齐全")]
        至少无磨损配件齐全功能齐全 = 2,

        /// <summary>
        /// 至少有磨损或配件不齐全，功能齐全
        /// </summary>
        [Description("至少有磨损或配件不齐全，功能齐全")]
        至少有磨损或配件不齐全功能齐全 = 3,

        /// <summary>
        /// 至少配件齐全，部分功能不可用
        /// </summary>
        [Description("至少配件齐全，部分功能不可用")]
        至少配件齐全部分功能不可用 = 4,

        /// <summary>
        /// 至少配件不全，部分功能不可用
        /// </summary>
        [Description("至少配件不全，部分功能不可用")]
        至少配件不全部分功能不可用 = 5
    }

}
