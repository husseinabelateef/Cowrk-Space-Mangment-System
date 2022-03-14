using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class RoomReserve
    {
        public int Id { get; set; }
        [ForeignKey("Reservation")]
        public int Reservation_Id { get; set; }
        [ForeignKey("Room")]
        public int Rooom_Id { get; set; }
        public DateTime End_Time { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual Room Room { get; set; }
    }
}
