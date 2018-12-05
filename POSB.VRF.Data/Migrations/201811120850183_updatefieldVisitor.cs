namespace POSB.VRF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefieldVisitor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitorRequestForms", "VisitStartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.VisitorRequestForms", "VisitEntryDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VisitorRequestForms", "VisitEntryDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.VisitorRequestForms", "VisitStartDate");
        }
    }
}
