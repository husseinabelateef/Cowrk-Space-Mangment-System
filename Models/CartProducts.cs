using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class CartProducts
    {
        [ForeignKey("Cart")]
        public int Cart_Id { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public int Quentaty { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
