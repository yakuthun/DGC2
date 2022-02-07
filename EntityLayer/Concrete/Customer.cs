using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [StringLength(50)]
        public string CustomerUsername { get; set; }
        [StringLength(50)]
        public string CustomerPassword { get; set; }
        [StringLength(70)]
        public string CustomernMail { get; set; }
        [StringLength(20)]
        public string CustomerTel { get; set; }
        [StringLength(70)]
        public string CompanyCode { get; set; }
        [StringLength(70)]
        public string CompanyName { get; set; }
        public int TaxNO { get; set; }
        [StringLength(70)]
        public string TaxDepartment { get; set; }
        [StringLength(300)]
        public string CustomerAddress { get; set; }
        [StringLength(50)]
        public string Sector { get; set; }

        public DateTime CustomerStartDate { get; set; }
      
        public DateTime CustomerFinishDate { get; set; }
        public bool CustomerStatus { get; set; }

        public ICollection<SubCustomer> SubCustomers { get; set; }

    }
}
