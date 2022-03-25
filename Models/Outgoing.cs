using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Outgoing
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("reciption")]
        public string Reciption_ID { get; set; }
        public virtual Receptionist reciption { get; set; }
        public virtual ICollection<RawProductMovments> RawProductMovments { get; set; }
        public virtual ICollection<ProductMovments> ProductMovments { get; set; }



    }
}
