namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_calendar_add2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        CalendarID = c.Int(nullable: false, identity: true),
                        CLVersion = c.Int(nullable: false),
                        CLStatus = c.Boolean(nullable: false),
                        CLUseStartDate = c.DateTime(nullable: false),
                        CLUseFinishDate = c.DateTime(nullable: false),
                        CLStartDate = c.DateTime(nullable: false),
                        CLFinishDate = c.DateTime(nullable: false),
                        CLSlice = c.Int(nullable: false),
                        CLAmount = c.Int(nullable: false),
                        CLTolerance = c.Int(nullable: false),
                        CLSumTolerance = c.Int(nullable: false),
                        CLPalletCapacity = c.Int(nullable: false),
                        AppointmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CalendarID)
                .ForeignKey("dbo.Appointments", t => t.AppointmentID, cascadeDelete: true)
                .Index(t => t.AppointmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Calendars", "AppointmentID", "dbo.Appointments");
            DropIndex("dbo.Calendars", new[] { "AppointmentID" });
            DropTable("dbo.Calendars");
        }
    }
}
