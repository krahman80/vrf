using POSB.VRF.Domain.Models;
using System.Data.Entity.ModelConfiguration;

namespace POSB.VRF.Data.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {

            Property(u => u.Login)
                .IsRequired()
                .HasMaxLength(50);

            Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            Property(u => u.Title)
                .IsOptional()
                .HasMaxLength(100);

            Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(150);

            Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            HasRequired(r => r.Roles)
                .WithMany(u => u.Users)
                .HasForeignKey(u => u.RoleId)
                .WillCascadeOnDelete(false);

        }
    }
}
