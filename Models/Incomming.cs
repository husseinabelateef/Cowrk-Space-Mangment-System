using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Incomming
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //total price of hours in checkout shift
        public double ShiftCloseReservationIncome{ get; set; }
        // total price of catering in log out shift
        public double ShiftCloseCateringIncome { get; set; }
        [ForeignKey("User")]
        public string AppuserID { get; set; } 
        // Collection of incomming in Receprionst
        //public Receptionist Receptionist { get; set; } 
       public virtual ApplicationUser User { get; set; }

    }
}
