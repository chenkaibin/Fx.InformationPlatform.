namespace Fx.InformationPlatform.Site.ViewModel
{
    /// <summary>
    /// 车辆求购信息视图模型
    /// </summary>
    public class BuyViewCar
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 三级分类
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
        /// 车辆年份
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
    }
}