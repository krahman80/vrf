using POSB.VRF.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace POSB.VRF.Data.EntityConfigurations
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50);
            
            Property(r => r.Description)
                .IsOptional()
                .HasMaxLength(255);

            Property(r => r.IsAdmin)
                .IsOptional();

            HasMany(c => c.Permissions)
                   .WithMany(t => t.Roles)
                   .Map(m =>
                   {
                       m.ToTable("RolePermissions");
                       m.MapLeftKey("Role_Id");
                       m.MapRightKey("Permission_Id");
                   });

        }
    }
}
