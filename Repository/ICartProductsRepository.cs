using System;
using System.Collections.Generic;
using Cowrk_Space_Mangment_System.Models;
namespace Cowrk_Space_Mangment_System.Repository
{
    public interface ICartProductsRepository : Irepository<CartProducts , int>
    {
        public List<CartProducts> GetAllProductOfCategory(int categoryId);
        public int RemoveItem(CartProducts item);
        public CartProducts getAnItem(int cartId, Guid ProductId);
    }
}
