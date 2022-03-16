using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Reservation
    {
        public int ID { get; set; }
        public DateTime Start_Time { get; set; }

        //number Of hours want to Reserve 
        public int ExpextedHours { get; set; }
        [ForeignKey("Receptionst")]
        public int Receptionst_Id { get; set; }
        [ForeignKey("Client")]
        public Guid Client_ID { get; set; }
        [ForeignKey("ClientCart")]
        public int ClientCart_ID { get; set; }
        // DD/MM/YY
        public DateTime Date { get; set; }
        public double Hours_Price { get; set; }

        public double TotalPrice { get; set; }
        public virtual Client Client { get; set; }
        public virtual ClientCart ClientCart { get; set; }
        public ICollection<RoomReserve> RoomReserve { get; set; }
        public virtual ChairReserve ChairReserves { get; set; }
        public virtual Receptionist Recpetionst { get; set; }
    }
}
