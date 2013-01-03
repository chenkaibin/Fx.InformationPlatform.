using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxSite
{
    /// <summary>
    /// 一级频道
    /// </summary>
    public class Channel : IAction
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Channel()
        {
            this.ChannelLists = new List<ChannelList>();            
        }

        /// <summary>
        /// 一级频道主键Id
        /// </summary>
        public int ChannelId { get; set; }

        /// <summary>
        /// 一级频道名称
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// 一级频道简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 一级频道下的二级频道列表
        /// </summary>
        public virtual ICollection<ChannelList> ChannelLists { get; set; }

        /// <summary>
        /// 具体一级频道所对应的控制器名称
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// 具体一级频道所执行方法名称
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 路由参数 针对MVC个性化的东西
        /// </summary>
        public string RoutePars { get; set; }

        /// <summary>
        /// 排序 
        /// </summary>
        public virtual int Sorted { get; set; }

    }
}
