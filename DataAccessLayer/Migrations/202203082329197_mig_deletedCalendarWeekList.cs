namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_deletedCalendarWeekList : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CalendarWeekLists", "Calendar_CalendarID", "dbo.Calendars");
            DropForeignKey("dbo.Calendars", "CalendarWeekList_DailyID", "dbo.CalendarWeekLists");
            DropForeignKey("dbo.Calendars", "CalendarWeekLists_DailyID", "dbo.CalendarWeekLists");
            DropIndex("dbo.Calendars", new[] { "CalendarWeekList_DailyID" });
            DropIndex("dbo.Calendars", new[] { "CalendarWeekLists_DailyID" });
            DropIndex("dbo.CalendarWeekLists", new[] { "Calendar_CalendarID" });
            DropColumn("dbo.Calendars", "WeekID");
            DropColumn("dbo.Calendars", "CalendarWeekList_DailyID");
            DropColumn("dbo.Calendars", "CalendarWeekLists_DailyID");
            DropTable("dbo.CalendarWeekLists");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CalendarWeekLists",
                c => new
                    {
                        DailyID = c.Int(nullable: false, identity: true),
                        DailyAmount = c.Int(nullable: false),
                        DailyDate = c.DateTime(nullable: false),
                        DailyPaletAmount = c.Int(nullable: false),
                        Calendar_CalendarID = c.Int(),
                    })
                .PrimaryKey(t => t.DailyID);
            
            AddColumn("dbo.Calendars", "CalendarWeekLists_DailyID", c => c.Int());
            AddColumn("dbo.Calendars", "CalendarWeekList_DailyID", c => c.Int());
            AddColumn("dbo.Calendars", "WeekID", c => c.Int());
            CreateIndex("dbo.CalendarWeekLists", "Calendar_CalendarID");
            CreateIndex("dbo.Calendars", "CalendarWeekLists_DailyID");
            CreateIndex("dbo.Calendars", "CalendarWeekList_DailyID");
            AddForeignKey("dbo.Calendars", "CalendarWeekLists_DailyID", "dbo.CalendarWeekLists", "DailyID");
            AddForeignKey("dbo.Calendars", "CalendarWeekList_DailyID", "dbo.CalendarWeekLists", "DailyID");
            AddForeignKey("dbo.CalendarWeekLists", "Calendar_CalendarID", "dbo.Calendars", "CalendarID");
        }
    }
}
