using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Cart
    {
        public int ID { get; set; }
        //for anonumous or client cart
        [Display(Name ="Client")]
        public bool IsClient { get; set; }
        [Display(Name ="Price For Your Catering")]
        public int TotalPrice { get; set; }
        [Display(Name ="Invoice Date")]
        public DateTime Date { get; set; }


        public virtual List<Product> Products { get; set; }
    }
}
