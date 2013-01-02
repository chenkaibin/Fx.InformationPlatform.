using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Fx.Domain.FxSite.IService;
using Fx.Infrastructure;

namespace Fx.Domain.FxSite
{
    /// <summary>
    /// 站点基础信息服务
    /// </summary>
    public class SiteService : ISite
    {
        /// <summary>
        /// 获取所有的地区 顺序排序
        /// </summary>
        /// <returns></returns>
        public List<Entity.FxSite.Area> GetAreas()
        {
            using (var content = new SiteContext())
            {
                return content.Areas.OrderBy(r => r.Sorted).ToList();
            }
        }

        /// <summary>
        /// 获取所有的城市数据
        /// </summary>
        /// <returns></returns>
        public List<Entity.FxSite.City> GetCitys(int AreaId)
        {
            using (var content = new SiteContext())
            {
                return content.Cities.Where(r => r.AreaID == AreaId).OrderBy(r => r.Sorted).ToList();
            }
        }

        /// <summary>
        /// 获取地区对应的城市 顺序排序
        /// </summary>
        /// <returns></returns>
        public List<Entity.FxSite.GoodsCondition> GoodsConditions()
        {
            using (var content = new SiteContext())
            {
                return content.GoodsConditions.OrderBy(r => r.Sorted).ToList();
            }
        }

        /// <summary>
        /// 获取物品信息新旧程度相关信息
        /// </summary>
        /// <returns></returns>
        public List<Entity.FxSite.Area> GetAreaDomain()
        {
            using (var content = new SiteContext())
            {
                return content.Areas.Include(r => r.Cities).ToList();
            }
        }

        /// <summary>
        /// 获取所有的地区包括其级联城市
        /// </summary>
        /// <returns></returns>
        public List<Entity.FxSite.City> GetCities()
        {
            using (var content = new SiteContext())
            {
                return content.Cities.ToList();
            }
        }
    }
}
