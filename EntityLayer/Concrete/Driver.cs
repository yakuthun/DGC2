using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Driver
    {
        [Key]
        public int DriverID { get; set; }
        [StringLength(50)]
        public string DriverLogisticName { get; set; }
        [StringLength(50)]
        public string DriverName { get; set; }
        [StringLength(50)]
        public string DriverSurname { get; set; }
        [StringLength(20)]
        public string DriverPlate { get; set; }
        [StringLength(20)]
        public string DriverNumber { get; set; }
        public bool DriverStatus { get; set; }


        public int SubCustomerID { get; set; }
        public virtual SubCustomer SubCustomer { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
