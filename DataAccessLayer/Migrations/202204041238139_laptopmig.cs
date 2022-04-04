namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class laptopmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        CalendarID = c.Int(nullable: false, identity: true),
                        CLSliceID = c.Int(nullable: false),
                        CLUseStartDate = c.DateTime(nullable: false),
                        CLUseFinishDate = c.DateTime(nullable: false),
                        CLStartDate = c.String(),
                        CLStartHour = c.String(),
                        CLFinishDate = c.String(),
                        CLSlice = c.Int(nullable: false),
                        CLAmount = c.Int(nullable: false),
                        CLTolerance = c.Int(nullable: false),
                        CLSumTolerance = c.Int(nullable: false),
                        CLDailyAmount = c.Int(nullable: false),
                        CLDailyPaletAmount = c.Int(nullable: false),
                        CLPalletCapacity = c.Int(nullable: false),
                        SlicesID = c.Int(),
                    })
                .PrimaryKey(t => t.CalendarID)
                .ForeignKey("dbo.Slice", t => t.SlicesID)
                .Index(t => t.SlicesID);
            
            CreateTable(
                "dbo.Slice",
                c => new
                    {
                        SlicesID = c.Int(nullable: false, identity: true),
                        SliceVersion = c.Int(nullable: false),
                        SliceStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SlicesID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserUsername = c.String(maxLength: 50),
                        UserCreatedPassword = c.String(maxLength: 50),
                        UserPassword = c.String(maxLength: 50),
                        UserMail = c.String(maxLength: 70),
                        UserTel = c.String(maxLength: 50),
                        UserRole = c.String(maxLength: 30),
                        UserStatus = c.Boolean(nullable: false),
                        CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            AddColumn("dbo.Chiefs", "ChiefRole", c => c.String(maxLength: 30));
            AddColumn("dbo.Appointments", "AppSlice", c => c.Int());
            AddColumn("dbo.Appointments", "AppStartHour", c => c.String());
            AddColumn("dbo.Appointments", "AppClickTime", c => c.DateTime());
            AddColumn("dbo.Appointments", "InComingDate", c => c.DateTime());
            AddColumn("dbo.Appointments", "DownloadedDate", c => c.DateTime());
            AddColumn("dbo.Appointments", "OutDate", c => c.DateTime());
            AddColumn("dbo.Appointments", "AppointmentUCode", c => c.String(maxLength: 20));
            AddColumn("dbo.Appointments", "AppointmentUpdateComment", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Appointments", "AppointmentCancelComment", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Appointments", "AppDriverLogisticName", c => c.String(maxLength: 50));
            AddColumn("dbo.Appointments", "AppDriverName", c => c.String(maxLength: 50));
            AddColumn("dbo.Appointments", "AppDriverPlate", c => c.String(maxLength: 20));
            AddColumn("dbo.Appointments", "AppDriverNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Appointments", "DriverStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Appointments", "CalendarID", c => c.Int());
            AlterColumn("dbo.Appointments", "AppStartDate", c => c.String());
            AlterColumn("dbo.Appointments", "AppFinishDate", c => c.DateTime());
            AlterColumn("dbo.Drivers", "DriverSurname", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Appointments", "CalendarID");
            AddForeignKey("dbo.Appointments", "CalendarID", "dbo.Calendars", "CalendarID");
            DropColumn("dbo.Appointments", "RealAppStartDate");
            DropColumn("dbo.Appointments", "RealAppFinishDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "RealAppFinishDate", c => c.DateTime());
            AddColumn("dbo.Appointments", "RealAppStartDate", c => c.DateTime());
            DropForeignKey("dbo.Users", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Calendars", "SlicesID", "dbo.Slice");
            DropForeignKey("dbo.Appointments", "CalendarID", "dbo.Calendars");
            DropIndex("dbo.Users", new[] { "CustomerID" });
            DropIndex("dbo.Calendars", new[] { "SlicesID" });
            DropIndex("dbo.Appointments", new[] { "CalendarID" });
            AlterColumn("dbo.Drivers", "DriverSurname", c => c.String(maxLength: 50));
            AlterColumn("dbo.Appointments", "AppFinishDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Appointments", "AppStartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Appointments", "CalendarID");
            DropColumn("dbo.Appointments", "DriverStatus");
            DropColumn("dbo.Appointments", "AppDriverNumber");
            DropColumn("dbo.Appointments", "AppDriverPlate");
            DropColumn("dbo.Appointments", "AppDriverName");
            DropColumn("dbo.Appointments", "AppDriverLogisticName");
            DropColumn("dbo.Appointments", "AppointmentCancelComment");
            DropColumn("dbo.Appointments", "AppointmentUpdateComment");
            DropColumn("dbo.Appointments", "AppointmentUCode");
            DropColumn("dbo.Appointments", "OutDate");
            DropColumn("dbo.Appointments", "DownloadedDate");
            DropColumn("dbo.Appointments", "InComingDate");
            DropColumn("dbo.Appointments", "AppClickTime");
            DropColumn("dbo.Appointments", "AppStartHour");
            DropColumn("dbo.Appointments", "AppSlice");
            DropColumn("dbo.Chiefs", "ChiefRole");
            DropTable("dbo.Users");
            DropTable("dbo.Slice");
            DropTable("dbo.Calendars");
        }
    }
}
