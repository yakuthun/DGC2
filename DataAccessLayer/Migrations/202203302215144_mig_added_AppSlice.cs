namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_added_AppSlice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "AppSlice", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Appointments", "AppSlice");
        }
    }
}
