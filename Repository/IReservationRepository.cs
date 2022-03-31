using Cowrk_Space_Mangment_System.Models;

namespace Cowrk_Space_Mangment_System.Repository
{
    public interface IReservationRepository: Irepository<Reservation,int>
    {
        public int GetReservationIdForUser(int ClientId);
        public Cart GetLastCartForUser(int ClientId);
    }
}
