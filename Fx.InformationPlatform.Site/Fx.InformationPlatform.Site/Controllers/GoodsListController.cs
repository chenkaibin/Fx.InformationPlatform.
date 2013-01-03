using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxGoods;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 物品列表控制器
    /// </summary>
    public class GoodsListController : Controller
    {
        private GoodsCache goodsCache;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="goodsCache">物品缓存</param>
        public GoodsListController(GoodsCache goodsCache)
        {
            this.goodsCache = goodsCache;
        }

        /// <summary>
        /// 物品列表首页
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            var model = new GoodsListModel();
            model.CultureLifes = goodsCache.GetGoodsCultureLifeList();
            model.Electronics = goodsCache.GetGoodsElectronicsList();
            model.Fashions = goodsCache.GetGoodsFashionList();
            model.HomeSupplies = goodsCache.GetGoodsHomeSuppliesList();
            model.Others = goodsCache.GetGoodsOtherList();
            return View(model);
        }

    }
}
