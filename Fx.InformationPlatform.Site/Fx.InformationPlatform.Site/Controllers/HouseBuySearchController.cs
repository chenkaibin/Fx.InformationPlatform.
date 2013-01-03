using System.Linq;
using System.Web.Mvc;
using Fx.Entity.Catagroy;
using Fx.Entity.FxHouse;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxHouse;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 房屋求购查询控制器
    /// </summary>
    public class HouseBuySearchController : Controller
    {
        private HouseCache houseCache;
        /// <summary>
        /// 用于一般检索
        /// </summary>
        private Fx.Domain.Base.IService.ISiteSearch<HouseBuyInfo> siteHouseSearch;
        /// <summary>
        /// 用于房屋分类查看
        /// </summary>
        private Fx.Domain.Base.IService.IHouseSearch<HouseBuyInfo> houseSearch;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="houseCache">房屋缓存</param>
        /// <param name="siteHouseSearch">大频道帖子关键字查询接口</param>
        /// <param name="houseSearch">房屋交易检索接口</param>
        public HouseBuySearchController(HouseCache houseCache,
            Fx.Domain.Base.IService.ISiteSearch<HouseBuyInfo> siteHouseSearch,
            Fx.Domain.Base.IService.IHouseSearch<HouseBuyInfo> houseSearch)
        {
            this.houseCache = houseCache;
            this.siteHouseSearch = siteHouseSearch;
            this.houseSearch = houseSearch;
        }

        /// <summary>
        /// 展销商铺求购页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Shop(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyShop().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.Shop, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 饮食商铺求购页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Restaurants(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyRestaurants().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.Restaurants, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 仓库求购页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Warehouse(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyWarehouse().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.Warehouse, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 办公室求购页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Office(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyOffice().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.Office, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// House求购页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult House(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyHouse().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.House, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// Flat求购页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Flat(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyFlat().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.Flat, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 学生公寓求购页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult StudentAparment(int id)
        {
            var model = new HouseBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainHouse = houseCache.GetMainHouseBuyStudentAparment().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainHouse.Count == 100)
                {
                    int page = id - 1;
                    model.MainHouse = houseSearch.SearchByCatagroy(ChannelListDetailCatagroy.StudentAparment, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }
    }
}
