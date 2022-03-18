using System;
using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //price from supplier
        public double ActualPrice { get; set; }
        //price I will sell to clients with
        public double SellingPrice { get; set; }
        // barcode printed in every product 

        public string BarCode { get; set; }

        //Actual Amount in place
        public int ActualAmount { get; set; }
        public DateTime ExpireDate { get; set; }
        public ICollection<Drink> Drinks { get; set; }
        public virtual ICollection<ProductMovments> ProductMovments { get; set; }

    }


}
