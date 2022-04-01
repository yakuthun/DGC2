namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_canceledapp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "AppointmentCancelComment", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "AppointmentCancelComment");
        }
    }
}
