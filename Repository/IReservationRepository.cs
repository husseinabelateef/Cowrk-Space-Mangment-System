using Cowrk_Space_Mangment_System.Models;
using System;

namespace Cowrk_Space_Mangment_System.Repository
{
    public interface IReservationRepository : Irepository<Reservation, int>
    {
        public Cart GetLastCartForUser(int client);
        Reservation where(Func<object, object> p);
    }
}
