using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Room
    {
        //Individual / shared / nook1 / nook2
        public int ID { get; set; }
       
        public string Name { get; set; }

        public virtual ICollection<Chair> Chairs { get; set; }
        public ICollection<RoomReserve> RoomReserve { get; set; }

    }
}
