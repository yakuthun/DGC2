namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_appdriverall_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "AppDriverLogisticName", c => c.String(maxLength: 50));
            AddColumn("dbo.Appointments", "AppDriverName", c => c.String(maxLength: 50));
            AddColumn("dbo.Appointments", "AppDriverPlate", c => c.String(maxLength: 20));
            AddColumn("dbo.Appointments", "AppDriverNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.Appointments", "DriverStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Appointments", "AppPlate");
            DropColumn("dbo.Drivers", "DriverSurname");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "DriverSurname", c => c.String(maxLength: 50));
            AddColumn("dbo.Appointments", "AppPlate", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Appointments", "DriverStatus");
            DropColumn("dbo.Appointments", "AppDriverNumber");
            DropColumn("dbo.Appointments", "AppDriverPlate");
            DropColumn("dbo.Appointments", "AppDriverName");
            DropColumn("dbo.Appointments", "AppDriverLogisticName");
        }
    }
}
