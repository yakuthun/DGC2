using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(50)]
        public string UserUsername { get; set; }
        [StringLength(50)]
        public string UserCreatedPassword { get; set; }
        [StringLength(50)]
        public string UserPassword { get; set; }
        [StringLength(70)]
        public string UserMail { get; set; }
        [StringLength(50)]
        public string UserTel { get; set; }
        [StringLength(30)]
        public string UserRole { get; set; }

        public bool UserStatus { get; set; }

        public int? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
