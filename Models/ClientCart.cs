using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class ClientCart
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Reservation")]
        public int Reservation_ID { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Cart")]
        public int Cart_Id { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
