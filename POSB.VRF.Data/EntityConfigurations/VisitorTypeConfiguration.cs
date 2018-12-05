using POSB.VRF.Domain.Models;
using System.Data.Entity.ModelConfiguration;


namespace POSB.VRF.Data.EntityConfigurations
{
    public class VisitorTypeConfiguration : EntityTypeConfiguration<VisitorType>
    {
        public VisitorTypeConfiguration()
        {
            Property(c => c.Description)
              .IsOptional()
              .HasMaxLength(50);
        }
    }
}
