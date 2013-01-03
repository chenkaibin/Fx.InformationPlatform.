using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Entity.Catagroy;
using Fx.Entity.FxGoods;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxGoods;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 物品求购查询控制器
    /// </summary>
    public class GoodsBuySearchController : Controller
    {
        private GoodsCache goodsCache;
        /// <summary>
        /// 用于一般检索
        /// </summary>
        private Fx.Domain.Base.IService.ISiteSearch<GoodsBuyInfo> siteGoodsSearch;
        /// <summary>
        /// 用于二手分类查看
        /// </summary>
        private Fx.Domain.Base.IService.IGoodsSearch<GoodsBuyInfo> goodsSearch;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="goodsCache">物品缓存</param>
        /// <param name="siteGoodsSearch">大频道帖子关键字查询接口</param>
        /// <param name="goodsSearch">物品交易检索接口</param>
        public GoodsBuySearchController(GoodsCache goodsCache,
            Fx.Domain.Base.IService.ISiteSearch<GoodsBuyInfo> siteGoodsSearch,
            Fx.Domain.Base.IService.IGoodsSearch<GoodsBuyInfo> goodsSearch)
        {
            this.goodsCache = goodsCache;
            this.siteGoodsSearch = siteGoodsSearch;
            this.goodsSearch = goodsSearch;
        }

        /// <summary>
        /// 手机页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Phone(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyPhone().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Phone, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 电脑页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Computer(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyComputer().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Computer, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 数码摄像器材页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult DigitalCamera(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyDigitalCamera().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.DigitalCamera, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 电脑配件页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult ComputerAccessories(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyComputerAccessories().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.ComputerAccessories, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 游戏机页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult PlayStations(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyPlayStations().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.PlayStations, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 游戏机配件页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult PSAccessories(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyPSAccessories().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.PSAccessories, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 手机配件页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult PhoneAccessories(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyPhoneAccessories().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.PhoneAccessories, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 数码产品其他页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult ElectronicsOther(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyElectronicsOther().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.ElectronicsOther, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 家具页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Furniture(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyFurniture().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Furniture, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 厨房家电页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult KitchenAppliances(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyKitchenAppliances().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.KitchenAppliances, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 视听家电页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult AudioAppliances(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyAudioAppliances().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.AudioAppliances, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 餐具/厨具页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult KitchenDinningWares(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyKitchenDinningWares().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.KitchenDinningWares, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 工艺品/摆设页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Decoration(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyDecoration().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Decoration, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 其他家电页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult OtherElectronics(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyOtherElectronics().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.OtherElectronics, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 运动器材页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult GymEquipment(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyGymEquipment().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.GymEquipment, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 单车页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Bike(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyBike().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Bike, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 居家用品其他页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult HomeSuppliesOther(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyHomeSuppliesOther().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.HomeSuppliesOther, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 衣服页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Clothing(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyClothing().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Clothing, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 鞋子页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Shoes(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyShoes().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Shoes, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 箱包页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Bag(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyBag().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Bag, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 首饰页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Accessories(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyAccessories().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Accessories, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 衣服鞋包其他页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult FashionOther(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyFashionOther().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.FashionOther, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 乐器页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult MusicInstruments(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyMusicInstruments().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.MusicInstruments, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 印刷品页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Books(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyBooks().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Books, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 玩具模型页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Toys(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyToys().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Toys, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 文具页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult Stationary(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyStationary().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.Stationary, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 文化生活其他页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult CultureLifeOther(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyCultureLifeOther().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.CultureLifeOther, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }

        /// <summary>
        /// 物品交易其他之其他页面
        /// </summary>
        /// <param name="id">第几页</param>
        /// <returns>View</returns>
        public ActionResult OtherOther(int id)
        {
            var model = new GoodsBuySearchModel(id);
            if (id <= 0)
            {
                return RedirectToAction("PageNotFound", "PageLink");
            }
            if (id <= 10)
            {
                model.MainGoods = goodsCache.GetMainGoodsBuyOtherOther().Skip((id - 1) * 10).Take(10).ToList();
            }
            else
            {
                //缓存中数量超过100个的时候 才可能有后续数据 这个时候才去读取 否则不读取  默认100个   
                if (model.MainGoods.Count == 100)
                {
                    int page = id - 1;
                    model.MainGoods = goodsSearch.SearchByCatagroy(ChannelListDetailCatagroy.OtherOther, page, 10);
                }
            }
            
            model.CheckModel();
            return View(model);
        }
    }
}
