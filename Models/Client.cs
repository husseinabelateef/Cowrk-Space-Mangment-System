using System;
using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Client
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        //Job / graduated / studen
        public string Profession { get; set; }
        public string Faculty { get; set; }
        //name of the QR_Code Image
        public string QR_Code { get; set; }
        public virtual List<Reservation> Reservations { get; set; }
    }
}
