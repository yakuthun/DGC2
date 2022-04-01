namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_appupdate_sbmmail_appacptupdatess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 10));
            AddColumn("dbo.Chiefs", "ChiefCreatedPassword", c => c.String(maxLength: 50));
            AddColumn("dbo.Appointments", "AppointmentName", c => c.String(maxLength: 50));
            AddColumn("dbo.Appointments", "AppointmentImage", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Appointments", "AppointmentComment", c => c.String(nullable: false, maxLength: 200));
            AddColumn("dbo.Appointments", "AppointmentAcceptStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.SubCustomers", "SubCustomerCreatedPassword", c => c.String(maxLength: 50));
            AddColumn("dbo.SubCustomers", "SubCustomerMail", c => c.String(maxLength: 50));
            AddColumn("dbo.Customers", "CustomerCreatedPassword", c => c.String(maxLength: 50));
            AlterColumn("dbo.Appointments", "RealAppStartDate", c => c.DateTime());
            AlterColumn("dbo.Appointments", "RealAppFinishDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Appointments", "RealAppFinishDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Appointments", "RealAppStartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "CustomerCreatedPassword");
            DropColumn("dbo.SubCustomers", "SubCustomerMail");
            DropColumn("dbo.SubCustomers", "SubCustomerCreatedPassword");
            DropColumn("dbo.Appointments", "AppointmentAcceptStatus");
            DropColumn("dbo.Appointments", "AppointmentComment");
            DropColumn("dbo.Appointments", "AppointmentImage");
            DropColumn("dbo.Appointments", "AppointmentName");
            DropColumn("dbo.Chiefs", "ChiefCreatedPassword");
            DropColumn("dbo.Admins", "AdminRole");
        }
    }
}
