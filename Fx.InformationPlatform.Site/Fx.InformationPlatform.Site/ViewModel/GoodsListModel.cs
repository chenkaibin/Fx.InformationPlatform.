using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxGoods;

namespace Fx.InformationPlatform.Site.ViewModel
{
    /// <summary>
    /// 物品列表结果视图模型
    /// </summary>
    public class GoodsListModel
    { 
        /// <summary>
        /// 数码产品列表信息
        /// </summary>
        public List<GoodsTransferInfo> Electronics { get; set; }

        /// <summary>
        /// 居家用品列表信息
        /// </summary>
        public List<GoodsTransferInfo> HomeSupplies { get; set; }

        /// <summary>
        /// 衣服鞋包列表信息
        /// </summary>
        public List<GoodsTransferInfo> Fashions { get; set; }

        /// <summary>
        /// 文化生活列表信息
        /// </summary>
        public List<GoodsTransferInfo> CultureLifes { get; set; }

        /// <summary>
        /// 其他列表信息
        /// </summary>
        public List<GoodsTransferInfo> Others { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public GoodsListModel()
        {
            this.Electronics = new List<GoodsTransferInfo>();
            this.HomeSupplies = new List<GoodsTransferInfo>();
            this.Fashions = new List<GoodsTransferInfo>();
            this.CultureLifes = new List<GoodsTransferInfo>();
            this.Others = new List<GoodsTransferInfo>();
        }
    }
}