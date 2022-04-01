namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_added_dailypalet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calendars", "CLDailyPaletAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calendars", "CLDailyPaletAmount");
        }
    }
}
