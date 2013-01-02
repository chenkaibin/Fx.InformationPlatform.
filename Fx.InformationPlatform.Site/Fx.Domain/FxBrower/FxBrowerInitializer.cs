using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Fx.Domain.FxBrower
{
    /// <summary>
    /// 浏览器信息记录上下文初始化
    /// </summary>
    public class FxBrowerInitializer :  DropCreateDatabaseIfModelChanges<FxBrowerContext>
    {
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(FxBrowerContext context)
        {
            base.Seed(context);
        }
    }
}
