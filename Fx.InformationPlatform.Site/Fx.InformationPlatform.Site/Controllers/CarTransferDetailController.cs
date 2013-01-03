using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxAggregate.IService;
using Fx.Domain.FxCar.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 车辆转让详情控制器
    /// </summary>
    public class CarTransferDetailController : Controller
    {
        private ITransferCar transferCar;
        private IFavorite favorite;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="transferCar">车辆转让保存读取接口</param>
        /// <param name="favorite">收藏接口</param>
        public CarTransferDetailController(ITransferCar transferCar,
            IFavorite favorite)
        {
            this.transferCar = transferCar;
            this.favorite = favorite;
        }

        /// <summary>
        /// 车辆转让详情首页
        /// </summary>
        /// <param name="id">帖子id</param>
        /// <returns>View</returns>
        public ActionResult Index(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            else
            {
                var car = transferCar.Get(id);
                if (car == null)
                {
                    return RedirectToAction("PageNotFound", "PageLink");
                }
                if (User.Identity.IsAuthenticated)
                {
                    var isFav = favorite.IsFavorite((int)Fx.Entity.ChannelCatagroy.FxCarTransfer, id, User.Identity.Name);
                    ViewBag.IsFav = isFav;
                }
                else
                {
                    ViewBag.IsFav = false;
                }
                return View(car);
            }
        }

        /// <summary>
        /// 车辆转让信息收藏
        /// </summary>
        /// <param name="infoId">帖子id</param>
        /// <returns>View</returns>
        public ActionResult Favorite(int infoId)
        {
            if (infoId > 0 && User.Identity.IsAuthenticated)
            {
                var car = transferCar.Get(infoId);
                var ret = favorite.AddFavorite(new Entity.FxAggregate.Favorite()
                {
                    ChannelCatagroy = (int)Fx.Entity.ChannelCatagroy.FxCarTransfer,
                    InfoId = infoId,
                    Title = car.PublishTitle,
                    UserAccount = User.Identity.Name
                });
                if (ret.isSuccess)
                {
                    TempData["Tip"] = "收藏成功";
                }
                else
                {
                    TempData["Tip"] = ret.ResultMsg;
                }
            }
            else
            {
                TempData["Tip"] = "收藏失败,您没有登录,请先登陆";
            }
            return RedirectToAction("Index", new { id = infoId });
        }

    }
}
