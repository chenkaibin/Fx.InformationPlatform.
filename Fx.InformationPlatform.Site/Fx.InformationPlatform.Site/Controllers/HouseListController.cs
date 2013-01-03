using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxHouse;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 房屋列表控制器
    /// </summary>
    public class HouseListController : Controller
    {
        private HouseCache houseCache;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="houseCache">房屋缓存</param>
        public HouseListController(HouseCache houseCache)
        {
            this.houseCache = houseCache;
        }

        /// <summary>
        /// 房屋列表首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var model = new HouseListModel();
            model.CommercialProperties = houseCache.GetHouseCommercialPropertiesList();
            model.Properties = houseCache.GetHousePropertiesList();
            return View(model);
        }

    }
}
