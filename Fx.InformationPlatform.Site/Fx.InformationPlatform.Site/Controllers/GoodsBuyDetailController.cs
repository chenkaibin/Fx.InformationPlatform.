using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxAggregate.IService;
using Fx.Domain.FxGoods.IService;
using Fx.Entity.FxGoods;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 二手求购详情控制器
    /// </summary>
    public class GoodsBuyDetailController : Controller
    {
        private IBuyGoods buyGoods;
        private IFavorite favorite;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="buygoods">物品求购保存读取接口</param>
        /// <param name="favorite">收藏接口</param>
        public GoodsBuyDetailController(IBuyGoods buygoods,
             IFavorite favorite)
        {
            this.buyGoods = buygoods;
            this.favorite = favorite;
        }

        /// <summary>
        /// 二手求购详情首页
        /// </summary>
        /// <param name="id">帖子Id</param>
        /// <returns>View</returns>
        public ActionResult Index(int id)
        {
            GoodsBuyInfo goods;
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            else
            {
                goods = buyGoods.Get(id);
                if (goods == null)
                {
                    return RedirectToAction("PageNotFound", "PageLink");
                }
                if (User.Identity.IsAuthenticated)
                {
                    var isFav = favorite.IsFavorite((int)Fx.Entity.ChannelCatagroy.FxGoodsBuy, id, User.Identity.Name);
                    ViewBag.IsFav = isFav;
                }
                else
                {
                    ViewBag.IsFav = false;
                }
            }
            //换物
            if (goods.Pictures != null && goods.Pictures.Count > 0)
            {
                return View("IndexWithPicture", goods);
            }
            else
            {
                return View("IndexWithNoPicture", goods);
            }
        }

        /// <summary>
        /// 物品求购信息收藏
        /// </summary>
        /// <param name="infoId">帖子Id</param>
        /// <returns>View</returns>
        public ActionResult Favorite(int infoId)
        {
            if (infoId > 0 && User.Identity.IsAuthenticated)
            {
                var goods = buyGoods.Get(infoId);
                var ret = favorite.AddFavorite(new Entity.FxAggregate.Favorite()
                {
                    ChannelCatagroy = (int)Fx.Entity.ChannelCatagroy.FxGoodsBuy,
                    InfoId = infoId,
                    Title = goods.PublishTitle,
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
