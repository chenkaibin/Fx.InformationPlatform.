using System.Collections.Generic;
using Fx.Entity;

namespace Fx.InformationPlatform.Site.ViewModel
{
    /// <summary>
    /// 车辆转让视图模型
    /// </summary>
    public class TransferViewCar
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///  三级分类Id
        /// </summary>
        public int CatagroyId { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 区域Id
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 车辆年饭
        /// </summary>
        public int CarYear { get; set; }

        /// <summary>
        /// 车辆行驶英里数
        /// </summary>
        public int CarMileage { get; set; }

        /// <summary>
        /// 发布者接收对外接收信息邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Mark { get; set; }

        /// <summary>
        /// 车辆转让相关正面照片
        /// </summary>
        public List<TransferPicture> FaceFiles { get; set; }

        /// <summary>
        /// 车辆转让相关其他方位照片
        /// </summary>
        public List<TransferPicture> OtherFiles { get; set; }

        /// <summary>
        /// 车辆转让相关其他方位照片2
        /// </summary>
        public List<TransferPicture> BadFiles { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public TransferViewCar()
        {
            FaceFiles = new List<TransferPicture>();
            OtherFiles = new List<TransferPicture>();
            BadFiles = new List<TransferPicture>();
        }
    }
}