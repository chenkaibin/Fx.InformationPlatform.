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
    
    internal partial class ChannelListDetail_Mapping : EntityTypeConfiguration<ChannelListDetail>
    {
        public ChannelListDetail_Mapping()
        {                        
              this.HasKey(t => t.ChannelListDetailId);
              this.ToTable("ChannelListDetail", "Site");
              this.Property(t => t.ChannelListDetailId).HasColumnName("ChannelListDetailId");
              this.Property(t => t.ChannelListDetailName).HasColumnName("ChannelListDetailName").HasMaxLength(20);
              this.Property(t => t.Description).HasColumnName("Description").HasMaxLength(256);   
           
         }
    }
}

