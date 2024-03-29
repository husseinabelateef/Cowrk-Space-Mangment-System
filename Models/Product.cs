﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Enter Product Name")]
        public string Name { get; set; }

        //price from supplier
        [Required(ErrorMessage = "Enter Actual Price")]
        public double ActualPrice { get; set; }

        //price I will sell to clients with
        [Required(ErrorMessage = "Enter Selling Price")]
        public double SellingPrice { get; set; }

        // barcode printed in every product 
        public string BarCode { get; set; }

        //Actual Amount in place
        [Required(ErrorMessage = "Enter Actual Price")]
        public int ActualAmount { get; set; }
        [Required(ErrorMessage = "Enter ExpireDate")]
        [DataType(DataType.Date)]
        public DateTime ExpireDate { get; set; }
        public ICollection<Drink> Drinks { get; set; }
        public virtual ICollection<ProductMovments> ProductMovments { get; set; }
        public override int GetHashCode()
        {
            return base.GetHashCode();

        }
        public override bool Equals(object obj)
        {
            Product product = obj as Product;
            if (product == null)
                return false;
            if (product.Id != this.Id)
                return false;
            return true;
            
        }

        public Product()
        {
            this.Id = Guid.NewGuid();
        }

    }


}
