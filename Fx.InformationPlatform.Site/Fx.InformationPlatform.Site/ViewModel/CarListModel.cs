using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fx.Entity.FxCar;

namespace Fx.InformationPlatform.Site.ViewModel
{
    /// <summary>
    /// 车辆列表结果模型
    /// </summary>
    public class CarListModel
    {
        /// <summary>
        /// 二手车辆列表信息
        /// </summary>
        public List<CarTransferInfo> SecondHandCars { get; set; }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CarListModel()
        {
            this.SecondHandCars = new List<CarTransferInfo>();
        }
    }
}