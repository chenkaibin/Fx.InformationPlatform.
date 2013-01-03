using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxSite
{
    /// <summary>
    /// 地区
    /// </summary>
    public class Area
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public Area()
        {
            this.Cities = new HashSet<City>();
        }

        /// <summary>
        /// 地区主键Id
        /// </summary>
        public int AreaId { get; set; }

        /// <summary>
        /// 地区名称
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sorted { get; set; }

        /// <summary>
        /// 地区相关城市
        /// </summary>
        public virtual ICollection<City> Cities { get; set; }
    }
}
