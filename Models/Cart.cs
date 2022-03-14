using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Cart
    {
        public int ID { get; set; }
        [ForeignKey("Reservation")]
        public int Reservation_ID { get; set; }
        public int TotalPrice { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
