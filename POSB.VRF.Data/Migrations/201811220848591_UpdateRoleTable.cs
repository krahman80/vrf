namespace POSB.VRF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRoleTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Roles", "IsAdmin", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "IsAdmin", c => c.Byte());
        }
    }
}
