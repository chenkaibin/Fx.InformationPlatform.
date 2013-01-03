using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Entity.FxHouse;
using Fx.Entity.FxSite;
using FxCacheService.FxHouse;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.ViewModel
{
    /// <summary>
    /// 房屋求购查询结果视图模型
    /// </summary>
    public class HouseBuySearchModel : SearchBase
    {
        /// <summary>
        /// 右部分 暂时是空 
        /// </summary>
        public List<HouseBuyInfo> RightHouse { get; set; }

        /// <summary>
        /// 房屋查询返回结果
        /// </summary>
        public List<HouseBuyInfo> MainHouse { get; set; }

        /// <summary>
        /// 房屋置顶信息
        /// </summary>
        public List<HouseBuyInfo> TopHouse { get; set; }

        /// <summary>
        /// 三级频道相关数据
        /// </summary>
        public List<ChannelListDetail> ClcDatas
        {
            get
            {
                return siteCache.GetHouseBuyChannel();
            }
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="id">当前第几页</param>
        public HouseBuySearchModel(int id)
            : base()
        {
            this.CurrentIndex = id;
            this.TopHouse = DependencyResolver.Current.GetService<HouseCache>().GetHouseBuyTopShow();
        }

        /// <summary>
        /// 检查模型
        /// </summary>
        public override void CheckModel()
        {
            this.RightHouse = this.RightHouse == null ? new List<HouseBuyInfo>() : this.RightHouse;
            this.MainHouse = this.MainHouse == null ? new List<HouseBuyInfo>() : this.MainHouse;
            this.TopHouse = this.TopHouse == null ? new List<HouseBuyInfo>() : this.TopHouse;
        }
    }
}