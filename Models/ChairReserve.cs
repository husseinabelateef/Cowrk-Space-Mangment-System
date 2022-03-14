using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class ChairReserve
    {
        public int Id { get; set; }
        [ForeignKey("Chair")]
        public int Chair_Id { get; set; }
        [ForeignKey("Reservation")]
        public int Reservation_Id { get; set; }
        public DateTime End_Time { get; set; }
        public virtual Chair Chair { get; set; }
        public virtual Reservation Reservation { get; set; }

    }
}
