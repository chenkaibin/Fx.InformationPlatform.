using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxSite
{
    /// <summary>
    /// 频道分类明细 三级列表
    /// </summary>
    public class ChannelListDetail : IAction
    {
        /// <summary>
        /// 频道分类明细主键Id
        /// </summary>
        public int ChannelListDetailId { get; set; }

        /// <summary>
        /// 频道列表名称
        /// </summary>
        public string ChannelListDetailName { get; set; }

        /// <summary>
        /// 频道列表简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sorted { get; set; }

        /// <summary>
        /// 所在的控制器 针对MVC个性化的东西
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// 所处的Action 针对MVC个性化的东西
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 路由参数 针对MVC个性化的东西
        /// </summary>
        public string RoutePars { get; set; }
    }
}
