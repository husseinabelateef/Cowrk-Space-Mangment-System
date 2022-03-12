using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public DateTime Start_Time { get; set; }
        public DateTime End_Time { get; set; }
        public int Reciptionist_ID { get; set; }
        [ForeignKey("client")]
        public int Client_ID { get; set; }
        [ForeignKey("cart")]
        public int Cart_ID { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual Client client { get; set; }
        public virtual Cart cart { get; set; }
    }
}
