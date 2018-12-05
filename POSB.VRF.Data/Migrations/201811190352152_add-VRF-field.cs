namespace POSB.VRF.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVRFfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitorRequestForms", "SponsorName", c => c.String(maxLength: 50));
            AddColumn("dbo.VisitorRequestForms", "SponsorEmail", c => c.String(maxLength: 70));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisitorRequestForms", "SponsorEmail");
            DropColumn("dbo.VisitorRequestForms", "SponsorName");
        }
    }
}
