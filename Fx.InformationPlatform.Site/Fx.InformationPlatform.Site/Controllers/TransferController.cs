using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxSite.IService;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 转让页面频道选择控制器
    /// </summary>
#if DEBUG

#else
    [Authorize]    
#endif
    public class TransferController : Controller
    {
        private IChannelService channelService;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="channelService">一级频道服务接口</param>
        public TransferController(IChannelService channelService)
        {
            this.channelService = channelService;
        }

        /// <summary>
        /// 转让页面频道首页
        /// </summary>
        /// <param name="id">默认选中第几个选项卡</param>
        /// <returns>View</returns>
        public ActionResult Index(int id)
        {
            ViewBag.Select = id;
            return View(channelService.GetAllChannels());
        }

    }
}
