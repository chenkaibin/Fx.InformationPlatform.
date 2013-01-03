using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Entity.Catagroy;
using Fx.Entity.FxCar;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxCar;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 车辆求购搜索控制器
    /// </summary>
    public class CarBuySearchController : Controller
    {
        private CarCache carCache;
        /// <summary>
        /// 用于一般检索
        /// </summary>
        private Fx.Domain.Base.IService.ISiteSearch<CarBuyInfo> siteCarSearch;
 
        private Fx.Domain.Base.IService.ICarSearch<CarBuyInfo> carSearch;
        /// <summary>
        ///  默认构造函数
        /// </summary>
        /// <param name="carCache">车辆缓存</param>
        /// <param name="siteCarSearch">大频道帖子关键字查询接口</param>
        /// <param name="carSearch">车辆交易检索接口</param>
        /// <param name="siteCache">站点缓存</param>
        public CarBuySearchController(CarCache carCache,
            Fx.Domain.Base.IService.ISiteSearch<CarBuyInfo> siteCarSearch,
            Fx.Domain.Base.IService.ICarSearch<CarBuyInfo> carSearch,
            SiteCache siteCache)
        {
            this.carCache = carCache;
            this.siteCarSearch = siteCarSearch;
            this.carSearch = carSearch;
        }

        /// <summary>
        /// 奥迪页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Audi(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyAudi().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Audi, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 宝马页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult BMW(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyBMW().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.BMW, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 别克页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Buick(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyBuick().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Buick, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 雪铁龙页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Citroen(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyCitroen().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Citroen, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 福特页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Ford(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyFord().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Ford, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 本田页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Honda(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyHonda().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Honda, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 丰田页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Toyota(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyToyota().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Toyota, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 日产页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Nissan(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyNissan().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Nissan, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

         /// <summary>
        ///  MINI页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult MINI(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyMINI().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.MINI, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 奔驰页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult MercedesBenz(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyMercedesBenz().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.MercedesBenz, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 标致页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Peugeot(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyPeugeot().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Peugeot, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 大众页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult VW(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyVW().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.VW, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 沃尔沃页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Volvo(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuyVolvo().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.Volvo, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 其他品牌页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult SecondHandCarOther(int id)
        {
            var model = new CarBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainCars = carCache.GetMainCarBuySecondHandCarOther().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainCars.Count == 100)
                {
                    model.MainCars = carSearch.SearchByCatagroy(ChannelListDetailCatagroy.SecondHandCarOther, (id - 1), 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

    }
}
