using POSB.VRF.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace POSB.VRF.Data.EntityConfigurations
{
    public class PermissionConfiguration : EntityTypeConfiguration<Permission>
    {

        public PermissionConfiguration ()
	    {

            Property(c => c.Name)
              .IsRequired()
              .HasMaxLength(50);

            Property(c => c.Description)
              .IsOptional()
              .HasMaxLength(255);

            Property(c => c.ControllerMethod)
              .IsRequired()
              .HasMaxLength(100);

	    }

    }
}
