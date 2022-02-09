using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SubCustomer
    {
        [Key]
        public int SubCustomerID { get; set; }
        [StringLength(50)]
        public string SubCustomerUsername { get; set; }
        [StringLength(50)]
        public string SubCustomerPassword { get; set; }
        [StringLength(20)]
        public string SubCustomerName { get; set; }
        [StringLength(20)]
        public string SubCustomerSurname { get; set; }
        [StringLength(50)]
        public string SubCustomerCode { get; set; }
        [StringLength(300)]
        public string SubCustomerAddress { get; set; }
        [StringLength(70)]
        public string SubCustomerCompany { get; set; }
        public bool SubCustomerStatus { get; set; }


        public int? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }


        public ICollection<Driver> Drivers { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
