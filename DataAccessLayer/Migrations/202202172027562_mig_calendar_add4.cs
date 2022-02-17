namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_calendar_add4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Calendars", "AppointmentID", "dbo.Appointments");
            DropIndex("dbo.Calendars", new[] { "AppointmentID" });
            AddColumn("dbo.Appointments", "CalendarID", c => c.Int());
            CreateIndex("dbo.Appointments", "CalendarID");
            AddForeignKey("dbo.Appointments", "CalendarID", "dbo.Calendars", "CalendarID");
            DropColumn("dbo.Calendars", "AppointmentID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Calendars", "AppointmentID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Appointments", "CalendarID", "dbo.Calendars");
            DropIndex("dbo.Appointments", new[] { "CalendarID" });
            DropColumn("dbo.Appointments", "CalendarID");
            CreateIndex("dbo.Calendars", "AppointmentID");
            AddForeignKey("dbo.Calendars", "AppointmentID", "dbo.Appointments", "AppointmentID", cascadeDelete: true);
        }
    }
}
