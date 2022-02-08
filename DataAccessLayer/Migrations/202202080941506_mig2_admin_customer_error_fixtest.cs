namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2_admin_customer_error_fixtest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCustomers", "CustomerID", "dbo.Customers");
            AddColumn("dbo.SubCustomers", "Customer_AdminID", c => c.Int());
            CreateIndex("dbo.SubCustomers", "Customer_AdminID");
            AddForeignKey("dbo.SubCustomers", "Customer_AdminID", "dbo.Admins", "AdminID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCustomers", "Customer_AdminID", "dbo.Admins");
            DropIndex("dbo.SubCustomers", new[] { "Customer_AdminID" });
            DropColumn("dbo.SubCustomers", "Customer_AdminID");
            AddForeignKey("dbo.SubCustomers", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
        }
    }
}
