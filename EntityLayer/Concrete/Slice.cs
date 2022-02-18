using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Slice
    {
        [Key]
        public int SlicesID { get; set; }
        public int SliceVersion { get; set; }
        public bool SliceStatus { get; set; }
        public ICollection<Calendar> Calendars { get; set; }
    }
}
