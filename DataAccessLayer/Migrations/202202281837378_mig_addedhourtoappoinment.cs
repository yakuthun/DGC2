namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addedhourtoappoinment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "AppStartHour", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "AppStartHour");
        }
    }
}
