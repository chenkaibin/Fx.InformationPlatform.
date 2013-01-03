using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// Base控制器 具体求购/转让控制器继承 用于提供定位MVC中的控制器和执行具体方法
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 控制器名称
        /// </summary>
        protected string ControllerName { get; private set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        protected string ActionName { get; private set; }
        /// <summary>
        /// 路由参数
        /// </summary>
        protected string RoutePars { get; private set; }

        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void InitParas()
        {
            ActionName = this.ActionName();
            ControllerName = this.ControllerName();
        }
    }
}
