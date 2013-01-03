using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Entity.FxSite
{
    /// <summary>
    /// 城市
    /// </summary>
    public class City
    {
        /// <summary>
        /// 城市主键Id
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual int Sorted { get; set; }
        
        /// <summary>
        /// 城市对应区域Id
        /// </summary>
        public int AreaID { get; set; }
    }
}
