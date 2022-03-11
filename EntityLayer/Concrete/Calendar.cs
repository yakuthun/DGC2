using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Calendar
    {
        [Key]
        public int CalendarID { get; set; }
        public int CLSliceID { get; set; }
        public DateTime CLUseStartDate  { get; set; }
        public DateTime CLUseFinishDate  { get; set; }
        public DateTime CLStartDate { get; set; }
        public DateTime CLStartHour { get; set; }
        public DateTime CLFinishDate { get; set; }
        public int CLSlice { get; set; }
        public int CLAmount { get; set; }
        public int CLTolerance { get; set; }
        public int CLSumTolerance { get; set; }
        public int CLDailyAmount { get; set; }
        public int CLDailyPaletAmount { get; set; }
        public int CLPalletCapacity { get; set; }
        public int? SlicesID { get; set; }
        public virtual Slice Slice { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

        




    }
}
