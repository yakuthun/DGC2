namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_appincomingand_appdownloadedDATE_ADDED : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "InComingDate", c => c.DateTime());
            AddColumn("dbo.Appointments", "DownloadedDate", c => c.DateTime());
            DropColumn("dbo.Appointments", "RealAppStartDate");
            DropColumn("dbo.Appointments", "RealAppFinishDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "RealAppFinishDate", c => c.DateTime());
            AddColumn("dbo.Appointments", "RealAppStartDate", c => c.DateTime());
            DropColumn("dbo.Appointments", "DownloadedDate");
            DropColumn("dbo.Appointments", "InComingDate");
        }
    }
}
