using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxSite
{
    /// <summary>
    /// 二级频道列表
    /// </summary>
    public class ChannelList : IAction, IPublishAction
    {
        /// <summary>
        /// 默认构造
        /// </summary>
        public ChannelList()
        {
            this.ChannelListDetails = new List<ChannelListDetail>();
        }

        /// <summary>
        /// 二级频道列表主键Id
        /// </summary>
        public int ChannelListId { get; set; }

        /// <summary>
        /// 二级频道列表
        /// </summary>
        public string ChannelListName { get; set; }

        /// <summary>
        /// 频道列表简介
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 二级频道列表所在控制器名称
        /// </summary>
        public string ControllerName { get; set; }

        /// <summary>
        /// 具体二级频道所执行方法名称
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 具体二级频道相关路由参数
        /// </summary>
        public string RoutePars { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sorted { get; set; }

        /// <summary>
        /// 此二级频道下三级频道相关信息
        /// </summary>
        public virtual ICollection<ChannelListDetail> ChannelListDetails { get; set; }

        /// <summary>
        /// 二级频道所对应的转让控制器
        /// </summary>
        public string TransferController { get; set; }

        /// <summary>
        /// 二级频道所对应的求购控制器
        /// </summary>
        public string BuyController { get; set; }
    }
}
