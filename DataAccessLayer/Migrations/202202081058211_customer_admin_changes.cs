namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer_admin_changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCustomers", "CustomerID", "dbo.Customers");
            DropIndex("dbo.SubCustomers", new[] { "CustomerID" });
            DropIndex("dbo.SubCustomers", new[] { "Customer_AdminID" });
            DropColumn("dbo.SubCustomers", "CustomerID");
            RenameColumn(table: "dbo.SubCustomers", name: "Customer_AdminID", newName: "CustomerID");
            AlterColumn("dbo.SubCustomers", "CustomerID", c => c.Int());
            CreateIndex("dbo.SubCustomers", "CustomerID");
            AddForeignKey("dbo.SubCustomers", "CustomerID", "dbo.Customers", "CustomerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCustomers", "CustomerID", "dbo.Customers");
            DropIndex("dbo.SubCustomers", new[] { "CustomerID" });
            AlterColumn("dbo.SubCustomers", "CustomerID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.SubCustomers", name: "CustomerID", newName: "Customer_AdminID");
            AddColumn("dbo.SubCustomers", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.SubCustomers", "Customer_AdminID");
            CreateIndex("dbo.SubCustomers", "CustomerID");
            AddForeignKey("dbo.SubCustomers", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
        }
    }
}
