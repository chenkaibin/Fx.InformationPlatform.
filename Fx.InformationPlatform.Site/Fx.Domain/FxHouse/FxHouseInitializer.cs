using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxHouse
{
    /// <summary>
    /// 房屋上下文初始化
    /// </summary>
    public class FxHouseInitializer : DropCreateDatabaseAlways<FxHouseContext>
    {
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="context">房屋上下文</param>
        protected override void Seed(FxHouseContext context)
        {
            base.Seed(context);
        }
    }
}
