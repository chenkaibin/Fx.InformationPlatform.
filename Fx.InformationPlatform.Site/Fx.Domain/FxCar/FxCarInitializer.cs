using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxCar
{
    /// <summary>
    /// 车辆上下文数据库初始化
    /// </summary>
    public class FxCarInitializer : DropCreateDatabaseAlways<FxCarContext>
    {
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="context">车辆上下文</param>
        protected override void Seed(FxCarContext context)
        {
            base.Seed(context);
        }
    }
}
