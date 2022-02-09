namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_driverupdate_subcustomername_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "DriverPlate", c => c.String(maxLength: 20));
            AddColumn("dbo.Drivers", "DriverNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.SubCustomers", "SubCustomerCompany", c => c.String(maxLength: 70));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubCustomers", "SubCustomerCompany");
            DropColumn("dbo.Drivers", "DriverNumber");
            DropColumn("dbo.Drivers", "DriverPlate");
        }
    }
}
