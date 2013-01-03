using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Fx.Domain.FxSite.IService;
using Fx.Entity.FxSite;
using Fx.Infrastructure.Caching;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.ViewModel
{
    /// <summary>
    /// 查询结果基类
    /// </summary>
    public class SearchBase
    {
        /// <summary>
        /// 站点缓存
        /// </summary>
        protected SiteCache siteCache;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SearchBase()
        {
            this.siteCache = System.Web.Mvc.DependencyResolver.Current.GetService<SiteCache>();            
        }

        /// <summary>
        /// 区域数据
        /// </summary>
        public List<Fx.Entity.FxSite.Area> Areas
        {
            get
            {
                return siteCache.GetArea();
            }
        }

        /// <summary>
        /// 广告信息
        /// </summary>
        public string Ad { get; set; }

        /// <summary>
        /// 当前所运行的方法
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 区域Id
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 分页栏当前的索引
        /// </summary>
        public int CurrentIndex { get; set; }

        /// <summary>
        /// 三级分类
        /// </summary>
        public int Clc { get; set; }

        /// <summary>
        /// 分页栏开始索引
        /// </summary>
        public int StartIndex
        {
            get
            {
                // 11  1*10+1=11
                // 1  0*10+1=1
                int number = CurrentIndex / 10;
                if (number == 0)
                {
                    return 1;
                }
                return number * 10;
            }
        }

        /// <summary>
        /// 分页栏结束索引
        /// </summary>
        public int EndIndex
        {
            get
            {
                int number = CurrentIndex / 10;
                return (number + 1) * 10;
            }
        }

        /// <summary>
        /// 模型检查
        /// </summary>
        public virtual void CheckModel()
        {

        }
    }
}
