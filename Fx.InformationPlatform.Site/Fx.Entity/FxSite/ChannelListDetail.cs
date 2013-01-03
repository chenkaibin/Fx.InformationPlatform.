using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxSite
{
    /// <summary>
    /// 频道三级列表
    /// </summary>
    public class ChannelListDetail : IAction
    {
        /// <summary>
        /// 频道三级列表主键Id
        /// </summary>
        public int ChannelListDetailId { get; set; }

        /// <summary>
        /// 频道三级列表名称
        /// </summary>
        public string ChannelListDetailName { get; set; }

        /// <summary>
        /// 频道三级列表简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sorted { get; set; }

        /// <summary>
        /// 具体三级频道所在控制器名称
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// 具体三级频道所执行方法名称
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 路由参数 针对MVC个性化的东西
        /// </summary>
        public string RoutePars { get; set; }
    }
}
