using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Fx.Domain.FxSite.IService;
using Fx.Infrastructure;
using Fx.Infrastructure.Caching;

namespace Fx.Domain.FxSite
{
    /// <summary>
    /// 站点车辆基础信息服务 
    /// </summary>
    public class CarService : ICar
    {
        /// <summary>
        /// 车辆年份相关数据对应的缓存Key
        /// </summary>
        private readonly string CARKEYYEAR = "Fx.Domain.FxSite.CarService.GetCarShowYear";
        /// <summary>
        /// 车辆英里相关数据对应的缓存Key
        /// </summary>
        private readonly string CARMILEAGE = "Fx.Domain.FxSite.CarService.CARMILEAGE";
        ICacheManager cachemanager;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="cachemanager">缓存接口</param>
        public CarService(ICacheManager cachemanager)
        {
            this.cachemanager = cachemanager;
        }

        /// <summary>
        /// 根据路由获取车辆转让三级明细列表
        /// </summary>
        /// <param name="ControllerName">控制器名称</param>
        /// <param name="ActionName">方法名称</param>
        /// <returns>三级明细列表</returns>
        public List<Entity.FxSite.ChannelListDetail> GetChannelBuyDetail(string ControllerName, string ActionName)
        {
            Fx.Entity.FxSite.ChannelList channelList;
            using (var content = new SiteContext())
            {
                channelList = content.ChannelLists.Include(r => r.ChannelListDetails)
                    .Where(r => r.BuyController == ControllerName
                             && r.ActionName == ActionName).FirstOrDefault();
            }
            if (channelList != null)
            {
                var details = channelList.ChannelListDetails.OrderBy(r => r.Sorted).ToList();
                return details;
            }
            return new List<Entity.FxSite.ChannelListDetail>();
        }

        /// <summary>
        /// 根据路由获取车辆求购三级明细列表
        /// </summary>
        /// <param name="ControllerName">控制器名称</param>
        /// <param name="ActionName">方法名称</param>
        /// <returns>三级明细列表</returns>
        public List<Entity.FxSite.ChannelListDetail> GetChannelTransferDetail(string ControllerName, string ActionName)
        {
            Fx.Entity.FxSite.ChannelList channelList;
            using (var content = new SiteContext())
            {
                channelList = content.ChannelLists.Include(r => r.ChannelListDetails)
                     .Where(r => r.TransferController == ControllerName &&
                         r.ActionName == ActionName).FirstOrDefault();
            }
            if (channelList != null)
            {
                var details = channelList.ChannelListDetails.OrderBy(r => r.Sorted).ToList();
                return details;
            }
            return new List<Entity.FxSite.ChannelListDetail>();
        }


        /// <summary>
        /// 获取汽车允许显示的生产年份 走缓存服务
        /// </summary>
        /// <returns>生产年份列表</returns>
        public List<int> GetCarShowYear()
        {
            if (cachemanager.Get(CARKEYYEAR) == null)
            {
                List<int> years = new List<int>();
                int currentyear = DateTime.Now.Year;
                for (int i = 1995; i <= currentyear; i++)
                {
                    years.Add(i);
                }
                cachemanager.Insert(CARKEYYEAR, years, 3600, System.Web.Caching.CacheItemPriority.Default);
            }
            return cachemanager.Get(CARKEYYEAR) as List<int>;
        }

        /// <summary>
        ///  获取汽车显示的英里数 走缓存服务，具体英里数不保存在相关数据库中
        /// </summary>
        /// <returns>英里数和其相关描述</returns>
        public Dictionary<int, string> GetCarMileage()
        {
            if (cachemanager.Get(CARMILEAGE) == null)
            {
                var carMileage = new Dictionary<int, string>();
                carMileage.Add(1, "100英里以下");
                carMileage.Add(2, "5000英里以下");
                carMileage.Add(3, "10000英里以下");
                carMileage.Add(4, "20000英里以下");
                carMileage.Add(5, "40000英里以下");
                carMileage.Add(6, "60000英里以下");
                carMileage.Add(7, "80000英里以下");
                carMileage.Add(8, "100000英里以下");
                carMileage.Add(9, "100000英里以上");
                cachemanager.Insert(CARMILEAGE, carMileage, 3600, System.Web.Caching.CacheItemPriority.Default);
            }
            return cachemanager.Get(CARMILEAGE) as Dictionary<int, string>;
        }
    }
}
