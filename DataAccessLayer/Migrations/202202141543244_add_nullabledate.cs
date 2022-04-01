namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_nullabledate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Appointments", "AppFinishDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "AppFinishDate", c => c.DateTime(nullable: false));
        }
    }
}
