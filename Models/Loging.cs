using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Loging
    {
        public int Id { get; set; }
        //start working hour
        public DateTime Login { get; set; }
        //end working Hours
        public DateTime LogOut { get; set; }

        //total working Hours PerShift
        public int TotalHours { get; set; }

        [ForeignKey("Receptionst")]
        public int Receptionst_Id { get; set; }
        public virtual Receptionist Recpetionst { get; set; }

    }
}
