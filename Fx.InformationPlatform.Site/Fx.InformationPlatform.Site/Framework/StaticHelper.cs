using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Fx.Domain.Account.IService;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site
{
    /// <summary>
    /// 展示层的帮助类
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// 是否有上传文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool HasFile(this HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }

        /// <summary>
        /// 当前控制器下运行的方法名称
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <returns>当前控制器下运行的方法名称</returns>
        public static string ActionName(this Controller controller)
        {
            return controller.RouteData.Route.GetRouteData(controller.HttpContext).Values["action"] as string;
        }

        /// <summary>
        /// 当前控制器的名称
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <returns>当前控制器的名称</returns>
        public static string ControllerName(this Controller controller)
        {
            return controller.RouteData.Route.GetRouteData(controller.HttpContext).Values["controller"] as string;
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="t">时间</param>
        /// <returns>时间戳</returns>
        public static string GetTimeStamp(this DateTime t)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 获取日期yyyyMMdd
        /// </summary>
        /// <returns>日期yyyyMMdd</returns>
        public static string GetDate()
        {
            return string.Format("{0:yyyyMMdd}", DateTime.Now);
        }

        /// <summary>
        /// 获取枚举类子项描述信息
        /// </summary>
        /// <param name="enumSubitem">枚举类子项</param>        
        public static string GetEnumDescription(this Enum enumSubitem)
        {
            string strValue = enumSubitem.ToString();
            System.Reflection.FieldInfo fieldinfo = enumSubitem.GetType().GetField(strValue);
            if (fieldinfo != null)
            {
                Object[] objs = fieldinfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (objs == null || objs.Length == 0)
                {
                    return strValue;
                }
                else
                {
                    DescriptionAttribute da = (DescriptionAttribute)objs[0];
                    return da.Description;
                }
            }
            else
            {
                return "UnKonw";
            }
        }

        /// <summary>
        /// 获取当前用户的昵称 昵称默认保存于Session中，超时后自动从新加载
        /// </summary>
        /// <param name="session">当然Session</param>
        /// <param name="key">昵称的Session Key</param>
        /// <returns>昵称</returns>
        public static object GetSessionName(this HttpSessionState session,string key)
        {
            if (session[key]==null || string.IsNullOrWhiteSpace(session[key].ToString()))
            {
                IAccountService  account=System.Web.Mvc.DependencyResolver.Current.GetService<IAccountService>();
                var userExtend = account.GetUserExtendInfo(key);
                session[key] = userExtend.NickName == null ? "" : userExtend.NickName;
            }
            return session[key];
        }

        /// <summary>
        /// 根据区域Id获取区域名称
        /// </summary>
        /// <param name="areaId">区域Id</param>
        /// <returns>区域名称</returns>
        public static string GetAreaName(int areaId)
        {
            SiteCache siteCache = System.Web.Mvc.DependencyResolver.Current.GetService<SiteCache>();
            return siteCache.GetArea().Where(r => r.AreaId==areaId).First().AreaName;
        }

        /// <summary>
        /// 根据城市Id获取城市名称
        /// </summary>
        /// <param name="cityId">城市Id</param>
        /// <returns>城市名称</returns>
        public static string GetCityName(int cityId)
        {
            SiteCache siteCache = System.Web.Mvc.DependencyResolver.Current.GetService<SiteCache>();
            return siteCache.GetCity().Where(r => r.CityId == cityId).First().CityName;
        }

        /// <summary>
        /// 获取当前用户的私信数量
        /// </summary>
        /// <param name="email">用户帐号</param>
        /// <returns>私信数量</returns>
        public static int PrivateMessageCount(string email)
        {
            GlobalCache glo = System.Web.Mvc.DependencyResolver.Current.GetService<GlobalCache>();
            return glo.PrivateMessageCount(email);
        }
    }
}