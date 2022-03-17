using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Room
    {
        public int ID { get; set; }
        //Individual / shared / nook1/nook2
        public string Name { get; set; }

        public virtual List<Chair> Chairs { get; set; }
        public ICollection<RoomReserve> RoomReserve { get; set; }

    }
}
