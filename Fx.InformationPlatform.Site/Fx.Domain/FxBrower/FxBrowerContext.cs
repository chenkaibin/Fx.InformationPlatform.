using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Fx.Domain.FxBrower.Mapping;
using Fx.Entity.FxBrower;

namespace Fx.Domain.FxBrower
{
    /// <summary>
    /// 浏览器信息记录上下文
    /// </summary>
    public class FxBrowerContext : DbContext
    {
        /// <summary>
        /// 默认构造函数,读取数据库字符串fx.collectinfo-sqlserver
        /// </summary>
        public FxBrowerContext()
            : base("fx.collectinfo-sqlserver")
        {

        }

        /// <summary>
        /// 浏览器信息记录上下文数据库模型如何创建
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new Brower_Mapping());

        }
        /// <summary>
        /// 浏览器聚合根
        /// </summary>
        public DbSet<Brower> Browers { get; set; }

    }
}
