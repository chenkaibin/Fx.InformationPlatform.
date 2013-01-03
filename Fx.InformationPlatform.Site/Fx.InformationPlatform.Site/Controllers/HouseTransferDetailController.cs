using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxAggregate.IService;
using Fx.Domain.FxHouse.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 具体房屋转让详情控制器
    /// </summary>
    public class HouseTransferDetailController : Controller
    {
        private ITransferHouse transferHouse;
        private IFavorite favorite;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="transferHouse">房屋转让保存读取接口</param>
        /// <param name="favorite">收藏接口</param>
        public HouseTransferDetailController(ITransferHouse transferHouse,
            IFavorite favorite)
        {
            this.transferHouse = transferHouse;
            this.favorite = favorite;
        }

        /// <summary>
        /// 具体房屋转让详情首页
        /// </summary>
        /// <param name="id">帖子Id</param>
        /// <returns>View</returns>
        public ActionResult Index(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            else
            {
                var house = transferHouse.Get(id);
                if (house == null)
                {
                    return RedirectToAction("PageNotFound", "PageLink");
                }
                if (User.Identity.IsAuthenticated)
                {
                    var isFav = favorite.IsFavorite((int)Fx.Entity.ChannelCatagroy.FxHouseTrasnfer, id, User.Identity.Name);
                    ViewBag.IsFav = isFav;
                }
                else
                {
                    ViewBag.IsFav = false;
                }
                return View(house);
            }
        }

        /// <summary>
        /// 房屋转让信息收藏
        /// </summary>
        /// <param name="infoId">帖子Id</param>
        /// <returns>View</returns>
        public ActionResult Favorite(int infoId)
        {
            if (infoId > 0 && User.Identity.IsAuthenticated)
            {
                var house = transferHouse.Get(infoId);
                var ret = favorite.AddFavorite(new Entity.FxAggregate.Favorite()
                {
                    ChannelCatagroy = (int)Fx.Entity.ChannelCatagroy.FxHouseTrasnfer,
                    InfoId = infoId,
                    Title = house.PublishTitle,
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
