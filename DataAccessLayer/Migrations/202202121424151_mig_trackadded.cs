namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_trackadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "AppointmentTrackStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "AppointmentAcceptStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "AppointmentAcceptStatus", c => c.Boolean(nullable: false));
            DropColumn("dbo.Appointments", "AppointmentTrackStatus");
        }
    }
}
