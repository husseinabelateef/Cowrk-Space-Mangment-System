using Cowrk_Space_Mangment_System.Models;
using System;
using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Repository

{
    public interface IProductRepository : Irepository<Product,Guid>
    {
        //List of Expired Product
        public List<Product> ExpiredProduct();
    }
}
