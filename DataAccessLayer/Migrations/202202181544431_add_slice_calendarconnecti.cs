namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_slice_calendarconnecti : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slice",
                c => new
                    {
                        SlicesID = c.Int(nullable: false, identity: true),
                        SliceVersion = c.Int(nullable: false),
                        SliceStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SlicesID);
            
            AddColumn("dbo.Calendars", "CLSliceID", c => c.Int(nullable: false));
            AddColumn("dbo.Calendars", "SlicesID", c => c.Int());
            CreateIndex("dbo.Calendars", "SlicesID");
            AddForeignKey("dbo.Calendars", "SlicesID", "dbo.Slice", "SlicesID");
            DropColumn("dbo.Calendars", "CLVersion");
            DropColumn("dbo.Calendars", "SliceID");
            DropColumn("dbo.Calendars", "CLStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Calendars", "CLStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Calendars", "SliceID", c => c.Int(nullable: false));
            AddColumn("dbo.Calendars", "CLVersion", c => c.Int(nullable: false));
            DropForeignKey("dbo.Calendars", "SlicesID", "dbo.Slice");
            DropIndex("dbo.Calendars", new[] { "SlicesID" });
            DropColumn("dbo.Calendars", "SlicesID");
            DropColumn("dbo.Calendars", "CLSliceID");
            DropTable("dbo.Slice");
        }
    }
}
