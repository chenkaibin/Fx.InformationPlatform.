//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fx.Domain.FxHouse.Mapping
{
    #pragma warning disable 1573
    using System.Data.Entity.ModelConfiguration;
    using Fx.Entity;
    
    internal partial class TransferPicture_Mapping : EntityTypeConfiguration<TransferPicture>
    {
        public TransferPicture_Mapping()
        {                        
              this.HasKey(t => t.TransferPictureId);        
              this.ToTable("TransferPicture","House");
              this.Property(t => t.TransferPictureId).HasColumnName("TransferPictureId");
              this.Property(t => t.TransferPictureCatagroy).HasColumnName("TransferPictureCatagroy");
              this.Property(t => t.PhysicalPath).HasColumnName("PhysicalPath").HasMaxLength(128);
              this.Property(t => t.ImageUrl).HasColumnName("ImageUrl").HasMaxLength(128);
              this.Property(t => t.MinImageUrl).HasColumnName("MinImageUrl").HasMaxLength(128);
              this.Property(t => t.IsCdn).HasColumnName("IsCdn");
              this.Property(t => t.CdnUrl).HasColumnName("CdnUrl").HasMaxLength(128);
         }
    }
}

