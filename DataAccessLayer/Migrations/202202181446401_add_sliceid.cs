namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_sliceid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calendars", "SliceID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calendars", "SliceID");
        }
    }
}
