using System.Collections.Generic;
using Cowrk_Space_Mangment_System.Models;

namespace Cowrk_Space_Mangment_System.Repository
{
    public interface ICartRepository: Irepository<Cart,int>
    {
        public List<Cart> GetAllUnpaidCart();
        public List<Cart> GetAllUnpaidVistorsCart();
        public List<Cart> GetAllUnpaidClientsCart();
        public int GetUnpaidCount();
        public int GetAllUnpaidCountVistorsCart();
        public int GetAllUnpaidCountClientsCart();

    }
}
