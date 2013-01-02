using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fx.Entity.MemberShip;

namespace Fx.Domain.Account.Mapping.Other
{
    /// <summary>
    /// 用户扩展信息数据库Mapping
    /// </summary>
    public class OtherInformation_Mapping : EntityTypeConfiguration<OtherInformation>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public OtherInformation_Mapping()
        {
            this.HasKey(r => r.OtherInformationId);
            this.ToTable("OtherInformation","User");
            this.Property(r => r.QQ).HasMaxLength(20);
            this.Property(r => r.Mobile).HasMaxLength(20);
            this.Property(r => r.Email).HasMaxLength(256);
            this.Property(r => r.HeadPicture).HasMaxLength(128);
            this.Property(r => r.NickName).HasMaxLength(128);
            this.Property(r => r.Address).HasMaxLength(256);
            this.Property(r => r.PasswordAnswer).HasMaxLength(20);
            this.Property(r => r.PasswordQuestion).HasMaxLength(20);
        }
    }
}
