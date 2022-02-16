using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        public int AppointmentCapacity { get; set; }
        [StringLength(50)]
        public string AppointmentLoadType { get; set; }
        [StringLength(50)]
        public string AppointmentName { get; set; }
        [StringLength(200)]
        [Required(AllowEmptyStrings = true)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string AppointmentImage { get; set; }
        [StringLength(200)]
        [Required(AllowEmptyStrings = true)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string AppointmentComment { get; set; }

        public DateTime AppStartDate { get; set; }

        public DateTime? AppFinishDate { get; set; }

        public DateTime? InComingDate { get; set; }

        public DateTime? DownloadedDate { get; set; }
        [StringLength(20)]
        public string AppointmentUCode { get; set; }
        public bool AppointmentStatus { get; set; }
        public int AppointmentTrackStatus { get; set; }
        [StringLength(200)]
        [Required(AllowEmptyStrings = true)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string DriverComment { get; set; }

        [StringLength(50)]
        public string AppDriverLogisticName { get; set; }
        [StringLength(50)]
        public string AppDriverName { get; set; }
        [StringLength(20)]
        public string AppDriverPlate { get; set; }
        [StringLength(20)]
        public string AppDriverNumber { get; set; }

        public bool DriverStatus { get; set; }
        public int SubCustomerID { get; set; }
        public virtual SubCustomer SubCustomer { get; set; }

        public int ChiefID { get; set; }
        public virtual Chief Chief { get; set; }

     


        public int? DriverID { get; set; }
        public virtual Driver Driver { get; set; }

    }
}
