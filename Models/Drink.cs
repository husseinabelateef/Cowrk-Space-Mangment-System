using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Drink
    {


        [ForeignKey("Product")]
        [Key, Column(Order = 0)]
        public int ProductId { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("RawProduct")]
        public int RawProID { get; set; }
        public virtual Product Product { get; set; }
        public virtual RawProduct RawProduct { get; set; }
    }
}
