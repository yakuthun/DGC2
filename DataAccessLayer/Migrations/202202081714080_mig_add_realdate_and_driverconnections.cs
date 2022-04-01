namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_realdate_and_driverconnections : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "RealAppStartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "RealAppFinishDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Appointments", "DriverID", c => c.Int());
            CreateIndex("dbo.Appointments", "DriverID");
            AddForeignKey("dbo.Appointments", "DriverID", "dbo.Drivers", "DriverID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "DriverID", "dbo.Drivers");
            DropIndex("dbo.Appointments", new[] { "DriverID" });
            DropColumn("dbo.Appointments", "DriverID");
            DropColumn("dbo.Appointments", "RealAppFinishDate");
            DropColumn("dbo.Appointments", "RealAppStartDate");
        }
    }
}
