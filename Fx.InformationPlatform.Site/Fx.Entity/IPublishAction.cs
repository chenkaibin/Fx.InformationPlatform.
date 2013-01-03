using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fx.Entity
{
    /// <summary>
    /// 发布Action所对应的控制器
    /// </summary>
    public interface IPublishAction
    {
        /// <summary>
        /// 发布Action所对应的转让控制器
        /// </summary>
        string TransferController { get; set; }

        /// <summary>
        /// 发布Action所对应的求购控制器
        /// </summary>
        string BuyController { get; set; }
    }
}
