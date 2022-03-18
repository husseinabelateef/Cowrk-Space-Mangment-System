using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Client
    {
        public Guid ID { get; set; }
        [Display(Name = "Client Name")]
        [Required(ErrorMessage = "Name Required")]
        [RegularExpression(@"^[A-Za-z]{3,}(\s[A-Za-z]{3,})+$",
            ErrorMessage = "Name is not valid")]
        public string Name { get; set; }
        //Job / graduated / student
        [Required(ErrorMessage ="Profession is Required")]
        public string Profession { get; set; }
        public string Faculty { get; set; }
        //name of the QR_Code Image
        public string QR_Code { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
