using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.InformationPlatform.Site.ViewModel;
using Fx.Infrastructure.Caching;
using FxCacheService.FxCar;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 汽车列表控制器
    /// </summary>
    public class CarListController : Controller
    {
        private CarCache carCache;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="carCache">车辆缓存</param>
        public CarListController(CarCache carCache)
        {
            this.carCache = carCache;
        }

        /// <summary>
        /// 汽车列表首页
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            var model = new CarListModel();
            model.SecondHandCars = carCache.GetCarSecondHandCarList();
            return View(model);
        }

    }
}
