using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Chief
    {
        [Key]
        public int ChiefID { get; set; }
        [StringLength(50)]
        public string ChiefUsername { get; set; }
        [StringLength(50)]
        public string ChiefPassword { get; set; }

        public int BranchNo { get; set; }
        [StringLength(20)]
        public string ChiefTel { get; set; }
        [StringLength(20)]
        public string ChiefName { get; set; }
        [StringLength(20)]
        public string ChiefSurname { get; set; }

        public DateTime ChiefStartDate { get; set; }

        public DateTime ChiefFinishDate { get; set; }
        public bool ChiefStatus { get; set; }

        public ICollection<AppManagement> AppManagements { get; set; }
        public ICollection<Appointment> Appointments { get; set; }
    }
}
