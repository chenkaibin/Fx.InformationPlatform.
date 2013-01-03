using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Entity.FxCar;
using Fx.Entity.FxSite;
using FxCacheService.FxCar;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.ViewModel
{
    /// <summary>
    /// 车辆求购查询结果视图模型
    /// </summary>
    public class CarBuySearchModel : SearchBase
    {
        /// <summary>
        /// 右部分 暂时是空 
        /// </summary>
        public List<CarBuyInfo> RightCars { get; set; }

        /// <summary>
        /// 车辆查询返回结果
        /// </summary>
        public List<CarBuyInfo> MainCars { get; set; }

        /// <summary>
        /// 车辆置顶信息
        /// </summary>
        public List<CarBuyInfo> TopCars { get; set; }

        /// <summary>
        /// 三级频道相关数据
        /// </summary>
        public List<ChannelListDetail> ClcDatas
        {
            get
            {
                return siteCache.GetCarBuyChannel();
            }
        }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="id">当前第几页</param>
        public CarBuySearchModel(int id)
            : base()            
        {
            this.CurrentIndex = id;
            this.TopCars = DependencyResolver.Current.GetService<CarCache>().GetCarBuyTopShow();
        }

      
        /// <summary>
        /// 检查模型
        /// </summary>
        public override void CheckModel()
        {
            base.CheckModel();
            this.RightCars = this.RightCars == null ? new List<CarBuyInfo>() : this.RightCars;
            this.MainCars = this.MainCars == null ? new List<CarBuyInfo>() : this.MainCars;
            this.TopCars = this.TopCars == null ? new List<CarBuyInfo>() : this.TopCars;
        }
        
    }
}