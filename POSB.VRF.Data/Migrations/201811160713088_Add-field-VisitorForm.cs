namespace POSB.VRF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddfieldVisitorForm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitorRequestForms", "VisitDestination", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisitorRequestForms", "VisitDestination");
        }
    }
}
