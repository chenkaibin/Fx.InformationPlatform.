using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxSite
{
    /// <summary>
    /// 物品新旧基础信息
    /// </summary>
    public class GoodsCondition
    {
        /// <summary>
        /// 物品新旧基础信息主键Id
        /// </summary>
        public int GoodsConditionId { get; set; }

        /// <summary>
        /// 二手物品新旧基础信息名称
        /// </summary>
        public string GoodsConditionName { get; set; }

        /// <summary>
        /// 二手物品新旧基础信息描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sorted { get; set; }

        /// <summary>
        /// 是否需要一些填写扩展信息
        /// </summary>
        public bool IsHasMessage { get; set; }

        /// <summary>
        /// 相关扩展信息 如一些损坏的信息
        /// </summary>
        public string PlaceHolder { get; set; }
    }
}
