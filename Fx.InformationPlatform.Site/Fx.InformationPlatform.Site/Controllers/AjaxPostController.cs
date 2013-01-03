using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.FxAggregate.IService;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.Controllers
{
#if DEBUG
#else
    [Authorize]
#endif
    /// <summary>
    /// 处理Ajax Post提交请求控制器
    /// </summary>
    public class AjaxPostController : Controller
    {
        private IAggregateInfo aggregateInfoService;
        private IPrivateMessage privateMessageService;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="aggregateInfoService">聚合信息接口</param>
        /// <param name="privateMessageService">私信接口</param>
        public AjaxPostController(IAggregateInfo aggregateInfoService,
            IPrivateMessage privateMessageService)
        {
            this.aggregateInfoService = aggregateInfoService;
            this.privateMessageService = privateMessageService;
        }

        /// <summary>
        /// 发送私信
        /// </summary>
        /// <param name="infoId">帖子Id</param>
        /// <param name="channelCatagroy">频道</param>
        /// <param name="privateTxt">私信内容</param>
        /// <returns>View</returns>
        public ActionResult PrivateMessage(int infoId, int channelCatagroy, string privateTxt)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Json("私信发送失败,您没有登录,请先登陆", JsonRequestBehavior.DenyGet);
            }
            if (Request.IsAjaxRequest() && infoId > 0 && channelCatagroy >= 0)
            {
                var info = aggregateInfoService.GetInfoByCatatgroyAndId(channelCatagroy, infoId);
                if (info != null && aggregateInfoService.IsValid(info) == true)
                {
                    privateMessageService.AddPrivateMessage(new Entity.FxAggregate.PrivateMessage()
                    {
                        ChannelCatagroy = channelCatagroy,
                        InterestingEmail = User.Identity.Name,
                        UserAccount = info.UserAccount,
                        SourceId = infoId,
                        Title = info.PublishTitle,
                        Message = privateTxt

                    });

                    var glo = System.Web.Mvc.DependencyResolver.Current.GetService<GlobalCache>();
                    glo.PrivateMessageCountAdd(info.UserAccount);
                    glo.PrivateMessageTodayCountAdd(info.UserAccount);
                    return Json("私信发送成功", JsonRequestBehavior.DenyGet);
                }
                else
                {
                    return Json("私信发送失败", JsonRequestBehavior.DenyGet);
                }

            }
            else
            {
                return new ContentResult() { Content = "Access Forbidden!" };
            }
        }
    }
}
