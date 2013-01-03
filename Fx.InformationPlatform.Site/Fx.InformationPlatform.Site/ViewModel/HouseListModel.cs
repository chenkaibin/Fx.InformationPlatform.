using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxHouse;

namespace Fx.InformationPlatform.Site.ViewModel
{
    /// <summary>
    /// 房屋列表视图模型
    /// </summary>
    public class HouseListModel
    {
        /// <summary>
        /// 商业用房列表信息
        /// </summary>
        public List<HouseTransferInfo> CommercialProperties { get; set; }

        /// <summary>
        /// 居住用房列表信息
        /// </summary>
        public List<HouseTransferInfo> Properties { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HouseListModel()
        {
            this.CommercialProperties = new List<HouseTransferInfo>();
            this.Properties = new List<HouseTransferInfo>();
        }
    }
}