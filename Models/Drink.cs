using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Drink
    {

        public int ID { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        [ForeignKey("RawProduct")]
        public int RawProID { get; set; }
        public virtual Product Product { get; set; }
        public virtual RawProduct RawProduct { get; set; }
    }
}
