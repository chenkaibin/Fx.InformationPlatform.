using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Entity;
using Fx.Entity.FxGoods;

namespace Fx.Domain.FxGoods
{
    /// <summary>
    /// 物品上下文数据库初始化
    /// </summary>
    public class FxGoodsInitializer : DropCreateDatabaseAlways<FxGoodsContext>
    {
        /// <summary>
        /// 数据保存
        /// </summary>
        /// <param name="context">物品上下文</param>
        protected override void Seed(FxGoodsContext context)
        {
            base.Seed(context);           
        }
    }
}
