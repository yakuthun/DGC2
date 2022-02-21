namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_testsr34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calendars", "CLDailyAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calendars", "CLDailyAmount");
        }
    }
}
