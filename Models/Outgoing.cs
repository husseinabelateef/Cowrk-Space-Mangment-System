using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Outgoing
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }

        //[ForeignKey("reciption")]
        //public int Reciption_ID { get; set; }
        //public virtual Reciption reciption { get; set; }
    }
}
