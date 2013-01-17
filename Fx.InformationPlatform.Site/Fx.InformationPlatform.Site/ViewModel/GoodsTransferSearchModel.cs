using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Entity.FxGoods;
using Fx.Entity.FxSite;
using FxCacheService.FxGoods;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.ViewModel
{
    /// <summary>
    /// 物品转让查询结果视图模型
    /// </summary>
    public class GoodsTransferSearchModel : SearchBase
    {
        /// <summary>
        /// 右部分 暂时是空 
        /// </summary>
        public List<GoodsTransferInfo> RightGoods { get; set; }

        /// <summary>
        /// 物品查询返回结果
        /// </summary>
        public List<GoodsTransferInfo> MainGoods { get; set; }

        /// <summary>
        /// 物品置顶信息
        /// </summary>
        public List<GoodsTransferInfo> TopGoods { get; set; }

        /// <summary>
        /// 是否按换物
        /// </summary>
        public bool IsChangeByGoods { get; set; }

        /// <summary>
        /// 是否按价格
        /// </summary>
        public bool IsChangeByPrice { get; set; }

        /// <summary>
        /// 三级频道相关数据
        /// </summary>
        public List<ChannelList> ClcDatas
        {
            get
            {
                return siteCache.GetGoodsChannel();
            }
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="id">当前第几页</param>
        public GoodsTransferSearchModel(int id)
            : base()
        {
            CheckModel();
            this.CurrentIndex = id;
            this.IsChangeByGoods = true;
            this.IsChangeByPrice = true;
            this.TopGoods = DependencyResolver.Current.GetService<GoodsCache>().GetGoodsTransferTopShow();
        }

        /// <summary>
        /// 检查模型
        /// </summary>
        public override void CheckModel()
        {
            this.RightGoods = this.RightGoods == null ? new List<GoodsTransferInfo>() : this.RightGoods;
            this.MainGoods = this.MainGoods == null ? new List<GoodsTransferInfo>() : this.MainGoods;
            this.TopGoods = this.TopGoods == null ? new List<GoodsTransferInfo>() : this.TopGoods;
        }
    }
}