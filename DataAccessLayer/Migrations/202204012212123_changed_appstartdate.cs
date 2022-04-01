namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_appstartdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "AppStartDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "AppStartDate", c => c.DateTime());
        }
    }
}
