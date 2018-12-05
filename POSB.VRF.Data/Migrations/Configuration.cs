namespace POSB.VRF.Data.Migrations
{
    using POSB.VRF.Domain.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<POSB.VRF.Data.VRFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(POSB.VRF.Data.VRFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            #region add Roles
            var roles = new Dictionary<string, Role>
            {
                {"admin", new Role {Id = 1, Name = "Administrator", Description = "Administrator can access all areas of the application by default.", IsAdmin = true, IsActive = true, CreatedBy = "admin", CreatedDate = DateTime.Now, ModifiedBy = "admin", ModifiedDate = DateTime.Now }},
                {"sponsor", new Role {Id = 2, Name = "Sponsor", Description = "", IsAdmin = false, IsActive = true, CreatedBy = "admin", CreatedDate = DateTime.Now, ModifiedBy = "admin", ModifiedDate = DateTime.Now }},
                {"control room", new Role {Id = 3, Name = "Control Room", Description = "", IsAdmin = false, IsActive = true, CreatedBy = "admin", CreatedDate = DateTime.Now, ModifiedBy = "admin", ModifiedDate = DateTime.Now }},
            };

            foreach (var role in roles.Values)
                context.Roles.AddOrUpdate(r => r.Id, role);

            #endregion

            #region Add User
            var users = new Dictionary<string, User>
            {
                {"admin", new User {Id = 1, FullName = "administrator", Login = "admin", Password = "Plv05Fa3eoK4+pFccqHV5Q==", Title = "System Administrator", RoleId = 1, Email = "admin@petrosea.com", IsActive = true, CreatedBy = "admin", CreatedDate = DateTime.Now, ModifiedBy = "admin", ModifiedDate = DateTime.Now }},
                
            };

            foreach (var user in users.Values)
                context.Users.AddOrUpdate(u => u.Id, user);

            #endregion

            #region Add Permission

            var permissions = new Dictionary<string, Permission>
            {
                {"user create", new Permission {Id = 1, Name = "create new user", Description = "create new user", ControllerMethod = "user-create", IsActive = true, CreatedBy = "admin", CreatedDate = DateTime.Now, ModifiedBy = "admin", ModifiedDate = DateTime.Now }},
                {"user edit", new Permission {Id = 2, Name = "edit user", Description = "edit user", ControllerMethod = "user-edit", IsActive = true, CreatedBy = "admin", CreatedDate = DateTime.Now, ModifiedBy = "admin", ModifiedDate = DateTime.Now }}
            };

            foreach (var permission in permissions.Values)
                context.Permissions.AddOrUpdate(r => r.Id, permission);
            #endregion

            #region add Visitor type 

            var visitorTypes = new Dictionary<string, VisitorType>
            {
                {"Petrosea", new VisitorType {Id = 1, Description="Petrosea", IsActive= true, CreatedBy="admin", CreatedDate=DateTime.Now, ModifiedBy="admin", ModifiedDate=DateTime.Now}},
                {"Petrosea's Client", new VisitorType {Id = 2, Description="Petrosea's Client", IsActive= true, CreatedBy="admin", CreatedDate=DateTime.Now, ModifiedBy="admin", ModifiedDate=DateTime.Now}},
                {"Client", new VisitorType {Id = 3, Description="Client", IsActive= true, CreatedBy="admin", CreatedDate=DateTime.Now, ModifiedBy="admin", ModifiedDate=DateTime.Now}},
                {"Client Service Provider", new VisitorType {Id = 4, Description="Client Service Provider", IsActive= true, CreatedBy="admin", CreatedDate=DateTime.Now, ModifiedBy="admin", ModifiedDate=DateTime.Now}},
                {"Guest", new VisitorType {Id = 5, Description="Guest", IsActive= true, CreatedBy="admin", CreatedDate=DateTime.Now, ModifiedBy="admin", ModifiedDate=DateTime.Now}},
            };

            foreach (var visitorType in visitorTypes.Values)
                context.VisitorTypes.AddOrUpdate(r => r.Id, visitorType);

            #endregion


        }
    }
}
