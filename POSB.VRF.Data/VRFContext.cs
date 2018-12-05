using System.Data.Entity;
using POSB.VRF.Domain.Models;
using POSB.VRF.Data.EntityConfigurations;
namespace POSB.VRF.Data
{
    public class VRFContext : DbContext
    {

        public VRFContext()
            : base("VRFContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

            public virtual DbSet<User> Users { get; set; }
            public virtual DbSet<Role> Roles { get; set; }
            public virtual DbSet<Permission> Permissions { get; set; }
            public virtual DbSet<VisitorRequestForm> VisitorRequestForms { get; set; }
            public virtual DbSet<VisitorType> VisitorTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Types().Configure(entity => entity.ToTable("POSB." + entity.ClrType.Name));
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new PermissionConfiguration());
            modelBuilder.Configurations.Add(new VisitorTypeConfiguration());
            modelBuilder.Configurations.Add(new VisitorRequestFormConfiguration());
        }

    }
}
