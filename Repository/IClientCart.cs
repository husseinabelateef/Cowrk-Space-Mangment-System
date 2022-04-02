using Cowrk_Space_Mangment_System.Models;

namespace Cowrk_Space_Mangment_System.Repository
{
    public interface IClientCart : Irepository<ClientCart , int>
    {
        public string clientName(int CartId);
    }
}
