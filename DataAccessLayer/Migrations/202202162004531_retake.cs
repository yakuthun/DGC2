namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class retake : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "DriverSurname", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "DriverSurname");
        }
    }
}
