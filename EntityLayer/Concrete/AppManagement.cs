using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AppManagement
    {
        [Key]
        public int APPManagementID { get; set; }
        [StringLength(50)]
        public string APPMCapacity { get; set; }
        [StringLength(50)]
        public string APPMLoadType { get; set; }

        public int ChiefID { get; set; }
        public virtual Chief Chief { get; set; }

    }
}
