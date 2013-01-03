using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity;

namespace Fx.InformationPlatform.Site.ViewModel
{
    /// <summary>
    /// 物品转让视图模型
    /// </summary>
    public class TransferViewGoods
    {       
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 三级分类Id
        /// </summary>
        public int CatagroyId { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 是否换物
        /// </summary>
        public bool IsChangeGoods { get; set; }

        /// <summary>
        /// 想要交换物品的信息
        /// </summary>
        public string ChangeGoodsMsg { get; set; }

        /// <summary>
        /// 区域Id
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 物品新旧程度Id
        /// </summary>
        public int GoodConditionId { get; set; }

        /// <summary>
        /// 物品新旧程度相关信息
        /// </summary>
        public string GoodConditonMsg { get; set; }

        /// <summary>
        /// 正面照片
        /// </summary>
        public List<TransferPicture> FaceFiles { get; set; }

        /// <summary>
        /// 其他方位照片
        /// </summary>
        public List<TransferPicture> OtherFiles { get; set; }

        /// <summary>
        /// 其他方位照片2 
        /// </summary>
        public List<TransferPicture> BadFiles { get; set; }

        /// <summary>
        /// 发布者接收信息邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public TransferViewGoods()
        {
            FaceFiles = new List<TransferPicture>();
            OtherFiles = new List<TransferPicture>();
            BadFiles = new List<TransferPicture>();
        }
    }
}