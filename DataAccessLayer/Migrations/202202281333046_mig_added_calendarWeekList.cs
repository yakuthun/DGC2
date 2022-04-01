namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_added_calendarWeekList : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.DailyID)
                .ForeignKey("dbo.Calendars", t => t.Calendar_CalendarID)
                .Index(t => t.Calendar_CalendarID);
            
            AddColumn("dbo.Calendars", "WeekID", c => c.Int());
            AddColumn("dbo.Calendars", "CalendarWeekList_DailyID", c => c.Int());
            AddColumn("dbo.Calendars", "CalendarWeekLists_DailyID", c => c.Int());
            CreateIndex("dbo.Calendars", "CalendarWeekList_DailyID");
            CreateIndex("dbo.Calendars", "CalendarWeekLists_DailyID");
            AddForeignKey("dbo.Calendars", "CalendarWeekList_DailyID", "dbo.CalendarWeekLists", "DailyID");
            AddForeignKey("dbo.Calendars", "CalendarWeekLists_DailyID", "dbo.CalendarWeekLists", "DailyID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calendars", "CalendarWeekLists_DailyID", "dbo.CalendarWeekLists");
            DropForeignKey("dbo.Calendars", "CalendarWeekList_DailyID", "dbo.CalendarWeekLists");
            DropForeignKey("dbo.CalendarWeekLists", "Calendar_CalendarID", "dbo.Calendars");
            DropIndex("dbo.CalendarWeekLists", new[] { "Calendar_CalendarID" });
            DropIndex("dbo.Calendars", new[] { "CalendarWeekLists_DailyID" });
            DropIndex("dbo.Calendars", new[] { "CalendarWeekList_DailyID" });
            DropColumn("dbo.Calendars", "CalendarWeekLists_DailyID");
            DropColumn("dbo.Calendars", "CalendarWeekList_DailyID");
            DropColumn("dbo.Calendars", "WeekID");
            DropTable("dbo.CalendarWeekLists");
        }
    }
}
