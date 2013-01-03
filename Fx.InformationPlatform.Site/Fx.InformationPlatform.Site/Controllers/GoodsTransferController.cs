using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fx.Domain.Account.IService;
using Fx.Domain.FxGoods.IService;
using Fx.Domain.FxSite.IService;
using Fx.Entity;
using Fx.Entity.FxGoods;
using Fx.InformationPlatform.Site.ViewModel;
using FxCacheService.FxSite;

namespace Fx.InformationPlatform.Site.Controllers
{
    /// <summary>
    /// 二手转让发布控制器
    /// </summary>
#if DEBUG

#else
    [Authorize]    
#endif
    public class GoodsTransferController : BaseController, ISiteJob
    {
        IGoods goodsService;
        ITransferGoods transferService;
        IAccountService accountService;
        /// <summary>
        /// 默认构造函数
        /// </summary>
        /// <param name="goodsService">站点下物品基础信息接口</param>
        /// <param name="transferService">物品转让保存读取接口</param>
        /// <param name="accountService">帐号服务接口</param>
        public GoodsTransferController(IGoods goodsService,
            ITransferGoods transferService,
            IAccountService accountService)
        {
            this.goodsService = goodsService;
            this.transferService = transferService;
            this.accountService = accountService;
        }


        /// <summary>
        /// 数码产品转让页面
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Electronics()
        {
            BindData();
            return View();
        }

        /// <summary>
        /// 居家用品转让页面
        /// </summary>
        /// <returns>View</returns>
        public ActionResult HomeSupplies()
        {
            BindData();
            return View();
        }

        /// <summary>
        /// 衣服鞋包转让页面
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Fashion()
        {
            BindData();
            return View();
        }

        /// <summary>
        /// 文化生活转让页面
        /// </summary>
        /// <returns>View</returns>
        public ActionResult CultureLife()
        {
            BindData();
            return View();
        }

        /// <summary>
        /// 物品其他转让页面
        /// </summary>
        /// <returns>View</returns>
        public ActionResult Other()
        {
            BindData();
            return View();
        }


        private void BindData()
        {
            BindCatagroy();
            BindArea();
        }

        private void BindArea()
        {
            var siteCache = System.Web.Mvc.DependencyResolver.Current.GetService<SiteCache>();
            ViewData["area"] = siteCache.GetAreaListItems();
        }

        private void BindCatagroy()
        {
            InitParas();
            List<SelectListItem> details = new List<SelectListItem>();
            details.Add(new SelectListItem() { Value = "0", Text = "--请选择物品类别--" });
            goodsService.GetChannelTransferDetail(this.ControllerName, this.ActionName).ForEach(r => details.Add(new SelectListItem() { Text = r.ChannelListDetailName, Value = r.ChannelListDetailId.ToString() }));
            ViewData["catagroy"] = details;
        }

        /// <summary>
        ///  数码产品发布
        /// </summary>
        /// <param name="goods">物品转让视图模型</param>
        /// <param name="facefile">正面照片</param>
        /// <param name="otherfile">其他方位照片</param>
        /// <param name="badfile">其他方位照片2</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Electronics(TransferViewGoods goods,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishGoods(goods, facefile, otherfile, badfile);
        }

        /// <summary>
        ///  居家用品发布
        /// </summary>
        /// <param name="goods">物品转让视图模型</param>
        /// <param name="facefile">正面照片</param>
        /// <param name="otherfile">其他方位照片</param>
        /// <param name="badfile">其他方位照片2</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult HomeSupplies(TransferViewGoods goods,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishGoods(goods, facefile, otherfile, badfile);
        }

        /// <summary>
        ///  衣服鞋包发布
        /// </summary>
        /// <param name="goods">物品转让视图模型</param>
        /// <param name="facefile">正面照片</param>
        /// <param name="otherfile">其他方位照片</param>
        /// <param name="badfile">其他方位照片2</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Fashion(TransferViewGoods goods,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishGoods(goods, facefile, otherfile, badfile);
        }

        /// <summary>
        /// 文化生活发布
        /// </summary>
        /// <param name="goods">物品转让视图模型</param>
        /// <param name="facefile">正面照片</param>
        /// <param name="otherfile">其他方位照片</param>
        /// <param name="badfile">其他方位照片2</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult CultureLife(TransferViewGoods goods,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishGoods(goods, facefile, otherfile, badfile);
        }

        /// <summary>
        ///  物品其他发布
        /// </summary>
        /// <param name="goods">物品转让视图模型</param>
        /// <param name="facefile">正面照片</param>
        /// <param name="otherfile">其他方位照片</param>
        /// <param name="badfile">其他方位照片2</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult Other(TransferViewGoods goods,
            List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            return PublishGoods(goods, facefile, otherfile, badfile);
        }


        private ActionResult PublishGoods(TransferViewGoods goods, List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            if (BuildGoods(goods, facefile, otherfile, badfile))
            {
                GoodsTransferInfo transfergoods = MapperGoods(goods);
                transferService.SaveTransferGoods(transfergoods);
                RunJob();
                FxCacheService.FxSite.GlobalCache cache = System.Web.Mvc.DependencyResolver.Current.GetService<FxCacheService.FxSite.GlobalCache>();
                cache.InfoPublishAllCountAdd();
                return View("Success");
            }
            return View("FaildTransfer");
        }


        private GoodsTransferInfo MapperGoods(TransferViewGoods goods)
        {
            var info = new GoodsTransferInfo();
            info.CatagroyId = goods.CatagroyId;
            info.AreaId = goods.AreaId;
            info.ChangeMsg = goods.ChangeGoodsMsg;
            info.Controller = this.ControllerName;
            info.Action = this.ActionName;
            info.CityId = goods.CityId;
            info.GoodsConditionMsg = goods.GoodConditonMsg;
            info.GoodsconditonId = goods.GoodConditionId;
            info.IsChange = goods.IsChangeGoods;
            info.Mark = goods.Mark;
            goods.FaceFiles.ForEach(r => info.Pictures.Add(r));
            goods.OtherFiles.ForEach(r => info.Pictures.Add(r));
            goods.BadFiles.ForEach(r => info.Pictures.Add(r));
            info.Price = (int)goods.Price;
            info.PublishTitle = goods.Title;
            info.PublishUserEmail = goods.Email;
            info.UserAccount = User.Identity.Name;
            return info;
        }

        private bool BuildGoods(TransferViewGoods goods, List<HttpPostedFileBase> facefile, List<HttpPostedFileBase> otherfile, List<HttpPostedFileBase> badfile)
        {
            InitParas();
            string pictureName;
            string pictureMinName;
            //图片保存到
            #region FaceFile
            foreach (var face in facefile)
            {
                if (face.HasFile())
                {
                    pictureName = GetPictureName();
                    pictureMinName = GetPictureMinName();
                    goods.FaceFiles.Add(new TransferPicture()
                    {
                        ImageUrl = GetVirtualPath() + pictureName,
                        MinImageUrl = GetVirtualPath() + pictureMinName,
                        CdnUrl = "",
                        TransferPictureCatagroy = (int)PictureCatagroy.Head,
                        PhysicalPath = GetPhysicalPath() + pictureName
                    });
                    SaveFile(face, GetPhysicalPath(), GetPhysicalPath() + pictureName);
                }
            }
            #endregion

            #region OtherFile
            foreach (var other in otherfile)
            {
                if (other.HasFile())
                {
                    pictureName = GetPictureName();
                    pictureMinName = GetPictureMinName();
                    goods.OtherFiles.Add(new TransferPicture()
                    {
                        ImageUrl = GetVirtualPath() + pictureName,
                        MinImageUrl = GetVirtualPath() + pictureMinName,
                        CdnUrl = "",
                        TransferPictureCatagroy = (int)PictureCatagroy.Other,
                        PhysicalPath = GetPhysicalPath() + pictureName
                    });
                    SaveFile(other, GetPhysicalPath(), GetPhysicalPath() + pictureName);
                }
            }
            #endregion

            #region badFile
            foreach (var bad in badfile)
            {
                if (bad.HasFile())
                {
                    pictureName = GetPictureName();
                    pictureMinName = GetPictureMinName();
                    goods.BadFiles.Add(new TransferPicture()
                    {
                        ImageUrl = GetVirtualPath() + pictureName,
                        MinImageUrl = GetVirtualPath() + pictureMinName,
                        CdnUrl = "",
                        TransferPictureCatagroy = (int)PictureCatagroy.Bad,
                        PhysicalPath = GetPhysicalPath() + pictureName
                    });
                    SaveFile(bad, GetPhysicalPath(), GetPhysicalPath() + pictureName);
                }
            }
            #endregion

            return true;
        }


        #region UpLoad
        private readonly string transferPhysicalImagePath = @"UploadImage\Transfer\GoodsImage\";
        private readonly string transferVirtualImagePath = "UploadImage/Transfer/GoodsImage/";


        private string GetPhysicalPath()
        {
            return string.Format(@"{0}{1}{2}\{3}\", HttpContext.Server.MapPath("../"), transferPhysicalImagePath, GetDate(), GetUserId());
        }

        private string GetVirtualPath()
        {
            return string.Format("{0}{1}/{2}/", transferVirtualImagePath, GetDate(), GetUserId());
        }


        string userId;
        private string GetUserId()
        {
            if (string.IsNullOrEmpty(userId))
            {
                userId = accountService.GetCurrentUser(User.Identity.Name).ToString();
            }
            return userId;
        }

        string date;
        private string GetDate()
        {
            if (string.IsNullOrEmpty(date))
            {
                date = Helper.GetDate();
            }
            return date;
        }


        int pictureCount = 100;
        string timestamp = DateTime.Now.GetTimeStamp();

        private string GetPictureName()
        {
            string pictureName = string.Format("{0}{1}.jpg", timestamp, pictureCount);
            pictureCount++;
            return pictureName;

        }


        private string GetPictureMinName()
        {
            string pictureName = string.Format("{0}{1}-64X64.jpg", timestamp, pictureCount);
            return pictureName;
        }

        private void SaveFile(HttpPostedFileBase file, string folderPath, string filePath)
        {
            if (!System.IO.File.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }
            file.SaveAs(filePath);
        }
        #endregion

        /// <summary>
        /// Job运行
        /// </summary>
        public void RunJob()
        {
            //new FxTask.FxGoods.Transfer.GoodsTransferJobLoad();


            new System.Threading.Thread(() =>
            {
                new FxTask.FxGoods.Transfer.GoodsTransferJobLoad().Execute();
            }).Start();
        }
    }
}
