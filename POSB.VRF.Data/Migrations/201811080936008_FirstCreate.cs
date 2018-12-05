namespace POSB.VRF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 255),
                        ControllerMethod = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 255),
                        IsAdmin = c.Byte(),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Title = c.String(maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 150),
                        RoleId = c.Int(nullable: false),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.VisitorRequestForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitorName = c.String(nullable: false, maxLength: 50),
                        VisitorEmail = c.String(nullable: false, maxLength: 70),
                        VisitorPhone = c.String(nullable: false, maxLength: 20),
                        VisitorTypeId = c.Int(nullable: false),
                        VisitorCompany = c.String(maxLength: 50),
                        VisitPurpose = c.String(maxLength: 255),
                        VisitEntryDate = c.DateTime(nullable: false),
                        VisitEndDate = c.DateTime(nullable: false),
                        VisitDuration = c.String(),
                        VisitorIDUpload = c.String(),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VisitorTypes", t => t.VisitorTypeId)
                .Index(t => t.VisitorTypeId);
            
            CreateTable(
                "dbo.VisitorTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 50),
                        CreatedBy = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RolePermissions",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Permission_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Permission_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Permissions", t => t.Permission_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Permission_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisitorRequestForms", "VisitorTypeId", "dbo.VisitorTypes");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RolePermissions", "Permission_Id", "dbo.Permissions");
            DropForeignKey("dbo.RolePermissions", "Role_Id", "dbo.Roles");
            DropIndex("dbo.RolePermissions", new[] { "Permission_Id" });
            DropIndex("dbo.RolePermissions", new[] { "Role_Id" });
            DropIndex("dbo.VisitorRequestForms", new[] { "VisitorTypeId" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropTable("dbo.RolePermissions");
            DropTable("dbo.VisitorTypes");
            DropTable("dbo.VisitorRequestForms");
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
            DropTable("dbo.Permissions");
        }
    }
}
