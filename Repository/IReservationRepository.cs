using Cowrk_Space_Mangment_System.Models;
using System;

namespace Cowrk_Space_Mangment_System.Repository
{
    public interface IReservationRepository : Irepository<Reservation, int>
    {
        Reservation where(Func<object, object> p);
    }
}
