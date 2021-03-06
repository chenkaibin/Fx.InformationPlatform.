//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fx.Domain.FxSite.Mapping
{
#pragma warning disable 1573
    using System.Data.Entity.ModelConfiguration;
    using Fx.Entity.FxSite;

    internal partial class Area_Mapping : EntityTypeConfiguration<Area>
    {
        public Area_Mapping()
        {
            this.HasKey(t => t.AreaId);
            this.ToTable("Area", "Site");
            this.Property(t => t.AreaId).HasColumnName("AreaId");
            this.Property(t => t.AreaName).HasColumnName("AreaName").IsRequired().HasMaxLength(50);
            this.Property(t => t.Sorted).HasColumnName("Sorted");
            this.HasMany(t => t.Cities).WithOptional().HasForeignKey(t => t.AreaID).WillCascadeOnDelete(false);
        }
    }
}
