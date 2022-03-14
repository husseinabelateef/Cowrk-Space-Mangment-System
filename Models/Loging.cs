using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Loging
    {
        public DateTime Login { get; set; }
        public DateTime LogOut { get; set; }
        //[Key]
        //[ForeignKey("Receptionst")]
        //public int Receptionst_Id { get; set; }
        //public virtual Receptionst Recpetionst { get; set; }

    }
}
