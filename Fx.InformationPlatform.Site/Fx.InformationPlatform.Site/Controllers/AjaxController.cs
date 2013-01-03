using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Fx.Domain.FxSite.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 处理Ajax Get请求控制器
    /// </summary>
    public class AjaxController : Controller
    {
        private ISite publishService;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="publishService">站点基础信息接口</param>
        public AjaxController(ISite publishService)
        {
            this.publishService = publishService;
        }

        /// <summary>
        /// 根据区域Id获取相应城市Html 缓存3600秒
        /// </summary>
        /// <param name="areaId">区域Id</param>
        /// <returns>ContentResult</returns>
        [OutputCache(Duration = 3600)]
        public ActionResult City(int areaId)
        {
            if (Request.IsAjaxRequest() && areaId > 0)
            {
                string show = "<option value=\"0\">--请选择详细地址--</option>";
                var list = publishService.GetCitys(areaId);
                var json = from p in list
                           select string.Format("<option value=\"{0}\">{1}</option>", p.CityId, p.CityName);

                return Json(show + string.Join("", json), JsonRequestBehavior.DenyGet);
            }
            else
            {
                return new ContentResult() { Content = "Access Forbidden!" };
            }
        }

        /// <summary>
        /// 获取物品求购新旧基础信息 缓存3600秒
        /// </summary>
        /// <returns>ContentResult</returns>
        [OutputCache(Duration = 3600)]
        public ActionResult GoodsBuyCondition()
        {
            if (Request.IsAjaxRequest())
            {
                string show = "<option value=\"0\">--请选择新旧程度--</option>";
                var list = publishService.GoodsConditions();
                var json = from p in list
                           select string.Format("<option value=\"{0}\" extend=\"{1}\" message=\"{2}\" >{3}</option>", p.GoodsConditionId, p.IsHasMessage.ToString().ToUpper(), p.PlaceHolder, "至少" + p.GoodsConditionName);

                return Json(show + string.Join("", json), JsonRequestBehavior.DenyGet);
            }
            else
            {
                return new ContentResult() { Content = "Access Forbidden!" };
            }
        }

        /// <summary>
        /// 获取物品转让新旧基础信息 缓存3600秒
        /// </summary>
        /// <returns>ContentResult</returns>
        [OutputCache(Duration = 3600)]
        public ActionResult GoodsTransferCondition()
        {
            if (Request.IsAjaxRequest())
            {
                string show = "<option value=\"0\">--请选择新旧程度--</option>";
                var list = publishService.GoodsConditions();
                var json = from p in list
                           select string.Format("<option value=\"{0}\" extend=\"{1}\" message=\"{2}\" >{3}</option>", p.GoodsConditionId, p.IsHasMessage.ToString().ToUpper(), p.PlaceHolder, p.GoodsConditionName);

                return Json(show + string.Join("", json), JsonRequestBehavior.DenyGet);
            }
            else
            {
                return new ContentResult() { Content = "Access Forbidden!" };
            }
        }
    }
}
