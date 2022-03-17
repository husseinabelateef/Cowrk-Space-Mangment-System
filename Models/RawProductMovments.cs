using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class RawProductMovments
    {
        [ForeignKey("RawProduct")]
        public int Raw_ProductID { get; set; }
        [ForeignKey("Outgoing")]
        public int OutgoingID { get; set; }
        public double Amount { get; set; }
        public virtual RawProduct RawProduct { get; set; }
        public virtual Outgoing Outgoing { get; set; }
    }
}
