using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class ProductMovments
    {
        [ForeignKey("Product")]
        public Guid ProductID { get; set; }
        [ForeignKey("Outgoing")]
        public int OutgoingID { get; set; }
        //Added To system 
        public double Amount { get; set; }
        public virtual Product Product { get; set; }
        public virtual Outgoing Outgoing { get; set; }
    }
}
