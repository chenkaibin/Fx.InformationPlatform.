using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.Account.IService;
using Fx.Domain.FxHouse.IService;
using Fx.Domain.FxSite.IService;
using Fx.Entity.FxHouse;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 房屋求购控制器 
    /// </summary>
#if DEBUG

#else
    [Authorize]    
#endif
    public class HouseBuyController : BaseController, ISiteJob
    {
        private IHouse houseService;
        private IBuyHouse buyService;
        private IAccountService accountService;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="houseService">站点下房屋基础信息接口</param>
        /// <param name="buyService">房屋求购保存读取接口</param>
        /// <param name="accountService">帐号服务接口</param>
        public HouseBuyController(IHouse houseService,
            IBuyHouse buyService,
            IAccountService accountService)
        {
            this.houseService = houseService;
            this.buyService = buyService;
            this.accountService = accountService;
        }

        /// <summary>
        /// 商业用房页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CommercialProperties()
        {
            BindData();
            return View();
        }

        /// <summary>
        /// 居住用房页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Properties()
        {
            BindData();
            return View();
        }

        /// <summary>
        /// 商业用房发布
        /// </summary>
        /// <param name="house">房屋求购视图模型</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult CommercialProperties(BuyViewHouse house)
        {
            return PublishHouse(house);
        }

        /// <summary>
        /// 居住用房发布
        /// </summary>
        /// <param name="house">房屋求购视图模型</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Properties(BuyViewHouse house)
        {
            return PublishHouse(house);
        }

        private ActionResult PublishHouse(BuyViewHouse house)
        {
            if (BuildHouse(house))
            {
                HouseBuyInfo transferhouse = MapperCar(house);
                buyService.SaveBuyHouse(transferhouse);
                RunJob();
                FxCacheService.FxSite.GlobalCache cache = System.Web.Mvc.DependencyResolver.Current.GetService<FxCacheService.FxSite.GlobalCache>();
                cache.InfoPublishAllCountAdd();
                return View("Success");
            }
            return View("FaildTransfer");
        }

        private bool BuildHouse(BuyViewHouse car)
        {
            InitParas();
            return true;
        }

        private HouseBuyInfo MapperCar(BuyViewHouse house)
        {
            var info = new HouseBuyInfo();
            info.Bill = house.Bill;
            info.HasFurniture = house.HasFurniture;
            info.CatagroyId = house.CatagroyId;
            info.AreaId = house.AreaId;
            info.RoomNumber = house.RoomNumber;
            info.Controller = this.ControllerName;
            info.Action = this.ActionName;
            info.CityId = house.CityId;
            info.Mark = house.Mark;
            info.Price = (int)house.Price;
            info.PublishTitle = house.Title;
            info.PublishUserEmail = house.Email;
            info.UserAccount = User.Identity.Name;

            return info;
        }

        private void BindData()
        {
            BindCatagroy();
            BindArea();
        }

        private void BindArea()
        {
            var siteCache = System.Web.Mvc.DependencyResolver.Current.GetService<SiteCache>();
            ViewData["area"] = siteCache.GetAreaListItems();
        }

        private void BindCatagroy()
        {
            InitParas();
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择物品类别--" });
            houseService.GetChannelBuyDetail(this.ControllerName, this.ActionName).ForEach(r => details.Add(new SelectListItem() { Text = r.ChannelListDetailName, Value = r.ChannelListDetailId.ToString() }));
            ViewData["catagroy"] = details;
        }

        /// <summary>
        /// Job运行
        /// </summary>
        public void RunJob()
        {
            new System.Threading.Thread(() =>
            {
                new FxTask.FxHouse.Buy.HouseBuyJobLoad().Execute();
            }).Start();
        }
    }
}
