namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_670 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "AppStartDate", c => c.DateTime());
            AlterColumn("dbo.Appointments", "AppStartHour", c => c.DateTime());
            AlterColumn("dbo.Appointments", "AppClickTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "AppClickTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Appointments", "AppStartHour", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Appointments", "AppStartDate", c => c.DateTime(nullable: false));
        }
    }
}
