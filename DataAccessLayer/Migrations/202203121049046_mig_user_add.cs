namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_user_add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserUsername = c.String(maxLength: 50),
                        UserCreatedPassword = c.String(maxLength: 50),
                        UserPassword = c.String(maxLength: 50),
                        UserMail = c.String(maxLength: 70),
                        UserTel = c.String(maxLength: 50),
                        UserStatus = c.Boolean(nullable: false),
                        CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Users", new[] { "CustomerID" });
            DropTable("dbo.Users");
        }
    }
}
