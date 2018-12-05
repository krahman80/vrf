namespace POSB.VRF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VisitorRequestForms", "VisitorIDUpload", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VisitorRequestForms", "VisitorIDUpload", c => c.String());
        }
    }
}
