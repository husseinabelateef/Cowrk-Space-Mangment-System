using System;
using System.Collections.Generic;
using Cowrk_Space_Mangment_System.Models;
namespace Cowrk_Space_Mangment_System.Repository
   
{
    public interface IDrinkRepository : Irepository<Drink , int>
    {
        public List<RawProduct> ProductMaterial(Guid ProductID);
        public List<Product> RawAvailableFor(int RawProductId);
    }
}
