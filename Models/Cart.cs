using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace Cowrk_Space_Mangment_System.Models
{
    public class Cart
    {
        public int ID { get; set; }
      //for anonumous or client cart
        public bool IsClient { get; set; }
        public int TotalPrice { get; set; }

        public DateTime Date { get; set; }


        public virtual List<Product> Products { get; set; }
    }
}
