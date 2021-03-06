﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.Account.IService;
using Fx.Entity.Account;
using Fx.Entity.MemberShip;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 帐号控制器
    /// </summary>
    public class AccountController : Controller
    {
        private IAccountService accountService;
        private GlobalCache gloCache;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="accountService">帐号服务接口</param>
        /// <param name="gloCache">全局缓存</param>
        public AccountController(IAccountService accountService,
            GlobalCache gloCache)
        {
            this.accountService = accountService;
            this.gloCache = gloCache;
            ViewBag.UserCount = gloCache.UserCount();
        }

        
        /// <summary>
        /// 帐号首页
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 用户登录页面
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user">用户注册模型</param>
        /// <param name="returnUrl">返回Url</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Login(RegisterUser user, string returnUrl)
        {

            var result = accountService.VaildUser(user.Email, user.Password);
            if (result.isSuccess)
            {
                //创建验证票subdomain  share cookie
                var ticket = new System.Web.Security.FormsAuthenticationTicket(user.Email, true, 30);
                string authTicket = System.Web.Security.FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, authTicket);
                cookie.Domain = AppSettings.FormDomain;
                var userExtend = accountService.GetUserExtendInfo(user.Email);
                Session[user.Email] = userExtend.NickName == null ? "" : userExtend.NickName;
                Response.Cookies.Add(cookie);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.Error = result.ResultMsg;
            }
            return View();
        }

        /// <summary>
        /// 注册用户页面展示
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user">用户注册模型</param>
        /// <returns>View</returns>
        public ActionResult Register(RegisterUser user)
        {
            if (user != null && user.PasswordQuestion != null)
            {
                if (user.PasswordQuestion == "请选择密保查询问题")
                {
                    ViewBag.PasswordQuestion = "请选择一个密保查询问题";
                }
            }
            if (!ModelState.IsValid || user == null ||
                user.VerificationCode == null || user.Email == null
                || Session["PictureCode"] == null)
            {
                return View("Register", user);
            }
            if (string.Compare(user.VerificationCode, Session["PictureCode"].ToString(), true) != 0)
            {
                ViewBag.VerificationCode = "验证码错误,请重试";
                return View("Register", user);
            }
            var membershipuser = new Membership();
            membershipuser.Users = new Users();
            membershipuser.Users.UserName = user.Email;
            membershipuser.MobilePIN = user.Mobile;
            membershipuser.Email = user.Email;
            membershipuser.Password = user.Password;
            var other = new OtherInformation();
            other.Address = "";
            other.Mobile = user.Mobile;
            other.QQ = user.QQ;
            other.Sex = SexCatalog.Male;
            other.NickName = user.NickName;
            other.PasswordQuestion = user.PasswordQuestion;
            other.PasswordAnswer = user.PasswordAnswer;
            var entityResult = accountService.AddUser(membershipuser, other);
            if (entityResult.isSuccess)
            {
                // 跳转到登录页面
                //System.Web.Security.FormsAuthentication.SetAuthCookie(user.Email, true);
                //Session[user.Email] = user.NickName == null ? "" : user.NickName;
                var ticket = new System.Web.Security.FormsAuthenticationTicket(user.Email, true, 30);
                string authTicket = System.Web.Security.FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, authTicket);
                cookie.Domain = AppSettings.FormDomain;
                var userExtend = accountService.GetUserExtendInfo(user.Email);
                Session[user.Email] = userExtend.NickName == null ? "" : userExtend.NickName;
                Response.Cookies.Add(cookie);
                gloCache.UserCountAdd();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = entityResult.ResultMsg;
                return View("Register", user);
            }
        }

        /// <summary>
        /// 注销用户
        /// </summary>
        /// <returns>View</returns>
        public ActionResult LoginOff()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 重置密码页面
        /// </summary>
        /// <returns>View</returns>
        public ActionResult ResetPassword()
        {
            return View();
        }


        /// <summary>
        /// 邮箱重置密码 需要考虑恶意破解的问题 但是没有实现
        /// </summary>
        /// <param name="useremail"></param>
        /// <param name="passwordAnswer">密保问题</param>
        /// <param name="passwordQuestion">密保答案</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult ResetPassword(string useremail, string passwordQuestion, string passwordAnswer)
        {
            var isExist = accountService.IsExistUser(useremail);
            if (isExist.isSuccess)
            {
                var user = accountService.GetUserExtendInfo(useremail);
                if (user != null &&
                    user.PasswordAnswer == passwordAnswer &&
                    user.PasswordQuestion == passwordQuestion)
                {
                    var res = accountService.ResetPassword(useremail);
                    if (res.isSuccess)
                    {
                        ViewBag.Tip = "您的密码是："+res.Tag;
                    }
                    else
                    {
                        ViewBag.Tip = res.ResultMsg;
                    }
                    return View();
                }
                ViewBag.Tip = "您填写的信息不正确";
                return View();
            }
            else
            {
                ViewBag.Tip = "对不起，不存在这个邮箱帐号";
                return View();
            }
        }

    }
}
