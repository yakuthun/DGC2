namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_appupdatecomment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "AppointmentUpdateComment", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Appointments", "DriverComment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "DriverComment", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Appointments", "AppointmentUpdateComment");
        }
    }
}
