using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Chief> Chiefs { get; set; }
        public DbSet<SubCustomer> SubCustomers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<AppManagement> AppManagements { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Slice> Slices { get; set; }
    }
}
