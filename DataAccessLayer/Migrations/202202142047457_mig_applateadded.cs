namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_applateadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "DriverComment", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Appointments", "AppPlate", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "AppPlate");
            DropColumn("dbo.Appointments", "DriverComment");
        }
    }
}
