using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.Account.IService;
using Fx.Domain.FxCar.IService;
using Fx.Domain.FxSite.IService;
using Fx.Entity.FxCar;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 汽车求购发布控制器
    /// </summary>
#if DEBUG

#else
    [Authorize]    
#endif
    public class CarBuyController : BaseController, ISiteJob
    {
        private ICar carService;
        private IBuyCar buyService;
        private IAccountService accountService;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="carService">站点下车辆基础信息接口</param>
        /// <param name="buyService">车辆求购保存读取接口</param>
        /// <param name="accountService">帐号服务接口</param>
        public CarBuyController(ICar carService ,
            IBuyCar buyService,
            IAccountService accountService)
        {
            this.carService = carService;
            this.buyService = buyService;
            this.accountService = accountService;
        }

        /// <summary>
        /// 发布二手车页面
        /// </summary>
        /// <returns></returns>
        public ActionResult SecondHandCar()
        {
            BindData();
            return View();
        }

        /// <summary>
        /// 二手车发布
        /// </summary>
        /// <param name="car">车辆求购信息视图模型</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SecondHandCar(BuyViewCar car)
        {
            return PublishCar(car);
        }

        /// <summary>
        /// 车辆发布
        /// </summary>
        /// <param name="car">车辆求购信息视图模型</param>
        /// <returns>跳转成功页面或者失败页面</returns>
        private ActionResult PublishCar(BuyViewCar car)
        {
            if (BuildCar(car))
            {
                CarBuyInfo buycar = MapperCar(car);
                buyService.SaveBuyCar(buycar);
                RunJob();
                FxCacheService.FxSite.GlobalCache cache = System.Web.Mvc.DependencyResolver.Current.GetService<FxCacheService.FxSite.GlobalCache>();
                cache.InfoPublishAllCountAdd();
                return View("Success");
            }
            return View("FaildTransfer");
        }




        private bool BuildCar(BuyViewCar car)
        {
            InitParas();
            return true;
        }

        private CarBuyInfo MapperCar(BuyViewCar car)
        {
            var info = new CarBuyInfo();
            info.CarMileage = car.CarMileage;
            info.CarYear = car.CarYear;          
            info.CatagroyId = car.CatagroyId;
            info.AreaId = car.AreaId;;
            info.Controller = this.ControllerName;
            info.Action = this.ActionName;
            info.CityId = car.CityId;
            info.Mark = car.Mark;
            info.Price = (int)car.Price;
            info.PublishTitle = car.Title;
            info.PublishUserEmail = car.Email;
            info.UserAccount = User.Identity.Name;            
            return info;
        }

        #region BindData
        private void BindData()
        {
            BindArea();
            BindCatagroy();
            BindCarYear();
            BindCarMileage();
        }

        private void BindArea()
        {
            var siteCache=System.Web.Mvc.DependencyResolver.Current.GetService<SiteCache>();
            ViewData["area"] = siteCache.GetAreaListItems();
        }

        private void BindCarMileage()
        {
            ViewData["carMileage"] = GetCarMileageDetail();
        }

        private void BindCarYear()
        {
            ViewData["carYear"] = GetCarYearDetail();
        }

        private void BindCatagroy()
        {
            InitParas();
            ViewData["catagroy"] = GetCatagroyDetail();
        }

        [OutputCache(Duration = 3600)]
        private List<SelectListItem> GetCatagroyDetail()
        {
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择车辆类别--" });
            carService.GetChannelBuyDetail(this.ControllerName, this.ActionName).ForEach(r => details.Add(new SelectListItem() { Text = r.ChannelListDetailName, Value = r.ChannelListDetailId.ToString() }));
            return details;
        }


        [OutputCache(Duration = 3600)]
        private List<SelectListItem> GetCarYearDetail()
        {
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择生产年份--" });
            carService.GetCarShowYear().ForEach(r => details.Add(new SelectListItem() { Text = r.ToString()+"以后", Value = r.ToString() }));
            return details;
        }

        [OutputCache(Duration = 3600)]
        private object GetCarMileageDetail()
        {
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择里程数--" });
            foreach (var item in carService.GetCarMileage())
            {
                details.Add(new SelectListItem() { Value = item.Key.ToString(), Text = item.Value });
            }
            return details;
        }
        #endregion

        /// <summary>
        /// 发布成功后运行的Job
        /// </summary>
        public void RunJob()
        {
            new System.Threading.Thread(() =>
            {
                new FxTask.FxCar.Buy.CarBuyJobLoad().Execute();
            }).Start();
        }
    }
}
