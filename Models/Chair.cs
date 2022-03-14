using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Chair
    {
        public int Id { get; set; }
        [ForeignKey("Room")]
        public int Room_ID { get; set; }
        public bool availability { get; set; }

      //  public virtual Room Room { get; set;  }
    }
}
