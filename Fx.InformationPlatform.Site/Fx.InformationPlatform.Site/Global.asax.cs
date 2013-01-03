using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Fx.InformationPlatform.Site.Framework;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace Fx.InformationPlatform.Site
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    /// Fx.InformationPlatform.Site MVC程序
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        //public static Container Container { get; private set; }
        /// <summary>
        /// 注册全局异常过滤器
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new Fx.InformationPlatform.Site.Framework.ElmahHandledErrorLoggerFilter());
            filters.Add(new HandleErrorAttribute());
        }

        /// <summary>
        /// 注册路由
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Brower", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Buy", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Buy", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
               "Transfer", // Route name
               "{controller}/{action}/{id}", // URL with parameters
               new { controller = "Transfer", action = "Index", id = UrlParameter.Optional } // Parameter defaults
           );



        }

        /// <summary>
        /// 程序启动
        /// </summary>
        protected void Application_Start()
        {
            System.Web.Mvc.ViewEngines.Engines.Clear();
            System.Web.Mvc.ViewEngines.Engines.Add(new CsharpRazorViewEngiee());

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            if (!Fx.InformationPlatform.Site.T4Helper.IsDebug)
            {
                //new FxTask.QuartzLoadProvider().Load();
            }
        }
    }
}