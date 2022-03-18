using System;
using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Models
{
    public class RawProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // REMAINING AMOUNT RECEPTIONST WILL ADDED IT 
        public double ActualAmount { get; set; }
        
        // references that one cup weight from that raw data 
        public double RefrenceCupWeight { get; set; } // 
        //expected number of cups for this raw data entered
        public int Quantity { get; set; }

        //number of cups has been sealed
        public int NOC { get; set; }
        // Expire date 
        public DateTime ExpireDate { get; set; }

        public virtual ICollection<Drink> Drinks { get; set; }
        public virtual ICollection<RawProductMovments> RawProductMovments { get; set; }


    }
}
