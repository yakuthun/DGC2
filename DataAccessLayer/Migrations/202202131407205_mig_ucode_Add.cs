namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_ucode_Add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "AppointmentUCode", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "AppointmentUCode");
        }
    }
}
