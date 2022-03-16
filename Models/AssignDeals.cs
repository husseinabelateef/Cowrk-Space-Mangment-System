using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace Cowrk_Space_Mangment_System.Models
{
    public class AssignDeals
    {
        public int ID { get; set; }
        [ForeignKey("Deal")]
        public int DealID { get; set; }
        [ForeignKey("Client")]
        public Guid ClientID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Deal Deal { get; set; }
        public virtual Client Client { get; set; }

    }
}
