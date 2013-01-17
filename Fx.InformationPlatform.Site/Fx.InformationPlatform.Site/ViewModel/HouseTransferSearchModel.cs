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
    /// 房屋转让查询结果视图模型
    /// </summary>
    public class HouseTransferSearchModel : SearchBase
    {
        /// <summary>
        /// 右部分 暂时是空 
        /// </summary>
        public List<HouseTransferInfo> RightHouse { get; set; }

        /// <summary>
        /// 房屋查询返回结果
        /// </summary>
        public List<HouseTransferInfo> MainHouse { get; set; }

        /// <summary>
        /// 房屋置顶信息
        /// </summary>
        public List<HouseTransferInfo> TopHouse { get; set; }

        /// <summary>
        /// 三级频道相关数据
        /// </summary>
        public List<ChannelListDetail> ClcDatas
        {
            get
            {
                return siteCache.GetHouseTransferChannel();
            }
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="id">当前第几页</param>
        public HouseTransferSearchModel(int id)
            : base()
        {
            CheckModel();
            this.CurrentIndex = id;
            this.TopHouse = DependencyResolver.Current.GetService<HouseCache>().GetHouseTransferTopShow();
        }

        /// <summary>
        /// 检查模型
        /// </summary>
        public override void CheckModel()
        {
            this.RightHouse = this.RightHouse == null ? new List<HouseTransferInfo>() : this.RightHouse;
            this.MainHouse = this.MainHouse == null ? new List<HouseTransferInfo>() : this.MainHouse;
            this.TopHouse = this.TopHouse == null ? new List<HouseTransferInfo>() : this.TopHouse;
        }
    }
}