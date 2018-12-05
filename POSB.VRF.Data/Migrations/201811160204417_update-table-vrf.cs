namespace POSB.VRF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetablevrf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VisitorRequestForms", "VisitorCompany", c => c.String(maxLength: 50));
            AlterColumn("dbo.VisitorRequestForms", "VisitPurpose", c => c.String(maxLength: 255));
            AlterColumn("dbo.VisitorRequestForms", "VisitorIDUpload", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VisitorRequestForms", "VisitorIDUpload", c => c.String(nullable: false));
            AlterColumn("dbo.VisitorRequestForms", "VisitPurpose", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.VisitorRequestForms", "VisitorCompany", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
