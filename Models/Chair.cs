using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Chair
    {
        public int Id { get; set; }
        [ForeignKey("Room")]
        public int Room_ID { get; set; }
        //true available false Not
        public bool Availability { get; set; }
        public virtual ICollection<ChairReserve> ChairReserves { get; set; }

        public virtual Room Room { get; set; }
    }
}
