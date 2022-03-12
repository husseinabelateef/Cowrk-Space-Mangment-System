using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
        public string Faculty { get; set; }
        public string QR_Code { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
